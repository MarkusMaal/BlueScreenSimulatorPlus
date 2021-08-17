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
            this.memoryBox = new System.Windows.Forms.CheckBox();
            this.errorCode = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.winPanel = new System.Windows.Forms.Panel();
            this.playSndBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.win1startup = new System.Windows.Forms.RadioButton();
            this.win2startup = new System.Windows.Forms.RadioButton();
            this.nostartup = new System.Windows.Forms.RadioButton();
            this.waterBox = new System.Windows.Forms.CheckBox();
            this.winMode = new System.Windows.Forms.CheckBox();
            this.helpTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.simulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueScreenHacksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeCustomizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prankModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandLineSyntaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulatorSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.waitPopup = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.WXOptions.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.errorCode.SuspendLayout();
            this.ntPanel.SuspendLayout();
            this.nineXmessage.SuspendLayout();
            this.winPanel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select preset:";
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
            this.windowVersion.Location = new System.Drawing.Point(90, 27);
            this.windowVersion.Name = "windowVersion";
            this.windowVersion.Size = new System.Drawing.Size(397, 21);
            this.windowVersion.TabIndex = 1;
            this.windowVersion.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            this.windowVersion.DropDownClosed += new System.EventHandler(this.windowVersion_DropDownClosed);
            this.windowVersion.Click += new System.EventHandler(this.WindowVersion_Click);
            this.windowVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
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
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Controls.Add(this.checkBox3);
            this.flowLayoutPanel1.Controls.Add(this.winPanel);
            this.flowLayoutPanel1.Controls.Add(this.waterBox);
            this.flowLayoutPanel1.Controls.Add(this.winMode);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(15, 73);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(472, 289);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // WXOptions
            // 
            this.WXOptions.Controls.Add(this.flowLayoutPanel2);
            this.WXOptions.Location = new System.Drawing.Point(3, 3);
            this.WXOptions.Name = "WXOptions";
            this.WXOptions.Size = new System.Drawing.Size(464, 50);
            this.WXOptions.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.autoBox);
            this.flowLayoutPanel2.Controls.Add(this.serverBox);
            this.flowLayoutPanel2.Controls.Add(this.greenBox);
            this.flowLayoutPanel2.Controls.Add(this.qrBox);
            this.flowLayoutPanel2.Controls.Add(this.memoryBox);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(464, 50);
            this.flowLayoutPanel2.TabIndex = 4;
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
            this.autoBox.CheckedChanged += new System.EventHandler(this.AutoBox_CheckedChanged);
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
            this.serverBox.CheckedChanged += new System.EventHandler(this.ServerBox_CheckedChanged);
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
            this.greenBox.CheckedChanged += new System.EventHandler(this.GreenBox_CheckedChanged);
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
            this.qrBox.CheckedChanged += new System.EventHandler(this.QrBox_CheckedChanged);
            this.qrBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // memoryBox
            // 
            this.memoryBox.AutoSize = true;
            this.memoryBox.Location = new System.Drawing.Point(3, 26);
            this.memoryBox.Name = "memoryBox";
            this.memoryBox.Size = new System.Drawing.Size(143, 17);
            this.memoryBox.TabIndex = 4;
            this.memoryBox.Text = "Additional error codes [?]";
            this.helpTip.SetToolTip(this.memoryBox, "Displays memory addresses at the top left of the screen (optional feature in Wind" +
        "ows 8+ bluescreens)");
            this.memoryBox.UseVisualStyleBackColor = true;
            this.memoryBox.CheckedChanged += new System.EventHandler(this.MemoryBox_CheckedChanged);
            // 
            // errorCode
            // 
            this.errorCode.Controls.Add(this.button2);
            this.errorCode.Controls.Add(this.textBox2);
            this.errorCode.Controls.Add(this.checkBox2);
            this.errorCode.Controls.Add(this.textBox1);
            this.errorCode.Controls.Add(this.label5);
            this.errorCode.Controls.Add(this.comboBox1);
            this.errorCode.Controls.Add(this.label3);
            this.errorCode.Location = new System.Drawing.Point(0, 59);
            this.errorCode.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.errorCode.Name = "errorCode";
            this.errorCode.Size = new System.Drawing.Size(467, 84);
            this.errorCode.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(401, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 20);
            this.button2.TabIndex = 7;
            this.button2.Text = "Choose";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(151, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(244, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "vga.sys";
            this.helpTip.SetToolTip(this.textBox2, "Specific file, that  may have caused the crash");
            this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
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
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged_1);
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
            this.ntPanel.Location = new System.Drawing.Point(0, 149);
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
            this.blinkBox.CheckedChanged += new System.EventHandler(this.BlinkBox_CheckedChanged);
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
            this.amdBox.CheckedChanged += new System.EventHandler(this.AmdBox_CheckedChanged);
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
            this.stackBox.CheckedChanged += new System.EventHandler(this.StackBox_CheckedChanged);
            this.stackBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // nineXmessage
            // 
            this.nineXmessage.Controls.Add(this.comboBox2);
            this.nineXmessage.Controls.Add(this.label4);
            this.nineXmessage.Location = new System.Drawing.Point(0, 182);
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
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
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
            this.acpiBox.Location = new System.Drawing.Point(3, 213);
            this.acpiBox.Name = "acpiBox";
            this.acpiBox.Size = new System.Drawing.Size(124, 17);
            this.acpiBox.TabIndex = 8;
            this.acpiBox.Text = "ACPI error screen [?]";
            this.helpTip.SetToolTip(this.acpiBox, "Only displays the stop code (Windows Vista/7 only)");
            this.acpiBox.UseVisualStyleBackColor = true;
            this.acpiBox.CheckedChanged += new System.EventHandler(this.AcpiBox_CheckedChanged);
            this.acpiBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(3, 236);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(237, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Show error description on the blue screen [?]";
            this.helpTip.SetToolTip(this.checkBox1, "Displays error description in addition to STOP code (e.g. IRQL_NOT_LESS_OR_EQUAL)" +
        "");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(3, 259);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(69, 17);
            this.checkBox3.TabIndex = 13;
            this.checkBox3.Text = "Dump [?]";
            this.helpTip.SetToolTip(this.checkBox3, "Enable to display dumping process in Windows XP/Vista/7 bluescreens");
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.CheckBox3_CheckedChanged);
            // 
            // winPanel
            // 
            this.winPanel.Controls.Add(this.playSndBox);
            this.winPanel.Controls.Add(this.flowLayoutPanel3);
            this.winPanel.Location = new System.Drawing.Point(473, 3);
            this.winPanel.Name = "winPanel";
            this.winPanel.Size = new System.Drawing.Size(461, 56);
            this.winPanel.TabIndex = 14;
            // 
            // playSndBox
            // 
            this.playSndBox.AutoSize = true;
            this.playSndBox.Location = new System.Drawing.Point(2, 35);
            this.playSndBox.Name = "playSndBox";
            this.playSndBox.Size = new System.Drawing.Size(93, 17);
            this.playSndBox.TabIndex = 4;
            this.playSndBox.Text = "Play sound [?]";
            this.helpTip.SetToolTip(this.playSndBox, "Plays constant beep noise while displaying the blue screen");
            this.playSndBox.UseVisualStyleBackColor = true;
            this.playSndBox.CheckedChanged += new System.EventHandler(this.PlaySndBox_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.win1startup);
            this.flowLayoutPanel3.Controls.Add(this.win2startup);
            this.flowLayoutPanel3.Controls.Add(this.nostartup);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(458, 26);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // win1startup
            // 
            this.win1startup.AutoSize = true;
            this.win1startup.Checked = true;
            this.win1startup.Location = new System.Drawing.Point(3, 3);
            this.win1startup.Name = "win1startup";
            this.win1startup.Size = new System.Drawing.Size(163, 17);
            this.win1startup.TabIndex = 0;
            this.win1startup.TabStop = true;
            this.win1startup.Text = "Windows 1.01 startup screen";
            this.win1startup.UseVisualStyleBackColor = true;
            this.win1startup.CheckedChanged += new System.EventHandler(this.Win1startup_CheckedChanged);
            // 
            // win2startup
            // 
            this.win2startup.AutoSize = true;
            this.win2startup.Location = new System.Drawing.Point(172, 3);
            this.win2startup.Name = "win2startup";
            this.win2startup.Size = new System.Drawing.Size(163, 17);
            this.win2startup.TabIndex = 1;
            this.win2startup.Text = "Windows 2.03 startup screen";
            this.win2startup.UseVisualStyleBackColor = true;
            this.win2startup.CheckedChanged += new System.EventHandler(this.Win2startup_CheckedChanged);
            // 
            // nostartup
            // 
            this.nostartup.AutoSize = true;
            this.nostartup.Location = new System.Drawing.Point(341, 3);
            this.nostartup.Name = "nostartup";
            this.nostartup.Size = new System.Drawing.Size(109, 17);
            this.nostartup.TabIndex = 2;
            this.nostartup.Text = "No startup screen";
            this.nostartup.UseVisualStyleBackColor = true;
            this.nostartup.CheckedChanged += new System.EventHandler(this.Nostartup_CheckedChanged);
            // 
            // waterBox
            // 
            this.waterBox.AutoSize = true;
            this.waterBox.Checked = true;
            this.waterBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.waterBox.Location = new System.Drawing.Point(473, 65);
            this.waterBox.Name = "waterBox";
            this.waterBox.Size = new System.Drawing.Size(127, 17);
            this.waterBox.TabIndex = 16;
            this.waterBox.Text = "Display watermark [?]";
            this.helpTip.SetToolTip(this.waterBox, "Displays a watermark to let the user know that this a blue screen simulator");
            this.waterBox.UseVisualStyleBackColor = true;
            this.waterBox.CheckedChanged += new System.EventHandler(this.WaterBox_CheckedChanged);
            // 
            // winMode
            // 
            this.winMode.AutoSize = true;
            this.winMode.Location = new System.Drawing.Point(473, 88);
            this.winMode.Name = "winMode";
            this.winMode.Size = new System.Drawing.Size(121, 17);
            this.winMode.TabIndex = 17;
            this.winMode.Text = "Windowed mode [?]";
            this.helpTip.SetToolTip(this.winMode, "Does not full screen bluescreens, which results in better quality");
            this.winMode.UseVisualStyleBackColor = true;
            this.winMode.CheckedChanged += new System.EventHandler(this.WinMode_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(418, 387);
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
            this.button3.Location = new System.Drawing.Point(301, 387);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 23);
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
            this.button4.Location = new System.Drawing.Point(122, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Error code editor";
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
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Location = new System.Drawing.Point(3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(113, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "Additional options";
            this.helpTip.SetToolTip(this.button5, "Experimental features to mess with in blue screens");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            this.button5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button7_KeyDown);
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Location = new System.Drawing.Point(15, 387);
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
            this.label7.Location = new System.Drawing.Point(15, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Alt + F4 - Exits the blue screen";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.Location = new System.Drawing.Point(351, 365);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 13);
            this.label10.TabIndex = 8;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(14, 31);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 13);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Change";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulatorToolStripMenuItem,
            this.specialToolStripMenuItem,
            this.advancedToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(499, 22);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // simulatorToolStripMenuItem
            // 
            this.simulatorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulateToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.simulatorToolStripMenuItem.Name = "simulatorToolStripMenuItem";
            this.simulatorToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.simulatorToolStripMenuItem.Size = new System.Drawing.Size(66, 22);
            this.simulatorToolStripMenuItem.Text = "Common";
            this.simulatorToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.simulatorToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.AutoSize = false;
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoUpdateToolStripMenuItem,
            this.simulatorSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 21);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blueScreenHacksToolStripMenuItem,
            this.codeCustomizationToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(68, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            this.advancedToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.advancedToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // blueScreenHacksToolStripMenuItem
            // 
            this.blueScreenHacksToolStripMenuItem.Name = "blueScreenHacksToolStripMenuItem";
            this.blueScreenHacksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.blueScreenHacksToolStripMenuItem.Text = "Advanced options";
            this.blueScreenHacksToolStripMenuItem.Click += new System.EventHandler(this.blueScreenHacksToolStripMenuItem_Click);
            // 
            // codeCustomizationToolStripMenuItem
            // 
            this.codeCustomizationToolStripMenuItem.Name = "codeCustomizationToolStripMenuItem";
            this.codeCustomizationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.codeCustomizationToolStripMenuItem.Text = "Code customization";
            this.codeCustomizationToolStripMenuItem.Click += new System.EventHandler(this.codeCustomizationToolStripMenuItem_Click);
            // 
            // specialToolStripMenuItem
            // 
            this.specialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prankModeToolStripMenuItem});
            this.specialToolStripMenuItem.Name = "specialToolStripMenuItem";
            this.specialToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.specialToolStripMenuItem.Size = new System.Drawing.Size(52, 22);
            this.specialToolStripMenuItem.Text = "Special";
            this.specialToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.specialToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // prankModeToolStripMenuItem
            // 
            this.prankModeToolStripMenuItem.Name = "prankModeToolStripMenuItem";
            this.prankModeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.prankModeToolStripMenuItem.Text = "Prank mode";
            this.prankModeToolStripMenuItem.Click += new System.EventHandler(this.prankModeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 3);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.AutoSize = false;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 21);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandLineSyntaxToolStripMenuItem,
            this.quickHelpToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // commandLineSyntaxToolStripMenuItem
            // 
            this.commandLineSyntaxToolStripMenuItem.Name = "commandLineSyntaxToolStripMenuItem";
            this.commandLineSyntaxToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.commandLineSyntaxToolStripMenuItem.Text = "Command line syntax";
            this.commandLineSyntaxToolStripMenuItem.Click += new System.EventHandler(this.commandLineSyntaxToolStripMenuItem_Click);
            // 
            // quickHelpToolStripMenuItem
            // 
            this.quickHelpToolStripMenuItem.Name = "quickHelpToolStripMenuItem";
            this.quickHelpToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.quickHelpToolStripMenuItem.Text = "Quick help";
            this.quickHelpToolStripMenuItem.Click += new System.EventHandler(this.quickHelpToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // autoUpdateToolStripMenuItem
            // 
            this.autoUpdateToolStripMenuItem.Name = "autoUpdateToolStripMenuItem";
            this.autoUpdateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autoUpdateToolStripMenuItem.Text = "AutoUpdate";
            this.autoUpdateToolStripMenuItem.Click += new System.EventHandler(this.autoUpdateToolStripMenuItem_Click);
            // 
            // simulatorSettingsToolStripMenuItem
            // 
            this.simulatorSettingsToolStripMenuItem.Name = "simulatorSettingsToolStripMenuItem";
            this.simulatorSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.simulatorSettingsToolStripMenuItem.Text = "Simulator settings";
            this.simulatorSettingsToolStripMenuItem.Click += new System.EventHandler(this.simulatorSettingsToolStripMenuItem_Click);
            // 
            // simulateToolStripMenuItem
            // 
            this.simulateToolStripMenuItem.AutoSize = false;
            this.simulateToolStripMenuItem.Name = "simulateToolStripMenuItem";
            this.simulateToolStripMenuItem.Size = new System.Drawing.Size(180, 21);
            this.simulateToolStripMenuItem.Text = "Simulate";
            this.simulateToolStripMenuItem.Click += new System.EventHandler(this.simulateToolStripMenuItem_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.button5);
            this.flowLayoutPanel4.Controls.Add(this.button4);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(473, 111);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(467, 30);
            this.flowLayoutPanel4.TabIndex = 18;
            // 
            // waitPopup
            // 
            this.waitPopup.Tick += new System.EventHandler(this.waitPopup_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 424);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.windowVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(550, 9999);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(515, 373);
            this.Name = "Form1";
            this.Text = "BlueScreen Simulator Plus";
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
            this.winPanel.ResumeLayout(false);
            this.winPanel.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
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
        private System.Windows.Forms.Panel ntPanel;
        public System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.ComboBox windowVersion;
        public System.Windows.Forms.Timer timer2;
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
        public System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox memoryBox;
        public System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Panel winPanel;
        private System.Windows.Forms.CheckBox playSndBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.RadioButton win1startup;
        private System.Windows.Forms.RadioButton win2startup;
        private System.Windows.Forms.RadioButton nostartup;
        public System.Windows.Forms.CheckBox waterBox;
        internal System.Windows.Forms.CheckBox winMode;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem simulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prankModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueScreenHacksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeCustomizationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandLineSyntaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulatorSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulateToolStripMenuItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Timer waitPopup;
    }
}

