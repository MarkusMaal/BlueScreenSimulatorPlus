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
            this.updateHeading = new MaterialSkin.Controls.MaterialLabel();
            this.updateDescriptionLabel = new MaterialSkin.Controls.MaterialLabel();
            this.updateStepsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TempStatus = new System.Windows.Forms.PictureBox();
            this.Launchstatus = new System.Windows.Forms.PictureBox();
            this.HashStatus = new System.Windows.Forms.PictureBox();
            this.DownloadStatus = new System.Windows.Forms.PictureBox();
            this.downloadUpdateLabel = new MaterialSkin.Controls.MaterialLabel();
            this.hashCheckLabel = new MaterialSkin.Controls.MaterialLabel();
            this.installAndLaunchLabel = new MaterialSkin.Controls.MaterialLabel();
            this.delTempLabel = new MaterialSkin.Controls.MaterialLabel();
            this.updateProgress = new MaterialSkin.Controls.MaterialProgressBar();
            this.warningLabel = new MaterialSkin.Controls.MaterialLabel();
            this.dloadState = new MaterialSkin.Controls.MaterialLabel();
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
            this.updateHeading.Depth = 0;
            this.updateHeading.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.updateHeading.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.updateHeading.Location = new System.Drawing.Point(12, 35);
            this.updateHeading.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateHeading.Name = "updateHeading";
            this.updateHeading.Size = new System.Drawing.Size(247, 29);
            this.updateHeading.TabIndex = 0;
            this.updateHeading.Text = "Updating, please wait...";
            // 
            // updateDescriptionLabel
            // 
            this.updateDescriptionLabel.AutoSize = true;
            this.updateDescriptionLabel.Depth = 0;
            this.updateDescriptionLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.updateDescriptionLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.updateDescriptionLabel.Location = new System.Drawing.Point(14, 73);
            this.updateDescriptionLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateDescriptionLabel.Name = "updateDescriptionLabel";
            this.updateDescriptionLabel.Size = new System.Drawing.Size(362, 14);
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
            this.updateStepsPanel.Location = new System.Drawing.Point(17, 102);
            this.updateStepsPanel.Name = "updateStepsPanel";
            this.updateStepsPanel.RowCount = 4;
            this.updateStepsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.updateStepsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.updateStepsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.updateStepsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.updateStepsPanel.Size = new System.Drawing.Size(492, 78);
            this.updateStepsPanel.TabIndex = 2;
            // 
            // TempStatus
            // 
            this.TempStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TempStatus.Image = global::UltimateBlueScreenSimulator.Properties.Resources.pending;
            this.TempStatus.Location = new System.Drawing.Point(0, 58);
            this.TempStatus.Margin = new System.Windows.Forms.Padding(0);
            this.TempStatus.Name = "TempStatus";
            this.TempStatus.Size = new System.Drawing.Size(22, 20);
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
            this.Launchstatus.Size = new System.Drawing.Size(22, 20);
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
            this.HashStatus.Size = new System.Drawing.Size(22, 19);
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
            this.DownloadStatus.Size = new System.Drawing.Size(22, 19);
            this.DownloadStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DownloadStatus.TabIndex = 4;
            this.DownloadStatus.TabStop = false;
            // 
            // downloadUpdateLabel
            // 
            this.downloadUpdateLabel.Depth = 0;
            this.downloadUpdateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.downloadUpdateLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.downloadUpdateLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.downloadUpdateLabel.Location = new System.Drawing.Point(25, 0);
            this.downloadUpdateLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.downloadUpdateLabel.Name = "downloadUpdateLabel";
            this.downloadUpdateLabel.Size = new System.Drawing.Size(464, 19);
            this.downloadUpdateLabel.TabIndex = 0;
            this.downloadUpdateLabel.Text = "Downloading the update";
            this.downloadUpdateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hashCheckLabel
            // 
            this.hashCheckLabel.Depth = 0;
            this.hashCheckLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hashCheckLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.hashCheckLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.hashCheckLabel.Location = new System.Drawing.Point(25, 19);
            this.hashCheckLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.hashCheckLabel.Name = "hashCheckLabel";
            this.hashCheckLabel.Size = new System.Drawing.Size(464, 19);
            this.hashCheckLabel.TabIndex = 1;
            this.hashCheckLabel.Text = "Hashchecking";
            this.hashCheckLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // installAndLaunchLabel
            // 
            this.installAndLaunchLabel.Depth = 0;
            this.installAndLaunchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.installAndLaunchLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.installAndLaunchLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.installAndLaunchLabel.Location = new System.Drawing.Point(25, 38);
            this.installAndLaunchLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.installAndLaunchLabel.Name = "installAndLaunchLabel";
            this.installAndLaunchLabel.Size = new System.Drawing.Size(464, 20);
            this.installAndLaunchLabel.TabIndex = 2;
            this.installAndLaunchLabel.Text = "Installing and launching the new update";
            this.installAndLaunchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // delTempLabel
            // 
            this.delTempLabel.Depth = 0;
            this.delTempLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delTempLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.delTempLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.delTempLabel.Location = new System.Drawing.Point(25, 58);
            this.delTempLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.delTempLabel.Name = "delTempLabel";
            this.delTempLabel.Size = new System.Drawing.Size(464, 20);
            this.delTempLabel.TabIndex = 3;
            this.delTempLabel.Text = "Deleting temporary update files";
            this.delTempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // updateProgress
            // 
            this.updateProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updateProgress.Depth = 0;
            this.updateProgress.Location = new System.Drawing.Point(17, 194);
            this.updateProgress.MouseState = MaterialSkin.MouseState.HOVER;
            this.updateProgress.Name = "updateProgress";
            this.updateProgress.Size = new System.Drawing.Size(492, 5);
            this.updateProgress.TabIndex = 3;
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Depth = 0;
            this.warningLabel.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.warningLabel.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(14, 243);
            this.warningLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(162, 14);
            this.warningLabel.TabIndex = 4;
            this.warningLabel.Text = "Do not turn off your computer";
            // 
            // dloadState
            // 
            this.dloadState.AutoSize = true;
            this.dloadState.Depth = 0;
            this.dloadState.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dloadState.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.dloadState.Location = new System.Drawing.Point(14, 225);
            this.dloadState.MouseState = MaterialSkin.MouseState.HOVER;
            this.dloadState.Name = "dloadState";
            this.dloadState.Size = new System.Drawing.Size(233, 14);
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
            this.ClientSize = new System.Drawing.Size(521, 351);
            this.Controls.Add(this.dloadState);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.updateProgress);
            this.Controls.Add(this.updateStepsPanel);
            this.Controls.Add(this.updateDescriptionLabel);
            this.Controls.Add(this.updateHeading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(478, 273);
            this.Name = "UpdateInterface";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
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

        private MaterialSkin.Controls.MaterialLabel updateHeading;
        private MaterialSkin.Controls.MaterialLabel updateDescriptionLabel;
        private System.Windows.Forms.TableLayoutPanel updateStepsPanel;
        private MaterialSkin.Controls.MaterialLabel downloadUpdateLabel;
        private MaterialSkin.Controls.MaterialLabel hashCheckLabel;
        private MaterialSkin.Controls.MaterialLabel installAndLaunchLabel;
        private MaterialSkin.Controls.MaterialLabel delTempLabel;
        private System.Windows.Forms.PictureBox TempStatus;
        private System.Windows.Forms.PictureBox Launchstatus;
        private System.Windows.Forms.PictureBox HashStatus;
        private System.Windows.Forms.PictureBox DownloadStatus;
        private MaterialSkin.Controls.MaterialProgressBar updateProgress;
        private MaterialSkin.Controls.MaterialLabel warningLabel;
        private MaterialSkin.Controls.MaterialLabel dloadState;
        private System.Windows.Forms.Timer hashWait;
        private System.Windows.Forms.Timer installWait;
        private System.Windows.Forms.Timer cleanWait;
        private System.Windows.Forms.Timer blinkBlink;
    }
}