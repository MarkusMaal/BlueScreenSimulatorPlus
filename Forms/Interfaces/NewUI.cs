using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using SimulatorDatabase;
using UltimateBlueScreenSimulator.Forms.Interfaces;
using Control = System.Windows.Forms.Control;
using Panel = System.Windows.Forms.Panel;

namespace UltimateBlueScreenSimulator
{
    public partial class NewUI : MaterialForm
    {
        internal BlueScreen me;

        public readonly bool betabuild = true;

        public static ThreadStart ts;
        Thread bsod_starter;
        internal MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;

        public bool abopen = false;
        string version = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(0, 1) + "." + Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(1);


        public NewUI()
        {
            InitializeComponent();
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800, Primary.Blue900,
                Primary.Blue400, Accent.Indigo700,
                TextShade.WHITE
            );
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        internal void RelocateButtons()
        {
            button1.Location = new Point(this.Width - button1.Width - 10, this.Height - button1.Height - 10);
            button3.Location = new Point(button1.Location.X - (button1.Width) - 5, button1.Location.Y);
            label7.Location = new Point(label7.Location.X, button1.Location.Y + label7.Height / 2);
            flowLayoutPanel1.BackColor = this.BackColor;
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                c.BackColor = this.BackColor;
            }
        }

        private void NewUi1_Load(object sender, EventArgs e)
        {
            if (Program.gs.ErrorCode != 0)
            {
                ProcessErrors();
            }
            RelocateButtons();
            string verStr = Convert.ToDouble(version.Replace(".", ",")).ToString().Replace(",", ".");
            if (!verStr.Contains("."))
            {
                verStr += ".0";
            }
            this.Text = $"Blue Screen Simulator Plus {verStr}";
            if (betabuild)
            {
                this.Text += "          // UNDER CONSTRUCTION //";
            }
            windowVersion.Items.Clear();
            for (int i = Program.templates.Count - 1; i >= 0; i--)
            {
                windowVersion.Items.Add(Program.templates.GetAt(i).GetString("friendlyname"));
            }
            //WXOptions.Visible = false;
            errorCode.Visible = false;
            nineXmessage.Visible = false;
            serverBox.Visible = false;
            greenBox.Visible = false;
            qrBox.Visible = false;
            checkBox1.Visible = false;
            winMode.Visible = false;
            acpiBox.Visible = false;
            amdBox.Visible = false;
            stackBox.Visible = false;
            checkBox2.Enabled = true;
            ntPanel.Visible = false;
            if (windowVersion.Items.Count > 0) { windowVersion.SelectedIndex = 0; }
            string winver = "";
            int os_build = 0;
            try
            {
                winver = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
                os_build = Convert.ToInt32(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "0").ToString());
            }
            catch
            {
            }
            if (Program.gs.DisplayOne)
            {
                windowVersion.Items.Clear();
                for (int i = Program.templates.Count - 1; i >= 0; i--)
                {
                    windowVersion.Items.Add(Program.templates.GetAt(i).GetString("friendlyname"));
                }
                windowVersion.SelectedItem = me.GetString("friendlyname");
                //windowVersion.Visible = false;
                //label1.Text = "Selected preset: " + windowVersion.SelectedItem.ToString();
                //linkLabel1.Location = new Point(label1.Location.X + label1.Width, linkLabel1.Location.Y);
                //linkLabel1.Visible = true;
            } else
            {
                GetOS();
            }
            if (Program.gs.PM_CloseMainUI)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                return;
            }
            bool DarkMode = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1) == 0;
            Program.gs.NightTheme = Program.gs.AutoDark && DarkMode;
            if (Program.gs.AutoDark && DarkMode)
            {
                materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                RelocateButtons();
            }
            Program.gs.ApplyScheme();
        }



        public void GetOS()
        {
            windowVersion.Items.Clear();
            for (int i = Program.templates.Count - 1; i >= 0; i--)
            {
                windowVersion.Items.Add(Program.templates.GetAt(i).GetString("friendlyname"));
            }
            WXOptions.Visible = false;
            errorCode.Visible = false;
            nineXmessage.Visible = false;
            serverBox.Visible = false;
            greenBox.Visible = false;
            qrBox.Visible = false;
            checkBox1.Visible = false;
            winMode.Visible = false;
            acpiBox.Visible = false;
            amdBox.Visible = false;
            stackBox.Visible = false;
            checkBox2.Enabled = true;
            ntPanel.Visible = false;
            if (windowVersion.Items.Count > 0) { windowVersion.SelectedIndex = 0; }
            string winver = "";
            int os_build = 0;
            try
            {
                winver = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
                os_build = Convert.ToInt32(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "0").ToString());
            }
            catch
            {
            }
            /*if (specificos != "")
            {
                winver = specificos;
                specificos = "";
            }*/
            //this code identifies Windows 11
            if (os_build >= 22000)
            {
                SetOS("Windows 11");
            }
            //this code identifies Windows 10
            else if (winver.Contains("Windows 10"))
            {
                SetOS("Windows 10");
            }
            //this code identifies Windows 8 or Windows 8.1
            else if (winver.Contains("Windows 8"))
            {
                SetOS("Windows 8");
            }
            //this code identifies Windows 7
            else if (winver.Contains("Windows 7"))
            {
                SetOS("Windows 7");
            }
            //this code identifies Windows Vista
            else if (winver.Contains("Windows Vista"))
            {
                SetOS("Windows Vista");
            }
            //this code identifies Windows XP
            else if (winver.Contains("Windows XP"))
            {
                SetOS("Windows XP");
            }
            //this code identifies Windows 2000
            else if ((winver.Contains("Windows 2000")) || (winver.Contains("Windows NT 5")))
            {
                SetOS("Windows 2000");
            }
            //this code identifies Windows 95 or Windows 98
            else if ((winver.Contains("Windows 95")) || (winver.Contains("Windows 98")))
            {
                SetOS("Windows 9x");
            }
            //this code identifies old Windows NT versions
            else if ((winver.Contains("Windows NT 4")) || (winver.Contains("Windows NT 3")))
            {
                SetOS("Windows NT");
            }
        }

        void SetOS(string winver)
        {
            for (int i = 0; i < windowVersion.Items.Count; i++)
            {
                if (windowVersion.Items[i].ToString().Contains(winver))
                {
                    windowVersion.SelectedIndex = i;
                }
            }
        }

        private void NewUi1_ResizeEnd(object sender, EventArgs e)
        {
            int sub = 35;
            this.errorCode.Width = this.Width - sub;
            WXOptions.Width = this.Width - sub;
            ntPanel.Width = this.Width - sub;
            nineXmessage.Width = this.Width - sub;
            winPanel.Width = this.Width - sub;
            errorCode.Width = this.Width - sub;
            flowLayoutPanel4.Width = this.Width - sub;
            RelocateButtons();
        }


        private void windowVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadSelection();
        }

        public void Crash()
        {
            ts = new ThreadStart(ShowBlueScreen);
            bsod_starter = new Thread(ts);
            bsod_starter.Start();
        }

        public void ShowBlueScreen()
        {
            if (windowVersion.Items.Count < 1)
            {
                Program.loadfinished = true;
                if (Program.gs.EnableEggs && (Program.gs.ErrorCode != 500))
                {
                    MessageBox.Show("Please select a Windows version! Also, how in the world did you deselect a dropdown list?", "Error displaying blue screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Program.gs.ErrorCode == 500)
                {
                    Thread.CurrentThread.Abort();
                    return;
                }
                else
                {
                    MessageBox.Show("No configuration selected", "Error displaying blue screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            me.Show();
            Thread.CurrentThread.Abort();
        }

        internal void ReloadSelection()
        {
            /*if (linkLabel1.Visible)
            {
                linkLabel1.Visible = false;
                label1.Text = "Select preset:";
                windowVersion.Visible = true;
            }
            if (windowVersion.Items.Count == 1)
            {
                linkLabel1.Visible = true;
                label1.Text = "Selected preset: " + windowVersion.SelectedItem.ToString();
                linkLabel1.Location = new Point(label1.Location.X + label1.Width, linkLabel1.Location.Y);
                windowVersion.Visible = false;
            }*/
            //hide all controls
            WXOptions.Visible = false;
            errorCode.Visible = false;
            nineXmessage.Visible = false;
            serverBox.Visible = false;
            greenBox.Visible = false;
            qrBox.Visible = false;
            checkBox1.Visible = false;
            winMode.Visible = false;
            acpiBox.Visible = false;
            amdBox.Visible = false;
            stackBox.Visible = false;
            checkBox2.Enabled = true;
            ntPanel.Visible = false;
            memoryBox.Visible = false;
            dumpBox.Visible = false;
            winPanel.Visible = false;
            addInfFile.Enabled = false;
            advNTButton.Visible = false;
            dumpBox.Enabled = true;
            eCodeEditButton.Visible = false;
            devPCBox.Visible = false;
            playSndBox.Visible = false;
            countdownBox.Visible = false;
            progressTuneButton.Visible = false;
            //progressTunerToolStripMenuItem.Enabled = false;
            blackScreenBox.Visible = false;
            try
            {
                // set current bluescreen
                if (!Program.gs.DisplayOne)
                {
                    me = Program.templates.GetAt(Program.templates.Count - 1 - windowVersion.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                me.Crash(ex.Message, ex.StackTrace, "OrangeScreen");
            }
            // set control visibility for specific OS-es
            switch (me.GetString("os"))
            {
                case "Windows 11":
                    WXOptions.Visible = true;
                    serverBox.Visible = true;
                    qrBox.Visible = true;
                    errorCode.Visible = true;
                    autoBox.Checked = true;
                    checkBox1.Visible = true;
                    winMode.Visible = true;
                    memoryBox.Visible = true;
                    eCodeEditButton.Visible = true;
                    blackScreenBox.Visible = true;
                    progressTuneButton.Visible = true;
                    blackScreenBox.Checked = me.GetBool("blackscreen");
                    break;
                case "Windows 10":
                    WXOptions.Visible = true;
                    serverBox.Visible = true;
                    greenBox.Visible = true;
                    qrBox.Visible = true;
                    errorCode.Visible = true;
                    autoBox.Checked = true;
                    checkBox1.Visible = true;
                    winMode.Visible = true;
                    memoryBox.Visible = true;
                    eCodeEditButton.Visible = true;
                    devPCBox.Visible = true;
                    progressTuneButton.Visible = true;
                    break;
                case "Windows 8/8.1":
                    WXOptions.Visible = true;
                    errorCode.Visible = true;
                    checkBox1.Visible = true;
                    winMode.Visible = true;
                    memoryBox.Visible = true;
                    eCodeEditButton.Visible = true;
                    progressTuneButton.Visible = true;
                    blackScreenBox.Visible = true;
                    break;
                case "Windows 8 Beta":
                    WXOptions.Visible = true;
                    errorCode.Visible = true;
                    checkBox1.Visible = true;
                    winMode.Visible = true;
                    memoryBox.Visible = true;
                    eCodeEditButton.Visible = true;
                    countdownBox.Visible = true;
                    break;
                case "Windows Vista":
                case "Windows 7":
                    errorCode.Visible = true;
                    winMode.Visible = true;
                    acpiBox.Visible = true;
                    checkBox1.Visible = true;
                    autoBox.Visible = true;
                    dumpBox.Visible = true;
                    addInfFile.Enabled = true;
                    advNTButton.Visible = true;
                    eCodeEditButton.Visible = true;
                    //progressTunerToolStripMenuItem.Enabled = true;
                    break;
                case "Windows XP":
                    errorCode.Visible = true;
                    winMode.Visible = true;
                    checkBox1.Visible = true;
                    autoBox.Visible = true;
                    dumpBox.Visible = true;
                    addInfFile.Enabled = true;
                    advNTButton.Visible = true;
                    eCodeEditButton.Visible = true;
                    break;
                case "Windows 2000":
                    errorCode.Visible = true;
                    winMode.Visible = true;
                    checkBox1.Checked = true;
                    eCodeEditButton.Visible = true;
                    advNTButton.Visible = true;
                    break;
                case "Windows 9x/Me":
                    nineXmessage.Visible = true;
                    winMode.Visible = true;
                    eCodeEditButton.Visible = true;
                    break;
                case "Windows CE":
                    winMode.Visible = true;
                    errorCode.Visible = true;
                    checkBox2.Checked = false;
                    checkBox2.Enabled = false;
                    textBox2.Enabled = false;
                    break;
                case "Windows NT 3.x/4.0":
                    errorCode.Visible = true;
                    amdBox.Visible = true;
                    stackBox.Visible = true;
                    ntPanel.Visible = true;
                    winMode.Visible = true;
                    advNTButton.Visible = true;
                    eCodeEditButton.Visible = true;
                    break;
                case "Windows 3.1x":
                    winMode.Visible = true;
                    break;
                case "Windows 1.x/2.x":
                    winMode.Visible = true;
                    winPanel.Visible = true;
                    playSndBox.Visible = true;
                    break;
            }
            bool inlist = false;
            foreach (string item in comboBox1.Items)
            {
                if (item == me.GetString("code"))
                {
                    inlist = true;
                }
            }
            //codeCustomizationToolStripMenuItem.Enabled = eCodeEditButton.Visible;
            //advancedNTOptionsToolStripMenuItem.Enabled = advNTButton.Visible;
            // load options for current bluescreen
            autoBox.Checked = me.GetBool("autoclose");
            serverBox.Checked = me.GetBool("server");
            greenBox.Checked = me.GetBool("green");
            qrBox.Checked = me.GetBool("qr");
            comboBox1.SelectedItem = me.GetString("code");
            comboBox2.SelectedItem = me.GetString("screen_mode");
            checkBox1.Checked = me.GetBool("show_description");
            checkBox2.Checked = me.GetBool("show_file");
            textBox2.Text = me.GetString("culprit");
            amdBox.Checked = me.GetBool("amd");
            stackBox.Checked = me.GetBool("stack_trace");
            blinkBox.Checked = me.GetBool("blink");
            acpiBox.Checked = me.GetBool("acpi");
            playSndBox.Checked = me.GetBool("playsound");
            waterBox.Checked = me.GetBool("watermark");
            winMode.Checked = me.GetBool("windowed");
            countdownBox.Checked = me.GetBool("countdown");
            if (acpiBox.Checked)
            {
                dumpBox.Enabled = false;
            }
            win1startup.Checked = false;
            win2startup.Checked = false;
            nostartup.Checked = false;
            switch (me.GetString("qr_file"))
            {
                case "local:0":
                    win1startup.Checked = true;
                    break;
                case "local:1":
                    win2startup.Checked = true;
                    break;
                case "local:null":
                    nostartup.Checked = true;
                    break;
            }
        }


        internal void RandFunction()
        {
            Random r = new Random();
            for (int i = 0; i < Program.templates.Count; i++)
            {
                foreach (string kvp in Program.templates.GetAt(i).AllBools().Keys.ToArray<string>())
                {
                    bool value = r.Next(0, 1) == 1;
                    Program.templates.GetAt(i).SetBool(kvp, value);
                }
                if (comboBox1.Items.Count <= 0)
                {
                    break;
                }
                Program.templates.GetAt(i).SetString("code", comboBox1.Items[r.Next(0, comboBox1.Items.Count - 1)].ToString());
                if (Program.templates.GetAt(i).GetString("os") != "Windows 3.1x") {
                    Program.templates.GetAt(i).SetString("screen_mode", comboBox2.Items[r.Next(0, comboBox2.Items.Count - 1)].ToString());
                }
                Program.templates.GetAt(i).SetBool("windowed", winMode.Checked);
                Thread.Sleep(16);
            }
            windowVersion.SelectedIndex = SetRnd(windowVersion.Items.Count - 1);
            if (Program.gs.EnableEggs)
            {
                if (textBox1.Text == "blackscreen")
                {
                    windowVersion.Items.Add("Windows Vista/7 BOOTMGR (1024x768, ClearType)");
                    windowVersion.SelectedIndex = windowVersion.Items.Count - 1;
                }
            }
            textBox2.Text = me.GenFile();
            if (windowVersion.SelectedIndex == 4) { checkBox1.Checked = true; }
        }

        int SetRnd(int limit)
        {
            System.Threading.Thread.Sleep(20);
            Random rnd = new Random();
            try
            {
                int outp = 0;
                outp = rnd.Next(limit);
                return outp;
            }
            catch
            {
                return 0;
            }
        }

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if (textBox2.Text.ToLower().Contains("null"))
                {
                    foreach (Control c in this.Controls)
                    {
                        c.Text = "undefined";
                    }
                    foreach (Control c in flowLayoutPanel1.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    foreach (Control c in winPanel.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    foreach (Control c in ntPanel.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    foreach (Control c in errorCode.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    foreach (Control c in nineXmessage.Controls)
                    {
                        c.Text = "undefined";
                        c.Dispose();
                    }
                    this.Text = "";
                    this.HelpButton = false;
                    this.ShowIcon = false;
                    this.ShowInTaskbar = false;
                    return;
                }
            }
            if (Program.loadfinished && this.Visible)
            {
                Program.loadfinished = false;
                Program.load_progress = 100;
                Gen g;
                Thread gt;
                gt = new Thread(() => {
                    g = new Gen();
                    g.ShowDialog();
                });
                gt.Start();
            }
            Program.gs.PM_Lockout = false;
            Crash();
        }

        private void winMode_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("windowed", winMode.Checked);
            label7.Visible = !winMode.Checked;
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            ChooseFile cf = new ChooseFile();
            if (cf.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = cf.fileBrowser.SelectedItems[0].Text;
            }
            cf.Dispose();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if (textBox2.Text.Contains("one"))
                {
                    textBox2.Text = textBox2.Text.Replace("one", "sky");
                }
                if (textBox2.Text == "undefined")
                {
                    checkBox2.Checked = false;
                }
            }
            if (me == null)
            {
                return;
            }
            me.SetString("culprit", textBox2.Text);
            if ((me.GetString("os") == "Windows XP") || (me.GetString("os") == "Windows Vista") || (me.GetString("os") == "Windows 7"))
            {
                try
                {
                    me.RenameFile(0, textBox2.Text);
                }
                catch (Exception ex)
                {
                    if (Program.gs.EnableEggs)
                    {
                        me.Crash(ex.Message, ex.StackTrace, "GreenScreen");
                    }
                    else
                    {
                        MessageBox.Show("An error has occoured.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox2.Checked;
            button2.Enabled = checkBox2.Checked;
            if (me != null)
            {
                me.SetBool("show_file", checkBox2.Checked);
            }
        }

        private void materialFloatingActionButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will change random settings on various blue screens. Are you sure you want to continue?", "I'm feeling unlucky", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Program.loadfinished = false;
                Gen g = new Gen();
                g.Show();
                Thread.Sleep(10);
                RandFunction();
                button1.PerformClick();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((windowVersion.SelectedIndex != 1) && (this.me != null))
            {
                me.SetString("code", comboBox1.SelectedItem.ToString());
                if ((me.GetString("os") == "Windows XP") && me.GetBool("auto"))
                {
                    string[] xpmsg = Properties.Resources.xpMsg.Split(';');
                    if (me.GetString("code").Contains("007F"))
                    {
                        me.SetText("Troubleshooting introduction", xpmsg[3]);
                        me.SetText("Troubleshooting", string.Format("{0}\r\n\r\n{1}", xpmsg[9], xpmsg[10]));
                    }
                    else if (me.GetString("code").Contains("00C5"))
                    {
                        me.SetText("Troubleshooting introduction", xpmsg[0]);
                        me.SetText("Troubleshooting", string.Format("{0}\r\n\r\n{1}\r\n\r\n{2}\r\n\r\n{3}\r\n\r\n{4}", xpmsg[1], xpmsg[2], xpmsg[3], xpmsg[4], xpmsg[5]));
                    }
                    else if (me.GetString("code").Contains("008E"))
                    {
                        me.SetText("Troubleshooting introduction", xpmsg[3]);
                        me.SetText("Troubleshooting", string.Format("{0}\r\n\r\n{1}", xpmsg[7], xpmsg[8]));
                    }
                    else
                    {
                        me.SetText("Troubleshooting introduction", xpmsg[3]);
                        me.SetText("Troubleshooting", string.Format("{0}\r\n\r\n{1}\r\n{2}", xpmsg[0], xpmsg[5], xpmsg[6]));
                    }
                }
            }
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (materialTabControl1.SelectedIndex)
            {
                case 1:
                    logIf.Text = Program.gs.GetLog();
                    break;
                case 2:
                    materialTabControl1.SelectedIndex = 0;
                    materialTabControl1.TabPages[0].Show();
                    if (!abopen)
                    {
                        AboutSettingsDialog ab1 = new AboutSettingsDialog
                        {
                            Text = "Settings",
                            SettingTab = true
                        };
                        ab1.ShowDialog();
                        ab1.Dispose();
                        abopen = false;
                    }
                    else
                    {
                        MessageBox.Show("Settings window is already open", "Cannot open settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case 3:
                    materialTabControl1.SelectedIndex = 0;
                    materialTabControl1.TabPages[0].Show();
                    if (!abopen)
                    {
                        AboutSettingsDialog ab1 = new AboutSettingsDialog
                        {
                            Text = "Help and about",
                            SettingTab = false
                        };
                        ab1.ShowDialog();
                        abopen = false;
                    }
                    else
                    {
                        MessageBox.Show("The window is already open", "Cannot open window", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                case 4:
                    materialTabControl1.SelectedIndex = 0;
                    materialTabControl1.TabPages[0].Show();
                    PrankMode pm = new PrankMode();
                    pm.Show();
                    break;
                case 5:
                    materialTabControl1.SelectedIndex = 0;
                    materialTabControl1.TabPages[0].Show();
                    if (MessageBox.Show("The old UI is deprecated and will not recieve any new updates. Do you still want to continue?.", "Restore old layout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        this.Hide();
                        Main m = new Main();
                        m.Show();
                    }
                    break;
            }
        }

        private void autoBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("autoclose", autoBox.Checked);
        }

        private void serverBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("server", serverBox.Checked);
        }

        private void greenBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("insider", greenBox.Checked);
        }

        private void qrBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("qr", qrBox.Checked);
        }

        private void memoryBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("extracodes", memoryBox.Checked);
        }

        private void devPCBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("device", devPCBox.Checked);
        }

        private void blackScreenBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("blackscreen", blackScreenBox.Checked);
        }

        private void addInfFile_CheckedChanged(object sender, EventArgs e)
        {
            if (addInfFile.Enabled)
            {
                me.SetBool("extrafile", addInfFile.Checked);
            }
        }

        private void amdBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("amd", amdBox.Checked);
        }

        private void stackBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("stack_trace", stackBox.Checked);
        }

        private void blinkBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("blink", blinkBox.Checked);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            me.SetString("screen_mode", comboBox2.SelectedItem.ToString());
        }

        private void acpiBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("acpi", acpiBox.Checked);
            dumpBox.Enabled = !acpiBox.Checked;
            dumpBox.Checked = !acpiBox.Checked;
        }

        private void waterBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("watermark", waterBox.Checked);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("show_description", checkBox1.Checked);
        }

        private void dumpBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("autoclose", dumpBox.Checked);
        }

        private void playSndBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("playsound", playSndBox.Checked);
        }

        private void win1startup_CheckedChanged(object sender, EventArgs e)
        {
            if (win1startup.Checked)
            {
                me.SetString("qr_file", "local:0");
            }
            else if (win2startup.Checked)
            {
                me.SetString("qr_file", "local:1");
            }
            else if (nostartup.Checked)
            {
                me.SetString("qr_file", "local:null");
            }
        }

        private void advOptionsButton_Click(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if (textBox2.Text == "blaster")
                {
                    foreach (Control c in this.Controls)
                    {
                        c.Text = "form";
                    }
                    foreach (Panel p in this.Controls.OfType<Panel>())
                    {
                        foreach (Control c in p.Controls)
                        {
                            c.Text = "panel";
                        }
                        foreach (Panel q in p.Controls.OfType<Panel>())
                        {
                            foreach (Panel r in q.Controls.OfType<Panel>())
                            {
                                foreach (Control f in r.Controls)
                                {
                                    foreach (Panel s in q.Controls.OfType<Panel>())
                                    {
                                        foreach (Control d in s.Controls)
                                        {
                                            d.Text = "spaghetti";
                                        }
                                        s.Text = "subsubsubpanel";
                                    }
                                    f.Text = "subsubpanel";
                                }
                            }
                            foreach (Control c in q.Controls)
                            {
                                c.Text = "subpanel";
                            }
                        }
                    }
                    return;
                }
            }
            StringEdit bh = new StringEdit
            {
                me = me
            };
            bh.Show();
        }

        private void eCodeEditButton_Click(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if (textBox1.Text == "RASTER_FONTS")
                {
                    BTS bts = new BTS();
                    bts.Show();
                    return;
                }
            }
            IndexForm iform = new IndexForm
            {
                me = me,
                c1 = me.GetCodes()[0],
                c2 = me.GetCodes()[1],
                c3 = me.GetCodes()[2],
                c4 = me.GetCodes()[3]
            };
            iform.Show();
        }

        private void advNTButton_Click(object sender, EventArgs e)
        {
            int backup = windowVersion.SelectedIndex;
            IndexForm iform = new IndexForm
            {
                nt_edit = true,
                me = me
            };
            iform.ShowDialog();
            iform.Dispose();
            windowVersion.SelectedIndex = 0;
            windowVersion.SelectedIndex = backup;
        }

        private void progressTuneButton_Click(object sender, EventArgs e)
        {
            ProgressTuner pt = new ProgressTuner();
            pt.KFrames = me.AllProgress();
            pt.Text = string.Format("Progress tuner - {0}", me.GetString("friendlyname"));
            if (pt.KFrames.Count > 0)
            {
                pt.progressTrackBar.RangeMax = me.GetInt("progressmillis");
            }
            pt.ReloadBitmap();
            pt.SetLabelText();
            pt.totalTimeText.Text = ((float)me.GetInt("progressmillis") / 100f).ToString().Replace(",", ".");
            if (pt.ShowDialog() == DialogResult.OK)
            {
                me.SetAllProgression(pt.KFrames.Keys.ToArray<int>(), pt.KFrames.Values.ToArray<int>());
                me.SetInt("progressmillis", pt.progressTrackBar.RangeMax);
            }
            pt.Dispose();
        }

        private void quickHelp_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl != null)
            {
                if (e.AssociatedControl is MaterialButton mb)
                {
                    quickHelp.ToolTipTitle = mb.Text.Replace(" [?]", "");
                }
                else if (e.AssociatedControl is MaterialLabel ml)
                {
                    quickHelp.ToolTipTitle = ml.Text.Replace(" [?]", "");
                }
                else if (e.AssociatedControl is MaterialCheckbox mc)
                {
                    quickHelp.ToolTipTitle = mc.Text.Replace(" [?]", "");
                }
                else if (e.AssociatedControl.Name == "button1")
                {
                    quickHelp.ToolTipTitle = "Simulate";
                }
                else if (e.AssociatedControl.Name == "button3")
                {
                    quickHelp.ToolTipTitle = "I'm feeling unlucky";
                }
                else
                {
                    quickHelp.ToolTipTitle = "Quick help";
                }
            }
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, Program.gs.GetLog(false), Encoding.Unicode);
            }
        }

        ColorScheme MakeScheme(Accent accent)
        {
            return new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue400, accent, TextShade.WHITE);
        }

        private void countdownBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("countdown", countdownBox.Checked);
        }

        private void updateCheckerTimer_Tick(object sender, EventArgs e)
        {

            if (System.IO.File.Exists("BSSP.exe"))
            {
                updateCheckerTimer.Enabled = false;
                //MessageBox.Show("Thank you for installing the latest version of Blue screen simulator plus :)\n\nWhat's new?\n" + Program.changelog + "\n\nYou can find a more detailed changelog in the official BlueScreenSimulatorPlus GitHub page.", "Update was successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int tries = 0;
                while (System.IO.File.Exists("BSSP.exe"))
                {
                    tries += 1;
                    try
                    {
                        System.IO.File.Move("BSSP.exe", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BSSP_old.exe");
                        System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BSSP_old.exe");
                    }
                    catch
                    {
                        //yo
                    }
                    if (tries > 64)
                    {
                        break;
                    }
                }
            }
            try
            {
                if (System.IO.File.Exists("vercheck.txt"))
                {
                    string[] lines = System.IO.File.ReadAllLines("vercheck.txt");
                    if (Convert.ToDouble(lines[0].Replace(".", ",").Replace("\r", "").Replace("\n", "").Trim()) > Convert.ToDouble(version.Replace(".", ",")))
                    {
                        updateCheckerTimer.Enabled = false;
                        System.IO.File.Delete("vercheck.txt");
                        if (MessageBox.Show("A new version of blue screen simulator is available. Would you like to update now?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.IO.File.WriteAllText("hash.txt", lines[1].Trim());
                            if (Program.gs.PostponeUpdate == false)
                            {
                                UpdateInterface ui = new UpdateInterface();
                                ui.Show();
                                this.Hide();
                            }
                            else
                            {
                                Program.gs.UpdateAfterExit = true;
                                MessageBox.Show("The update has been postponed to install when the program is closed.");
                            }
                        }
                    }
                    else
                    {
                        if (updateCheckerTimer.Interval == 5999)
                        {
                            updateCheckerTimer.Interval = 6000;
                            updateCheckerTimer.Enabled = false;
                            System.IO.File.Delete("vercheck.txt");
                            if (MessageBox.Show("A new version of blue screen simulator is available. Would you like to update now?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                System.IO.File.WriteAllText("hash.txt", lines[1].Trim());
                                if (Program.gs.PostponeUpdate == false)
                                {
                                    UpdateInterface ui = new UpdateInterface();
                                    ui.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    Program.gs.UpdateAfterExit = true;
                                    MessageBox.Show("The update has been postponed to install when the program is closed.");
                                }
                            }
                        }
                        else if (updateCheckerTimer.Interval == 5998)
                        {
                            updateCheckerTimer.Interval = 6000;
                            updateCheckerTimer.Enabled = false;
                            MessageBox.Show("This version of blue screen simulator plus is up to date", "Blue screens simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            System.IO.File.Delete("vercheck.txt");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                if (updateCheckerTimer.Interval != 6000)
                {
                    MessageBox.Show("An error has occoured.\n\nFatal exception: " + ex.Message + "\n\nStack trace\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                updateCheckerTimer.Enabled = false;
            }
        }

        private void NewUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.gs.SaveSettings();
            try
            {
                if (Program.gs.UpdateAfterExit)
                {
                    UpdateInterface ui = new UpdateInterface();
                    ui.Show();
                    this.Hide();
                    Program.gs.UpdateAfterExit = false;
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            catch
            {
                e.Cancel = false;
            }
            if (!e.Cancel)
            {
                Application.Exit();
            }
        }

        private void prankModeTimer_Tick(object sender, EventArgs e)
        {
            if (Program.gs.PM_Timecatch)
            {
                int hrs = Program.gs.PM_Time[0];
                int mins = Program.gs.PM_Time[1];
                int secs = Program.gs.PM_Time[2];
                if ((hrs == 0) && (mins == 0) && (secs == 0))
                {
                    me.SetBool("watermark", false);
                    me.SetBool("windowed", false);
                    me.SetBool("autoclose", true);
                    Crash();
                    waitPopup.Enabled = true;
                    prankModeTimer.Enabled = false;
                }
                if (secs == 0)
                {
                    mins -= 1;
                    secs = 60;
                }
                if (mins == -1)
                {
                    hrs -= 1;
                    mins = 59;
                }
                if (hrs == -1)
                {
                    hrs = 0;
                    mins = 0;
                    secs = 0;
                }
                else
                {
                    secs -= 1;
                }
                int[] timex = { hrs, mins, secs };
                Program.gs.PM_Time = timex;
            }
            else if (Program.gs.PM_UsbDevice.Length > 0)
            {
                foreach (USBDeviceInfo usb in USBDeviceInfo.GetUSBDevices())
                {
                    string usbinfo = usb.DeviceID;
                    if ((usbinfo == Program.gs.PM_UsbDevice[0]))
                    {
                        me.SetBool("watermark", false);
                        me.SetBool("windowed", false);
                        me.SetBool("autoclose", true);
                        Crash();
                        waitPopup.Enabled = true;
                        prankModeTimer.Enabled = false;
                        break;
                    }
                }
            }
            else
            {
                bool getcatch = false;
                if (Process.GetProcessesByName(Program.gs.PM_AppName.Replace(".exe", "")).Length != 0)
                {
                    getcatch = true;
                }
                if (getcatch)
                {
                    me.SetBool("watermark", false);
                    me.SetBool("windowed", false);
                    me.SetBool("autoclose", true);
                    Crash();
                    waitPopup.Enabled = true;
                    prankModeTimer.Enabled = false;
                }
            }
        }

        private void waitPopup_Tick(object sender, EventArgs e)
        {
            if (!bsod_starter.IsAlive)
            {
                if (!Program.gs.PM_Lockout)
                {
                    waitPopup.Enabled = false;
                    this.WindowState = FormWindowState.Normal;
                    Program.f1.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void NewUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                if ((e.KeyCode == Keys.C) && e.Control && e.Alt)
                {
                    new ClickIt().Show();
                }
            }
        }

        private void NewUI_Shown(object sender, EventArgs e)
        {
            this.Enabled = Program.verificate;
            button1.Visible = Program.verificate;
            button3.Visible = Program.verificate;
            if (Program.verificate)
            {
                Program.clip.ExitSplash();
            }
            this.TopMost = true;
            this.TopMost = false;
        }

        private void ProcessErrors()
        {
            Program.clip.ExitSplash();
            switch (Program.gs.ErrorCode)
            {
                case 0:
                    break;
                case 1:
                    MessageBox.Show("No command specified in hidden mode\nAre you missing the /c argument?\n\n0x001: COMMAND_DEADLOCK", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.halt = true;
                    Application.Exit();
                    break;
                case 2:
                    MessageBox.Show("Specified file is either corrupted or not a valid blue screen simulator plus hack file.\n\n0x002: HEADER_MISSING", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x003: INCOMPATIBLE_HACK", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 4:
                    MessageBox.Show("Specified file is either corrupt or does not exist.\n\n0x004: FILE_MISSING", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 5:
                    MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x005: MISSING_ATTRIBUTES", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 6:
                    MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x006: FACE_TOO_LONG", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 7:
                    MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x007: FACE_TOO_SHORT", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 8:
                    MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x008: RGB_OUT_OF_RANGE", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 9:
                    MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x009: RGB_VALUE_NEGATIVE", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 10:
                    MessageBox.Show("A supported Windows version could not be identified.\n\n0x00A: PRODUCT_NAME_NOT_LISTED", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 11:
                    MessageBox.Show("Windows version could not be identified.\nAre you using a compatibility layer?\n\n0x00B: PRODUCT_NAME_MISSING", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 12:
                    MessageBox.Show("Cannot find the Windows version specified\n\n0x00C: WINVER_NOT_FOUND", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 13:
                    MessageBox.Show("Cannot find the error code specified\n\n0x00D: NTCODE_NOT_FOUND", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 14:
                    MessageBox.Show("Cannot find the error code specified\n\n0x00D: 9XCODE_NOT_FOUND", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 15:
                    MessageBox.Show("The syntax of the command is incorrect\n\n0x00E: BAD_SYNTAX", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 16:
                    MessageBox.Show("The syntax of the command is incorrect\n\n0x00F: BAD_SYNTAX", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 17:
                    MessageBox.Show("The syntax of the command is incorrect\n\n0x010: BAD_SYNTAX", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 18:
                    MessageBox.Show("The syntax of the command is incorrect\n\n0x011: BAD_SYNTAX", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 19:
                    MessageBox.Show("Internal database could not be loaded\n\n0x012: NT_DATABASE_MISSING", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 20:
                    MessageBox.Show("Internal database seems to be corrupted\n\n0x013: NT_DATABASE_CORRUPTED", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 23:
                    MessageBox.Show("The syntax of the command is incorrect\n\n0x016: COMMAND_ARGUMENT_INVALID", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 24:
                    MessageBox.Show("Specified hack file does not exist\n\n0x014: HACK_FILE_NON_EXISTENT", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 25:
                    MessageBox.Show("Specified hack file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x015: HACK_FILE_INCOMPATIBLE", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    Application.Exit();
                    this.Close();
                    break;
            }
        }

        private void autoBox_Paint(object sender, PaintEventArgs e)
        {
        }

        private void customizeCodesButton_Click(object sender, EventArgs e)
        {
            MessageTableEditor mte = new MessageTableEditor();
            mte.nt_errors = true;
            mte.ShowDialog();
        }

        private void blackScreenBox_MouseHover(object sender, EventArgs e)
        {
            if (sender is MaterialCheckbox)
            {
                if (me.GetString("os") != "Windows 8/8.1")
                {
                    quickHelp.SetToolTip(blackScreenBox, "On older versions of Windows 11, the screen was black instead of blue.");
                }
                else
                {
                    quickHelp.SetToolTip(blackScreenBox, "On some later beta builds of Windows 8, the screen was black instead of blue.");
                }
            }
        }
    }
}
