namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    partial class StringEdit
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Property name", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Value", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringEdit));
            this.labelProps = new System.Windows.Forms.Label();
            this.MessageView = new System.Windows.Forms.ListView();
            this.AllIcons = new System.Windows.Forms.ImageList(this.components);
            this.specificProps = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.stringProps = new System.Windows.Forms.Panel();
            this.stringEditor = new System.Windows.Forms.TextBox();
            this.colorProps = new System.Windows.Forms.Panel();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorPreview = new System.Windows.Forms.Label();
            this.specificPropsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.xpMsgChooser = new System.Windows.Forms.FlowLayoutPanel();
            this.autoRadio = new System.Windows.Forms.RadioButton();
            this.manualRadio = new System.Windows.Forms.RadioButton();
            this.qrProps = new System.Windows.Forms.Panel();
            this.browseButton = new System.Windows.Forms.Button();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.radioFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.defaultRadioBtn = new System.Windows.Forms.RadioButton();
            this.transparentRadioBtn = new System.Windows.Forms.RadioButton();
            this.customRadioBtn = new System.Windows.Forms.RadioButton();
            this.timeoutProps = new System.Windows.Forms.Panel();
            this.timeoutBox = new System.Windows.Forms.TextBox();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.fontProps = new System.Windows.Forms.Panel();
            this.fontChangeButton = new System.Windows.Forms.Button();
            this.fontPreview = new System.Windows.Forms.Label();
            this.blinkProps = new System.Windows.Forms.Panel();
            this.speedTrackbar = new System.Windows.Forms.TrackBar();
            this.blinkingDash = new System.Windows.Forms.Label();
            this.previewLabel = new System.Windows.Forms.Label();
            this.colorChooser = new System.Windows.Forms.ColorDialog();
            this.blinkywinky = new System.Windows.Forms.Timer(this.components);
            this.fontChooser = new System.Windows.Forms.FontDialog();
            this.simpleToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.customQRBrowser = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.bugcheckPreview = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.updatePreviewCheck = new System.Windows.Forms.CheckBox();
            this.stringProps.SuspendLayout();
            this.colorProps.SuspendLayout();
            this.specificPropsFlowLayoutPanel.SuspendLayout();
            this.xpMsgChooser.SuspendLayout();
            this.qrProps.SuspendLayout();
            this.radioFlowLayoutPanel.SuspendLayout();
            this.timeoutProps.SuspendLayout();
            this.fontProps.SuspendLayout();
            this.blinkProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugcheckPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // labelProps
            // 
            this.labelProps.AutoSize = true;
            this.labelProps.Location = new System.Drawing.Point(12, 23);
            this.labelProps.Name = "labelProps";
            this.labelProps.Size = new System.Drawing.Size(54, 13);
            this.labelProps.TabIndex = 3;
            this.labelProps.Text = "Properties";
            // 
            // MessageView
            // 
            this.MessageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageView.FullRowSelect = true;
            this.MessageView.GridLines = true;
            listViewGroup1.Header = "Property name";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "Value";
            listViewGroup2.Name = "listViewGroup2";
            this.MessageView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.MessageView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MessageView.HideSelection = false;
            this.MessageView.LargeImageList = this.AllIcons;
            this.MessageView.Location = new System.Drawing.Point(12, 39);
            this.MessageView.MultiSelect = false;
            this.MessageView.Name = "MessageView";
            this.MessageView.ShowGroups = false;
            this.MessageView.Size = new System.Drawing.Size(390, 545);
            this.MessageView.SmallImageList = this.AllIcons;
            this.MessageView.TabIndex = 0;
            this.MessageView.UseCompatibleStateImageBehavior = false;
            this.MessageView.View = System.Windows.Forms.View.Details;
            this.MessageView.SelectedIndexChanged += new System.EventHandler(this.MessageView_SelectedIndexChanged);
            // 
            // AllIcons
            // 
            this.AllIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("AllIcons.ImageStream")));
            this.AllIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.AllIcons.Images.SetKeyName(0, "artage-io-48148_1564916990.ico");
            this.AllIcons.Images.SetKeyName(1, "Tatice-Operating-Systems-Windows.ico");
            this.AllIcons.Images.SetKeyName(2, "Dakirby309-Windows-8-Metro-Folders-OS-Windows-8-Metro.ico");
            this.AllIcons.Images.SetKeyName(3, "new-windows-logo (2).ico");
            this.AllIcons.Images.SetKeyName(4, "string.png");
            this.AllIcons.Images.SetKeyName(5, "setting.png");
            this.AllIcons.Images.SetKeyName(6, "theming.png");
            // 
            // specificProps
            // 
            this.specificProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.specificProps.Location = new System.Drawing.Point(407, 20);
            this.specificProps.Name = "specificProps";
            this.specificProps.Size = new System.Drawing.Size(383, 13);
            this.specificProps.TabIndex = 4;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOK.Location = new System.Drawing.Point(744, 600);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "&OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.Button1_Click);
            // 
            // stringProps
            // 
            this.stringProps.Controls.Add(this.stringEditor);
            this.stringProps.Location = new System.Drawing.Point(3, 3);
            this.stringProps.Name = "stringProps";
            this.stringProps.Size = new System.Drawing.Size(400, 175);
            this.stringProps.TabIndex = 6;
            this.stringProps.Visible = false;
            // 
            // stringEditor
            // 
            this.stringEditor.Location = new System.Drawing.Point(11, 6);
            this.stringEditor.Multiline = true;
            this.stringEditor.Name = "stringEditor";
            this.stringEditor.Size = new System.Drawing.Size(378, 158);
            this.stringEditor.TabIndex = 1;
            this.stringEditor.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // colorProps
            // 
            this.colorProps.Controls.Add(this.colorButton);
            this.colorProps.Controls.Add(this.colorPreview);
            this.colorProps.Location = new System.Drawing.Point(3, 493);
            this.colorProps.Name = "colorProps";
            this.colorProps.Size = new System.Drawing.Size(394, 42);
            this.colorProps.TabIndex = 5;
            this.colorProps.Visible = false;
            // 
            // colorButton
            // 
            this.colorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.colorButton.Location = new System.Drawing.Point(56, 10);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(75, 23);
            this.colorButton.TabIndex = 3;
            this.colorButton.Text = "Change";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // colorPreview
            // 
            this.colorPreview.BackColor = System.Drawing.Color.Black;
            this.colorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPreview.Location = new System.Drawing.Point(11, 10);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(39, 23);
            this.colorPreview.TabIndex = 2;
            // 
            // specificPropsFlowLayoutPanel
            // 
            this.specificPropsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specificPropsFlowLayoutPanel.Controls.Add(this.stringProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.xpMsgChooser);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.qrProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.timeoutProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.fontProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.blinkProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.colorProps);
            this.specificPropsFlowLayoutPanel.Location = new System.Drawing.Point(410, 39);
            this.specificPropsFlowLayoutPanel.Name = "specificPropsFlowLayoutPanel";
            this.specificPropsFlowLayoutPanel.Size = new System.Drawing.Size(404, 212);
            this.specificPropsFlowLayoutPanel.TabIndex = 2;
            // 
            // xpMsgChooser
            // 
            this.xpMsgChooser.Controls.Add(this.autoRadio);
            this.xpMsgChooser.Controls.Add(this.manualRadio);
            this.xpMsgChooser.Location = new System.Drawing.Point(3, 184);
            this.xpMsgChooser.Name = "xpMsgChooser";
            this.xpMsgChooser.Size = new System.Drawing.Size(401, 24);
            this.xpMsgChooser.TabIndex = 7;
            this.xpMsgChooser.Visible = false;
            // 
            // autoRadio
            // 
            this.autoRadio.AutoSize = true;
            this.autoRadio.Checked = true;
            this.autoRadio.Location = new System.Drawing.Point(3, 3);
            this.autoRadio.Name = "autoRadio";
            this.autoRadio.Size = new System.Drawing.Size(47, 17);
            this.autoRadio.TabIndex = 0;
            this.autoRadio.TabStop = true;
            this.autoRadio.Text = "Auto";
            this.autoRadio.UseVisualStyleBackColor = true;
            this.autoRadio.CheckedChanged += new System.EventHandler(this.autoRadio_CheckedChanged);
            // 
            // manualRadio
            // 
            this.manualRadio.AutoSize = true;
            this.manualRadio.Location = new System.Drawing.Point(56, 3);
            this.manualRadio.Name = "manualRadio";
            this.manualRadio.Size = new System.Drawing.Size(60, 17);
            this.manualRadio.TabIndex = 1;
            this.manualRadio.Text = "Manual";
            this.manualRadio.UseVisualStyleBackColor = true;
            this.manualRadio.CheckedChanged += new System.EventHandler(this.manualRadio_CheckedChanged);
            // 
            // qrProps
            // 
            this.qrProps.Controls.Add(this.browseButton);
            this.qrProps.Controls.Add(this.filenameLabel);
            this.qrProps.Controls.Add(this.radioFlowLayoutPanel);
            this.qrProps.Location = new System.Drawing.Point(3, 214);
            this.qrProps.Name = "qrProps";
            this.qrProps.Size = new System.Drawing.Size(394, 71);
            this.qrProps.TabIndex = 1;
            this.qrProps.Visible = false;
            // 
            // browseButton
            // 
            this.browseButton.Enabled = false;
            this.browseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.browseButton.Location = new System.Drawing.Point(10, 45);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(8, 29);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(86, 13);
            this.filenameLabel.TabIndex = 1;
            this.filenameLabel.Text = "Filename: local:0";
            // 
            // radioFlowLayoutPanel
            // 
            this.radioFlowLayoutPanel.Controls.Add(this.defaultRadioBtn);
            this.radioFlowLayoutPanel.Controls.Add(this.transparentRadioBtn);
            this.radioFlowLayoutPanel.Controls.Add(this.customRadioBtn);
            this.radioFlowLayoutPanel.Location = new System.Drawing.Point(7, 3);
            this.radioFlowLayoutPanel.Name = "radioFlowLayoutPanel";
            this.radioFlowLayoutPanel.Size = new System.Drawing.Size(222, 23);
            this.radioFlowLayoutPanel.TabIndex = 1;
            // 
            // defaultRadioBtn
            // 
            this.defaultRadioBtn.AutoSize = true;
            this.defaultRadioBtn.Checked = true;
            this.defaultRadioBtn.Location = new System.Drawing.Point(3, 3);
            this.defaultRadioBtn.Name = "defaultRadioBtn";
            this.defaultRadioBtn.Size = new System.Drawing.Size(59, 17);
            this.defaultRadioBtn.TabIndex = 2;
            this.defaultRadioBtn.TabStop = true;
            this.defaultRadioBtn.Text = "Default";
            this.defaultRadioBtn.UseVisualStyleBackColor = true;
            this.defaultRadioBtn.CheckedChanged += new System.EventHandler(this.DefaultRadioBtn_CheckedChanged);
            // 
            // transparentRadioBtn
            // 
            this.transparentRadioBtn.AutoSize = true;
            this.transparentRadioBtn.Location = new System.Drawing.Point(68, 3);
            this.transparentRadioBtn.Name = "transparentRadioBtn";
            this.transparentRadioBtn.Size = new System.Drawing.Size(82, 17);
            this.transparentRadioBtn.TabIndex = 3;
            this.transparentRadioBtn.Text = "Transparent";
            this.transparentRadioBtn.UseVisualStyleBackColor = true;
            this.transparentRadioBtn.CheckedChanged += new System.EventHandler(this.TransparentRadioBtn_CheckedChanged);
            // 
            // customRadioBtn
            // 
            this.customRadioBtn.AutoSize = true;
            this.customRadioBtn.Location = new System.Drawing.Point(156, 3);
            this.customRadioBtn.Name = "customRadioBtn";
            this.customRadioBtn.Size = new System.Drawing.Size(60, 17);
            this.customRadioBtn.TabIndex = 4;
            this.customRadioBtn.Text = "Custom";
            this.customRadioBtn.UseVisualStyleBackColor = true;
            this.customRadioBtn.CheckedChanged += new System.EventHandler(this.CustomRadioBtn_CheckedChanged);
            // 
            // timeoutProps
            // 
            this.timeoutProps.Controls.Add(this.timeoutBox);
            this.timeoutProps.Controls.Add(this.secondsLabel);
            this.timeoutProps.Location = new System.Drawing.Point(3, 291);
            this.timeoutProps.Name = "timeoutProps";
            this.timeoutProps.Size = new System.Drawing.Size(394, 29);
            this.timeoutProps.TabIndex = 2;
            this.timeoutProps.Visible = false;
            // 
            // timeoutBox
            // 
            this.timeoutBox.Location = new System.Drawing.Point(9, 3);
            this.timeoutBox.Name = "timeoutBox";
            this.timeoutBox.Size = new System.Drawing.Size(47, 20);
            this.timeoutBox.TabIndex = 1;
            this.timeoutBox.TextChanged += new System.EventHandler(this.TimeoutBox_TextChanged);
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Location = new System.Drawing.Point(62, 6);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(47, 13);
            this.secondsLabel.TabIndex = 0;
            this.secondsLabel.Text = "seconds";
            // 
            // fontProps
            // 
            this.fontProps.Controls.Add(this.fontChangeButton);
            this.fontProps.Controls.Add(this.fontPreview);
            this.fontProps.Location = new System.Drawing.Point(3, 326);
            this.fontProps.Name = "fontProps";
            this.fontProps.Size = new System.Drawing.Size(394, 84);
            this.fontProps.TabIndex = 3;
            this.fontProps.Visible = false;
            // 
            // fontChangeButton
            // 
            this.fontChangeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fontChangeButton.Location = new System.Drawing.Point(11, 54);
            this.fontChangeButton.Name = "fontChangeButton";
            this.fontChangeButton.Size = new System.Drawing.Size(75, 23);
            this.fontChangeButton.TabIndex = 5;
            this.fontChangeButton.Text = "Change";
            this.fontChangeButton.UseVisualStyleBackColor = true;
            this.fontChangeButton.Click += new System.EventHandler(this.FontChangeButton_Click);
            // 
            // fontPreview
            // 
            this.fontPreview.AutoSize = true;
            this.fontPreview.Location = new System.Drawing.Point(8, 12);
            this.fontPreview.Name = "fontPreview";
            this.fontPreview.Size = new System.Drawing.Size(221, 13);
            this.fontPreview.TabIndex = 4;
            this.fontPreview.Text = "The quick brown fox jumps over the lazy dog.";
            // 
            // blinkProps
            // 
            this.blinkProps.Controls.Add(this.speedTrackbar);
            this.blinkProps.Controls.Add(this.blinkingDash);
            this.blinkProps.Controls.Add(this.previewLabel);
            this.blinkProps.Location = new System.Drawing.Point(3, 416);
            this.blinkProps.Name = "blinkProps";
            this.blinkProps.Size = new System.Drawing.Size(394, 71);
            this.blinkProps.TabIndex = 4;
            this.blinkProps.Visible = false;
            // 
            // speedTrackbar
            // 
            this.speedTrackbar.Location = new System.Drawing.Point(7, 28);
            this.speedTrackbar.Maximum = 2000;
            this.speedTrackbar.Minimum = 1;
            this.speedTrackbar.Name = "speedTrackbar";
            this.speedTrackbar.Size = new System.Drawing.Size(380, 45);
            this.speedTrackbar.TabIndex = 5;
            this.speedTrackbar.Value = 100;
            this.speedTrackbar.Scroll += new System.EventHandler(this.TrackBar1_Scroll);
            // 
            // blinkingDash
            // 
            this.blinkingDash.AutoSize = true;
            this.blinkingDash.Location = new System.Drawing.Point(58, 12);
            this.blinkingDash.Name = "blinkingDash";
            this.blinkingDash.Size = new System.Drawing.Size(13, 13);
            this.blinkingDash.TabIndex = 4;
            this.blinkingDash.Text = "_";
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(8, 12);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(48, 13);
            this.previewLabel.TabIndex = 3;
            this.previewLabel.Text = "Preview:";
            // 
            // blinkywinky
            // 
            this.blinkywinky.Tick += new System.EventHandler(this.Blinkywinky_Tick);
            // 
            // simpleToolTip
            // 
            this.simpleToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.simpleToolTip.ToolTipTitle = "Cannot change to specific value";
            // 
            // customQRBrowser
            // 
            this.customQRBrowser.Filter = "Raster images|*.jpg;*.jpeg;*.jpe;*.png;*.bmp;*.gif;*.tif;*.tiff";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 604);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Hack zone! Do not report issues caused by changing these settings!";
            // 
            // bugcheckPreview
            // 
            this.bugcheckPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bugcheckPreview.Image = global::UltimateBlueScreenSimulator.Properties.Resources.loadpic;
            this.bugcheckPreview.Location = new System.Drawing.Point(410, 283);
            this.bugcheckPreview.Margin = new System.Windows.Forms.Padding(0);
            this.bugcheckPreview.Name = "bugcheckPreview";
            this.bugcheckPreview.Size = new System.Drawing.Size(404, 301);
            this.bugcheckPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bugcheckPreview.TabIndex = 12;
            this.bugcheckPreview.TabStop = false;
            this.bugcheckPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.bugcheckPreview_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Preview";
            // 
            // updatePreviewCheck
            // 
            this.updatePreviewCheck.AutoSize = true;
            this.updatePreviewCheck.Checked = true;
            this.updatePreviewCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.updatePreviewCheck.Location = new System.Drawing.Point(654, 264);
            this.updatePreviewCheck.Name = "updatePreviewCheck";
            this.updatePreviewCheck.Size = new System.Drawing.Size(165, 17);
            this.updatePreviewCheck.TabIndex = 14;
            this.updatePreviewCheck.Text = "Update preview automatically";
            this.updatePreviewCheck.UseVisualStyleBackColor = true;
            this.updatePreviewCheck.CheckedChanged += new System.EventHandler(this.updatePreviewCheck_CheckedChanged);
            // 
            // StringEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 635);
            this.Controls.Add(this.updatePreviewCheck);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bugcheckPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.specificPropsFlowLayoutPanel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.specificProps);
            this.Controls.Add(this.labelProps);
            this.Controls.Add(this.MessageView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(534, 206);
            this.Name = "StringEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bluescreen hacks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StringEdit_FormClosing);
            this.Load += new System.EventHandler(this.StringEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StringEdit_KeyDown);
            this.stringProps.ResumeLayout(false);
            this.stringProps.PerformLayout();
            this.colorProps.ResumeLayout(false);
            this.specificPropsFlowLayoutPanel.ResumeLayout(false);
            this.xpMsgChooser.ResumeLayout(false);
            this.xpMsgChooser.PerformLayout();
            this.qrProps.ResumeLayout(false);
            this.qrProps.PerformLayout();
            this.radioFlowLayoutPanel.ResumeLayout(false);
            this.radioFlowLayoutPanel.PerformLayout();
            this.timeoutProps.ResumeLayout(false);
            this.timeoutProps.PerformLayout();
            this.fontProps.ResumeLayout(false);
            this.fontProps.PerformLayout();
            this.blinkProps.ResumeLayout(false);
            this.blinkProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bugcheckPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelProps;
        private System.Windows.Forms.ListView MessageView;
        private System.Windows.Forms.Label specificProps;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Panel stringProps;
        private System.Windows.Forms.TextBox stringEditor;
        private System.Windows.Forms.Panel colorProps;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label colorPreview;
        private System.Windows.Forms.FlowLayoutPanel specificPropsFlowLayoutPanel;
        private System.Windows.Forms.ColorDialog colorChooser;
        private System.Windows.Forms.Panel blinkProps;
        private System.Windows.Forms.TrackBar speedTrackbar;
        private System.Windows.Forms.Label blinkingDash;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.Timer blinkywinky;
        private System.Windows.Forms.Panel fontProps;
        private System.Windows.Forms.Button fontChangeButton;
        private System.Windows.Forms.Label fontPreview;
        private System.Windows.Forms.FontDialog fontChooser;
        private System.Windows.Forms.Panel timeoutProps;
        private System.Windows.Forms.TextBox timeoutBox;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.ToolTip simpleToolTip;
        private System.Windows.Forms.Panel qrProps;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.FlowLayoutPanel radioFlowLayoutPanel;
        private System.Windows.Forms.RadioButton defaultRadioBtn;
        private System.Windows.Forms.RadioButton transparentRadioBtn;
        private System.Windows.Forms.RadioButton customRadioBtn;
        private System.Windows.Forms.OpenFileDialog customQRBrowser;
        private System.Windows.Forms.FlowLayoutPanel xpMsgChooser;
        private System.Windows.Forms.RadioButton autoRadio;
        private System.Windows.Forms.RadioButton manualRadio;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ImageList AllIcons;
        private System.Windows.Forms.PictureBox bugcheckPreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox updatePreviewCheck;
    }
}