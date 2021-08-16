namespace UltimateBlueScreenSimulator
{
    partial class Splash
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SplashText = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 105F);
            this.label1.Location = new System.Drawing.Point(3, -38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 203);
            this.label1.TabIndex = 0;
            this.label1.Text = ":)";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 32F);
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(98, -10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 64);
            this.label2.TabIndex = 1;
            this.label2.Text = "+";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.label3.Location = new System.Drawing.Point(116, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 38);
            this.label3.TabIndex = 2;
            this.label3.Text = "Blue screen simulator plus";
            this.label3.UseWaitCursor = true;
            // 
            // SplashText
            // 
            this.SplashText.BackColor = System.Drawing.Color.Black;
            this.SplashText.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.SplashText.Location = new System.Drawing.Point(20, 129);
            this.SplashText.Name = "SplashText";
            this.SplashText.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.SplashText.Size = new System.Drawing.Size(426, 20);
            this.SplashText.TabIndex = 3;
            this.SplashText.Text = "Please wait...";
            this.SplashText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.SplashText.UseWaitCursor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(374, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 64);
            this.label4.TabIndex = 4;
            this.label4.Text = "2.0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label4.UseWaitCursor = true;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::UltimateBlueScreenSimulator.Properties.Resources.round_corners;
            this.ClientSize = new System.Drawing.Size(471, 149);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SplashText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label SplashText;
        internal System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label4;
    }
}