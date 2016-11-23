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

using SimpleJSON;
using System.Diagnostics;

namespace PurpleElectron {

	// TODO: INCOMPLETE. SEE TRELLO BOARD
	public enum ChannelType {
		DeviceCapture,
		ProcessCapture,
		Gate
	}

	// TODO: UNSUPPORTED. SEE TRELLO BOARD
	public enum OutputFormat {
		WAV,
		WMA, 
		RAW, 
		AIFF, 
		DDP, 
		FLAC, 
		MP3, 
		AAC 
	}

	public interface IChannel {

		string channelName { get; }
		ChannelType channelType { get; }
		OutputFormat outputFormat { get; set; }
		int cacheLength { get; set; }
		bool storeInMemoryUntilSave { get; set; }
		void StartCapture();
		void StopCapture();
		bool ShowPropertiesEditor();
		void SaveData();
		JSONNode ToJSON();
		void Dispose();
	}

	public class DeviceCaptureChannel : IChannel, IDisposable {

		public string channelName { get; private set; }
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
		public FileStream channelStreamA { get; set; }
		public FileStream channelStreamB { get; set; }
		public List<byte> channelMemoryA = new List<byte>();
		public List<byte> channelMemoryB = new List<byte>();

		public List<MMDevice> deviceList;

		public bool canWrite = true;
		public int currentFile;
		public Timer fileTimer;

		public DeviceCaptureProperties propertiesWindow;

		/// <summary>
		/// This will prompt the Wasapi object to begin capturing from the primaryDevice.
		/// 
		/// IMPORTANT: Calling this will, dispose of any previously cached data
		/// and will reinitialize the Wasapi object.
		/// </summary>
		public void StartCapture() {
			Debug.WriteLine("Starting capture for " + channelName);

			StopCapture();

			var flow = Utility.GetDataFlow(channelDevice);
			switch (flow) {
				case DataFlow.Capture:

					Debug.WriteLine("Using WasapiCapture for device: " + channelDevice.FriendlyName);
					channelCapture = new WasapiCapture {
						Device = channelDevice
					};

					break;
				case DataFlow.Render:

					Debug.WriteLine("Using WasapiLoopbackCapture for device: " + channelDevice.FriendlyName);
					channelCapture = new WasapiLoopbackCapture {
						Device = channelDevice
					};

					break;
			}

			Debug.WriteLine("Initializing capture device");
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
				Debug.WriteLine("Ensuring proper temp directories exist");
				CheckTempDirectory(true);

				Debug.WriteLine("Opening streams to: {0} and {1}", channelFileA, channelFileB);
				channelStreamA = File.Create(channelFileA);
				channelStreamB = File.Create(channelFileB);

				Debug.WriteLine("Opening writers for those files.");
				channelWriterA = new WaveWriter(channelStreamA, channelCapture.WaveFormat);
				channelWriterB = new WaveWriter(channelStreamB, channelCapture.WaveFormat);

				Debug.WriteLine("Implementing data available event.");
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
				
				Debug.WriteLine("Implementing file swapper");
				fileTimer.Elapsed += (s, e) => {
					if (!canWrite) return;

					canWrite = false;

					Debug.WriteLine("Swapping files");

					switch (currentFile) {
						case 0:
							currentFile = 1;

							CheckTempDirectory(false);

							if (File.Exists(channelFileB)) {
								channelStreamB.Close();
								channelStreamB.Dispose();
								File.Delete(channelFileB);
							}
							channelStreamB = File.Create(channelFileB);

							/*if (!channelWriterB.IsDisposed && !channelWriterB.IsDisposing) {
								channelWriterB.Dispose();
							}*/

							channelWriterB = new WaveWriter(channelStreamB, channelCapture.WaveFormat);

							break;
						case 1:
							currentFile = 0;

							CheckTempDirectory(false);

							if (File.Exists(channelFileA)) {
								channelStreamA.Close();
								channelStreamA.Dispose();
								File.Delete(channelFileA);
							}
							channelStreamA = File.Create(channelFileA);

							/*if (!channelWriterA.IsDisposed && !channelWriterA.IsDisposing) {
								channelWriterA.Dispose();
							}*/

							channelWriterA = new WaveWriter(channelStreamA, channelCapture.WaveFormat);

							break;
					}

					canWrite = true;
				};
			}

			Debug.WriteLine("Starting the timer swapper");
			fileTimer.AutoReset = true;
			fileTimer.Start();

			Debug.WriteLine("Starting the capture device stream");
			channelCapture.Start();

			Debug.WriteLine("Started the capture device stream");
		}

		public void StopCapture() {

			if (channelCapture?.RecordingState == RecordingState.Recording)
				Cleanup();
        }

		public bool ShowPropertiesEditor() {
			var propertiesChanged = false;

			var result = propertiesWindow.ShowDialog();
			if (result == System.Windows.Forms.DialogResult.OK) {
				var newChannelName = propertiesWindow.GetChannelName();
				var newOutputFormat = propertiesWindow.GetOutputFormat();
				var newCacheLength = propertiesWindow.GetCacheLength();
				var newStoreInMemoryUntilSave = propertiesWindow.GetBufferMethod();
				var device = propertiesWindow.GetDevice();

				if (newChannelName != channelName) {
					channelName = newChannelName;
					propertiesChanged = true;
				}
				if (newOutputFormat != outputFormat) {
					outputFormat = newOutputFormat;
					propertiesChanged = true;
				}
				if (newCacheLength != cacheLength) {
					cacheLength = newCacheLength;
					propertiesChanged = true;
				}
				if (newStoreInMemoryUntilSave != storeInMemoryUntilSave) {
					storeInMemoryUntilSave = newStoreInMemoryUntilSave;
					propertiesChanged = true;
				}
				if (channelDevice.DeviceID != device.DeviceID) {
					StopCapture();
					channelDevice = device;
					StartCapture();

					propertiesChanged = true;
				}
			}

			return propertiesChanged;
		}

