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
namespace UltimateBlueScreenSimulator
{
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

        //scaling mode string
        public string GMode = "HighQualityBicubic";

        //if enabled, the program can write files
        public bool fileio = true;

        //specific OS when given in argument
        public string specificos = "";

        //this variable stores troubleshooting text for Windows XP/Vista/7 blue screens
        public string supporttext = "If this is the first time you've seen this Stop error screen,\nrestart your computer. If this screen appears again, follow\nthese steps:\n\nCheck to make sure any new hardware or software is properly installed.\nIf this is a new installation, ask your hardware or software manufacturer\nfor any Windows updates you might need.\n\nIf problems continue, disable or remove any newly installed hardware\nor software. Disable BIOS memory options such as caching or shadowing.\nIf you need to use Safe mode to remove or disable components, restart\nyour computer, press F8 to select Advanced Startup Options, and then\nselect Safe Mode.";

        internal bool displayone = false;

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
            // set current bluescreen
            me = Program.bluescreens[Program.bluescreens.Count - 1 - windowVersion.SelectedIndex];
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
                devPCBox.Visible = true;
            }
            else if (me.GetString("os") == "Windows 8/8.1")
            {
                WXOptions.Visible = true;
                errorCode.Visible = true;
                checkBox1.Visible = true;
                winMode.Visible = true;
                memoryBox.Visible = true;
                eCodeEditButton.Visible = true;
            }
            else if (me.GetString("os") == "Windows Vista/7")
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
            }
            codeCustomizationToolStripMenuItem.Enabled = eCodeEditButton.Visible;
            advancedNTOptionsToolStripMenuItem.Enabled = advNTButton.Visible;
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

        public void GetOS()
        {
            windowVersion.Items.Clear();
            for (int i = Program.bluescreens.Count - 1; i >= 0 ; i--)
            {
                windowVersion.Items.Add(Program.bluescreens[i].GetString("friendlyname"));
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
            try
            {
                winver = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
            }
            catch
            {
            }
            if (specificos != "")
            {
                winver = specificos;
                specificos = "";
            }
            //this code identifies Windows 11
            if (winver.Contains("Windows 11"))
            {
                SetOS("Windows 11");
            }
            //this code identifies Windows 10
            if (winver.Contains("Windows 10"))
            {
                SetOS("Windows 10");
            }
            //this code identifies Windows 8 or Windows 8.1
            else if (winver.Contains("Windows 8"))
            {
                SetOS("Windows 8");
            }
            //this code identifies Windows 7 or Windows Vista
            else if ((winver.Contains("Windows 7")) || (winver.Contains("Windows Vista")))
            {
                SetOS("Windows Vista/7");
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

        public void Crash()
        {
            ts = new ThreadStart(ShowBlueScreen);
            bsod_starter = new Thread(ts);
            bsod_starter.Start();
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
            ts = new ThreadStart(ShowBlueScreen);
            bsod_starter = new Thread(ts);
            try
            {
                System.IO.File.WriteAllText("test.log", "");
                System.IO.File.Delete("test.log");
                fileio = true;
            }
            catch
            {
                fileio = false;
                autoupdate = false;
            }
            if (displayone)
            {
                windowVersion.Items.Clear();
                for (int i = Program.bluescreens.Count - 1; i >= 0; i--)
                {
                    windowVersion.Items.Add(Program.bluescreens[i].GetString("friendlyname"));
                }
                windowVersion.SelectedItem = me.GetString("friendlyname");
                windowVersion.Visible = false;
                label1.Text = "Selected preset: " + windowVersion.SelectedItem.ToString();
                linkLabel1.Location = new Point(label1.Location.X + label1.Width, linkLabel1.Location.Y);
                linkLabel1.Visible = true;
            } else
            {
                GetOS();
            }
            if ((autoupdate == true) && DoWeHaveInternet(1000))
            { 
                UpdateInterface ui = new UpdateInterface();
                ui.DownloadFile(Program.update_server + "/bssp_version.txt", "vercheck.txt");
                updateCheckerTimer.Enabled = true;
                if (System.IO.File.Exists("BSSP_latest.zim"))
                {
                    try
                    { 
                        System.IO.File.Delete("BSSP_latest.zim");
                    }
                    catch
                    {
                        fileio = false;
                    }
                }
            }
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
            if (bsod_starter.IsAlive)
            { 
                if (Program.hidden)
                {
                    if (error == 0)
                    { 
                        spl2.SplashText.Text = "Generating blue screen...";
                        spl2.veriFileTimer.Enabled = false;
                        spl2.Show();
                    }
                }
            }
            switch (error)
            {
                case 0:
                    break;
                case 1:
                    MessageBox.Show("No command specified in hidden mode\nAre you missing the /c argument?\n\n0x001: COMMAND_DEADLOCK", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.Close();
                    break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //displays "Generating..." when a bluescreen is being generated
            //label10.Text = "Generating...";
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
            Crash();
        }

        //launches troubleshooting text editor
        private void Button2_Click(object sender, EventArgs e)
        {
            SupportEditor se = new SupportEditor();
            se.Show();
        }

        public void ShowBlueScreen()
        {
            if (windowVersion.Items.Count < 1)
            {
                Program.loadfinished = true;
                if (enableeggs)
                {
                    MessageBox.Show("Please select a Windows version! Also, how in the world did you deselect a dropdown list?", "Error displaying blue screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    MessageBox.Show("No configuration selected", "Error displaying blue screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            me.Show();
            try
            {
                if (spl2.Visible) { spl2.Close(); }
            }
            catch
            {
            }
            Thread.CurrentThread.Abort();
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
            Program.loadfinished = false;
            Gen g = new Gen();
            g.Show();
            Thread.Sleep(10);
            RandFunction();
            button1.PerformClick();
        }

        internal void RandFunction()
        {
            try
            {
                windowVersion.SelectedIndex = SetRnd(windowVersion.Items.Count - 1);
                autoBox.Checked = Convert.ToBoolean(SetRnd(2) - 1);
                greenBox.Checked = Convert.ToBoolean(SetRnd(2) - 1);
                serverBox.Checked = Convert.ToBoolean(SetRnd(2) - 1);
                qrBox.Checked = Convert.ToBoolean(SetRnd(2) - 1);
                comboBox1.SelectedIndex = SetRnd(comboBox1.Items.Count - 1);
                comboBox2.SelectedIndex = SetRnd(comboBox2.Items.Count - 1);
                amdBox.Checked = Convert.ToBoolean(SetRnd(2) - 1);
                stackBox.Checked = Convert.ToBoolean(SetRnd(2) - 1);
                acpiBox.Checked = Convert.ToBoolean(SetRnd(2) - 1);
                blinkBox.Checked = Convert.ToBoolean(SetRnd(2) - 1); ;
                checkBox1.Checked = Convert.ToBoolean(SetRnd(2) - 1);
                checkBox2.Checked = Convert.ToBoolean(SetRnd(2) - 1);
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
            catch (Exception ex)
            {
                Console.WriteLine("\nUnspecified error: " + ex.Message + "\n");
            }
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
            /*if (MessageBox.Show("System requirements:\n\nOS: Windows XP or later\nMicrosoft .NET Framework 3.5 (preinstalled in Windows 7 and later)\nScreen resolution: 1024x768 or higher (1280x1024 or higher recommended)\n\n\nHow to get help?\n\nFor items that have [?] at the end, you can just hover over them for more information.\n\n\nHow do I disable ClearType?\n\nTo disable ClearType, open system properties (Windows + Pause/Break). Then select advanced options (or Advanced tab). Finally select \"Settings\" from the performance section and uncheck font smoothing.\n\n\nWhat is the purpose of this program?\n\nThis program can be used as a way of screenshotting bluescreens without actually crashing your computer or messing with virtual machines. You can also use this program for pranking purposes (no harm will be done to the system).\n\n\nAbout this program:\n\nLanguage: C# (.NET framework, Windows Forms)\nCreated by: Markus Maal (TheMarkusGuy/MarkusTegelane)\nVersion 1.11, Build 7-8-19\nThis program can only be provided free of charge (if you had to pay for this, please ask for a refund). This program is provided as is, without a warranty.\n2019 Markuse tarkvara (Markus' software)\n\nWould you like to see command line argument syntax? (select \"Yes\" if you do)", "Help and about", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            { 
                MessageBox.Show(Program.cmds, "Command line argument usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
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
                    bsod_starter.Start();
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
                        bsod_starter.Start();
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
                    bsod_starter.Start();
                    waitPopup.Enabled = true;
                    prankModeTimer.Enabled = false;
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

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
                MessageBox.Show("Thank you for installing the latest version of Blue screen simulator plus :)\n\nWhat's new?\n * Typo fixed in the Windows 8/10 blue screen\n * Minor improvements\n * Executable description\n ? Added few easter eggs\n ? Beta version of the dark mode (betadark)\n ? Beta version of the Windows 7 black screen (blackscreen)", "Update was successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (tries > 500)
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
                    if (Convert.ToDouble(lines[0].Replace(".", ",").Replace("\r", "").Replace("\n", "").Trim()) > 2.0)
                    {
                        updateCheckerTimer.Enabled = false;
                        System.IO.File.Delete("vercheck.txt");
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
                            System.IO.File.Delete("vercheck.txt");
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
                            System.IO.File.Delete("vercheck.txt");
                        }
                    }
                }
            } catch (Exception ex)
            {
                updateCheckerTimer.Enabled = false;
                MessageBox.Show("An error has occoured.\n\nFatal exception: " + ex.Message + "\n\nStack trace\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    System.IO.File.WriteAllText("settings.cfg", "UpdateClose=" + postponeupdate.ToString() + "\nHashVerify=" + hashverify.ToString() + "\nAutoUpdate=" + autoupdate.ToString() + "\nShowCursor=" + showcursor.ToString() + "\nScaleMode=" + GMode + "\nMultiMode=" + Program.multidisplaymode.ToString() + "\nSeecrets=" + enableeggs.ToString() + "\nServer=" + Program.update_server);
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
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            if (textBox1.Text == "betadark")
            {
                MessageBox.Show("This egg is experimental. Don't complain please...", "Dark mode beta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form[] allForms = { this, new StringEdit(), Program.spl };
                foreach (Form f in allForms)
                {
                    f.BackColor = Color.Black;
                    f.ForeColor = Color.White;
                    foreach (Button c in f.Controls.OfType<Button>())
                    {
                        c.FlatStyle = FlatStyle.Flat;
                        c.BackColor = Color.FromArgb(0, 0, 50);
                    }
                    foreach (ComboBox c in f.Controls.OfType<ComboBox>())
                    {
                        c.DropDownStyle = ComboBoxStyle.DropDown;
                        c.FlatStyle = FlatStyle.Flat;
                        c.BackColor = Color.FromArgb(50, 50, 50);
                        c.ForeColor = Color.FromArgb(255, 255, 255);
                    }
                    foreach (Panel p in f.Controls.OfType<Panel>())
                    {
                        foreach (Panel q in p.Controls.OfType<Panel>())
                        {
                            foreach (TextBox t in q.Controls.OfType<TextBox>())
                            {
                                t.BorderStyle = BorderStyle.FixedSingle;
                                t.ForeColor = Color.White;
                                t.BackColor = Color.DimGray;
                            }
                            foreach (ComboBox c in q.Controls.OfType<ComboBox>())
                            {
                                c.DropDownStyle = ComboBoxStyle.DropDown;
                                c.FlatStyle = FlatStyle.Flat;
                                c.BackColor = Color.FromArgb(50, 50, 50);
                                c.ForeColor = Color.FromArgb(255, 255, 255);
                            }
                        }
                    }
                    return;
                }
            }
            if (!abopen)
            {
                AboutSettingsDialog ab1 = new AboutSettingsDialog
                {
                    Text = "Settings",
                    SettingTab = true
                };
                ab1.Show();
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
            try
            {
                if (windowVersion.SelectedIndex != -1)
                {
                    me.SetString("code", comboBox1.SelectedItem.ToString());
                }
            }
            catch { }
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
            if ((me.GetString("os") == "Windows XP") || (me.GetString("os") == "Windows Vista/7"))
            {
                me.RenameFile(me.GetFiles().ElementAt(0).Key, textBox2.Text);
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
            Crash();
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
                ab1.Show();
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
                ab1.Show();
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
                ab1.Show();
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
                ab1.Show();
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
                waitPopup.Enabled = false;
                this.WindowState = FormWindowState.Normal;
                this.Show();
            }
        }

        private void AdvancedNTOptionsToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
