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

		/*private int currentFile = 0;

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

		private bool canWrite = true;*/

		private ConfigEditor editor;

		public ProcessContext() {
			Debug.WriteLine("Registering devices");
			Config.RegisterChannelType("Device Capture", ChannelType.DeviceCapture, typeof(DeviceCaptureChannel));
			Debug.WriteLine("Loading config");
			Config.LoadConfig();

			Debug.WriteLine("Initializing context resources");
			
			editor = new ConfigEditor {
				Visible = false
			};

			Debug.WriteLine("Setting up context events");
			editor.SetupEvents(this);

			trayIcon = new NotifyIcon {
				Icon = Properties.Resources.AppIcon,
				ContextMenu = new ContextMenu(new MenuItem[] {
					new MenuItem("Restart Capture", RestartCapture),
					new MenuItem("-"),
					new MenuItem("Change Settings", ShowConfigEditor),
					new MenuItem("-"),
					new MenuItem("Exit", Exit)
				}),
				Visible = true
			};

			trayIcon.BalloonTipClicked += TrayIcon_BalloonTipClicked;

			Debug.WriteLine("Starting base channel capture");
			foreach (var channel in Config.ActiveChannels) {
				channel.channel.StartCapture();
			}
		}

		private void TrayIcon_BalloonTipClicked(object sender, EventArgs e) {
			Process.Start(Config.SavePath.FullName);
		}

		private void ShowConfigEditor(object sender, EventArgs e) {
			editor.Show();
		}

		/// <summary>
		/// Sends a save signal to all enabled channels
		/// </summary>
		public void SaveData() {
			foreach (var channel in Config.ActiveChannels) {
				channel.channel.SaveData();
			}
		}

		public new void Dispose() {

			trayIcon.Visible = false;
			trayIcon.Dispose();

			captureItem.Dispose();

			Dispose(true);

			GC.SuppressFinalize(this);
		}

		private void Exit(object sender, EventArgs e) {
			//Dispose();

			trayIcon.Visible = false;
			trayIcon.Dispose();

			Application.Exit();
			Process.GetCurrentProcess().Kill();
		}

		private void RestartCapture(object sender, EventArgs e) {
			foreach (var channel in Config.ActiveChannels) {
				channel.channel.StopCapture();
				channel.channel.StartCapture();
			}
		}
	}
}
