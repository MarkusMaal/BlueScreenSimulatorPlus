namespace UltimateBlueScreenSimulator
{
    partial class BTS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTS));
            this.charSetA = new System.Windows.Forms.PictureBox();
            this.charSetB = new System.Windows.Forms.PictureBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.charSetC = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.charSetA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charSetB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charSetC)).BeginInit();
            this.SuspendLayout();
            // 
            // charSetA
            // 
            this.charSetA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charSetA.Image = global::UltimateBlueScreenSimulator.Properties.Resources.rasterNT;
            this.charSetA.Location = new System.Drawing.Point(12, 24);
            this.charSetA.Name = "charSetA";
            this.charSetA.Size = new System.Drawing.Size(635, 17);
            this.charSetA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.charSetA.TabIndex = 0;
            this.charSetA.TabStop = false;
            this.charSetA.Click += new System.EventHandler(this.ChangeSizeModeA);
            // 
            // charSetB
            // 
            this.charSetB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charSetB.Image = global::UltimateBlueScreenSimulator.Properties.Resources.rasters3;
            this.charSetB.Location = new System.Drawing.Point(12, 47);
            this.charSetB.Name = "charSetB";
            this.charSetB.Size = new System.Drawing.Size(635, 17);
            this.charSetB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.charSetB.TabIndex = 1;
            this.charSetB.TabStop = false;
            this.charSetB.Click += new System.EventHandler(this.ChangeSizeModeB);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(290, 111);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseClick);
            // 
            // charSetC
            // 
            this.charSetC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charSetC.Image = global::UltimateBlueScreenSimulator.Properties.Resources.doscii;
            this.charSetC.Location = new System.Drawing.Point(14, 65);
            this.charSetC.Name = "charSetC";
            this.charSetC.Size = new System.Drawing.Size(635, 10);
            this.charSetC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.charSetC.TabIndex = 3;
            this.charSetC.TabStop = false;
            this.charSetC.Click += new System.EventHandler(this.ChangeSizeModeC);
            // 
            // BTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(662, 146);
            this.Controls.Add(this.charSetC);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.charSetB);
            this.Controls.Add(this.charSetA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BTS";
            this.ShowInTaskbar = false;
            this.Text = "???";
            ((System.ComponentModel.ISupportInitialize)(this.charSetA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charSetB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charSetC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox charSetA;
        private System.Windows.Forms.PictureBox charSetB;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.PictureBox charSetC;
    }
}