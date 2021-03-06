﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing.Drawing2D;

namespace UltimateBlueScreenSimulator
{
    public partial class Form1 : Form
    {
        //these variables deal with error codes
        public string c1 = "RRRRRRRRRRRRRRRR";
        public string c2 = "RRRRRRRRRRRRRRRR";
        public string c3 = "RRRRRRRRRRRRRRRR";
        public string c4 = "RRRRRRRRRRRRRRRR";

        public string kode = "";

        //these variables deal with bsod themes
        public Color[] bsodmodern = { Color.FromArgb(16, 113, 170), Color.White };
        public Color[] bsodxvs = { Color.Navy, Color.White };
        public Color[] bsodnt = { Color.FromArgb(0, 0, 168), Color.FromArgb(170, 170, 170)};
        public Color[] bsodold = { Color.FromArgb(0, 0, 170), Color.White, Color.FromArgb(170, 170, 170), Color.FromArgb(0, 0, 170) };
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
        Splash spl2 = new Splash();
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

        //visible operating systems
        public bool[] osshows = { true, true, true, true, true, true, true, true, true, true};

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
        public Form1()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select bluescreen type
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
            xpNote.Visible = false;
            if (windowVersion.SelectedItem.ToString().Trim() == "Windows 10 (Native, Safe mode: 640x480, ClearType)")
            {
                WXOptions.Visible = true;
                serverBox.Visible = true;
                greenBox.Visible = true;
                qrBox.Visible = true;
                errorCode.Visible = true;
                autoBox.Checked = true;
                checkBox1.Visible = true;
                winMode.Visible = true;
            }
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows 8/8.1 (Native, Safe mode: 640x480, ClearType)")
            {
                WXOptions.Visible = true;
                errorCode.Visible = true;
                checkBox1.Visible = true;
                winMode.Visible = true;
            }
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows Vista/7 (640x480, ClearType)")
            {
                errorCode.Visible = true;
                winMode.Visible = true;
                acpiBox.Visible = true;
                checkBox1.Visible = true;
            }
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows XP (640x480, Standard)")
            {
                errorCode.Visible = true;
                winMode.Visible = true;
                xpNote.Visible = true;
                checkBox1.Visible = true;
            }
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows 2000 Professional/Server Family (640x480, Standard)")
            {
                errorCode.Visible = true;
                winMode.Visible = true;
                checkBox1.Checked = true;
            }
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows 9x/Millennium Edition (EGA text mode, Standard)")
            {
                nineXmessage.Visible = true;
                winMode.Visible = true;
            }
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows CE 3.0 and later (750x400, Standard)")
            {
                winMode.Visible = true;
                errorCode.Visible = true;
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
                textBox2.Enabled = false;
                xpNote.Visible = true;
            }
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows NT 4.0/3.x (VGA text mode, Standard)")
            {
                errorCode.Visible = true;
                amdBox.Visible = true;
                stackBox.Visible = true;
                ntPanel.Visible = true;
                winMode.Visible = true;
            }
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows 3.1 (EGA text mode, Standard)")
            {
                winMode.Visible = true;
            }
        }

