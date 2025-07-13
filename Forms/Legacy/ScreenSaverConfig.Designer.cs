namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    partial class ScreenSaverConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenSaverConfig));
            this.multiDisplayBox = new System.Windows.Forms.ComboBox();
            this.multiDisplayLabel = new System.Windows.Forms.Label();
            this.eggHunterButton = new System.Windows.Forms.CheckBox();
            this.simulatorSettingsNotice = new System.Windows.Forms.Label();
            this.scalingModeBox = new System.Windows.Forms.ComboBox();
            this.scalingModeLabel = new System.Windows.Forms.Label();
            this.hideInFullscreenButton = new System.Windows.Forms.CheckBox();
            this.mouseMoveAutoExitCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.helpTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
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
            this.multiDisplayBox.Location = new System.Drawing.Point(135, 85);
            this.multiDisplayBox.Name = "multiDisplayBox";
            this.multiDisplayBox.Size = new System.Drawing.Size(198, 21);
            this.multiDisplayBox.TabIndex = 3;
            this.multiDisplayBox.SelectedIndexChanged += new System.EventHandler(this.MultiDisplaySetup);
            // 
            // multiDisplayLabel
            // 
            this.multiDisplayLabel.AutoSize = true;
            this.multiDisplayLabel.Location = new System.Drawing.Point(9, 88);
            this.multiDisplayLabel.Name = "multiDisplayLabel";
            this.multiDisplayLabel.Size = new System.Drawing.Size(116, 13);
            this.multiDisplayLabel.TabIndex = 24;
            this.multiDisplayLabel.Text = "Multi-monitor behaviour";
            // 
            // eggHunterButton
            // 
            this.eggHunterButton.AutoSize = true;
            this.eggHunterButton.Checked = true;
            this.eggHunterButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.eggHunterButton.Location = new System.Drawing.Point(12, 61);
            this.eggHunterButton.Name = "eggHunterButton";
            this.eggHunterButton.Size = new System.Drawing.Size(132, 17);
            this.eggHunterButton.TabIndex = 2;
            this.eggHunterButton.Text = "&Enable easter eggs [?]";
            this.helpTip.SetToolTip(this.eggHunterButton, "Turns on/off the fun stuff");
            this.eggHunterButton.UseVisualStyleBackColor = true;
            this.eggHunterButton.CheckedChanged += new System.EventHandler(this.EggHunterButton_CheckedChanged);
            // 
            // simulatorSettingsNotice
            // 
            this.simulatorSettingsNotice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simulatorSettingsNotice.Location = new System.Drawing.Point(9, 142);
            this.simulatorSettingsNotice.Name = "simulatorSettingsNotice";
            this.simulatorSettingsNotice.Size = new System.Drawing.Size(321, 61);
            this.simulatorSettingsNotice.TabIndex = 22;
            this.simulatorSettingsNotice.Text = "OS: {0}\r\nTemplate: {1}\r\nNote: To change template settings, you must generate anot" +
    "her screensaver file.";
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
            this.scalingModeBox.Location = new System.Drawing.Point(135, 114);
            this.scalingModeBox.Name = "scalingModeBox";
            this.scalingModeBox.Size = new System.Drawing.Size(198, 21);
            this.scalingModeBox.TabIndex = 4;
            this.helpTip.SetToolTip(this.scalingModeBox, "Specifies how crash screens in full screen mode should be scaled. Bicubic scaling " +
        "is recommended.");
            this.scalingModeBox.SelectedIndexChanged += new System.EventHandler(this.ScalingModeBox_SelectedIndexChanged);
            // 
            // scalingModeLabel
            // 
            this.scalingModeLabel.AutoSize = true;
            this.scalingModeLabel.Location = new System.Drawing.Point(9, 117);
            this.scalingModeLabel.Name = "scalingModeLabel";
            this.scalingModeLabel.Size = new System.Drawing.Size(120, 13);
            this.scalingModeLabel.TabIndex = 20;
            this.scalingModeLabel.Text = "Fullscreen scaling mode";
            // 
            // hideInFullscreenButton
            // 
            this.hideInFullscreenButton.AutoSize = true;
            this.hideInFullscreenButton.Checked = true;
            this.hideInFullscreenButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideInFullscreenButton.Location = new System.Drawing.Point(12, 38);
            this.hideInFullscreenButton.Name = "hideInFullscreenButton";
            this.hideInFullscreenButton.Size = new System.Drawing.Size(233, 17);
            this.hideInFullscreenButton.TabIndex = 1;
            this.hideInFullscreenButton.Text = "&Hide cursor when displaying a bugcheck [?]";
            this.helpTip.SetToolTip(this.hideInFullscreenButton, "Hides Windows cursor from the simulated crash screen");
            this.hideInFullscreenButton.UseVisualStyleBackColor = true;
            this.hideInFullscreenButton.CheckedChanged += new System.EventHandler(this.HideInFullscreenButton_CheckedChanged);
            // 
            // mouseMoveAutoExitCheckBox
            // 
            this.mouseMoveAutoExitCheckBox.AutoSize = true;
            this.mouseMoveAutoExitCheckBox.Location = new System.Drawing.Point(12, 15);
            this.mouseMoveAutoExitCheckBox.Name = "mouseMoveAutoExitCheckBox";
            this.mouseMoveAutoExitCheckBox.Size = new System.Drawing.Size(243, 17);
            this.mouseMoveAutoExitCheckBox.TabIndex = 0;
            this.mouseMoveAutoExitCheckBox.Text = "E&xit the simulation when moving the mouse [?]";
            this.helpTip.SetToolTip(this.mouseMoveAutoExitCheckBox, "Returns to desktop when you move the mouse cursor");
            this.mouseMoveAutoExitCheckBox.UseVisualStyleBackColor = true;
            this.mouseMoveAutoExitCheckBox.CheckedChanged += new System.EventHandler(this.MouseMoveAutoExitCheckBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(258, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "&OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(177, 206);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ScreenSaverConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 241);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.multiDisplayBox);
            this.Controls.Add(this.multiDisplayLabel);
            this.Controls.Add(this.eggHunterButton);
            this.Controls.Add(this.simulatorSettingsNotice);
            this.Controls.Add(this.scalingModeBox);
            this.Controls.Add(this.scalingModeLabel);
            this.Controls.Add(this.mouseMoveAutoExitCheckBox);
            this.Controls.Add(this.hideInFullscreenButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(274, 276);
            this.Name = "ScreenSaverConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Screen saver options";
            this.Load += new System.EventHandler(this.ScreenSaverConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox multiDisplayBox;
        private System.Windows.Forms.Label multiDisplayLabel;
        private System.Windows.Forms.CheckBox eggHunterButton;
        private System.Windows.Forms.Label simulatorSettingsNotice;
        private System.Windows.Forms.ComboBox scalingModeBox;
        private System.Windows.Forms.Label scalingModeLabel;
        private System.Windows.Forms.CheckBox hideInFullscreenButton;
        private System.Windows.Forms.CheckBox mouseMoveAutoExitCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip helpTip;
    }
}