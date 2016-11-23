using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using CSCore.CoreAudioAPI;
using VIBlend.WinForms.Controls;

namespace PurpleElectron {
	public partial class DeviceCaptureProperties : Form {
		public DeviceCaptureProperties() {
			InitializeComponent();
		}

		public void Populate(DeviceCaptureChannel channel) {
			Debug.WriteLine("Setting properties window text");
			Text = "Editing: " + (channelNameTextBox.Text = channel.channelName);

			Debug.WriteLine("Setting properties window cache length");
			cacheLengthTextBox.Text = channel.cacheLength.ToString();

			Debug.WriteLine("Setting properties window output format");
			// This little bit of code is in a couple parts
			// First it gets the first item in the combo box
			// that contains the output format's file type (wav, flac, et cetera),
			// find the index of that item, and sets the selected index
			// of the combo box to that index.
			outputFormatComboBox.SelectedIndex = outputFormatComboBox.Items.IndexOf(
				outputFormatComboBox.Items.First(
					item => item.Text.ToLower().Contains(channel.outputFormat.ToString().ToLower())
					)
				);

			Debug.WriteLine("Setting properties window buffer method");
			bufferMethodComboBox.SelectedIndex = channel.storeInMemoryUntilSave ? 1 : 0;

			var selectedIndex = 0;

			Debug.WriteLine("Setting properties window device list");
			for (int i = 0; i < channel.deviceList.Count; i++) {

				var device = channel.deviceList[i];

				var devicePrefix = Utility.GetDataFlow(device) == DataFlow.Capture ? "Input: " : "Output: "; 
				deviceComboBox.Items.Add(new ListItem {
					Tag = device,
					Text = devicePrefix + device.FriendlyName
				});
				
				if (channel.channelDevice.DeviceID == device.DeviceID) {
					selectedIndex = i;
				}
			}

			deviceComboBox.SelectedIndex = selectedIndex;

			Debug.WriteLine("Populated properties window");
		}

		private void saveSettingsButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
		}

		private void cacheLengthTextBox_TextChanged(object sender, EventArgs e) {
			if (int.Parse(cacheLengthTextBox.Text) < 1) {
				cacheLengthTextBox.Text = "1";
			}
		}

		public string GetChannelName() {
			return channelNameTextBox.Text;
		}

		public OutputFormat GetOutputFormat() {
			foreach (var name in Enum.GetNames(typeof(OutputFormat))) {
				if (outputFormatComboBox.SelectedItem.Text.ToLower().Contains(name.ToLower()))
					return (OutputFormat)Enum.Parse(typeof(OutputFormat), name);
			}

			return OutputFormat.WAV;
		}

		public int GetCacheLength() {
			return int.Parse(cacheLengthTextBox.Text);
		}

		public bool GetBufferMethod() {
			return Convert.ToBoolean(bufferMethodComboBox.SelectedIndex);
		}

		public MMDevice GetDevice() {
			return (MMDevice)deviceComboBox.SelectedItem.Tag;
		}
	}
}
