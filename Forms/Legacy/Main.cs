using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using SimulatorDatabase;
using System.Threading;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media.Animation;
using UltimateBlueScreenSimulator.Forms.Interfaces;
namespace UltimateBlueScreenSimulator
{
    // DEPRECATED: Avoid making changes to this form unless absolutely neccessary! Use NewUI instead!
    public partial class Main : Form
    {
        internal BlueScreen me;
        //these variables deal with error codes
        public string c1 = "RRRRRRRRRRRRRRRR";
        public string c2 = "RRRRRRRRRRRRRRRR";
        public string c3 = "RRRRRRRRRRRRRRRR";
        public string c4 = "RRRRRRRRRRRRRRRR";
        
        public string kode = "";
        
        public string emoticon = ":(";

        //these variables are used for prank mode
        //this variable determines whether or not to display a message
        public bool showmsg = false;
        //these variables are for displaying a message
        public string MsgBoxMessage = "Enter a message here.";
        public string MsgBoxTitle = "Enter a title here";
        public MessageBoxIcon MsgBoxIcon = MessageBoxIcon.Exclamation;
        public MessageBoxButtons MsgBoxType = MessageBoxButtons.OK;
        //these variables are used for triggers
        public int[] time = { 0, 5, 0 };
        public string appname = "notepad.exe";
        //timecatch determines whether or not the trigger is related to time
        public bool timecatch = true;
        //trigger device for prank mode
        public string[] usb_device = { };

        readonly Splash spl2 = new Splash();
        //determines whether or not to close after closing a blue screen
        public bool closecuzhidden = false;

        //if true, closes form1 no matter what
        public int error = 0;

        //set cursor blink speed
        public int blinkspeed = 100;

        //whether or not the update is postponed
        public bool postponeupdate = false;
        public bool realpostpone = false;

        //whether or not the automatic update check is allowed
        public bool autoupdate = true;

        //whether or not the updater hashchecks downloads
        public bool hashverify = true;

        //whether or not to show the mouse cursor in fullscreen mode
        public bool showcursor = false;

        //whether or not the user can close bluescreen with Alt+F4
        public bool lockout = false;

        //visible operating systems
        public bool[] osshows = { true, true, true, true, true, true, true, true, true, true, true, true};

        //enable/disable easter eggs
        public bool enableeggs = true;

        //indicates whether or not the about/settings window is visible
        public bool abopen = false;

        //enable/disable automatic night theme
        public bool autodark = true;

        //scaling mode string
        public string GMode = "HighQualityBicubic";

        //if enabled, the program can write files
        public bool fileio = true;

        //specific OS when given in argument
        public string specificos = "";

        //this variable stores troubleshooting text for Windows XP/Vista/7 blue screens
        public string supporttext = "If this is the first time you've seen this Stop error screen,\nrestart your computer. If this screen appears again, follow\nthese steps:\n\nCheck to make sure any new hardware or software is properly installed.\nIf this is a new installation, ask your hardware or software manufacturer\nfor any Windows updates you might need.\n\nIf problems continue, disable or remove any newly installed hardware\nor software. Disable BIOS memory options such as caching or shadowing.\nIf you need to use Safe mode to remove or disable components, restart\nyour computer, press F8 to select Advanced Startup Options, and then\nselect Safe Mode.";

        internal bool displayone = false; // TODO: figure out wtf is this boolean used for
        
        string version = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(0, 1) + "." + Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(1);

        public static ThreadStart ts;
        Thread bsod_starter;

        public Main()
        {
            InitializeComponent();
        }

        private void ChangeConfiguration(object sender, EventArgs e)
        {
            if (linkLabel1.Visible)
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
            }

            UIActions.HideSelection(this);

            try
            {
                // set current bluescreen
                if (!Program.gs.DisplayOne)
                {
                    me = Program.templates.GetAt(Program.templates.Count - 1 - windowVersion.SelectedIndex);
                }
                UIActions.ResetSelection(this, me);
            }
            catch (Exception ex) when (!Debugger.IsAttached)
            {
                me.Crash(ex, "OrangeScreen");
            }
        }

