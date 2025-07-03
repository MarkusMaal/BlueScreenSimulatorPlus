namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    partial class AddBluescreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBluescreen));
            this.templatePicker = new System.Windows.Forms.ComboBox();
            this.osNameLabel = new System.Windows.Forms.Label();
            this.osBox = new System.Windows.Forms.TextBox();
            this.friendlyBox = new System.Windows.Forms.TextBox();
            this.friendlyNameLabel = new System.Windows.Forms.Label();
            this.iconLabel = new System.Windows.Forms.Label();
            this.iconBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.templateLabel = new System.Windows.Forms.Label();
            this.specifyOsBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // templatePicker
            // 
            this.templatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templatePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templatePicker.FormattingEnabled = true;
            this.templatePicker.Items.AddRange(new object[] {
            "Windows 1.x/2.x",
            "Windows 3.1x",
            "Windows 9x/Me",
            "Windows CE",
            "Windows NT 3.1",
            "Windows NT 3.x/4.0",
            "Windows 2000",
            "Windows XP",
            "Windows Vista",
            "Windows 7",
            "BOOTMGR",
            "Windows 8 Beta",
            "Windows 8/8.1",
            "Windows 10",
            "Windows 11"});
            this.templatePicker.Location = new System.Drawing.Point(12, 26);
            this.templatePicker.Name = "templatePicker";
            this.templatePicker.Size = new System.Drawing.Size(357, 21);
            this.templatePicker.TabIndex = 0;
            this.templatePicker.SelectedIndexChanged += new System.EventHandler(this.OSSelector);
            // 
            // osNameLabel
            // 
            this.osNameLabel.AutoSize = true;
            this.osNameLabel.Location = new System.Drawing.Point(10, 63);
            this.osNameLabel.Name = "osNameLabel";
            this.osNameLabel.Size = new System.Drawing.Size(51, 13);
            this.osNameLabel.TabIndex = 1;
            this.osNameLabel.Text = "OS name";
            // 
            // osBox
            // 
            this.osBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.osBox.Enabled = false;
            this.osBox.Location = new System.Drawing.Point(88, 60);
            this.osBox.Name = "osBox";
            this.osBox.Size = new System.Drawing.Size(282, 20);
            this.osBox.TabIndex = 2;
            this.osBox.TextChanged += new System.EventHandler(this.JustifyWindowsWarriors);
            // 
            // friendlyBox
            // 
            this.friendlyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyBox.Location = new System.Drawing.Point(88, 86);
            this.friendlyBox.Name = "friendlyBox";
            this.friendlyBox.Size = new System.Drawing.Size(282, 20);
            this.friendlyBox.TabIndex = 4;
            // 
            // friendlyNameLabel
            // 
            this.friendlyNameLabel.AutoSize = true;
            this.friendlyNameLabel.Location = new System.Drawing.Point(10, 89);
            this.friendlyNameLabel.Name = "friendlyNameLabel";
            this.friendlyNameLabel.Size = new System.Drawing.Size(72, 13);
            this.friendlyNameLabel.TabIndex = 3;
            this.friendlyNameLabel.Text = "Friendly name";
            // 
            // iconLabel
            // 
            this.iconLabel.AutoSize = true;
            this.iconLabel.Location = new System.Drawing.Point(10, 115);
            this.iconLabel.Name = "iconLabel";
            this.iconLabel.Size = new System.Drawing.Size(28, 13);
            this.iconLabel.TabIndex = 5;
            this.iconLabel.Text = "Icon";
            // 
            // iconBox
            // 
            this.iconBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iconBox.FormattingEnabled = true;
            this.iconBox.Items.AddRange(new object[] {
            "2D flag",
            "3D flag",
            "2D window",
            "3D window"});
            this.iconBox.Location = new System.Drawing.Point(88, 112);
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(99, 21);
            this.iconBox.TabIndex = 6;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(297, 182);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.MakeBluescreen);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(216, 182);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // templateLabel
            // 
            this.templateLabel.AutoSize = true;
            this.templateLabel.Location = new System.Drawing.Point(10, 9);
            this.templateLabel.Name = "templateLabel";
            this.templateLabel.Size = new System.Drawing.Size(54, 13);
            this.templateLabel.TabIndex = 9;
            this.templateLabel.Text = "Template:";
            // 
            // specifyOsBox
            // 
            this.specifyOsBox.AutoSize = true;
            this.specifyOsBox.Location = new System.Drawing.Point(12, 148);
            this.specifyOsBox.Name = "specifyOsBox";
            this.specifyOsBox.Size = new System.Drawing.Size(212, 17);
            this.specifyOsBox.TabIndex = 10;
            this.specifyOsBox.Text = "Specify your own OS (DANGEROUS!!!)";
            this.specifyOsBox.UseVisualStyleBackColor = true;
            this.specifyOsBox.CheckedChanged += new System.EventHandler(this.ConfirmCustomOS);
            // 
            // AddBluescreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(381, 217);
            this.Controls.Add(this.specifyOsBox);
            this.Controls.Add(this.templateLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.iconLabel);
            this.Controls.Add(this.friendlyBox);
            this.Controls.Add(this.friendlyNameLabel);
            this.Controls.Add(this.osBox);
            this.Controls.Add(this.osNameLabel);
            this.Controls.Add(this.templatePicker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 247);
            this.Name = "AddBluescreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add error screen";
            this.Load += new System.EventHandler(this.Initialize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox templatePicker;
        private System.Windows.Forms.Label osNameLabel;
        private System.Windows.Forms.TextBox osBox;
        private System.Windows.Forms.TextBox friendlyBox;
        private System.Windows.Forms.Label friendlyNameLabel;
        private System.Windows.Forms.Label iconLabel;
        private System.Windows.Forms.ComboBox iconBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label templateLabel;
        private System.Windows.Forms.CheckBox specifyOsBox;
    }
}