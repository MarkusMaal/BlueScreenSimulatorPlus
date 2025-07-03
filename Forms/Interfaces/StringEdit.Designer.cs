using MaterialSkin.Controls;

namespace UltimateBlueScreenSimulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringEdit));
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Property name", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Value", System.Windows.Forms.HorizontalAlignment.Left);
            this.AllIcons = new System.Windows.Forms.ImageList(this.components);
            this.MessageView = new MaterialSkin.Controls.MaterialListView();
            this.specificProps = new MaterialSkin.Controls.MaterialLabel();
            this.buttonOK = new MaterialSkin.Controls.MaterialButton();
            this.stringProps = new System.Windows.Forms.Panel();
            this.stringEditor = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.colorProps = new System.Windows.Forms.Panel();
            this.colorButton = new MaterialSkin.Controls.MaterialButton();
            this.colorPreview = new System.Windows.Forms.Label();
            this.specificPropsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.xpMsgChooser = new System.Windows.Forms.FlowLayoutPanel();
            this.autoRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.manualRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.qrProps = new System.Windows.Forms.Panel();
            this.browseButton = new MaterialSkin.Controls.MaterialButton();
            this.filenameLabel = new MaterialSkin.Controls.MaterialLabel();
            this.radioFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.defaultRadioBtn = new MaterialSkin.Controls.MaterialRadioButton();
            this.transparentRadioBtn = new MaterialSkin.Controls.MaterialRadioButton();
            this.customRadioBtn = new MaterialSkin.Controls.MaterialRadioButton();
            this.timeoutProps = new System.Windows.Forms.Panel();
            this.timeoutBox = new MaterialSkin.Controls.MaterialTextBox();
            this.secondsLabel = new MaterialSkin.Controls.MaterialLabel();
            this.fontProps = new System.Windows.Forms.Panel();
            this.fontChangeButton = new MaterialSkin.Controls.MaterialButton();
            this.fontPreview = new System.Windows.Forms.Label();
            this.blinkProps = new System.Windows.Forms.Panel();
            this.speedTrackbar = new MaterialSkin.Controls.MaterialSlider();
            this.blinkingDash = new MaterialSkin.Controls.MaterialLabel();
            this.previewLabel = new MaterialSkin.Controls.MaterialLabel();
            this.colorChooser = new System.Windows.Forms.ColorDialog();
            this.blinkywinky = new System.Windows.Forms.Timer(this.components);
            this.fontChooser = new System.Windows.Forms.FontDialog();
            this.simpleToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.customQRBrowser = new System.Windows.Forms.OpenFileDialog();
            this.whereTheButtonsLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.stringProps.SuspendLayout();
            this.colorProps.SuspendLayout();
            this.specificPropsFlowLayoutPanel.SuspendLayout();
            this.xpMsgChooser.SuspendLayout();
            this.qrProps.SuspendLayout();
            this.radioFlowLayoutPanel.SuspendLayout();
            this.timeoutProps.SuspendLayout();
            this.fontProps.SuspendLayout();
            this.blinkProps.SuspendLayout();
            this.SuspendLayout();
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
            // MessageView
            // 
            this.MessageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageView.AutoSizeTable = false;
            this.MessageView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MessageView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MessageView.Depth = 0;
            this.MessageView.FullRowSelect = true;
            listViewGroup3.Header = "Property name";
            listViewGroup3.Name = "listViewGroup1";
            listViewGroup4.Header = "Value";
            listViewGroup4.Name = "listViewGroup2";
            this.MessageView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup3,
            listViewGroup4});
            this.MessageView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MessageView.HideSelection = false;
            this.MessageView.LargeImageList = this.AllIcons;
            this.MessageView.Location = new System.Drawing.Point(12, 52);
            this.MessageView.MinimumSize = new System.Drawing.Size(200, 100);
            this.MessageView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.MessageView.MouseState = MaterialSkin.MouseState.OUT;
            this.MessageView.MultiSelect = false;
            this.MessageView.Name = "MessageView";
            this.MessageView.OwnerDraw = true;
            this.MessageView.ShowGroups = false;
            this.MessageView.Size = new System.Drawing.Size(417, 426);
            this.MessageView.SmallImageList = this.AllIcons;
            this.MessageView.TabIndex = 0;
            this.MessageView.UseCompatibleStateImageBehavior = false;
            this.MessageView.View = System.Windows.Forms.View.Details;
            this.MessageView.SelectedIndexChanged += new System.EventHandler(this.MessageView_SelectedIndexChanged);
            // 
            // specificProps
            // 
            this.specificProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.specificProps.Depth = 0;
            this.specificProps.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.specificProps.Location = new System.Drawing.Point(455, 30);
            this.specificProps.MouseState = MaterialSkin.MouseState.HOVER;
            this.specificProps.Name = "specificProps";
            this.specificProps.Size = new System.Drawing.Size(403, 22);
            this.specificProps.TabIndex = 4;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.AutoSize = false;
            this.buttonOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOK.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonOK.Depth = 0;
            this.buttonOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOK.HighEmphasis = true;
            this.buttonOK.Icon = null;
            this.buttonOK.Location = new System.Drawing.Point(773, 485);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonOK.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonOK.Size = new System.Drawing.Size(86, 26);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "&OK";
            this.buttonOK.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonOK.UseAccentColor = false;
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
            this.stringEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.stringEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stringEditor.Depth = 0;
            this.stringEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stringEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.stringEditor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.stringEditor.Location = new System.Drawing.Point(0, 0);
            this.stringEditor.MaxLength = 65536;
            this.stringEditor.MouseState = MaterialSkin.MouseState.OUT;
            this.stringEditor.Name = "stringEditor";
            this.stringEditor.Size = new System.Drawing.Size(400, 175);
            this.stringEditor.TabIndex = 1;
            this.stringEditor.Text = "";
            this.stringEditor.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // colorProps
            // 
            this.colorProps.Controls.Add(this.colorButton);
            this.colorProps.Controls.Add(this.colorPreview);
            this.colorProps.Location = new System.Drawing.Point(3, 561);
            this.colorProps.Name = "colorProps";
            this.colorProps.Size = new System.Drawing.Size(394, 42);
            this.colorProps.TabIndex = 5;
            this.colorProps.Visible = false;
            // 
            // colorButton
            // 
            this.colorButton.AutoSize = false;
            this.colorButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.colorButton.Depth = 0;
            this.colorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.colorButton.HighEmphasis = true;
            this.colorButton.Icon = null;
            this.colorButton.Location = new System.Drawing.Point(56, 10);
            this.colorButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.colorButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.colorButton.Name = "colorButton";
            this.colorButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.colorButton.Size = new System.Drawing.Size(75, 23);
            this.colorButton.TabIndex = 3;
            this.colorButton.Text = "Change";
            this.colorButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.colorButton.UseAccentColor = false;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // colorPreview
            // 
            this.colorPreview.BackColor = System.Drawing.Color.Black;
            this.colorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.colorPreview.Location = new System.Drawing.Point(11, 10);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(39, 23);
            this.colorPreview.TabIndex = 2;
            // 
            // specificPropsFlowLayoutPanel
            // 
            this.specificPropsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specificPropsFlowLayoutPanel.AutoScroll = true;
            this.specificPropsFlowLayoutPanel.Controls.Add(this.stringProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.xpMsgChooser);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.qrProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.timeoutProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.fontProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.blinkProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.colorProps);
            this.specificPropsFlowLayoutPanel.Location = new System.Drawing.Point(435, 52);
            this.specificPropsFlowLayoutPanel.Name = "specificPropsFlowLayoutPanel";
            this.specificPropsFlowLayoutPanel.Size = new System.Drawing.Size(424, 428);
            this.specificPropsFlowLayoutPanel.TabIndex = 2;
            // 
            // xpMsgChooser
            // 
            this.xpMsgChooser.Controls.Add(this.autoRadio);
            this.xpMsgChooser.Controls.Add(this.manualRadio);
            this.xpMsgChooser.Location = new System.Drawing.Point(3, 184);
            this.xpMsgChooser.Name = "xpMsgChooser";
            this.xpMsgChooser.Size = new System.Drawing.Size(401, 37);
            this.xpMsgChooser.TabIndex = 7;
            this.xpMsgChooser.Visible = false;
            // 
            // autoRadio
            // 
            this.autoRadio.AutoSize = true;
            this.autoRadio.Checked = true;
            this.autoRadio.Depth = 0;
            this.autoRadio.Location = new System.Drawing.Point(0, 0);
            this.autoRadio.Margin = new System.Windows.Forms.Padding(0);
            this.autoRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.autoRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.autoRadio.Name = "autoRadio";
            this.autoRadio.Ripple = true;
            this.autoRadio.Size = new System.Drawing.Size(68, 37);
            this.autoRadio.TabIndex = 0;
            this.autoRadio.TabStop = true;
            this.autoRadio.Text = "Auto";
            this.autoRadio.UseVisualStyleBackColor = true;
            this.autoRadio.CheckedChanged += new System.EventHandler(this.autoRadio_CheckedChanged);
            // 
            // manualRadio
            // 
            this.manualRadio.AutoSize = true;
            this.manualRadio.Depth = 0;
            this.manualRadio.Location = new System.Drawing.Point(68, 0);
            this.manualRadio.Margin = new System.Windows.Forms.Padding(0);
            this.manualRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.manualRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.manualRadio.Name = "manualRadio";
            this.manualRadio.Ripple = true;
            this.manualRadio.Size = new System.Drawing.Size(89, 37);
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
            this.qrProps.Location = new System.Drawing.Point(3, 227);
            this.qrProps.Name = "qrProps";
            this.qrProps.Size = new System.Drawing.Size(394, 111);
            this.qrProps.TabIndex = 1;
            this.qrProps.Visible = false;
            // 
            // browseButton
            // 
            this.browseButton.AutoSize = false;
            this.browseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.browseButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.browseButton.Depth = 0;
            this.browseButton.Enabled = false;
            this.browseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.browseButton.HighEmphasis = true;
            this.browseButton.Icon = null;
            this.browseButton.Location = new System.Drawing.Point(12, 72);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.browseButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.browseButton.Name = "browseButton";
            this.browseButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse";
            this.browseButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.browseButton.UseAccentColor = false;
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Depth = 0;
            this.filenameLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filenameLabel.Location = new System.Drawing.Point(9, 47);
            this.filenameLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(121, 19);
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
            this.radioFlowLayoutPanel.Size = new System.Drawing.Size(384, 33);
            this.radioFlowLayoutPanel.TabIndex = 1;
            // 
            // defaultRadioBtn
            // 
            this.defaultRadioBtn.AutoSize = true;
            this.defaultRadioBtn.Checked = true;
            this.defaultRadioBtn.Depth = 0;
            this.defaultRadioBtn.Location = new System.Drawing.Point(0, 0);
            this.defaultRadioBtn.Margin = new System.Windows.Forms.Padding(0);
            this.defaultRadioBtn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.defaultRadioBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.defaultRadioBtn.Name = "defaultRadioBtn";
            this.defaultRadioBtn.Ripple = true;
            this.defaultRadioBtn.Size = new System.Drawing.Size(87, 37);
            this.defaultRadioBtn.TabIndex = 2;
            this.defaultRadioBtn.TabStop = true;
            this.defaultRadioBtn.Text = "Default";
            this.defaultRadioBtn.UseVisualStyleBackColor = true;
            this.defaultRadioBtn.CheckedChanged += new System.EventHandler(this.DefaultRadioBtn_CheckedChanged);
            // 
            // transparentRadioBtn
            // 
            this.transparentRadioBtn.AutoSize = true;
            this.transparentRadioBtn.Depth = 0;
            this.transparentRadioBtn.Location = new System.Drawing.Point(87, 0);
            this.transparentRadioBtn.Margin = new System.Windows.Forms.Padding(0);
            this.transparentRadioBtn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.transparentRadioBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.transparentRadioBtn.Name = "transparentRadioBtn";
            this.transparentRadioBtn.Ripple = true;
            this.transparentRadioBtn.Size = new System.Drawing.Size(121, 37);
            this.transparentRadioBtn.TabIndex = 3;
            this.transparentRadioBtn.Text = "Transparent";
            this.transparentRadioBtn.UseVisualStyleBackColor = true;
            this.transparentRadioBtn.CheckedChanged += new System.EventHandler(this.TransparentRadioBtn_CheckedChanged);
            // 
            // customRadioBtn
            // 
            this.customRadioBtn.AutoSize = true;
            this.customRadioBtn.Depth = 0;
            this.customRadioBtn.Location = new System.Drawing.Point(208, 0);
            this.customRadioBtn.Margin = new System.Windows.Forms.Padding(0);
            this.customRadioBtn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.customRadioBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.customRadioBtn.Name = "customRadioBtn";
            this.customRadioBtn.Ripple = true;
            this.customRadioBtn.Size = new System.Drawing.Size(90, 37);
            this.customRadioBtn.TabIndex = 4;
            this.customRadioBtn.Text = "Custom";
            this.customRadioBtn.UseVisualStyleBackColor = true;
            this.customRadioBtn.CheckedChanged += new System.EventHandler(this.CustomRadioBtn_CheckedChanged);
            // 
            // timeoutProps
            // 
            this.timeoutProps.Controls.Add(this.timeoutBox);
            this.timeoutProps.Controls.Add(this.secondsLabel);
            this.timeoutProps.Location = new System.Drawing.Point(3, 344);
            this.timeoutProps.Name = "timeoutProps";
            this.timeoutProps.Size = new System.Drawing.Size(394, 44);
            this.timeoutProps.TabIndex = 2;
            this.timeoutProps.Visible = false;
            // 
            // timeoutBox
            // 
            this.timeoutBox.AnimateReadOnly = false;
            this.timeoutBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeoutBox.Depth = 0;
            this.timeoutBox.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.timeoutBox.LeadingIcon = null;
            this.timeoutBox.Location = new System.Drawing.Point(9, 3);
            this.timeoutBox.MaxLength = 50;
            this.timeoutBox.MouseState = MaterialSkin.MouseState.OUT;
            this.timeoutBox.Multiline = false;
            this.timeoutBox.Name = "timeoutBox";
            this.timeoutBox.Size = new System.Drawing.Size(47, 36);
            this.timeoutBox.TabIndex = 1;
            this.timeoutBox.Text = "";
            this.timeoutBox.TrailingIcon = null;
            this.timeoutBox.UseTallSize = false;
            this.timeoutBox.TextChanged += new System.EventHandler(this.TimeoutBox_TextChanged);
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Depth = 0;
            this.secondsLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.secondsLabel.Location = new System.Drawing.Point(62, 12);
            this.secondsLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(60, 19);
            this.secondsLabel.TabIndex = 0;
            this.secondsLabel.Text = "seconds";
            // 
            // fontProps
            // 
            this.fontProps.Controls.Add(this.fontChangeButton);
            this.fontProps.Controls.Add(this.fontPreview);
            this.fontProps.Location = new System.Drawing.Point(3, 394);
            this.fontProps.Name = "fontProps";
            this.fontProps.Size = new System.Drawing.Size(394, 84);
            this.fontProps.TabIndex = 3;
            this.fontProps.Visible = false;
            // 
            // fontChangeButton
            // 
            this.fontChangeButton.AutoSize = false;
            this.fontChangeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fontChangeButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.fontChangeButton.Depth = 0;
            this.fontChangeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fontChangeButton.HighEmphasis = true;
            this.fontChangeButton.Icon = null;
            this.fontChangeButton.Location = new System.Drawing.Point(11, 54);
            this.fontChangeButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.fontChangeButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.fontChangeButton.Name = "fontChangeButton";
            this.fontChangeButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.fontChangeButton.Size = new System.Drawing.Size(75, 23);
            this.fontChangeButton.TabIndex = 5;
            this.fontChangeButton.Text = "Change";
            this.fontChangeButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.fontChangeButton.UseAccentColor = false;
            this.fontChangeButton.UseVisualStyleBackColor = true;
            this.fontChangeButton.Click += new System.EventHandler(this.FontChangeButton_Click);
            // 
            // fontPreview
            // 
            this.fontPreview.AutoSize = true;
            this.fontPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fontPreview.Location = new System.Drawing.Point(8, 12);
            this.fontPreview.Name = "fontPreview";
            this.fontPreview.Size = new System.Drawing.Size(292, 17);
            this.fontPreview.TabIndex = 4;
            this.fontPreview.Text = "The quick brown fox jumps over the lazy dog.";
            // 
            // blinkProps
            // 
            this.blinkProps.Controls.Add(this.speedTrackbar);
            this.blinkProps.Controls.Add(this.blinkingDash);
            this.blinkProps.Controls.Add(this.previewLabel);
            this.blinkProps.Location = new System.Drawing.Point(3, 484);
            this.blinkProps.Name = "blinkProps";
            this.blinkProps.Size = new System.Drawing.Size(394, 71);
            this.blinkProps.TabIndex = 4;
            this.blinkProps.Visible = false;
            // 
            // speedTrackbar
            // 
            this.speedTrackbar.Depth = 0;
            this.speedTrackbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.speedTrackbar.Location = new System.Drawing.Point(7, 28);
            this.speedTrackbar.MouseState = MaterialSkin.MouseState.HOVER;
            this.speedTrackbar.Name = "speedTrackbar";
            this.speedTrackbar.RangeMax = 2000;
            this.speedTrackbar.RangeMin = 1;
            this.speedTrackbar.ShowText = false;
            this.speedTrackbar.ShowValue = false;
            this.speedTrackbar.Size = new System.Drawing.Size(380, 40);
            this.speedTrackbar.TabIndex = 5;
            this.speedTrackbar.Text = "My Data";
            this.speedTrackbar.Value = 100;
            this.speedTrackbar.onValueChanged += new MaterialSkin.Controls.MaterialSlider.ValueChanged(this.speedTrackbar_onValueChanged);
            // 
            // blinkingDash
            // 
            this.blinkingDash.AutoSize = true;
            this.blinkingDash.Depth = 0;
            this.blinkingDash.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.blinkingDash.Location = new System.Drawing.Point(74, 12);
            this.blinkingDash.MouseState = MaterialSkin.MouseState.HOVER;
            this.blinkingDash.Name = "blinkingDash";
            this.blinkingDash.Size = new System.Drawing.Size(8, 19);
            this.blinkingDash.TabIndex = 4;
            this.blinkingDash.Text = "_";
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Depth = 0;
            this.previewLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.previewLabel.Location = new System.Drawing.Point(8, 12);
            this.previewLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(60, 19);
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
            // whereTheButtonsLink
            // 
            this.whereTheButtonsLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.whereTheButtonsLink.AutoSize = true;
            this.whereTheButtonsLink.Location = new System.Drawing.Point(12, 529);
            this.whereTheButtonsLink.Name = "whereTheButtonsLink";
            this.whereTheButtonsLink.Size = new System.Drawing.Size(189, 13);
            this.whereTheButtonsLink.TabIndex = 7;
            this.whereTheButtonsLink.TabStop = true;
            this.whereTheButtonsLink.Text = "&Where are the save and load buttons?";
            this.whereTheButtonsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(9, 492);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hack zone! Do not report issues caused by changing these settings!";
            // 
            // StringEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.whereTheButtonsLink);
            this.Controls.Add(this.specificPropsFlowLayoutPanel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.specificProps);
            this.Controls.Add(this.MessageView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(534, 206);
            this.Name = "StringEdit";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bluescreen hacks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StringEdit_FormClosing);
            this.Load += new System.EventHandler(this.StringEdit_Load);
            this.stringProps.ResumeLayout(false);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialListView MessageView;
        private MaterialSkin.Controls.MaterialLabel specificProps;
        private MaterialSkin.Controls.MaterialButton buttonOK;
        private System.Windows.Forms.Panel stringProps;
        private MaterialSkin.Controls.MaterialMultiLineTextBox stringEditor;
        private System.Windows.Forms.Panel colorProps;
        private MaterialSkin.Controls.MaterialButton colorButton;
        private System.Windows.Forms.Label colorPreview;
        private System.Windows.Forms.FlowLayoutPanel specificPropsFlowLayoutPanel;
        private System.Windows.Forms.ColorDialog colorChooser;
        private System.Windows.Forms.Panel blinkProps;
        private MaterialSkin.Controls.MaterialSlider speedTrackbar;
        private MaterialSkin.Controls.MaterialLabel blinkingDash;
        private MaterialSkin.Controls.MaterialLabel previewLabel;
        private System.Windows.Forms.Timer blinkywinky;
        private System.Windows.Forms.Panel fontProps;
        private MaterialSkin.Controls.MaterialButton fontChangeButton;
        private System.Windows.Forms.Label fontPreview;
        private System.Windows.Forms.FontDialog fontChooser;
        private System.Windows.Forms.Panel timeoutProps;
        private MaterialSkin.Controls.MaterialTextBox timeoutBox;
        private MaterialSkin.Controls.MaterialLabel secondsLabel;
        private System.Windows.Forms.ToolTip simpleToolTip;
        private System.Windows.Forms.Panel qrProps;
        private MaterialSkin.Controls.MaterialButton browseButton;
        private MaterialSkin.Controls.MaterialLabel filenameLabel;
        private System.Windows.Forms.FlowLayoutPanel radioFlowLayoutPanel;
        private MaterialSkin.Controls.MaterialRadioButton defaultRadioBtn;
        private MaterialSkin.Controls.MaterialRadioButton transparentRadioBtn;
        private MaterialSkin.Controls.MaterialRadioButton customRadioBtn;
        private System.Windows.Forms.OpenFileDialog customQRBrowser;
        private System.Windows.Forms.LinkLabel whereTheButtonsLink;
        internal System.Windows.Forms.ImageList AllIcons;
        private System.Windows.Forms.FlowLayoutPanel xpMsgChooser;
        private MaterialSkin.Controls.MaterialRadioButton autoRadio;
        private MaterialSkin.Controls.MaterialRadioButton manualRadio;
        private System.Windows.Forms.Label label1;
    }
}