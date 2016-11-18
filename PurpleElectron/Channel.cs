using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using CSCore;
using CSCore.Codecs.WAV;
using CSCore.CoreAudioAPI;
using CSCore.SoundIn;
using CSCore.Streams;
using CSCore.Win32;

namespace PurpleElectron {

	public enum ChannelType {
		DeviceCapture,
		ProcessCapture, // TODO: INCOMPLETE. SEE TRELLO BOARD
		Gate // TODO: INCOMPLETE. SEE TRELLO BOARD
	}
	
	public enum OutputFormat {
		WAV,
		WMA, // TODO: UNSUPPORTED. SEE TRELLO BOARD
		RAW, // TODO: UNSUPPORTED. SEE TRELLO BOARD
		AIFF, // TODO: UNSUPPORTED. SEE TRELLO BOARD
		DDP, // TODO: UNSUPPORTED. SEE TRELLO BOARD
		FLAC, // TODO: UNSUPPORTED. SEE TRELLO BOARD
		MP3, // TODO: UNSUPPORTED. SEE TRELLO BOARD
		AAC // TODO: UNSUPPORTED. SEE TRELLO BOARD
	}

	public interface IChannel {

		string channelName { get; }
		ChannelType channelType { get; }
		OutputFormat outputFormat { get; set; }
		int cacheLength { get; set; }
		void StartCapture();
		void StopCapture();
		void SaveData();
	}

	public class DeviceCaptureChannel : IChannel, IDisposable {

		public string channelName { get; }
		public string channelFolder {
			get {
				return Config.TEMP + channelName + "/";
			}
		}
		public string channelFileA {
			get {
				return channelFolder + channelName + ".a.wav";
			}
		}
		public string channelFileB {
			get {
				return channelFolder + channelName + ".b.wav";
			}
		}
		public ChannelType channelType { get { return ChannelType.DeviceCapture; } }
		public OutputFormat outputFormat { get; set; }
		public int cacheLength { get; set; }
		public bool storeInMemoryUntilSave { get; set; }

		public WasapiCapture channelCapture;
		public MMDevice channelDevice;
		public WaveWriter channelWriterA;
		public WaveWriter channelWriterB;
		public FileStream channelStreamA;
		public FileStream channelStreamB;
		public List<byte> channelMemoryA;
		public List<byte> channelMemoryB;

		public List<MMDevice> deviceList;

		public bool canWrite;
		public int currentFile;
		public Timer fileTimer;

		/// <summary>
		/// This will prompt the Wasapi object to begin capturing from the primaryDevice.
		/// 
		/// IMPORTANT: Calling this will, dispose of any previously cached data
		/// and will reinitialize the Wasapi object.
		/// </summary>
		public void StartCapture() {
			if (channelCapture?.RecordingState == RecordingState.Recording) StopCapture();

			var flow = Utility.GetDataFlow(channelDevice);
			switch (flow) {
				case DataFlow.Capture:

					channelCapture = new WasapiCapture {
						Device = channelDevice
					};

					break;
				case DataFlow.Render:

					channelCapture = new WasapiLoopbackCapture {
						Device = channelDevice
					};

					break;
			}

			channelCapture.Initialize();

			fileTimer = new Timer(cacheLength * 1000);

			if (storeInMemoryUntilSave) {
				channelCapture.DataAvailable += (s, e) => {
					switch (currentFile) {
						case 0:
							for (int i = e.Offset; i < e.ByteCount; i++) {
								channelMemoryA.Add(e.Data[i]);
							}
							break;
						case 1:
							for (int i = e.Offset; i < e.ByteCount; i++) {
								channelMemoryB.Add(e.Data[i]);
							}
							break;
					}
				};


				fileTimer.Elapsed += (s, e) => {

					switch (currentFile) {
						case 0:
							currentFile = 1;
							channelMemoryB.Clear();
							break;
						case 1:
							currentFile = 0;
							channelMemoryA.Clear();
							break;
					}
				};
			}
			else {
				CheckTempDirectory();

				channelStreamA = File.Create(channelFileA);
				channelStreamB = File.Create(channelFileB);

				channelWriterA = new WaveWriter(channelStreamA, channelCapture.WaveFormat);
				channelWriterB = new WaveWriter(channelStreamB, channelCapture.WaveFormat);

				channelCapture.DataAvailable += (s, e) => {
					while (!canWrite) ;

					switch (currentFile) {
						case 0:
							channelWriterA.Write(e.Data, e.Offset, e.ByteCount);
							break;
						case 1:
							channelWriterB.Write(e.Data, e.Offset, e.ByteCount);
							break;
					}
				};


				fileTimer.Elapsed += (s, e) => {
					if (!canWrite) return;

					canWrite = false;

					switch (currentFile) {
						case 0:
							currentFile = 1;

							CheckTempDirectory();

							if (File.Exists(channelFileB)) {
								channelStreamB.Dispose();
								File.Delete(channelFileB);
							}
							channelStreamB = File.Create(channelFileB);

							if (!channelWriterB.IsDisposed && !channelWriterB.IsDisposing) {
								channelWriterB.Dispose();
							}

							channelWriterB = new WaveWriter(channelStreamB, channelCapture.WaveFormat);

							break;
						case 1:
							currentFile = 0;

							CheckTempDirectory();

							if (File.Exists(channelFileA)) {
								channelStreamA.Dispose();
								File.Delete(channelFileA);
							}
							channelStreamA = File.Create(channelFileA);

							if (!channelWriterA.IsDisposed && !channelWriterA.IsDisposing) {
								channelWriterA.Dispose();
							}

							channelWriterA = new WaveWriter(channelStreamA, channelCapture.WaveFormat);

							break;
					}

					canWrite = true;
				};
			}

			fileTimer.AutoReset = true;
			fileTimer.Start();

			channelCapture.Start();
		}

		public void StopCapture() {

			if (channelCapture?.RecordingState == RecordingState.Recording) channelCapture.Stop();
		}

		public void SaveData() {
			if (storeInMemoryUntilSave) {
				
				//TODO: concatenate the data stored in memory (MemoryA and MemoryB) and store it in a file
				
			}
			else {

				// TODO: merge the two files and save it

			}
		}

		public DeviceCaptureChannel(string name, OutputFormat fmt = OutputFormat.WAV) {
			channelName = name;
			outputFormat = fmt;
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator()) {
				channelDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);

				deviceList = new List<MMDevice>(enumerator.EnumAudioEndpoints(DataFlow.All, DeviceState.Active));
			}
		}

		public void CheckTempDirectory() {
			// Make sure we have a place to house our temp folder
			if (!Directory.Exists(Config.TEMP)) Directory.CreateDirectory(Config.TEMP);
			// the channel's temp folder, which contains the stream files for this channel
			if (!Directory.Exists(channelFolder)) Directory.CreateDirectory(channelFolder);
			else {
				if (File.Exists(channelFileA)) File.Delete(channelFileA);
				if (File.Exists(channelFileB)) File.Delete(channelFileB);
			}
		}
		
		public void Dispose() {
			
			channelMemoryA.Clear();
			channelMemoryB.Clear();

			channelWriterA.Dispose();
			channelWriterB.Dispose();

			channelStreamA.Dispose();
			channelStreamB.Dispose();

			channelCapture.Dispose();
			channelDevice.Dispose();

			deviceList.ForEach(device => device.Dispose());
			deviceList.Clear();

			fileTimer.Stop();
			fileTimer.Dispose();

			GC.SuppressFinalize(this);
		}
	}
}
