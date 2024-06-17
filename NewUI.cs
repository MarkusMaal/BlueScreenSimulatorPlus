using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Win32;
using SimulatorDatabase;
using static System.Windows.Forms.Design.AxImporter;
using Control = System.Windows.Forms.Control;

namespace UltimateBlueScreenSimulator
{
    public partial class NewUI : MaterialForm
    {
        internal BlueScreen me;

        //enable/disable easter eggs
        public bool enableeggs = true;

        public static ThreadStart ts;
        Thread bsod_starter;

        public NewUI()
        {
            InitializeComponent();
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Indigo400, Primary.Indigo500,
                Primary.Indigo500, Accent.Orange400,
                TextShade.WHITE
            );
        }

        private void NewUi1_Load(object sender, EventArgs e)
        {
            windowVersion.Items.Clear();
            for (int i = Program.bluescreens.Count - 1; i >= 0; i--)
            {
                windowVersion.Items.Add(Program.bluescreens[i].GetString("friendlyname"));
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
            /* if (specificos != "")
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
            this.errorCode.Width = this.Width - 20;
            WXOptions.Width = this.Width - 20;
            ntPanel.Width = this.Width - 20;
            nineXmessage.Width = this.Width - 20;
            winPanel.Width = this.Width - 20;
            errorCode.Width = this.Width - 20;
            flowLayoutPanel4.Width = this.Width - 20;
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.f1.Show();
        }

        private void windowVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetOS();
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
                if (enableeggs)
                {
                    MessageBox.Show("Please select a Windows version! Also, how in the world did you deselect a dropdown list?", "Error displaying blue screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        internal void GetOS()
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
            progressTuneButton.Visible = false;
            //progressTunerToolStripMenuItem.Enabled = false;
            blackScreenBox.Visible = false;
            try
            {
                // set current bluescreen
                me = Program.bluescreens[Program.bluescreens.Count - 1 - windowVersion.SelectedIndex];
            }
            catch (Exception ex)
            {
                me.Crash(ex.Message, ex.StackTrace, "OrangeScreen");
            }
            // set control visibility for specific OS-es
            if (me.GetString("os") == "Windows 11")
            {
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
                //progressTunerToolStripMenuItem.Enabled = true;
                blackScreenBox.Checked = me.GetBool("blackscreen");
            }
            else if (me.GetString("os") == "Windows 10")
            {
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
                //progressTunerToolStripMenuItem.Enabled = true;
                devPCBox.Visible = true;
                progressTuneButton.Visible = true;
            }
            else if (me.GetString("os") == "Windows 8/8.1")
            {
                WXOptions.Visible = true;
                errorCode.Visible = true;
                checkBox1.Visible = true;
                winMode.Visible = true;
                memoryBox.Visible = true;
                eCodeEditButton.Visible = true;
                //progressTunerToolStripMenuItem.Enabled = true;
                progressTuneButton.Visible = true;
            }
            else if ((me.GetString("os") == "Windows Vista") || (me.GetString("os") == "Windows 7"))
            {
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
            }
            else if (me.GetString("os") == "Windows XP")
            {
                errorCode.Visible = true;
                winMode.Visible = true;
                checkBox1.Visible = true;
                autoBox.Visible = true;
                dumpBox.Visible = true;
                addInfFile.Enabled = true;
                advNTButton.Visible = true;
                eCodeEditButton.Visible = true;
            }
            else if (me.GetString("os") == "Windows 2000")
            {
                errorCode.Visible = true;
                winMode.Visible = true;
                checkBox1.Checked = true;
                eCodeEditButton.Visible = true;
                advNTButton.Visible = true;
            }
            else if (me.GetString("os") == "Windows 9x/Me")
            {
                nineXmessage.Visible = true;
                winMode.Visible = true;
                eCodeEditButton.Visible = true;
            }
            else if (me.GetString("os") == "Windows CE")
            {
                winMode.Visible = true;
                errorCode.Visible = true;
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
                textBox2.Enabled = false;
            }
            else if (me.GetString("os") == "Windows NT 3.x/4.0")
            {
                errorCode.Visible = true;
                amdBox.Visible = true;
                stackBox.Visible = true;
                ntPanel.Visible = true;
                winMode.Visible = true;
                advNTButton.Visible = true;
                eCodeEditButton.Visible = true;
            }
            else if (me.GetString("os") == "Windows 3.1x")
            {
                winMode.Visible = true;
            }
            else if (me.GetString("os") == "Windows 1.x/2.x")
            {
                winMode.Visible = true;
                winPanel.Visible = true;
                playSndBox.Visible = true;
            }
            bool inlist = false;
            foreach (string item in comboBox1.Items)
            {
                if (item == me.GetString("code"))
                {
                    inlist = true;
                }
            }
            customCheckBox.Checked = !inlist;
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
            for (int i = 0; i < Program.bluescreens.Count; i++)
            {
                foreach (string kvp in Program.bluescreens[i].AllBools().Keys.ToArray<string>())
                {
                    bool value = r.Next(0, 1) == 1;
                    Program.bluescreens[i].SetBool(kvp, value);
                }
                if (comboBox1.Items.Count <= 0)
                {
                    break;
                }
                Program.bluescreens[i].SetString("code", comboBox1.Items[r.Next(0, comboBox1.Items.Count - 1)].ToString());
                if (Program.bluescreens[i].GetString("os") != "Windows 3.1x") {
                    Program.bluescreens[i].SetString("screen_mode", comboBox2.Items[r.Next(0, comboBox2.Items.Count - 1)].ToString());
                }
                Program.bluescreens[i].SetBool("windowed", winMode.Checked);
                Thread.Sleep(16);
            }
            windowVersion.SelectedIndex = SetRnd(windowVersion.Items.Count - 1);
            if (enableeggs)
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
            if (enableeggs == true)
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
                Gen g = new Gen();
                g.Show();
            }
            Program.f1.lockout = false;
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
            if (enableeggs)
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
            me.SetString("culprit", textBox2.Text);
            if ((me.GetString("os") == "Windows XP") || (me.GetString("os") == "Windows Vista") || (me.GetString("os") == "Windows 7"))
            {
                try
                {
                    me.RenameFile(me.GetFiles().ElementAt(0).Key, textBox2.Text);
                }
                catch (Exception ex)
                {
                    if (enableeggs)
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
            me.SetBool("show_file", checkBox2.Checked);
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

        private void customCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            customMessageCode.Visible = customCheckBox.Checked;
            customMessageLabel1.Visible = customCheckBox.Checked;
            customMessageLabel2.Visible = customCheckBox.Checked;
            customMessageText.Visible = customCheckBox.Checked;
            comboBox1.Visible = !customCheckBox.Checked;
            if (me.GetString("code").Contains("x"))
            {
                customMessageText.Text = me.GetString("code").Split(' ')[0];
                customMessageCode.Text = me.GetString("code").Split('(')[1].Split('x')[1].Replace(")", "");
                if (!customCheckBox.Checked)
                {
                    me.SetString("code", comboBox1.SelectedItem.ToString());
                }
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

        private void customMessageCode_TextChanged(object sender, EventArgs e)
        {
            me.SetString("code", string.Format("{0} (0x{1})", customMessageText.Text, customMessageCode.Text));
        }

        private void customMessageText_TextChanged(object sender, EventArgs e)
        {
            me.SetString("code", string.Format("{0} (0x{1})", customMessageText.Text, customMessageCode.Text));
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (materialTabControl1.SelectedIndex == 1)
            {
                logIf.Text = me.GetLog();
            }
        }
    }
}
