using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.Codecs.WAV;
using CSCore.Win32;

using Gma.System.MouseKeyHook;

using Ookii.Dialogs;

namespace PurpleElectron {
	public partial class ConfigEditor : Form {

		private ProcessContext context;
		private IKeyboardMouseEvents hook;
		private Keys latestShortcutKeys = Keys.None;

		private bool capturingShortcut = false;

		private bool restartRequired = false;

		private ContextMenu addButtonMenu;

		public ConfigEditor() {
			Debug.WriteLine("Initializing component");

			InitializeComponent();

			Debug.WriteLine("Setting latest shortcut keys");

			latestShortcutKeys = Config.CaptureShortcut.keys;
		}

		protected override void WndProc(ref Message m) {
			if (m.Msg == Utility.WM_SHOWME) {
				ShowMe();
			}
			base.WndProc(ref m);
		}

		private void ShowMe() {
			if (WindowState == FormWindowState.Minimized) {
				WindowState = FormWindowState.Normal;
			}

			var top = TopMost;
			TopMost = true;
			TopMost = top;
		}

		private void ConfigEditor_Load(object sender, EventArgs e) {
			
			outputFolderTextBox.Text = Config.SavePath.FullName;
			outputFolderBrowseDialog.SelectedPath = Config.SavePath.FullName;

			shiftCheckBox.Checked = Config.CaptureShortcut.shift;
			ctrlCheckBox.Checked = Config.CaptureShortcut.ctrl;
			altCheckBox.Checked = Config.CaptureShortcut.alt;
			latestShortcutKeys = Config.CaptureShortcut.keys;
			captureShortcutButton.Text = latestShortcutKeys.ToString();
			
			saveSettingsButton.Enabled = false;
			restartRequired = false;
		}

		private void browseButton_Click(object sender, EventArgs e) {
			DialogResult dr;
			do {

				dr = outputFolderBrowseDialog.ShowDialog();

				if (dr == DialogResult.Cancel) {
					break;
				}
			}
			while (string.IsNullOrWhiteSpace(outputFolderBrowseDialog.SelectedPath));

			if (dr == DialogResult.OK) {
				outputFolderTextBox.Text = outputFolderBrowseDialog.SelectedPath;
				saveSettingsButton.Enabled = true;
			}
		}

		private void fileFormatCombatBox_SelectedIndexChanged(object sender, EventArgs e) {
			// TODO: Add support for other file formats and update the output format here.
			
			//MessageBox.Show("Only RIFF WAV is supported at the moment. Sorry!");
		}

		private void captureShortcutButton_Click(object sender, EventArgs e) {
			capturingShortcut = true;
			captureShortcutButton.Text = "Press some keys... (Press escape to cancel)";
		}

		private void cancelButton_Click(object sender, EventArgs e) {
			outputFolderTextBox.Text = Config.SavePath.FullName;
			captureShortcutButton.Text = (latestShortcutKeys = Config.CaptureShortcut.keys).ToString();

			saveSettingsButton.Enabled = false;
			this.Visible = false;
		}

		private void saveSettingsButton_Click(object sender, EventArgs e) {
			Debug.WriteLine("Attempting save");
			if (restartRequired) {
				using (var restartButton = new TaskDialogButton(ButtonType.Custom) {
					Text = "Restart now",
					CommandLinkNote = "The new settings will fully take effect."
				})
				using (var restartLaterButton = new TaskDialogButton(ButtonType.Custom) {
					Text = "Restart later",
					CommandLinkNote = "The new settings wont take effect until you reopen Purple Electron"
				})
				using (var cancelChanges = new TaskDialogButton(ButtonType.Custom) {
					Text = "Discard changes",
					CommandLinkNote = "Discard the new settings and don't restart Purple Election"
				})
				using (var td = new TaskDialog {
					WindowTitle = "Restart required...",
					MainIcon = TaskDialogIcon.Information,
					MainInstruction = "Restart required for settings to take effect",
					Content = "In order for the new settings to take effect, you must close and reopen Purple Electron!\n\nWould you like to restart now, or later?",
					ButtonStyle = TaskDialogButtonStyle.CommandLinks,

				}) {
					td.Buttons.Add(restartButton);
					td.Buttons.Add(restartLaterButton);
					td.Buttons.Add(cancelChanges);
					var press = td.ShowDialog(this);

					switch (press.Text) {
						case "Restart now":
							try {
								ShortSave();

								saveSettingsButton.Enabled = false;

								Process.Start(Application.ExecutablePath);
								Process.GetCurrentProcess().Kill();
							}
							catch (Exception ex) {
								throw;
							}
							break;
						case "Restart later":
							ShortSave();

							saveSettingsButton.Enabled = false;
							this.Visible = false;
							break;
						case "Discard changes":
							outputFolderTextBox.Text = Config.SavePath.FullName;
							captureShortcutButton.Text = (latestShortcutKeys = Config.CaptureShortcut.keys).ToString();
							break;
					}
				}
			}
			else {
				Debug.WriteLine("Committing to short save");
				ShortSave();

				saveSettingsButton.Enabled = false;
				this.Visible = false;
			}

			Debug.WriteLine("Restarting enabled capture devices and stopping disabled capture devices");
			Config.ActiveChannels.ForEach(item => {
				if (item.enabled) {
					item.channel.StopCapture();
					item.channel.StartCapture();
				}
				else {
					item.channel.StopCapture();
				}
			});
		}

		private void altCheckBox_CheckedChanged(object sender, EventArgs e) {
			saveSettingsButton.Enabled = true;
		}

