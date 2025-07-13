
namespace UltimateBlueScreenSimulator
{
    partial class Metaerror
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Metaerror));
            this.technicalinfoLabel = new System.Windows.Forms.Label();
            this.troubleshootingLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.continueButton = new System.Windows.Forms.Button();
            this.retryButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.criticalIntroduction = new System.Windows.Forms.Label();
            this.embarrassmentLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.dumpButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // technicalinfoLabel
            // 
            this.technicalinfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.technicalinfoLabel.BackColor = System.Drawing.Color.Black;
            this.technicalinfoLabel.Font = new System.Drawing.Font("Consolas", 12F);
            this.technicalinfoLabel.ForeColor = System.Drawing.Color.White;
            this.technicalinfoLabel.Location = new System.Drawing.Point(-2, 620);
            this.technicalinfoLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 20);
            this.technicalinfoLabel.Name = "technicalinfoLabel";
            this.technicalinfoLabel.Padding = new System.Windows.Forms.Padding(250, 15, 250, 15);
            this.technicalinfoLabel.Size = new System.Drawing.Size(1285, 165);
            this.technicalinfoLabel.TabIndex = 10;
            this.technicalinfoLabel.Text = "GreenScreen Exception\r\n\r\nThe end-user manually initiated the crash\r\n\r\nThere is no" +
    " stack trace available for this error.";
            // 
            // troubleshootingLabel
            // 
            this.troubleshootingLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.troubleshootingLabel.AutoSize = true;
            this.troubleshootingLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.troubleshootingLabel.Location = new System.Drawing.Point(67, 455);
            this.troubleshootingLabel.Name = "troubleshootingLabel";
            this.troubleshootingLabel.Size = new System.Drawing.Size(908, 60);
            this.troubleshootingLabel.TabIndex = 11;
            this.troubleshootingLabel.Text = resources.GetString("troubleshootingLabel.Text");
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(72, 403);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1147, 49);
            this.panel1.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.continueButton);
            this.flowLayoutPanel1.Controls.Add(this.retryButton);
            this.flowLayoutPanel1.Controls.Add(this.abortButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(427, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(319, 49);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.Gold;
            this.continueButton.FlatAppearance.BorderSize = 0;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.continueButton.ForeColor = System.Drawing.Color.Black;
            this.continueButton.Location = new System.Drawing.Point(8, 8);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(97, 33);
            this.continueButton.TabIndex = 0;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = false;
            this.continueButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // retryButton
            // 
            this.retryButton.BackColor = System.Drawing.Color.Lime;
            this.retryButton.FlatAppearance.BorderSize = 0;
            this.retryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.retryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.retryButton.ForeColor = System.Drawing.Color.Black;
            this.retryButton.Location = new System.Drawing.Point(111, 8);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(97, 33);
            this.retryButton.TabIndex = 1;
            this.retryButton.Text = "Retry";
            this.retryButton.UseVisualStyleBackColor = false;
            this.retryButton.Visible = false;
            this.retryButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // abortButton
            // 
            this.abortButton.BackColor = System.Drawing.Color.DarkRed;
            this.abortButton.FlatAppearance.BorderSize = 0;
            this.abortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abortButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.abortButton.Location = new System.Drawing.Point(214, 8);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(97, 33);
            this.abortButton.TabIndex = 2;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = false;
            this.abortButton.Visible = false;
            this.abortButton.Click += new System.EventHandler(this.Button3_Click);
            // 
            // criticalIntroduction
            // 
            this.criticalIntroduction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.criticalIntroduction.AutoSize = true;
            this.criticalIntroduction.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.criticalIntroduction.Location = new System.Drawing.Point(67, 320);
            this.criticalIntroduction.Name = "criticalIntroduction";
            this.criticalIntroduction.Size = new System.Drawing.Size(1152, 60);
            this.criticalIntroduction.TabIndex = 16;
            this.criticalIntroduction.Text = resources.GetString("criticalIntroduction.Text");
            // 
            // embarrassmentLabel
            // 
            this.embarrassmentLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.embarrassmentLabel.AutoSize = true;
            this.embarrassmentLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.embarrassmentLabel.ForeColor = System.Drawing.Color.Snow;
            this.embarrassmentLabel.Location = new System.Drawing.Point(63, 279);
            this.embarrassmentLabel.Name = "embarrassmentLabel";
            this.embarrassmentLabel.Size = new System.Drawing.Size(316, 37);
            this.embarrassmentLabel.TabIndex = 17;
            this.embarrassmentLabel.Text = "Well, this is embarrasing...";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 90F);
            this.label1.Location = new System.Drawing.Point(537, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 159);
            this.label1.TabIndex = 18;
            this.label1.Text = "😓";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dumpButton
            // 
            this.dumpButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dumpButton.BackColor = System.Drawing.Color.Crimson;
            this.dumpButton.FlatAppearance.BorderSize = 0;
            this.dumpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dumpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dumpButton.Location = new System.Drawing.Point(141, 8);
            this.dumpButton.Name = "dumpButton";
            this.dumpButton.Size = new System.Drawing.Size(178, 33);
            this.dumpButton.TabIndex = 2;
            this.dumpButton.Text = "Delete configuration files";
            this.dumpButton.UseVisualStyleBackColor = false;
            this.dumpButton.Click += new System.EventHandler(this.DeleteConfigs);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Location = new System.Drawing.Point(72, 532);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1147, 49);
            this.panel2.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Controls.Add(this.dumpButton);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(427, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(327, 49);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.MediumBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 33);
            this.button1.TabIndex = 2;
            this.button1.Text = "Dump tracelog";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.DumpTracelog);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(68, 584);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Error details:";
            // 
            // Metaerror
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1281, 783);
            this.Controls.Add(this.technicalinfoLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.troubleshootingLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.embarrassmentLabel);
            this.Controls.Add(this.criticalIntroduction);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Metaerror";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "metaerror";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Metaerror_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Metaerror_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label technicalinfoLabel;
        private System.Windows.Forms.Label troubleshootingLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Label criticalIntroduction;
        private System.Windows.Forms.Label embarrassmentLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button retryButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.Timer screenUpdater;
        private System.Windows.Forms.Button dumpButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}