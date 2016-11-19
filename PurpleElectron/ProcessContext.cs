using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;

using CSCore;
using CSCore.Codecs.WAV;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.Streams;
using CSCore.Win32;


namespace PurpleElectron {
	public class ProcessContext : ApplicationContext {

		private NotifyIcon trayIcon;
		private MenuItem captureItem;

		private int currentFile = 0;

		// System audio
		private WasapiLoopbackCapture render_loopback;
		private WaveWriter render_fileA;
		private WaveWriter render_fileB;
		private FileStream render_streamA;
		private FileStream render_streamB;

		// Microphone audio
		private WasapiCapture capture_loopback;
		private SoundInSource capture_source;
		private SingleBlockNotificationStream capture_notifyStream;
		private IWaveSource capture_finalSource;
		private WaveWriter capture_fileA;
		private WaveWriter capture_fileB;
		private FileStream capture_streamA;
		private FileStream capture_streamB;

		private System.Timers.Timer fileTimer;
		private Stopwatch appTime = new Stopwatch();

		private bool canWrite = true;

		private ConfigEditor editor;

		public ProcessContext() {
			Debug.WriteLine("Registering devices");
			Config.RegisterChannelType("Device Capture", ChannelType.DeviceCapture, typeof(DeviceCaptureChannel));
			Debug.WriteLine("Loading config");
			Config.LoadConfig();

			Debug.WriteLine("Initializing context resources");

			captureItem = new MenuItem("Capture", Capture);
			editor = new ConfigEditor {
				Visible = false
			};
			editor.SetupEvents(this);

			trayIcon = new NotifyIcon {
				Icon = Properties.Resources.AppIcon,
				ContextMenu = new ContextMenu(new MenuItem[] {
					captureItem,
					new MenuItem("-"),
					new MenuItem("Change Settings", ShowConfigEditor),
					new MenuItem("-"),
					new MenuItem("Exit", Exit)
				}),
				Visible = true
			};

			trayIcon.BalloonTipClicked += TrayIcon_BalloonTipClicked;

			try {
				StartSystemCache();
			}
			catch (CSCore.CoreAudioAPI.CoreAudioAPIException core_exception) {
				Debug.WriteLine("Exception Message: " + core_exception.Message);
				Debug.WriteLine("Exception HResult: " + core_exception.HResult.ToString());
			}
		}

		private void TrayIcon_BalloonTipClicked(object sender, EventArgs e) {
			Process.Start(Config.SavePath.FullName);
		}

		public new void Dispose() {

			trayIcon.Visible = false;
			trayIcon.Dispose();

			captureItem.Dispose();

			if (render_loopback.RecordingState == RecordingState.Recording) {
				render_loopback.Stop();
			}
			render_loopback.Dispose();

			if (capture_loopback.RecordingState == RecordingState.Recording) {
				capture_loopback.Stop();
			}
			capture_loopback.Dispose();

			fileTimer.Stop();
			fileTimer.Dispose();

			render_fileA.Dispose();
			render_fileB.Dispose();
			
			render_streamA.Close();
			render_streamB.Close();

			capture_fileA.Dispose();
			capture_fileB.Dispose();

			capture_streamA.Close();
			capture_streamB.Close();

			Dispose(true);

			GC.SuppressFinalize(this);
		}

