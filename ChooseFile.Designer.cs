
namespace UltimateBlueScreenSimulator
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
            this.SuspendLayout();
            // 
            // fileBrowser
            // 
            this.fileBrowser.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.fileBrowser.AllowColumnReorder = true;
            this.fileBrowser.AutoArrange = false;
            this.fileBrowser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fileBrowser.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.Description});
            this.fileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileBrowser.FullRowSelect = true;
            this.fileBrowser.GridLines = true;
            this.fileBrowser.HideSelection = false;
            this.fileBrowser.LabelEdit = true;
            this.fileBrowser.Location = new System.Drawing.Point(0, 0);
            this.fileBrowser.MultiSelect = false;
            this.fileBrowser.Name = "fileBrowser";
            this.fileBrowser.Size = new System.Drawing.Size(588, 320);
            this.fileBrowser.TabIndex = 0;
            this.fileBrowser.UseCompatibleStateImageBehavior = false;
            this.fileBrowser.View = System.Windows.Forms.View.Details;
            this.fileBrowser.ItemActivate += new System.EventHandler(this.WhenUserSelectsTheDesiredFile);
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
            // ChooseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 320);
            this.Controls.Add(this.fileBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChooseFile";
            this.Text = "Choose culprit file";
            this.Load += new System.EventHandler(this.Initialize);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader FileName;
        private System.Windows.Forms.ColumnHeader Description;
        internal System.Windows.Forms.ListView fileBrowser;
    }
}