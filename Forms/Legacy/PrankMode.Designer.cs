namespace UltimateBlueScreenSimulator.Forms.Legacy
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
            this.bluescreenTypeLabel = new System.Windows.Forms.Label();
            this.bluescreenTypePanel = new System.Windows.Forms.Panel();
            this.matchAllRadio = new System.Windows.Forms.RadioButton();
            this.bestMatchRadio = new System.Windows.Forms.RadioButton();
            this.triggerLabel = new System.Windows.Forms.Label();
            this.triggerPanel = new System.Windows.Forms.Panel();
            this.usbRadio = new System.Windows.Forms.RadioButton();
            this.triggerFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.timePanel = new System.Windows.Forms.Panel();
            this.timerBox = new System.Windows.Forms.MaskedTextBox();
            this.timeFormatLabel = new System.Windows.Forms.Label();
            this.appPanel = new System.Windows.Forms.Panel();
            this.triggerAppLabel = new System.Windows.Forms.Label();
            this.triggerAppBox = new System.Windows.Forms.TextBox();
            this.usbPanel = new System.Windows.Forms.Panel();
            this.whyNoDeviceButton = new System.Windows.Forms.Button();
            this.resetDeviceButton = new System.Windows.Forms.Button();
            this.deviceInfoLabel = new System.Windows.Forms.Label();
            this.appRadio = new System.Windows.Forms.RadioButton();
            this.timeRadio = new System.Windows.Forms.RadioButton();
            this.letCloseBox = new System.Windows.Forms.CheckBox();
            this.miscLabel = new System.Windows.Forms.Label();
            this.friendlyMessageBox = new System.Windows.Forms.CheckBox();
            this.friendlyMessageContentsBox = new System.Windows.Forms.TextBox();
            this.friendlyMessageTitleLabel = new System.Windows.Forms.Label();
            this.friendlyMessageTitleBox = new System.Windows.Forms.TextBox();
            this.friendlyMessageIconPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.errorRadio = new System.Windows.Forms.RadioButton();
            this.warningRadio = new System.Windows.Forms.RadioButton();
            this.questionRadio = new System.Windows.Forms.RadioButton();
            this.infoRadio = new System.Windows.Forms.RadioButton();
            this.noneRadio = new System.Windows.Forms.RadioButton();
            this.friendlyMessageIconLabel = new System.Windows.Forms.Label();
            this.friendlyMessageButtonsLabel = new System.Windows.Forms.Label();
            this.friendlyMessageButtonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.okRadio = new System.Windows.Forms.RadioButton();
            this.okCancelRadio = new System.Windows.Forms.RadioButton();
            this.retryIgnoreAboutRadio = new System.Windows.Forms.RadioButton();
            this.retryCancelRadio = new System.Windows.Forms.RadioButton();
            this.yesNoRadio = new System.Windows.Forms.RadioButton();
            this.yesNoCancelRadio = new System.Windows.Forms.RadioButton();
            this.previewFriendlyMessageButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.usbFinder = new System.Windows.Forms.Timer(this.components);
            this.closePrank = new System.Windows.Forms.CheckBox();
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
            this.bluescreenTypeLabel.Location = new System.Drawing.Point(12, 21);
            this.bluescreenTypeLabel.Name = "bluescreenTypeLabel";
            this.bluescreenTypeLabel.Size = new System.Drawing.Size(97, 13);
            this.bluescreenTypeLabel.TabIndex = 0;
            this.bluescreenTypeLabel.Text = "Bluescreen options";
            // 
            // bluescreenTypePanel
            // 
            this.bluescreenTypePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bluescreenTypePanel.Controls.Add(this.matchAllRadio);
            this.bluescreenTypePanel.Controls.Add(this.bestMatchRadio);
            this.bluescreenTypePanel.Location = new System.Drawing.Point(12, 37);
            this.bluescreenTypePanel.Name = "bluescreenTypePanel";
            this.bluescreenTypePanel.Size = new System.Drawing.Size(520, 56);
            this.bluescreenTypePanel.TabIndex = 1;
            // 
            // matchAllRadio
            // 
            this.matchAllRadio.AutoSize = true;
            this.matchAllRadio.Location = new System.Drawing.Point(3, 30);
            this.matchAllRadio.Name = "matchAllRadio";
            this.matchAllRadio.Size = new System.Drawing.Size(143, 17);
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
            this.bestMatchRadio.Location = new System.Drawing.Point(3, 7);
            this.bestMatchRadio.Name = "bestMatchRadio";
            this.bestMatchRadio.Size = new System.Drawing.Size(368, 17);
            this.bestMatchRadio.TabIndex = 1;
            this.bestMatchRadio.TabStop = true;
            this.bestMatchRadio.Text = "Use a bluescreen type that matches this system, but match other settings";
            this.bestMatchRadio.UseVisualStyleBackColor = true;
            // 
            // triggerLabel
            // 
            this.triggerLabel.AutoSize = true;
            this.triggerLabel.Location = new System.Drawing.Point(12, 96);
            this.triggerLabel.Name = "triggerLabel";
            this.triggerLabel.Size = new System.Drawing.Size(77, 13);
            this.triggerLabel.TabIndex = 2;
            this.triggerLabel.Text = "Trigger options";
            // 
            // triggerPanel
            // 
            this.triggerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.triggerPanel.Controls.Add(this.usbRadio);
            this.triggerPanel.Controls.Add(this.triggerFlowPanel);
            this.triggerPanel.Controls.Add(this.appRadio);
            this.triggerPanel.Controls.Add(this.timeRadio);
            this.triggerPanel.Location = new System.Drawing.Point(12, 112);
            this.triggerPanel.Name = "triggerPanel";
            this.triggerPanel.Size = new System.Drawing.Size(520, 81);
            this.triggerPanel.TabIndex = 2;
            // 
            // usbRadio
            // 
            this.usbRadio.AutoSize = true;
            this.usbRadio.Location = new System.Drawing.Point(143, 3);
            this.usbRadio.Name = "usbRadio";
            this.usbRadio.Size = new System.Drawing.Size(82, 17);
            this.usbRadio.TabIndex = 3;
            this.usbRadio.Text = "USB device";
            this.usbRadio.UseVisualStyleBackColor = true;
            this.usbRadio.CheckedChanged += new System.EventHandler(this.RadioButton16_CheckedChanged);
            // 
            // triggerFlowPanel
            // 
            this.triggerFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.triggerFlowPanel.Controls.Add(this.timePanel);
            this.triggerFlowPanel.Controls.Add(this.appPanel);
            this.triggerFlowPanel.Controls.Add(this.usbPanel);
            this.triggerFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.triggerFlowPanel.Location = new System.Drawing.Point(3, 26);
            this.triggerFlowPanel.Name = "triggerFlowPanel";
            this.triggerFlowPanel.Size = new System.Drawing.Size(514, 52);
            this.triggerFlowPanel.TabIndex = 4;
            // 
            // timePanel
            // 
            this.timePanel.Controls.Add(this.timerBox);
            this.timePanel.Controls.Add(this.timeFormatLabel);
            this.timePanel.Location = new System.Drawing.Point(3, 3);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(173, 33);
            this.timePanel.TabIndex = 1;
            // 
            // timerBox
            // 
            this.timerBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.timerBox.Location = new System.Drawing.Point(3, 5);
            this.timerBox.Mask = "##:##:##";
            this.timerBox.Name = "timerBox";
            this.timerBox.Size = new System.Drawing.Size(53, 20);
            this.timerBox.TabIndex = 4;
            this.timerBox.Text = "000500";
            this.timerBox.TextChanged += new System.EventHandler(this.MaskedTextBox1_TextChanged);
            // 
            // timeFormatLabel
            // 
            this.timeFormatLabel.AutoSize = true;
            this.timeFormatLabel.Location = new System.Drawing.Point(62, 8);
            this.timeFormatLabel.Name = "timeFormatLabel";
            this.timeFormatLabel.Size = new System.Drawing.Size(108, 13);
            this.timeFormatLabel.TabIndex = 5;
            this.timeFormatLabel.Text = "(format hrs:mins:secs)";
            // 
            // appPanel
            // 
            this.appPanel.Controls.Add(this.triggerAppLabel);
            this.appPanel.Controls.Add(this.triggerAppBox);
            this.appPanel.Location = new System.Drawing.Point(182, 3);
            this.appPanel.Name = "appPanel";
            this.appPanel.Size = new System.Drawing.Size(286, 45);
            this.appPanel.TabIndex = 2;
            this.appPanel.Visible = false;
            // 
            // triggerAppLabel
            // 
            this.triggerAppLabel.AutoSize = true;
            this.triggerAppLabel.Location = new System.Drawing.Point(3, 4);
            this.triggerAppLabel.Name = "triggerAppLabel";
            this.triggerAppLabel.Size = new System.Drawing.Size(272, 13);
            this.triggerAppLabel.TabIndex = 3;
            this.triggerAppLabel.Text = "Process name (ie notepad.exe, iexplore.exe, sol.exe etc)";
            // 
            // triggerAppBox
            // 
            this.triggerAppBox.Enabled = false;
            this.triggerAppBox.Location = new System.Drawing.Point(6, 20);
            this.triggerAppBox.Name = "triggerAppBox";
            this.triggerAppBox.Size = new System.Drawing.Size(193, 20);
            this.triggerAppBox.TabIndex = 2;
            this.triggerAppBox.Text = "notepad.exe";
            // 
            // usbPanel
            // 
            this.usbPanel.Controls.Add(this.whyNoDeviceButton);
            this.usbPanel.Controls.Add(this.resetDeviceButton);
            this.usbPanel.Controls.Add(this.deviceInfoLabel);
            this.usbPanel.Location = new System.Drawing.Point(474, 3);
            this.usbPanel.Name = "usbPanel";
            this.usbPanel.Size = new System.Drawing.Size(333, 52);
            this.usbPanel.TabIndex = 3;
            this.usbPanel.Visible = false;
            // 
            // whyNoDeviceButton
            // 
            this.whyNoDeviceButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.whyNoDeviceButton.Location = new System.Drawing.Point(87, 29);
            this.whyNoDeviceButton.Name = "whyNoDeviceButton";
            this.whyNoDeviceButton.Size = new System.Drawing.Size(141, 20);
            this.whyNoDeviceButton.TabIndex = 2;
            this.whyNoDeviceButton.Text = "My device isn\'t detected";
            this.whyNoDeviceButton.UseVisualStyleBackColor = true;
            this.whyNoDeviceButton.Click += new System.EventHandler(this.Button5_Click);
            // 
            // resetDeviceButton
            // 
            this.resetDeviceButton.Enabled = false;
            this.resetDeviceButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resetDeviceButton.Location = new System.Drawing.Point(6, 29);
            this.resetDeviceButton.Name = "resetDeviceButton";
            this.resetDeviceButton.Size = new System.Drawing.Size(75, 20);
            this.resetDeviceButton.TabIndex = 1;
            this.resetDeviceButton.Text = "Reset";
            this.resetDeviceButton.UseVisualStyleBackColor = true;
            this.resetDeviceButton.Click += new System.EventHandler(this.Button4_Click);
            // 
            // deviceInfoLabel
            // 
            this.deviceInfoLabel.Location = new System.Drawing.Point(3, 1);
            this.deviceInfoLabel.Name = "deviceInfoLabel";
            this.deviceInfoLabel.Size = new System.Drawing.Size(327, 32);
            this.deviceInfoLabel.TabIndex = 8;
            this.deviceInfoLabel.Text = "No trigger device\r\n(Unplug and) plug in desired trigger device";
            // 
            // appRadio
            // 
            this.appRadio.AutoSize = true;
            this.appRadio.Location = new System.Drawing.Point(60, 3);
            this.appRadio.Name = "appRadio";
            this.appRadio.Size = new System.Drawing.Size(77, 17);
            this.appRadio.TabIndex = 2;
            this.appRadio.Text = "Application";
            this.appRadio.UseVisualStyleBackColor = true;
            this.appRadio.CheckedChanged += new System.EventHandler(this.RadioButton4_CheckedChanged);
            // 
            // timeRadio
            // 
            this.timeRadio.AutoSize = true;
            this.timeRadio.Checked = true;
            this.timeRadio.Location = new System.Drawing.Point(3, 3);
            this.timeRadio.Name = "timeRadio";
            this.timeRadio.Size = new System.Drawing.Size(51, 17);
            this.timeRadio.TabIndex = 1;
            this.timeRadio.TabStop = true;
            this.timeRadio.Text = "Timer";
            this.timeRadio.UseVisualStyleBackColor = true;
            this.timeRadio.CheckedChanged += new System.EventHandler(this.RadioButton3_CheckedChanged);
            // 
            // letCloseBox
            // 
            this.letCloseBox.AutoSize = true;
            this.letCloseBox.Checked = true;
            this.letCloseBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.letCloseBox.Location = new System.Drawing.Point(12, 212);
            this.letCloseBox.Name = "letCloseBox";
            this.letCloseBox.Size = new System.Drawing.Size(277, 17);
            this.letCloseBox.TabIndex = 3;
            this.letCloseBox.Text = "Allow the user to close the blue screen using ALT+F4";
            this.letCloseBox.UseVisualStyleBackColor = true;
            this.letCloseBox.CheckedChanged += new System.EventHandler(this.LetCloseBox_CheckedChanged);
            // 
            // miscLabel
            // 
            this.miscLabel.AutoSize = true;
            this.miscLabel.Location = new System.Drawing.Point(12, 196);
            this.miscLabel.Name = "miscLabel";
            this.miscLabel.Size = new System.Drawing.Size(109, 13);
            this.miscLabel.TabIndex = 5;
            this.miscLabel.Text = "Miscelaneous options";
            // 
            // friendlyMessageBox
            // 
            this.friendlyMessageBox.AutoSize = true;
            this.friendlyMessageBox.Location = new System.Drawing.Point(12, 235);
            this.friendlyMessageBox.Name = "friendlyMessageBox";
            this.friendlyMessageBox.Size = new System.Drawing.Size(277, 17);
            this.friendlyMessageBox.TabIndex = 4;
            this.friendlyMessageBox.Text = "Show a message after the bluescreen is being closed";
            this.friendlyMessageBox.UseVisualStyleBackColor = true;
            this.friendlyMessageBox.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // friendlyMessageContentsBox
            // 
            this.friendlyMessageContentsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyMessageContentsBox.Enabled = false;
            this.friendlyMessageContentsBox.Location = new System.Drawing.Point(12, 258);
            this.friendlyMessageContentsBox.Multiline = true;
            this.friendlyMessageContentsBox.Name = "friendlyMessageContentsBox";
            this.friendlyMessageContentsBox.Size = new System.Drawing.Size(520, 45);
            this.friendlyMessageContentsBox.TabIndex = 6;
            this.friendlyMessageContentsBox.Text = "Enter a message here.";
            this.friendlyMessageContentsBox.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // friendlyMessageTitleLabel
            // 
            this.friendlyMessageTitleLabel.AutoSize = true;
            this.friendlyMessageTitleLabel.Location = new System.Drawing.Point(12, 309);
            this.friendlyMessageTitleLabel.Name = "friendlyMessageTitleLabel";
            this.friendlyMessageTitleLabel.Size = new System.Drawing.Size(69, 13);
            this.friendlyMessageTitleLabel.TabIndex = 9;
            this.friendlyMessageTitleLabel.Text = "Message title";
            // 
            // friendlyMessageTitleBox
            // 
            this.friendlyMessageTitleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyMessageTitleBox.Enabled = false;
            this.friendlyMessageTitleBox.Location = new System.Drawing.Point(87, 306);
            this.friendlyMessageTitleBox.Name = "friendlyMessageTitleBox";
            this.friendlyMessageTitleBox.Size = new System.Drawing.Size(445, 20);
            this.friendlyMessageTitleBox.TabIndex = 7;
            this.friendlyMessageTitleBox.Text = "Enter a title here";
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
            this.friendlyMessageIconPanel.Location = new System.Drawing.Point(12, 345);
            this.friendlyMessageIconPanel.Name = "friendlyMessageIconPanel";
            this.friendlyMessageIconPanel.Size = new System.Drawing.Size(520, 26);
            this.friendlyMessageIconPanel.TabIndex = 8;
            // 
            // errorRadio
            // 
            this.errorRadio.AutoSize = true;
            this.errorRadio.Location = new System.Drawing.Point(3, 3);
            this.errorRadio.Name = "errorRadio";
            this.errorRadio.Size = new System.Drawing.Size(108, 17);
            this.errorRadio.TabIndex = 0;
            this.errorRadio.Text = "Error/Critical Stop";
            this.errorRadio.UseVisualStyleBackColor = true;
            this.errorRadio.CheckedChanged += new System.EventHandler(this.RadioButton5_CheckedChanged);
            // 
            // warningRadio
            // 
            this.warningRadio.AutoSize = true;
            this.warningRadio.Checked = true;
            this.warningRadio.Location = new System.Drawing.Point(117, 3);
            this.warningRadio.Name = "warningRadio";
            this.warningRadio.Size = new System.Drawing.Size(127, 17);
            this.warningRadio.TabIndex = 1;
            this.warningRadio.TabStop = true;
            this.warningRadio.Text = "Warning/Exclamation";
            this.warningRadio.UseVisualStyleBackColor = true;
            this.warningRadio.CheckedChanged += new System.EventHandler(this.RadioButton6_CheckedChanged);
            // 
            // questionRadio
            // 
            this.questionRadio.AutoSize = true;
            this.questionRadio.Location = new System.Drawing.Point(250, 3);
            this.questionRadio.Name = "questionRadio";
            this.questionRadio.Size = new System.Drawing.Size(94, 17);
            this.questionRadio.TabIndex = 2;
            this.questionRadio.Text = "Question/Help";
            this.questionRadio.UseVisualStyleBackColor = true;
            this.questionRadio.CheckedChanged += new System.EventHandler(this.RadioButton7_CheckedChanged);
            // 
            // infoRadio
            // 
            this.infoRadio.AutoSize = true;
            this.infoRadio.Location = new System.Drawing.Point(350, 3);
            this.infoRadio.Name = "infoRadio";
            this.infoRadio.Size = new System.Drawing.Size(77, 17);
            this.infoRadio.TabIndex = 3;
            this.infoRadio.Text = "Information";
            this.infoRadio.UseVisualStyleBackColor = true;
            this.infoRadio.CheckedChanged += new System.EventHandler(this.RadioButton8_CheckedChanged);
            // 
            // noneRadio
            // 
            this.noneRadio.AutoSize = true;
            this.noneRadio.Location = new System.Drawing.Point(433, 3);
            this.noneRadio.Name = "noneRadio";
            this.noneRadio.Size = new System.Drawing.Size(62, 17);
            this.noneRadio.TabIndex = 4;
            this.noneRadio.Text = "No icon";
            this.noneRadio.UseVisualStyleBackColor = true;
            this.noneRadio.CheckedChanged += new System.EventHandler(this.RadioButton9_CheckedChanged);
            // 
            // friendlyMessageIconLabel
            // 
            this.friendlyMessageIconLabel.AutoSize = true;
            this.friendlyMessageIconLabel.Location = new System.Drawing.Point(12, 329);
            this.friendlyMessageIconLabel.Name = "friendlyMessageIconLabel";
            this.friendlyMessageIconLabel.Size = new System.Drawing.Size(73, 13);
            this.friendlyMessageIconLabel.TabIndex = 12;
            this.friendlyMessageIconLabel.Text = "Message icon";
            // 
            // friendlyMessageButtonsLabel
            // 
            this.friendlyMessageButtonsLabel.AutoSize = true;
            this.friendlyMessageButtonsLabel.Location = new System.Drawing.Point(12, 373);
            this.friendlyMessageButtonsLabel.Name = "friendlyMessageButtonsLabel";
            this.friendlyMessageButtonsLabel.Size = new System.Drawing.Size(88, 13);
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
            this.friendlyMessageButtonsPanel.Location = new System.Drawing.Point(12, 389);
            this.friendlyMessageButtonsPanel.Name = "friendlyMessageButtonsPanel";
            this.friendlyMessageButtonsPanel.Size = new System.Drawing.Size(520, 26);
            this.friendlyMessageButtonsPanel.TabIndex = 9;
            // 
            // okRadio
            // 
            this.okRadio.AutoSize = true;
            this.okRadio.Checked = true;
            this.okRadio.Location = new System.Drawing.Point(3, 3);
            this.okRadio.Name = "okRadio";
            this.okRadio.Size = new System.Drawing.Size(40, 17);
            this.okRadio.TabIndex = 0;
            this.okRadio.TabStop = true;
            this.okRadio.Text = "OK";
            this.okRadio.UseVisualStyleBackColor = true;
            this.okRadio.CheckedChanged += new System.EventHandler(this.RadioButton10_CheckedChanged);
            // 
            // okCancelRadio
            // 
            this.okCancelRadio.AutoSize = true;
            this.okCancelRadio.Location = new System.Drawing.Point(49, 3);
            this.okCancelRadio.Name = "okCancelRadio";
            this.okCancelRadio.Size = new System.Drawing.Size(78, 17);
            this.okCancelRadio.TabIndex = 1;
            this.okCancelRadio.Text = "OK/Cancel";
            this.okCancelRadio.UseVisualStyleBackColor = true;
            this.okCancelRadio.CheckedChanged += new System.EventHandler(this.RadioButton11_CheckedChanged);
            // 
            // retryIgnoreAboutRadio
            // 
            this.retryIgnoreAboutRadio.AutoSize = true;
            this.retryIgnoreAboutRadio.Location = new System.Drawing.Point(133, 3);
            this.retryIgnoreAboutRadio.Name = "retryIgnoreAboutRadio";
            this.retryIgnoreAboutRadio.Size = new System.Drawing.Size(115, 17);
            this.retryIgnoreAboutRadio.TabIndex = 2;
            this.retryIgnoreAboutRadio.Text = "Retry/Ignore/Abort";
            this.retryIgnoreAboutRadio.UseVisualStyleBackColor = true;
            this.retryIgnoreAboutRadio.CheckedChanged += new System.EventHandler(this.RadioButton12_CheckedChanged);
            // 
            // retryCancelRadio
            // 
            this.retryCancelRadio.AutoSize = true;
            this.retryCancelRadio.Location = new System.Drawing.Point(254, 3);
            this.retryCancelRadio.Name = "retryCancelRadio";
            this.retryCancelRadio.Size = new System.Drawing.Size(88, 17);
            this.retryCancelRadio.TabIndex = 3;
            this.retryCancelRadio.Text = "Retry/Cancel";
            this.retryCancelRadio.UseVisualStyleBackColor = true;
            this.retryCancelRadio.CheckedChanged += new System.EventHandler(this.RadioButton15_CheckedChanged);
            // 
            // yesNoRadio
            // 
            this.yesNoRadio.AutoSize = true;
            this.yesNoRadio.Location = new System.Drawing.Point(348, 3);
            this.yesNoRadio.Name = "yesNoRadio";
            this.yesNoRadio.Size = new System.Drawing.Size(62, 17);
            this.yesNoRadio.TabIndex = 4;
            this.yesNoRadio.Text = "Yes/No";
            this.yesNoRadio.UseVisualStyleBackColor = true;
            this.yesNoRadio.CheckedChanged += new System.EventHandler(this.RadioButton13_CheckedChanged);
            // 
            // yesNoCancelRadio
            // 
            this.yesNoCancelRadio.AutoSize = true;
            this.yesNoCancelRadio.Location = new System.Drawing.Point(416, 3);
            this.yesNoCancelRadio.Name = "yesNoCancelRadio";
            this.yesNoCancelRadio.Size = new System.Drawing.Size(100, 17);
            this.yesNoCancelRadio.TabIndex = 5;
            this.yesNoCancelRadio.Text = "Yes/No/Cancel";
            this.yesNoCancelRadio.UseVisualStyleBackColor = true;
            this.yesNoCancelRadio.CheckedChanged += new System.EventHandler(this.RadioButton14_CheckedChanged);
            // 
            // previewFriendlyMessageButton
            // 
            this.previewFriendlyMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.previewFriendlyMessageButton.Enabled = false;
            this.previewFriendlyMessageButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.previewFriendlyMessageButton.Location = new System.Drawing.Point(425, 229);
            this.previewFriendlyMessageButton.Name = "previewFriendlyMessageButton";
            this.previewFriendlyMessageButton.Size = new System.Drawing.Size(107, 23);
            this.previewFriendlyMessageButton.TabIndex = 5;
            this.previewFriendlyMessageButton.Text = "Preview message";
            this.previewFriendlyMessageButton.UseVisualStyleBackColor = true;
            this.previewFriendlyMessageButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.okButton.Location = new System.Drawing.Point(457, 429);
            this.okButton.Name = "okButton";
            this.okButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "O&K";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cancelButton.Location = new System.Drawing.Point(376, 429);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "&Cancel";
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
            this.closePrank.Location = new System.Drawing.Point(12, 435);
            this.closePrank.Name = "closePrank";
            this.closePrank.Size = new System.Drawing.Size(185, 17);
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
            this.ClientSize = new System.Drawing.Size(539, 464);
            this.Controls.Add(this.closePrank);
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
            this.MinimumSize = new System.Drawing.Size(555, 503);
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
            this.friendlyMessageIconPanel.ResumeLayout(false);
            this.friendlyMessageIconPanel.PerformLayout();
            this.friendlyMessageButtonsPanel.ResumeLayout(false);
            this.friendlyMessageButtonsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bluescreenTypeLabel;
        private System.Windows.Forms.Panel bluescreenTypePanel;
        private System.Windows.Forms.RadioButton matchAllRadio;
        private System.Windows.Forms.RadioButton bestMatchRadio;
        private System.Windows.Forms.Label triggerLabel;
        private System.Windows.Forms.Panel triggerPanel;
        private System.Windows.Forms.Label timeFormatLabel;
        private System.Windows.Forms.MaskedTextBox timerBox;
        private System.Windows.Forms.Label triggerAppLabel;
        private System.Windows.Forms.TextBox triggerAppBox;
        private System.Windows.Forms.RadioButton appRadio;
        private System.Windows.Forms.RadioButton timeRadio;
        private System.Windows.Forms.CheckBox letCloseBox;
        private System.Windows.Forms.Label miscLabel;
        private System.Windows.Forms.CheckBox friendlyMessageBox;
        private System.Windows.Forms.TextBox friendlyMessageContentsBox;
        private System.Windows.Forms.Label friendlyMessageTitleLabel;
        private System.Windows.Forms.TextBox friendlyMessageTitleBox;
        private System.Windows.Forms.FlowLayoutPanel friendlyMessageIconPanel;
        private System.Windows.Forms.RadioButton errorRadio;
        private System.Windows.Forms.RadioButton warningRadio;
        private System.Windows.Forms.RadioButton questionRadio;
        private System.Windows.Forms.RadioButton infoRadio;
        private System.Windows.Forms.RadioButton noneRadio;
        private System.Windows.Forms.Label friendlyMessageIconLabel;
        private System.Windows.Forms.Label friendlyMessageButtonsLabel;
        private System.Windows.Forms.FlowLayoutPanel friendlyMessageButtonsPanel;
        private System.Windows.Forms.RadioButton okRadio;
        private System.Windows.Forms.RadioButton okCancelRadio;
        private System.Windows.Forms.RadioButton retryIgnoreAboutRadio;
        private System.Windows.Forms.RadioButton yesNoRadio;
        private System.Windows.Forms.RadioButton yesNoCancelRadio;
        private System.Windows.Forms.FlowLayoutPanel triggerFlowPanel;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Panel appPanel;
        private System.Windows.Forms.Button previewFriendlyMessageButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton retryCancelRadio;
        private System.Windows.Forms.RadioButton usbRadio;
        private System.Windows.Forms.Panel usbPanel;
        private System.Windows.Forms.Button resetDeviceButton;
        private System.Windows.Forms.Label deviceInfoLabel;
        private System.Windows.Forms.Timer usbFinder;
        private System.Windows.Forms.Button whyNoDeviceButton;
        private System.Windows.Forms.CheckBox closePrank;
    }
}