		public void Capture(object sender, EventArgs e) {

			canWrite = false;
			Debug.WriteLine("Saving audio");

			if (!Directory.Exists(Config.SavePath.FullName)) Directory.CreateDirectory(Config.SavePath.FullName);

			var render_fileName = Config.SavePath.FullName + "/" + DateTime.Now.ToString(Config.SaveNameFormat) + "_render" + ".wav";
			var capture_fileName = Config.SavePath.FullName + "/" + DateTime.Now.ToString(Config.SaveNameFormat) + "_capture" + ".wav";
			if (appTime.Elapsed.Seconds > Config.CacheLength) {

				WriteDualStream(render_fileName, currentFile, render_streamA, render_streamB);
				WriteDualStream(capture_fileName, currentFile, capture_streamA, capture_streamB);
			}
			else {
				// since we havent swapped files yet, all of what we've recorded is in the current file
				// thus we only need to copy the file!
				File.WriteAllBytes(render_fileName, Utility.ReadToEnd(render_streamA));
				File.WriteAllBytes(capture_fileName, Utility.ReadToEnd(capture_streamA));

				if (File.Exists(Config.render_a)) {
					render_streamA.Close();
					File.Delete(Config.render_a);
				}
				if (File.Exists(Config.capture_a)) {
					capture_streamA.Close();
					File.Delete(Config.capture_a);
				}

				render_streamA = File.Create(Config.render_a);
				render_fileA = new WaveWriter(render_streamA, render_loopback.WaveFormat);

				capture_streamA = File.Create(Config.capture_a);
				capture_fileA = new WaveWriter(capture_streamA, capture_loopback.WaveFormat);
			}
			canWrite = true;

			trayIcon.ShowBalloonTip(5000, "Purple Electron", "Captured cached audio.", ToolTipIcon.Info);
			
		}

		private static void WriteDualStream(string outputFile, int file_index, FileStream a, FileStream b) {
			// Concatenate a.wav and b.wav, then splice out the part that we want to save
			var bytesA = Utility.ReadToEnd((file_index == 0) ? b : a);
			var bytesB = Utility.ReadToEnd((file_index == 1) ? b : a);

			var chunk1_size = BitConverter.ToInt32(bytesA, 16);
			var format = BitConverter.ToInt16(bytesA, 20);

			var channels = BitConverter.ToInt16(bytesA, 22);
			var rate = BitConverter.ToInt32(bytesA, 24);
			var byteRate = BitConverter.ToInt32(bytesA, 28);
			var align = BitConverter.ToInt16(bytesA, 32);
			var bitsPerSample = BitConverter.ToInt16(bytesA, 34);

			var dataA = bytesA.Skip(44).ToArray();
			var dataB = bytesB.Skip(44).ToArray();

			var lengthA = dataA.Length;
			var lengthB = dataB.Length;

			// We're doing hardcore byte concatenation since the output
			// temp files (a.wav and b.wav) are both uncompressed raw data.
			//
			// ... when more than WAV is introduced, we'll have to do this for all of the supported
			// file types.
			using (var file = File.Create(outputFile))
			using (BinaryWriter bw = new BinaryWriter(file)) {
				bw.Write(System.Text.Encoding.ASCII.GetBytes("RIFF")); // chunk id
				bw.Write(4 + (8 + chunk1_size) + (8 + lengthA + lengthB)); // chunk size
				bw.Write(System.Text.Encoding.ASCII.GetBytes("WAVE")); // format
				bw.Write(System.Text.Encoding.ASCII.GetBytes("fmt ")); // sub chunk 1 id
				bw.Write(chunk1_size); // sub chunk 1 size
				bw.Write(format); // audio format
				bw.Write(channels); // num channels
				bw.Write(rate); // sample rate
				bw.Write(byteRate); // byte rate
				bw.Write(align); // block align
				bw.Write(bitsPerSample); // bits per sample
				bw.Write(System.Text.Encoding.ASCII.GetBytes("data")); // sub chunk 2 id
				bw.Write(lengthA + lengthB); // sub chunk 2 size
				bw.Write(dataA); // first part of Data
				bw.Write(dataB); // last part of Data

				bw.Flush();
				bw.Close();
			}
		}

		private void ShowConfigEditor(object sender, EventArgs e) {
			editor.Show();
		}

		private void Exit(object sender, EventArgs e) {
			//Dispose();

			trayIcon.Visible = false;
			trayIcon.Dispose();

			Application.Exit();
			Process.GetCurrentProcess().Kill();
		}

