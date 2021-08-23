namespace UltimateBlueScreenSimulator
{
    partial class AboutSettingsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutSettingsDialog));
            this.aboutTable = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.logoDisplayFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.markusSoftwareLogo = new System.Windows.Forms.PictureBox();
            this.veriFileLogo = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.aboutSettingsTabControl = new System.Windows.Forms.TabControl();
            this.aboutPanel = new System.Windows.Forms.TabPage();
            this.updatePanel = new System.Windows.Forms.TabPage();
            this.customServerButton = new System.Windows.Forms.Button();
            this.primaryServerButton = new System.Windows.Forms.Button();
            this.backupServerButton = new System.Windows.Forms.Button();
            this.primaryServerBox = new System.Windows.Forms.TextBox();
            this.primaryServerLabel = new System.Windows.Forms.Label();
            this.noticeLabel = new System.Windows.Forms.Label();
            this.updateCheckButton = new System.Windows.Forms.Button();
            this.unsignButton = new System.Windows.Forms.Button();
            this.updateTimeLabel = new System.Windows.Forms.Label();
            this.updateSettingsLabel = new System.Windows.Forms.Label();
            this.updateTimeFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.updateImmediatelyRadio = new System.Windows.Forms.RadioButton();
            this.updateOnCloseRadio = new System.Windows.Forms.RadioButton();
            this.hashBox = new System.Windows.Forms.CheckBox();
            this.updateSettingsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.autoUpdateRadio = new System.Windows.Forms.RadioButton();
            this.noUpdatesRadio = new System.Windows.Forms.RadioButton();
            this.updatePanelHeading = new System.Windows.Forms.Label();
            this.simulatorSettingsPanel = new System.Windows.Forms.TabPage();
            this.devNukeAllButton = new System.Windows.Forms.Button();
            this.devNewAllButton = new System.Windows.Forms.Button();
            this.devDictEditButton = new System.Windows.Forms.Button();
            this.multiDisplayBox = new System.Windows.Forms.ComboBox();
            this.multiDisplayLabel = new System.Windows.Forms.Label();
            this.configEditingButtonsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.resetButton = new System.Windows.Forms.Button();
            this.resetHackButton = new System.Windows.Forms.Button();
            this.addCfg = new System.Windows.Forms.Button();
            this.removeCfg = new System.Windows.Forms.Button();
            this.saveCfg = new System.Windows.Forms.Button();
            this.loadCfg = new System.Windows.Forms.Button();
            this.osName = new System.Windows.Forms.Label();
            this.configList = new System.Windows.Forms.ListBox();
            this.eggHunterButton = new System.Windows.Forms.CheckBox();
            this.simulatorSettingsNotice = new System.Windows.Forms.Label();
            this.scalingModeBox = new System.Windows.Forms.ComboBox();
            this.scalingModeLabel = new System.Windows.Forms.Label();
            this.hideInFullscreenButton = new System.Windows.Forms.CheckBox();
            this.configListHeading = new System.Windows.Forms.Label();
            this.simulatorSettingsHeading = new System.Windows.Forms.Label();
            this.helpPanel = new System.Windows.Forms.TabPage();
            this.helpPanelChild = new System.Windows.Forms.FlowLayoutPanel();
            this.helpButtonsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.howToGetHelpButton = new System.Windows.Forms.Button();
            this.purposesOfThisProgramButton = new System.Windows.Forms.Button();
            this.systemRequirementsButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.helpDisplay = new System.Windows.Forms.TextBox();
            this.commandLinePanel = new System.Windows.Forms.TabPage();
            this.commandLineHelpDisplay = new System.Windows.Forms.TextBox();
            this.helpTip = new System.Windows.Forms.ToolTip(this.components);
            this.updateCheckerTimer = new System.Windows.Forms.Timer(this.components);
            this.saveBsconfig = new System.Windows.Forms.SaveFileDialog();
            this.loadBsconfig = new System.Windows.Forms.OpenFileDialog();
            this.aboutTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.logoDisplayFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.markusSoftwareLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veriFileLogo)).BeginInit();
            this.aboutSettingsTabControl.SuspendLayout();
            this.aboutPanel.SuspendLayout();
            this.updatePanel.SuspendLayout();
            this.updateTimeFlowPanel.SuspendLayout();
            this.updateSettingsFlowPanel.SuspendLayout();
            this.simulatorSettingsPanel.SuspendLayout();
            this.configEditingButtonsFlowPanel.SuspendLayout();
            this.helpPanel.SuspendLayout();
            this.helpPanelChild.SuspendLayout();
            this.helpButtonsFlowPanel.SuspendLayout();
            this.commandLinePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutTable
            // 
            this.aboutTable.ColumnCount = 2;
            this.aboutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.56546F));
            this.aboutTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.43453F));
            this.aboutTable.Controls.Add(this.logoPictureBox, 0, 0);
            this.aboutTable.Controls.Add(this.logoDisplayFlowPanel, 1, 4);
            this.aboutTable.Controls.Add(this.labelProductName, 1, 0);
            this.aboutTable.Controls.Add(this.labelVersion, 1, 1);
            this.aboutTable.Controls.Add(this.labelCopyright, 1, 2);
            this.aboutTable.Controls.Add(this.okButton, 1, 5);
            this.aboutTable.Controls.Add(this.labelCompanyName, 1, 3);
            this.aboutTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutTable.Location = new System.Drawing.Point(3, 3);
            this.aboutTable.Name = "aboutTable";
            this.aboutTable.RowCount = 6;
            this.aboutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.19195F));
            this.aboutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.572755F));
            this.aboutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.19195F));
            this.aboutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.86378F));
            this.aboutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.24768F));
            this.aboutTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.47988F));
            this.aboutTable.Size = new System.Drawing.Size(528, 346);
            this.aboutTable.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = global::UltimateBlueScreenSimulator.Properties.Resources.bsodbanner2;
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.aboutTable.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(134, 340);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // logoDisplayFlowPanel
            // 
            this.logoDisplayFlowPanel.Controls.Add(this.markusSoftwareLogo);
            this.logoDisplayFlowPanel.Controls.Add(this.veriFileLogo);
            this.logoDisplayFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoDisplayFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.logoDisplayFlowPanel.Location = new System.Drawing.Point(143, 157);
            this.logoDisplayFlowPanel.Name = "logoDisplayFlowPanel";
            this.logoDisplayFlowPanel.Size = new System.Drawing.Size(382, 131);
            this.logoDisplayFlowPanel.TabIndex = 25;
            // 
            // markusSoftwareLogo
            // 
            this.markusSoftwareLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.markusSoftwareLogo.Image = global::UltimateBlueScreenSimulator.Properties.Resources.msoftware;
            this.markusSoftwareLogo.Location = new System.Drawing.Point(0, 0);
            this.markusSoftwareLogo.Margin = new System.Windows.Forms.Padding(0);
            this.markusSoftwareLogo.Name = "markusSoftwareLogo";
            this.markusSoftwareLogo.Size = new System.Drawing.Size(202, 53);
            this.markusSoftwareLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.markusSoftwareLogo.TabIndex = 0;
            this.markusSoftwareLogo.TabStop = false;
            // 
            // veriFileLogo
            // 
            this.veriFileLogo.Image = global::UltimateBlueScreenSimulator.Properties.Resources.verifile;
            this.veriFileLogo.Location = new System.Drawing.Point(0, 53);
            this.veriFileLogo.Margin = new System.Windows.Forms.Padding(0);
            this.veriFileLogo.Name = "veriFileLogo";
            this.veriFileLogo.Size = new System.Drawing.Size(202, 67);
            this.veriFileLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.veriFileLogo.TabIndex = 1;
            this.veriFileLogo.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(146, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(379, 17);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "Product Name";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(146, 21);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(379, 17);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "Version";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Location = new System.Drawing.Point(146, 39);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 17);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(379, 17);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.BackColor = System.Drawing.SystemColors.Control;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.okButton.Location = new System.Drawing.Point(450, 320);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = false;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCompanyName.Location = new System.Drawing.Point(146, 60);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(379, 88);
            this.labelCompanyName.TabIndex = 22;
            // 
            // aboutSettingsTabControl
            // 
            this.aboutSettingsTabControl.Controls.Add(this.aboutPanel);
            this.aboutSettingsTabControl.Controls.Add(this.updatePanel);
            this.aboutSettingsTabControl.Controls.Add(this.simulatorSettingsPanel);
            this.aboutSettingsTabControl.Controls.Add(this.helpPanel);
            this.aboutSettingsTabControl.Controls.Add(this.commandLinePanel);
            this.aboutSettingsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutSettingsTabControl.Location = new System.Drawing.Point(3, 3);
            this.aboutSettingsTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.aboutSettingsTabControl.Name = "aboutSettingsTabControl";
            this.aboutSettingsTabControl.Padding = new System.Drawing.Point(0, 0);
            this.aboutSettingsTabControl.SelectedIndex = 0;
            this.aboutSettingsTabControl.Size = new System.Drawing.Size(542, 378);
            this.aboutSettingsTabControl.TabIndex = 1;
            this.aboutSettingsTabControl.SelectedIndexChanged += new System.EventHandler(this.TabSwitcher);
            // 
            // aboutPanel
            // 
            this.aboutPanel.Controls.Add(this.aboutTable);
            this.aboutPanel.Location = new System.Drawing.Point(4, 22);
            this.aboutPanel.Name = "aboutPanel";
            this.aboutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.aboutPanel.Size = new System.Drawing.Size(534, 352);
            this.aboutPanel.TabIndex = 0;
            this.aboutPanel.Text = "About";
            this.aboutPanel.UseVisualStyleBackColor = true;
            // 
            // updatePanel
            // 
            this.updatePanel.Controls.Add(this.customServerButton);
            this.updatePanel.Controls.Add(this.primaryServerButton);
            this.updatePanel.Controls.Add(this.backupServerButton);
            this.updatePanel.Controls.Add(this.primaryServerBox);
            this.updatePanel.Controls.Add(this.primaryServerLabel);
            this.updatePanel.Controls.Add(this.noticeLabel);
            this.updatePanel.Controls.Add(this.updateCheckButton);
            this.updatePanel.Controls.Add(this.unsignButton);
            this.updatePanel.Controls.Add(this.updateTimeLabel);
            this.updatePanel.Controls.Add(this.updateSettingsLabel);
            this.updatePanel.Controls.Add(this.updateTimeFlowPanel);
            this.updatePanel.Controls.Add(this.hashBox);
            this.updatePanel.Controls.Add(this.updateSettingsFlowPanel);
            this.updatePanel.Controls.Add(this.updatePanelHeading);
            this.updatePanel.Location = new System.Drawing.Point(4, 22);
            this.updatePanel.Name = "updatePanel";
            this.updatePanel.Padding = new System.Windows.Forms.Padding(3);
            this.updatePanel.Size = new System.Drawing.Size(534, 352);
            this.updatePanel.TabIndex = 1;
            this.updatePanel.Text = "Update settings";
            this.updatePanel.UseVisualStyleBackColor = true;
            // 
            // customServerButton
            // 
            this.customServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customServerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customServerButton.Location = new System.Drawing.Point(441, 245);
            this.customServerButton.Name = "customServerButton";
            this.customServerButton.Size = new System.Drawing.Size(74, 23);
            this.customServerButton.TabIndex = 13;
            this.customServerButton.Text = "Custom";
            this.helpTip.SetToolTip(this.customServerButton, "This is the last option. If the both servers are down, you can use another server" +
        ", which you can find on my blog if both links are down for some reason.");
            this.customServerButton.UseVisualStyleBackColor = true;
            this.customServerButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // primaryServerButton
            // 
            this.primaryServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.primaryServerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.primaryServerButton.Location = new System.Drawing.Point(291, 245);
            this.primaryServerButton.Name = "primaryServerButton";
            this.primaryServerButton.Size = new System.Drawing.Size(71, 23);
            this.primaryServerButton.TabIndex = 12;
            this.primaryServerButton.Text = "Primary";
            this.helpTip.SetToolTip(this.primaryServerButton, "This is the server you want to use most of the time.");
            this.primaryServerButton.UseVisualStyleBackColor = true;
            this.primaryServerButton.Click += new System.EventHandler(this.SetToPrimaryServer);
            // 
            // backupServerButton
            // 
            this.backupServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backupServerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backupServerButton.Location = new System.Drawing.Point(365, 245);
            this.backupServerButton.Name = "backupServerButton";
            this.backupServerButton.Size = new System.Drawing.Size(74, 23);
            this.backupServerButton.TabIndex = 11;
            this.backupServerButton.Text = "Backup";
            this.helpTip.SetToolTip(this.backupServerButton, "This is the server you should use if the primary server is down.");
            this.backupServerButton.UseVisualStyleBackColor = true;
            this.backupServerButton.Click += new System.EventHandler(this.SetToBackupServer);
            // 
            // primaryServerBox
            // 
            this.primaryServerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.primaryServerBox.Enabled = false;
            this.primaryServerBox.Location = new System.Drawing.Point(20, 272);
            this.primaryServerBox.Name = "primaryServerBox";
            this.primaryServerBox.Size = new System.Drawing.Size(495, 20);
            this.primaryServerBox.TabIndex = 10;
            this.primaryServerBox.Text = "http://markustegelane.tk/app";
            this.primaryServerBox.TextChanged += new System.EventHandler(this.ChangeUpdateServer);
            // 
            // primaryServerLabel
            // 
            this.primaryServerLabel.AutoSize = true;
            this.primaryServerLabel.Location = new System.Drawing.Point(17, 250);
            this.primaryServerLabel.Name = "primaryServerLabel";
            this.primaryServerLabel.Size = new System.Drawing.Size(89, 13);
            this.primaryServerLabel.TabIndex = 9;
            this.primaryServerLabel.Text = "Update server [?]";
            this.helpTip.SetToolTip(this.primaryServerLabel, "This is where the update files are downloaded from");
            // 
            // noticeLabel
            // 
            this.noticeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.noticeLabel.Location = new System.Drawing.Point(3, 329);
            this.noticeLabel.Name = "noticeLabel";
            this.noticeLabel.Size = new System.Drawing.Size(531, 18);
            this.noticeLabel.TabIndex = 8;
            this.noticeLabel.Text = "These settings will be saved once the program is closed.";
            this.noticeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // updateCheckButton
            // 
            this.updateCheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateCheckButton.AutoSize = true;
            this.updateCheckButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateCheckButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateCheckButton.Location = new System.Drawing.Point(151, 303);
            this.updateCheckButton.Name = "updateCheckButton";
            this.updateCheckButton.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.updateCheckButton.Size = new System.Drawing.Size(116, 23);
            this.updateCheckButton.TabIndex = 7;
            this.updateCheckButton.Text = "Check for updates";
            this.helpTip.SetToolTip(this.updateCheckButton, "Checks for updates right away");
            this.updateCheckButton.UseVisualStyleBackColor = true;
            this.updateCheckButton.Click += new System.EventHandler(this.CheckForUpdates);
            // 
            // unsignButton
            // 
            this.unsignButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.unsignButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.unsignButton.Location = new System.Drawing.Point(20, 303);
            this.unsignButton.Name = "unsignButton";
            this.unsignButton.Size = new System.Drawing.Size(125, 23);
            this.unsignButton.TabIndex = 6;
            this.unsignButton.Text = "Unsign this computer";
            this.helpTip.SetToolTip(this.unsignButton, "Removes the signature of this computer, which makes the first use dialog show up " +
        "again");
            this.unsignButton.UseVisualStyleBackColor = true;
            this.unsignButton.Click += new System.EventHandler(this.UnsignMe);
            // 
            // updateTimeLabel
            // 
            this.updateTimeLabel.AutoSize = true;
            this.updateTimeLabel.Location = new System.Drawing.Point(17, 158);
            this.updateTimeLabel.Name = "updateTimeLabel";
            this.updateTimeLabel.Size = new System.Drawing.Size(154, 13);
            this.updateTimeLabel.TabIndex = 5;
            this.updateTimeLabel.Text = "Choose when to install updates";
            // 
            // updateSettingsLabel
            // 
            this.updateSettingsLabel.AutoSize = true;
            this.updateSettingsLabel.Location = new System.Drawing.Point(17, 43);
            this.updateSettingsLabel.Name = "updateSettingsLabel";
            this.updateSettingsLabel.Size = new System.Drawing.Size(103, 13);
            this.updateSettingsLabel.TabIndex = 4;
            this.updateSettingsLabel.Text = "AutoUpdate settings";
            // 
            // updateTimeFlowPanel
            // 
            this.updateTimeFlowPanel.Controls.Add(this.updateImmediatelyRadio);
            this.updateTimeFlowPanel.Controls.Add(this.updateOnCloseRadio);
            this.updateTimeFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.updateTimeFlowPanel.Location = new System.Drawing.Point(20, 176);
            this.updateTimeFlowPanel.Margin = new System.Windows.Forms.Padding(0, 12, 3, 3);
            this.updateTimeFlowPanel.Name = "updateTimeFlowPanel";
            this.updateTimeFlowPanel.Size = new System.Drawing.Size(495, 60);
            this.updateTimeFlowPanel.TabIndex = 3;
            // 
            // updateImmediatelyRadio
            // 
            this.updateImmediatelyRadio.AutoSize = true;
            this.updateImmediatelyRadio.Checked = true;
            this.updateImmediatelyRadio.Location = new System.Drawing.Point(0, 7);
            this.updateImmediatelyRadio.Margin = new System.Windows.Forms.Padding(0, 7, 3, 3);
            this.updateImmediatelyRadio.Name = "updateImmediatelyRadio";
            this.updateImmediatelyRadio.Size = new System.Drawing.Size(278, 17);
            this.updateImmediatelyRadio.TabIndex = 0;
            this.updateImmediatelyRadio.TabStop = true;
            this.updateImmediatelyRadio.Text = "Install updates right after clicking \"Yes\" on the prompt";
            this.helpTip.SetToolTip(this.updateImmediatelyRadio, "Installs the update right away when user accepts to install the update.");
            this.updateImmediatelyRadio.UseVisualStyleBackColor = true;
            this.updateImmediatelyRadio.CheckedChanged += new System.EventHandler(this.UpdateWhenDoneSetup);
            // 
            // updateOnCloseRadio
            // 
            this.updateOnCloseRadio.AutoSize = true;
            this.updateOnCloseRadio.Location = new System.Drawing.Point(0, 34);
            this.updateOnCloseRadio.Margin = new System.Windows.Forms.Padding(0, 7, 3, 3);
            this.updateOnCloseRadio.Name = "updateOnCloseRadio";
            this.updateOnCloseRadio.Size = new System.Drawing.Size(400, 17);
            this.updateOnCloseRadio.TabIndex = 1;
            this.updateOnCloseRadio.Text = "Install updates once the program closes, if the user clicked \"Yes\" on the prompt";
            this.helpTip.SetToolTip(this.updateOnCloseRadio, "A more convienient option, which allows you to install updates after closing the " +
        "program.");
            this.updateOnCloseRadio.UseVisualStyleBackColor = true;
            // 
            // hashBox
            // 
            this.hashBox.AutoSize = true;
            this.hashBox.Checked = true;
            this.hashBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hashBox.Location = new System.Drawing.Point(20, 128);
            this.hashBox.Name = "hashBox";
            this.hashBox.Size = new System.Drawing.Size(198, 17);
            this.hashBox.TabIndex = 2;
            this.hashBox.Text = "Hashcheck downloaded updates [?]";
            this.helpTip.SetToolTip(this.hashBox, resources.GetString("hashBox.ToolTip"));
            this.hashBox.UseVisualStyleBackColor = true;
            this.hashBox.CheckedChanged += new System.EventHandler(this.HashcheckSetup);
            // 
            // updateSettingsFlowPanel
            // 
            this.updateSettingsFlowPanel.Controls.Add(this.autoUpdateRadio);
            this.updateSettingsFlowPanel.Controls.Add(this.noUpdatesRadio);
            this.updateSettingsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.updateSettingsFlowPanel.Location = new System.Drawing.Point(20, 62);
            this.updateSettingsFlowPanel.Margin = new System.Windows.Forms.Padding(0, 12, 3, 3);
            this.updateSettingsFlowPanel.Name = "updateSettingsFlowPanel";
            this.updateSettingsFlowPanel.Size = new System.Drawing.Size(495, 60);
            this.updateSettingsFlowPanel.TabIndex = 1;
            // 
            // autoUpdateRadio
            // 
            this.autoUpdateRadio.AutoSize = true;
            this.autoUpdateRadio.Checked = true;
            this.autoUpdateRadio.Location = new System.Drawing.Point(0, 7);
            this.autoUpdateRadio.Margin = new System.Windows.Forms.Padding(0, 7, 3, 3);
            this.autoUpdateRadio.Name = "autoUpdateRadio";
            this.autoUpdateRadio.Size = new System.Drawing.Size(360, 17);
            this.autoUpdateRadio.TabIndex = 0;
            this.autoUpdateRadio.TabStop = true;
            this.autoUpdateRadio.Text = "Automatically check for updates and notify when an update is available";
            this.helpTip.SetToolTip(this.autoUpdateRadio, "Recommended setting: Checks for the latest version of blue screen simulator plus " +
        "from the internet. If any updates are available, you can just download and insta" +
        "ll them, usually in less than a minute.");
            this.autoUpdateRadio.UseVisualStyleBackColor = true;
            this.autoUpdateRadio.CheckedChanged += new System.EventHandler(this.EnableDisableUpdateSetup);
            // 
            // noUpdatesRadio
            // 
            this.noUpdatesRadio.AutoSize = true;
            this.noUpdatesRadio.Location = new System.Drawing.Point(0, 34);
            this.noUpdatesRadio.Margin = new System.Windows.Forms.Padding(0, 7, 3, 3);
            this.noUpdatesRadio.Name = "noUpdatesRadio";
            this.noUpdatesRadio.Size = new System.Drawing.Size(210, 17);
            this.noUpdatesRadio.TabIndex = 1;
            this.noUpdatesRadio.Text = "Do not automatically check for updates";
            this.helpTip.SetToolTip(this.noUpdatesRadio, "Does not check for updates when launching the program. An advantage of this optio" +
        "n is when using read only media, as checking for updates requires the program to" +
        " download a file.");
            this.noUpdatesRadio.UseVisualStyleBackColor = true;
            // 
            // updatePanelHeading
            // 
            this.updatePanelHeading.AutoSize = true;
            this.updatePanelHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.updatePanelHeading.Location = new System.Drawing.Point(16, 16);
            this.updatePanelHeading.Name = "updatePanelHeading";
            this.updatePanelHeading.Size = new System.Drawing.Size(122, 20);
            this.updatePanelHeading.TabIndex = 0;
            this.updatePanelHeading.Text = "Update settings";
            // 
            // simulatorSettingsPanel
            // 
            this.simulatorSettingsPanel.Controls.Add(this.devNukeAllButton);
            this.simulatorSettingsPanel.Controls.Add(this.devNewAllButton);
            this.simulatorSettingsPanel.Controls.Add(this.devDictEditButton);
            this.simulatorSettingsPanel.Controls.Add(this.multiDisplayBox);
            this.simulatorSettingsPanel.Controls.Add(this.multiDisplayLabel);
            this.simulatorSettingsPanel.Controls.Add(this.configEditingButtonsFlowPanel);
            this.simulatorSettingsPanel.Controls.Add(this.osName);
            this.simulatorSettingsPanel.Controls.Add(this.configList);
            this.simulatorSettingsPanel.Controls.Add(this.eggHunterButton);
            this.simulatorSettingsPanel.Controls.Add(this.simulatorSettingsNotice);
            this.simulatorSettingsPanel.Controls.Add(this.scalingModeBox);
            this.simulatorSettingsPanel.Controls.Add(this.scalingModeLabel);
            this.simulatorSettingsPanel.Controls.Add(this.hideInFullscreenButton);
            this.simulatorSettingsPanel.Controls.Add(this.configListHeading);
            this.simulatorSettingsPanel.Controls.Add(this.simulatorSettingsHeading);
            this.simulatorSettingsPanel.Location = new System.Drawing.Point(4, 22);
            this.simulatorSettingsPanel.Name = "simulatorSettingsPanel";
            this.simulatorSettingsPanel.Size = new System.Drawing.Size(534, 352);
            this.simulatorSettingsPanel.TabIndex = 4;
            this.simulatorSettingsPanel.Text = "Simulator settings";
            this.simulatorSettingsPanel.UseVisualStyleBackColor = true;
            // 
            // devNukeAllButton
            // 
            this.devNukeAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.devNukeAllButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.devNukeAllButton.Location = new System.Drawing.Point(226, 3);
            this.devNukeAllButton.Name = "devNukeAllButton";
            this.devNukeAllButton.Size = new System.Drawing.Size(97, 46);
            this.devNukeAllButton.TabIndex = 21;
            this.devNukeAllButton.Text = "[DEV] Nuke All (DANGEROUS!!)";
            this.devNukeAllButton.UseVisualStyleBackColor = true;
            this.devNukeAllButton.Visible = false;
            this.devNukeAllButton.Click += new System.EventHandler(this.DevNukeAll);
            // 
            // devNewAllButton
            // 
            this.devNewAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.devNewAllButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.devNewAllButton.Location = new System.Drawing.Point(328, 3);
            this.devNewAllButton.Name = "devNewAllButton";
            this.devNewAllButton.Size = new System.Drawing.Size(97, 46);
            this.devNewAllButton.TabIndex = 20;
            this.devNewAllButton.Text = "[DEV] New All";
            this.devNewAllButton.UseVisualStyleBackColor = true;
            this.devNewAllButton.Visible = false;
            this.devNewAllButton.Click += new System.EventHandler(this.DevNewAll);
            // 
            // devDictEditButton
            // 
            this.devDictEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.devDictEditButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.devDictEditButton.Location = new System.Drawing.Point(431, 3);
            this.devDictEditButton.Name = "devDictEditButton";
            this.devDictEditButton.Size = new System.Drawing.Size(90, 46);
            this.devDictEditButton.TabIndex = 19;
            this.devDictEditButton.Text = "[DEV] DictEdit";
            this.devDictEditButton.UseVisualStyleBackColor = true;
            this.devDictEditButton.Visible = false;
            this.devDictEditButton.Click += new System.EventHandler(this.DevDictEdit);
            // 
            // multiDisplayBox
            // 
            this.multiDisplayBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiDisplayBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.multiDisplayBox.FormattingEnabled = true;
            this.multiDisplayBox.Items.AddRange(new object[] {
            "Only modify primary display",
            "Blank other screens",
            "Mirror primary screen",
            "Freeze secondary screens"});
            this.multiDisplayBox.Location = new System.Drawing.Point(143, 256);
            this.multiDisplayBox.Name = "multiDisplayBox";
            this.multiDisplayBox.Size = new System.Drawing.Size(370, 21);
            this.multiDisplayBox.TabIndex = 18;
            this.multiDisplayBox.SelectedIndexChanged += new System.EventHandler(this.MultiDisplaySetup);
            // 
            // multiDisplayLabel
            // 
            this.multiDisplayLabel.AutoSize = true;
            this.multiDisplayLabel.Location = new System.Drawing.Point(17, 259);
            this.multiDisplayLabel.Name = "multiDisplayLabel";
            this.multiDisplayLabel.Size = new System.Drawing.Size(116, 13);
            this.multiDisplayLabel.TabIndex = 17;
            this.multiDisplayLabel.Text = "Multi-monitor behaviour";
            // 
            // configEditingButtonsFlowPanel
            // 
            this.configEditingButtonsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configEditingButtonsFlowPanel.Controls.Add(this.resetButton);
            this.configEditingButtonsFlowPanel.Controls.Add(this.resetHackButton);
            this.configEditingButtonsFlowPanel.Controls.Add(this.addCfg);
            this.configEditingButtonsFlowPanel.Controls.Add(this.removeCfg);
            this.configEditingButtonsFlowPanel.Controls.Add(this.saveCfg);
            this.configEditingButtonsFlowPanel.Controls.Add(this.loadCfg);
            this.configEditingButtonsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.configEditingButtonsFlowPanel.Location = new System.Drawing.Point(226, 97);
            this.configEditingButtonsFlowPanel.Name = "configEditingButtonsFlowPanel";
            this.configEditingButtonsFlowPanel.Size = new System.Drawing.Size(305, 91);
            this.configEditingButtonsFlowPanel.TabIndex = 16;
            // 
            // resetButton
            // 
            this.resetButton.Enabled = false;
            this.resetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resetButton.Location = new System.Drawing.Point(3, 65);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(141, 23);
            this.resetButton.TabIndex = 12;
            this.resetButton.Text = "Reset everything [?]";
            this.helpTip.SetToolTip(this.resetButton, "Reset all settings in this configuration");
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ConfigHackEraser);
            // 
            // resetHackButton
            // 
            this.resetHackButton.Enabled = false;
            this.resetHackButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resetHackButton.Location = new System.Drawing.Point(3, 36);
            this.resetHackButton.Name = "resetHackButton";
            this.resetHackButton.Size = new System.Drawing.Size(141, 23);
            this.resetHackButton.TabIndex = 13;
            this.resetHackButton.Text = "Reset hacks [?]";
            this.helpTip.SetToolTip(this.resetHackButton, "Deletes any custom hacks for this configuration");
            this.resetHackButton.UseVisualStyleBackColor = true;
            this.resetHackButton.Click += new System.EventHandler(this.ResetConfig);
            // 
            // addCfg
            // 
            this.addCfg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addCfg.Location = new System.Drawing.Point(3, 7);
            this.addCfg.Name = "addCfg";
            this.addCfg.Size = new System.Drawing.Size(141, 23);
            this.addCfg.TabIndex = 14;
            this.addCfg.Text = "Add configuration [?]";
            this.helpTip.SetToolTip(this.addCfg, resources.GetString("addCfg.ToolTip"));
            this.addCfg.UseVisualStyleBackColor = true;
            this.addCfg.Click += new System.EventHandler(this.AddConfig);
            // 
            // removeCfg
            // 
            this.removeCfg.Enabled = false;
            this.removeCfg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.removeCfg.Location = new System.Drawing.Point(150, 65);
            this.removeCfg.Name = "removeCfg";
            this.removeCfg.Size = new System.Drawing.Size(145, 23);
            this.removeCfg.TabIndex = 15;
            this.removeCfg.Text = "Remove configuration [?]";
            this.helpTip.SetToolTip(this.removeCfg, "Removes the configuration, meaning it will no longer be accessible in the main me" +
        "nu or any other part of the program.");
            this.removeCfg.UseVisualStyleBackColor = true;
            this.removeCfg.Click += new System.EventHandler(this.ConfigEraser);
            // 
            // saveCfg
            // 
            this.saveCfg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveCfg.Location = new System.Drawing.Point(150, 36);
            this.saveCfg.Name = "saveCfg";
            this.saveCfg.Size = new System.Drawing.Size(145, 23);
            this.saveCfg.TabIndex = 16;
            this.saveCfg.Text = "Save configurations [?]";
            this.helpTip.SetToolTip(this.saveCfg, "Allows you to save all of these configurations into a file, that can be loaded la" +
        "ter.");
            this.saveCfg.UseVisualStyleBackColor = true;
            this.saveCfg.Click += new System.EventHandler(this.SaveConfig);
            // 
            // loadCfg
            // 
            this.loadCfg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadCfg.Location = new System.Drawing.Point(150, 7);
            this.loadCfg.Name = "loadCfg";
            this.loadCfg.Size = new System.Drawing.Size(145, 23);
            this.loadCfg.TabIndex = 17;
            this.loadCfg.Text = "Load configurations [?]";
            this.helpTip.SetToolTip(this.loadCfg, "Allows you to load configurations from a file. BSSP 1.x files also supported.");
            this.loadCfg.UseVisualStyleBackColor = true;
            this.loadCfg.Click += new System.EventHandler(this.BrowseConfig);
            // 
            // osName
            // 
            this.osName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.osName.Location = new System.Drawing.Point(226, 64);
            this.osName.Name = "osName";
            this.osName.Size = new System.Drawing.Size(295, 30);
            this.osName.TabIndex = 11;
            this.osName.Text = "Select a configuration to modify/remove it";
            // 
            // configList
            // 
            this.configList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.configList.FormattingEnabled = true;
            this.configList.ItemHeight = 20;
            this.configList.Location = new System.Drawing.Point(20, 64);
            this.configList.Name = "configList";
            this.configList.ScrollAlwaysVisible = true;
            this.configList.Size = new System.Drawing.Size(200, 124);
            this.configList.TabIndex = 9;
            this.configList.SelectedIndexChanged += new System.EventHandler(this.ConfigSelector);
            // 
            // eggHunterButton
            // 
            this.eggHunterButton.AutoSize = true;
            this.eggHunterButton.Checked = true;
            this.eggHunterButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eggHunterButton.Location = new System.Drawing.Point(20, 232);
            this.eggHunterButton.Name = "eggHunterButton";
            this.eggHunterButton.Size = new System.Drawing.Size(132, 17);
            this.eggHunterButton.TabIndex = 8;
            this.eggHunterButton.Text = "Enable easter eggs [?]";
            this.helpTip.SetToolTip(this.eggHunterButton, "Turns on/off secret functionality in the program");
            this.eggHunterButton.UseVisualStyleBackColor = true;
            this.eggHunterButton.CheckedChanged += new System.EventHandler(this.EggHunter);
            // 
            // simulatorSettingsNotice
            // 
            this.simulatorSettingsNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simulatorSettingsNotice.Location = new System.Drawing.Point(17, 309);
            this.simulatorSettingsNotice.Name = "simulatorSettingsNotice";
            this.simulatorSettingsNotice.Size = new System.Drawing.Size(496, 43);
            this.simulatorSettingsNotice.TabIndex = 7;
            this.simulatorSettingsNotice.Text = "Scaling mode does not affect modern Windows blue screens, as they use the native " +
    "resolution of your monitor without scaling. Setting up multi-monitor behaviour i" +
    "s recommended for prank/stealth modes.";
            // 
            // scalingModeBox
            // 
            this.scalingModeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scalingModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scalingModeBox.FormattingEnabled = true;
            this.scalingModeBox.Items.AddRange(new object[] {
            "Bicubic (default, has artifacts)",
            "Bilinear (looks blurry, no artifacting)",
            "Nearest neighbour (sharpest, but blocky)",
            "Alternate bicubic (less artifacting)",
            "Alternate bilinear (sharper)"});
            this.scalingModeBox.Location = new System.Drawing.Point(143, 285);
            this.scalingModeBox.Name = "scalingModeBox";
            this.scalingModeBox.Size = new System.Drawing.Size(370, 21);
            this.scalingModeBox.TabIndex = 6;
            this.helpTip.SetToolTip(this.scalingModeBox, "Specifies how blue screens in full screen mode should be scaled. Bicubic scaling " +
        "is recommended.");
            this.scalingModeBox.SelectedIndexChanged += new System.EventHandler(this.ScalingModeSetup);
            // 
            // scalingModeLabel
            // 
            this.scalingModeLabel.AutoSize = true;
            this.scalingModeLabel.Location = new System.Drawing.Point(17, 288);
            this.scalingModeLabel.Name = "scalingModeLabel";
            this.scalingModeLabel.Size = new System.Drawing.Size(120, 13);
            this.scalingModeLabel.TabIndex = 5;
            this.scalingModeLabel.Text = "Fullscreen scaling mode";
            // 
            // hideInFullscreenButton
            // 
            this.hideInFullscreenButton.AutoSize = true;
            this.hideInFullscreenButton.Checked = true;
            this.hideInFullscreenButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideInFullscreenButton.Location = new System.Drawing.Point(20, 209);
            this.hideInFullscreenButton.Name = "hideInFullscreenButton";
            this.hideInFullscreenButton.Size = new System.Drawing.Size(288, 17);
            this.hideInFullscreenButton.TabIndex = 4;
            this.hideInFullscreenButton.Text = "Hide cursor when displaying a fullscreen blue screen [?]";
            this.helpTip.SetToolTip(this.hideInFullscreenButton, "Hides Windows cursor from the simulated blue screen");
            this.hideInFullscreenButton.UseVisualStyleBackColor = true;
            this.hideInFullscreenButton.CheckedChanged += new System.EventHandler(this.CursorVisibilitySetup);
            // 
            // configListHeading
            // 
            this.configListHeading.AutoSize = true;
            this.configListHeading.Location = new System.Drawing.Point(17, 48);
            this.configListHeading.Name = "configListHeading";
            this.configListHeading.Size = new System.Drawing.Size(119, 13);
            this.configListHeading.TabIndex = 3;
            this.configListHeading.Text = "Available configurations";
            // 
            // simulatorSettingsHeading
            // 
            this.simulatorSettingsHeading.AutoSize = true;
            this.simulatorSettingsHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.simulatorSettingsHeading.Location = new System.Drawing.Point(16, 16);
            this.simulatorSettingsHeading.Name = "simulatorSettingsHeading";
            this.simulatorSettingsHeading.Size = new System.Drawing.Size(136, 20);
            this.simulatorSettingsHeading.TabIndex = 1;
            this.simulatorSettingsHeading.Text = "Simulator settings";
            // 
            // helpPanel
            // 
            this.helpPanel.Controls.Add(this.helpPanelChild);
            this.helpPanel.Location = new System.Drawing.Point(4, 22);
            this.helpPanel.Name = "helpPanel";
            this.helpPanel.Size = new System.Drawing.Size(534, 352);
            this.helpPanel.TabIndex = 2;
            this.helpPanel.Text = "Help";
            this.helpPanel.UseVisualStyleBackColor = true;
            // 
            // helpPanelChild
            // 
            this.helpPanelChild.Controls.Add(this.helpButtonsFlowPanel);
            this.helpPanelChild.Controls.Add(this.helpDisplay);
            this.helpPanelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpPanelChild.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.helpPanelChild.Location = new System.Drawing.Point(0, 0);
            this.helpPanelChild.Name = "helpPanelChild";
            this.helpPanelChild.Size = new System.Drawing.Size(534, 352);
            this.helpPanelChild.TabIndex = 2;
            // 
            // helpButtonsFlowPanel
            // 
            this.helpButtonsFlowPanel.Controls.Add(this.howToGetHelpButton);
            this.helpButtonsFlowPanel.Controls.Add(this.purposesOfThisProgramButton);
            this.helpButtonsFlowPanel.Controls.Add(this.systemRequirementsButton);
            this.helpButtonsFlowPanel.Controls.Add(this.button1);
            this.helpButtonsFlowPanel.Location = new System.Drawing.Point(3, 3);
            this.helpButtonsFlowPanel.Name = "helpButtonsFlowPanel";
            this.helpButtonsFlowPanel.Size = new System.Drawing.Size(534, 37);
            this.helpButtonsFlowPanel.TabIndex = 1;
            // 
            // howToGetHelpButton
            // 
            this.howToGetHelpButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.howToGetHelpButton.Location = new System.Drawing.Point(8, 6);
            this.howToGetHelpButton.Margin = new System.Windows.Forms.Padding(8, 6, 3, 3);
            this.howToGetHelpButton.Name = "howToGetHelpButton";
            this.howToGetHelpButton.Size = new System.Drawing.Size(104, 23);
            this.howToGetHelpButton.TabIndex = 0;
            this.howToGetHelpButton.Text = "How to get help";
            this.howToGetHelpButton.UseVisualStyleBackColor = true;
            this.howToGetHelpButton.Click += new System.EventHandler(this.QuickHelp_Help);
            // 
            // purposesOfThisProgramButton
            // 
            this.purposesOfThisProgramButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.purposesOfThisProgramButton.Location = new System.Drawing.Point(117, 6);
            this.purposesOfThisProgramButton.Margin = new System.Windows.Forms.Padding(2, 6, 3, 3);
            this.purposesOfThisProgramButton.Name = "purposesOfThisProgramButton";
            this.purposesOfThisProgramButton.Size = new System.Drawing.Size(141, 23);
            this.purposesOfThisProgramButton.TabIndex = 1;
            this.purposesOfThisProgramButton.Text = "Purposes of this program";
            this.purposesOfThisProgramButton.UseVisualStyleBackColor = true;
            this.purposesOfThisProgramButton.Click += new System.EventHandler(this.QuickHelp_Purpose);
            // 
            // systemRequirementsButton
            // 
            this.systemRequirementsButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.systemRequirementsButton.Location = new System.Drawing.Point(263, 6);
            this.systemRequirementsButton.Margin = new System.Windows.Forms.Padding(2, 6, 3, 3);
            this.systemRequirementsButton.Name = "systemRequirementsButton";
            this.systemRequirementsButton.Size = new System.Drawing.Size(122, 23);
            this.systemRequirementsButton.TabIndex = 2;
            this.systemRequirementsButton.Text = "System requirements";
            this.systemRequirementsButton.UseVisualStyleBackColor = true;
            this.systemRequirementsButton.Click += new System.EventHandler(this.QuickHelp_SystemRequirements);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(390, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 6, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "User manual";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UserManualButtonClick);
            // 
            // helpDisplay
            // 
            this.helpDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.helpDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.helpDisplay.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.helpDisplay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.helpDisplay.Location = new System.Drawing.Point(0, 43);
            this.helpDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.helpDisplay.Multiline = true;
            this.helpDisplay.Name = "helpDisplay";
            this.helpDisplay.ReadOnly = true;
            this.helpDisplay.Size = new System.Drawing.Size(534, 286);
            this.helpDisplay.TabIndex = 0;
            // 
            // commandLinePanel
            // 
            this.commandLinePanel.Controls.Add(this.commandLineHelpDisplay);
            this.commandLinePanel.Location = new System.Drawing.Point(4, 22);
            this.commandLinePanel.Name = "commandLinePanel";
            this.commandLinePanel.Size = new System.Drawing.Size(534, 352);
            this.commandLinePanel.TabIndex = 3;
            this.commandLinePanel.Text = "Command line help";
            this.commandLinePanel.UseVisualStyleBackColor = true;
            // 
            // commandLineHelpDisplay
            // 
            this.commandLineHelpDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.commandLineHelpDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.commandLineHelpDisplay.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.commandLineHelpDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandLineHelpDisplay.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.commandLineHelpDisplay.Location = new System.Drawing.Point(0, 0);
            this.commandLineHelpDisplay.Multiline = true;
            this.commandLineHelpDisplay.Name = "commandLineHelpDisplay";
            this.commandLineHelpDisplay.ReadOnly = true;
            this.commandLineHelpDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.commandLineHelpDisplay.ShortcutsEnabled = false;
            this.commandLineHelpDisplay.Size = new System.Drawing.Size(534, 352);
            this.commandLineHelpDisplay.TabIndex = 0;
            this.commandLineHelpDisplay.WordWrap = false;
            // 
            // updateCheckerTimer
            // 
            this.updateCheckerTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // saveBsconfig
            // 
            this.saveBsconfig.Filter = "Bluescreen simulator 2.x configuration files|*.bs2cfg;*.bs2";
            // 
            // loadBsconfig
            // 
            this.loadBsconfig.Filter = "All bluescreen simulator plus configuration files|*.bscfg;*.bs2cfg;*.bsc;*.bs2|Bl" +
    "uescreen simulator 2.x configuration files|*.bs2cfg;*.bs2|Blue screen simulator " +
    "1.x configuration files|*.bscfg;*.bsc";
            this.loadBsconfig.Title = "Load bluescreen configuration";
            // 
            // AboutSettingsDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 384);
            this.Controls.Add(this.aboutSettingsTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(564, 423);
            this.Name = "AboutSettingsDialog";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitMe);
            this.Load += new System.EventHandler(this.SetInitalInterface);
            this.Resize += new System.EventHandler(this.OnMeResized);
            this.aboutTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.logoDisplayFlowPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.markusSoftwareLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veriFileLogo)).EndInit();
            this.aboutSettingsTabControl.ResumeLayout(false);
            this.aboutPanel.ResumeLayout(false);
            this.updatePanel.ResumeLayout(false);
            this.updatePanel.PerformLayout();
            this.updateTimeFlowPanel.ResumeLayout(false);
            this.updateTimeFlowPanel.PerformLayout();
            this.updateSettingsFlowPanel.ResumeLayout(false);
            this.updateSettingsFlowPanel.PerformLayout();
            this.simulatorSettingsPanel.ResumeLayout(false);
            this.simulatorSettingsPanel.PerformLayout();
            this.configEditingButtonsFlowPanel.ResumeLayout(false);
            this.helpPanel.ResumeLayout(false);
            this.helpPanelChild.ResumeLayout(false);
            this.helpPanelChild.PerformLayout();
            this.helpButtonsFlowPanel.ResumeLayout(false);
            this.commandLinePanel.ResumeLayout(false);
            this.commandLinePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel aboutTable;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TabControl aboutSettingsTabControl;
        private System.Windows.Forms.TabPage aboutPanel;
        private System.Windows.Forms.TabPage updatePanel;
        private System.Windows.Forms.TabPage helpPanel;
        private System.Windows.Forms.TabPage commandLinePanel;
        private System.Windows.Forms.Button updateCheckButton;
        private System.Windows.Forms.ToolTip helpTip;
        private System.Windows.Forms.Button unsignButton;
        private System.Windows.Forms.Label updateTimeLabel;
        private System.Windows.Forms.Label updateSettingsLabel;
        private System.Windows.Forms.FlowLayoutPanel updateTimeFlowPanel;
        private System.Windows.Forms.RadioButton updateImmediatelyRadio;
        private System.Windows.Forms.RadioButton updateOnCloseRadio;
        private System.Windows.Forms.CheckBox hashBox;
        private System.Windows.Forms.FlowLayoutPanel updateSettingsFlowPanel;
        private System.Windows.Forms.RadioButton autoUpdateRadio;
        private System.Windows.Forms.RadioButton noUpdatesRadio;
        private System.Windows.Forms.Label updatePanelHeading;
        private System.Windows.Forms.TabPage simulatorSettingsPanel;
        private System.Windows.Forms.ComboBox scalingModeBox;
        private System.Windows.Forms.Label scalingModeLabel;
        private System.Windows.Forms.CheckBox hideInFullscreenButton;
        private System.Windows.Forms.Label configListHeading;
        private System.Windows.Forms.Label simulatorSettingsHeading;
        private System.Windows.Forms.TextBox commandLineHelpDisplay;
        private System.Windows.Forms.FlowLayoutPanel helpButtonsFlowPanel;
        private System.Windows.Forms.Button howToGetHelpButton;
        private System.Windows.Forms.TextBox helpDisplay;
        private System.Windows.Forms.Button purposesOfThisProgramButton;
        private System.Windows.Forms.Button systemRequirementsButton;
        private System.Windows.Forms.Timer updateCheckerTimer;
        private System.Windows.Forms.Label noticeLabel;
        private System.Windows.Forms.Label simulatorSettingsNotice;
        private System.Windows.Forms.CheckBox eggHunterButton;
        private System.Windows.Forms.FlowLayoutPanel logoDisplayFlowPanel;
        private System.Windows.Forms.PictureBox markusSoftwareLogo;
        private System.Windows.Forms.PictureBox veriFileLogo;
        private System.Windows.Forms.FlowLayoutPanel helpPanelChild;
        private System.Windows.Forms.ListBox configList;
        private System.Windows.Forms.Label osName;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button resetHackButton;
        private System.Windows.Forms.FlowLayoutPanel configEditingButtonsFlowPanel;
        private System.Windows.Forms.Button addCfg;
        private System.Windows.Forms.Button removeCfg;
        private System.Windows.Forms.ComboBox multiDisplayBox;
        private System.Windows.Forms.Label multiDisplayLabel;
        private System.Windows.Forms.Button saveCfg;
        private System.Windows.Forms.SaveFileDialog saveBsconfig;
        internal System.Windows.Forms.OpenFileDialog loadBsconfig;
        internal System.Windows.Forms.Button loadCfg;
        private System.Windows.Forms.Button devNewAllButton;
        private System.Windows.Forms.Button devDictEditButton;
        private System.Windows.Forms.Button devNukeAllButton;
        private System.Windows.Forms.TextBox primaryServerBox;
        private System.Windows.Forms.Label primaryServerLabel;
        private System.Windows.Forms.Button primaryServerButton;
        private System.Windows.Forms.Button backupServerButton;
        private System.Windows.Forms.Button customServerButton;
        private System.Windows.Forms.Button button1;
    }
}
