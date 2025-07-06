namespace UltimateBlueScreenSimulator
{
    partial class WindowScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowScreen));
            this.screenDisplay = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.screenDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // screenDisplay
            // 
            this.screenDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenDisplay.Location = new System.Drawing.Point(0, 0);
            this.screenDisplay.Name = "screenDisplay";
            this.screenDisplay.Size = new System.Drawing.Size(800, 450);
            this.screenDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.screenDisplay.TabIndex = 0;
            this.screenDisplay.TabStop = false;
            // 
            // WindowScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.screenDisplay);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowScreen";
            this.ShowInTaskbar = false;
            this.Text = "BSSP fullscreen display";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WindowScreen_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WindowScreen_FormClosed);
            this.Load += new System.EventHandler(this.WindowScreen_Load);
            this.MouseHover += new System.EventHandler(this.WindowScreen_MouseHover);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowScreen_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.screenDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox screenDisplay;
    }
}