        public bool DoWeHaveInternet(long minimumSpeed)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return false;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // discard because of standard reasons
                if ((ni.OperationalStatus != OperationalStatus.Up) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                    continue;

                // this allow to filter modems, serial, etc.
                // I use 10000000 as a minimum speed for most cases
                if (ni.Speed < minimumSpeed)
                    continue;

                // discard virtual cards (virtual box, virtual pc, etc.)
                if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                    continue;

                // discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
                if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                    continue;

                return true;
            }
            return false;
        }

        private void Initialize(object sender, EventArgs e)
        {
            Program.clip.ExitSplash();
            UIActions.InitializeForm(this);
            bool DarkMode = (int)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", 1) == 0;
            if (DarkMode && autodark)
            {
                nightThemeToolStripMenuItem.PerformClick();
            }
            this.Show();
            this.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
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
                    foreach (Control c in flowLayoutPanel2.Controls)
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
            Program.gs.PM_Lockout = false;
            UIActions.Crash(this);
        }

        //launches troubleshooting text editor
        private void Button2_Click(object sender, EventArgs e)
        {
            SupportEditor se = new SupportEditor();
            se.Show();
        }


        //search function
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (string it in comboBox1.Items)
            {
                if (it.Contains(textBox1.Text.Replace(" ", "_").ToUpper()))
                {
                    comboBox1.SelectedItem = it;
                    break;
                }
            }
        }

        //random function
        private void Button3_Click(object sender, EventArgs e)
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
                if (Program.templates.GetAt(i).GetString("os") != "Windows 3.1x") { Program.templates.GetAt(i).SetString("screen_mode", comboBox2.Items[r.Next(0, comboBox2.Items.Count - 1)].ToString()); }
                Program.templates.GetAt(i).SetBool("windowed", winMode.Checked);
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

        //Technical address generation options
        private void Button4_Click(object sender, EventArgs e)
        {
            if (enableeggs)
            {
                if (textBox1.Text == "RASTER_FONTS")
                {
                    BTS bts = new BTS();
                    bts.Show();
                    return;
                }
            }
            ErrorCodeEditor iform = new ErrorCodeEditor
            {
                me = me,
                c1 = me.GetCodes()[0],
                c2 = me.GetCodes()[1],
                c3 = me.GetCodes()[2],
                c4 = me.GetCodes()[3]
            };
            iform.Show();
        }

        //enables, disa
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox2.Checked;
            button2.Enabled = checkBox2.Checked;
            me.SetBool("show_file", checkBox2.Checked);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (enableeggs)
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

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            if (!abopen) {
                AboutSettingsDialog a1 = new AboutSettingsDialog
                {
                    Text = "Help and about"
                };
                a1.Show();
            }
            else
            {
                MessageBox.Show("Help and about window is already open", "Cannot open help and about", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            e.Cancel = true;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {

            if (timecatch)
            {
                int hrs = time[0];
                int mins = time[1];
                int secs = time[2];
                if ((hrs == 0) && (mins == 0) && (secs == 0))
                {
                    me.SetBool("watermark", false);
                    me.SetBool("windowed", false);
                    me.SetBool("autoclose", true);
                    UIActions.Crash(this);
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
                } else
                {
                    secs -= 1;
                }
                int[] timex = { hrs, mins, secs };
                time = timex;
            } else if (usb_device.Length > 0)
            {
                foreach (USBDeviceInfo usb in USBDeviceInfo.GetUSBDevices())
                {
                    string usbinfo = usb.DeviceID;
                    if ((usbinfo == usb_device[0]))
                    {
                        me.SetBool("watermark", false);
                        me.SetBool("windowed", false);
                        me.SetBool("autoclose", true);
                        UIActions.Crash(this);
                        waitPopup.Enabled = true;
                        prankModeTimer.Enabled = false;
                        break;
                    }
                }
            } else
            {
                bool getcatch = false;
                if (Process.GetProcessesByName(appname.Replace(".exe", "")).Length != 0)
                {
                    getcatch = true;
                }
                if (getcatch)
                {
                    me.SetBool("watermark", false);
                    me.SetBool("windowed", false);
                    me.SetBool("autoclose", true);
                    UIActions.Crash(this);
                    waitPopup.Enabled = true;
                    prankModeTimer.Enabled = false;
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Program.clip.ExitSplash();
            lockout = false;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            UpdateInterface ui = new UpdateInterface();
            ui.Show();
            this.Hide();
        }

        private void Timer3_Tick(object sender, EventArgs e)
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
                if (System.IO.File.Exists(Program.prefix + "vercheck.txt"))
                {
                    string[] lines = System.IO.File.ReadAllLines(Program.prefix + "vercheck.txt");
                    if (Convert.ToDouble(lines[0].Replace(".", ",").Replace("\r", "").Replace("\n", "").Trim()) > Convert.ToDouble(version.Replace(".", ",")))
                    {
                        updateCheckerTimer.Enabled = false;
                        System.IO.File.Delete(Program.prefix + "vercheck.txt");
                        if (MessageBox.Show("A new version of blue screen simulator is available. Would you like to update now?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.IO.File.WriteAllText("hash.txt", lines[1].Trim());
                            if (postponeupdate == false)
                            { 
                                UpdateInterface ui = new UpdateInterface();
                                ui.Show();
                                this.Hide();
                            }
                            else
                            {
                                realpostpone = true;
                                MessageBox.Show("The update has been postponed to install when the program is closed.");
                            }
                        }
                    } else
                    {
                        if (updateCheckerTimer.Interval == 5999)
                        {
                            updateCheckerTimer.Interval = 6000;
                            updateCheckerTimer.Enabled = false;
                            System.IO.File.Delete(Program.prefix + "vercheck.txt");
                            if (MessageBox.Show("A new version of blue screen simulator is available. Would you like to update now?", "Update available", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                System.IO.File.WriteAllText("hash.txt", lines[1].Trim());
                                if (postponeupdate == false)
                                {
                                    UpdateInterface ui = new UpdateInterface();
                                    ui.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    realpostpone = true;
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
                            System.IO.File.Delete(Program.prefix + "vercheck.txt");
                        }
                    }
                }
            } catch (Exception ex)
            {

                if (updateCheckerTimer.Interval != 6000)
                {
                    MessageBox.Show("An error has occoured.\n\nFatal exception: " + ex.Message + "\n\nStack trace\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                updateCheckerTimer.Enabled = false;
            }
        }

        private void Button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                try
                {
                    if (Program.gs.Autosave)
                    {
                        Program.templates.SaveData(Program.prefix + "bluescreens.json", 0);
                    }
                    Program.gs.SaveSettings();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (realpostpone)
                {
                    UpdateInterface ui = new UpdateInterface();
                    ui.Show();
                    this.Hide();
                    realpostpone = false;
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
                if (!Program.f1.Visible)
                {
                    Application.Exit();
                }
            }
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            if (!abopen)
            {
                AboutSettingsDialog ab1 = new AboutSettingsDialog
                {
                    Text = "Settings",
                    SettingTab = true
                };
                ab1.okButton.DialogResult = DialogResult.None;
                ab1.ShowDialog();
                ab1.Dispose();
            }
            else
            {
                MessageBox.Show("Settings window is already open", "Cannot open settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (enableeggs)
            {
                if (e.Control)
                {
                    if (e.KeyCode == Keys.K)
                    {
                        MessageBox.Show("Karrots are good for your eyesight", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void Button7_KeyDown(object sender, KeyEventArgs e)
        {
            if (enableeggs)
            { 
                if (e.Control)
                {
                    if (e.Alt)
                    {
                        if (e.KeyCode == Keys.C)
                        {
                            ClickIt ci = new ClickIt();
                            ci.Show();
                        }
                    }
                }
                if (e.Control)
                {
                    if (e.KeyCode == Keys.K)
                    {
                        MessageBox.Show("Karrots are good for your eyesight", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (e.KeyCode == Keys.Up)
                {
                    kode += "u";
                }
                else if (e.KeyCode == Keys.Down)
                {
                    kode += "d";
                }
                else if (e.KeyCode == Keys.Left)
                {
                    kode += "l";
                }
                else if (e.KeyCode == Keys.Right)
                {
                    kode += "r";
                }
                else if (e.KeyCode == Keys.B)
                {
                    kode += "b";
                }
                else if (e.KeyCode == Keys.A)
                {
                    kode += "a";
                }
                else
                {
                    kode = "";
                }
                if (e.Shift && (e.KeyCode == Keys.F6))
                {
                    if (windowVersion.Focused)
                    {
                        flowLayoutPanel1.Focus();
                    }
                    else if (flowLayoutPanel1.Focused)
                    {
                        button7.Focus();
                    }
                    else if (menuBar.Focused)
                    {
                        windowVersion.Focus();
                    }
                    else
                    {
                        menuBar.Focus();
                    }
                }
                else if (!e.Shift && (e.KeyCode == Keys.F6))
                {
                    if (windowVersion.Focused)
                    {
                        menuBar.Focus();
                    }
                    else if (flowLayoutPanel1.Focused)
                    {
                        windowVersion.Focus();
                    }
                    else if (menuBar.Focused)
                    {
                        button7.Focus();
                    }
                    else
                    {
                        flowLayoutPanel1.Focus();
                    }
                }
                if (kode == "uuddlrlrba")
                {
                    ClickIt ci = new ClickIt();
                    ci.Show();
                    kode = "";
                }
            }
        }

        private void AutoBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("autoclose", autoBox.Checked);
        }

        private void ServerBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("server", serverBox.Checked);
        }

        private void GreenBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("insider", greenBox.Checked);
        }

        private void QrBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("qr", qrBox.Checked);
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (windowVersion.SelectedIndex != -1)
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

        private void TextBox2_TextChanged(object sender, EventArgs e)
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
                    me.RenameFile(0, textBox2.Text);
                } catch (Exception ex)
                {
                    if (enableeggs)
                    {
                        me.Crash(ex, "GreenScreen");
                    } else
                    {
                        MessageBox.Show("An error has occoured.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AmdBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("amd", amdBox.Checked);
        }

        private void StackBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("stack_trace", stackBox.Checked);
        }

        private void BlinkBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("blink", blinkBox.Checked);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            me.SetString("screen_mode", comboBox2.SelectedItem.ToString());
        }

        private void AcpiBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("acpi", acpiBox.Checked);
            dumpBox.Enabled = !acpiBox.Checked;
            dumpBox.Checked = !acpiBox.Checked;
        }

        private void WaterBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("watermark", waterBox.Checked);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("show_description", checkBox1.Checked);
        }

        private void WinMode_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("windowed", winMode.Checked);
            label7.Visible = !winMode.Checked;
        }

        private void MemoryBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("extracodes", memoryBox.Checked);
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            ChooseFile cf = new ChooseFile();
            if (cf.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = cf.fileBrowser.SelectedItems[0].Text;
            }
            cf.Dispose();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("autoclose", dumpBox.Checked);
        }

        private void PlaySndBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("playsound", playSndBox.Checked);
        }

        private void Win1startup_CheckedChanged(object sender, EventArgs e)
        {
            if (win1startup.Checked)
            {
                me.SetString("qr_file", "local:0");
            }
        }

        private void Win2startup_CheckedChanged(object sender, EventArgs e)
        {
            if (win2startup.Checked)
            {
                me.SetString("qr_file", "local:1");
            }
        }

        private void Nostartup_CheckedChanged(object sender, EventArgs e)
        {
            if (nostartup.Checked)
            {
                me.SetString("qr_file", "local:null");
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (!abopen)
            {
                AboutSettingsDialog a1 = new AboutSettingsDialog
                {
                    Text = "Help and about"
                };
                a1.Show();
            }
            else
            {
                MessageBox.Show("Help and about window is already open", "Cannot open help and about", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Visible = false;
            windowVersion.Visible = true;
            label1.Text = "Select preset:";
        }

        private void WindowVersion_DropDownClosed(object sender, EventArgs e)
        {
            if (windowVersion.Items.Count == 0)
            {
                if (enableeggs)
                {
                    windowVersion.Visible = false;
                    linkLabel1.Visible = false;
                    label1.Visible = false;
                    waterBox.Visible = false;
                    MessageBox.Show("How did we get here?", "What have you done?", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void PrankModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrankMode pm = new PrankMode();
            pm.Show();
        }

        private void BlueScreenHacksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            advOptionsButton.PerformClick();
        }

        private void CodeCustomizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eCodeEditButton.PerformClick();
        }

        private void SimulateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.loadfinished && this.Visible)
            {
                Program.loadfinished = false;
                Gen g = new Gen();
                g.Show();
            }
            UIActions.Crash(this);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!abopen)
            {
                AboutSettingsDialog ab1 = new AboutSettingsDialog
                {
                    Text = "Help and about",
                    SettingTab = false
                };
                ab1.ShowDialog();
                ab1.Dispose();
            }
            else
            {
                MessageBox.Show("The window is already open", "Cannot open window", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void QuickHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!abopen)
            {
                AboutSettingsDialog ab1 = new AboutSettingsDialog
                {
                    Text = "Help and about",
                    SettingTab = false,
                    tab_id = 1
                };
                ab1.ShowDialog();
                ab1.Dispose();
            }
            else
            {
                MessageBox.Show("The window is already open", "Cannot open window", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CommandLineSyntaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!abopen)
            {
                AboutSettingsDialog ab1 = new AboutSettingsDialog
                {
                    Text = "Help and about",
                    SettingTab = false,
                    tab_id = 2
                };
                ab1.ShowDialog();
                ab1.Dispose();
            }
            else
            {
                MessageBox.Show("The window is already open", "Cannot open window", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AutoUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button7.PerformClick();
        }

        private void SimulatorSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!abopen)
            {
                AboutSettingsDialog ab1 = new AboutSettingsDialog
                {
                    Text = "Settings",
                    SettingTab = true,
                    tab_id = 1
                };
                ab1.okButton.DialogResult = DialogResult.None;
                ab1.ShowDialog();
                ab1.Dispose();
            }
            else
            {
                MessageBox.Show("Settings window is already open", "Cannot open settings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void WaitPopup_Tick(object sender, EventArgs e)
        {
            if (!bsod_starter.IsAlive)
            {
                if (!closecuzhidden)
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

        private void AdvancedNTOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int backup = windowVersion.SelectedIndex;
            NTdtor iform = new NTdtor
            {
                me = me
            };
            iform.ShowDialog();
            iform.Dispose();
            windowVersion.SelectedIndex = 0;
            windowVersion.SelectedIndex = backup;
        }

        private void AddInfFile_CheckedChanged(object sender, EventArgs e)
        {
            if (addInfFile.Enabled)
            {
                me.SetBool("extrafile", addInfFile.Checked);
            }
        }

        private void AdvNTButton_Click(object sender, EventArgs e)
        {
            advancedNTOptionsToolStripMenuItem.PerformClick();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            flowLayoutPanel2.Width = flowLayoutPanel1.Width;
            ntPanel.Width = flowLayoutPanel1.Width;
            errorCode.Width = flowLayoutPanel1.Width;
            nineXmessage.Width = flowLayoutPanel1.Width;
            flowLayoutPanel4.Width = flowLayoutPanel1.Width;
            winPanel.Width = flowLayoutPanel1.Width;
            WXOptions.Width = flowLayoutPanel1.Width;
        }

        private void DevPCBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("device", devPCBox.Checked);
        }

        private void ContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DoWeHaveInternet(1000))
            {
                // online user manual
                Process p = new Process();
                p.StartInfo.FileName = Program.gs.UpdateServer.Replace("/app", "") + "/bssp/help.pdf";
                p.Start();
            } else
            {
                System.IO.File.WriteAllBytes(Environment.GetEnvironmentVariable("TEMP") + "\\bssp_manual.pdf", Properties.Resources.BSSP_manual);

                Process p = new Process();
                p.StartInfo.FileName = Environment.GetEnvironmentVariable("TEMP") + "\\bssp_manual.pdf";
                p.Start();
            }
        }

        private void LightSwitch(object sender, EventArgs e)
        {
            Color back;
            Color fore;
            if (nightThemeToolStripMenuItem.Checked)
            {
                back = Color.Black;
                fore = Color.Gray;
            } else
            {
                back = SystemColors.Control;
                fore = SystemColors.ControlText;
            }
            this.BackColor = back;
            this.ForeColor = fore;
            foreach (Control c in this.Controls)
            {
                c.BackColor = back;
                c.ForeColor = fore;
                if (c is FlowLayoutPanel flp)
                {
                    foreach (Control fpc in flp.Controls)
                    {
                        if ((fpc is FlowLayoutPanel) || (fpc is Panel))
                        {
                            foreach (Control sc in fpc.Controls)
                            {
                                sc.BackColor = back;
                                sc.ForeColor = fore;
                            }
                        }
                    }
                }
            }
        }

        private void SimulatorToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (nightThemeToolStripMenuItem.Checked)
            {
                simulatorToolStripMenuItem.DropDown.BackColor = Color.FromArgb(80, 80, 80);
                simulatorToolStripMenuItem.DropDown.ForeColor = Color.Gray;
                helpToolStripMenuItem.DropDown.BackColor = Color.FromArgb(80, 80, 80);
                helpToolStripMenuItem.DropDown.ForeColor = Color.Gray;
                advancedToolStripMenuItem.DropDown.BackColor = Color.FromArgb(80, 80, 80);
                advancedToolStripMenuItem.DropDown.ForeColor = Color.Gray;
                settingsToolStripMenuItem.DropDown.BackColor = Color.FromArgb(80, 80, 80);
                settingsToolStripMenuItem.DropDown.ForeColor = Color.Gray;
            } else
            {
                simulatorToolStripMenuItem.DropDown.BackColor = SystemColors.Menu;
                simulatorToolStripMenuItem.DropDown.ForeColor = SystemColors.MenuText;
                helpToolStripMenuItem.DropDown.BackColor = SystemColors.Menu;
                helpToolStripMenuItem.DropDown.ForeColor = SystemColors.MenuText;
                advancedToolStripMenuItem.DropDown.BackColor = SystemColors.Menu;
                advancedToolStripMenuItem.DropDown.ForeColor = SystemColors.MenuText;
                settingsToolStripMenuItem.DropDown.BackColor = SystemColors.Menu;
                settingsToolStripMenuItem.DropDown.ForeColor = SystemColors.MenuText;
            }
        }

        private void blackScreenBox_CheckedChanged(object sender, EventArgs e)
        {
            me.SetBool("blackscreen", blackScreenBox.Checked);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (me.GetString("os") == "Windows 8 Beta")
            {
                MessageBox.Show("Progress tuner is not available for this OS, dummy!", "Progress tuner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProgressTuner pt = new ProgressTuner();
            pt.KFrames = me.AllProgress();
            pt.Text = string.Format("Progress tuner - {0}", me.GetString("friendlyname"));
            if (pt.KFrames.Count > 0)
            {
                pt.progressTrackBar.RangeMax = me.GetInt("progressmillis");
            }
            pt.ReloadBitmap();
            pt.SetLabelText();
            if (this.nightThemeToolStripMenuItem.Checked)
            {
                pt.BackColor = Color.Black;
                pt.ForeColor = Color.White;
            }
            pt.totalTimeText.Text = ((float)me.GetInt("progressmillis") / 100f).ToString().Replace(",", ".");
            if (pt.ShowDialog() == DialogResult.OK)
            {
                me.SetAllProgression(pt.KFrames.Keys.ToArray<int>(), pt.KFrames.Values.ToArray<int>());
                me.SetInt("progressmillis", pt.progressTrackBar.RangeMax);
            }
            pt.Dispose();
        }

        private void progressTunerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            progressTuneButton.PerformClick();
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

        private void customMessageText_TextChanged(object sender, EventArgs e)
        {
            me.SetString("code", string.Format("{0} (0x{1})", customMessageText.Text, customMessageCode.Text));
        }

        private void customMessageCode_TextChanged(object sender, EventArgs e)
        {
            me.SetString("code", string.Format("{0} (0x{1})", customMessageText.Text, customMessageCode.Text));
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
