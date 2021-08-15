
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
            this.templatePicker = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.osBox = new System.Windows.Forms.TextBox();
            this.friendlyBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.iconBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            "Windows NT 3.x/4.0",
            "Windows 2000",
            "Windows XP",
            "Windows Vista/7",
            "Windows Boot Manager",
            "Windows 8/8.1",
            "Windows 10",
            "Windows 11"});
            this.templatePicker.Location = new System.Drawing.Point(12, 26);
            this.templatePicker.Name = "templatePicker";
            this.templatePicker.Size = new System.Drawing.Size(357, 21);
            this.templatePicker.TabIndex = 0;
            this.templatePicker.SelectedIndexChanged += new System.EventHandler(this.TemplatePicker_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "OS name";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Friendly name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Icon";
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(297, 182);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "&OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(216, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Template:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 148);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(212, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Specify your own OS (DANGEROUS!!!)";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // AddBluescreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 217);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.iconBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.friendlyBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.osBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.templatePicker);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(240, 247);
            this.Name = "AddBluescreen";
            this.Text = "Add error screen";
            this.Load += new System.EventHandler(this.AddBluescreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox templatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox osBox;
        private System.Windows.Forms.TextBox friendlyBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox iconBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}