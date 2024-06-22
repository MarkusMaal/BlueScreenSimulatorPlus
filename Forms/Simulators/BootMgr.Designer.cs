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
            this.bootmgrTitle = new System.Windows.Forms.Label();
            this.bootmgrIntro = new System.Windows.Forms.Label();
            this.bootmgrTroubleshoot = new System.Windows.Forms.Label();
            this.bootmgrConsultAdmin = new System.Windows.Forms.Label();
            this.bootmgrEnterContinue = new System.Windows.Forms.Label();
            this.bootmgrEscapeExit = new System.Windows.Forms.Label();
            this.bootmgrStatus = new System.Windows.Forms.Label();
            this.bootmgrInfo = new System.Windows.Forms.Label();
            this.bootmgrStatusCode = new System.Windows.Forms.Label();
            this.bootmgrInfoDetails = new System.Windows.Forms.Label();
            this.screenUpdater = new System.Windows.Forms.Timer(this.components);
            this.waterMarkText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bootmgrTitle
            // 
            this.bootmgrTitle.BackColor = System.Drawing.Color.Silver;
            this.bootmgrTitle.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrTitle.ForeColor = System.Drawing.Color.Black;
            this.bootmgrTitle.Location = new System.Drawing.Point(34, 11);
            this.bootmgrTitle.Name = "bootmgrTitle";
            this.bootmgrTitle.Size = new System.Drawing.Size(947, 26);
            this.bootmgrTitle.TabIndex = 0;
            this.bootmgrTitle.Text = "Windows Boot Manager";
            this.bootmgrTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bootmgrIntro
            // 
            this.bootmgrIntro.BackColor = System.Drawing.Color.Black;
            this.bootmgrIntro.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrIntro.ForeColor = System.Drawing.Color.Silver;
            this.bootmgrIntro.Location = new System.Drawing.Point(28, 81);
            this.bootmgrIntro.Name = "bootmgrIntro";
            this.bootmgrIntro.Size = new System.Drawing.Size(963, 58);
            this.bootmgrIntro.TabIndex = 1;
            this.bootmgrIntro.Text = "Windows failed to start. A recent hardware or software change might be the\r\ncause" +
    ". To fix the problem:";
            // 
            // bootmgrTroubleshoot
            // 
            this.bootmgrTroubleshoot.BackColor = System.Drawing.Color.Black;
            this.bootmgrTroubleshoot.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrTroubleshoot.ForeColor = System.Drawing.Color.Silver;
            this.bootmgrTroubleshoot.Location = new System.Drawing.Point(58, 166);
            this.bootmgrTroubleshoot.Name = "bootmgrTroubleshoot";
            this.bootmgrTroubleshoot.Size = new System.Drawing.Size(933, 87);
            this.bootmgrTroubleshoot.TabIndex = 2;
            this.bootmgrTroubleshoot.Text = "1. Insert your Windows installation disc and restart your computer.\r\n2. Choose yo" +
    "ur language settings, and then click \"Next.\"\r\n3. Click \"Repair your computer.\"";
            // 
            // bootmgrConsultAdmin
            // 
            this.bootmgrConsultAdmin.BackColor = System.Drawing.Color.Black;
            this.bootmgrConsultAdmin.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrConsultAdmin.ForeColor = System.Drawing.Color.Silver;
            this.bootmgrConsultAdmin.Location = new System.Drawing.Point(28, 282);
            this.bootmgrConsultAdmin.Name = "bootmgrConsultAdmin";
            this.bootmgrConsultAdmin.Size = new System.Drawing.Size(963, 58);
            this.bootmgrConsultAdmin.TabIndex = 3;
            this.bootmgrConsultAdmin.Text = "If you do not have this disc, contact your system administrator or computer\r\nmanu" +
    "facturer for assistance.";
            // 
            // bootmgrEnterContinue
            // 
            this.bootmgrEnterContinue.BackColor = System.Drawing.Color.Silver;
            this.bootmgrEnterContinue.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrEnterContinue.ForeColor = System.Drawing.Color.Black;
            this.bootmgrEnterContinue.Location = new System.Drawing.Point(39, 731);
            this.bootmgrEnterContinue.Name = "bootmgrEnterContinue";
            this.bootmgrEnterContinue.Size = new System.Drawing.Size(455, 26);
            this.bootmgrEnterContinue.TabIndex = 4;
            this.bootmgrEnterContinue.Text = " ENTER=Continue";
            this.bootmgrEnterContinue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bootmgrEscapeExit
            // 
            this.bootmgrEscapeExit.BackColor = System.Drawing.Color.Silver;
            this.bootmgrEscapeExit.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrEscapeExit.ForeColor = System.Drawing.Color.Black;
            this.bootmgrEscapeExit.Location = new System.Drawing.Point(493, 731);
            this.bootmgrEscapeExit.Name = "bootmgrEscapeExit";
            this.bootmgrEscapeExit.Size = new System.Drawing.Size(488, 26);
            this.bootmgrEscapeExit.TabIndex = 5;
            this.bootmgrEscapeExit.Text = "ESC=Exit ";
            this.bootmgrEscapeExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bootmgrStatus
            // 
            this.bootmgrStatus.BackColor = System.Drawing.Color.Black;
            this.bootmgrStatus.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrStatus.ForeColor = System.Drawing.Color.Silver;
            this.bootmgrStatus.Location = new System.Drawing.Point(81, 451);
            this.bootmgrStatus.Name = "bootmgrStatus";
            this.bootmgrStatus.Size = new System.Drawing.Size(105, 31);
            this.bootmgrStatus.TabIndex = 6;
            this.bootmgrStatus.Text = "Status: ";
            // 
            // bootmgrInfo
            // 
            this.bootmgrInfo.BackColor = System.Drawing.Color.Black;
            this.bootmgrInfo.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrInfo.ForeColor = System.Drawing.Color.Silver;
            this.bootmgrInfo.Location = new System.Drawing.Point(81, 507);
            this.bootmgrInfo.Name = "bootmgrInfo";
            this.bootmgrInfo.Size = new System.Drawing.Size(74, 31);
            this.bootmgrInfo.TabIndex = 7;
            this.bootmgrInfo.Text = "Info: ";
            // 
            // bootmgrStatusCode
            // 
            this.bootmgrStatusCode.BackColor = System.Drawing.Color.Black;
            this.bootmgrStatusCode.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrStatusCode.ForeColor = System.Drawing.Color.White;
            this.bootmgrStatusCode.Location = new System.Drawing.Point(182, 451);
            this.bootmgrStatusCode.Name = "bootmgrStatusCode";
            this.bootmgrStatusCode.Size = new System.Drawing.Size(644, 31);
            this.bootmgrStatusCode.TabIndex = 8;
            this.bootmgrStatusCode.Text = "0xc000000e";
            // 
            // bootmgrInfoDetails
            // 
            this.bootmgrInfoDetails.BackColor = System.Drawing.Color.Black;
            this.bootmgrInfoDetails.Font = new System.Drawing.Font("Consolas", 16F);
            this.bootmgrInfoDetails.ForeColor = System.Drawing.Color.White;
            this.bootmgrInfoDetails.Location = new System.Drawing.Point(161, 507);
            this.bootmgrInfoDetails.Name = "bootmgrInfoDetails";
            this.bootmgrInfoDetails.Size = new System.Drawing.Size(766, 65);
            this.bootmgrInfoDetails.TabIndex = 9;
            this.bootmgrInfoDetails.Text = "The boot selection failed because a required device is\r\ninaccessible.";
            // 
            // screenUpdater
            // 
            this.screenUpdater.Enabled = true;
            this.screenUpdater.Tick += new System.EventHandler(this.UpdateScreen);
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
            this.Controls.Add(this.bootmgrInfoDetails);
            this.Controls.Add(this.bootmgrStatusCode);
            this.Controls.Add(this.bootmgrInfo);
            this.Controls.Add(this.bootmgrStatus);
            this.Controls.Add(this.bootmgrEscapeExit);
            this.Controls.Add(this.bootmgrEnterContinue);
            this.Controls.Add(this.bootmgrConsultAdmin);
            this.Controls.Add(this.bootmgrTroubleshoot);
            this.Controls.Add(this.bootmgrIntro);
            this.Controls.Add(this.bootmgrTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BootMgr";
            this.Text = "Windows Boot Manager error screen simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Unloading);
            this.Load += new System.EventHandler(this.Initialization);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyChecker);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bootmgrTitle;
        private System.Windows.Forms.Label bootmgrIntro;
        private System.Windows.Forms.Label bootmgrTroubleshoot;
        private System.Windows.Forms.Label bootmgrConsultAdmin;
        private System.Windows.Forms.Label bootmgrEnterContinue;
        private System.Windows.Forms.Label bootmgrEscapeExit;
        private System.Windows.Forms.Label bootmgrStatus;
        private System.Windows.Forms.Label bootmgrInfo;
        private System.Windows.Forms.Label bootmgrStatusCode;
        private System.Windows.Forms.Label bootmgrInfoDetails;
        private System.Windows.Forms.Timer screenUpdater;
        private System.Windows.Forms.Label waterMarkText;
    }
}