namespace UltimateBlueScreenSimulator
{
    partial class SupportEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupportEditor));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.errorCode = new System.Windows.Forms.Label();
            this.supportInfo = new System.Windows.Forms.Label();
            this.technicalCode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.errorCode);
            this.flowLayoutPanel1.Controls.Add(this.textBox1);
            this.flowLayoutPanel1.Controls.Add(this.supportInfo);
            this.flowLayoutPanel1.Controls.Add(this.technicalCode);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(636, 448);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(615, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "A problem has been detected and Windows has been shut down to prevent damage\r\nto " +
    "your computer.";
            // 
            // errorCode
            // 
            this.errorCode.AutoSize = true;
            this.errorCode.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.errorCode.Location = new System.Drawing.Point(3, 48);
            this.errorCode.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.errorCode.Name = "errorCode";
            this.errorCode.Size = new System.Drawing.Size(383, 14);
            this.errorCode.TabIndex = 1;
            this.errorCode.Text = "The end-user manually generated the crash dump.";
            // 
            // supportInfo
            // 
            this.supportInfo.AutoSize = true;
            this.supportInfo.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.supportInfo.Location = new System.Drawing.Point(3, 290);
            this.supportInfo.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.supportInfo.Name = "supportInfo";
            this.supportInfo.Size = new System.Drawing.Size(183, 14);
            this.supportInfo.TabIndex = 2;
            this.supportInfo.Text = "Technical information:";
            // 
            // technicalCode
            // 
            this.technicalCode.AutoSize = true;
            this.technicalCode.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.technicalCode.Location = new System.Drawing.Point(3, 324);
            this.technicalCode.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.technicalCode.Name = "technicalCode";
            this.technicalCode.Size = new System.Drawing.Size(559, 14);
            this.technicalCode.TabIndex = 3;
            this.technicalCode.Text = "*** STOP: 0xDEADDEAD (0x00000000, 0x00000000, 0x00000000, 0x00000000)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label5.Location = new System.Drawing.Point(3, 358);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(271, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Beginning dump of physical memory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label6.Location = new System.Drawing.Point(3, 372);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "Physical memory dump complete.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.label7.Location = new System.Drawing.Point(3, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(583, 28);
            this.label7.TabIndex = 6;
            this.label7.Text = "Contact your system administrator or technical support group for further\r\nassista" +
    "nce.";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Navy;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(3, 82);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(608, 185);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // SupportEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Lucida Console", 10.4F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SupportEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit troubleshooting text";
            this.Load += new System.EventHandler(this.SupportEditor_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label errorCode;
        public System.Windows.Forms.Label supportInfo;
        public System.Windows.Forms.Label technicalCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
    }
}