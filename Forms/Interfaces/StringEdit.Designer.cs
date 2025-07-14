using MaterialSkin2Framework.Controls;

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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Property name", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Value", System.Windows.Forms.HorizontalAlignment.Left);
            this.AllIcons = new System.Windows.Forms.ImageList(this.components);
            this.MessageView = new MaterialSkin2Framework.Controls.MaterialListView();
            this.specificProps = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.buttonOK = new MaterialSkin2Framework.Controls.MaterialButton();
            this.stringProps = new System.Windows.Forms.Panel();
            this.stringEditor = new MaterialSkin2Framework.Controls.MaterialMultiLineTextBox();
            this.colorProps = new System.Windows.Forms.Panel();
            this.colorButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.colorPreview = new System.Windows.Forms.Label();
            this.specificPropsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.xpMsgChooser = new System.Windows.Forms.FlowLayoutPanel();
            this.autoRadio = new MaterialSkin2Framework.Controls.MaterialRadioButton();
            this.manualRadio = new MaterialSkin2Framework.Controls.MaterialRadioButton();
            this.qrProps = new System.Windows.Forms.Panel();
            this.radioFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.defaultRadioBtn = new MaterialSkin2Framework.Controls.MaterialRadioButton();
            this.transparentRadioBtn = new MaterialSkin2Framework.Controls.MaterialRadioButton();
            this.customRadioBtn = new MaterialSkin2Framework.Controls.MaterialRadioButton();
            this.browseButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.filenameLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.timeoutProps = new System.Windows.Forms.Panel();
            this.timeoutBox = new MaterialSkin2Framework.Controls.MaterialTextBox2();
            this.secondsLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.fontProps = new System.Windows.Forms.Panel();
            this.fontChangeButton = new MaterialSkin2Framework.Controls.MaterialButton();
            this.fontPreview = new System.Windows.Forms.Label();
            this.blinkProps = new System.Windows.Forms.Panel();
            this.speedTrackbar = new MaterialSkin2Framework.Controls.MaterialSlider();
            this.blinkingDash = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.previewLabel = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.bugcheckPreview = new System.Windows.Forms.PictureBox();
            this.colorChooser = new System.Windows.Forms.ColorDialog();
            this.blinkywinky = new System.Windows.Forms.Timer(this.components);
            this.fontChooser = new System.Windows.Forms.FontDialog();
            this.simpleToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.customQRBrowser = new System.Windows.Forms.OpenFileDialog();
            this.whereTheButtonsLink = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.previewRefresh = new System.Windows.Forms.Timer(this.components);
            this.updatePreviewCheck = new MaterialSkin2Framework.Controls.MaterialCheckbox();
            this.materialLabel2 = new MaterialSkin2Framework.Controls.MaterialLabel();
            this.stringProps.SuspendLayout();
            this.colorProps.SuspendLayout();
            this.specificPropsFlowLayoutPanel.SuspendLayout();
            this.xpMsgChooser.SuspendLayout();
            this.qrProps.SuspendLayout();
            this.radioFlowLayoutPanel.SuspendLayout();
            this.timeoutProps.SuspendLayout();
            this.fontProps.SuspendLayout();
            this.blinkProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bugcheckPreview)).BeginInit();
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
            this.MessageView.Location = new System.Drawing.Point(16, 64);
            this.MessageView.Margin = new System.Windows.Forms.Padding(4);
            this.MessageView.MinimumSize = new System.Drawing.Size(267, 123);
            this.MessageView.MouseLocation = new System.Drawing.Point(-1, -1);
            this.MessageView.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.MessageView.MultiSelect = false;
            this.MessageView.Name = "MessageView";
            this.MessageView.OwnerDraw = true;
            this.MessageView.ShowGroups = false;
            this.MessageView.Size = new System.Drawing.Size(397, 509);
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
            this.specificProps.Location = new System.Drawing.Point(260, 33);
            this.specificProps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.specificProps.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.specificProps.Name = "specificProps";
            this.specificProps.Size = new System.Drawing.Size(537, 27);
            this.specificProps.TabIndex = 4;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.AutoSize = false;
            this.buttonOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonOK.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonOK.Depth = 0;
            this.buttonOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonOK.HighEmphasis = true;
            this.buttonOK.Icon = null;
            this.buttonOK.Location = new System.Drawing.Point(711, 581);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.buttonOK.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonOK.Size = new System.Drawing.Size(115, 32);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "&OK";
            this.buttonOK.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonOK.UseAccentColor = false;
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.Button1_Click);
            // 
            // stringProps
            // 
            this.stringProps.Controls.Add(this.stringEditor);
            this.stringProps.Location = new System.Drawing.Point(4, 58);
            this.stringProps.Margin = new System.Windows.Forms.Padding(4);
            this.stringProps.Name = "stringProps";
            this.stringProps.Size = new System.Drawing.Size(373, 179);
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
            this.stringEditor.Margin = new System.Windows.Forms.Padding(4);
            this.stringEditor.MaxLength = 65536;
            this.stringEditor.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.stringEditor.Name = "stringEditor";
            this.stringEditor.Size = new System.Drawing.Size(373, 179);
            this.stringEditor.TabIndex = 1;
            this.stringEditor.Text = "";
            this.stringEditor.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // colorProps
            // 
            this.colorProps.Controls.Add(this.colorButton);
            this.colorProps.Controls.Add(this.colorPreview);
            this.colorProps.Location = new System.Drawing.Point(4, 658);
            this.colorProps.Margin = new System.Windows.Forms.Padding(4);
            this.colorProps.Name = "colorProps";
            this.colorProps.Size = new System.Drawing.Size(373, 52);
            this.colorProps.TabIndex = 5;
            this.colorProps.Visible = false;
            // 
            // colorButton
            // 
            this.colorButton.AutoSize = false;
            this.colorButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.colorButton.Depth = 0;
            this.colorButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.colorButton.HighEmphasis = true;
            this.colorButton.Icon = null;
            this.colorButton.Location = new System.Drawing.Point(75, 12);
            this.colorButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.colorButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.colorButton.Name = "colorButton";
            this.colorButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.colorButton.Size = new System.Drawing.Size(100, 28);
            this.colorButton.TabIndex = 3;
            this.colorButton.Text = "Change";
            this.colorButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.colorButton.UseAccentColor = false;
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // colorPreview
            // 
            this.colorPreview.BackColor = System.Drawing.Color.Black;
            this.colorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.colorPreview.Location = new System.Drawing.Point(15, 12);
            this.colorPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(51, 28);
            this.colorPreview.TabIndex = 2;
            // 
            // specificPropsFlowLayoutPanel
            // 
            this.specificPropsFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specificPropsFlowLayoutPanel.AutoScroll = true;
            this.specificPropsFlowLayoutPanel.Controls.Add(this.xpMsgChooser);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.stringProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.qrProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.timeoutProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.fontProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.blinkProps);
            this.specificPropsFlowLayoutPanel.Controls.Add(this.colorProps);
            this.specificPropsFlowLayoutPanel.Location = new System.Drawing.Point(421, 64);
            this.specificPropsFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.specificPropsFlowLayoutPanel.Name = "specificPropsFlowLayoutPanel";
            this.specificPropsFlowLayoutPanel.Size = new System.Drawing.Size(402, 196);
            this.specificPropsFlowLayoutPanel.TabIndex = 2;
            // 
            // xpMsgChooser
            // 
            this.xpMsgChooser.Controls.Add(this.autoRadio);
            this.xpMsgChooser.Controls.Add(this.manualRadio);
            this.xpMsgChooser.Location = new System.Drawing.Point(4, 4);
            this.xpMsgChooser.Margin = new System.Windows.Forms.Padding(4);
            this.xpMsgChooser.Name = "xpMsgChooser";
            this.xpMsgChooser.Size = new System.Drawing.Size(373, 46);
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
            this.autoRadio.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.autoRadio.Name = "autoRadio";
            this.autoRadio.Ripple = true;
            this.autoRadio.Size = new System.Drawing.Size(68, 37);
            this.autoRadio.TabIndex = 0;
            this.autoRadio.TabStop = true;
            this.autoRadio.Text = "Auto";
            this.autoRadio.UseVisualStyleBackColor = true;
            this.autoRadio.CheckedChanged += new System.EventHandler(this.AutoRadio_CheckedChanged);
            // 
            // manualRadio
            // 
            this.manualRadio.AutoSize = true;
            this.manualRadio.Depth = 0;
            this.manualRadio.Location = new System.Drawing.Point(68, 0);
            this.manualRadio.Margin = new System.Windows.Forms.Padding(0);
            this.manualRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.manualRadio.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.manualRadio.Name = "manualRadio";
            this.manualRadio.Ripple = true;
            this.manualRadio.Size = new System.Drawing.Size(89, 37);
            this.manualRadio.TabIndex = 1;
            this.manualRadio.Text = "Manual";
            this.manualRadio.UseVisualStyleBackColor = true;
            this.manualRadio.CheckedChanged += new System.EventHandler(this.ManualRadio_CheckedChanged);
            // 
            // qrProps
            // 
            this.qrProps.Controls.Add(this.radioFlowLayoutPanel);
            this.qrProps.Controls.Add(this.browseButton);
            this.qrProps.Controls.Add(this.filenameLabel);
            this.qrProps.Location = new System.Drawing.Point(4, 245);
            this.qrProps.Margin = new System.Windows.Forms.Padding(4);
            this.qrProps.Name = "qrProps";
            this.qrProps.Size = new System.Drawing.Size(373, 137);
            this.qrProps.TabIndex = 1;
            this.qrProps.Visible = false;
            // 
            // radioFlowLayoutPanel
            // 
            this.radioFlowLayoutPanel.Controls.Add(this.defaultRadioBtn);
            this.radioFlowLayoutPanel.Controls.Add(this.transparentRadioBtn);
            this.radioFlowLayoutPanel.Controls.Add(this.customRadioBtn);
            this.radioFlowLayoutPanel.Location = new System.Drawing.Point(8, 4);
            this.radioFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.radioFlowLayoutPanel.Name = "radioFlowLayoutPanel";
            this.radioFlowLayoutPanel.Size = new System.Drawing.Size(365, 41);
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
            this.defaultRadioBtn.MouseState = MaterialSkin2Framework.MouseState.HOVER;
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
            this.transparentRadioBtn.MouseState = MaterialSkin2Framework.MouseState.HOVER;
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
            this.customRadioBtn.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.customRadioBtn.Name = "customRadioBtn";
            this.customRadioBtn.Ripple = true;
            this.customRadioBtn.Size = new System.Drawing.Size(90, 37);
            this.customRadioBtn.TabIndex = 4;
            this.customRadioBtn.Text = "Custom";
            this.customRadioBtn.UseVisualStyleBackColor = true;
            this.customRadioBtn.CheckedChanged += new System.EventHandler(this.CustomRadioBtn_CheckedChanged);
            // 
            // browseButton
            // 
            this.browseButton.AutoSize = false;
            this.browseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.browseButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.browseButton.Depth = 0;
            this.browseButton.Enabled = false;
            this.browseButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.browseButton.HighEmphasis = true;
            this.browseButton.Icon = null;
            this.browseButton.Location = new System.Drawing.Point(16, 89);
            this.browseButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.browseButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.browseButton.Name = "browseButton";
            this.browseButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.browseButton.Size = new System.Drawing.Size(100, 28);
            this.browseButton.TabIndex = 5;
            this.browseButton.Text = "Browse";
            this.browseButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.browseButton.UseAccentColor = false;
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Depth = 0;
            this.filenameLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.filenameLabel.Location = new System.Drawing.Point(12, 58);
            this.filenameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.filenameLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(121, 19);
            this.filenameLabel.TabIndex = 1;
            this.filenameLabel.Text = "Filename: local:0";
            // 
            // timeoutProps
            // 
            this.timeoutProps.Controls.Add(this.timeoutBox);
            this.timeoutProps.Controls.Add(this.secondsLabel);
            this.timeoutProps.Location = new System.Drawing.Point(4, 390);
            this.timeoutProps.Margin = new System.Windows.Forms.Padding(4);
            this.timeoutProps.Name = "timeoutProps";
            this.timeoutProps.Size = new System.Drawing.Size(373, 54);
            this.timeoutProps.TabIndex = 2;
            this.timeoutProps.Visible = false;
            // 
            // timeoutBox
            // 
            this.timeoutBox.AnimateReadOnly = false;
            this.timeoutBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.timeoutBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.timeoutBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.timeoutBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.timeoutBox.Depth = 0;
            this.timeoutBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.timeoutBox.HideSelection = true;
            this.timeoutBox.LeadingIcon = null;
            this.timeoutBox.Location = new System.Drawing.Point(12, 4);
            this.timeoutBox.Margin = new System.Windows.Forms.Padding(4);
            this.timeoutBox.MaxLength = 50;
            this.timeoutBox.MouseState = MaterialSkin2Framework.MouseState.OUT;
            this.timeoutBox.Name = "timeoutBox";
            this.timeoutBox.PasswordChar = '\0';
            this.timeoutBox.PrefixSuffixText = null;
            this.timeoutBox.ReadOnly = false;
            this.timeoutBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeoutBox.SelectedText = "";
            this.timeoutBox.SelectionLength = 0;
            this.timeoutBox.SelectionStart = 0;
            this.timeoutBox.ShortcutsEnabled = true;
            this.timeoutBox.Size = new System.Drawing.Size(63, 36);
            this.timeoutBox.TabIndex = 1;
            this.timeoutBox.TabStop = false;
            this.timeoutBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.timeoutBox.TrailingIcon = null;
            this.timeoutBox.UseSystemPasswordChar = false;
            this.timeoutBox.UseTallSize = false;
            this.timeoutBox.TextChanged += new System.EventHandler(this.TimeoutBox_TextChanged);
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Depth = 0;
            this.secondsLabel.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.secondsLabel.Location = new System.Drawing.Point(83, 15);
            this.secondsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.secondsLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(60, 19);
            this.secondsLabel.TabIndex = 0;
            this.secondsLabel.Text = "seconds";
            // 
            // fontProps
            // 
            this.fontProps.Controls.Add(this.fontChangeButton);
            this.fontProps.Controls.Add(this.fontPreview);
            this.fontProps.Location = new System.Drawing.Point(4, 452);
            this.fontProps.Margin = new System.Windows.Forms.Padding(4);
            this.fontProps.Name = "fontProps";
            this.fontProps.Size = new System.Drawing.Size(373, 103);
            this.fontProps.TabIndex = 3;
            this.fontProps.Visible = false;
            // 
            // fontChangeButton
            // 
            this.fontChangeButton.AutoSize = false;
            this.fontChangeButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.fontChangeButton.Density = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.fontChangeButton.Depth = 0;
            this.fontChangeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fontChangeButton.HighEmphasis = true;
            this.fontChangeButton.Icon = null;
            this.fontChangeButton.Location = new System.Drawing.Point(15, 66);
            this.fontChangeButton.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.fontChangeButton.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.fontChangeButton.Name = "fontChangeButton";
            this.fontChangeButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.fontChangeButton.Size = new System.Drawing.Size(100, 28);
            this.fontChangeButton.TabIndex = 5;
            this.fontChangeButton.Text = "Change";
            this.fontChangeButton.Type = MaterialSkin2Framework.Controls.MaterialButton.MaterialButtonType.Contained;
            this.fontChangeButton.UseAccentColor = false;
            this.fontChangeButton.UseVisualStyleBackColor = true;
            this.fontChangeButton.Click += new System.EventHandler(this.FontChangeButton_Click);
            // 
            // fontPreview
            // 
            this.fontPreview.AutoSize = true;
            this.fontPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.fontPreview.Location = new System.Drawing.Point(11, 15);
            this.fontPreview.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.blinkProps.Location = new System.Drawing.Point(4, 563);
            this.blinkProps.Margin = new System.Windows.Forms.Padding(4);
            this.blinkProps.Name = "blinkProps";
            this.blinkProps.Size = new System.Drawing.Size(373, 87);
            this.blinkProps.TabIndex = 4;
            this.blinkProps.Visible = false;
            // 
            // speedTrackbar
            // 
            this.speedTrackbar.Depth = 0;
            this.speedTrackbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.speedTrackbar.Location = new System.Drawing.Point(9, 34);
            this.speedTrackbar.Margin = new System.Windows.Forms.Padding(4);
            this.speedTrackbar.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.speedTrackbar.Name = "speedTrackbar";
            this.speedTrackbar.RangeMax = 2000;
            this.speedTrackbar.RangeMin = 1;
            this.speedTrackbar.ShowText = false;
            this.speedTrackbar.ShowValue = false;
            this.speedTrackbar.Size = new System.Drawing.Size(507, 40);
            this.speedTrackbar.TabIndex = 5;
            this.speedTrackbar.Text = "My Data";
            this.speedTrackbar.Value = 100;
            this.speedTrackbar.onValueChanged += new MaterialSkin2Framework.Controls.MaterialSlider.ValueChanged(this.SpeedTrackbar_onValueChanged);
            // 
            // blinkingDash
            // 
            this.blinkingDash.AutoSize = true;
            this.blinkingDash.Depth = 0;
            this.blinkingDash.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.blinkingDash.Location = new System.Drawing.Point(99, 15);
            this.blinkingDash.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blinkingDash.MouseState = MaterialSkin2Framework.MouseState.HOVER;
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
            this.previewLabel.Location = new System.Drawing.Point(11, 15);
            this.previewLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.previewLabel.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(60, 19);
            this.previewLabel.TabIndex = 3;
            this.previewLabel.Text = "Preview:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(421, 273);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.materialLabel1.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(152, 28);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Preview";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bugcheckPreview
            // 
            this.bugcheckPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bugcheckPreview.Image = global::UltimateBlueScreenSimulator.Properties.Resources.loadpic;
            this.bugcheckPreview.Location = new System.Drawing.Point(421, 306);
            this.bugcheckPreview.Margin = new System.Windows.Forms.Padding(0);
            this.bugcheckPreview.Name = "bugcheckPreview";
            this.bugcheckPreview.Size = new System.Drawing.Size(404, 265);
            this.bugcheckPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bugcheckPreview.TabIndex = 1;
            this.bugcheckPreview.TabStop = false;
            this.bugcheckPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.BugcheckPreview_Paint);
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
            this.whereTheButtonsLink.Location = new System.Drawing.Point(16, 635);
            this.whereTheButtonsLink.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.whereTheButtonsLink.Name = "whereTheButtonsLink";
            this.whereTheButtonsLink.Size = new System.Drawing.Size(233, 16);
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
            this.label1.Location = new System.Drawing.Point(12, 590);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Hack zone! Do not report issues caused by changing these settings!";
            // 
            // updatePreviewCheck
            // 
            this.updatePreviewCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updatePreviewCheck.AutoSize = true;
            this.updatePreviewCheck.Checked = true;
            this.updatePreviewCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.updatePreviewCheck.Depth = 0;
            this.updatePreviewCheck.Location = new System.Drawing.Point(577, 269);
            this.updatePreviewCheck.Margin = new System.Windows.Forms.Padding(0);
            this.updatePreviewCheck.MouseLocation = new System.Drawing.Point(-1, -1);
            this.updatePreviewCheck.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.updatePreviewCheck.Name = "updatePreviewCheck";
            this.updatePreviewCheck.ReadOnly = false;
            this.updatePreviewCheck.Ripple = true;
            this.updatePreviewCheck.Size = new System.Drawing.Size(244, 37);
            this.updatePreviewCheck.TabIndex = 10;
            this.updatePreviewCheck.Text = "Automatically update preview";
            this.updatePreviewCheck.UseVisualStyleBackColor = true;
            this.updatePreviewCheck.CheckedChanged += new System.EventHandler(this.MaterialCheckbox1_CheckedChanged);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(12, 37);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin2Framework.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(72, 19);
            this.materialLabel2.TabIndex = 11;
            this.materialLabel2.Text = "Properties";
            // 
            // StringEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 616);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.updatePreviewCheck);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.bugcheckPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.whereTheButtonsLink);
            this.Controls.Add(this.specificPropsFlowLayoutPanel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.specificProps);
            this.Controls.Add(this.MessageView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.FormStyle = MaterialSkin2Framework.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(707, 245);
            this.Name = "StringEdit";
            this.Padding = new System.Windows.Forms.Padding(4, 30, 4, 4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bluescreen hacks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StringEdit_FormClosing);
            this.Load += new System.EventHandler(this.StringEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StringEdit_KeyDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.bugcheckPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialListView MessageView;
        private MaterialSkin2Framework.Controls.MaterialLabel specificProps;
        private MaterialSkin2Framework.Controls.MaterialButton buttonOK;
        private System.Windows.Forms.Panel stringProps;
        private MaterialSkin2Framework.Controls.MaterialMultiLineTextBox stringEditor;
        private System.Windows.Forms.Panel colorProps;
        private MaterialSkin2Framework.Controls.MaterialButton colorButton;
        private System.Windows.Forms.Label colorPreview;
        private System.Windows.Forms.FlowLayoutPanel specificPropsFlowLayoutPanel;
        private System.Windows.Forms.ColorDialog colorChooser;
        private System.Windows.Forms.Panel blinkProps;
        private MaterialSkin2Framework.Controls.MaterialSlider speedTrackbar;
        private MaterialSkin2Framework.Controls.MaterialLabel blinkingDash;
        private MaterialSkin2Framework.Controls.MaterialLabel previewLabel;
        private System.Windows.Forms.Timer blinkywinky;
        private System.Windows.Forms.Panel fontProps;
        private MaterialSkin2Framework.Controls.MaterialButton fontChangeButton;
        private System.Windows.Forms.Label fontPreview;
        private System.Windows.Forms.FontDialog fontChooser;
        private System.Windows.Forms.Panel timeoutProps;
        private MaterialSkin2Framework.Controls.MaterialTextBox2 timeoutBox;
        private MaterialSkin2Framework.Controls.MaterialLabel secondsLabel;
        private System.Windows.Forms.ToolTip simpleToolTip;
        private System.Windows.Forms.Panel qrProps;
        private MaterialSkin2Framework.Controls.MaterialButton browseButton;
        private MaterialSkin2Framework.Controls.MaterialLabel filenameLabel;
        private System.Windows.Forms.FlowLayoutPanel radioFlowLayoutPanel;
        private MaterialSkin2Framework.Controls.MaterialRadioButton defaultRadioBtn;
        private MaterialSkin2Framework.Controls.MaterialRadioButton transparentRadioBtn;
        private MaterialSkin2Framework.Controls.MaterialRadioButton customRadioBtn;
        private System.Windows.Forms.OpenFileDialog customQRBrowser;
        private System.Windows.Forms.LinkLabel whereTheButtonsLink;
        internal System.Windows.Forms.ImageList AllIcons;
        private System.Windows.Forms.FlowLayoutPanel xpMsgChooser;
        private MaterialSkin2Framework.Controls.MaterialRadioButton autoRadio;
        private MaterialSkin2Framework.Controls.MaterialRadioButton manualRadio;
        private System.Windows.Forms.Label label1;
        private MaterialLabel materialLabel1;
        private System.Windows.Forms.PictureBox bugcheckPreview;
        private System.Windows.Forms.Timer previewRefresh;
        private MaterialCheckbox updatePreviewCheck;
        private MaterialLabel materialLabel2;
    }
}