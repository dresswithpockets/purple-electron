namespace PurpleElectron {
	partial class ConfigEditor {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigEditor));
			this.configTabs = new VIBlend.WinForms.Controls.vTabControl();
			this.outputTabPage = new VIBlend.WinForms.Controls.vTabPage();
			this.fileFormatCombatBox = new VIBlend.WinForms.Controls.vComboBox();
			this.outputFormatLAbel = new VIBlend.WinForms.Controls.vLabel();
			this.browseButton = new VIBlend.WinForms.Controls.vButton();
			this.outputFolderTextBox = new VIBlend.WinForms.Controls.vTextBox();
			this.outputFolderLabel = new VIBlend.WinForms.Controls.vLabel();
			this.captureTabPage = new VIBlend.WinForms.Controls.vTabPage();
			this.refreshDevicesButton = new VIBlend.WinForms.Controls.vButton();
			this.microphoneDeviceComboBox = new System.Windows.Forms.ComboBox();
			this.systemDeviceComboBox = new System.Windows.Forms.ComboBox();
			this.microphoneDeviceLabel = new VIBlend.WinForms.Controls.vLabel();
			this.systemDeviceLabel = new VIBlend.WinForms.Controls.vLabel();
			this.cacheLengthNumber = new VIBlend.WinForms.Controls.vNumberEditor();
			this.altLabel = new VIBlend.WinForms.Controls.vLabel();
			this.ctrlLabel = new VIBlend.WinForms.Controls.vLabel();
			this.altCheckBox = new VIBlend.WinForms.Controls.vCheckBox();
			this.shiftLabel = new VIBlend.WinForms.Controls.vLabel();
			this.ctrlCheckBox = new VIBlend.WinForms.Controls.vCheckBox();
			this.shiftCheckBox = new VIBlend.WinForms.Controls.vCheckBox();
			this.cacheLengthNoteB = new VIBlend.WinForms.Controls.vLabel();
			this.cacheLengthNoteA = new VIBlend.WinForms.Controls.vLabel();
			this.cacheLengthLabel = new VIBlend.WinForms.Controls.vLabel();
			this.captureShortcutLabel = new VIBlend.WinForms.Controls.vLabel();
			this.captureShortcutButton = new VIBlend.WinForms.Controls.vButton();
			this.outputFolderBrowseDialog = new Ookii.Dialogs.VistaFolderBrowserDialog();
			this.cancelButton = new VIBlend.WinForms.Controls.vButton();
			this.saveSettingsButton = new VIBlend.WinForms.Controls.vButton();
			this.configTabs.SuspendLayout();
			this.outputTabPage.SuspendLayout();
			this.captureTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// configTabs
			// 
			this.configTabs.AllowAnimations = true;
			this.configTabs.AllPagesHeight = 0;
			this.configTabs.Controls.Add(this.outputTabPage);
			this.configTabs.Controls.Add(this.captureTabPage);
			this.configTabs.Dock = System.Windows.Forms.DockStyle.Top;
			this.configTabs.FitTabsToBounds = true;
			this.configTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.configTabs.Location = new System.Drawing.Point(0, 0);
			this.configTabs.MinimumSize = new System.Drawing.Size(0, 186);
			this.configTabs.Name = "configTabs";
			this.configTabs.Padding = new System.Windows.Forms.Padding(100, 0, 0, 0);
			this.configTabs.Size = new System.Drawing.Size(671, 279);
			this.configTabs.TabAlignment = VIBlend.WinForms.Controls.vTabPageAlignment.Left;
			this.configTabs.TabIndex = 1;
			this.configTabs.TabPages.Add(this.outputTabPage);
			this.configTabs.TabPages.Add(this.captureTabPage);
			this.configTabs.TabsAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
			this.configTabs.TextOrientation = VIBlend.WinForms.Controls.vTabPageTextOrientation.Vertical;
			this.configTabs.TitleHeight = 100;
			this.configTabs.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLACKPEARL;
			// 
			// outputTabPage
			// 
			this.outputTabPage.Controls.Add(this.fileFormatCombatBox);
			this.outputTabPage.Controls.Add(this.outputFormatLAbel);
			this.outputTabPage.Controls.Add(this.browseButton);
			this.outputTabPage.Controls.Add(this.outputFolderTextBox);
			this.outputTabPage.Controls.Add(this.outputFolderLabel);
			this.outputTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputTabPage.Location = new System.Drawing.Point(100, 0);
			this.outputTabPage.Name = "outputTabPage";
			this.outputTabPage.Padding = new System.Windows.Forms.Padding(0);
			this.outputTabPage.SelectedTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputTabPage.Size = new System.Drawing.Size(571, 279);
			this.outputTabPage.TabIndex = 3;
			this.outputTabPage.Text = "Output";
			this.outputTabPage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputTabPage.TooltipText = "Settings regarding output files and format";
			this.outputTabPage.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLACKPEARL;
			this.outputTabPage.Visible = false;
			// 
			// fileFormatCombatBox
			// 
			this.fileFormatCombatBox.AutoCompleteEnabled = true;
			this.fileFormatCombatBox.BackColor = System.Drawing.Color.White;
			this.fileFormatCombatBox.DisplayMember = "";
			this.fileFormatCombatBox.DropDownHeight = 80;
			this.fileFormatCombatBox.DropDownList = true;
			this.fileFormatCombatBox.DropDownMaximumSize = new System.Drawing.Size(1000, 1000);
			this.fileFormatCombatBox.DropDownMinimumSize = new System.Drawing.Size(10, 10);
			this.fileFormatCombatBox.DropDownResizeDirection = VIBlend.WinForms.Controls.SizingDirection.None;
			this.fileFormatCombatBox.DropDownWidth = 391;
			this.fileFormatCombatBox.Enabled = false;
			listItem1.RoundedCornersMask = ((byte)(15));
			listItem1.Text = "WAVE (.wav)";
			listItem2.RoundedCornersMask = ((byte)(15));
			listItem2.Text = "FLAC (.flac)";
			listItem3.RoundedCornersMask = ((byte)(15));
			listItem3.Text = "Ogg Vorbis (.ogg)";
			listItem4.RoundedCornersMask = ((byte)(15));
			listItem4.Text = "MPEG-2 Audio Layer III (.mp3)";
			this.fileFormatCombatBox.Items.Add(listItem1);
			this.fileFormatCombatBox.Items.Add(listItem2);
			this.fileFormatCombatBox.Items.Add(listItem3);
			this.fileFormatCombatBox.Items.Add(listItem4);
			this.fileFormatCombatBox.Location = new System.Drawing.Point(149, 82);
			this.fileFormatCombatBox.Name = "fileFormatCombatBox";
			this.fileFormatCombatBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fileFormatCombatBox.RoundedCornersMaskListItem = ((byte)(15));
			this.fileFormatCombatBox.SelectedIndex = 0;
			this.fileFormatCombatBox.ShowGrip = false;
			this.fileFormatCombatBox.Size = new System.Drawing.Size(391, 23);
			this.fileFormatCombatBox.TabIndex = 3;
			this.fileFormatCombatBox.Text = "WAVE (.wav)";
			this.fileFormatCombatBox.UseThemeBackColor = false;
			this.fileFormatCombatBox.UseThemeDropDownArrowColor = true;
			this.fileFormatCombatBox.ValueMember = "";
			this.fileFormatCombatBox.VIBlendScrollBarsTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.fileFormatCombatBox.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.fileFormatCombatBox.SelectedIndexChanged += new System.EventHandler(this.fileFormatCombatBox_SelectedIndexChanged);
			// 
			// outputFormatLAbel
			// 
			this.outputFormatLAbel.BackColor = System.Drawing.Color.Transparent;
			this.outputFormatLAbel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.outputFormatLAbel.Ellipsis = false;
			this.outputFormatLAbel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputFormatLAbel.ForeColor = System.Drawing.SystemColors.Control;
			this.outputFormatLAbel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.outputFormatLAbel.Location = new System.Drawing.Point(7, 83);
			this.outputFormatLAbel.Multiline = true;
			this.outputFormatLAbel.Name = "outputFormatLAbel";
			this.outputFormatLAbel.Size = new System.Drawing.Size(119, 25);
			this.outputFormatLAbel.TabIndex = 1;
			this.outputFormatLAbel.Text = "Output Format:";
			this.outputFormatLAbel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.outputFormatLAbel.UseMnemonics = true;
			this.outputFormatLAbel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// browseButton
			// 
			this.browseButton.AllowAnimations = true;
			this.browseButton.BackColor = System.Drawing.Color.Transparent;
			this.browseButton.Location = new System.Drawing.Point(449, 34);
			this.browseButton.Name = "browseButton";
			this.browseButton.RoundedCornersMask = ((byte)(15));
			this.browseButton.Size = new System.Drawing.Size(91, 22);
			this.browseButton.TabIndex = 2;
			this.browseButton.Text = "Browse";
			this.browseButton.UseVisualStyleBackColor = false;
			this.browseButton.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
			// 
			// outputFolderTextBox
			// 
			this.outputFolderTextBox.BackColor = System.Drawing.Color.White;
			this.outputFolderTextBox.BoundsOffset = new System.Drawing.Size(1, 1);
			this.outputFolderTextBox.ControlBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.outputFolderTextBox.DefaultText = "Empty...";
			this.outputFolderTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputFolderTextBox.Location = new System.Drawing.Point(149, 33);
			this.outputFolderTextBox.MaxLength = 32767;
			this.outputFolderTextBox.Name = "outputFolderTextBox";
			this.outputFolderTextBox.PasswordChar = '\0';
			this.outputFolderTextBox.Readonly = true;
			this.outputFolderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.outputFolderTextBox.SelectionLength = 0;
			this.outputFolderTextBox.SelectionStart = 0;
			this.outputFolderTextBox.Size = new System.Drawing.Size(294, 23);
			this.outputFolderTextBox.TabIndex = 1;
			this.outputFolderTextBox.Text = "save/";
			this.outputFolderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.outputFolderTextBox.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// outputFolderLabel
			// 
			this.outputFolderLabel.BackColor = System.Drawing.Color.Transparent;
			this.outputFolderLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.outputFolderLabel.Ellipsis = false;
			this.outputFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.outputFolderLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.outputFolderLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.outputFolderLabel.Location = new System.Drawing.Point(7, 34);
			this.outputFolderLabel.Multiline = true;
			this.outputFolderLabel.Name = "outputFolderLabel";
			this.outputFolderLabel.Size = new System.Drawing.Size(111, 25);
			this.outputFolderLabel.TabIndex = 0;
			this.outputFolderLabel.Text = "Output Folder:";
			this.outputFolderLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.outputFolderLabel.UseMnemonics = true;
			this.outputFolderLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// captureTabPage
			// 
			this.captureTabPage.Controls.Add(this.refreshDevicesButton);
			this.captureTabPage.Controls.Add(this.microphoneDeviceComboBox);
			this.captureTabPage.Controls.Add(this.systemDeviceComboBox);
			this.captureTabPage.Controls.Add(this.microphoneDeviceLabel);
			this.captureTabPage.Controls.Add(this.systemDeviceLabel);
			this.captureTabPage.Controls.Add(this.cacheLengthNumber);
			this.captureTabPage.Controls.Add(this.altLabel);
			this.captureTabPage.Controls.Add(this.ctrlLabel);
			this.captureTabPage.Controls.Add(this.altCheckBox);
			this.captureTabPage.Controls.Add(this.shiftLabel);
			this.captureTabPage.Controls.Add(this.ctrlCheckBox);
			this.captureTabPage.Controls.Add(this.shiftCheckBox);
			this.captureTabPage.Controls.Add(this.cacheLengthNoteB);
			this.captureTabPage.Controls.Add(this.cacheLengthNoteA);
			this.captureTabPage.Controls.Add(this.cacheLengthLabel);
			this.captureTabPage.Controls.Add(this.captureShortcutLabel);
			this.captureTabPage.Controls.Add(this.captureShortcutButton);
			this.captureTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.captureTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.captureTabPage.Location = new System.Drawing.Point(100, 0);
			this.captureTabPage.Name = "captureTabPage";
			this.captureTabPage.Padding = new System.Windows.Forms.Padding(0);
			this.captureTabPage.SelectedTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.captureTabPage.Size = new System.Drawing.Size(571, 279);
			this.captureTabPage.TabIndex = 4;
			this.captureTabPage.Text = "Capture";
			this.captureTabPage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.captureTabPage.TooltipText = "Settings regarding the lookback capturing of audio";
			this.captureTabPage.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.BLACKPEARL;
			this.captureTabPage.Visible = false;
			// 
			// refreshDevicesButton
			// 
			this.refreshDevicesButton.AllowAnimations = true;
			this.refreshDevicesButton.BackColor = System.Drawing.Color.Transparent;
			this.refreshDevicesButton.Location = new System.Drawing.Point(381, 249);
			this.refreshDevicesButton.Name = "refreshDevicesButton";
			this.refreshDevicesButton.RoundedCornersMask = ((byte)(15));
			this.refreshDevicesButton.Size = new System.Drawing.Size(159, 22);
			this.refreshDevicesButton.TabIndex = 4;
			this.refreshDevicesButton.Text = "Refresh Devices";
			this.refreshDevicesButton.UseVisualStyleBackColor = false;
			this.refreshDevicesButton.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.refreshDevicesButton.Click += new System.EventHandler(this.refreshDevicesButton_Click);
			// 
			// microphoneDeviceComboBox
			// 
			this.microphoneDeviceComboBox.FormattingEnabled = true;
			this.microphoneDeviceComboBox.Location = new System.Drawing.Point(149, 215);
			this.microphoneDeviceComboBox.Name = "microphoneDeviceComboBox";
			this.microphoneDeviceComboBox.Size = new System.Drawing.Size(391, 28);
			this.microphoneDeviceComboBox.TabIndex = 15;
			this.microphoneDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.microphoneDeviceComboBox_SelectedIndexChanged);
			// 
			// systemDeviceComboBox
			// 
			this.systemDeviceComboBox.FormattingEnabled = true;
			this.systemDeviceComboBox.Location = new System.Drawing.Point(149, 173);
			this.systemDeviceComboBox.Name = "systemDeviceComboBox";
			this.systemDeviceComboBox.Size = new System.Drawing.Size(391, 28);
			this.systemDeviceComboBox.TabIndex = 14;
			this.systemDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.systemDeviceComboBox_SelectedIndexChanged);
			// 
			// microphoneDeviceLabel
			// 
			this.microphoneDeviceLabel.BackColor = System.Drawing.Color.Transparent;
			this.microphoneDeviceLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.microphoneDeviceLabel.Ellipsis = false;
			this.microphoneDeviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.microphoneDeviceLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.microphoneDeviceLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.microphoneDeviceLabel.Location = new System.Drawing.Point(7, 218);
			this.microphoneDeviceLabel.Multiline = true;
			this.microphoneDeviceLabel.Name = "microphoneDeviceLabel";
			this.microphoneDeviceLabel.Size = new System.Drawing.Size(136, 25);
			this.microphoneDeviceLabel.TabIndex = 7;
			this.microphoneDeviceLabel.Text = "Microphone:";
			this.microphoneDeviceLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.microphoneDeviceLabel.UseMnemonics = true;
			this.microphoneDeviceLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// systemDeviceLabel
			// 
			this.systemDeviceLabel.BackColor = System.Drawing.Color.Transparent;
			this.systemDeviceLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.systemDeviceLabel.Ellipsis = false;
			this.systemDeviceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.systemDeviceLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.systemDeviceLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.systemDeviceLabel.Location = new System.Drawing.Point(7, 175);
			this.systemDeviceLabel.Multiline = true;
			this.systemDeviceLabel.Name = "systemDeviceLabel";
			this.systemDeviceLabel.Size = new System.Drawing.Size(136, 25);
			this.systemDeviceLabel.TabIndex = 6;
			this.systemDeviceLabel.Text = "System Device: ";
			this.systemDeviceLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.systemDeviceLabel.UseMnemonics = true;
			this.systemDeviceLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// cacheLengthNumber
			// 
			this.cacheLengthNumber.BackColor = System.Drawing.Color.White;
			this.cacheLengthNumber.BoundsOffset = new System.Drawing.Size(1, 1);
			this.cacheLengthNumber.ControlBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
			this.cacheLengthNumber.CultureInfo = new System.Globalization.CultureInfo("en-US");
			this.cacheLengthNumber.DecimalPlaces = 0;
			this.cacheLengthNumber.DefaultText = "Empty...";
			this.cacheLengthNumber.Location = new System.Drawing.Point(149, 82);
			this.cacheLengthNumber.MaxLength = 32767;
			this.cacheLengthNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.cacheLengthNumber.Name = "cacheLengthNumber";
			this.cacheLengthNumber.PasswordChar = '\0';
			this.cacheLengthNumber.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cacheLengthNumber.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.cacheLengthNumber.SelectionLength = 0;
			this.cacheLengthNumber.SelectionStart = 0;
			this.cacheLengthNumber.Size = new System.Drawing.Size(391, 23);
			this.cacheLengthNumber.SpinType = VIBlend.WinForms.Controls.SpinType.None;
			this.cacheLengthNumber.TabIndex = 13;
			this.cacheLengthNumber.Text = "1";
			this.cacheLengthNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.cacheLengthNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.cacheLengthNumber.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.STEEL;
			this.cacheLengthNumber.ValueChanged += new VIBlend.WinForms.Controls.ValueChangedEditorEventHandler(this.cacheLengthNumber_ValueChanged);
			// 
			// altLabel
			// 
			this.altLabel.BackColor = System.Drawing.Color.Transparent;
			this.altLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.altLabel.Ellipsis = false;
			this.altLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.altLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.altLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.altLabel.Location = new System.Drawing.Point(326, 34);
			this.altLabel.Multiline = true;
			this.altLabel.Name = "altLabel";
			this.altLabel.Size = new System.Drawing.Size(33, 25);
			this.altLabel.TabIndex = 11;
			this.altLabel.Text = "Alt";
			this.altLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.altLabel.UseMnemonics = true;
			this.altLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// ctrlLabel
			// 
			this.ctrlLabel.BackColor = System.Drawing.Color.Transparent;
			this.ctrlLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.ctrlLabel.Ellipsis = false;
			this.ctrlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ctrlLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.ctrlLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.ctrlLabel.Location = new System.Drawing.Point(257, 34);
			this.ctrlLabel.Multiline = true;
			this.ctrlLabel.Name = "ctrlLabel";
			this.ctrlLabel.Size = new System.Drawing.Size(33, 25);
			this.ctrlLabel.TabIndex = 9;
			this.ctrlLabel.Text = "Ctrl";
			this.ctrlLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.ctrlLabel.UseMnemonics = true;
			this.ctrlLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// altCheckBox
			// 
			this.altCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.altCheckBox.Checked = true;
			this.altCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.altCheckBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.altCheckBox.Location = new System.Drawing.Point(306, 31);
			this.altCheckBox.Name = "altCheckBox";
			this.altCheckBox.Size = new System.Drawing.Size(14, 24);
			this.altCheckBox.TabIndex = 12;
			this.altCheckBox.UseVisualStyleBackColor = false;
			this.altCheckBox.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.altCheckBox.CheckedChanged += new System.EventHandler(this.altCheckBox_CheckedChanged);
			// 
			// shiftLabel
			// 
			this.shiftLabel.BackColor = System.Drawing.Color.Transparent;
			this.shiftLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.shiftLabel.Ellipsis = false;
			this.shiftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.shiftLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.shiftLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.shiftLabel.Location = new System.Drawing.Point(181, 34);
			this.shiftLabel.Multiline = true;
			this.shiftLabel.Name = "shiftLabel";
			this.shiftLabel.Size = new System.Drawing.Size(41, 25);
			this.shiftLabel.TabIndex = 5;
			this.shiftLabel.Text = "Shift";
			this.shiftLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.shiftLabel.UseMnemonics = true;
			this.shiftLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// ctrlCheckBox
			// 
			this.ctrlCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.ctrlCheckBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ctrlCheckBox.Location = new System.Drawing.Point(237, 31);
			this.ctrlCheckBox.Name = "ctrlCheckBox";
			this.ctrlCheckBox.Size = new System.Drawing.Size(14, 24);
			this.ctrlCheckBox.TabIndex = 10;
			this.ctrlCheckBox.UseVisualStyleBackColor = false;
			this.ctrlCheckBox.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.ctrlCheckBox.CheckedChanged += new System.EventHandler(this.ctrlCheckBox_CheckedChanged);
			// 
			// shiftCheckBox
			// 
			this.shiftCheckBox.BackColor = System.Drawing.Color.Transparent;
			this.shiftCheckBox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.shiftCheckBox.Location = new System.Drawing.Point(161, 31);
			this.shiftCheckBox.Name = "shiftCheckBox";
			this.shiftCheckBox.Size = new System.Drawing.Size(14, 24);
			this.shiftCheckBox.TabIndex = 8;
			this.shiftCheckBox.UseVisualStyleBackColor = false;
			this.shiftCheckBox.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.shiftCheckBox.CheckedChanged += new System.EventHandler(this.shiftCheckBox_CheckedChanged);
			// 
			// cacheLengthNoteB
			// 
			this.cacheLengthNoteB.BackColor = System.Drawing.Color.Transparent;
			this.cacheLengthNoteB.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.cacheLengthNoteB.Ellipsis = false;
			this.cacheLengthNoteB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cacheLengthNoteB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			this.cacheLengthNoteB.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.cacheLengthNoteB.Location = new System.Drawing.Point(149, 142);
			this.cacheLengthNoteB.Multiline = true;
			this.cacheLengthNoteB.Name = "cacheLengthNoteB";
			this.cacheLengthNoteB.Size = new System.Drawing.Size(360, 25);
			this.cacheLengthNoteB.TabIndex = 7;
			this.cacheLengthNoteB.Text = " ";
			this.cacheLengthNoteB.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.cacheLengthNoteB.UseMnemonics = true;
			this.cacheLengthNoteB.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// cacheLengthNoteA
			// 
			this.cacheLengthNoteA.BackColor = System.Drawing.Color.Transparent;
			this.cacheLengthNoteA.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.cacheLengthNoteA.Ellipsis = false;
			this.cacheLengthNoteA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cacheLengthNoteA.ForeColor = System.Drawing.SystemColors.Control;
			this.cacheLengthNoteA.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.cacheLengthNoteA.Location = new System.Drawing.Point(149, 111);
			this.cacheLengthNoteA.Multiline = true;
			this.cacheLengthNoteA.Name = "cacheLengthNoteA";
			this.cacheLengthNoteA.Size = new System.Drawing.Size(360, 25);
			this.cacheLengthNoteA.TabIndex = 6;
			this.cacheLengthNoteA.Text = "Note: this value is in seconds. The output file will range from this value to thi" +
    "s value times 2 (i.e. 60 seconds to 120 seconds)";
			this.cacheLengthNoteA.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.cacheLengthNoteA.UseMnemonics = true;
			this.cacheLengthNoteA.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// cacheLengthLabel
			// 
			this.cacheLengthLabel.BackColor = System.Drawing.Color.Transparent;
			this.cacheLengthLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.cacheLengthLabel.Ellipsis = false;
			this.cacheLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cacheLengthLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.cacheLengthLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.cacheLengthLabel.Location = new System.Drawing.Point(7, 83);
			this.cacheLengthLabel.Multiline = true;
			this.cacheLengthLabel.Name = "cacheLengthLabel";
			this.cacheLengthLabel.Size = new System.Drawing.Size(136, 25);
			this.cacheLengthLabel.TabIndex = 5;
			this.cacheLengthLabel.Text = "Cache Length:";
			this.cacheLengthLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.cacheLengthLabel.UseMnemonics = true;
			this.cacheLengthLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// captureShortcutLabel
			// 
			this.captureShortcutLabel.BackColor = System.Drawing.Color.Transparent;
			this.captureShortcutLabel.DisplayStyle = VIBlend.WinForms.Controls.LabelItemStyle.TextOnly;
			this.captureShortcutLabel.Ellipsis = false;
			this.captureShortcutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.captureShortcutLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.captureShortcutLabel.ImageAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.captureShortcutLabel.Location = new System.Drawing.Point(7, 34);
			this.captureShortcutLabel.Multiline = true;
			this.captureShortcutLabel.Name = "captureShortcutLabel";
			this.captureShortcutLabel.Size = new System.Drawing.Size(136, 25);
			this.captureShortcutLabel.TabIndex = 4;
			this.captureShortcutLabel.Text = "Capture Shortcut:";
			this.captureShortcutLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
			this.captureShortcutLabel.UseMnemonics = true;
			this.captureShortcutLabel.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			// 
			// captureShortcutButton
			// 
			this.captureShortcutButton.AllowAnimations = true;
			this.captureShortcutButton.BackColor = System.Drawing.Color.Transparent;
			this.captureShortcutButton.Location = new System.Drawing.Point(381, 34);
			this.captureShortcutButton.Name = "captureShortcutButton";
			this.captureShortcutButton.RoundedCornersMask = ((byte)(15));
			this.captureShortcutButton.Size = new System.Drawing.Size(159, 22);
			this.captureShortcutButton.TabIndex = 3;
			this.captureShortcutButton.Text = "F6";
			this.captureShortcutButton.UseVisualStyleBackColor = false;
			this.captureShortcutButton.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.captureShortcutButton.Click += new System.EventHandler(this.captureShortcutButton_Click);
			// 
			// outputFolderBrowseDialog
			// 
			this.outputFolderBrowseDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// cancelButton
			// 
			this.cancelButton.AllowAnimations = true;
			this.cancelButton.BackColor = System.Drawing.Color.Transparent;
			this.cancelButton.Location = new System.Drawing.Point(562, 285);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.RoundedCornersMask = ((byte)(15));
			this.cancelButton.Size = new System.Drawing.Size(97, 25);
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = false;
			this.cancelButton.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// saveSettingsButton
			// 
			this.saveSettingsButton.AllowAnimations = true;
			this.saveSettingsButton.BackColor = System.Drawing.Color.Transparent;
			this.saveSettingsButton.Enabled = false;
			this.saveSettingsButton.Location = new System.Drawing.Point(459, 285);
			this.saveSettingsButton.Name = "saveSettingsButton";
			this.saveSettingsButton.RoundedCornersMask = ((byte)(15));
			this.saveSettingsButton.Size = new System.Drawing.Size(97, 25);
			this.saveSettingsButton.TabIndex = 4;
			this.saveSettingsButton.Text = "Save";
			this.saveSettingsButton.UseVisualStyleBackColor = false;
			this.saveSettingsButton.VIBlendTheme = VIBlend.Utilities.VIBLEND_THEME.NERO;
			this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
			// 
			// ConfigEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(671, 320);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.configTabs);
			this.Controls.Add(this.saveSettingsButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ConfigEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Purple Electron - Settings";
			this.Load += new System.EventHandler(this.ConfigEditor_Load);
			this.configTabs.ResumeLayout(false);
			this.outputTabPage.ResumeLayout(false);
			this.captureTabPage.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private VIBlend.WinForms.Controls.vTabControl configTabs;
		private VIBlend.WinForms.Controls.vTabPage outputTabPage;
		private VIBlend.WinForms.Controls.vTabPage captureTabPage;
		private VIBlend.WinForms.Controls.vLabel outputFolderLabel;
		private VIBlend.WinForms.Controls.vButton browseButton;
		private VIBlend.WinForms.Controls.vTextBox outputFolderTextBox;
		private VIBlend.WinForms.Controls.vComboBox fileFormatCombatBox;
		private VIBlend.WinForms.Controls.vLabel outputFormatLAbel;
		private VIBlend.WinForms.Controls.vLabel captureShortcutLabel;
		private VIBlend.WinForms.Controls.vButton captureShortcutButton;
		private Ookii.Dialogs.VistaFolderBrowserDialog outputFolderBrowseDialog;
		private VIBlend.WinForms.Controls.vLabel cacheLengthLabel;
		private VIBlend.WinForms.Controls.vLabel cacheLengthNoteA;
		private VIBlend.WinForms.Controls.vLabel cacheLengthNoteB;
		private VIBlend.WinForms.Controls.vLabel altLabel;
		private VIBlend.WinForms.Controls.vLabel ctrlLabel;
		private VIBlend.WinForms.Controls.vCheckBox altCheckBox;
		private VIBlend.WinForms.Controls.vLabel shiftLabel;
		private VIBlend.WinForms.Controls.vCheckBox ctrlCheckBox;
		private VIBlend.WinForms.Controls.vCheckBox shiftCheckBox;
		private VIBlend.WinForms.Controls.vNumberEditor cacheLengthNumber;
		private VIBlend.WinForms.Controls.vButton cancelButton;
		private VIBlend.WinForms.Controls.vButton saveSettingsButton;
		private VIBlend.WinForms.Controls.vLabel systemDeviceLabel;
		private VIBlend.WinForms.Controls.vLabel microphoneDeviceLabel;
		private System.Windows.Forms.ComboBox microphoneDeviceComboBox;
		private System.Windows.Forms.ComboBox systemDeviceComboBox;
		private VIBlend.WinForms.Controls.vButton refreshDevicesButton;
	}
}

