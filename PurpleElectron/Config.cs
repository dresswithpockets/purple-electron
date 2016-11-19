using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Linq;
using System.Diagnostics;

using CSCore.CoreAudioAPI;

using SimpleJSON;

namespace PurpleElectron {

	public static class Config {

		internal const string CONFIG_PATH = "config.json";
		internal const string TEMP = "temp/";
		internal const string TEMP_CAPTURE_A = "capture_a.wav";
		internal const string TEMP_CAPTURE_B = "capture_b.wav";
		internal const string TEMP_RENDER_A = "render_a.wav";
		internal const string TEMP_RENDER_B = "render_b.wav";

		internal const string GUID = "1F923A3E-B532-40A6-8065-D73D597996E1";

		internal static string render_a {
			get {
				return TEMP + TEMP_RENDER_A;
			}
		}
		internal static string render_b {
			get {
				return TEMP + TEMP_RENDER_B;
			}
		}
		internal static string capture_a {
			get {
				return TEMP + TEMP_CAPTURE_A;
			}
		}
		internal static string capture_b {
			get {
				return TEMP + TEMP_CAPTURE_B;
			}
		}

		public static KeyShortcut CaptureShortcut = new KeyShortcut(Keys.F6, false, false, true);

		public static MMDevice RenderDevice = GetDefaultRenderDevice();
		public static MMDevice CaptureDevice = GetDefaultCaptureDevice();

		/// <summary>
		/// The length of each audio cache file.
		/// 
		/// In Seconds
		/// </summary>
		public static int CacheLength = 60;

		public static DirectoryInfo SavePath = DefaultDirectoryInfo;
		public static string SaveNameFormat = "MM-dd-yyyy - hh-mm-ss";

		public static Dictionary<ChannelType, ChannelTypeItem> RegisteredChannels = new Dictionary<ChannelType, ChannelTypeItem>();

		private static DirectoryInfo DefaultDirectoryInfo {
			get {
				if (!Directory.Exists("save/")) return Directory.CreateDirectory("save/");
				return new DirectoryInfo("save/");
			}
		}

		public static IEnumerable<MMDevice> EnumerateCaptureDevices() {
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator()) {
				return enumerator.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active);
			}
		}

		public static IEnumerable<MMDevice> EnumerateRenderDevices() {
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator()) {
				return enumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active);
			}
		}
		
		public static MMDevice GetDefaultCaptureDevice() {
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator()) {
				var dev = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
				//Debug.WriteLine("Microphone: " + dev.FriendlyName);
				return dev;
			}
		}

		public static MMDevice GetDefaultRenderDevice() {
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator()) {
				return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
			}
		}

		public static void RegisterChannelType(string name, ChannelType channelType, Type type) {
			if (!RegisteredChannels.ContainsKey(channelType)) {
				RegisteredChannels.Add(channelType, new ChannelTypeItem(name, channelType, type));
			}
		}

		public static void SaveConfig() {
			var root = new JSONClass();

			var capture_shortcut = new JSONClass();
			capture_shortcut["keys"].AsInt = (int)CaptureShortcut.keys;
			capture_shortcut["shift"].AsBool = CaptureShortcut.shift;
			capture_shortcut["ctrl"].AsBool = CaptureShortcut.ctrl;
			capture_shortcut["alt"].AsBool = CaptureShortcut.alt;

			root.Add("capture_shortcut", capture_shortcut);
			root.Add("cache_length", CacheLength.ToString());

			root.Add("save_path", SavePath.FullName);
			root.Add("capture_id", CaptureDevice.DeviceID);
			root.Add("render_id", RenderDevice.DeviceID);

			File.WriteAllText(CONFIG_PATH, root.ToString());
		}

		public static void LoadConfig() {
			if (!File.Exists(CONFIG_PATH)) SaveConfig();
			else {
				var root = JSON.Parse(File.ReadAllText(CONFIG_PATH));

				var capture_shortcut = root["capture_shortcut"];
				CaptureShortcut = new KeyShortcut((Keys)capture_shortcut["keys"].AsInt,
					capture_shortcut["shift"].AsBool,
					capture_shortcut["ctrl"].AsBool,
					capture_shortcut["alt"].AsBool);

				CacheLength = root["cache_length"].AsInt;
				SavePath = new DirectoryInfo(root["save_path"]);

				var cid = root["capture_id"];
				var rid = root["render_id"];

				using (var deviceEnum = new MMDeviceEnumerator())
				using (var capture_devices = deviceEnum.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active))
				using (var render_devices = deviceEnum.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active)) {
					
					foreach (var device in capture_devices) {
						if (device.DeviceID == cid) {
							CaptureDevice = device;
							break;
						}
					}
					foreach (var device in render_devices) {
						if (device.DeviceID == rid) {
							RenderDevice = device;
						}
					}

					if (CaptureDevice == null) {
						CaptureDevice = GetDefaultCaptureDevice();
					}
					if (RenderDevice == null) {
						RenderDevice = GetDefaultRenderDevice();
					}
				}
			}
		}
	}
	
	public struct KeyShortcut {
		public bool shift { get; }
		public bool ctrl { get; }
		public bool alt { get; }
		public Keys keys { get; }

		public Keys modifiers {
			get {
				var val = Keys.None;

				if (shift) val |= Keys.Shift;
				if (ctrl) val |= Keys.Control;
				if (alt) val |= Keys.Alt;

				return val;
			}
		}

		public KeyShortcut(Keys keys, bool shift, bool ctrl, bool alt) {
			this.keys = keys;
			this.shift = shift;
			this.ctrl = ctrl;
			this.alt = alt;
		}
	}

	public class DeviceItem {
		public MMDevice Device { get; }

		public DeviceItem(MMDevice device) {
			Device = device;
		}

		public override string ToString() {
			return Device.FriendlyName;
		}
	}

	public class ChannelItem {

		public bool Enabled;
		public IChannel Channel { get; }

		public ChannelItem(IChannel channel) {
			Channel = channel;
			Enabled = true;
		}

		public override string ToString() {
			var enable = Enabled ? "(Enabled) " : "(Disabled) ";

			return enable + Channel.channelName;
		}
	}

	public class ChannelTypeItem {

		public string channelTypeName { get; }
		public ChannelType channelType { get; }
		public Type objectType { get; }

		public ChannelTypeItem(string friendlyName, ChannelType type, Type objType) {
			channelTypeName = friendlyName;
			channelType = type;
			objectType = objType;
		}

		public override string ToString() {
			return channelTypeName;
		}
	}
}
