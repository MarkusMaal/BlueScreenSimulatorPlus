﻿
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;
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
            this.aboutSettingsTabControl = new MaterialSkin2Framework.Controls.MaterialTabControl();
            this.updatePanel = new System.Windows.Forms.TabPage();
            this.materialCard6 = new System.Windows.Forms.Panel();
            this.updatePanelHeading = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.customServerButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.updateSettingsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.autoUpdateRadio = new MaterialSkin2Framework.Controls.MaterialRadioButton();
            this.noUpdatesRadio = new MaterialSkin2Framework.Controls.MaterialRadioButton();
            this.primaryServerButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.hashBox = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.backupServerButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.updateTimeFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.updateImmediatelyRadio = new MaterialSkin2Framework.Controls.MaterialRadioButton();
            this.updateOnCloseRadio = new MaterialSkin2Framework.Controls.MaterialRadioButton();
            this.primaryServerBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.updateSettingsLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.primaryServerLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.updateTimeLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.noticeLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.unsignButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.updateCheckButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.simulatorSettingsPanel = new System.Windows.Forms.TabPage();
            this.label1 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialCard7 = new System.Windows.Forms.Panel();
            this.simulatorSettingsHeading = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.devFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.materialButton6 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.devSplashButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.devDictEditButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.devNewAllButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.materialButton7 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.materialButton4 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.devRestartApp = new MaterialSkin2Framework.Controls.MaterialButton();
            this.materialButton12 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.selectAllBox = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.configListHeading = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.randomnessCheckBox = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.hideInFullscreenButton = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.scalingModeLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.multiDisplayBox = new MaterialSkin2Framework.Controls.MaterialComboBox();
            this.scalingModeBox = new MaterialSkin2Framework.Controls.MaterialComboBox();
            this.multiDisplayLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.simulatorSettingsNotice = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.configEditingButtonsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.resetButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.resetHackButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.removeCfg = new MaterialSkin2Framework.Controls.MaterialButton();
            this.saveCfg = new MaterialSkin2Framework.Controls.MaterialButton();
            this.loadCfg = new MaterialSkin2Framework.Controls.MaterialButton();
            this.addCfg = new MaterialSkin2Framework.Controls.MaterialButton();
            this.autosaveCheck = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.eggHunterButton = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.osName = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.configList = new MaterialSkin2Framework.Controls.MaterialListBox();
            this.appearancePanel = new System.Windows.Forms.TabPage();
            this.legacyInterfaceCheck = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.materialButton10 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.materialButton9 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.materialButton11 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.materialButton8 = new MaterialSkin2Framework.Controls.MaterialButton();
            this.darkDetectCheck = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.materialSwitch1 = new MaterialSkin2Framework.Controls.MaterialSwitch();
            this.rtlSwitch = new MaterialSkin2Framework.Controls.MaterialSwitch();
            this.materialLabel2 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.primaryColorBox = new MaterialSkin2Framework.Controls.MaterialComboBox();
            this.accentBox = new MaterialSkin2Framework.Controls.MaterialComboBox();
            this.darkMode = new MaterialSkin2Framework.Controls.MaterialSwitch();
            this.helpTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveBsconfig = new System.Windows.Forms.SaveFileDialog();
            this.loadBsconfig = new System.Windows.Forms.OpenFileDialog();
            this.checkIfLoadedSaved = new System.Windows.Forms.Timer(this.components);
            this.demoReelTimer = new System.Windows.Forms.Timer(this.components);
            this.materialTabSelector1 = new MaterialSkin2Framework.Controls.MaterialTabSelector();
            this.aboutSettingsTabControl.SuspendLayout();
            this.updatePanel.SuspendLayout();
            this.materialCard6.SuspendLayout();
            this.updateSettingsFlowPanel.SuspendLayout();
            this.updateTimeFlowPanel.SuspendLayout();
            this.simulatorSettingsPanel.SuspendLayout();
            this.materialCard7.SuspendLayout();
            this.devFlowPanel.SuspendLayout();
            this.configEditingButtonsFlowPanel.SuspendLayout();
            this.appearancePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // aboutSettingsTabControl
            // 
            this.aboutSettingsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aboutSettingsTabControl.Controls.Add(this.updatePanel);
            this.aboutSettingsTabControl.Controls.Add(this.simulatorSettingsPanel);
            this.aboutSettingsTabControl.Controls.Add(this.appearancePanel);
            this.aboutSettingsTabControl.Depth = 0;
            this.aboutSettingsTabControl.Location = new System.Drawing.Point(4, 92);
            this.aboutSettingsTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.aboutSettingsTabControl.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.aboutSettingsTabControl.Multiline = true;
            this.aboutSettingsTabControl.Name = "aboutSettingsTabControl";
            this.aboutSettingsTabControl.Padding = new System.Drawing.Point(0, 0);
            this.aboutSettingsTabControl.SelectedIndex = 0;
            this.aboutSettingsTabControl.Size = new System.Drawing.Size(979, 633);
            this.aboutSettingsTabControl.TabIndex = 1;
            this.aboutSettingsTabControl.SelectedIndexChanged += new System.EventHandler(this.TabSwitcher);
            // 
            // updatePanel
            // 
            this.updatePanel.BackColor = System.Drawing.Color.White;
            this.updatePanel.Controls.Add(this.materialCard6);
            this.updatePanel.Location = new System.Drawing.Point(4, 25);
            this.updatePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.updatePanel.Name = "updatePanel";
            this.updatePanel.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.updatePanel.Size = new System.Drawing.Size(971, 604);
            this.updatePanel.TabIndex = 1;
            this.updatePanel.Text = "Update settings";
            // 
            // materialCard6
            // 
            this.materialCard6.Controls.Add(this.updatePanelHeading);
            this.materialCard6.Controls.Add(this.customServerButton);
            this.materialCard6.Controls.Add(this.updateSettingsFlowPanel);
            this.materialCard6.Controls.Add(this.primaryServerButton);
            this.materialCard6.Controls.Add(this.hashBox);
            this.materialCard6.Controls.Add(this.backupServerButton);
            this.materialCard6.Controls.Add(this.updateTimeFlowPanel);
            this.materialCard6.Controls.Add(this.primaryServerBox);
            this.materialCard6.Controls.Add(this.updateSettingsLabel);
            this.materialCard6.Controls.Add(this.primaryServerLabel);
            this.materialCard6.Controls.Add(this.updateTimeLabel);
            this.materialCard6.Controls.Add(this.noticeLabel);
            this.materialCard6.Controls.Add(this.unsignButton);
            this.materialCard6.Controls.Add(this.updateCheckButton);
            this.materialCard6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard6.Location = new System.Drawing.Point(4, 4);
            this.materialCard6.Margin = new System.Windows.Forms.Padding(0);
            this.materialCard6.Name = "materialCard6";
            this.materialCard6.Size = new System.Drawing.Size(963, 596);
            this.materialCard6.TabIndex = 15;
            // 
            // updatePanelHeading
            // 
            this.updatePanelHeading.AutoSize = true;
            this.updatePanelHeading.Depth = 0;
            this.updatePanelHeading.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.updatePanelHeading.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.H6;
            this.updatePanelHeading.Location = new System.Drawing.Point(13, 25);
            this.updatePanelHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.updatePanelHeading.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.updatePanelHeading.Name = "updatePanelHeading";
            this.updatePanelHeading.Size = new System.Drawing.Size(142, 24);
            this.updatePanelHeading.TabIndex = 0;
            this.updatePanelHeading.Text = "Update settings";
            // 
            // customServerButton
            // 
            this.customServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customServerButton.AutoSize = false;
            this.customServerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.customServerButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.customServerButton.Depth = 0;
            this.customServerButton.DrawShadows = false;
            this.customServerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.customServerButton.HighEmphasis = true;
            this.customServerButton.Icon = null;
            this.customServerButton.Location = new System.Drawing.Point(836, 369);
            this.customServerButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.customServerButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.customServerButton.Name = "customServerButton";
            this.customServerButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.customServerButton.Size = new System.Drawing.Size(108, 32);
            this.customServerButton.TabIndex = 13;
            this.customServerButton.Text = "Custom";
            this.helpTip.SetToolTip(this.customServerButton, "This is the last option. If the both servers are down, you can use another server" +
        ", which you can find on my blog if both links are down for some reason.");
            this.customServerButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.customServerButton.UseAccentColor = false;
            this.customServerButton.UseVisualStyleBackColor = true;
            this.customServerButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // updateSettingsFlowPanel
            // 
            this.updateSettingsFlowPanel.AutoSize = true;
            this.updateSettingsFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateSettingsFlowPanel.Controls.Add(this.autoUpdateRadio);
            this.updateSettingsFlowPanel.Controls.Add(this.noUpdatesRadio);
            this.updateSettingsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.updateSettingsFlowPanel.Location = new System.Drawing.Point(17, 85);
            this.updateSettingsFlowPanel.Margin = new System.Windows.Forms.Padding(0, 15, 4, 4);
            this.updateSettingsFlowPanel.Name = "updateSettingsFlowPanel";
            this.updateSettingsFlowPanel.Size = new System.Drawing.Size(540, 74);
            this.updateSettingsFlowPanel.TabIndex = 1;
            // 
            // autoUpdateRadio
            // 
            this.autoUpdateRadio.AutoSize = true;
            this.autoUpdateRadio.Checked = true;
            this.autoUpdateRadio.Depth = 0;
            this.autoUpdateRadio.Location = new System.Drawing.Point(0, 0);
            this.autoUpdateRadio.Margin = new System.Windows.Forms.Padding(0);
            this.autoUpdateRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.autoUpdateRadio.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.autoUpdateRadio.Name = "autoUpdateRadio";
            this.autoUpdateRadio.Ripple = true;
            this.autoUpdateRadio.Size = new System.Drawing.Size(540, 37);
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
            this.noUpdatesRadio.Depth = 0;
            this.noUpdatesRadio.Location = new System.Drawing.Point(0, 37);
            this.noUpdatesRadio.Margin = new System.Windows.Forms.Padding(0);
            this.noUpdatesRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.noUpdatesRadio.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.noUpdatesRadio.Name = "noUpdatesRadio";
            this.noUpdatesRadio.Ripple = true;
            this.noUpdatesRadio.Size = new System.Drawing.Size(313, 37);
            this.noUpdatesRadio.TabIndex = 1;
            this.noUpdatesRadio.Text = "Do not automatically check for updates";
            this.helpTip.SetToolTip(this.noUpdatesRadio, "Does not check for updates when launching the program. An advantage of this optio" +
        "n is when using read only media, as checking for updates requires the program to" +
        " download a file.");
            this.noUpdatesRadio.UseVisualStyleBackColor = true;
            // 
            // primaryServerButton
            // 
            this.primaryServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.primaryServerButton.AutoSize = false;
            this.primaryServerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.primaryServerButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.primaryServerButton.Depth = 0;
            this.primaryServerButton.DrawShadows = false;
            this.primaryServerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.primaryServerButton.HighEmphasis = true;
            this.primaryServerButton.Icon = null;
            this.primaryServerButton.Location = new System.Drawing.Point(598, 369);
            this.primaryServerButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.primaryServerButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.primaryServerButton.Name = "primaryServerButton";
            this.primaryServerButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.primaryServerButton.Size = new System.Drawing.Size(113, 32);
            this.primaryServerButton.TabIndex = 12;
            this.primaryServerButton.Text = "Primary";
            this.helpTip.SetToolTip(this.primaryServerButton, "This is the server you want to use most of the time.");
            this.primaryServerButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.primaryServerButton.UseAccentColor = false;
            this.primaryServerButton.UseVisualStyleBackColor = true;
            this.primaryServerButton.Click += new System.EventHandler(this.SetToPrimaryServer);
            // 
            // hashBox
            // 
            this.hashBox.AutoSize = true;
            this.hashBox.Checked = true;
            this.hashBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hashBox.Depth = 0;
            this.hashBox.Location = new System.Drawing.Point(16, 177);
            this.hashBox.Margin = new System.Windows.Forms.Padding(0);
            this.hashBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.hashBox.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.hashBox.Name = "hashBox";
            this.hashBox.ReadOnly = false;
            this.hashBox.Ripple = true;
            this.hashBox.Size = new System.Drawing.Size(285, 37);
            this.hashBox.TabIndex = 2;
            this.hashBox.Text = "Hashcheck downloaded updates [?]";
            this.helpTip.SetToolTip(this.hashBox, resources.GetString("hashBox.ToolTip"));
            this.hashBox.UseVisualStyleBackColor = true;
            this.hashBox.CheckedChanged += new System.EventHandler(this.HashcheckSetup);
            // 
            // backupServerButton
            // 
            this.backupServerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backupServerButton.AutoSize = false;
            this.backupServerButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.backupServerButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.backupServerButton.Depth = 0;
            this.backupServerButton.DrawShadows = false;
            this.backupServerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.backupServerButton.HighEmphasis = true;
            this.backupServerButton.Icon = null;
            this.backupServerButton.Location = new System.Drawing.Point(722, 369);
            this.backupServerButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.backupServerButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.backupServerButton.Name = "backupServerButton";
            this.backupServerButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.backupServerButton.Size = new System.Drawing.Size(104, 32);
            this.backupServerButton.TabIndex = 11;
            this.backupServerButton.Text = "Backup";
            this.helpTip.SetToolTip(this.backupServerButton, "This is the server you should use if the primary server is down.");
            this.backupServerButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.backupServerButton.UseAccentColor = false;
            this.backupServerButton.UseVisualStyleBackColor = true;
            this.backupServerButton.Click += new System.EventHandler(this.SetToBackupServer);
            // 
            // updateTimeFlowPanel
            // 
            this.updateTimeFlowPanel.AutoSize = true;
            this.updateTimeFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateTimeFlowPanel.Controls.Add(this.updateImmediatelyRadio);
            this.updateTimeFlowPanel.Controls.Add(this.updateOnCloseRadio);
            this.updateTimeFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.updateTimeFlowPanel.Location = new System.Drawing.Point(25, 261);
            this.updateTimeFlowPanel.Margin = new System.Windows.Forms.Padding(0, 15, 4, 4);
            this.updateTimeFlowPanel.Name = "updateTimeFlowPanel";
            this.updateTimeFlowPanel.Size = new System.Drawing.Size(589, 74);
            this.updateTimeFlowPanel.TabIndex = 3;
            // 
            // updateImmediatelyRadio
            // 
            this.updateImmediatelyRadio.AutoSize = true;
            this.updateImmediatelyRadio.Checked = true;
            this.updateImmediatelyRadio.Depth = 0;
            this.updateImmediatelyRadio.Location = new System.Drawing.Point(0, 0);
            this.updateImmediatelyRadio.Margin = new System.Windows.Forms.Padding(0);
            this.updateImmediatelyRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.updateImmediatelyRadio.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.updateImmediatelyRadio.Name = "updateImmediatelyRadio";
            this.updateImmediatelyRadio.Ripple = true;
            this.updateImmediatelyRadio.Size = new System.Drawing.Size(413, 37);
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
            this.updateOnCloseRadio.Depth = 0;
            this.updateOnCloseRadio.Location = new System.Drawing.Point(0, 37);
            this.updateOnCloseRadio.Margin = new System.Windows.Forms.Padding(0);
            this.updateOnCloseRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.updateOnCloseRadio.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.updateOnCloseRadio.Name = "updateOnCloseRadio";
            this.updateOnCloseRadio.Ripple = true;
            this.updateOnCloseRadio.Size = new System.Drawing.Size(589, 37);
            this.updateOnCloseRadio.TabIndex = 1;
            this.updateOnCloseRadio.Text = "Install updates once the program closes, if the user clicked \"Yes\" on the prompt";
            this.helpTip.SetToolTip(this.updateOnCloseRadio, "A more convienient option, which allows you to install updates after closing the " +
        "program.");
            this.updateOnCloseRadio.UseVisualStyleBackColor = true;
            // 
            // primaryServerBox
            // 
            this.primaryServerBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.primaryServerBox.AnimateReadOnly = false;
            this.primaryServerBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.primaryServerBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.primaryServerBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.primaryServerBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.primaryServerBox.Depth = 0;
            this.primaryServerBox.Enabled = false;
            this.primaryServerBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.primaryServerBox.HideSelection = true;
            this.primaryServerBox.LeadingIcon = null;
            this.primaryServerBox.Location = new System.Drawing.Point(25, 410);
            this.primaryServerBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.primaryServerBox.MaxLength = 50;
            this.primaryServerBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.primaryServerBox.Name = "primaryServerBox";
            this.primaryServerBox.PasswordChar = '\0';
            this.primaryServerBox.PrefixSuffixText = null;
            this.primaryServerBox.ReadOnly = false;
            this.primaryServerBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.primaryServerBox.SelectedText = "";
            this.primaryServerBox.SelectionLength = 0;
            this.primaryServerBox.SelectionStart = 0;
            this.primaryServerBox.ShortcutsEnabled = true;
            this.primaryServerBox.Size = new System.Drawing.Size(919, 36);
            this.primaryServerBox.TabIndex = 10;
            this.primaryServerBox.TabStop = false;
            this.primaryServerBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.primaryServerBox.TrailingIcon = null;
            this.primaryServerBox.UseSystemPasswordChar = false;
            this.primaryServerBox.UseTallSize = false;
            this.primaryServerBox.TextChanged += new System.EventHandler(this.ChangeUpdateServer);
            // 
            // updateSettingsLabel
            // 
            this.updateSettingsLabel.AutoSize = true;
            this.updateSettingsLabel.Depth = 0;
            this.updateSettingsLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.updateSettingsLabel.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.Caption;
            this.updateSettingsLabel.Location = new System.Drawing.Point(13, 66);
            this.updateSettingsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.updateSettingsLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.updateSettingsLabel.Name = "updateSettingsLabel";
            this.updateSettingsLabel.Size = new System.Drawing.Size(112, 14);
            this.updateSettingsLabel.TabIndex = 4;
            this.updateSettingsLabel.Text = "AutoUpdate settings";
            // 
            // primaryServerLabel
            // 
            this.primaryServerLabel.AutoSize = true;
            this.primaryServerLabel.Depth = 0;
            this.primaryServerLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.primaryServerLabel.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.Caption;
            this.primaryServerLabel.Location = new System.Drawing.Point(21, 383);
            this.primaryServerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.primaryServerLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.primaryServerLabel.Name = "primaryServerLabel";
            this.primaryServerLabel.Size = new System.Drawing.Size(90, 14);
            this.primaryServerLabel.TabIndex = 9;
            this.primaryServerLabel.Text = "Update server [?]";
            this.helpTip.SetToolTip(this.primaryServerLabel, "This is where the update files are downloaded from");
            // 
            // updateTimeLabel
            // 
            this.updateTimeLabel.AutoSize = true;
            this.updateTimeLabel.Depth = 0;
            this.updateTimeLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.updateTimeLabel.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.Caption;
            this.updateTimeLabel.Location = new System.Drawing.Point(21, 242);
            this.updateTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.updateTimeLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.updateTimeLabel.Name = "updateTimeLabel";
            this.updateTimeLabel.Size = new System.Drawing.Size(171, 14);
            this.updateTimeLabel.TabIndex = 5;
            this.updateTimeLabel.Text = "Choose when to install updates";
            // 
            // noticeLabel
            // 
            this.noticeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.noticeLabel.Depth = 0;
            this.noticeLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.noticeLabel.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.Caption;
            this.noticeLabel.Location = new System.Drawing.Point(254, 573);
            this.noticeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.noticeLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.noticeLabel.Name = "noticeLabel";
            this.noticeLabel.Size = new System.Drawing.Size(705, 22);
            this.noticeLabel.TabIndex = 8;
            this.noticeLabel.Text = "These settings will be saved once the program is closed.";
            this.noticeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // unsignButton
            // 
            this.unsignButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.unsignButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.unsignButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.unsignButton.Depth = 0;
            this.unsignButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.unsignButton.HighEmphasis = true;
            this.unsignButton.Icon = null;
            this.unsignButton.Location = new System.Drawing.Point(17, 533);
            this.unsignButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.unsignButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.unsignButton.Name = "unsignButton";
            this.unsignButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.unsignButton.Size = new System.Drawing.Size(193, 36);
            this.unsignButton.TabIndex = 6;
            this.unsignButton.Text = "Unsign this computer";
            this.helpTip.SetToolTip(this.unsignButton, "Removes the signature of this computer, which makes the first use dialog show up " +
        "again");
            this.unsignButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.unsignButton.UseAccentColor = false;
            this.unsignButton.UseVisualStyleBackColor = true;
            this.unsignButton.Click += new System.EventHandler(this.UnsignMe);
            // 
            // updateCheckButton
            // 
            this.updateCheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateCheckButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.updateCheckButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.updateCheckButton.Depth = 0;
            this.updateCheckButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.updateCheckButton.HighEmphasis = true;
            this.updateCheckButton.Icon = null;
            this.updateCheckButton.Location = new System.Drawing.Point(285, 533);
            this.updateCheckButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.updateCheckButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.updateCheckButton.Name = "updateCheckButton";
            this.updateCheckButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.updateCheckButton.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.updateCheckButton.Size = new System.Drawing.Size(168, 36);
            this.updateCheckButton.TabIndex = 7;
            this.updateCheckButton.Text = "Check for updates";
            this.helpTip.SetToolTip(this.updateCheckButton, "Checks for updates right away");
            this.updateCheckButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.updateCheckButton.UseAccentColor = false;
            this.updateCheckButton.UseVisualStyleBackColor = true;
            this.updateCheckButton.Click += new System.EventHandler(this.CheckForUpdates);
            // 
            // simulatorSettingsPanel
            // 
            this.simulatorSettingsPanel.BackColor = System.Drawing.Color.White;
            this.simulatorSettingsPanel.Controls.Add(this.label1);
            this.simulatorSettingsPanel.Controls.Add(this.materialCard7);
            this.simulatorSettingsPanel.Location = new System.Drawing.Point(4, 25);
            this.simulatorSettingsPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.simulatorSettingsPanel.Name = "simulatorSettingsPanel";
            this.simulatorSettingsPanel.Size = new System.Drawing.Size(971, 604);
            this.simulatorSettingsPanel.TabIndex = 4;
            this.simulatorSettingsPanel.Text = "Simulator settings";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Depth = 0;
            this.label1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(680, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 160);
            this.label1.TabIndex = 26;
            // 
            // materialCard7
            // 
            this.materialCard7.Controls.Add(this.simulatorSettingsHeading);
            this.materialCard7.Controls.Add(this.devFlowPanel);
            this.materialCard7.Controls.Add(this.selectAllBox);
            this.materialCard7.Controls.Add(this.configListHeading);
            this.materialCard7.Controls.Add(this.randomnessCheckBox);
            this.materialCard7.Controls.Add(this.hideInFullscreenButton);
            this.materialCard7.Controls.Add(this.scalingModeLabel);
            this.materialCard7.Controls.Add(this.multiDisplayBox);
            this.materialCard7.Controls.Add(this.scalingModeBox);
            this.materialCard7.Controls.Add(this.multiDisplayLabel);
            this.materialCard7.Controls.Add(this.simulatorSettingsNotice);
            this.materialCard7.Controls.Add(this.configEditingButtonsFlowPanel);
            this.materialCard7.Controls.Add(this.autosaveCheck);
            this.materialCard7.Controls.Add(this.eggHunterButton);
            this.materialCard7.Controls.Add(this.osName);
            this.materialCard7.Controls.Add(this.configList);
            this.materialCard7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard7.Location = new System.Drawing.Point(0, 0);
            this.materialCard7.Margin = new System.Windows.Forms.Padding(0);
            this.materialCard7.Name = "materialCard7";
            this.materialCard7.Size = new System.Drawing.Size(971, 604);
            this.materialCard7.TabIndex = 27;
            // 
            // simulatorSettingsHeading
            // 
            this.simulatorSettingsHeading.AutoSize = true;
            this.simulatorSettingsHeading.Depth = 0;
            this.simulatorSettingsHeading.Font = new System.Drawing.Font("Roboto Medium", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.simulatorSettingsHeading.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.H6;
            this.simulatorSettingsHeading.Location = new System.Drawing.Point(13, 25);
            this.simulatorSettingsHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.simulatorSettingsHeading.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.simulatorSettingsHeading.Name = "simulatorSettingsHeading";
            this.simulatorSettingsHeading.Size = new System.Drawing.Size(164, 24);
            this.simulatorSettingsHeading.TabIndex = 1;
            this.simulatorSettingsHeading.Text = "Simulator settings";
            // 
            // devFlowPanel
            // 
            this.devFlowPanel.AutoScroll = true;
            this.devFlowPanel.Controls.Add(this.materialButton6);
            this.devFlowPanel.Controls.Add(this.devSplashButton);
            this.devFlowPanel.Controls.Add(this.devDictEditButton);
            this.devFlowPanel.Controls.Add(this.devNewAllButton);
            this.devFlowPanel.Controls.Add(this.materialButton7);
            this.devFlowPanel.Controls.Add(this.materialButton4);
            this.devFlowPanel.Controls.Add(this.devRestartApp);
            this.devFlowPanel.Controls.Add(this.materialButton12);
            this.devFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.devFlowPanel.Location = new System.Drawing.Point(265, 4);
            this.devFlowPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.devFlowPanel.Name = "devFlowPanel";
            this.devFlowPanel.Size = new System.Drawing.Size(687, 85);
            this.devFlowPanel.TabIndex = 23;
            this.devFlowPanel.Visible = false;
            this.devFlowPanel.WrapContents = false;
            // 
            // materialButton6
            // 
            this.materialButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton6.CharacterCasing = MaterialSkin2Framework.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.materialButton6.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton6.Depth = 0;
            this.materialButton6.HighEmphasis = true;
            this.materialButton6.Icon = null;
            this.materialButton6.Location = new System.Drawing.Point(1259, 7);
            this.materialButton6.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.materialButton6.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton6.Name = "materialButton6";
            this.materialButton6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton6.Size = new System.Drawing.Size(277, 36);
            this.materialButton6.TabIndex = 25;
            this.materialButton6.Text = "[DEV] Serialize TemplateRegistry";
            this.materialButton6.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton6.UseAccentColor = false;
            this.materialButton6.UseVisualStyleBackColor = true;
            this.materialButton6.Click += new System.EventHandler(this.MaterialButton6_Click_1);
            // 
            // devSplashButton
            // 
            this.devSplashButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.devSplashButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.devSplashButton.CharacterCasing = MaterialSkin2Framework.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.devSplashButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.devSplashButton.Depth = 0;
            this.devSplashButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.devSplashButton.HighEmphasis = true;
            this.devSplashButton.Icon = null;
            this.devSplashButton.Location = new System.Drawing.Point(1074, 7);
            this.devSplashButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.devSplashButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.devSplashButton.Name = "devSplashButton";
            this.devSplashButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.devSplashButton.Size = new System.Drawing.Size(175, 36);
            this.devSplashButton.TabIndex = 22;
            this.devSplashButton.Text = "[DEV] Splash Screen";
            this.devSplashButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.devSplashButton.UseAccentColor = false;
            this.devSplashButton.UseVisualStyleBackColor = true;
            this.devSplashButton.Click += new System.EventHandler(this.DisplayDevSplashScreen);
            // 
            // devDictEditButton
            // 
            this.devDictEditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.devDictEditButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.devDictEditButton.CharacterCasing = MaterialSkin2Framework.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.devDictEditButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.devDictEditButton.Depth = 0;
            this.devDictEditButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.devDictEditButton.HighEmphasis = true;
            this.devDictEditButton.Icon = null;
            this.devDictEditButton.Location = new System.Drawing.Point(939, 7);
            this.devDictEditButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.devDictEditButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.devDictEditButton.Name = "devDictEditButton";
            this.devDictEditButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.devDictEditButton.Size = new System.Drawing.Size(125, 36);
            this.devDictEditButton.TabIndex = 19;
            this.devDictEditButton.Text = "[DEV] DictEdit";
            this.devDictEditButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.devDictEditButton.UseAccentColor = false;
            this.devDictEditButton.UseVisualStyleBackColor = true;
            this.devDictEditButton.Click += new System.EventHandler(this.DevDictEdit);
            // 
            // devNewAllButton
            // 
            this.devNewAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.devNewAllButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.devNewAllButton.CharacterCasing = MaterialSkin2Framework.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.devNewAllButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.devNewAllButton.Depth = 0;
            this.devNewAllButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.devNewAllButton.HighEmphasis = true;
            this.devNewAllButton.Icon = null;
            this.devNewAllButton.Location = new System.Drawing.Point(718, 7);
            this.devNewAllButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.devNewAllButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.devNewAllButton.Name = "devNewAllButton";
            this.devNewAllButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.devNewAllButton.Size = new System.Drawing.Size(211, 36);
            this.devNewAllButton.TabIndex = 20;
            this.devNewAllButton.Text = "[DEV] Default templates";
            this.devNewAllButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.devNewAllButton.UseAccentColor = false;
            this.devNewAllButton.UseVisualStyleBackColor = true;
            this.devNewAllButton.Click += new System.EventHandler(this.DevNewAll);
            // 
            // materialButton7
            // 
            this.materialButton7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton7.CharacterCasing = MaterialSkin2Framework.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.materialButton7.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton7.Depth = 0;
            this.materialButton7.HighEmphasis = true;
            this.materialButton7.Icon = null;
            this.materialButton7.Location = new System.Drawing.Point(529, 7);
            this.materialButton7.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.materialButton7.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton7.Name = "materialButton7";
            this.materialButton7.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton7.Size = new System.Drawing.Size(179, 36);
            this.materialButton7.TabIndex = 23;
            this.materialButton7.Text = "[DEV] Embedded data";
            this.materialButton7.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton7.UseAccentColor = false;
            this.materialButton7.UseVisualStyleBackColor = true;
            this.materialButton7.Click += new System.EventHandler(this.ShowEmbedded);
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.CharacterCasing = MaterialSkin2Framework.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.materialButton4.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = null;
            this.materialButton4.Location = new System.Drawing.Point(422, 7);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.materialButton4.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(97, 36);
            this.materialButton4.TabIndex = 24;
            this.materialButton4.Text = "[TEST] Gen";
            this.materialButton4.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            this.materialButton4.Click += new System.EventHandler(this.MaterialButton4_Click);
            // 
            // devRestartApp
            // 
            this.devRestartApp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.devRestartApp.CharacterCasing = MaterialSkin2Framework.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.devRestartApp.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.devRestartApp.Depth = 0;
            this.devRestartApp.HighEmphasis = true;
            this.devRestartApp.Icon = null;
            this.devRestartApp.Location = new System.Drawing.Point(191, 7);
            this.devRestartApp.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.devRestartApp.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.devRestartApp.Name = "devRestartApp";
            this.devRestartApp.NoAccentTextColor = System.Drawing.Color.Empty;
            this.devRestartApp.Size = new System.Drawing.Size(221, 36);
            this.devRestartApp.TabIndex = 23;
            this.devRestartApp.Text = "[DEV] Restart Application";
            this.devRestartApp.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.devRestartApp.UseAccentColor = false;
            this.devRestartApp.UseVisualStyleBackColor = true;
            this.devRestartApp.Click += new System.EventHandler(this.RestartAll);
            // 
            // materialButton12
            // 
            this.materialButton12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton12.CharacterCasing = MaterialSkin2Framework.Controls.MaterialButton.CharacterCasingEnum.Normal;
            this.materialButton12.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton12.Depth = 0;
            this.materialButton12.HighEmphasis = true;
            this.materialButton12.Icon = null;
            this.materialButton12.Location = new System.Drawing.Point(5, 7);
            this.materialButton12.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.materialButton12.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton12.Name = "materialButton12";
            this.materialButton12.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton12.Size = new System.Drawing.Size(176, 36);
            this.materialButton12.TabIndex = 26;
            this.materialButton12.Text = "[DEV] Perform tests";
            this.materialButton12.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton12.UseAccentColor = false;
            this.materialButton12.UseVisualStyleBackColor = true;
            this.materialButton12.Click += new System.EventHandler(this.MaterialButton12_Click);
            // 
            // selectAllBox
            // 
            this.selectAllBox.AutoSize = true;
            this.selectAllBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.selectAllBox.Depth = 0;
            this.selectAllBox.Location = new System.Drawing.Point(651, 319);
            this.selectAllBox.Margin = new System.Windows.Forms.Padding(0);
            this.selectAllBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.selectAllBox.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.selectAllBox.Name = "selectAllBox";
            this.selectAllBox.ReadOnly = false;
            this.selectAllBox.Ripple = true;
            this.selectAllBox.Size = new System.Drawing.Size(226, 37);
            this.selectAllBox.TabIndex = 25;
            this.selectAllBox.Text = "Select all configurations [?]";
            this.selectAllBox.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.helpTip.SetToolTip(this.selectAllBox, "Selects all configurations at once");
            this.selectAllBox.UseVisualStyleBackColor = true;
            this.selectAllBox.CheckedChanged += new System.EventHandler(this.SelectAllBox_CheckedChanged);
            // 
            // configListHeading
            // 
            this.configListHeading.AutoSize = true;
            this.configListHeading.Depth = 0;
            this.configListHeading.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.configListHeading.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.Caption;
            this.configListHeading.Location = new System.Drawing.Point(27, 71);
            this.configListHeading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.configListHeading.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.configListHeading.Name = "configListHeading";
            this.configListHeading.Size = new System.Drawing.Size(133, 14);
            this.configListHeading.TabIndex = 3;
            this.configListHeading.Text = "Available configurations";
            // 
            // randomnessCheckBox
            // 
            this.randomnessCheckBox.AutoSize = true;
            this.randomnessCheckBox.Depth = 0;
            this.randomnessCheckBox.Location = new System.Drawing.Point(17, 321);
            this.randomnessCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.randomnessCheckBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.randomnessCheckBox.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.randomnessCheckBox.Name = "randomnessCheckBox";
            this.randomnessCheckBox.ReadOnly = false;
            this.randomnessCheckBox.Ripple = true;
            this.randomnessCheckBox.Size = new System.Drawing.Size(447, 37);
            this.randomnessCheckBox.TabIndex = 24;
            this.randomnessCheckBox.Text = "Add randomness to progress counters in legacy configs [?]";
            this.helpTip.SetToolTip(this.randomnessCheckBox, resources.GetString("randomnessCheckBox.ToolTip"));
            this.randomnessCheckBox.UseVisualStyleBackColor = true;
            this.randomnessCheckBox.CheckedChanged += new System.EventHandler(this.RandomnessCheckBox_CheckedChanged);
            // 
            // hideInFullscreenButton
            // 
            this.hideInFullscreenButton.AutoSize = true;
            this.hideInFullscreenButton.Checked = true;
            this.hideInFullscreenButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideInFullscreenButton.Depth = 0;
            this.hideInFullscreenButton.Location = new System.Drawing.Point(17, 364);
            this.hideInFullscreenButton.Margin = new System.Windows.Forms.Padding(0);
            this.hideInFullscreenButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.hideInFullscreenButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.hideInFullscreenButton.Name = "hideInFullscreenButton";
            this.hideInFullscreenButton.ReadOnly = false;
            this.hideInFullscreenButton.Ripple = true;
            this.hideInFullscreenButton.Size = new System.Drawing.Size(433, 37);
            this.hideInFullscreenButton.TabIndex = 4;
            this.hideInFullscreenButton.Text = "Hide cursor when displaying a fullscreen crash screen [?]";
            this.helpTip.SetToolTip(this.hideInFullscreenButton, "Hides Windows cursor from the simulated bugcheck");
            this.hideInFullscreenButton.UseVisualStyleBackColor = true;
            this.hideInFullscreenButton.CheckedChanged += new System.EventHandler(this.CursorVisibilitySetup);
            // 
            // scalingModeLabel
            // 
            this.scalingModeLabel.AutoSize = true;
            this.scalingModeLabel.Depth = 0;
            this.scalingModeLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.scalingModeLabel.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.Caption;
            this.scalingModeLabel.Location = new System.Drawing.Point(27, 522);
            this.scalingModeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scalingModeLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.scalingModeLabel.Name = "scalingModeLabel";
            this.scalingModeLabel.Size = new System.Drawing.Size(132, 14);
            this.scalingModeLabel.TabIndex = 5;
            this.scalingModeLabel.Text = "Fullscreen scaling mode";
            // 
            // multiDisplayBox
            // 
            this.multiDisplayBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multiDisplayBox.AutoResize = false;
            this.multiDisplayBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.multiDisplayBox.Depth = 0;
            this.multiDisplayBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.multiDisplayBox.DropDownHeight = 118;
            this.multiDisplayBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.multiDisplayBox.DropDownWidth = 121;
            this.multiDisplayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.multiDisplayBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.multiDisplayBox.FormattingEnabled = true;
            this.multiDisplayBox.IntegralHeight = false;
            this.multiDisplayBox.ItemHeight = 29;
            this.multiDisplayBox.Items.AddRange(new object[] {
            "Only modify primary display",
            "Blank other screens",
            "Mirror primary screen",
            "Freeze secondary screens"});
            this.multiDisplayBox.Location = new System.Drawing.Point(233, 457);
            this.multiDisplayBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.multiDisplayBox.MaxDropDownItems = 4;
            this.multiDisplayBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.multiDisplayBox.Name = "multiDisplayBox";
            this.multiDisplayBox.Size = new System.Drawing.Size(700, 35);
            this.multiDisplayBox.StartIndex = 0;
            this.multiDisplayBox.TabIndex = 18;
            this.multiDisplayBox.UseTallSize = false;
            this.multiDisplayBox.SelectedIndexChanged += new System.EventHandler(this.MultiDisplaySetup);
            // 
            // scalingModeBox
            // 
            this.scalingModeBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scalingModeBox.AutoResize = false;
            this.scalingModeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.scalingModeBox.Depth = 0;
            this.scalingModeBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.scalingModeBox.DropDownHeight = 118;
            this.scalingModeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scalingModeBox.DropDownWidth = 121;
            this.scalingModeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.scalingModeBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.scalingModeBox.FormattingEnabled = true;
            this.scalingModeBox.IntegralHeight = false;
            this.scalingModeBox.ItemHeight = 29;
            this.scalingModeBox.Items.AddRange(new object[] {
            "Bicubic (default, has artifacts)",
            "Bilinear (looks blurry, no artifacting)",
            "Nearest neighbour (sharpest, but blocky)",
            "Alternate bicubic (less artifacting)",
            "Alternate bilinear (sharper)"});
            this.scalingModeBox.Location = new System.Drawing.Point(233, 508);
            this.scalingModeBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scalingModeBox.MaxDropDownItems = 4;
            this.scalingModeBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.scalingModeBox.Name = "scalingModeBox";
            this.scalingModeBox.Size = new System.Drawing.Size(700, 35);
            this.scalingModeBox.StartIndex = 0;
            this.scalingModeBox.TabIndex = 6;
            this.helpTip.SetToolTip(this.scalingModeBox, "Specifies how bugchecks in full screen mode should be scaled. Bicubic scaling is " +
        "recommended.");
            this.scalingModeBox.UseTallSize = false;
            this.scalingModeBox.SelectedIndexChanged += new System.EventHandler(this.ScalingModeSetup);
            // 
            // multiDisplayLabel
            // 
            this.multiDisplayLabel.AutoSize = true;
            this.multiDisplayLabel.Depth = 0;
            this.multiDisplayLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.multiDisplayLabel.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.Caption;
            this.multiDisplayLabel.Location = new System.Drawing.Point(27, 471);
            this.multiDisplayLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.multiDisplayLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.multiDisplayLabel.Name = "multiDisplayLabel";
            this.multiDisplayLabel.Size = new System.Drawing.Size(131, 14);
            this.multiDisplayLabel.TabIndex = 17;
            this.multiDisplayLabel.Text = "Multi-monitor behaviour";
            // 
            // simulatorSettingsNotice
            // 
            this.simulatorSettingsNotice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simulatorSettingsNotice.Depth = 0;
            this.simulatorSettingsNotice.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.simulatorSettingsNotice.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.Caption;
            this.simulatorSettingsNotice.Location = new System.Drawing.Point(27, 558);
            this.simulatorSettingsNotice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.simulatorSettingsNotice.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.simulatorSettingsNotice.Name = "simulatorSettingsNotice";
            this.simulatorSettingsNotice.Size = new System.Drawing.Size(904, 46);
            this.simulatorSettingsNotice.TabIndex = 7;
            this.simulatorSettingsNotice.Text = "Scaling mode does not affect modern Windows crash screens, as they use the native" +
    " resolution of your monitor without scaling. Setting up multi-monitor behaviour " +
    "is recommended for prank/stealth modes.";
            // 
            // configEditingButtonsFlowPanel
            // 
            this.configEditingButtonsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.configEditingButtonsFlowPanel.Controls.Add(this.resetButton);
            this.configEditingButtonsFlowPanel.Controls.Add(this.resetHackButton);
            this.configEditingButtonsFlowPanel.Controls.Add(this.removeCfg);
            this.configEditingButtonsFlowPanel.Controls.Add(this.saveCfg);
            this.configEditingButtonsFlowPanel.Controls.Add(this.loadCfg);
            this.configEditingButtonsFlowPanel.Controls.Add(this.addCfg);
            this.configEditingButtonsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.configEditingButtonsFlowPanel.Location = new System.Drawing.Point(415, 132);
            this.configEditingButtonsFlowPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.configEditingButtonsFlowPanel.Name = "configEditingButtonsFlowPanel";
            this.configEditingButtonsFlowPanel.Size = new System.Drawing.Size(539, 185);
            this.configEditingButtonsFlowPanel.TabIndex = 16;
            // 
            // resetButton
            // 
            this.resetButton.AutoSize = false;
            this.resetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.resetButton.Depth = 0;
            this.resetButton.Enabled = false;
            this.resetButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resetButton.HighEmphasis = true;
            this.resetButton.Icon = null;
            this.resetButton.Location = new System.Drawing.Point(5, 134);
            this.resetButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.resetButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.resetButton.Name = "resetButton";
            this.resetButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.resetButton.Size = new System.Drawing.Size(253, 44);
            this.resetButton.TabIndex = 12;
            this.resetButton.Text = "Reset everything [?]";
            this.helpTip.SetToolTip(this.resetButton, "Reset all settings in this configuration");
            this.resetButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.resetButton.UseAccentColor = true;
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ConfigHackEraser);
            // 
            // resetHackButton
            // 
            this.resetHackButton.AutoSize = false;
            this.resetHackButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetHackButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.resetHackButton.Depth = 0;
            this.resetHackButton.Enabled = false;
            this.resetHackButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.resetHackButton.HighEmphasis = true;
            this.resetHackButton.Icon = null;
            this.resetHackButton.Location = new System.Drawing.Point(5, 76);
            this.resetHackButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.resetHackButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.resetHackButton.Name = "resetHackButton";
            this.resetHackButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.resetHackButton.Size = new System.Drawing.Size(253, 44);
            this.resetHackButton.TabIndex = 13;
            this.resetHackButton.Text = "Reset hacks [?]";
            this.helpTip.SetToolTip(this.resetHackButton, "Deletes everything under the \'additional options\' menu for this configuration");
            this.resetHackButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.resetHackButton.UseAccentColor = true;
            this.resetHackButton.UseVisualStyleBackColor = true;
            this.resetHackButton.Click += new System.EventHandler(this.ResetConfig);
            // 
            // removeCfg
            // 
            this.removeCfg.AutoSize = false;
            this.removeCfg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.removeCfg.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.removeCfg.Depth = 0;
            this.removeCfg.Enabled = false;
            this.removeCfg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.removeCfg.HighEmphasis = true;
            this.removeCfg.Icon = null;
            this.removeCfg.Location = new System.Drawing.Point(5, 18);
            this.removeCfg.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.removeCfg.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.removeCfg.Name = "removeCfg";
            this.removeCfg.NoAccentTextColor = System.Drawing.Color.Empty;
            this.removeCfg.Size = new System.Drawing.Size(253, 44);
            this.removeCfg.TabIndex = 15;
            this.removeCfg.Text = "Remove config [?]";
            this.helpTip.SetToolTip(this.removeCfg, "Removes the configuration, meaning it will no longer be accessible in the main me" +
        "nu or any other part of the program.");
            this.removeCfg.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.removeCfg.UseAccentColor = true;
            this.removeCfg.UseVisualStyleBackColor = true;
            this.removeCfg.Click += new System.EventHandler(this.ConfigEraser);
            // 
            // saveCfg
            // 
            this.saveCfg.AutoSize = false;
            this.saveCfg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveCfg.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.saveCfg.Depth = 0;
            this.saveCfg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.saveCfg.HighEmphasis = true;
            this.saveCfg.Icon = null;
            this.saveCfg.Location = new System.Drawing.Point(276, 134);
            this.saveCfg.Margin = new System.Windows.Forms.Padding(13, 7, 5, 7);
            this.saveCfg.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.saveCfg.Name = "saveCfg";
            this.saveCfg.NoAccentTextColor = System.Drawing.Color.Empty;
            this.saveCfg.Size = new System.Drawing.Size(251, 44);
            this.saveCfg.TabIndex = 16;
            this.saveCfg.Text = "Save configs [?]";
            this.helpTip.SetToolTip(this.saveCfg, "Allows you to save all of these configurations into a file, that can be loaded la" +
        "ter.");
            this.saveCfg.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.saveCfg.UseAccentColor = false;
            this.saveCfg.UseVisualStyleBackColor = true;
            this.saveCfg.Click += new System.EventHandler(this.SaveConfig);
            // 
            // loadCfg
            // 
            this.loadCfg.AutoSize = false;
            this.loadCfg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadCfg.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.loadCfg.Depth = 0;
            this.loadCfg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loadCfg.HighEmphasis = true;
            this.loadCfg.Icon = null;
            this.loadCfg.Location = new System.Drawing.Point(276, 76);
            this.loadCfg.Margin = new System.Windows.Forms.Padding(13, 7, 5, 7);
            this.loadCfg.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.loadCfg.Name = "loadCfg";
            this.loadCfg.NoAccentTextColor = System.Drawing.Color.Empty;
            this.loadCfg.Size = new System.Drawing.Size(251, 44);
            this.loadCfg.TabIndex = 17;
            this.loadCfg.Text = "Load configs [?]";
            this.helpTip.SetToolTip(this.loadCfg, "Allows you to load configurations from a file. BSSP 1.x and 2.x files also suppor" +
        "ted.");
            this.loadCfg.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.loadCfg.UseAccentColor = false;
            this.loadCfg.UseVisualStyleBackColor = true;
            this.loadCfg.Click += new System.EventHandler(this.BrowseConfig);
            // 
            // addCfg
            // 
            this.addCfg.AutoSize = false;
            this.addCfg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addCfg.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.addCfg.Depth = 0;
            this.addCfg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addCfg.HighEmphasis = true;
            this.addCfg.Icon = null;
            this.addCfg.Location = new System.Drawing.Point(276, 18);
            this.addCfg.Margin = new System.Windows.Forms.Padding(13, 7, 5, 7);
            this.addCfg.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.addCfg.Name = "addCfg";
            this.addCfg.NoAccentTextColor = System.Drawing.Color.Empty;
            this.addCfg.Size = new System.Drawing.Size(251, 44);
            this.addCfg.TabIndex = 14;
            this.addCfg.Text = "Add configuration [?]";
            this.helpTip.SetToolTip(this.addCfg, resources.GetString("addCfg.ToolTip"));
            this.addCfg.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.addCfg.UseAccentColor = false;
            this.addCfg.UseVisualStyleBackColor = true;
            this.addCfg.Click += new System.EventHandler(this.AddConfig);
            // 
            // autosaveCheck
            // 
            this.autosaveCheck.AutoSize = true;
            this.autosaveCheck.Checked = true;
            this.autosaveCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autosaveCheck.Depth = 0;
            this.autosaveCheck.Location = new System.Drawing.Point(268, 405);
            this.autosaveCheck.Margin = new System.Windows.Forms.Padding(0);
            this.autosaveCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.autosaveCheck.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.autosaveCheck.Name = "autosaveCheck";
            this.autosaveCheck.ReadOnly = false;
            this.autosaveCheck.Ripple = true;
            this.autosaveCheck.Size = new System.Drawing.Size(159, 37);
            this.autosaveCheck.TabIndex = 8;
            this.autosaveCheck.Text = "Autosave/load [?]";
            this.helpTip.SetToolTip(this.autosaveCheck, "Automatically saves changes made to the simulator templates");
            this.autosaveCheck.UseVisualStyleBackColor = true;
            this.autosaveCheck.CheckedChanged += new System.EventHandler(this.AutosaveCheckChanged);
            // 
            // eggHunterButton
            // 
            this.eggHunterButton.AutoSize = true;
            this.eggHunterButton.Checked = true;
            this.eggHunterButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eggHunterButton.Depth = 0;
            this.eggHunterButton.Location = new System.Drawing.Point(17, 405);
            this.eggHunterButton.Margin = new System.Windows.Forms.Padding(0);
            this.eggHunterButton.MouseLocation = new System.Drawing.Point(-1, -1);
            this.eggHunterButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.eggHunterButton.Name = "eggHunterButton";
            this.eggHunterButton.ReadOnly = false;
            this.eggHunterButton.Ripple = true;
            this.eggHunterButton.Size = new System.Drawing.Size(188, 37);
            this.eggHunterButton.TabIndex = 8;
            this.eggHunterButton.Text = "Enable easter eggs [?]";
            this.helpTip.SetToolTip(this.eggHunterButton, "Turns on/off secret functionality in the program");
            this.eggHunterButton.UseVisualStyleBackColor = true;
            this.eggHunterButton.CheckedChanged += new System.EventHandler(this.EggHunter);
            // 
            // osName
            // 
            this.osName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.osName.BackColor = System.Drawing.Color.Transparent;
            this.osName.Depth = 0;
            this.osName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.osName.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.Body2;
            this.osName.Location = new System.Drawing.Point(415, 92);
            this.osName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.osName.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.osName.Name = "osName";
            this.osName.Size = new System.Drawing.Size(539, 47);
            this.osName.TabIndex = 11;
            this.osName.Text = "Select a configuration to modify/remove it";
            // 
            // configList
            // 
            this.configList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configList.BackColor = System.Drawing.Color.White;
            this.configList.BorderColor = System.Drawing.Color.LightGray;
            this.configList.Depth = 0;
            this.configList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.configList.Location = new System.Drawing.Point(28, 108);
            this.configList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.configList.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.configList.Name = "configList";
            this.configList.SelectedIndex = -1;
            this.configList.SelectedItem = null;
            this.configList.ShowScrollBar = true;
            this.configList.Size = new System.Drawing.Size(379, 197);
            this.configList.TabIndex = 9;
            this.configList.SelectedIndexChanged += new MaterialSkin2Framework.Controls.MaterialListBox.SelectedIndexChangedEventHandler(this.ConfigSelector);
            this.configList.DoubleClick += new System.EventHandler(this.ConfigList_DoubleClick);
            // 
            // appearancePanel
            // 
            this.appearancePanel.BackColor = System.Drawing.Color.White;
            this.appearancePanel.Controls.Add(this.legacyInterfaceCheck);
            this.appearancePanel.Controls.Add(this.materialButton10);
            this.appearancePanel.Controls.Add(this.materialButton9);
            this.appearancePanel.Controls.Add(this.materialButton11);
            this.appearancePanel.Controls.Add(this.materialButton8);
            this.appearancePanel.Controls.Add(this.darkDetectCheck);
            this.appearancePanel.Controls.Add(this.materialSwitch1);
            this.appearancePanel.Controls.Add(this.rtlSwitch);
            this.appearancePanel.Controls.Add(this.materialLabel2);
            this.appearancePanel.Controls.Add(this.materialLabel1);
            this.appearancePanel.Controls.Add(this.materialLabel3);
            this.appearancePanel.Controls.Add(this.materialLabel8);
            this.appearancePanel.Controls.Add(this.primaryColorBox);
            this.appearancePanel.Controls.Add(this.accentBox);
            this.appearancePanel.Controls.Add(this.darkMode);
            this.appearancePanel.Location = new System.Drawing.Point(4, 25);
            this.appearancePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.appearancePanel.Name = "appearancePanel";
            this.appearancePanel.Size = new System.Drawing.Size(971, 604);
            this.appearancePanel.TabIndex = 5;
            this.appearancePanel.Text = "Appearance";
            // 
            // legacyInterfaceCheck
            // 
            this.legacyInterfaceCheck.AutoSize = true;
            this.legacyInterfaceCheck.Depth = 0;
            this.legacyInterfaceCheck.Location = new System.Drawing.Point(27, 145);
            this.legacyInterfaceCheck.Margin = new System.Windows.Forms.Padding(0);
            this.legacyInterfaceCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.legacyInterfaceCheck.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.legacyInterfaceCheck.Name = "legacyInterfaceCheck";
            this.legacyInterfaceCheck.ReadOnly = false;
            this.legacyInterfaceCheck.Ripple = true;
            this.legacyInterfaceCheck.Size = new System.Drawing.Size(124, 37);
            this.legacyInterfaceCheck.TabIndex = 27;
            this.legacyInterfaceCheck.Text = "Classic UI [?]";
            this.helpTip.SetToolTip(this.legacyInterfaceCheck, "Enables the interface from previous versions, similar to 2.1 and earlier");
            this.legacyInterfaceCheck.UseVisualStyleBackColor = true;
            this.legacyInterfaceCheck.CheckedChanged += new System.EventHandler(this.LegacyInterfaceCheck_CheckedChanged);
            // 
            // materialButton10
            // 
            this.materialButton10.AutoSize = false;
            this.materialButton10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton10.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.materialButton10.Depth = 0;
            this.materialButton10.DrawShadows = false;
            this.materialButton10.HighEmphasis = true;
            this.materialButton10.Icon = null;
            this.materialButton10.Location = new System.Drawing.Point(604, 230);
            this.materialButton10.Margin = new System.Windows.Forms.Padding(1);
            this.materialButton10.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton10.Name = "materialButton10";
            this.materialButton10.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton10.Size = new System.Drawing.Size(43, 39);
            this.materialButton10.TabIndex = 18;
            this.helpTip.SetToolTip(this.materialButton10, "Accent color preview");
            this.materialButton10.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton10.UseAccentColor = true;
            this.materialButton10.UseVisualStyleBackColor = true;
            // 
            // materialButton9
            // 
            this.materialButton9.AutoSize = false;
            this.materialButton9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton9.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.materialButton9.Depth = 0;
            this.materialButton9.DrawShadows = false;
            this.materialButton9.HighEmphasis = true;
            this.materialButton9.Icon = null;
            this.materialButton9.Location = new System.Drawing.Point(556, 230);
            this.materialButton9.Margin = new System.Windows.Forms.Padding(1);
            this.materialButton9.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton9.Name = "materialButton9";
            this.materialButton9.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton9.Size = new System.Drawing.Size(43, 39);
            this.materialButton9.TabIndex = 18;
            this.helpTip.SetToolTip(this.materialButton9, "Primary color preview");
            this.materialButton9.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton9.UseAccentColor = false;
            this.materialButton9.UseVisualStyleBackColor = true;
            // 
            // materialButton11
            // 
            this.materialButton11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton11.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton11.Depth = 0;
            this.materialButton11.HighEmphasis = true;
            this.materialButton11.Icon = null;
            this.materialButton11.Location = new System.Drawing.Point(267, 284);
            this.materialButton11.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.materialButton11.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton11.Name = "materialButton11";
            this.materialButton11.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton11.Size = new System.Drawing.Size(102, 36);
            this.materialButton11.TabIndex = 17;
            this.materialButton11.Text = "Random [?]";
            this.helpTip.SetToolTip(this.materialButton11, "Automatically chooses a random primary and accent color");
            this.materialButton11.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton11.UseAccentColor = false;
            this.materialButton11.UseVisualStyleBackColor = true;
            this.materialButton11.Click += new System.EventHandler(this.MaterialButton11_Click);
            // 
            // materialButton8
            // 
            this.materialButton8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton8.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton8.Depth = 0;
            this.materialButton8.HighEmphasis = true;
            this.materialButton8.Icon = null;
            this.materialButton8.Location = new System.Drawing.Point(39, 284);
            this.materialButton8.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.materialButton8.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialButton8.Name = "materialButton8";
            this.materialButton8.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton8.Size = new System.Drawing.Size(163, 36);
            this.materialButton8.TabIndex = 17;
            this.materialButton8.Text = "Default colors [?]";
            this.helpTip.SetToolTip(this.materialButton8, "Restores primary color and accent color to default values");
            this.materialButton8.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton8.UseAccentColor = false;
            this.materialButton8.UseVisualStyleBackColor = true;
            this.materialButton8.Click += new System.EventHandler(this.MaterialButton8_Click);
            // 
            // darkDetectCheck
            // 
            this.darkDetectCheck.AutoSize = true;
            this.darkDetectCheck.Checked = true;
            this.darkDetectCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.darkDetectCheck.Depth = 0;
            this.darkDetectCheck.Location = new System.Drawing.Point(27, 105);
            this.darkDetectCheck.Margin = new System.Windows.Forms.Padding(0);
            this.darkDetectCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.darkDetectCheck.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.darkDetectCheck.Name = "darkDetectCheck";
            this.darkDetectCheck.ReadOnly = false;
            this.darkDetectCheck.Ripple = true;
            this.darkDetectCheck.Size = new System.Drawing.Size(251, 37);
            this.darkDetectCheck.TabIndex = 16;
            this.darkDetectCheck.Text = "Enable dark mode detection [?]";
            this.helpTip.SetToolTip(this.darkDetectCheck, "Automatically switches the program to night mode on startup if Windows is configu" +
        "red to use dark mode.");
            this.darkDetectCheck.UseVisualStyleBackColor = true;
            this.darkDetectCheck.CheckedChanged += new System.EventHandler(this.DarkDetectCheck_CheckedChanged);
            // 
            // materialSwitch1
            // 
            this.materialSwitch1.AutoSize = true;
            this.materialSwitch1.Checked = true;
            this.materialSwitch1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.materialSwitch1.Depth = 0;
            this.materialSwitch1.Location = new System.Drawing.Point(17, 402);
            this.materialSwitch1.Margin = new System.Windows.Forms.Padding(0);
            this.materialSwitch1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialSwitch1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialSwitch1.Name = "materialSwitch1";
            this.materialSwitch1.Ripple = true;
            this.materialSwitch1.Size = new System.Drawing.Size(136, 37);
            this.materialSwitch1.TabIndex = 15;
            this.materialSwitch1.Text = "Tooltips [?]";
            this.helpTip.SetToolTip(this.materialSwitch1, "Determines whether or not to display these popups when you hover over various con" +
        "trols");
            this.materialSwitch1.UseVisualStyleBackColor = true;
            this.materialSwitch1.CheckedChanged += new System.EventHandler(this.MaterialSwitch1_CheckedChanged);
            // 
            // rtlSwitch
            // 
            this.rtlSwitch.AutoSize = true;
            this.rtlSwitch.Depth = 0;
            this.rtlSwitch.Location = new System.Drawing.Point(19, 448);
            this.rtlSwitch.Margin = new System.Windows.Forms.Padding(0);
            this.rtlSwitch.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rtlSwitch.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.rtlSwitch.Name = "rtlSwitch";
            this.rtlSwitch.Ripple = true;
            this.rtlSwitch.Size = new System.Drawing.Size(159, 37);
            this.rtlSwitch.TabIndex = 15;
            this.rtlSwitch.Text = "Forced RTL [?]";
            this.helpTip.SetToolTip(this.rtlSwitch, "Forces right to left layout");
            this.rtlSwitch.UseVisualStyleBackColor = true;
            this.rtlSwitch.Visible = false;
            this.rtlSwitch.CheckedChanged += new System.EventHandler(this.RtlSwitch_CheckedChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.H5;
            this.materialLabel2.Location = new System.Drawing.Point(20, 356);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(136, 29);
            this.materialLabel2.TabIndex = 14;
            this.materialLabel2.Text = "Accessibility";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin2Framework.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(32, 23);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(94, 29);
            this.materialLabel1.TabIndex = 14;
            this.materialLabel1.Text = "Theming";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(35, 202);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(95, 19);
            this.materialLabel3.TabIndex = 13;
            this.materialLabel3.Text = "Primary color";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.Location = new System.Drawing.Point(295, 202);
            this.materialLabel8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel8.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(88, 19);
            this.materialLabel8.TabIndex = 13;
            this.materialLabel8.Text = "Accent color";
            // 
            // primaryColorBox
            // 
            this.primaryColorBox.AutoResize = false;
            this.primaryColorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.primaryColorBox.Depth = 0;
            this.primaryColorBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.primaryColorBox.DropDownHeight = 118;
            this.primaryColorBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.primaryColorBox.DropDownWidth = 121;
            this.primaryColorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.primaryColorBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.primaryColorBox.FormattingEnabled = true;
            this.primaryColorBox.IntegralHeight = false;
            this.primaryColorBox.ItemHeight = 29;
            this.primaryColorBox.Items.AddRange(new object[] {
            "Amber",
            "Blue",
            "Cyan",
            "Deep Orange",
            "Deep Purple",
            "Green",
            "Indigo",
            "Light Blue",
            "Light Green",
            "Lime",
            "Orange",
            "Pink",
            "Purple",
            "Red",
            "Teal",
            "Yellow"});
            this.primaryColorBox.Location = new System.Drawing.Point(39, 230);
            this.primaryColorBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.primaryColorBox.MaxDropDownItems = 4;
            this.primaryColorBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.primaryColorBox.Name = "primaryColorBox";
            this.primaryColorBox.Size = new System.Drawing.Size(251, 35);
            this.primaryColorBox.StartIndex = 0;
            this.primaryColorBox.TabIndex = 12;
            this.helpTip.SetToolTip(this.primaryColorBox, "Color of the titlebar and most buttons.");
            this.primaryColorBox.UseTallSize = false;
            this.primaryColorBox.SelectedIndexChanged += new System.EventHandler(this.MaterialComboBox1_SelectedIndexChanged);
            // 
            // accentBox
            // 
            this.accentBox.AutoResize = false;
            this.accentBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.accentBox.Depth = 0;
            this.accentBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.accentBox.DropDownHeight = 118;
            this.accentBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accentBox.DropDownWidth = 121;
            this.accentBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.accentBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.accentBox.FormattingEnabled = true;
            this.accentBox.IntegralHeight = false;
            this.accentBox.ItemHeight = 29;
            this.accentBox.Items.AddRange(new object[] {
            "Amber",
            "Blue",
            "Cyan",
            "Deep Orange",
            "Deep Purple",
            "Green",
            "Indigo",
            "Light Blue",
            "Light Green",
            "Lime",
            "Orange",
            "Pink",
            "Purple",
            "Red",
            "Teal",
            "Yellow"});
            this.accentBox.Location = new System.Drawing.Point(299, 230);
            this.accentBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.accentBox.MaxDropDownItems = 4;
            this.accentBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.accentBox.Name = "accentBox";
            this.accentBox.Size = new System.Drawing.Size(251, 35);
            this.accentBox.StartIndex = 0;
            this.accentBox.TabIndex = 12;
            this.helpTip.SetToolTip(this.accentBox, "Color of various highlights, such as checkboxes and important buttons");
            this.accentBox.UseTallSize = false;
            this.accentBox.SelectedIndexChanged += new System.EventHandler(this.AccentBox_SelectedIndexChanged);
            // 
            // darkMode
            // 
            this.darkMode.AutoSize = true;
            this.darkMode.Depth = 0;
            this.darkMode.Location = new System.Drawing.Point(27, 59);
            this.darkMode.Margin = new System.Windows.Forms.Padding(0);
            this.darkMode.MouseLocation = new System.Drawing.Point(-1, -1);
            this.darkMode.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.darkMode.Name = "darkMode";
            this.darkMode.Ripple = true;
            this.darkMode.Size = new System.Drawing.Size(160, 37);
            this.darkMode.TabIndex = 11;
            this.darkMode.Text = "Night mode [?]";
            this.helpTip.SetToolTip(this.darkMode, "Night mode applies a dark background color that is easier to look at in lower lig" +
        "ht levels");
            this.darkMode.UseVisualStyleBackColor = true;
            this.darkMode.CheckedChanged += new System.EventHandler(this.DarkMode_CheckedChanged);
            // 
            // helpTip
            // 
            this.helpTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.helpTip.ToolTipTitle = "Quick help";
            this.helpTip.Popup += new System.Windows.Forms.PopupEventHandler(this.HelpTip_Popup);
            // 
            // saveBsconfig
            // 
            this.saveBsconfig.Filter = "Bluescreen simulator 2.1 configuration files|*.bs2cfg;*.bs2|Bluescreen simulator " +
    "2.0 configuration files|*.bs2cfg;*.bs2|Bluescreen simulator 1.x configuration fi" +
    "les|*.bscfg;*.bsc";
            // 
            // loadBsconfig
            // 
            this.loadBsconfig.Filter = resources.GetString("loadBsconfig.Filter");
            this.loadBsconfig.Title = "Load bluescreen configuration";
            // 
            // checkIfLoadedSaved
            // 
            this.checkIfLoadedSaved.Tick += new System.EventHandler(this.WaitUntilComplete);
            // 
            // demoReelTimer
            // 
            this.demoReelTimer.Interval = 1000;
            this.demoReelTimer.Tick += new System.EventHandler(this.DemoReelTimer_Tick);
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabSelector1.BaseTabControl = this.aboutSettingsTabControl;
            this.materialTabSelector1.CharacterCasing = MaterialSkin2Framework.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTabSelector1.Location = new System.Drawing.Point(0, 30);
            this.materialTabSelector1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.materialTabSelector1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(1028, 59);
            this.materialTabSelector1.TabIndex = 2;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // AboutSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 729);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.aboutSettingsTabControl);
            this.DrawerTabControl = this.aboutSettingsTabControl;
            this.FormStyle = MaterialSkin2Framework.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(987, 714);
            this.Name = "AboutSettingsDialog";
            this.Padding = new System.Windows.Forms.Padding(4, 30, 4, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExitMe);
            this.Load += new System.EventHandler(this.SetInitalInterface);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AboutSettingsDialog_KeyDown);
            this.Resize += new System.EventHandler(this.OnMeResized);
            this.aboutSettingsTabControl.ResumeLayout(false);
            this.updatePanel.ResumeLayout(false);
            this.materialCard6.ResumeLayout(false);
            this.materialCard6.PerformLayout();
            this.updateSettingsFlowPanel.ResumeLayout(false);
            this.updateSettingsFlowPanel.PerformLayout();
            this.updateTimeFlowPanel.ResumeLayout(false);
            this.updateTimeFlowPanel.PerformLayout();
            this.simulatorSettingsPanel.ResumeLayout(false);
            this.materialCard7.ResumeLayout(false);
            this.materialCard7.PerformLayout();
            this.devFlowPanel.ResumeLayout(false);
            this.devFlowPanel.PerformLayout();
            this.configEditingButtonsFlowPanel.ResumeLayout(false);
            this.appearancePanel.ResumeLayout(false);
            this.appearancePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialTabControl aboutSettingsTabControl;
        private System.Windows.Forms.TabPage updatePanel;
        private MaterialButton updateCheckButton;
        private System.Windows.Forms.ToolTip helpTip;
        private MaterialButton unsignButton;
        private MaterialLabel updateTimeLabel;
        private MaterialLabel updateSettingsLabel;
        private System.Windows.Forms.FlowLayoutPanel updateTimeFlowPanel;
        private MaterialRadioButton updateImmediatelyRadio;
        private MaterialRadioButton updateOnCloseRadio;
        private MaterialCheckbox hashBox;
        private System.Windows.Forms.FlowLayoutPanel updateSettingsFlowPanel;
        private MaterialRadioButton autoUpdateRadio;
        private MaterialRadioButton noUpdatesRadio;
        private MaterialLabel updatePanelHeading;
        private MaterialComboBox scalingModeBox;
        private MaterialLabel scalingModeLabel;
        private MaterialCheckbox hideInFullscreenButton;
        private MaterialLabel configListHeading;
        private MaterialLabel simulatorSettingsHeading;
        private MaterialLabel noticeLabel;
        private MaterialLabel simulatorSettingsNotice;
        private MaterialCheckbox eggHunterButton;
        private MaterialSkin2Framework.Controls.MaterialListBox configList;
        private MaterialLabel osName;
        private MaterialButton resetButton;
        private MaterialButton resetHackButton;
        private System.Windows.Forms.FlowLayoutPanel configEditingButtonsFlowPanel;
        private MaterialButton addCfg;
        private MaterialButton removeCfg;
        private MaterialComboBox multiDisplayBox;
        private MaterialLabel multiDisplayLabel;
        private MaterialButton saveCfg; 
        private System.Windows.Forms.SaveFileDialog saveBsconfig;
        internal System.Windows.Forms.OpenFileDialog loadBsconfig;
        internal MaterialButton loadCfg;
        private MaterialButton devNewAllButton;
        private MaterialButton devDictEditButton;
        private MaterialTextBox2 primaryServerBox;
        private MaterialLabel primaryServerLabel;
        private MaterialButton primaryServerButton;
        private MaterialButton backupServerButton;
        private MaterialButton customServerButton;
        private MaterialButton devSplashButton;
        private System.Windows.Forms.FlowLayoutPanel devFlowPanel;
        private MaterialButton devRestartApp;
        private System.Windows.Forms.Timer checkIfLoadedSaved;
        private MaterialCheckbox randomnessCheckBox;
        private MaterialCheckbox selectAllBox;
        private MaterialLabel label1;
        private System.Windows.Forms.Panel materialCard6;
        private System.Windows.Forms.Panel materialCard7;
        private MaterialButton materialButton4;
        private System.Windows.Forms.TabPage appearancePanel;
        private MaterialLabel materialLabel1;
        private MaterialLabel materialLabel8;
        private MaterialComboBox accentBox;
        public MaterialSwitch darkMode;
        private MaterialSwitch materialSwitch1;
        private MaterialSwitch rtlSwitch;
        private MaterialLabel materialLabel2;
        private MaterialCheckbox darkDetectCheck;
        private MaterialButton materialButton6;
        private MaterialLabel materialLabel3;
        private MaterialComboBox primaryColorBox;
        private MaterialButton materialButton7;
        private MaterialCheckbox autosaveCheck;
        private System.Windows.Forms.Timer demoReelTimer;
        private MaterialButton materialButton8;
        private MaterialButton materialButton10;
        private MaterialButton materialButton9;
        private MaterialButton materialButton11;
        private MaterialCheckbox legacyInterfaceCheck;
        private MaterialButton materialButton12;
        private MaterialTabSelector materialTabSelector1;
        internal System.Windows.Forms.TabPage simulatorSettingsPanel;
    }
}
