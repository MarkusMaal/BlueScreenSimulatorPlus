namespace UltimateBlueScreenSimulator
{
    partial class BootMgr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BootMgr));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.waterMarkText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Consolas", 16F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(947, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows Boot Manager";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Consolas", 16F);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(28, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(963, 58);
            this.label2.TabIndex = 1;
            this.label2.Text = "Windows failed to start. A recent hardware or software change might be the\r\ncause" +
    ". To fix the problem:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Consolas", 16F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(58, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(933, 87);
            this.label3.TabIndex = 2;
            this.label3.Text = "1. Insert your Windows installation disc and restart your computer.\r\n2. Choose yo" +
    "ur language settings, and then click \"Next.\"\r\n3. Click \"Repair your computer.\"";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Consolas", 16F);
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(28, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(963, 58);
            this.label4.TabIndex = 3;
            this.label4.Text = "If you do not have this disc, contact your system administrator or computer\r\nmanu" +
    "facturer for assistance.";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Font = new System.Drawing.Font("Consolas", 16F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(39, 731);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(455, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = " ENTER=Continue";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Font = new System.Drawing.Font("Consolas", 16F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(493, 731);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(488, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "ESC=Exit ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Consolas", 16F);
            this.label7.ForeColor = System.Drawing.Color.Silver;
            this.label7.Location = new System.Drawing.Point(81, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "Status: ";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Consolas", 16F);
            this.label8.ForeColor = System.Drawing.Color.Silver;
            this.label8.Location = new System.Drawing.Point(81, 507);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 31);
            this.label8.TabIndex = 7;
            this.label8.Text = "Info: ";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Consolas", 16F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(182, 451);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(644, 31);
            this.label9.TabIndex = 8;
            this.label9.Text = "0xc000000e";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Consolas", 16F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(161, 507);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(766, 65);
            this.label10.TabIndex = 9;
            this.label10.Text = "The boot selection failed because a required device is\r\ninaccessible.";
            // 
            // screenUpdater
            // 
            this.screenUpdater.Enabled = true;
            this.screenUpdater.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // waterMarkText
            // 
            this.waterMarkText.AutoSize = true;
            this.waterMarkText.ForeColor = System.Drawing.Color.DimGray;
            this.waterMarkText.Location = new System.Drawing.Point(853, 709);
            this.waterMarkText.Name = "waterMarkText";
            this.waterMarkText.Size = new System.Drawing.Size(128, 13);
            this.waterMarkText.TabIndex = 10;
            this.waterMarkText.Text = "blue screen simulator plus";
            // 
            // BootMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.waterMarkText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BootMgr";
            this.Text = "Windows Boot Manager error screen simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BootMgr_FormClosing);
            this.Load += new System.EventHandler(this.BootMgr_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BootMgr_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer screenUpdater;
        private System.Windows.Forms.Label waterMarkText;
    }
}