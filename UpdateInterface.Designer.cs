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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TempStatus = new System.Windows.Forms.PictureBox();
            this.Launchstatus = new System.Windows.Forms.PictureBox();
            this.HashStatus = new System.Windows.Forms.PictureBox();
            this.DownloadStatus = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.dloadState = new System.Windows.Forms.Label();
            this.hashWait = new System.Windows.Forms.Timer(this.components);
            this.installWait = new System.Windows.Forms.Timer(this.components);
            this.cleanWait = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TempStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Launchstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HashStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please wait while we download and install the update";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "During the update progress, the program may restart several times.\r\nThe following" +
    " steps will be taken to ensure a successful update:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.502814F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.49718F));
            this.tableLayoutPanel1.Controls.Add(this.TempStatus, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Launchstatus, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.HashStatus, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DownloadStatus, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 77);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 78);
            this.tableLayoutPanel1.TabIndex = 2;
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
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(23, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(434, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Downloading the update";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(23, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(434, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hashchecking";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(23, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(434, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Installing and launching the new update";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(23, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(434, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Deleting temporary update files";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(17, 161);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(460, 20);
            this.progressBar1.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(248, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Do not turn off your computer or close this program!";
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
            // UpdateInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 234);
            this.Controls.Add(this.dloadState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(478, 273);
            this.Name = "UpdateInterface";
            this.Text = "Updater 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateInterface_FormClosing);
            this.Load += new System.EventHandler(this.UpdateInterface_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TempStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Launchstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HashStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox TempStatus;
        private System.Windows.Forms.PictureBox Launchstatus;
        private System.Windows.Forms.PictureBox HashStatus;
        private System.Windows.Forms.PictureBox DownloadStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label dloadState;
        private System.Windows.Forms.Timer hashWait;
        private System.Windows.Forms.Timer installWait;
        private System.Windows.Forms.Timer cleanWait;
    }
}