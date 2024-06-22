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
            this.charSetC = new System.Windows.Forms.PictureBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
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
            this.charSetA.Location = new System.Drawing.Point(16, 88);
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
            this.charSetB.Location = new System.Drawing.Point(16, 111);
            this.charSetB.Name = "charSetB";
            this.charSetB.Size = new System.Drawing.Size(635, 17);
            this.charSetB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.charSetB.TabIndex = 1;
            this.charSetB.TabStop = false;
            this.charSetB.Click += new System.EventHandler(this.ChangeSizeModeB);
            // 
            // charSetC
            // 
            this.charSetC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.charSetC.Image = global::UltimateBlueScreenSimulator.Properties.Resources.doscii;
            this.charSetC.Location = new System.Drawing.Point(18, 129);
            this.charSetC.Name = "charSetC";
            this.charSetC.Size = new System.Drawing.Size(635, 10);
            this.charSetC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.charSetC.TabIndex = 3;
            this.charSetC.TabStop = false;
            this.charSetC.Click += new System.EventHandler(this.ChangeSizeModeC);
            // 
            // materialButton1
            // 
            this.materialButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(294, 158);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(76, 36);
            this.materialButton1.TabIndex = 4;
            this.materialButton1.Text = "&Close";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.CloseClick);
            // 
            // BTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 212);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.charSetC);
            this.Controls.Add(this.charSetB);
            this.Controls.Add(this.charSetA);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BTS";
            this.ShowInTaskbar = false;
            this.Text = "???";
            this.Load += new System.EventHandler(this.BTS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.charSetA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charSetB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charSetC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox charSetA;
        private System.Windows.Forms.PictureBox charSetB;
        private System.Windows.Forms.PictureBox charSetC;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}