		private void StartSystemCache() {
			Debug.WriteLine("Initializing WASAPI Lookback...");
			render_loopback = new WasapiLoopbackCapture {
				Device = Config.RenderDevice
			};
			capture_loopback = new WasapiCapture {
				Device = Config.CaptureDevice,
			};
			
			render_loopback.Initialize();
			capture_loopback.Initialize();
			Debug.WriteLine("Initialized WASAPI Lookback.");

			if (!Directory.Exists(Config.TEMP)) Directory.CreateDirectory(Config.TEMP);
			else {

				if (File.Exists(Config.render_a)) File.Delete(Config.render_a);
				if (File.Exists(Config.render_b)) File.Delete(Config.render_b);

				if (File.Exists(Config.capture_a)) File.Delete(Config.capture_a);
				if (File.Exists(Config.capture_b)) File.Delete(Config.capture_b);
			}
			render_streamA = File.Create(Config.render_a);
			render_streamB = File.Create(Config.render_b);
			capture_streamA = File.Create(Config.capture_a);
			capture_streamB = File.Create(Config.capture_b);

			render_fileA = new WaveWriter(render_streamA, render_loopback.WaveFormat);
			render_fileB = new WaveWriter(render_streamB, render_loopback.WaveFormat);
			capture_fileA = new WaveWriter(capture_streamA, capture_loopback.WaveFormat);
			capture_fileB = new WaveWriter(capture_streamB, capture_loopback.WaveFormat);

			render_loopback.DataAvailable += (s, e) => {
				try {
					// wait until other events have finished reading from or writing to
					// the temp files.
					while (!canWrite) { };

					switch (currentFile) {
						case 0:
							render_fileA.Write(e.Data, e.Offset, e.ByteCount);
							break;
						case 1:
							render_fileB.Write(e.Data, e.Offset, e.ByteCount);
							break;
					}

					if (appTime.Elapsed.Seconds > Config.CacheLength) {
						appTime.Stop();
					}
				}
				catch (Exception ex) {
					Debug.WriteLine(ex);
				}
			};
			capture_loopback.DataAvailable += (s, e) => {
				try {
					// wait until other events have finished reading from or writing to
					// the temp files.
					while (!canWrite) { };

					switch (currentFile) {
						case 0:
							capture_fileA.Write(e.Data, e.Offset, e.ByteCount);
							break;
						case 1:
							capture_fileB.Write(e.Data, e.Offset, e.ByteCount);
							break;
					}

					if (appTime.Elapsed.Seconds > Config.CacheLength) {
						appTime.Stop();
					}
				}
				catch (Exception ex) {
					Debug.WriteLine(ex);
				}
			};

			fileTimer = new System.Timers.Timer(Config.CacheLength * 1000);

			fileTimer.Elapsed += (s, e) => {
				if (!canWrite) return;

				canWrite = false;
				try {
					Debug.WriteLine("Swapping files.");
					switch (currentFile) {
						case 0:
							currentFile = 1;

							if (File.Exists(Config.render_b)) {
								render_streamB.Close();
								render_streamB.Dispose();
								File.Delete(Config.render_b);
							}
							if (File.Exists(Config.capture_b)) {
								capture_streamB.Close();
								capture_streamB.Dispose();
								File.Delete(Config.capture_b);
							}

							render_streamB = File.Create(Config.render_b);
							render_fileB = new WaveWriter(render_streamB, render_loopback.WaveFormat);

							capture_streamB = File.Create(Config.capture_b);
							capture_fileB = new WaveWriter(capture_streamB, capture_loopback.WaveFormat);
							break;
						case 1:
							currentFile = 0;

							if (File.Exists(Config.render_a)) {
								render_streamA.Close();
								render_streamA.Dispose();
								File.Delete(Config.render_a);
							}
							if (File.Exists(Config.capture_a)) {
								capture_streamA.Close();
								capture_streamA.Dispose();
								File.Delete(Config.capture_a);
							}

							render_streamA = File.Create(Config.render_a);
							render_fileA = new WaveWriter(render_streamA, render_loopback.WaveFormat);

							capture_streamA = File.Create(Config.capture_a);
							capture_fileA = new WaveWriter(capture_streamA, capture_loopback.WaveFormat);
							break;
					}
					Debug.WriteLine("Swapped file to file " + currentFile.ToString());
				}
				catch (IOException ioe) {
					Debug.WriteLine(ioe);
				}
				catch (Exception ex) {
					Debug.WriteLine(ex);
				}
				canWrite = true;
			};

			fileTimer.AutoReset = true;
			fileTimer.Start();

			render_loopback.Start();
			capture_loopback.Start();

			appTime.Start();
		}
	}
}
