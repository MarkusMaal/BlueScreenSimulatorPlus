namespace UltimateBlueScreenSimulator
{
    partial class WXBS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WXBS));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.waterMarkText = new System.Windows.Forms.Label();
            this.memCodes = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-13, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(9999, 9999);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.FlowLayoutPanel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 102F);
            this.label1.Location = new System.Drawing.Point(60, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(60, 0, 3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 80, 0, 0);
            this.label1.Size = new System.Drawing.Size(145, 260);
            this.label1.TabIndex = 0;
            this.label1.Text = ":(";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label2.Location = new System.Drawing.Point(3, 280);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(789, 74);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your PC ran into a problem and needs to restart. We\'re just\r\ncollecting some erro" +
    "r info, and then we\'ll restart for you.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.label3.Location = new System.Drawing.Point(3, 394);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 40, 3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(80, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(252, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "0% complete";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panel2);
            this.flowLayoutPanel2.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 471);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 40, 0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(9999, 459);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 212);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UltimateBlueScreenSimulator.Properties.Resources.bsodqr;
            this.pictureBox1.Location = new System.Drawing.Point(89, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(201, 440);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 280);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label5.Location = new System.Drawing.Point(3, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1000, 133);
            this.label5.TabIndex = 4;
            this.label5.Text = "If you call a support person, give them this info:\r\n\r\nStop code: ";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(714, 36);
            this.label4.TabIndex = 3;
            this.label4.Text = "For more information about this issue and possible fixes, visit http://windows.co" +
    "m/stopcode";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // waterMarkText
            // 
            this.waterMarkText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.waterMarkText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(163)))), ((int)(((byte)(230)))));
            this.waterMarkText.Location = new System.Drawing.Point(1050, 670);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(188, 20);
            this.waterMarkText.TabIndex = 4;
            this.waterMarkText.Text = "bluescreen simulator plus";
            // 
            // memCodes
            // 
            this.memCodes.AutoSize = true;
            this.memCodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.memCodes.Location = new System.Drawing.Point(-3, 1);
            this.memCodes.Name = "memCodes";
            this.memCodes.Size = new System.Drawing.Size(132, 60);
            this.memCodes.TabIndex = 5;
            this.memCodes.Text = "0x0000000000000000\r\n0x0000000000000000\r\n0x0000000000000000\r\n0x0000000000000000";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // WXBS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(113)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.memCodes);
            this.Controls.Add(this.waterMarkText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "WXBS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modern Windows blue screen simulator";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WXBS_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WXBS_FormClosed);
            this.Load += new System.EventHandler(this.WXBS_Load);
            this.Resize += new System.EventHandler(this.WXBS_Resize);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Label waterMarkText;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label memCodes;
        private System.Windows.Forms.Timer timer2;
    }
}