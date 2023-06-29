
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
            this.errorFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
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
            this.errorFlowPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorFlowPanel
            // 
            this.errorFlowPanel.Controls.Add(this.technicalinfoLabel);
            this.errorFlowPanel.Controls.Add(this.troubleshootingLabel);
            this.errorFlowPanel.Controls.Add(this.panel1);
            this.errorFlowPanel.Controls.Add(this.criticalIntroduction);
            this.errorFlowPanel.Controls.Add(this.embarrassmentLabel);
            this.errorFlowPanel.Controls.Add(this.label1);
            this.errorFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.errorFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.errorFlowPanel.Name = "errorFlowPanel";
            this.errorFlowPanel.Size = new System.Drawing.Size(800, 600);
            this.errorFlowPanel.TabIndex = 2;
            this.errorFlowPanel.WrapContents = false;
            // 
            // technicalinfoLabel
            // 
            this.technicalinfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.technicalinfoLabel.AutoSize = true;
            this.technicalinfoLabel.BackColor = System.Drawing.Color.DarkBlue;
            this.technicalinfoLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 9F);
            this.technicalinfoLabel.ForeColor = System.Drawing.Color.White;
            this.technicalinfoLabel.Location = new System.Drawing.Point(20, 475);
            this.technicalinfoLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 20);
            this.technicalinfoLabel.Name = "technicalinfoLabel";
            this.technicalinfoLabel.Padding = new System.Windows.Forms.Padding(250, 15, 250, 15);
            this.technicalinfoLabel.Size = new System.Drawing.Size(740, 105);
            this.technicalinfoLabel.TabIndex = 10;
            this.technicalinfoLabel.Text = "GreenScreen Exception\r\n\r\nThe end-user manually initiated the crash\r\n\r\nThere is no" +
    " stack trace available for this error.";
            this.technicalinfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // troubleshootingLabel
            // 
            this.troubleshootingLabel.AutoSize = true;
            this.troubleshootingLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.troubleshootingLabel.Location = new System.Drawing.Point(3, 375);
            this.troubleshootingLabel.Name = "troubleshootingLabel";
            this.troubleshootingLabel.Size = new System.Drawing.Size(772, 80);
            this.troubleshootingLabel.TabIndex = 11;
            this.troubleshootingLabel.Text = resources.GetString("troubleshootingLabel.Text");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(3, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 49);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(241, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(309, 39);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.Gold;
            this.continueButton.FlatAppearance.BorderSize = 0;
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.continueButton.ForeColor = System.Drawing.Color.Black;
            this.continueButton.Location = new System.Drawing.Point(3, 13);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(97, 23);
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
            this.retryButton.ForeColor = System.Drawing.Color.Black;
            this.retryButton.Location = new System.Drawing.Point(106, 13);
            this.retryButton.Name = "retryButton";
            this.retryButton.Size = new System.Drawing.Size(97, 23);
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
            this.abortButton.Location = new System.Drawing.Point(209, 13);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(97, 23);
            this.abortButton.TabIndex = 2;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = false;
            this.abortButton.Visible = false;
            this.abortButton.Click += new System.EventHandler(this.Button3_Click);
            // 
            // criticalIntroduction
            // 
            this.criticalIntroduction.AutoSize = true;
            this.criticalIntroduction.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.criticalIntroduction.Location = new System.Drawing.Point(3, 240);
            this.criticalIntroduction.Name = "criticalIntroduction";
            this.criticalIntroduction.Size = new System.Drawing.Size(775, 80);
            this.criticalIntroduction.TabIndex = 16;
            this.criticalIntroduction.Text = resources.GetString("criticalIntroduction.Text");
            // 
            // embarrassmentLabel
            // 
            this.embarrassmentLabel.AutoSize = true;
            this.embarrassmentLabel.Font = new System.Drawing.Font("Segoe UI Semilight", 20F);
            this.embarrassmentLabel.ForeColor = System.Drawing.Color.Snow;
            this.embarrassmentLabel.Location = new System.Drawing.Point(3, 203);
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
            this.label1.Location = new System.Drawing.Point(326, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 159);
            this.label1.TabIndex = 18;
            this.label1.Text = ":(";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Metaerror
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.errorFlowPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Metaerror";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "metaerror";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Metaerror_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Metaerror_KeyDown);
            this.errorFlowPanel.ResumeLayout(false);
            this.errorFlowPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel errorFlowPanel;
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
    }
}