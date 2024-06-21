namespace UltimateBlueScreenSimulator
{
    partial class PrankMode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrankMode));
            this.bluescreenTypeLabel = new MaterialSkin.Controls.MaterialLabel();
            this.bluescreenTypePanel = new System.Windows.Forms.Panel();
            this.matchAllRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.bestMatchRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.triggerLabel = new MaterialSkin.Controls.MaterialLabel();
            this.triggerPanel = new System.Windows.Forms.Panel();
            this.usbRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.appRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.timeRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.triggerFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.timePanel = new System.Windows.Forms.Panel();
            this.timerBox = new MaterialSkin.Controls.MaterialMaskedTextBox();
            this.timeFormatLabel = new MaterialSkin.Controls.MaterialLabel();
            this.appPanel = new System.Windows.Forms.Panel();
            this.triggerAppLabel = new MaterialSkin.Controls.MaterialLabel();
            this.triggerAppBox = new MaterialSkin.Controls.MaterialTextBox();
            this.usbPanel = new System.Windows.Forms.Panel();
            this.whyNoDeviceButton = new MaterialSkin.Controls.MaterialButton();
            this.resetDeviceButton = new MaterialSkin.Controls.MaterialButton();
            this.deviceInfoLabel = new MaterialSkin.Controls.MaterialLabel();
            this.letCloseBox = new MaterialSkin.Controls.MaterialCheckbox();
            this.miscLabel = new MaterialSkin.Controls.MaterialLabel();
            this.friendlyMessageBox = new MaterialSkin.Controls.MaterialCheckbox();
            this.friendlyMessageContentsBox = new MaterialSkin.Controls.MaterialTextBox();
            this.friendlyMessageTitleLabel = new MaterialSkin.Controls.MaterialLabel();
            this.friendlyMessageTitleBox = new MaterialSkin.Controls.MaterialTextBox();
            this.friendlyMessageIconPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.errorRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.warningRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.questionRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.infoRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.noneRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.friendlyMessageIconLabel = new MaterialSkin.Controls.MaterialLabel();
            this.friendlyMessageButtonsLabel = new MaterialSkin.Controls.MaterialLabel();
            this.friendlyMessageButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.okRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.okCancelRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.retryIgnoreAboutRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.retryCancelRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.yesNoRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.yesNoCancelRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.previewFriendlyMessageButton = new MaterialSkin.Controls.MaterialButton();
            this.okButton = new MaterialSkin.Controls.MaterialButton();
            this.cancelButton = new MaterialSkin.Controls.MaterialButton();
            this.usbFinder = new System.Windows.Forms.Timer(this.components);
            this.closePrank = new MaterialSkin.Controls.MaterialCheckbox();
            this.bluescreenTypePanel.SuspendLayout();
            this.triggerPanel.SuspendLayout();
            this.triggerFlowPanel.SuspendLayout();
            this.timePanel.SuspendLayout();
            this.appPanel.SuspendLayout();
            this.usbPanel.SuspendLayout();
            this.friendlyMessageIconPanel.SuspendLayout();
            this.friendlyMessageButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bluescreenTypeLabel
            // 
            this.bluescreenTypeLabel.AutoSize = true;
            this.bluescreenTypeLabel.Depth = 0;
            this.bluescreenTypeLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bluescreenTypeLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.bluescreenTypeLabel.Location = new System.Drawing.Point(17, 72);
            this.bluescreenTypeLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.bluescreenTypeLabel.Name = "bluescreenTypeLabel";
            this.bluescreenTypeLabel.Size = new System.Drawing.Size(103, 14);
            this.bluescreenTypeLabel.TabIndex = 0;
            this.bluescreenTypeLabel.Text = "Bluescreen options";
            // 
            // bluescreenTypePanel
            // 
            this.bluescreenTypePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bluescreenTypePanel.Controls.Add(this.matchAllRadio);
            this.bluescreenTypePanel.Controls.Add(this.bestMatchRadio);
            this.bluescreenTypePanel.Location = new System.Drawing.Point(17, 88);
            this.bluescreenTypePanel.Name = "bluescreenTypePanel";
            this.bluescreenTypePanel.Size = new System.Drawing.Size(704, 70);
            this.bluescreenTypePanel.TabIndex = 1;
            // 
            // matchAllRadio
            // 
            this.matchAllRadio.AutoSize = true;
            this.matchAllRadio.Depth = 0;
            this.matchAllRadio.Location = new System.Drawing.Point(3, 32);
            this.matchAllRadio.Margin = new System.Windows.Forms.Padding(0);
            this.matchAllRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.matchAllRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.matchAllRadio.Name = "matchAllRadio";
            this.matchAllRadio.Ripple = true;
            this.matchAllRadio.Size = new System.Drawing.Size(214, 37);
            this.matchAllRadio.TabIndex = 2;
            this.matchAllRadio.Text = "Match all current settings";
            this.matchAllRadio.UseVisualStyleBackColor = true;
            this.matchAllRadio.CheckedChanged += new System.EventHandler(this.MatchAllRadio_CheckedChanged);
            this.matchAllRadio.Click += new System.EventHandler(this.RadioButton2_Click);
            // 
            // bestMatchRadio
            // 
            this.bestMatchRadio.AutoSize = true;
            this.bestMatchRadio.Checked = true;
            this.bestMatchRadio.Depth = 0;
            this.bestMatchRadio.Location = new System.Drawing.Point(3, 1);
            this.bestMatchRadio.Margin = new System.Windows.Forms.Padding(0);
            this.bestMatchRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.bestMatchRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.bestMatchRadio.Name = "bestMatchRadio";
            this.bestMatchRadio.Ripple = true;
            this.bestMatchRadio.Size = new System.Drawing.Size(549, 37);
            this.bestMatchRadio.TabIndex = 1;
            this.bestMatchRadio.TabStop = true;
            this.bestMatchRadio.Text = "Use a bluescreen type that matches this system, but match other settings";
            this.bestMatchRadio.UseVisualStyleBackColor = true;
            // 
            // triggerLabel
            // 
            this.triggerLabel.AutoSize = true;
            this.triggerLabel.Depth = 0;
            this.triggerLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.triggerLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.triggerLabel.Location = new System.Drawing.Point(17, 168);
            this.triggerLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.triggerLabel.Name = "triggerLabel";
            this.triggerLabel.Size = new System.Drawing.Size(83, 14);
            this.triggerLabel.TabIndex = 2;
            this.triggerLabel.Text = "Trigger options";
            // 
            // triggerPanel
            // 
            this.triggerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.triggerPanel.Controls.Add(this.usbRadio);
            this.triggerPanel.Controls.Add(this.appRadio);
            this.triggerPanel.Controls.Add(this.timeRadio);
            this.triggerPanel.Location = new System.Drawing.Point(122, 157);
            this.triggerPanel.Name = "triggerPanel";
            this.triggerPanel.Size = new System.Drawing.Size(599, 43);
            this.triggerPanel.TabIndex = 2;
            // 
            // usbRadio
            // 
            this.usbRadio.AutoSize = true;
            this.usbRadio.Depth = 0;
            this.usbRadio.Location = new System.Drawing.Point(217, 3);
            this.usbRadio.Margin = new System.Windows.Forms.Padding(0);
            this.usbRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.usbRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.usbRadio.Name = "usbRadio";
            this.usbRadio.Ripple = true;
            this.usbRadio.Size = new System.Drawing.Size(114, 37);
            this.usbRadio.TabIndex = 3;
            this.usbRadio.Text = "USB device";
            this.usbRadio.UseVisualStyleBackColor = true;
            this.usbRadio.CheckedChanged += new System.EventHandler(this.RadioButton16_CheckedChanged);
            // 
            // appRadio
            // 
            this.appRadio.AutoSize = true;
            this.appRadio.Depth = 0;
            this.appRadio.Location = new System.Drawing.Point(87, 3);
            this.appRadio.Margin = new System.Windows.Forms.Padding(0);
            this.appRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.appRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.appRadio.Name = "appRadio";
            this.appRadio.Ripple = true;
            this.appRadio.Size = new System.Drawing.Size(115, 37);
            this.appRadio.TabIndex = 2;
            this.appRadio.Text = "Application";
            this.appRadio.UseVisualStyleBackColor = true;
            this.appRadio.CheckedChanged += new System.EventHandler(this.RadioButton4_CheckedChanged);
            // 
            // timeRadio
            // 
            this.timeRadio.AutoSize = true;
            this.timeRadio.Checked = true;
            this.timeRadio.Depth = 0;
            this.timeRadio.Location = new System.Drawing.Point(3, 3);
            this.timeRadio.Margin = new System.Windows.Forms.Padding(0);
            this.timeRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.timeRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.timeRadio.Name = "timeRadio";
            this.timeRadio.Ripple = true;
            this.timeRadio.Size = new System.Drawing.Size(76, 37);
            this.timeRadio.TabIndex = 1;
            this.timeRadio.TabStop = true;
            this.timeRadio.Text = "Timer";
            this.timeRadio.UseVisualStyleBackColor = true;
            this.timeRadio.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // triggerFlowPanel
            // 
            this.triggerFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.triggerFlowPanel.Controls.Add(this.timePanel);
            this.triggerFlowPanel.Controls.Add(this.appPanel);
            this.triggerFlowPanel.Controls.Add(this.usbPanel);
            this.triggerFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.triggerFlowPanel.Location = new System.Drawing.Point(20, 196);
            this.triggerFlowPanel.Name = "triggerFlowPanel";
            this.triggerFlowPanel.Size = new System.Drawing.Size(701, 76);
            this.triggerFlowPanel.TabIndex = 4;
            // 
            // timePanel
            // 
            this.timePanel.Controls.Add(this.timerBox);
            this.timePanel.Controls.Add(this.timeFormatLabel);
            this.timePanel.Location = new System.Drawing.Point(3, 3);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(173, 62);
            this.timePanel.TabIndex = 1;
            // 
            // timerBox
            // 
            this.timerBox.AllowPromptAsInput = true;
            this.timerBox.AnimateReadOnly = false;
            this.timerBox.AsciiOnly = false;
            this.timerBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.timerBox.BeepOnError = false;
            this.timerBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.timerBox.Depth = 0;
            this.timerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.timerBox.HidePromptOnLeave = false;
            this.timerBox.HideSelection = true;
            this.timerBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.timerBox.LeadingIcon = null;
            this.timerBox.Location = new System.Drawing.Point(6, 20);
            this.timerBox.Mask = "##:##:##";
            this.timerBox.MaxLength = 32767;
            this.timerBox.MouseState = MaterialSkin.MouseState.OUT;
            this.timerBox.Name = "timerBox";
            this.timerBox.PasswordChar = '\0';
            this.timerBox.PrefixSuffixText = null;
            this.timerBox.PromptChar = '_';
            this.timerBox.ReadOnly = false;
            this.timerBox.RejectInputOnFirstFailure = false;
            this.timerBox.ResetOnPrompt = true;
            this.timerBox.ResetOnSpace = true;
            this.timerBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timerBox.SelectedText = "";
            this.timerBox.SelectionLength = 0;
            this.timerBox.SelectionStart = 8;
            this.timerBox.ShortcutsEnabled = true;
            this.timerBox.Size = new System.Drawing.Size(105, 36);
            this.timerBox.SkipLiterals = true;
            this.timerBox.TabIndex = 4;
            this.timerBox.TabStop = false;
            this.timerBox.Text = "00:05:00";
            this.timerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.timerBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.timerBox.TrailingIcon = null;
            this.timerBox.UseSystemPasswordChar = false;
            this.timerBox.UseTallSize = false;
            this.timerBox.ValidatingType = null;
            this.timerBox.TextChanged += new System.EventHandler(this.MaskedTextBox1_TextChanged);
            // 
            // timeFormatLabel
            // 
            this.timeFormatLabel.AutoSize = true;
            this.timeFormatLabel.Depth = 0;
            this.timeFormatLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.timeFormatLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.timeFormatLabel.Location = new System.Drawing.Point(3, 4);
            this.timeFormatLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.timeFormatLabel.Name = "timeFormatLabel";
            this.timeFormatLabel.Size = new System.Drawing.Size(157, 14);
            this.timeFormatLabel.TabIndex = 5;
            this.timeFormatLabel.Text = "Timer (format hrs:mins:secs)";
            // 
            // appPanel
            // 
            this.appPanel.Controls.Add(this.triggerAppLabel);
            this.appPanel.Controls.Add(this.triggerAppBox);
            this.appPanel.Location = new System.Drawing.Point(182, 3);
            this.appPanel.Name = "appPanel";
            this.appPanel.Size = new System.Drawing.Size(286, 62);
            this.appPanel.TabIndex = 2;
            this.appPanel.Visible = false;
            // 
            // triggerAppLabel
            // 
            this.triggerAppLabel.AutoSize = true;
            this.triggerAppLabel.Depth = 0;
            this.triggerAppLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.triggerAppLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.triggerAppLabel.Location = new System.Drawing.Point(3, 4);
            this.triggerAppLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.triggerAppLabel.Name = "triggerAppLabel";
            this.triggerAppLabel.Size = new System.Drawing.Size(296, 14);
            this.triggerAppLabel.TabIndex = 3;
            this.triggerAppLabel.Text = "Process name (ie notepad.exe, iexplore.exe, sol.exe etc)";
            // 
            // triggerAppBox
            // 
            this.triggerAppBox.AnimateReadOnly = false;
            this.triggerAppBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.triggerAppBox.Depth = 0;
            this.triggerAppBox.Enabled = false;
            this.triggerAppBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.triggerAppBox.LeadingIcon = null;
            this.triggerAppBox.Location = new System.Drawing.Point(6, 20);
            this.triggerAppBox.MaxLength = 50;
            this.triggerAppBox.MouseState = MaterialSkin.MouseState.OUT;
            this.triggerAppBox.Multiline = false;
            this.triggerAppBox.Name = "triggerAppBox";
            this.triggerAppBox.Size = new System.Drawing.Size(193, 36);
            this.triggerAppBox.TabIndex = 2;
            this.triggerAppBox.Text = "notepad.exe";
            this.triggerAppBox.TrailingIcon = null;
            this.triggerAppBox.UseTallSize = false;
            // 
            // usbPanel
            // 
            this.usbPanel.Controls.Add(this.whyNoDeviceButton);
            this.usbPanel.Controls.Add(this.resetDeviceButton);
            this.usbPanel.Controls.Add(this.deviceInfoLabel);
            this.usbPanel.Location = new System.Drawing.Point(474, 3);
            this.usbPanel.Name = "usbPanel";
            this.usbPanel.Size = new System.Drawing.Size(333, 73);
            this.usbPanel.TabIndex = 3;
            this.usbPanel.Visible = false;
            // 
            // whyNoDeviceButton
            // 
            this.whyNoDeviceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.whyNoDeviceButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.whyNoDeviceButton.Depth = 0;
            this.whyNoDeviceButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.whyNoDeviceButton.HighEmphasis = true;
            this.whyNoDeviceButton.Icon = null;
            this.whyNoDeviceButton.Location = new System.Drawing.Point(87, 32);
            this.whyNoDeviceButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.whyNoDeviceButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.whyNoDeviceButton.Name = "whyNoDeviceButton";
            this.whyNoDeviceButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.whyNoDeviceButton.Size = new System.Drawing.Size(211, 36);
            this.whyNoDeviceButton.TabIndex = 2;
            this.whyNoDeviceButton.Text = "My device isn\'t detected";
            this.whyNoDeviceButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.whyNoDeviceButton.UseAccentColor = false;
            this.whyNoDeviceButton.UseVisualStyleBackColor = true;
            this.whyNoDeviceButton.Click += new System.EventHandler(this.Button5_Click);
            // 
            // resetDeviceButton
            // 
            this.resetDeviceButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetDeviceButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.resetDeviceButton.Depth = 0;
            this.resetDeviceButton.Enabled = false;
            this.resetDeviceButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resetDeviceButton.HighEmphasis = true;
            this.resetDeviceButton.Icon = null;
            this.resetDeviceButton.Location = new System.Drawing.Point(6, 32);
            this.resetDeviceButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.resetDeviceButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.resetDeviceButton.Name = "resetDeviceButton";
            this.resetDeviceButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.resetDeviceButton.Size = new System.Drawing.Size(65, 36);
            this.resetDeviceButton.TabIndex = 1;
            this.resetDeviceButton.Text = "Reset";
            this.resetDeviceButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.resetDeviceButton.UseAccentColor = false;
            this.resetDeviceButton.UseVisualStyleBackColor = true;
            this.resetDeviceButton.Click += new System.EventHandler(this.Button4_Click);
            // 
            // deviceInfoLabel
            // 
            this.deviceInfoLabel.Depth = 0;
            this.deviceInfoLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.deviceInfoLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.deviceInfoLabel.Location = new System.Drawing.Point(3, 0);
            this.deviceInfoLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.deviceInfoLabel.Name = "deviceInfoLabel";
            this.deviceInfoLabel.Size = new System.Drawing.Size(327, 34);
            this.deviceInfoLabel.TabIndex = 8;
            this.deviceInfoLabel.Text = "No trigger device\r\n(Unplug and) plug in desired trigger device";
            // 
            // letCloseBox
            // 
            this.letCloseBox.AutoSize = true;
            this.letCloseBox.Checked = true;
            this.letCloseBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.letCloseBox.Depth = 0;
            this.letCloseBox.Location = new System.Drawing.Point(17, 288);
            this.letCloseBox.Margin = new System.Windows.Forms.Padding(0);
            this.letCloseBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.letCloseBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.letCloseBox.Name = "letCloseBox";
            this.letCloseBox.ReadOnly = false;
            this.letCloseBox.Ripple = true;
            this.letCloseBox.Size = new System.Drawing.Size(406, 37);
            this.letCloseBox.TabIndex = 3;
            this.letCloseBox.Text = "Allow the user to close the blue screen using ALT+F4";
            this.letCloseBox.UseVisualStyleBackColor = true;
            this.letCloseBox.CheckedChanged += new System.EventHandler(this.LetCloseBox_CheckedChanged);
            // 
            // miscLabel
            // 
            this.miscLabel.AutoSize = true;
            this.miscLabel.Depth = 0;
            this.miscLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.miscLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.miscLabel.Location = new System.Drawing.Point(17, 275);
            this.miscLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.miscLabel.Name = "miscLabel";
            this.miscLabel.Size = new System.Drawing.Size(119, 14);
            this.miscLabel.TabIndex = 5;
            this.miscLabel.Text = "Miscelaneous options";
            // 
            // friendlyMessageBox
            // 
            this.friendlyMessageBox.AutoSize = true;
            this.friendlyMessageBox.Depth = 0;
            this.friendlyMessageBox.Location = new System.Drawing.Point(17, 320);
            this.friendlyMessageBox.Margin = new System.Windows.Forms.Padding(0);
            this.friendlyMessageBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.friendlyMessageBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.friendlyMessageBox.Name = "friendlyMessageBox";
            this.friendlyMessageBox.ReadOnly = false;
            this.friendlyMessageBox.Ripple = true;
            this.friendlyMessageBox.Size = new System.Drawing.Size(408, 37);
            this.friendlyMessageBox.TabIndex = 4;
            this.friendlyMessageBox.Text = "Show a message after the bluescreen is being closed";
            this.friendlyMessageBox.UseVisualStyleBackColor = true;
            this.friendlyMessageBox.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // friendlyMessageContentsBox
            // 
            this.friendlyMessageContentsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyMessageContentsBox.AnimateReadOnly = false;
            this.friendlyMessageContentsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendlyMessageContentsBox.Depth = 0;
            this.friendlyMessageContentsBox.Enabled = false;
            this.friendlyMessageContentsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.friendlyMessageContentsBox.LeadingIcon = null;
            this.friendlyMessageContentsBox.Location = new System.Drawing.Point(17, 358);
            this.friendlyMessageContentsBox.MaxLength = 50;
            this.friendlyMessageContentsBox.MouseState = MaterialSkin.MouseState.OUT;
            this.friendlyMessageContentsBox.Multiline = false;
            this.friendlyMessageContentsBox.Name = "friendlyMessageContentsBox";
            this.friendlyMessageContentsBox.Size = new System.Drawing.Size(704, 36);
            this.friendlyMessageContentsBox.TabIndex = 6;
            this.friendlyMessageContentsBox.Text = "Enter a message here.";
            this.friendlyMessageContentsBox.TrailingIcon = null;
            this.friendlyMessageContentsBox.UseTallSize = false;
            this.friendlyMessageContentsBox.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // friendlyMessageTitleLabel
            // 
            this.friendlyMessageTitleLabel.AutoSize = true;
            this.friendlyMessageTitleLabel.Depth = 0;
            this.friendlyMessageTitleLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.friendlyMessageTitleLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.friendlyMessageTitleLabel.Location = new System.Drawing.Point(17, 409);
            this.friendlyMessageTitleLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.friendlyMessageTitleLabel.Name = "friendlyMessageTitleLabel";
            this.friendlyMessageTitleLabel.Size = new System.Drawing.Size(72, 14);
            this.friendlyMessageTitleLabel.TabIndex = 9;
            this.friendlyMessageTitleLabel.Text = "Message title";
            // 
            // friendlyMessageTitleBox
            // 
            this.friendlyMessageTitleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyMessageTitleBox.AnimateReadOnly = false;
            this.friendlyMessageTitleBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendlyMessageTitleBox.Depth = 0;
            this.friendlyMessageTitleBox.Enabled = false;
            this.friendlyMessageTitleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.friendlyMessageTitleBox.LeadingIcon = null;
            this.friendlyMessageTitleBox.Location = new System.Drawing.Point(92, 398);
            this.friendlyMessageTitleBox.MaxLength = 50;
            this.friendlyMessageTitleBox.MouseState = MaterialSkin.MouseState.OUT;
            this.friendlyMessageTitleBox.Multiline = false;
            this.friendlyMessageTitleBox.Name = "friendlyMessageTitleBox";
            this.friendlyMessageTitleBox.Size = new System.Drawing.Size(629, 36);
            this.friendlyMessageTitleBox.TabIndex = 7;
            this.friendlyMessageTitleBox.Text = "Enter a title here";
            this.friendlyMessageTitleBox.TrailingIcon = null;
            this.friendlyMessageTitleBox.UseTallSize = false;
            this.friendlyMessageTitleBox.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // friendlyMessageIconPanel
            // 
            this.friendlyMessageIconPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyMessageIconPanel.Controls.Add(this.errorRadio);
            this.friendlyMessageIconPanel.Controls.Add(this.warningRadio);
            this.friendlyMessageIconPanel.Controls.Add(this.questionRadio);
            this.friendlyMessageIconPanel.Controls.Add(this.infoRadio);
            this.friendlyMessageIconPanel.Controls.Add(this.noneRadio);
            this.friendlyMessageIconPanel.Enabled = false;
            this.friendlyMessageIconPanel.Location = new System.Drawing.Point(17, 445);
            this.friendlyMessageIconPanel.Name = "friendlyMessageIconPanel";
            this.friendlyMessageIconPanel.Size = new System.Drawing.Size(704, 43);
            this.friendlyMessageIconPanel.TabIndex = 8;
            // 
            // errorRadio
            // 
            this.errorRadio.AutoSize = true;
            this.errorRadio.Depth = 0;
            this.errorRadio.Location = new System.Drawing.Point(0, 0);
            this.errorRadio.Margin = new System.Windows.Forms.Padding(0);
            this.errorRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.errorRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.errorRadio.Name = "errorRadio";
            this.errorRadio.Ripple = true;
            this.errorRadio.Size = new System.Drawing.Size(161, 37);
            this.errorRadio.TabIndex = 0;
            this.errorRadio.Text = "Error/Critical Stop";
            this.errorRadio.UseVisualStyleBackColor = true;
            this.errorRadio.CheckedChanged += new System.EventHandler(this.RadioButton5_CheckedChanged);
            // 
            // warningRadio
            // 
            this.warningRadio.AutoSize = true;
            this.warningRadio.Checked = true;
            this.warningRadio.Depth = 0;
            this.warningRadio.Location = new System.Drawing.Point(161, 0);
            this.warningRadio.Margin = new System.Windows.Forms.Padding(0);
            this.warningRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.warningRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.warningRadio.Name = "warningRadio";
            this.warningRadio.Ripple = true;
            this.warningRadio.Size = new System.Drawing.Size(189, 37);
            this.warningRadio.TabIndex = 1;
            this.warningRadio.TabStop = true;
            this.warningRadio.Text = "Warning/Exclamation";
            this.warningRadio.UseVisualStyleBackColor = true;
            this.warningRadio.CheckedChanged += new System.EventHandler(this.RadioButton6_CheckedChanged);
            // 
            // questionRadio
            // 
            this.questionRadio.AutoSize = true;
            this.questionRadio.Depth = 0;
            this.questionRadio.Location = new System.Drawing.Point(350, 0);
            this.questionRadio.Margin = new System.Windows.Forms.Padding(0);
            this.questionRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.questionRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.questionRadio.Name = "questionRadio";
            this.questionRadio.Ripple = true;
            this.questionRadio.Size = new System.Drawing.Size(137, 37);
            this.questionRadio.TabIndex = 2;
            this.questionRadio.Text = "Question/Help";
            this.questionRadio.UseVisualStyleBackColor = true;
            this.questionRadio.CheckedChanged += new System.EventHandler(this.RadioButton7_CheckedChanged);
            // 
            // infoRadio
            // 
            this.infoRadio.AutoSize = true;
            this.infoRadio.Depth = 0;
            this.infoRadio.Location = new System.Drawing.Point(487, 0);
            this.infoRadio.Margin = new System.Windows.Forms.Padding(0);
            this.infoRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.infoRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.infoRadio.Name = "infoRadio";
            this.infoRadio.Ripple = true;
            this.infoRadio.Size = new System.Drawing.Size(118, 37);
            this.infoRadio.TabIndex = 3;
            this.infoRadio.Text = "Information";
            this.infoRadio.UseVisualStyleBackColor = true;
            this.infoRadio.CheckedChanged += new System.EventHandler(this.RadioButton8_CheckedChanged);
            // 
            // noneRadio
            // 
            this.noneRadio.AutoSize = true;
            this.noneRadio.Depth = 0;
            this.noneRadio.Location = new System.Drawing.Point(605, 0);
            this.noneRadio.Margin = new System.Windows.Forms.Padding(0);
            this.noneRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.noneRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.noneRadio.Name = "noneRadio";
            this.noneRadio.Ripple = true;
            this.noneRadio.Size = new System.Drawing.Size(89, 37);
            this.noneRadio.TabIndex = 4;
            this.noneRadio.Text = "No icon";
            this.noneRadio.UseVisualStyleBackColor = true;
            this.noneRadio.CheckedChanged += new System.EventHandler(this.RadioButton9_CheckedChanged);
            // 
            // friendlyMessageIconLabel
            // 
            this.friendlyMessageIconLabel.AutoSize = true;
            this.friendlyMessageIconLabel.Depth = 0;
            this.friendlyMessageIconLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.friendlyMessageIconLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.friendlyMessageIconLabel.Location = new System.Drawing.Point(17, 432);
            this.friendlyMessageIconLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.friendlyMessageIconLabel.Name = "friendlyMessageIconLabel";
            this.friendlyMessageIconLabel.Size = new System.Drawing.Size(75, 14);
            this.friendlyMessageIconLabel.TabIndex = 12;
            this.friendlyMessageIconLabel.Text = "Message icon";
            // 
            // friendlyMessageButtonsLabel
            // 
            this.friendlyMessageButtonsLabel.AutoSize = true;
            this.friendlyMessageButtonsLabel.Depth = 0;
            this.friendlyMessageButtonsLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.friendlyMessageButtonsLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.friendlyMessageButtonsLabel.Location = new System.Drawing.Point(17, 491);
            this.friendlyMessageButtonsLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.friendlyMessageButtonsLabel.Name = "friendlyMessageButtonsLabel";
            this.friendlyMessageButtonsLabel.Size = new System.Drawing.Size(94, 14);
            this.friendlyMessageButtonsLabel.TabIndex = 14;
            this.friendlyMessageButtonsLabel.Text = "Message buttons";
            // 
            // friendlyMessageButtonsPanel
            // 
            this.friendlyMessageButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyMessageButtonsPanel.Controls.Add(this.okRadio);
            this.friendlyMessageButtonsPanel.Controls.Add(this.okCancelRadio);
            this.friendlyMessageButtonsPanel.Controls.Add(this.retryIgnoreAboutRadio);
            this.friendlyMessageButtonsPanel.Controls.Add(this.retryCancelRadio);
            this.friendlyMessageButtonsPanel.Controls.Add(this.yesNoRadio);
            this.friendlyMessageButtonsPanel.Controls.Add(this.yesNoCancelRadio);
            this.friendlyMessageButtonsPanel.Enabled = false;
            this.friendlyMessageButtonsPanel.Location = new System.Drawing.Point(17, 510);
            this.friendlyMessageButtonsPanel.Name = "friendlyMessageButtonsPanel";
            this.friendlyMessageButtonsPanel.Size = new System.Drawing.Size(704, 40);
            this.friendlyMessageButtonsPanel.TabIndex = 9;
            // 
            // okRadio
            // 
            this.okRadio.AutoSize = true;
            this.okRadio.Checked = true;
            this.okRadio.Depth = 0;
            this.okRadio.Location = new System.Drawing.Point(0, 0);
            this.okRadio.Margin = new System.Windows.Forms.Padding(0);
            this.okRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.okRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.okRadio.Name = "okRadio";
            this.okRadio.Ripple = true;
            this.okRadio.Size = new System.Drawing.Size(56, 37);
            this.okRadio.TabIndex = 0;
            this.okRadio.TabStop = true;
            this.okRadio.Text = "OK";
            this.okRadio.UseVisualStyleBackColor = true;
            this.okRadio.CheckedChanged += new System.EventHandler(this.RadioButton10_CheckedChanged);
            // 
            // okCancelRadio
            // 
            this.okCancelRadio.AutoSize = true;
            this.okCancelRadio.Depth = 0;
            this.okCancelRadio.Location = new System.Drawing.Point(56, 0);
            this.okCancelRadio.Margin = new System.Windows.Forms.Padding(0);
            this.okCancelRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.okCancelRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.okCancelRadio.Name = "okCancelRadio";
            this.okCancelRadio.Ripple = true;
            this.okCancelRadio.Size = new System.Drawing.Size(111, 37);
            this.okCancelRadio.TabIndex = 1;
            this.okCancelRadio.Text = "OK/Cancel";
            this.okCancelRadio.UseVisualStyleBackColor = true;
            this.okCancelRadio.CheckedChanged += new System.EventHandler(this.RadioButton11_CheckedChanged);
            // 
            // retryIgnoreAboutRadio
            // 
            this.retryIgnoreAboutRadio.AutoSize = true;
            this.retryIgnoreAboutRadio.Depth = 0;
            this.retryIgnoreAboutRadio.Location = new System.Drawing.Point(167, 0);
            this.retryIgnoreAboutRadio.Margin = new System.Windows.Forms.Padding(0);
            this.retryIgnoreAboutRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.retryIgnoreAboutRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.retryIgnoreAboutRadio.Name = "retryIgnoreAboutRadio";
            this.retryIgnoreAboutRadio.Ripple = true;
            this.retryIgnoreAboutRadio.Size = new System.Drawing.Size(167, 37);
            this.retryIgnoreAboutRadio.TabIndex = 2;
            this.retryIgnoreAboutRadio.Text = "Retry/Ignore/Abort";
            this.retryIgnoreAboutRadio.UseVisualStyleBackColor = true;
            this.retryIgnoreAboutRadio.CheckedChanged += new System.EventHandler(this.RadioButton12_CheckedChanged);
            // 
            // retryCancelRadio
            // 
            this.retryCancelRadio.AutoSize = true;
            this.retryCancelRadio.Depth = 0;
            this.retryCancelRadio.Location = new System.Drawing.Point(334, 0);
            this.retryCancelRadio.Margin = new System.Windows.Forms.Padding(0);
            this.retryCancelRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.retryCancelRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.retryCancelRadio.Name = "retryCancelRadio";
            this.retryCancelRadio.Ripple = true;
            this.retryCancelRadio.Size = new System.Drawing.Size(126, 37);
            this.retryCancelRadio.TabIndex = 3;
            this.retryCancelRadio.Text = "Retry/Cancel";
            this.retryCancelRadio.UseVisualStyleBackColor = true;
            this.retryCancelRadio.CheckedChanged += new System.EventHandler(this.RadioButton15_CheckedChanged);
            // 
            // yesNoRadio
            // 
            this.yesNoRadio.AutoSize = true;
            this.yesNoRadio.Depth = 0;
            this.yesNoRadio.Location = new System.Drawing.Point(460, 0);
            this.yesNoRadio.Margin = new System.Windows.Forms.Padding(0);
            this.yesNoRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.yesNoRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.yesNoRadio.Name = "yesNoRadio";
            this.yesNoRadio.Ripple = true;
            this.yesNoRadio.Size = new System.Drawing.Size(88, 37);
            this.yesNoRadio.TabIndex = 4;
            this.yesNoRadio.Text = "Yes/No";
            this.yesNoRadio.UseVisualStyleBackColor = true;
            this.yesNoRadio.CheckedChanged += new System.EventHandler(this.RadioButton13_CheckedChanged);
            // 
            // yesNoCancelRadio
            // 
            this.yesNoCancelRadio.AutoSize = true;
            this.yesNoCancelRadio.Depth = 0;
            this.yesNoCancelRadio.Location = new System.Drawing.Point(548, 0);
            this.yesNoCancelRadio.Margin = new System.Windows.Forms.Padding(0);
            this.yesNoCancelRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.yesNoCancelRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.yesNoCancelRadio.Name = "yesNoCancelRadio";
            this.yesNoCancelRadio.Ripple = true;
            this.yesNoCancelRadio.Size = new System.Drawing.Size(143, 37);
            this.yesNoCancelRadio.TabIndex = 5;
            this.yesNoCancelRadio.Text = "Yes/No/Cancel";
            this.yesNoCancelRadio.UseVisualStyleBackColor = true;
            this.yesNoCancelRadio.CheckedChanged += new System.EventHandler(this.RadioButton14_CheckedChanged);
            // 
            // previewFriendlyMessageButton
            // 
            this.previewFriendlyMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previewFriendlyMessageButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.previewFriendlyMessageButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.previewFriendlyMessageButton.Depth = 0;
            this.previewFriendlyMessageButton.Enabled = false;
            this.previewFriendlyMessageButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.previewFriendlyMessageButton.HighEmphasis = true;
            this.previewFriendlyMessageButton.Icon = null;
            this.previewFriendlyMessageButton.Location = new System.Drawing.Point(567, 313);
            this.previewFriendlyMessageButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.previewFriendlyMessageButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.previewFriendlyMessageButton.Name = "previewFriendlyMessageButton";
            this.previewFriendlyMessageButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.previewFriendlyMessageButton.Size = new System.Drawing.Size(154, 36);
            this.previewFriendlyMessageButton.TabIndex = 5;
            this.previewFriendlyMessageButton.Text = "Preview message";
            this.previewFriendlyMessageButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.previewFriendlyMessageButton.UseAccentColor = false;
            this.previewFriendlyMessageButton.UseVisualStyleBackColor = true;
            this.previewFriendlyMessageButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.okButton.Depth = 0;
            this.okButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.okButton.HighEmphasis = true;
            this.okButton.Icon = null;
            this.okButton.Location = new System.Drawing.Point(657, 555);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.okButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.okButton.Name = "okButton";
            this.okButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.okButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.okButton.Size = new System.Drawing.Size(64, 36);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "O&K";
            this.okButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.okButton.UseAccentColor = false;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.cancelButton.Depth = 0;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cancelButton.HighEmphasis = true;
            this.cancelButton.Icon = null;
            this.cancelButton.Location = new System.Drawing.Point(553, 555);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cancelButton.Size = new System.Drawing.Size(87, 36);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.cancelButton.UseAccentColor = false;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Button3_Click);
            // 
            // usbFinder
            // 
            this.usbFinder.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // closePrank
            // 
            this.closePrank.AutoSize = true;
            this.closePrank.Checked = true;
            this.closePrank.CheckState = System.Windows.Forms.CheckState.Checked;
            this.closePrank.Depth = 0;
            this.closePrank.Location = new System.Drawing.Point(17, 556);
            this.closePrank.Margin = new System.Windows.Forms.Padding(0);
            this.closePrank.MouseLocation = new System.Drawing.Point(-1, -1);
            this.closePrank.MouseState = MaterialSkin.MouseState.HOVER;
            this.closePrank.Name = "closePrank";
            this.closePrank.ReadOnly = false;
            this.closePrank.Ripple = true;
            this.closePrank.Size = new System.Drawing.Size(269, 37);
            this.closePrank.TabIndex = 15;
            this.closePrank.Text = "Re-open after ending prank mode";
            this.closePrank.UseVisualStyleBackColor = true;
            this.closePrank.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PrankMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(739, 600);
            this.Controls.Add(this.closePrank);
            this.Controls.Add(this.triggerFlowPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.previewFriendlyMessageButton);
            this.Controls.Add(this.friendlyMessageIconLabel);
            this.Controls.Add(this.friendlyMessageIconPanel);
            this.Controls.Add(this.friendlyMessageTitleBox);
            this.Controls.Add(this.friendlyMessageTitleLabel);
            this.Controls.Add(this.friendlyMessageContentsBox);
            this.Controls.Add(this.friendlyMessageButtonsLabel);
            this.Controls.Add(this.friendlyMessageBox);
            this.Controls.Add(this.friendlyMessageButtonsPanel);
            this.Controls.Add(this.miscLabel);
            this.Controls.Add(this.letCloseBox);
            this.Controls.Add(this.triggerPanel);
            this.Controls.Add(this.triggerLabel);
            this.Controls.Add(this.bluescreenTypePanel);
            this.Controls.Add(this.bluescreenTypeLabel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(739, 600);
            this.Name = "PrankMode";
            this.Text = "Prank mode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrankMode_FormClosing);
            this.Load += new System.EventHandler(this.PrankMode_Load);
            this.bluescreenTypePanel.ResumeLayout(false);
            this.bluescreenTypePanel.PerformLayout();
            this.triggerPanel.ResumeLayout(false);
            this.triggerPanel.PerformLayout();
            this.triggerFlowPanel.ResumeLayout(false);
            this.timePanel.ResumeLayout(false);
            this.timePanel.PerformLayout();
            this.appPanel.ResumeLayout(false);
            this.appPanel.PerformLayout();
            this.usbPanel.ResumeLayout(false);
            this.usbPanel.PerformLayout();
            this.friendlyMessageIconPanel.ResumeLayout(false);
            this.friendlyMessageIconPanel.PerformLayout();
            this.friendlyMessageButtonsPanel.ResumeLayout(false);
            this.friendlyMessageButtonsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel bluescreenTypeLabel;
        private System.Windows.Forms.Panel bluescreenTypePanel;
        private MaterialSkin.Controls.MaterialRadioButton matchAllRadio;
        private MaterialSkin.Controls.MaterialRadioButton bestMatchRadio;
        private MaterialSkin.Controls.MaterialLabel triggerLabel;
        private System.Windows.Forms.Panel triggerPanel;
        private MaterialSkin.Controls.MaterialLabel timeFormatLabel;
        private MaterialSkin.Controls.MaterialMaskedTextBox timerBox;
        private MaterialSkin.Controls.MaterialLabel triggerAppLabel;
        private MaterialSkin.Controls.MaterialTextBox triggerAppBox;
        private MaterialSkin.Controls.MaterialRadioButton appRadio;
        private MaterialSkin.Controls.MaterialRadioButton timeRadio;
        private MaterialSkin.Controls.MaterialCheckbox letCloseBox;
        private MaterialSkin.Controls.MaterialLabel miscLabel;
        private MaterialSkin.Controls.MaterialCheckbox friendlyMessageBox;
        private MaterialSkin.Controls.MaterialTextBox friendlyMessageContentsBox;
        private MaterialSkin.Controls.MaterialLabel friendlyMessageTitleLabel;
        private MaterialSkin.Controls.MaterialTextBox friendlyMessageTitleBox;
        private System.Windows.Forms.FlowLayoutPanel friendlyMessageIconPanel;
        private MaterialSkin.Controls.MaterialRadioButton errorRadio;
        private MaterialSkin.Controls.MaterialRadioButton warningRadio;
        private MaterialSkin.Controls.MaterialRadioButton questionRadio;
        private MaterialSkin.Controls.MaterialRadioButton infoRadio;
        private MaterialSkin.Controls.MaterialRadioButton noneRadio;
        private MaterialSkin.Controls.MaterialLabel friendlyMessageIconLabel;
        private MaterialSkin.Controls.MaterialLabel friendlyMessageButtonsLabel;
        private System.Windows.Forms.FlowLayoutPanel friendlyMessageButtonsPanel;
        private MaterialSkin.Controls.MaterialRadioButton okRadio;
        private MaterialSkin.Controls.MaterialRadioButton okCancelRadio;
        private MaterialSkin.Controls.MaterialRadioButton retryIgnoreAboutRadio;
        private MaterialSkin.Controls.MaterialRadioButton yesNoRadio;
        private MaterialSkin.Controls.MaterialRadioButton yesNoCancelRadio;
        private System.Windows.Forms.FlowLayoutPanel triggerFlowPanel;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Panel appPanel;
        private MaterialSkin.Controls.MaterialButton previewFriendlyMessageButton;
        private MaterialSkin.Controls.MaterialButton okButton;
        private MaterialSkin.Controls.MaterialButton cancelButton;
        private MaterialSkin.Controls.MaterialRadioButton retryCancelRadio;
        private MaterialSkin.Controls.MaterialRadioButton usbRadio;
        private System.Windows.Forms.Panel usbPanel;
        private MaterialSkin.Controls.MaterialButton resetDeviceButton;
        private MaterialSkin.Controls.MaterialLabel deviceInfoLabel;
        private System.Windows.Forms.Timer usbFinder;
        private MaterialSkin.Controls.MaterialButton whyNoDeviceButton;
        private MaterialSkin.Controls.MaterialCheckbox closePrank;
    }
}