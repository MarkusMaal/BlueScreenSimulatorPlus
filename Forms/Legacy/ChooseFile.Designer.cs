namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    partial class ChooseFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseFile));
            this.fileBrowser = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.okButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileBrowser
            // 
            this.fileBrowser.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.fileBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileBrowser.AutoArrange = false;
            this.fileBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileBrowser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.Description});
            this.fileBrowser.FullRowSelect = true;
            this.fileBrowser.GridLines = true;
            this.fileBrowser.HideSelection = false;
            this.fileBrowser.LabelWrap = false;
            this.fileBrowser.Location = new System.Drawing.Point(0, 0);
            this.fileBrowser.MultiSelect = false;
            this.fileBrowser.Name = "fileBrowser";
            this.fileBrowser.Size = new System.Drawing.Size(588, 280);
            this.fileBrowser.TabIndex = 0;
            this.fileBrowser.UseCompatibleStateImageBehavior = false;
            this.fileBrowser.View = System.Windows.Forms.View.Details;
            this.fileBrowser.ItemActivate += new System.EventHandler(this.WhenUserSelectsTheDesiredFile);
            this.fileBrowser.SelectedIndexChanged += new System.EventHandler(this.FileBrowser_SelectedIndexChanged);
            // 
            // FileName
            // 
            this.FileName.Text = "Filename";
            this.FileName.Width = 133;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 1000;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(506, 289);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(406, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Customize";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // ChooseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 320);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fileBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChooseFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose culprit file";
            this.Load += new System.EventHandler(this.Initialize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseFile_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader Description;
        internal System.Windows.Forms.ListView fileBrowser;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button2;
    }
}