namespace UltimateBlueScreenSimulator
{
    partial class UpdateInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateInterface));
            this.updateHeading = new System.Windows.Forms.Label();
            this.updateDescriptionLabel = new System.Windows.Forms.Label();
            this.updateStepsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TempStatus = new System.Windows.Forms.PictureBox();
            this.Launchstatus = new System.Windows.Forms.PictureBox();
            this.HashStatus = new System.Windows.Forms.PictureBox();
            this.DownloadStatus = new System.Windows.Forms.PictureBox();
            this.downloadUpdateLabel = new System.Windows.Forms.Label();
            this.hashCheckLabel = new System.Windows.Forms.Label();
            this.installAndLaunchLabel = new System.Windows.Forms.Label();
            this.delTempLabel = new System.Windows.Forms.Label();
            this.updateProgress = new System.Windows.Forms.ProgressBar();
            this.warningLabel = new System.Windows.Forms.Label();
            this.dloadState = new System.Windows.Forms.Label();
            this.hashWait = new System.Windows.Forms.Timer(this.components);
            this.installWait = new System.Windows.Forms.Timer(this.components);
            this.cleanWait = new System.Windows.Forms.Timer(this.components);
            this.blinkBlink = new System.Windows.Forms.Timer(this.components);
            this.updateStepsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TempStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Launchstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HashStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // updateHeading
            // 
            this.updateHeading.AutoSize = true;
            this.updateHeading.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.updateHeading.Location = new System.Drawing.Point(12, 9);
            this.updateHeading.Name = "updateHeading";
            this.updateHeading.Size = new System.Drawing.Size(194, 25);
            this.updateHeading.TabIndex = 0;
            this.updateHeading.Text = "Updating, please wait...";
            // 
            // updateDescriptionLabel
            // 
            this.updateDescriptionLabel.AutoSize = true;
            this.updateDescriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.updateDescriptionLabel.Location = new System.Drawing.Point(14, 34);
            this.updateDescriptionLabel.Name = "updateDescriptionLabel";
            this.updateDescriptionLabel.Size = new System.Drawing.Size(359, 15);
            this.updateDescriptionLabel.TabIndex = 1;
            this.updateDescriptionLabel.Text = "During the update progress, the program may restart several times.";
            // 
            // updateStepsPanel
            // 
            this.updateStepsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateStepsPanel.ColumnCount = 2;
            this.updateStepsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.502814F));
            this.updateStepsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.49718F));
            this.updateStepsPanel.Controls.Add(this.TempStatus, 0, 3);
            this.updateStepsPanel.Controls.Add(this.Launchstatus, 0, 2);
            this.updateStepsPanel.Controls.Add(this.HashStatus, 0, 1);
            this.updateStepsPanel.Controls.Add(this.DownloadStatus, 0, 0);
            this.updateStepsPanel.Controls.Add(this.downloadUpdateLabel, 1, 0);
            this.updateStepsPanel.Controls.Add(this.hashCheckLabel, 1, 1);
            this.updateStepsPanel.Controls.Add(this.installAndLaunchLabel, 1, 2);
            this.updateStepsPanel.Controls.Add(this.delTempLabel, 1, 3);
            this.updateStepsPanel.Location = new System.Drawing.Point(17, 63);
            this.updateStepsPanel.Name = "updateStepsPanel";
            this.updateStepsPanel.RowCount = 4;
            this.updateStepsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.updateStepsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.updateStepsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.updateStepsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.updateStepsPanel.Size = new System.Drawing.Size(460, 78);
            this.updateStepsPanel.TabIndex = 2;
            // 
            // TempStatus
            // 
            this.TempStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TempStatus.Image = global::UltimateBlueScreenSimulator.Properties.Resources.pending;
            this.TempStatus.Location = new System.Drawing.Point(0, 58);
            this.TempStatus.Margin = new System.Windows.Forms.Padding(0);
            this.TempStatus.Name = "TempStatus";
            this.TempStatus.Size = new System.Drawing.Size(20, 20);
            this.TempStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.TempStatus.TabIndex = 7;
            this.TempStatus.TabStop = false;
            // 
            // Launchstatus
            // 
            this.Launchstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Launchstatus.Image = global::UltimateBlueScreenSimulator.Properties.Resources.current;
            this.Launchstatus.Location = new System.Drawing.Point(0, 38);
            this.Launchstatus.Margin = new System.Windows.Forms.Padding(0);
            this.Launchstatus.Name = "Launchstatus";
            this.Launchstatus.Size = new System.Drawing.Size(20, 20);
            this.Launchstatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Launchstatus.TabIndex = 6;
            this.Launchstatus.TabStop = false;
            // 
            // HashStatus
            // 
            this.HashStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HashStatus.Image = global::UltimateBlueScreenSimulator.Properties.Resources.failure;
            this.HashStatus.Location = new System.Drawing.Point(0, 19);
            this.HashStatus.Margin = new System.Windows.Forms.Padding(0);
            this.HashStatus.Name = "HashStatus";
            this.HashStatus.Size = new System.Drawing.Size(20, 19);
            this.HashStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.HashStatus.TabIndex = 5;
            this.HashStatus.TabStop = false;
            // 
            // DownloadStatus
            // 
            this.DownloadStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownloadStatus.Image = global::UltimateBlueScreenSimulator.Properties.Resources.success;
            this.DownloadStatus.Location = new System.Drawing.Point(0, 0);
            this.DownloadStatus.Margin = new System.Windows.Forms.Padding(0);
            this.DownloadStatus.Name = "DownloadStatus";
            this.DownloadStatus.Size = new System.Drawing.Size(20, 19);
            this.DownloadStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DownloadStatus.TabIndex = 4;
            this.DownloadStatus.TabStop = false;
            // 
            // downloadUpdateLabel
            // 
            this.downloadUpdateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadUpdateLabel.Location = new System.Drawing.Point(23, 0);
            this.downloadUpdateLabel.Name = "downloadUpdateLabel";
            this.downloadUpdateLabel.Size = new System.Drawing.Size(434, 19);
            this.downloadUpdateLabel.TabIndex = 0;
            this.downloadUpdateLabel.Text = "Downloading the update";
            this.downloadUpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hashCheckLabel
            // 
            this.hashCheckLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hashCheckLabel.Location = new System.Drawing.Point(23, 19);
            this.hashCheckLabel.Name = "hashCheckLabel";
            this.hashCheckLabel.Size = new System.Drawing.Size(434, 19);
            this.hashCheckLabel.TabIndex = 1;
            this.hashCheckLabel.Text = "Hashchecking";
            this.hashCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // installAndLaunchLabel
            // 
            this.installAndLaunchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.installAndLaunchLabel.Location = new System.Drawing.Point(23, 38);
            this.installAndLaunchLabel.Name = "installAndLaunchLabel";
            this.installAndLaunchLabel.Size = new System.Drawing.Size(434, 20);
            this.installAndLaunchLabel.TabIndex = 2;
            this.installAndLaunchLabel.Text = "Installing and launching the new update";
            this.installAndLaunchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // delTempLabel
            // 
            this.delTempLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delTempLabel.Location = new System.Drawing.Point(23, 58);
            this.delTempLabel.Name = "delTempLabel";
            this.delTempLabel.Size = new System.Drawing.Size(434, 20);
            this.delTempLabel.TabIndex = 3;
            this.delTempLabel.Text = "Deleting temporary update files";
            this.delTempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateProgress
            // 
            this.updateProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateProgress.Location = new System.Drawing.Point(17, 155);
            this.updateProgress.Name = "updateProgress";
            this.updateProgress.Size = new System.Drawing.Size(460, 20);
            this.updateProgress.TabIndex = 3;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(14, 202);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(145, 13);
            this.warningLabel.TabIndex = 4;
            this.warningLabel.Text = "Do not turn off your computer";
            // 
            // dloadState
            // 
            this.dloadState.AutoSize = true;
            this.dloadState.Location = new System.Drawing.Point(14, 188);
            this.dloadState.Name = "dloadState";
            this.dloadState.Size = new System.Drawing.Size(209, 13);
            this.dloadState.TabIndex = 5;
            this.dloadState.Text = "0 bytes downloaded (Transfer rate is 0 b/s)";
            // 
            // hashWait
            // 
            this.hashWait.Interval = 500;
            this.hashWait.Tick += new System.EventHandler(this.HashWait_Tick);
            // 
            // installWait
            // 
            this.installWait.Interval = 500;
            this.installWait.Tick += new System.EventHandler(this.InstallWait_Tick);
            // 
            // cleanWait
            // 
            this.cleanWait.Interval = 500;
            this.cleanWait.Tick += new System.EventHandler(this.CleanWait_Tick);
            // 
            // blinkBlink
            // 
            this.blinkBlink.Enabled = true;
            this.blinkBlink.Interval = 1000;
            this.blinkBlink.Tick += new System.EventHandler(this.BlinkBlink_Tick);
            // 
            // UpdateInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 239);
            this.Controls.Add(this.dloadState);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.updateProgress);
            this.Controls.Add(this.updateStepsPanel);
            this.Controls.Add(this.updateDescriptionLabel);
            this.Controls.Add(this.updateHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(478, 273);
            this.Name = "UpdateInterface";
            this.Text = "Updater 1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateInterface_FormClosing);
            this.Load += new System.EventHandler(this.UpdateInterface_Load);
            this.updateStepsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TempStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Launchstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HashStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updateHeading;
        private System.Windows.Forms.Label updateDescriptionLabel;
        private System.Windows.Forms.TableLayoutPanel updateStepsPanel;
        private System.Windows.Forms.Label downloadUpdateLabel;
        private System.Windows.Forms.Label hashCheckLabel;
        private System.Windows.Forms.Label installAndLaunchLabel;
        private System.Windows.Forms.Label delTempLabel;
        private System.Windows.Forms.PictureBox TempStatus;
        private System.Windows.Forms.PictureBox Launchstatus;
        private System.Windows.Forms.PictureBox HashStatus;
        private System.Windows.Forms.PictureBox DownloadStatus;
        private System.Windows.Forms.ProgressBar updateProgress;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Label dloadState;
        private System.Windows.Forms.Timer hashWait;
        private System.Windows.Forms.Timer installWait;
        private System.Windows.Forms.Timer cleanWait;
        private System.Windows.Forms.Timer blinkBlink;
    }
}