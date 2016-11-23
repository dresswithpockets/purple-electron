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

		internal const string GUID = "1F923A3E-B532-40A6-8065-D73D597996E1";

		private static DirectoryInfo DefaultSaveDirectoryInfo {
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
				return dev;
			}
		}

		public static MMDevice GetDefaultRenderDevice() {
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator()) {
				return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
			}
		}

		public static KeyShortcut CaptureShortcut = new KeyShortcut(Keys.F6, false, false, true);
		
		public static int CacheLength = 60;

		public static DirectoryInfo SavePath = DefaultSaveDirectoryInfo;
		public static string SaveNameFormat = "MM-dd-yyyy - HH-mm-ss";

		public static MMDevice RenderDevice = GetDefaultRenderDevice();
		public static MMDevice CaptureDevice = GetDefaultCaptureDevice();
		public static Dictionary<ChannelType, ChannelTypeItem> RegisteredChannels = new Dictionary<ChannelType, ChannelTypeItem>();
		public static List<ChannelItem> ActiveChannels = new List<ChannelItem>();

		public static void RegisterChannelType(string name, ChannelType channelType, Type type) {
			if (!RegisteredChannels.ContainsKey(channelType)) {
				RegisteredChannels.Add(channelType, new ChannelTypeItem(name, channelType, type));
			}
		}

		public static void SaveConfig() {
			Debug.WriteLine("Saving config");
			var root = new JSONClass();

			Debug.WriteLine("Saving capture shortcut, cache length, and save path");
			var capture_shortcut = new JSONClass();
			capture_shortcut["keys"].AsInt = (int)CaptureShortcut.keys;
			capture_shortcut["shift"].AsBool = CaptureShortcut.shift;
			capture_shortcut["ctrl"].AsBool = CaptureShortcut.ctrl;
			capture_shortcut["alt"].AsBool = CaptureShortcut.alt;

			root["capture_shortcut"] = capture_shortcut;
			root["cache_length"].AsInt = CacheLength;
			root["save_path"] = SavePath.FullName;

			Debug.WriteLine("Saving channels");

			var channels = new JSONArray();
			ActiveChannels.ForEach(channel => channels.Add(channel.ToJSON()));
			root["channels"] = channels;

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

				var channels = root["channels"];

				if (channels != null) {
					foreach (var channel in channels.AsArray) {
						Debug.WriteLine("Reading channel");
						ActiveChannels.Add(new ChannelItem((JSONClass)channel));
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

		public bool enabled;
		public ChannelType channelType;
		public IChannel channel { get; }

		public ChannelItem(IChannel channel) {
			this.channel = channel;
			channelType = channel.channelType;
			enabled = true;
		}

		public ChannelItem(JSONClass json) {
			var chan = (JSONClass)json[nameof(channel)];

			enabled = json[nameof(enabled)].AsBool;
			channelType = (ChannelType)json[nameof(channelType)].AsInt;
			channel = (IChannel)Activator.CreateInstance(Config.RegisteredChannels[channelType].objectType, new[] { chan });
		}

		public override string ToString() {
			//var enable = enabled ? "(Enabled) " : "(Disabled) ";

			//return enable + channel.channelName;
			// TODO: handle this shit
			return channel.channelName;
		}

		public JSONNode ToJSON() {
			var node = new JSONClass();

			node[nameof(enabled)].AsBool = enabled;
			node[nameof(channelType)].AsInt = (int)channel.channelType;
			node[nameof(channel)] = channel.ToJSON();

			return node;
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