		private void ctrlCheckBox_CheckedChanged(object sender, EventArgs e) {
			saveSettingsButton.Enabled = true;
		}

		private void shiftCheckBox_CheckedChanged(object sender, EventArgs e) {
			saveSettingsButton.Enabled = true;
		}

		private void systemDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			saveSettingsButton.Enabled = true;
		}

		private void microphoneDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			saveSettingsButton.Enabled = true;
		}

		private void ShortSave() {

			Debug.WriteLine("Saving editor preferences to config");
			Config.SavePath = new System.IO.DirectoryInfo(outputFolderTextBox.Text);
			Config.CaptureShortcut = new KeyShortcut(latestShortcutKeys, shiftCheckBox.Checked, ctrlCheckBox.Checked, altCheckBox.Checked);

			// TODO: remember what I was going to do here

			var addedChannels = channelListBox.Items.Select(item => (ChannelItem)item.Tag);
			var channelsArray = Config.ActiveChannels.ToArray();
			foreach (var add_this in addedChannels.Except(channelsArray)) {
				Debug.WriteLine("Adding channel to active channels");
				Config.ActiveChannels.Add(add_this);
			}
			Config.ActiveChannels.RemoveAll(item => {
				var ret = !addedChannels.Contains(item);
				if (ret) {
					Debug.WriteLine("Removing channel from active channels");
					item.channel.Dispose();
				}
				return ret;
			});

			Config.SaveConfig();
		}

		public void SetupEvents(ProcessContext context) {
			this.context = context;
			hook = Hook.GlobalEvents();
			
			hook.KeyDown += Hook_KeyDown;
		}

		private void Hook_KeyDown(object sender, KeyEventArgs e) {
			if (capturingShortcut) {

				if (e.KeyCode == Keys.Escape) {
					capturingShortcut = false;
					captureShortcutButton.Text = Config.CaptureShortcut.ToString();
					e.Handled = true;
				}
				else if (e.KeyCode != Keys.None && e.Modifiers == Keys.None) {
					capturingShortcut = false;

					latestShortcutKeys = e.KeyCode;

					captureShortcutButton.Text = e.KeyCode.ToString();

					saveSettingsButton.Enabled = true;
					e.Handled = true;
				}
			}
			else if (e.KeyCode == Config.CaptureShortcut.keys && e.Modifiers == Config.CaptureShortcut.modifiers) {
				Debug.WriteLine("Saving");
				context.SaveData();
			}
		}

		private void aboutButton_Click(object sender, EventArgs e) {
			var about = new AboutPurpleElectron();
			about.ShowDialog(this);
		}

		private void AddChannel(ChannelTypeItem channel) {
			Debug.WriteLine("Adding channel");
			var typeCount = 0;
			foreach (var listItem in channelListBox.Items) {
				if ((listItem.Tag as ChannelItem).channel.GetType() == channel.objectType) typeCount++;
			}

			var item = new ChannelItem(
				(IChannel)Activator.CreateInstance(
					channel.objectType,
					new[] {
						channel.channelTypeName + (typeCount == 0 ? "" : " " + typeCount.ToString()),
						(object)OutputFormat.WAV
					})
				);

			channelListBox.Items.Add(new VIBlend.WinForms.Controls.ListItem {
				Tag = item,
				Text = item.ToString()
			});

			saveSettingsButton.Enabled = true;
		}

		private void UpdateChannels() {
			Debug.WriteLine("Updating channels");

			var addedChannels = channelListBox.Items.Select(item => (ChannelItem)item.Tag);
			foreach (var remove_this in addedChannels.Except(Config.ActiveChannels)) {
				var itemsToRemove = channelListBox.Items.Where(item => item.Tag == remove_this);
				foreach (var item in itemsToRemove) {
					channelListBox.Items.Remove(item);
				}
			}
			foreach (var add_this in Config.ActiveChannels.Except(addedChannels)) {
				var itemsToAdd = Config.ActiveChannels.Where(item => !addedChannels.Contains(add_this));
				foreach (var item in itemsToAdd) {
					channelListBox.Items.Add(new VIBlend.WinForms.Controls.ListItem {
						Tag = item,
						Text = item.ToString()
					});
				}
			}
		}

		private void addChannelButton_Click(object sender, EventArgs e) {
			
			var vals = Config.RegisteredChannels.Values.ToArray();
			var channelTypes = new MenuItem[vals.Length];
            for (int i = 0; i < vals.Length; i++) {
				var val = vals[i];
				channelTypes[i] = new MenuItem(val.channelTypeName, (_s, _e) => AddChannel(val));
			}
			addButtonMenu = new ContextMenu(channelTypes);

			addButtonMenu.Show(addChannelButton, addChannelButton.PointToClient(Cursor.Position));
		}

		private void deleteChannelButton_Click(object sender, EventArgs e) {
			if (channelListBox.SelectedIndex > -1 && channelListBox.SelectedIndex < channelListBox.Items.Count) {
				channelListBox.Items.RemoveAt(channelListBox.SelectedIndex);
				saveSettingsButton.Enabled = true;
			}
		}

		private void ConfigEditor_VisibleChanged(object sender, EventArgs e) {
			if (Visible) {
				UpdateChannels();
			}
		}

		private void channelListBox_MouseDoubleClick(object sender, MouseEventArgs e) {
			if (channelListBox.SelectedItem != null) {

				saveSettingsButton.Enabled = (channelListBox.SelectedItem.Tag as ChannelItem).channel.ShowPropertiesEditor();
				channelListBox.SelectedItem.Text = (channelListBox.SelectedItem.Tag as ChannelItem).channel.channelName;
            }
		}
	}
}