		public void SaveData() {
			// TODO: Add support for other formats (see: OutputFormat)

			byte[] dataA, dataB;

			if (storeInMemoryUntilSave) {
				dataA = (currentFile == 0 ? channelMemoryB : channelMemoryA).ToArray();
				dataB = (currentFile == 1 ? channelMemoryB : channelMemoryA).ToArray();
			}
			else {
				var bytesA = Utility.ReadToEnd((currentFile == 0) ? channelStreamB : channelStreamA);
				var bytesB = Utility.ReadToEnd((currentFile == 1) ? channelStreamB : channelStreamA);

				dataA = bytesA.Skip(44).ToArray();
				dataB = bytesB.Skip(44).ToArray();
			}

			var saveDirectory = Config.SavePath.FullName + "/" + channelName + "/";
			if (!Directory.Exists(saveDirectory)) Directory.CreateDirectory(saveDirectory);
            using (var writer = new WaveWriter(saveDirectory + DateTime.Now.ToString(Config.SaveNameFormat) + ".wav", channelCapture.WaveFormat)) {
				writer.Write(dataA, 0, dataA.Length);
				writer.Write(dataB, 0, dataB.Length);
			}
		}

		public DeviceCaptureChannel(string name, OutputFormat fmt = OutputFormat.WAV) {
			channelName = name;
			outputFormat = fmt;
			cacheLength = 60; // default cache length, for now
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator()) {
				channelDevice = (MMDevice)enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

				deviceList = new List<MMDevice>(enumerator.EnumAudioEndpoints(DataFlow.All, DeviceState.Active));
			}
			
			Debug.WriteLine("Populating properties window");
			propertiesWindow = new DeviceCaptureProperties {
				Visible = false
			};
			propertiesWindow.Populate(this);
		}

		public DeviceCaptureChannel(JSONClass json) {

			channelName = json[nameof(channelName)];
			outputFormat = (OutputFormat)json[nameof(outputFormat)].AsInt;
			cacheLength = json[nameof(cacheLength)].AsInt;
			storeInMemoryUntilSave = json[nameof(storeInMemoryUntilSave)].AsBool;

			var id = json[nameof(channelDevice.DeviceID)];
			using (var enumerator = new MMDeviceEnumerator()) {
				deviceList = new List<MMDevice>(enumerator.EnumAudioEndpoints(DataFlow.All, DeviceState.Active));
				foreach (var device in deviceList) {
					if (device.DeviceID == id) {
						channelDevice = device;
						break;
					}
				}

				if (channelDevice == null) {
					channelDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
				}
			}

			cacheLength = 60; // default cache length, for now

			Debug.WriteLine("Populating properties window");
			propertiesWindow = new DeviceCaptureProperties {
				Visible = false
			};
			propertiesWindow.Populate(this);
		}

		public void CheckTempDirectory(bool delete) {
			Debug.WriteLine("Checking temp directory");
			// Make sure we have a place to house our temp folder
			if (!Directory.Exists(Config.TEMP)) Directory.CreateDirectory(Config.TEMP);
			// the channel's temp folder, which contains the stream files for this channel
			if (!Directory.Exists(channelFolder)) Directory.CreateDirectory(channelFolder);
			else if (delete) {
				if (File.Exists(channelFileA)) File.Delete(channelFileA);
				if (File.Exists(channelFileB)) File.Delete(channelFileB);
			}
			Debug.WriteLine("Checked temp directory");
		}

		public JSONNode ToJSON() {
			var node = new JSONClass();

			node[nameof(channelName)] = channelName;
			node[nameof(channelType)].AsInt = (int)channelType;
			node[nameof(outputFormat)].AsInt = (int)outputFormat;
			node[nameof(cacheLength)].AsInt = cacheLength;
			node[nameof(storeInMemoryUntilSave)].AsBool = storeInMemoryUntilSave;
			node[nameof(channelDevice.DeviceID)] = channelDevice.DeviceID;

			return node;
		}

		public void Cleanup() {
			channelMemoryA?.Clear();
			channelMemoryB?.Clear();

			channelWriterA?.Dispose();
			channelWriterB?.Dispose();

			channelStreamA?.Dispose();
			channelStreamB?.Dispose();

			channelCapture?.Dispose();

			fileTimer?.Stop();
			fileTimer?.Dispose();
		}

		public void Dispose() {
			
			channelMemoryA?.Clear();
			channelMemoryB?.Clear();

			channelWriterA?.Dispose();
			channelWriterB?.Dispose();

			channelStreamA?.Dispose();
			channelStreamB?.Dispose();

			channelCapture?.Dispose();
			channelDevice?.Dispose();

			deviceList?.ForEach(device => device.Dispose());
			deviceList?.Clear();

			fileTimer?.Stop();
			fileTimer?.Dispose();

			propertiesWindow?.Dispose();

			GC.SuppressFinalize(this);
		}
	}
}
