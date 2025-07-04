
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBluescreen));
            this.templateLabel = new MaterialSkin.Controls.MaterialLabel();
            this.osNameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.friendlyNameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.iconLabel = new MaterialSkin.Controls.MaterialLabel();
            this.specifyOsBox = new MaterialSkin.Controls.MaterialCheckbox();
            this.okButton = new MaterialSkin.Controls.MaterialButton();
            this.cancelButton = new MaterialSkin.Controls.MaterialButton();
            this.templatePicker = new MaterialSkin.Controls.MaterialComboBox();
            this.iconBox = new MaterialSkin.Controls.MaterialComboBox();
            this.friendlyBox = new MaterialSkin.Controls.MaterialTextBox();
            this.osBox = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // templateLabel
            // 
            this.templateLabel.AutoSize = true;
            this.templateLabel.Depth = 0;
            this.templateLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.templateLabel.Location = new System.Drawing.Point(11, 73);
            this.templateLabel.MouseState = MaterialSkin.MouseState.HOVER;
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
            this.osNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
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
            this.friendlyNameLabel.MouseState = MaterialSkin.MouseState.HOVER;
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
            this.iconLabel.MouseState = MaterialSkin.MouseState.HOVER;
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
            this.specifyOsBox.MouseState = MaterialSkin.MouseState.HOVER;
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
            this.okButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.okButton.Depth = 0;
            this.okButton.HighEmphasis = true;
            this.okButton.Icon = null;
            this.okButton.Location = new System.Drawing.Point(367, 327);
            this.okButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.okButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.okButton.Name = "okButton";
            this.okButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.okButton.Size = new System.Drawing.Size(64, 36);
            this.okButton.TabIndex = 13;
            this.okButton.Text = "&OK";
            this.okButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.okButton.UseAccentColor = false;
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.MakeBluescreen);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.cancelButton.Depth = 0;
            this.cancelButton.HighEmphasis = true;
            this.cancelButton.Icon = null;
            this.cancelButton.Location = new System.Drawing.Point(272, 327);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancelButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.cancelButton.Size = new System.Drawing.Size(87, 36);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
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
            "Windows 11"});
            this.templatePicker.Location = new System.Drawing.Point(15, 95);
            this.templatePicker.MaxDropDownItems = 4;
            this.templatePicker.MouseState = MaterialSkin.MouseState.OUT;
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
            this.iconBox.MouseState = MaterialSkin.MouseState.OUT;
            this.iconBox.Name = "iconBox";
            this.iconBox.Size = new System.Drawing.Size(121, 35);
            this.iconBox.StartIndex = 0;
            this.iconBox.TabIndex = 16;
            this.iconBox.UseTallSize = false;
            // 
            // friendlyBox
            // 
            this.friendlyBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.friendlyBox.AnimateReadOnly = false;
            this.friendlyBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendlyBox.Depth = 0;
            this.friendlyBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.friendlyBox.LeadingIcon = null;
            this.friendlyBox.Location = new System.Drawing.Point(128, 182);
            this.friendlyBox.MaxLength = 50;
            this.friendlyBox.MouseState = MaterialSkin.MouseState.OUT;
            this.friendlyBox.Multiline = false;
            this.friendlyBox.Name = "friendlyBox";
            this.friendlyBox.Size = new System.Drawing.Size(301, 36);
            this.friendlyBox.TabIndex = 17;
            this.friendlyBox.Text = "";
            this.friendlyBox.TrailingIcon = null;
            this.friendlyBox.UseTallSize = false;
            // 
            // osBox
            // 
            this.osBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.osBox.AnimateReadOnly = false;
            this.osBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.osBox.Depth = 0;
            this.osBox.Enabled = false;
            this.osBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.osBox.LeadingIcon = null;
            this.osBox.Location = new System.Drawing.Point(128, 140);
            this.osBox.MaxLength = 50;
            this.osBox.MouseState = MaterialSkin.MouseState.OUT;
            this.osBox.Multiline = false;
            this.osBox.Name = "osBox";
            this.osBox.Size = new System.Drawing.Size(301, 36);
            this.osBox.TabIndex = 18;
            this.osBox.Text = "";
            this.osBox.TrailingIcon = null;
            this.osBox.UseTallSize = false;
            this.osBox.TextChanged += new System.EventHandler(this.JustifyWindowsWarriors);
            // 
            // AddBluescreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 372);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel templateLabel;
        private MaterialSkin.Controls.MaterialLabel osNameLabel;
        private MaterialSkin.Controls.MaterialLabel friendlyNameLabel;
        private MaterialSkin.Controls.MaterialLabel iconLabel;
        private MaterialSkin.Controls.MaterialCheckbox specifyOsBox;
        private MaterialSkin.Controls.MaterialButton okButton;
        private MaterialSkin.Controls.MaterialButton cancelButton;
        private MaterialSkin.Controls.MaterialComboBox templatePicker;
        private MaterialSkin.Controls.MaterialComboBox iconBox;
        private MaterialSkin.Controls.MaterialTextBox friendlyBox;
        private MaterialSkin.Controls.MaterialTextBox osBox;
    }
}