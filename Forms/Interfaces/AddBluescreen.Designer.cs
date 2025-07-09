
namespace UltimateBlueScreenSimulator
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBluescreen));
            this.templateLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.osNameLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.friendlyNameLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.iconLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.specifyOsBox = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.okButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.cancelButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.templatePicker = new MaterialSkin2Framework.Controls.MaterialComboBox();
            this.iconBox = new MaterialSkin2Framework.Controls.MaterialComboBox();
            this.friendlyBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.osBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AllIcons = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // templateLabel
            // 
            this.templateLabel.AutoSize = true;
            this.templateLabel.Depth = 0;
            this.templateLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.templateLabel.Location = new System.Drawing.Point(11, 73);
            this.templateLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.templateLabel.Name = "templateLabel";
            this.templateLabel.Size = new System.Drawing.Size(72, 19);
            this.templateLabel.TabIndex = 11;
            this.templateLabel.Text = "Template:";
            // 
            // osNameLabel
            // 
            this.osNameLabel.AutoSize = true;
            this.osNameLabel.Depth = 0;
            this.osNameLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.osNameLabel.Location = new System.Drawing.Point(12, 150);
            this.osNameLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.osNameLabel.Name = "osNameLabel";
            this.osNameLabel.Size = new System.Drawing.Size(66, 19);
            this.osNameLabel.TabIndex = 11;
            this.osNameLabel.Text = "OS name";
            // 
            // friendlyNameLabel
            // 
            this.friendlyNameLabel.AutoSize = true;
            this.friendlyNameLabel.Depth = 0;
            this.friendlyNameLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.friendlyNameLabel.Location = new System.Drawing.Point(12, 190);
            this.friendlyNameLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.friendlyNameLabel.Name = "friendlyNameLabel";
            this.friendlyNameLabel.Size = new System.Drawing.Size(101, 19);
            this.friendlyNameLabel.TabIndex = 11;
            this.friendlyNameLabel.Text = "Friendly name";
            // 
            // iconLabel
            // 
            this.iconLabel.AutoSize = true;
            this.iconLabel.Depth = 0;
            this.iconLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.iconLabel.Location = new System.Drawing.Point(12, 233);
            this.iconLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.iconLabel.Name = "iconLabel";
            this.iconLabel.Size = new System.Drawing.Size(31, 19);
            this.iconLabel.TabIndex = 11;
            this.iconLabel.Text = "Icon";
            // 
            // specifyOsBox
            // 
            this.specifyOsBox.AutoSize = true;
            this.specifyOsBox.Depth = 0;
            this.specifyOsBox.Location = new System.Drawing.Point(4, 276);
            this.specifyOsBox.Margin = new System.Windows.Forms.Padding(0);
            this.specifyOsBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.specifyOsBox.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.specifyOsBox.Name = "specifyOsBox";
            this.specifyOsBox.ReadOnly = false;
            this.specifyOsBox.Ripple = true;
            this.specifyOsBox.Size = new System.Drawing.Size(302, 37);
            this.specifyOsBox.TabIndex = 12;
            this.specifyOsBox.Text = "Specify your own OS (DANGEROUS!!!)";
            this.specifyOsBox.UseVisualStyleBackColor = true;
            this.specifyOsBox.CheckedChanged += new System.EventHandler(this.ConfirmCustomOS);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.okButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.okButton.Depth = 0;
            this.okButton.HighEmphasis = true;
            this.okButton.Icon = null;
            this.okButton.Location = new System.Drawing.Point(367, 327);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.okButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.okButton.Name = "okButton";
            this.okButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.okButton.Size = new System.Drawing.Size(64, 36);
            this.okButton.TabIndex = 13;
            this.okButton.Text = "&OK";
            this.okButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.okButton.UseAccentColor = false;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.MakeBluescreen);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.cancelButton.Depth = 0;
            this.cancelButton.HighEmphasis = true;
            this.cancelButton.Icon = null;
            this.cancelButton.Location = new System.Drawing.Point(272, 327);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancelButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.cancelButton.Size = new System.Drawing.Size(87, 36);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.cancelButton.UseAccentColor = false;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelClick);
            // 
            // templatePicker
            // 
            this.templatePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templatePicker.AutoResize = false;
            this.templatePicker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.templatePicker.Depth = 0;
            this.templatePicker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.templatePicker.DropDownHeight = 118;
            this.templatePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templatePicker.DropDownWidth = 121;
            this.templatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.templatePicker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.templatePicker.FormattingEnabled = true;
            this.templatePicker.IntegralHeight = false;
            this.templatePicker.ItemHeight = 29;
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
            "Windows 11",
            "Windows 11 Beta"});
            this.templatePicker.Location = new System.Drawing.Point(15, 95);
            this.templatePicker.MaxDropDownItems = 4;
            this.templatePicker.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.templatePicker.Name = "templatePicker";
            this.templatePicker.Size = new System.Drawing.Size(414, 35);
            this.templatePicker.StartIndex = 0;
            this.templatePicker.TabIndex = 15;
            this.templatePicker.UseTallSize = false;
            this.templatePicker.SelectedIndexChanged += new System.EventHandler(this.OSSelector);
            // 
            // iconBox
            // 
            this.iconBox.AutoResize = false;
            this.iconBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.iconBox.Depth = 0;
            this.iconBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.iconBox.DropDownHeight = 118;
            this.iconBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.iconBox.DropDownWidth = 121;
            this.iconBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.iconBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.iconBox.FormattingEnabled = true;
            this.iconBox.IntegralHeight = false;
            this.iconBox.ItemHeight = 29;
            this.iconBox.Items.AddRange(new object[] {
            "2D flag",
            "3D flag",
            "2D window",
            "3D window"});
            this.iconBox.Location = new System.Drawing.Point(128, 227);
            this.iconBox.MaxDropDownItems = 4;
            this.iconBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(140, 35);
            this.iconBox.StartIndex = 0;
            this.iconBox.TabIndex = 16;
            this.iconBox.UseTallSize = false;
            this.iconBox.SelectedIndexChanged += new System.EventHandler(this.iconBox_SelectedIndexChanged);
            // 
            // friendlyBox
            // 
            this.friendlyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyBox.AnimateReadOnly = false;
            this.friendlyBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.friendlyBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.friendlyBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.friendlyBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.friendlyBox.Depth = 0;
            this.friendlyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.friendlyBox.HideSelection = true;
            this.friendlyBox.LeadingIcon = null;
            this.friendlyBox.Location = new System.Drawing.Point(128, 182);
            this.friendlyBox.MaxLength = 50;
            this.friendlyBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.friendlyBox.Name = "friendlyBox";
            this.friendlyBox.PasswordChar = '\0';
            this.friendlyBox.PrefixSuffixText = null;
            this.friendlyBox.ReadOnly = false;
            this.friendlyBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.friendlyBox.SelectedText = "";
            this.friendlyBox.SelectionLength = 0;
            this.friendlyBox.SelectionStart = 0;
            this.friendlyBox.ShortcutsEnabled = true;
            this.friendlyBox.Size = new System.Drawing.Size(301, 36);
            this.friendlyBox.TabIndex = 17;
            this.friendlyBox.TabStop = false;
            this.friendlyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.friendlyBox.TrailingIcon = null;
            this.friendlyBox.UseSystemPasswordChar = false;
            this.friendlyBox.UseTallSize = false;
            // 
            // osBox
            // 
            this.osBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.osBox.AnimateReadOnly = false;
            this.osBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.osBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.osBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.osBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.osBox.Depth = 0;
            this.osBox.Enabled = false;
            this.osBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.osBox.HideSelection = true;
            this.osBox.LeadingIcon = null;
            this.osBox.Location = new System.Drawing.Point(128, 140);
            this.osBox.MaxLength = 50;
            this.osBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.osBox.Name = "osBox";
            this.osBox.PasswordChar = '\0';
            this.osBox.PrefixSuffixText = null;
            this.osBox.ReadOnly = false;
            this.osBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.osBox.SelectedText = "";
            this.osBox.SelectionLength = 0;
            this.osBox.SelectionStart = 0;
            this.osBox.ShortcutsEnabled = true;
            this.osBox.Size = new System.Drawing.Size(301, 36);
            this.osBox.TabIndex = 18;
            this.osBox.TabStop = false;
            this.osBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.osBox.TrailingIcon = null;
            this.osBox.UseSystemPasswordChar = false;
            this.osBox.UseTallSize = false;
            this.osBox.TextChanged += new System.EventHandler(this.JustifyWindowsWarriors);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(274, 236);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // AllIcons
            // 
            this.AllIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("AllIcons.ImageStream")));
            this.AllIcons.TransparentColor = System.Drawing.Color.Transparent;
            /*this.AllIcons.Images.SetKeyName(0, "artage-io-48148_1564916990.ico");
            this.AllIcons.Images.SetKeyName(1, "Tatice-Operating-Systems-Windows.ico");
            this.AllIcons.Images.SetKeyName(2, "Dakirby309-Windows-8-Metro-Folders-OS-Windows-8-Metro.ico");
            this.AllIcons.Images.SetKeyName(3, "new-windows-logo (2).ico");
            this.AllIcons.Images.SetKeyName(4, "string.png");
            this.AllIcons.Images.SetKeyName(5, "setting.png");
            this.AllIcons.Images.SetKeyName(6, "theming.png");*/
            // 
            // AddBluescreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 372);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.osBox);
            this.Controls.Add(this.friendlyBox);
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.templatePicker);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.specifyOsBox);
            this.Controls.Add(this.iconLabel);
            this.Controls.Add(this.friendlyNameLabel);
            this.Controls.Add(this.osNameLabel);
            this.Controls.Add(this.templateLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(313, 351);
            this.Name = "AddBluescreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add error screen";
            this.Load += new System.EventHandler(this.Initialize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddBluescreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin2Framework.Controls.MaterialLabel templateLabel;
        private MaterialSkin2Framework.Controls.MaterialLabel osNameLabel;
        private MaterialSkin2Framework.Controls.MaterialLabel friendlyNameLabel;
        private MaterialSkin2Framework.Controls.MaterialLabel iconLabel;
        private MaterialSkin2Framework.Controls.MaterialCheckbox specifyOsBox;
        private MaterialSkin2Framework.Controls.MaterialButton okButton;
        private MaterialSkin2Framework.Controls.MaterialButton cancelButton;
        private MaterialSkin2Framework.Controls.MaterialComboBox templatePicker;
        private MaterialSkin2Framework.Controls.MaterialComboBox iconBox;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 friendlyBox;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 osBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.ImageList AllIcons;
    }
}