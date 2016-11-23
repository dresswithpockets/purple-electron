using System;

namespace PurpleElectron {
	partial class DeviceCaptureProperties {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			VIBlend.WinForms.Controls.ListItem listItem1 = new VIBlend.WinForms.Controls.ListItem();
			VIBlend.WinForms.Controls.ListItem listItem2 = new VIBlend.WinForms.Controls.ListItem();
			VIBlend.WinForms.Controls.ListItem listItem3 = new VIBlend.WinForms.Controls.ListItem();
			VIBlend.WinForms.Controls.ListItem listItem4 = new VIBlend.WinForms.Controls.ListItem();
			VIBlend.WinForms.Controls.ListItem listItem5 = new VIBlend.WinForms.Controls.ListItem();
			VIBlend.WinForms.Controls.ListItem listItem6 = new VIBlend.WinForms.Controls.ListItem();
			VIBlend.WinForms.Controls.ListItem listItem7 = new VIBlend.WinForms.Controls.ListItem();
			VIBlend.WinForms.Controls.ListItem listItem8 = new VIBlend.WinForms.Controls.ListItem();
			VIBlend.WinForms.Controls.ListItem listItem9 = new VIBlend.WinForms.Controls.ListItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceCaptureProperties));
			this.vPanel1 = new VIBlend.WinForms.Controls.vPanel();
			this.cancelButton = new VIBlend.WinForms.Controls.vButton();
			this.saveSettingsButton = new VIBlend.WinForms.Controls.vButton();
			this.deviceComboBox = new VIBlend.WinForms.Controls.vComboBox();
			this.deviceLabel = new VIBlend.WinForms.Controls.vLabel();
			this.bufferMethodComboBox = new VIBlend.WinForms.Controls.vComboBox();
			this.bufferMethodLabel = new VIBlend.WinForms.Controls.vLabel();
			this.cacheLengthLabel = new VIBlend.WinForms.Controls.vLabel();
			this.outputFormatComboBox = new VIBlend.WinForms.Controls.vComboBox();
			this.outputFormatLabel = new VIBlend.WinForms.Controls.vLabel();
			this.channelNameTextBox = new VIBlend.WinForms.Controls.vTextBox();
			this.channelNameLabel = new VIBlend.WinForms.Controls.vLabel();
			this.cacheLengthTextBox = new PurpleElectron.Controls.NumericTextBox();
			this.vPanel1.Content.SuspendLayout();
			this.vPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// vPanel1
			// 
			this.vPanel1.AllowAnimations = true;
			this.vPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.vPanel1.BorderRadius = 0;
			// 
			// vPanel1.Content
			// 
			this.vPanel1.Content.AutoScroll = true;
			this.vPanel1.Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.vPanel1.Content.Controls.Add(this.cancelButton);
			this.vPanel1.Content.Controls.Add(this.saveSettingsButton);
			this.vPanel1.Content.Controls.Add(this.deviceComboBox);
			this.vPanel1.Content.Controls.Add(this.deviceLabel);
			this.vPanel1.Content.Controls.Add(this.bufferMethodComboBox);
			this.vPanel1.Content.Controls.Add(this.bufferMethodLabel);
			this.vPanel1.Content.Controls.Add(this.cacheLengthTextBox);
			this.vPanel1.Content.Controls.Add(this.cacheLengthLabel);
			this.vPanel1.Content.Controls.Add(this.outputFormatComboBox);
			this.vPanel1.Content.Controls.Add(this.outputFormatLabel);
			this.vPanel1.Content.Controls.Add(this.channelNameTextBox);
			this.vPanel1.Content.Controls.Add(this.channelNameLabel);
			this.vPanel1.Content.Location = new System.Drawing.Point(1, 1);
			this.vPanel1.Content.Name = "Content";
			this.vPanel1.Content.Size = new System.Drawing.Size(445, 200);
			this.vPanel1.Content.TabIndex = 3;
			this.vPanel1.CustomScrollersIntersectionColor = System.Drawing.Color.Empty;
			this.vPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vPanel1.Location = new System.Drawing.Point(0, 0);
			this.vPanel1.Name = "vPanel1";
			this.vPanel1.Opacity = 1F;
			this.vPanel1.PanelBorderColor = System.Drawing.Color.Transparent;
			this.vPanel1.Size = new System.Drawing.Size(447, 202);
			this.vPanel1.TabIndex = 0;
			this.vPanel1.Text = "vPanel1";
			this.vPanel1.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// cancelButton
			// 
			this.cancelButton.AllowAnimations = true;
			this.cancelButton.BackColor = System.Drawing.Color.Transparent;
			this.cancelButton.Location = new System.Drawing.Point(337, 164);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.RoundedCornersMask = ((byte)(15));
			this.cancelButton.Size = new System.Drawing.Size(97, 25);
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = false;
			this.cancelButton.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// saveSettingsButton
			// 
			this.saveSettingsButton.AllowAnimations = true;
			this.saveSettingsButton.BackColor = System.Drawing.Color.Transparent;
			this.saveSettingsButton.Location = new System.Drawing.Point(234, 164);
			this.saveSettingsButton.Name = "saveSettingsButton";
			this.saveSettingsButton.RoundedCornersMask = ((byte)(15));
			this.saveSettingsButton.Size = new System.Drawing.Size(97, 25);
			this.saveSettingsButton.TabIndex = 6;
			this.saveSettingsButton.Text = "Okay";
			this.saveSettingsButton.UseVisualStyleBackColor = false;
			this.saveSettingsButton.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
			// 
			// deviceComboBox
			// 
			this.deviceComboBox.BackColor = System.Drawing.Color.White;
			this.deviceComboBox.DisplayMember = "";
			this.deviceComboBox.DropDownMaximumSize = new System.Drawing.Size(1000, 1000);
			this.deviceComboBox.DropDownMinimumSize = new System.Drawing.Size(10, 10);
			this.deviceComboBox.DropDownResizeDirection = VIBlend.WinForms.Controls.SizingDirection.Both;
			this.deviceComboBox.DropDownWidth = 296;
			this.deviceComboBox.Location = new System.Drawing.Point(138, 135);
			this.deviceComboBox.Name = "deviceComboBox";
			this.deviceComboBox.RoundedCornersMaskListItem = ((byte)(15));
			this.deviceComboBox.Size = new System.Drawing.Size(296, 23);
			this.deviceComboBox.TabIndex = 5;
			this.deviceComboBox.UseThemeBackColor = false;
			this.deviceComboBox.UseThemeDropDownArrowColor = true;
			this.deviceComboBox.ValueMember = "";
			this.deviceComboBox.VIBlendScrollBarsTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.deviceComboBox.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// deviceLabel
			// 
			this.deviceLabel.BackColor = System.Drawing.Color.Transparent;
			this.deviceLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.deviceLabel.Ellipsis = false;
			this.deviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.deviceLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.deviceLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.deviceLabel.Location = new System.Drawing.Point(11, 135);
			this.deviceLabel.Multiline = true;
			this.deviceLabel.Name = "deviceLabel";
			this.deviceLabel.Size = new System.Drawing.Size(120, 25);
			this.deviceLabel.TabIndex = 5;
			this.deviceLabel.Text = "Device:";
			this.deviceLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.deviceLabel.UseMnemonics = true;
			this.deviceLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// bufferMethodComboBox
			// 
			this.bufferMethodComboBox.BackColor = System.Drawing.Color.White;
			this.bufferMethodComboBox.DisplayMember = "";
			this.bufferMethodComboBox.DropDownMaximumSize = new System.Drawing.Size(1000, 1000);
			this.bufferMethodComboBox.DropDownMinimumSize = new System.Drawing.Size(10, 10);
			this.bufferMethodComboBox.DropDownResizeDirection = VIBlend.WinForms.Controls.SizingDirection.Both;
			this.bufferMethodComboBox.DropDownWidth = 296;
			listItem1.RoundedCornersMask = ((byte)(15));
			listItem1.Text = "Store Data in File Buffer";
			listItem2.RoundedCornersMask = ((byte)(15));
			listItem2.Text = "Store Data in Memory Buffer";
			this.bufferMethodComboBox.Items.Add(listItem1);
			this.bufferMethodComboBox.Items.Add(listItem2);
			this.bufferMethodComboBox.Location = new System.Drawing.Point(138, 104);
			this.bufferMethodComboBox.Name = "bufferMethodComboBox";
			this.bufferMethodComboBox.RoundedCornersMaskListItem = ((byte)(15));
			this.bufferMethodComboBox.SelectedIndex = 0;
			this.bufferMethodComboBox.Size = new System.Drawing.Size(296, 23);
			this.bufferMethodComboBox.TabIndex = 4;
			this.bufferMethodComboBox.Text = "Store Data in File Buffer";
			this.bufferMethodComboBox.UseThemeBackColor = false;
			this.bufferMethodComboBox.UseThemeDropDownArrowColor = true;
			this.bufferMethodComboBox.ValueMember = "";
			this.bufferMethodComboBox.VIBlendScrollBarsTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.bufferMethodComboBox.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// bufferMethodLabel
			// 
			this.bufferMethodLabel.BackColor = System.Drawing.Color.Transparent;
			this.bufferMethodLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.bufferMethodLabel.Ellipsis = false;
			this.bufferMethodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bufferMethodLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.bufferMethodLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.bufferMethodLabel.Location = new System.Drawing.Point(11, 104);
			this.bufferMethodLabel.Multiline = true;
			this.bufferMethodLabel.Name = "bufferMethodLabel";
			this.bufferMethodLabel.Size = new System.Drawing.Size(120, 25);
			this.bufferMethodLabel.TabIndex = 4;
			this.bufferMethodLabel.Text = "Buffer Method:";
			this.bufferMethodLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.bufferMethodLabel.UseMnemonics = true;
			this.bufferMethodLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// cacheLengthLabel
			// 
			this.cacheLengthLabel.BackColor = System.Drawing.Color.Transparent;
			this.cacheLengthLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.cacheLengthLabel.Ellipsis = false;
			this.cacheLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cacheLengthLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.cacheLengthLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.cacheLengthLabel.Location = new System.Drawing.Point(11, 73);
			this.cacheLengthLabel.Multiline = true;
			this.cacheLengthLabel.Name = "cacheLengthLabel";
			this.cacheLengthLabel.Size = new System.Drawing.Size(120, 25);
			this.cacheLengthLabel.TabIndex = 3;
			this.cacheLengthLabel.Text = "Cache Length:";
			this.cacheLengthLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.cacheLengthLabel.UseMnemonics = true;
			this.cacheLengthLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// outputFormatComboBox
			// 
			this.outputFormatComboBox.BackColor = System.Drawing.Color.White;
			this.outputFormatComboBox.DisplayMember = "";
			this.outputFormatComboBox.DropDownMaximumSize = new System.Drawing.Size(1000, 1000);
			this.outputFormatComboBox.DropDownMinimumSize = new System.Drawing.Size(10, 10);
			this.outputFormatComboBox.DropDownResizeDirection = VIBlend.WinForms.Controls.SizingDirection.Both;
			this.outputFormatComboBox.DropDownWidth = 296;
			listItem3.RoundedCornersMask = ((byte)(15));
			listItem3.Text = "Waveform (*.wav)";
			listItem4.RoundedCornersMask = ((byte)(15));
			listItem4.Text = "Audio Layer III (*.mp3)";
			listItem5.RoundedCornersMask = ((byte)(15));
			listItem5.Text = "Free Lossless (*.flac)";
			listItem6.RoundedCornersMask = ((byte)(15));
			listItem6.Text = "Audio Interchange (*.aiff)";
			listItem7.RoundedCornersMask = ((byte)(15));
			listItem7.Text = "Windows Media Audio (*.wma)";
			listItem8.RoundedCornersMask = ((byte)(15));
			listItem8.Text = "Advanced Audio Coding (*.aac)";
			listItem9.RoundedCornersMask = ((byte)(15));
			listItem9.Text = "Raw Audio (*.raw)";
			this.outputFormatComboBox.Items.Add(listItem3);
			this.outputFormatComboBox.Items.Add(listItem4);
			this.outputFormatComboBox.Items.Add(listItem5);
			this.outputFormatComboBox.Items.Add(listItem6);
			this.outputFormatComboBox.Items.Add(listItem7);
			this.outputFormatComboBox.Items.Add(listItem8);
			this.outputFormatComboBox.Items.Add(listItem9);
			this.outputFormatComboBox.Location = new System.Drawing.Point(138, 42);
			this.outputFormatComboBox.Name = "outputFormatComboBox";
			this.outputFormatComboBox.RoundedCornersMaskListItem = ((byte)(15));
			this.outputFormatComboBox.SelectedIndex = 0;
			this.outputFormatComboBox.Size = new System.Drawing.Size(296, 23);
			this.outputFormatComboBox.TabIndex = 3;
			this.outputFormatComboBox.Text = "Waveform (*.wav)";
			this.outputFormatComboBox.UseThemeBackColor = false;
			this.outputFormatComboBox.UseThemeDropDownArrowColor = true;
			this.outputFormatComboBox.ValueMember = "";
			this.outputFormatComboBox.VIBlendScrollBarsTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.outputFormatComboBox.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// outputFormatLabel
			// 
			this.outputFormatLabel.BackColor = System.Drawing.Color.Transparent;
			this.outputFormatLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.outputFormatLabel.Ellipsis = false;
			this.outputFormatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputFormatLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.outputFormatLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.outputFormatLabel.Location = new System.Drawing.Point(11, 42);
			this.outputFormatLabel.Multiline = true;
			this.outputFormatLabel.Name = "outputFormatLabel";
			this.outputFormatLabel.Size = new System.Drawing.Size(120, 25);
			this.outputFormatLabel.TabIndex = 2;
			this.outputFormatLabel.Text = "Output Format:";
			this.outputFormatLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.outputFormatLabel.UseMnemonics = true;
			this.outputFormatLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// channelNameTextBox
			// 
			this.channelNameTextBox.BackColor = System.Drawing.Color.White;
			this.channelNameTextBox.BoundsOffset = new System.Drawing.Size(1, 1);
			this.channelNameTextBox.ControlBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.channelNameTextBox.DefaultText = "Empty...";
			this.channelNameTextBox.Location = new System.Drawing.Point(138, 11);
			this.channelNameTextBox.MaxLength = 32767;
			this.channelNameTextBox.Name = "channelNameTextBox";
			this.channelNameTextBox.PasswordChar = '\0';
			this.channelNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.channelNameTextBox.SelectionLength = 0;
			this.channelNameTextBox.SelectionStart = 0;
			this.channelNameTextBox.Size = new System.Drawing.Size(296, 23);
			this.channelNameTextBox.TabIndex = 2;
			this.channelNameTextBox.Text = "Device Capture";
			this.channelNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.channelNameTextBox.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// channelNameLabel
			// 
			this.channelNameLabel.BackColor = System.Drawing.Color.Transparent;
			this.channelNameLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.channelNameLabel.Ellipsis = false;
			this.channelNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.channelNameLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.channelNameLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.channelNameLabel.Location = new System.Drawing.Point(11, 11);
			this.channelNameLabel.Multiline = true;
			this.channelNameLabel.Name = "channelNameLabel";
			this.channelNameLabel.Size = new System.Drawing.Size(120, 25);
			this.channelNameLabel.TabIndex = 1;
			this.channelNameLabel.Text = "Channel Name:";
			this.channelNameLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.channelNameLabel.UseMnemonics = true;
			this.channelNameLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// cacheLengthTextBox
			// 
			this.cacheLengthTextBox.DecimalNumbers = 0;
			this.cacheLengthTextBox.DecimalText = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.cacheLengthTextBox.ForeColor = System.Drawing.Color.Black;
			this.cacheLengthTextBox.Format = "^(\\-?)(\\d*)$";
			this.cacheLengthTextBox.HasNegatives = true;
			this.cacheLengthTextBox.Location = new System.Drawing.Point(138, 73);
			this.cacheLengthTextBox.Name = "cacheLengthTextBox";
			this.cacheLengthTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.cacheLengthTextBox.Size = new System.Drawing.Size(296, 20);
			this.cacheLengthTextBox.TabIndex = 4;
			this.cacheLengthTextBox.Text = "0";
			this.cacheLengthTextBox.TextChanged += new System.EventHandler(this.cacheLengthTextBox_TextChanged);
			// 
			// DeviceCaptureProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 202);
			this.Controls.Add(this.vPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "DeviceCaptureProperties";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Device Capture";
			this.vPanel1.Content.ResumeLayout(false);
			this.vPanel1.Content.PerformLayout();
			this.vPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private VIBlend.WinForms.Controls.vPanel vPanel1;
		private VIBlend.WinForms.Controls.vLabel channelNameLabel;
		private VIBlend.WinForms.Controls.vTextBox channelNameTextBox;
		private VIBlend.WinForms.Controls.vLabel outputFormatLabel;
		private VIBlend.WinForms.Controls.vComboBox outputFormatComboBox;
		private VIBlend.WinForms.Controls.vLabel cacheLengthLabel;
		private Controls.NumericTextBox cacheLengthTextBox;
		private VIBlend.WinForms.Controls.vComboBox bufferMethodComboBox;
		private VIBlend.WinForms.Controls.vLabel bufferMethodLabel;
		private VIBlend.WinForms.Controls.vComboBox deviceComboBox;
		private VIBlend.WinForms.Controls.vLabel deviceLabel;
		private VIBlend.WinForms.Controls.vButton cancelButton;
		private VIBlend.WinForms.Controls.vButton saveSettingsButton;
	}
}