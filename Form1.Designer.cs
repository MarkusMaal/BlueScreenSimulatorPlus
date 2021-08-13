namespace UltimateBlueScreenSimulator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.windowVersion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.WXOptions = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.autoBox = new System.Windows.Forms.CheckBox();
            this.serverBox = new System.Windows.Forms.CheckBox();
            this.greenBox = new System.Windows.Forms.CheckBox();
            this.qrBox = new System.Windows.Forms.CheckBox();
            this.errorCode = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ntPanel = new System.Windows.Forms.Panel();
            this.blinkBox = new System.Windows.Forms.CheckBox();
            this.amdBox = new System.Windows.Forms.CheckBox();
            this.stackBox = new System.Windows.Forms.CheckBox();
            this.nineXmessage = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.acpiBox = new System.Windows.Forms.CheckBox();
            this.waterBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.winMode = new System.Windows.Forms.CheckBox();
            this.xpNote = new System.Windows.Forms.Label();
            this.helpTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.WXOptions.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.errorCode.SuspendLayout();
            this.ntPanel.SuspendLayout();
            this.nineXmessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows version";
            // 
            // windowVersion
            // 
            this.windowVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.windowVersion.FormattingEnabled = true;
            this.windowVersion.Items.AddRange(new object[] {
            "Windows 10 (Native, Safe mode: 640x480, ClearType)",
            "Windows 2000 Professional/Server Family (640x480, Standard)",
            "Windows 3.1 (EGA text mode, Standard)",
            "Windows 8/8.1 (Native, Safe mode: 640x480, ClearType)",
            "Windows 9x/Millennium Edition (EGA text mode, Standard)",
            "Windows CE 3.0 and later (750x400, Standard)",
            "Windows NT 4.0/3.x (VGA text mode, Standard)",
            "Windows Vista/7 (640x480, ClearType)",
            "Windows Vista/7 BOOTMGR (1024x768, ClearType)",
            "Windows Vista/7 BOOTMGR (1024x768, ClearType)",
            "Windows XP (640x480, Standard)"});
            this.windowVersion.Location = new System.Drawing.Point(106, 19);
            this.windowVersion.Name = "windowVersion";
            this.windowVersion.Size = new System.Drawing.Size(381, 21);
            this.windowVersion.TabIndex = 1;
            this.windowVersion.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            this.windowVersion.Click += new System.EventHandler(this.WindowVersion_Click);
            this.windowVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BlueScreen options";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.WXOptions);
            this.flowLayoutPanel1.Controls.Add(this.errorCode);
            this.flowLayoutPanel1.Controls.Add(this.ntPanel);
            this.flowLayoutPanel1.Controls.Add(this.nineXmessage);
            this.flowLayoutPanel1.Controls.Add(this.acpiBox);
            this.flowLayoutPanel1.Controls.Add(this.waterBox);
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Controls.Add(this.winMode);
            this.flowLayoutPanel1.Controls.Add(this.xpNote);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(472, 211);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // WXOptions
            // 
            this.WXOptions.Controls.Add(this.flowLayoutPanel2);
            this.WXOptions.Location = new System.Drawing.Point(3, 3);
            this.WXOptions.Name = "WXOptions";
            this.WXOptions.Size = new System.Drawing.Size(464, 25);
            this.WXOptions.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.autoBox);
            this.flowLayoutPanel2.Controls.Add(this.serverBox);
            this.flowLayoutPanel2.Controls.Add(this.greenBox);
            this.flowLayoutPanel2.Controls.Add(this.qrBox);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(464, 25);
            this.flowLayoutPanel2.TabIndex = 4;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // autoBox
            // 
            this.autoBox.AutoSize = true;
            this.autoBox.Checked = true;
            this.autoBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoBox.Location = new System.Drawing.Point(3, 3);
            this.autoBox.Name = "autoBox";
            this.autoBox.Size = new System.Drawing.Size(95, 17);
            this.autoBox.TabIndex = 3;
            this.autoBox.Text = "Auto restart [?]";
            this.helpTip.SetToolTip(this.autoBox, "Closes the blue screen automatically. Also displays a different blue screen.");
            this.autoBox.UseVisualStyleBackColor = true;
            this.autoBox.CheckedChanged += new System.EventHandler(this.autoBox_CheckedChanged);
            this.autoBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // serverBox
            // 
            this.serverBox.AutoSize = true;
            this.serverBox.Location = new System.Drawing.Point(104, 3);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(130, 17);
            this.serverBox.TabIndex = 0;
            this.serverBox.Text = "Server blue screen [?]";
            this.helpTip.SetToolTip(this.serverBox, "Displays a blue screen without an emoticon :(");
            this.serverBox.UseVisualStyleBackColor = true;
            this.serverBox.CheckedChanged += new System.EventHandler(this.serverBox_CheckedChanged);
            this.serverBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // greenBox
            // 
            this.greenBox.AutoSize = true;
            this.greenBox.Location = new System.Drawing.Point(240, 3);
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(105, 17);
            this.greenBox.TabIndex = 1;
            this.greenBox.Text = "Green screen [?]";
            this.helpTip.SetToolTip(this.greenBox, "Shows a green screen instead of a blue screen (from Windows Insider Preview build" +
        "s)");
            this.greenBox.UseVisualStyleBackColor = true;
            this.greenBox.CheckedChanged += new System.EventHandler(this.greenBox_CheckedChanged);
            this.greenBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // qrBox
            // 
            this.qrBox.AutoSize = true;
            this.qrBox.Checked = true;
            this.qrBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.qrBox.Location = new System.Drawing.Point(351, 3);
            this.qrBox.Name = "qrBox";
            this.qrBox.Size = new System.Drawing.Size(84, 17);
            this.qrBox.TabIndex = 2;
            this.qrBox.Text = "QR code [?]";
            this.helpTip.SetToolTip(this.qrBox, "Displays the QR code, visible on most Windows 10 versions");
            this.qrBox.UseVisualStyleBackColor = true;
            this.qrBox.CheckedChanged += new System.EventHandler(this.qrBox_CheckedChanged);
            this.qrBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // errorCode
            // 
            this.errorCode.Controls.Add(this.textBox2);
            this.errorCode.Controls.Add(this.checkBox2);
            this.errorCode.Controls.Add(this.textBox1);
            this.errorCode.Controls.Add(this.label5);
            this.errorCode.Controls.Add(this.comboBox1);
            this.errorCode.Controls.Add(this.label3);
            this.errorCode.Location = new System.Drawing.Point(0, 34);
            this.errorCode.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.errorCode.Name = "errorCode";
            this.errorCode.Size = new System.Drawing.Size(467, 84);
            this.errorCode.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(151, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(313, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "vga.sys";
            this.helpTip.SetToolTip(this.textBox2, "Specific file, that  may have caused the crash");
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 61);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(143, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Show potential culprit file";
            this.helpTip.SetToolTip(this.checkBox2, "If enabled, displays a file that may have caused the problem");
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            this.checkBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(80, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0A";
            this.helpTip.SetToolTip(this.textBox1, "Search for the error code from the NT error message list");
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Find by code:";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(361, 21);
            this.comboBox1.TabIndex = 1;
            this.helpTip.SetToolTip(this.comboBox1, "Select specific NT error message to display.");
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "NT error message:";
            // 
            // ntPanel
            // 
            this.ntPanel.Controls.Add(this.blinkBox);
            this.ntPanel.Controls.Add(this.amdBox);
            this.ntPanel.Controls.Add(this.stackBox);
            this.ntPanel.Location = new System.Drawing.Point(0, 124);
            this.ntPanel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.ntPanel.Name = "ntPanel";
            this.ntPanel.Size = new System.Drawing.Size(467, 27);
            this.ntPanel.TabIndex = 12;
            // 
            // blinkBox
            // 
            this.blinkBox.AutoSize = true;
            this.blinkBox.Location = new System.Drawing.Point(259, 5);
            this.blinkBox.Name = "blinkBox";
            this.blinkBox.Size = new System.Drawing.Size(96, 17);
            this.blinkBox.TabIndex = 12;
            this.blinkBox.Text = "Blink cursor [?]";
            this.helpTip.SetToolTip(this.blinkBox, "Displays blinking caret cursor, as seen in NT 3.x versions");
            this.blinkBox.UseVisualStyleBackColor = true;
            this.blinkBox.CheckedChanged += new System.EventHandler(this.blinkBox_CheckedChanged);
            this.blinkBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // amdBox
            // 
            this.amdBox.AutoSize = true;
            this.amdBox.Location = new System.Drawing.Point(2, 5);
            this.amdBox.Name = "amdBox";
            this.amdBox.Size = new System.Drawing.Size(114, 17);
            this.amdBox.TabIndex = 9;
            this.amdBox.Text = "AMD processor [?]";
            this.helpTip.SetToolTip(this.amdBox, "Displays \"AUTHENTICAMD\" instead of \"GENUINEINTEL\" on the NT blue screen");
            this.amdBox.UseVisualStyleBackColor = true;
            this.amdBox.CheckedChanged += new System.EventHandler(this.amdBox_CheckedChanged);
            this.amdBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // stackBox
            // 
            this.stackBox.AutoSize = true;
            this.stackBox.Checked = true;
            this.stackBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stackBox.Location = new System.Drawing.Point(122, 5);
            this.stackBox.Name = "stackBox";
            this.stackBox.Size = new System.Drawing.Size(131, 17);
            this.stackBox.TabIndex = 10;
            this.stackBox.Text = "Display stack trace [?]";
            this.helpTip.SetToolTip(this.stackBox, "Displays developer debug information on the NT blue screen\r\nNote: The blue screen" +
        " may take longer to load if enabled");
            this.stackBox.UseVisualStyleBackColor = true;
            this.stackBox.CheckedChanged += new System.EventHandler(this.stackBox_CheckedChanged);
            this.stackBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // nineXmessage
            // 
            this.nineXmessage.Controls.Add(this.comboBox2);
            this.nineXmessage.Controls.Add(this.label4);
            this.nineXmessage.Location = new System.Drawing.Point(0, 157);
            this.nineXmessage.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.nineXmessage.Name = "nineXmessage";
            this.nineXmessage.Size = new System.Drawing.Size(467, 25);
            this.nineXmessage.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "System error",
            "Application error",
            "Driver error",
            "System is busy",
            "System is unresponsive (Warning)"});
            this.comboBox2.Location = new System.Drawing.Point(119, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(345, 21);
            this.comboBox2.TabIndex = 1;
            this.helpTip.SetToolTip(this.comboBox2, "Select specific 9x/Me error message to display.");
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "9x/Me error message:";
            // 
            // acpiBox
            // 
            this.acpiBox.AutoSize = true;
            this.acpiBox.Location = new System.Drawing.Point(3, 188);
            this.acpiBox.Name = "acpiBox";
            this.acpiBox.Size = new System.Drawing.Size(124, 17);
            this.acpiBox.TabIndex = 8;
            this.acpiBox.Text = "ACPI error screen [?]";
            this.helpTip.SetToolTip(this.acpiBox, "Only displays the stop code (Windows Vista/7 only)");
            this.acpiBox.UseVisualStyleBackColor = true;
            this.acpiBox.CheckedChanged += new System.EventHandler(this.acpiBox_CheckedChanged);
            this.acpiBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // waterBox
            // 
            this.waterBox.AutoSize = true;
            this.waterBox.Checked = true;
            this.waterBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.waterBox.Location = new System.Drawing.Point(473, 3);
            this.waterBox.Name = "waterBox";
            this.waterBox.Size = new System.Drawing.Size(127, 17);
            this.waterBox.TabIndex = 4;
            this.waterBox.Text = "Display watermark [?]";
            this.helpTip.SetToolTip(this.waterBox, "Displays a watermark to let the user know that this a blue screen simulator");
            this.waterBox.UseVisualStyleBackColor = true;
            this.waterBox.CheckedChanged += new System.EventHandler(this.waterBox_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(473, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(237, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Show error description on the blue screen [?]";
            this.helpTip.SetToolTip(this.checkBox1, "Displays error description in addition to STOP code (e.g. IRQL_NOT_LESS_OR_EQUAL)" +
        "");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // winMode
            // 
            this.winMode.AutoSize = true;
            this.winMode.Location = new System.Drawing.Point(473, 49);
            this.winMode.Name = "winMode";
            this.winMode.Size = new System.Drawing.Size(121, 17);
            this.winMode.TabIndex = 7;
            this.winMode.Text = "Windowed mode [?]";
            this.helpTip.SetToolTip(this.winMode, "Does not full screen bluescreens, which results in better quality");
            this.winMode.UseVisualStyleBackColor = true;
            this.winMode.CheckedChanged += new System.EventHandler(this.winMode_CheckedChanged);
            // 
            // xpNote
            // 
            this.xpNote.AutoSize = true;
            this.xpNote.Location = new System.Drawing.Point(473, 69);
            this.xpNote.Name = "xpNote";
            this.xpNote.Size = new System.Drawing.Size(325, 13);
            this.xpNote.TabIndex = 13;
            this.xpNote.Text = "For more authentic experience, please disable ClearType smoothing";
            this.xpNote.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(416, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Simulate";
            this.helpTip.SetToolTip(this.button1, "Starts the simulation");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(301, 295);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "I\'m feeling unlucky";
            this.helpTip.SetToolTip(this.button3, "This will generate a random blue screen");
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            this.button3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(240, 295);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Codes";
            this.helpTip.SetToolTip(this.button4, "Allows you to configure how memory codes are being displayed on blue screens. Whe" +
        "n the screen uses less than 16 digits, the first digits will be used (e.g. first" +
        " 8 digits)");
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            this.button4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(175, 295);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(59, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Hacks";
            this.helpTip.SetToolTip(this.button5, "Experimental features to mess with in blue screens");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            this.button5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(90, 295);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(79, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Prank mode";
            this.helpTip.SetToolTip(this.button6, "Useful tools for pranking people\r\nNote: This option should NOT be used maliciousl" +
        "y (ie as a way of stealing productivity)");
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            this.button6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(15, 295);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(69, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "Settings";
            this.helpTip.SetToolTip(this.button7, "Configure blue screen simulator\'s settings and allows you to check for updates.\r\n" +
        "Hint: To get help or see information about the program, press ? next to the clos" +
        "e button.");
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click_1);
            this.button7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(115, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Alt + F4 - Exits the blue screen";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "In fullscreen mode:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(351, 282);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 13);
            this.label10.TabIndex = 8;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 60;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 6000;
            this.timer3.Tick += new System.EventHandler(this.Timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 344);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.windowVersion);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 9999);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 373);
            this.Name = "Form1";
            this.Text = "BlueScreen simulator Plus";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.WXOptions.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.errorCode.ResumeLayout(false);
            this.errorCode.PerformLayout();
            this.ntPanel.ResumeLayout(false);
            this.ntPanel.PerformLayout();
            this.nineXmessage.ResumeLayout(false);
            this.nineXmessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel WXOptions;
        private System.Windows.Forms.ToolTip helpTip;
        private System.Windows.Forms.Panel errorCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel nineXmessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel ntPanel;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        public System.Windows.Forms.ComboBox windowVersion;
        private System.Windows.Forms.Label xpNote;
        public System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.CheckBox waterBox;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.CheckBox qrBox;
        internal System.Windows.Forms.CheckBox greenBox;
        internal System.Windows.Forms.CheckBox serverBox;
        internal System.Windows.Forms.ComboBox comboBox1;
        internal System.Windows.Forms.ComboBox comboBox2;
        internal System.Windows.Forms.CheckBox autoBox;
        internal System.Windows.Forms.CheckBox acpiBox;
        internal System.Windows.Forms.CheckBox amdBox;
        internal System.Windows.Forms.CheckBox stackBox;
        internal System.Windows.Forms.CheckBox blinkBox;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.CheckBox checkBox2;
        internal System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.CheckBox winMode;
        public System.Windows.Forms.Timer timer3;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button7;
    }
}