        public void GetOS()
        {
            windowVersion.Items.Clear();
            for (int i = 0; i < defaultVersions.Items.Count; i++)
            {
                if (osshows[i] == true)
                {
                    windowVersion.Items.Add(defaultVersions.Items[i]);
                }
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
            xpNote.Visible = false;
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

        private void Form1_Load(object sender, EventArgs e)
        {
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
            GetOS();
            if (autoupdate == true)
            { 
                UpdateInterface ui = new UpdateInterface();
                ui.DownloadFile("markustegelane.tk/app/bssp_version.txt", "vercheck.txt");
                timer3.Enabled = true;
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
            if (timer1.Enabled)
            { 
                if (Program.hidden)
                {
                    if (error == 0)
                    { 
                        spl2.SplashText.Text = "Generating blue screen...";
                        spl2.timer1.Enabled = false;
                        spl2.Show();
                    }
                }
            }
            if (error == 1)
            {
                MessageBox.Show("No command specified in hidden mode\nAre you missing the /c argument?\n\n0x001: COMMAND_DEADLOCK", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 10)
            {
                timer1.Enabled = false;
                MessageBox.Show("A supported Windows version could not be identified.\n\n0x00A: PRODUCT_NAME_NOT_LISTED", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Enabled = true;
                error = 0;
            }
            if (error == 11)
            {
                timer1.Enabled = false;
                MessageBox.Show("Windows version could not be identified.\nAre you using a compatibility layer?\n\n0x00B: PRODUCT_NAME_MISSING", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Enabled = true;
                error = 0;
            }
            if (error == 12)
            {
                timer1.Enabled = false;
                MessageBox.Show("Cannot find the Windows version specified\n\n0x00C: WINVER_NOT_FOUND", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 13)
            {
                timer1.Enabled = false;
                MessageBox.Show("Cannot find the error code specified\n\n0x00D: NTCODE_NOT_FOUND", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 14)
            {
                timer1.Enabled = false;
                MessageBox.Show("Cannot find the error code specified\n\n0x00D: 9XCODE_NOT_FOUND", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 15)
            {
                timer1.Enabled = false;
                MessageBox.Show("The syntax of the command is incorrect\n\n0x00E: BAD_SYNTAX", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 16)
            {
                timer1.Enabled = false;
                MessageBox.Show("The syntax of the command is incorrect\n\n0x00F: BAD_SYNTAX", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 17)
            {
                timer1.Enabled = false;
                MessageBox.Show("The syntax of the command is incorrect\n\n0x010: BAD_SYNTAX", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 18)
            {
                timer1.Enabled = false;
                MessageBox.Show("The syntax of the command is incorrect\n\n0x011: BAD_SYNTAX", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 19)
            {
                timer1.Enabled = false;
                MessageBox.Show("Internal database could not be loaded\n\n0x012: NT_DATABASE_MISSING", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 20)
            {
                timer1.Enabled = false;
                MessageBox.Show("Internal database seems to be corrupted\n\n0x013: NT_DATABASE_CORRUPTED", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 24)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified hack file does not exist\n\n0x014: HACK_FILE_NON_EXISTENT", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 25)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified hack file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x015: HACK_FILE_INCOMPATIBLE", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 23)
            {
                timer1.Enabled = false;
                MessageBox.Show("The syntax of the command is incorrect\n\n0x016: COMMAND_ARGUMENT_INVALID", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 9)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x009: RGB_VALUE_NEGATIVE", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (error == 8)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x008: RGB_OUT_OF_RANGE", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (error == 7)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x007: FACE_TOO_SHORT", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (error == 6)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x006: FACE_TOO_LONG", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (error == 5)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x005: MISSING_ATTRIBUTES", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (error == 2)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified file is either corrupted or not a valid blue screen simulator plus hack file.\n\n0x002: HEADER_MISSING", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (error == 3)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified file is either corrupted or incompatible with this version of blue screen simulator plus.\n\n0x003: INCOMPATIBLE_HACK", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error == 4)
            {
                timer1.Enabled = false;
                MessageBox.Show("Specified file is either corrupt or does not exist.\n\n0x004: FILE_MISSING", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (error != 0) { this.Close(); }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //displays "Generating..." when a bluescreen is being generated
            label10.Text = "Generating...";
            timer1.Enabled = true;

        }

        //generates hexadecimal codes
        //lettercount sets the length of the actual hex code
        //inspir is a string where each character represents if the value is fixed or random
        public string GenHex(int lettercount, string inspir)
        {
            //sleep command is used to make sure that randomization works properly
            Thread.Sleep(20);
            string output = "";
            Random r = new Random();
            for (int i = 0; i < lettercount; i++)
            {
                int temp = r.Next(15);
                char lette = ' ';
                if ((inspir + inspir).Substring(i, 1) == "R") { 
                    if (temp < 10) { lette = Convert.ToChar(temp.ToString()); }
                    if (temp == 10) { lette = 'A'; }
                    if (temp == 11) { lette = 'B'; }
                    if (temp == 12) { lette = 'C'; }
                    if (temp == 13) { lette = 'D'; }
                    if (temp == 14) { lette = 'E'; }
                    if (temp == 15) { lette = 'F'; }
                } else
                {
                    lette = Convert.ToChar((inspir + inspir).Substring(i, 1));
                }
                output += lette.ToString();
            }
            return output;
        }


        //GenAddress uses the last function to generate multiple error address codes
        public string GenAddress(int count, int places, bool lower)
        {
            string ot = "";
            string inspir = c1;
            for (int i = 0; i < count; i++)
            {
                if (i == 1) { inspir = c2; }
                if (i == 2) { inspir = c3; }
                if (i == 3) { inspir = c4; }
                if (ot != "") { ot += ", "; }
                ot += "0x" + GenHex(places, inspir);
            }
            if (lower) { return ot.ToLower(); }
            return ot;
        }

        //GenFile generates a new file for use in Windows NT blue screen
        public string GenFile(bool lower = true)
        {
            Thread.Sleep(20);
            string filename = "hal.dll";
            Random r = new Random();
            int temp = r.Next(15);
            if (temp == 0) { filename = "ntoskrnl.exe"; }
            if (temp == 1) { filename = "hal.dll"; }
            if (temp == 2) { filename = "atapi.sys"; }
            if (temp == 3) { filename = "tcpip.sys"; }
            if (temp == 4) { filename = "Cdrom.sys"; }
            if (temp == 5) { filename = "vga.sys"; }
            if (temp == 6) { filename = "Floppy.sys"; }
            if (temp == 7) { filename = "mup.sys"; }
            if (temp == 8) { filename = "Beep.sys"; }
            if (temp == 9) { filename = "Ntfs.sys"; }
            if (temp == 10) { filename = "netbios.sys"; }
            if (temp == 11) { filename = "CLASS32.SYS"; }
            if (temp == 12) { filename = "srv.sys"; }
            if (temp == 13) { filename = "SCSIPORT.SYS"; }
            if (temp == 14) { filename = "Disk.SYS"; }
            if (temp == 15) { filename = "Null.SYS"; }
            if (lower == false) { return filename.ToUpper(); }
            return filename;
        }

        //launches troubleshooting text editor
        private void Button2_Click(object sender, EventArgs e)
        {
            SupportEditor se = new SupportEditor();
            se.Show();
        }

        //generates the blue screen
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Interval != 60) { timer1.Interval = 60; }
            //disables the timer immediately
            //timer is used to give the computer time to draw a label, containing the text "Generating..."
            timer1.Enabled = false;
            if (enableeggs == true)
            {
                if (textBox2.Text.Contains("null"))
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
                    foreach (Control c in Program.bh.flowLayoutPanel1.Controls)
                    {
                        if (c is Panel)
                        {
                            foreach (Control ctrl in c.Controls)
                            {
                                if (ctrl is TextBox)
                                {
                                    ctrl.Text = "undefined";
                                }
                            }
                        }
                    }
                    this.Text = "";
                    this.HelpButton = false;
                    this.ShowIcon = false;
                    this.ShowInTaskbar = false;
                }
            }
            //Windows 10 blue screen
            //optional attributes
            /* qrBox (bool) - if true, QR code will be displayed on the blue screen
             * autoBox (bool) - if true, blue screen will close automatically
             * greenBox (bool) - if true, displays Windows Insider Preview's green screen
             * serverBox (bool) - if true, displays a server blue screen instead of a regular blue screen (without an emoticon)
             * waterBox (bool) - if true, displays a watermark
             * checkBox1 (bool) - if true, displays the error description
             * checkBox2 (bool) - if true, shows a potential culprit file
             * winMode (bool) - if true, the blue screen will display in a window
             */
            if (windowVersion.Items.Count < 1)
            {
                MessageBox.Show("Please select a Windows version, dummy!", "Error displaying blue screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Enabled = false;
                label10.Text = "";
                return;
            }
            if (windowVersion.SelectedItem.ToString().Trim() == "Windows 10 (Native, Safe mode: 640x480, ClearType)")
            {
                WXBS bs = new WXBS();
                try { 
                bs.label1.Text = emoticon;
                bs.BackColor = bsodmodern[0];
                bs.ForeColor = bsodmodern[1];
                if (qrBox.Checked == false) { bs.qr = false; }
                if (autoBox.Checked == false) { bs.close = false; }
                if (greenBox.Checked == true) { bs.green = true; }
                if (serverBox.Checked == true) { bs.server = true; }
                if (waterBox.Checked == false) { bs.waterMarkText.Visible = false; }
                if (checkBox2.Checked == true) { bs.whatfail = textBox2.Text; }
                if (winMode.Checked == true) { bs.WindowState = FormWindowState.Normal; bs.FormBorderStyle = FormBorderStyle.Sizable; }
                if (checkBox1.Checked == false)
                {
                    bs.code = comboBox1.SelectedItem.ToString().Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString();
                }
                else
                {
                    bs.code = comboBox1.SelectedItem.ToString().Split(' ')[0].ToString();
                }
                bs.Show();
                if (spl2.Visible) { spl2.Close(); }
                }
                catch
                {
                    bs.Show();
                }
            }
            //Windows 8.x blue screen
            //optional attributes
            /* autoBox (bool) - if true, blue screen will close automatically
             * waterBox (bool) - if true, displays a watermark
             * checkBox1 (bool) - if true, displays the error description
             * checkBox2 (bool) - if true, shows a potential culprit file
             * winMode (bool) - if true, the blue screen will display in a window
             */
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows 8/8.1 (Native, Safe mode: 640x480, ClearType)")
            {
                WXBS bs = new WXBS
                {
                    qr = false
                };
                try
                {
                    bs.label1.Text = emoticon;
                bs.BackColor = bsodmodern[0];
                bs.ForeColor = bsodmodern[1];
                if (autoBox.Checked == false) { bs.close = false; }
                if (waterBox.Checked == false) { bs.waterMarkText.Visible = false; }
                if (checkBox2.Checked == true) { bs.whatfail = textBox2.Text; }
                if (winMode.Checked == true) { bs.WindowState = FormWindowState.Normal; bs.FormBorderStyle = FormBorderStyle.Sizable; }
                bs.green = false;
                bs.server = false;
                bs.w8 = true;
                if (checkBox1.Checked == false)
                {
                    bs.code = comboBox1.SelectedItem.ToString().Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString();
                }
                else
                {
                    bs.code = comboBox1.SelectedItem.ToString().Split(' ')[0].ToString();
                }
                bs.Show();
                if (spl2.Visible) { spl2.Close(); }
                }
                catch
                {
                    bs.Show();
                }
            }
            //Windows Vista/7 blue screen
            //optional attributes
            /* waterBox (bool) - if true, displays a watermark
             * checkBox1 (bool) - if true, displays the error description
             * checkBox2 (bool) - if true, shows a potential culprit file
             * winMode (bool) - if true, the blue screen will display in a window
             * acpiBox (bool) - if true, displays only the technical information
             */
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows Vista/7 (640x480, ClearType)")
            {
                Xvsbs bs = new Xvsbs
                {
                    BackColor = bsodxvs[0],
                    ForeColor = bsodxvs[1],
                    w6mode = true
                };
                try
                { 
                    if (winMode.Checked == true) { bs.fullscreen = false; }
                    if (checkBox1.Checked == false) { bs.errorCode.Visible = false; }
                    if (waterBox.Checked == false) { bs.waterMarkText.Visible = false; }
                    if (checkBox2.Checked == true) { bs.whatfail = textBox2.Text; }
                    if (acpiBox.Checked == true)
                    {
                        bs.errorCode.Visible = false;
                        bs.label1.Visible = false;
                        bs.label5.Visible = false;
                        bs.label6.Visible = false;
                        bs.label7.Visible = false;
                    }
                    bs.errorCode.Text = comboBox1.SelectedItem.ToString().Split(' ')[0].ToString();
                    bs.technicalCode.Text = "*** STOP: " + comboBox1.SelectedItem.ToString().Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString() + " (" + GenAddress(4, 16, false) + ")";
                    bs.supportInfo.Text = supporttext + "\n\n\nTechnical information:";
                    bs.Show();
                    if (spl2.Visible) { spl2.Close(); }
                    if (acpiBox.Checked == true) { bs.supportInfo.Text = "\n\n\n\n\n"; }
                }
                catch
                {
                    bs.Show();
                }
            }
            //Windows Vista/7 bootmgr error screen
            //optional attributes
            /* waterBox (bool) - if true, displays a watermark
             * checkBox1 (bool) - if true, displays the error description
             * checkBox2 (bool) - if true, shows a potential culprit file
             * winMode (bool) - if true, the blue screen will display in a window
             * acpiBox (bool) - if true, displays only the technical information
             */
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows Vista/7 BOOTMGR (1024x768, ClearType)")
            {
                BootMgr bs = new BootMgr();
                bs.Show();
            }
            //Windows XP blue screen
            //optional attributes
            /* waterBox (bool) - if true, displays a watermark
             * checkBox1 (bool) - if true, displays the error description
             * checkBox2 (bool) - if true, shows a potential culprit file
             * winMode (bool) - if true, the blue screen will display in a window
             */
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows XP (640x480, Standard)")
            {
                Xvsbs bs = new Xvsbs
                {
                    BackColor = bsodxvs[0],
                    ForeColor = bsodxvs[1]
                };
                try
                { 
                    if (winMode.Checked == true) { bs.fullscreen = false; }
                    if (checkBox1.Checked == false) { bs.errorCode.Visible = false; }
                    if (waterBox.Checked == false) { bs.waterMarkText.Visible = false; }
                    if (checkBox2.Checked == true) { bs.whatfail = textBox2.Text; }
                    bs.errorCode.Text = comboBox1.SelectedItem.ToString().Split(' ')[0].ToString();
                    bs.technicalCode.Text = "*** STOP: " + comboBox1.SelectedItem.ToString().Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString() + " (" + GenAddress(4, 8, false) + ")";
                    bs.supportInfo.Text = supporttext + "\n\n\nTechnical information:";
                    bs.Show();
                    if (spl2.Visible) { spl2.Close(); }
                } catch
                {
                    bs.Show();
                }
            }
            //Windows 2000 blue screen
            //optional attributes
            /* waterBox (bool) - if true, displays a watermark
             * checkBox1 (bool) - if true, displays the error description
             * checkBox2 (bool) - if true, shows a potential culprit file
             * winMode (bool) - if true, the blue screen will display in a window
             */
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows 2000 Professional/Server Family (640x480, Standard)")
            {
                w2kbs bs = new w2kbs
                {
                    BackColor = bsodxvs[0],
                    ForeColor = bsodxvs[1]
                };
                try
                { 
                    if (winMode.Checked == true) { bs.fullscreen = false; }
                    if (checkBox1.Checked == false) { bs.errorCode.Visible = false; }
                    if (waterBox.Checked == false) { bs.waterMarkText.Visible = false; }
                    if (checkBox2.Checked == true) { bs.whatfail = textBox2.Text; }
                    bs.errorCode.Text = "*** STOP: " + comboBox1.SelectedItem.ToString().Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString() + " (" + GenAddress(4, 8, false) + ")";
                    bs.errorCode.Text = bs.errorCode.Text + "\n" + comboBox1.SelectedItem.ToString().Split(' ')[0].ToString();
                    bs.Show();
                    if (spl2.Visible) { spl2.Close(); }
                }
                catch
                {
                    bs.Show();
                }
            }
            //Windows 9x/Me blue screen
            //optional attributes
            /* waterBox (bool) - if true, displays a watermark
             * screenmode (string) - the type of error to be displayed (e.g. "System error")
             * winMode (bool) - if true, the blue screen will display in a window
             */
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows 9x/Millennium Edition (EGA text mode, Standard)")
            {
                old_bluescreen bs = new old_bluescreen
                {
                    BackColor = bsodold[0],
                    ForeColor = bsodold[1]
                };
                try
                {
                    if (winMode.Checked == true) { bs.window = true; }
                    bs.screenmode = comboBox2.SelectedItem.ToString();
                    bs.errorCode = GenHex(2, c1) + " : " + GenHex(4, c2) + " : " + GenHex(6, c3);
                    if (waterBox.Checked == false) { bs.waterMarkText.Visible = false; }
                    bs.Show();
                    if (spl2.Visible) { spl2.Close(); }
                }
                catch
                {
                    bs.Show();
                }
            }
            //Windows CE blue screen
            //optional attributes
            /* waterBox (bool) - if true, displays a watermark
             * winMode (bool) - if true, the blue screen will display in a window
             */
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows CE 3.0 and later (750x400, Standard)")
            {
                cebsod bs = new cebsod
                {
                    BackColor = bsodxvs[0],
                    ForeColor = bsodxvs[1]
                };
                try
                {
                    if (winMode.Checked == true) { bs.fullscreen = false; }
                    if (waterBox.Checked == false) { bs.waterMarkText.Visible = false; }
                    bs.technicalCode.Text = "*** STOP: 0x" + comboBox1.SelectedItem.ToString().Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString().Substring(4, 6) + " (" + comboBox1.SelectedItem.ToString().Split(' ')[0].ToString().Replace("_", " ").ToLower() + ")";
                    bs.Show();
                    if (spl2.Visible) { spl2.Close(); }
                }
                catch
                {
                    bs.Show();
                }
            }
            //Windows NT 3.x/4.0 blue screen
            //optional attributes
            /* waterBox (bool) - if true, displays a watermark
             * amdBox (bool) - if true, displays "AuthenticAMD" instead of "GenuineIntel" on the blue screen
             * stackBox (bool) - if true, displays Stack trace
             * blinkBox (bool) - if true, displays a blinking cursor
             * checkBox1 (bool) - if true, displays the error description
             * checkBox2 (bool) - if true, shows a potential culprit file
             * winMode (bool) - if true, the blue screen will display in a window
             */
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows NT 4.0/3.x (VGA text mode, Standard)")
            {
                NTBSOD bs = new NTBSOD
                {
                    BackColor = bsodnt[0],
                    ForeColor = bsodnt[1]
                };
                try { 
                    if (checkBox2.Checked == true) { bs.whatfail = textBox2.Text; }
                    bs.error = comboBox1.SelectedItem.ToString().Substring(0, comboBox1.SelectedItem.ToString().Length - 1);
                    if (winMode.Checked == true) { bs.fullscreen = false; }
                    if (amdBox.Checked == true) { bs.processortype = "AuthenticAMD"; }
                    if (stackBox.Checked == false) { bs.stacktrace = false; }
                    if (blinkBox.Checked == false) { bs.blink = false; }
                    if (waterBox.Checked == false) { bs.waterMarkText.Visible = false; }
                    bs.Show();
                    if (spl2.Visible) { spl2.Close(); }
                }
                catch
                {
                    bs.Show();
                }
            }
            //Windows 3.1x unofficial blue screen
            //optional attributes
            /* waterBox (bool) - if true, displays a watermark
             * screenmode (string) - the type of error to be displayed (e.g. "No unresponsive programs")
             * winMode (bool) - if true, the blue screen will display in a window
             */
            else if (windowVersion.SelectedItem.ToString().Trim() == "Windows 3.1 (EGA text mode, Standard)")
            {
                old_bluescreen bs = new old_bluescreen
                {
                    BackColor = bsodold[0],
                    ForeColor = bsodold[1]
                };
                try
                { 
                    if (winMode.Checked == true) { bs.window = true; }
                    bs.screenmode = "No unresponsive programs";
                    bs.errorCode = GenHex(2, c1) + " : " + GenHex(4, c2) + " : " + GenHex(6, c3);
                    if (waterBox.Checked == false) { bs.waterMarkText.Visible = false; }
                    bs.Show();
                    if (spl2.Visible) { spl2.Close(); }
                }
                catch
                {
                    bs.Show();
                }
            }
            //removes "Generating..." text
            label10.Text = "";
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
                textBox2.Text = GenFile();
                if (windowVersion.SelectedIndex == 4) { checkBox1.Checked = true; }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nUnspecified error: " + ex.Message + "\n");
            }
        }

        int SetRnd(int limit)
        {
            Thread.Sleep(20);
            Random rnd = new Random();
            try
            {
                int outp = 0;
                outp = rnd.Next(limit);
                return outp;
            } catch
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
                c1 = c1,
                c2 = c2,
                c3 = c3,
                c4 = c4
            };
            iform.Show();
        }

        //enables, disa
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.Enabled = true;
            } else
            {
                textBox2.Enabled = false;
            }
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
            Program.bh.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            PrankMode pm = new PrankMode();
            pm.Show();
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            if (!abopen) { 
                AboutBox1 a1 = new AboutBox1();
                a1.Text = "Help and about";
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
                    timer1.Enabled = true;
                    timer2.Enabled = false;
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
            } else
            {
                bool getcatch = false;
                if (Process.GetProcessesByName(appname.Replace(".exe", "")).Length != 0)
                {
                    getcatch = true;
                }
                if (getcatch)
                {
                    timer1.Interval = 5000;
                    timer1.Enabled = true;
                    timer2.Enabled = false;
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
                timer3.Enabled = false;
                MessageBox.Show("Thank you for installing the latest version of Blue screen simulator plus :)\n\nWhat's new?\n * Typo fixed in the Windows 8/10 blue screen\n * Minor improvements\n * Executable description\n ? Added few easter eggs\n ? Beta version of the dark mode (betadark)\n ? Beta version of the Windows 7 black screen (blackscreen)", "Update was successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int tries = 0;
                while (System.IO.File.Exists("BSSP.exe"))
                {
                    tries += 1;
                    try
                    {
                        System.IO.File.Delete("BSSP.exe");
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
                    if (lines[0].Trim() != "1.14")
                    {
                        timer3.Enabled = false;
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
                        if (timer3.Interval == 5999)
                        {
                            timer3.Interval = 6000;
                            timer3.Enabled = false;
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
                        else if (timer3.Interval == 5998)
                        {
                            timer3.Interval = 6000;
                            timer3.Enabled = false;
                            MessageBox.Show("This version of blue screen simulator plus is up to date", "Blue screens simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            System.IO.File.Delete("vercheck.txt");
                        }
                    }
                }
            } catch
            {
            }
        }

        private void Button1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string settingcontent = "UpdateClose=" + postponeupdate.ToString() + "\nHashVerify=" + hashverify.ToString() + "\nAutoUpdate=" + autoupdate.ToString() + "\nShowCursor=" + showcursor.ToString() + "\nScaleMode=" + GMode + "\nSeecrets=" + enableeggs.ToString();
                settingcontent += "\nVersions=\"";
                foreach (string element in windowVersion.Items)
                {
                    settingcontent += "\n" + element;
                }
                settingcontent += "\"";
                System.IO.File.WriteAllText("settings.cfg", settingcontent);
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

        private void WindowVersion_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "betadark")
            {
                MessageBox.Show("This egg is experimental. Don't complain please...", "Dark mode beta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form[] allForms = { this, Program.bh, Program.spl };
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
                AboutBox1 ab1 = new AboutBox1();
                ab1.Text = "Settings";
                ab1.SettingTab = true;
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
    }
}
