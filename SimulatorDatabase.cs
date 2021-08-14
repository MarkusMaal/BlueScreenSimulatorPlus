using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UltimateBlueScreenSimulator;
using System.Drawing;

//
// This namespace contains classes that are shared between forms that specify
// using SimulatorDatabase;
// at the top
//
namespace SimulatorDatabase
{

    //
    // Blue screen template class
    //
    public class BlueScreen
    {
        // constructor
        private Color background;
        private Color foreground;
        private Color highlight_bg;
        private Color highlight_fg;

        private string[] ecodes;

        private string code;
        private string emoticon;
        private string screen_mode;
        private string qr_file;
        private string friendlyname;
        private string culprit;

        private readonly string os;

        private bool windowed;
        private bool autoclose;
        private bool show_description;
        private bool show_file;
        private bool watermark;
        private bool server;
        private bool qr;
        private bool insider;
        private bool acpi;
        private bool amd;
        private bool stack_trace;
        private bool blink;
        private bool font_support;
        private bool blinkblink;
        private bool winxplus;
        private bool extracodes;

        private int blink_speed;
        private int timer;
        private int qr_size;

        private Font font;

        // possible values:
        // 2D flag
        // 3D flag
        // 2D window
        // 3D window
        private string icon;

        IDictionary<string, string> titles;
        IDictionary<string, string> texts;

        public BlueScreen(string base_os)
        {
            this.background = Color.FromArgb(0, 0, 0);
            this.foreground = Color.FromArgb(255, 255, 255);
            this.os = base_os;
            string[] codes_temp = { "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR" };
            this.ecodes = codes_temp;
            this.code = "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)";
            this.emoticon = ":(";
            this.screen_mode = "System error";
            this.windowed = false;
            this.autoclose = true;
            this.watermark = true;
            this.show_description = true;
            this.show_file = false;
            this.server = false;
            this.qr = true;
            this.insider = false;
            this.acpi = false;
            this.amd = false;
            this.stack_trace = true;
            this.blink = false;
            this.highlight_bg = Color.FromArgb(255, 255, 255);
            this.highlight_fg = Color.FromArgb(0, 0, 0);
            this.icon = "2D flag";
            this.blink_speed = 100;
            this.titles = new Dictionary<string, string>();
            this.texts = new Dictionary<string, string>();
            this.timer = 30;
            this.font = new Font("Lucida Console", 10.4f, FontStyle.Regular);
            this.qr_size = 110;
            this.qr_file = "local:0";
            this.blinkblink = false;
            this.font_support = true;
            this.winxplus = false;
            this.friendlyname = "";
            this.culprit = "";
            this.extracodes = false;
            SetOSSpecificDefaults();
        }

        // blue screen properties
        public bool GetBool(string name)
        {
            switch (name)
            {
                case "windowed": return this.windowed;
                case "watermark": return this.watermark;
                case "autoclose": return this.autoclose;
                case "show_description": return this.show_description;
                case "show_file": return this.show_file;
                case "server": return this.server;
                case "insider": return this.insider;
                case "acpi": return this.acpi;
                case "amd": return this.amd;
                case "blink": return this.blink;
                case "stack_trace": return this.stack_trace;
                case "font_support": return this.font_support;
                case "blinkblink": return this.blinkblink;
                case "winxplus": return this.winxplus;
                case "qr": return this.qr;
                case "extracodes": return this.extracodes;
                default: return false;
            }
        }
        public void SetBool(string name, bool value)
        {
            switch (name)
            {
                case "windowed": this.windowed = value; break;
                case "watermark": this.watermark = value; break;
                case "show_description": this.show_description = value; break;
                case "show_file": this.show_file = value; break;
                case "server": this.server = value; break;
                case "insider": this.insider = value; break;
                case "acpi": this.acpi = value; break;
                case "amd": this.amd = value; break;
                case "blink": this.blink = value; break;
                case "stack_trace": this.stack_trace = value; break;
                case "qr": this.qr = value; break;
                case "autoclose": this.autoclose = value; break;
                case "extracodes": this.extracodes = value; break;
            }
        }
        //GenAddress uses the last function to generate multiple error address codes
        public string GenAddress(int count, int places, bool lower)
        {
            string ot = "";
            string inspir = GetString("ecode1");
            for (int i = 0; i < count; i++)
            {
                if (i == 1) { inspir = GetString("ecode2"); }
                if (i == 2) { inspir = GetString("ecode3"); }
                if (i == 3) { inspir = GetString("ecode4"); }
                if (ot != "") { ot += ", "; }
                ot += "0x" + GenHex(places, inspir);
            }
            if (lower) { return ot.ToLower(); }
            return ot;
        }
        //generates hexadecimal codes
        //lettercount sets the length of the actual hex code
        //inspir is a string where each character represents if the value is fixed or random
        public string GenHex(int lettercount, string inspir)
        {
            //sleep command is used to make sure that randomization works properly
            System.Threading.Thread.Sleep(20);
            string output = "";
            Random r = new Random();
            for (int i = 0; i < lettercount; i++)
            {
                int temp = r.Next(15);
                char lette = ' ';
                if ((inspir + inspir).Substring(i, 1) == "R")
                {
                    if (temp < 10) { lette = Convert.ToChar(temp.ToString()); }
                    if (temp == 10) { lette = 'A'; }
                    if (temp == 11) { lette = 'B'; }
                    if (temp == 12) { lette = 'C'; }
                    if (temp == 13) { lette = 'D'; }
                    if (temp == 14) { lette = 'E'; }
                    if (temp == 15) { lette = 'F'; }
                }
                else
                {
                    lette = Convert.ToChar((inspir + inspir).Substring(i, 1));
                }
                output += lette.ToString();
            }
            return output;
        }



        //GenFile generates a new file for use in Windows NT blue screen
        public string GenFile(bool lower = true)
        {
            System.Threading.Thread.Sleep(20);
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

        public void Show()
        {
            switch (this.os)
            {
                case "BOOTMGR":
                    BootMgr bm = new BootMgr();
                    bm.Show();
                    //bm.Dispose();
                    break;
                case "Windows 11":
                    SetupWinXabove(new WXBS(), true);
                    break;
                case "Windows 10":
                    SetupWinXabove(new WXBS());
                    break;
                case "Windows 8/8.1":
                    SetupWin8(new WXBS());
                    break;
                case "Windows Vista/7":
                    SetupVista(new Xvsbs());
                    break;
                case "Windows XP":
                    SetupExperience(new Xvsbs());
                    break;
                case "Windows 2000":
                    Setup2k(new w2kbs());
                    break;
                case "Windows CE":
                    SetupCE(new cebsod());
                    break;
                case "Windows NT 3.x/4.0":
                    SetupNT(new NTBSOD());
                    break;
                case "Windows 9x/Me":
                    Setup9x(new old_bluescreen());
                    break;
                case "Windows 3.1x":
                    this.screen_mode = "No unresponsive programs";
                    Setup9x(new old_bluescreen());
                    break;
            }
        }

        private void SetupCE(cebsod bs)
        {
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            bs.Font = this.GetFont();
            bs.fullscreen = !this.windowed;
            bs.waterMarkText.Visible = this.watermark;
            bs.technicalCode.Text = "*** STOP: 0x" + this.code.Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString().Substring(4, 6) + " (" + this.code.Split(' ')[0].ToString().Replace("_", " ").ToLower() + ")";
            bs.me = this;
            bs.Show();
        }

        private void SetupNT(NTBSOD bs)
        {
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            if (GetBool("show_file")) { bs.whatfail = GetString("culprit"); }
            bs.error = this.code.Substring(0, this.code.ToString().Length - 1);
            bs.fullscreen = !this.windowed;
            if (this.amd) { bs.processortype = "AuthenticAMD"; }
            bs.stacktrace = this.stack_trace;
            bs.blink = this.blink;
            bs.waterMarkText.Visible = this.watermark;
            bs.me = this;
            bs.Show();
        }

        private void Setup9x(old_bluescreen bs)
        {
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            bs.window = this.GetBool("windowed");
            bs.screenmode = this.GetString("screen_mode");
            bs.errorCode = GenHex(2, GetString("ecode1")) + " : " + GenHex(4, GetString("ecode2")) + " : " + GenHex(6, GetString("ecode3"));
            bs.waterMarkText.Visible = this.GetBool("watermark");
            bs.me = this;
            bs.Show();
        }

        private void Setup2k(w2kbs bs)
        {
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            bs.fullscreen = !this.GetBool("windowed");
            bs.waterMarkText.Visible = this.GetBool("watermark");
            if (this.GetBool("show_file")) { bs.whatfail = this.GetString("culprit"); }
            bs.errorCode.Text = "*** STOP: " + this.GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString() + " (" +
                                GenHex(8, this.GetString("ecode1")) + ", " +
                                GenHex(8, this.GetString("ecode2")) + ", " +
                                GenHex(8, this.GetString("ecode3")) + ", " +
                                GenHex(8, this.GetString("ecode4")) +  ")";
            bs.errorCode.Text = bs.errorCode.Text + "\n" + this.GetString("code").Split(' ')[0].ToString();
            bs.me = this;
            bs.Show();
        }

        private void SetupExperience(Xvsbs bs)
        {
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            bs.fullscreen = !this.GetBool("windowed");
            bs.errorCode.Visible = this.GetBool("show_details");
            bs.waterMarkText.Visible = this.GetBool("watermark");
            if (this.GetBool("show_file")) { bs.whatfail = this.GetString("culprit"); }
            bs.errorCode.Text = this.GetString("code").Split(' ')[0].ToString();
            bs.technicalCode.Text = "*** STOP: " + this.GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString() + " (" + GenAddress(4, 8, false) + ")";
            bs.supportInfo.Text = this.GetTexts()["Technical support"] + "\n\n\nTechnical information:";
            bs.me = this;
            bs.Show();
        }

        private void SetupVista(Xvsbs bs)
        {
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            bs.fullscreen = !this.GetBool("windowed");
            bs.errorCode.Visible = this.GetBool("show_details");
            bs.waterMarkText.Visible = this.GetBool("watermark");
            if (this.GetBool("show_file")) { bs.whatfail = this.GetString("culprit"); }
            if (this.GetBool("acpi"))
            {
                //bs.errorCode.Visible = false;
                bs.label1.Visible = false;
                bs.label5.Visible = false;
                bs.label6.Visible = false;
                bs.label7.Visible = false;
            }
            bs.errorCode.Text = this.GetString("code").Split(' ')[0].ToString();
            bs.technicalCode.Text = "*** STOP: " + this.GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString() + " (" + GenAddress(4, 16, false) + ")";
            bs.supportInfo.Text = this.GetTexts()["Technical support"] + "\n\n\nTechnical information:";
            bs.w6mode = true;
            bs.me = this;
            bs.Show();
        }

        private void SetupWinXabove(WXBS bs, bool w11 = false)
        {
            bs.label1.Text = this.GetString("emoticon");
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            bs.qr = this.qr;
            bs.close = this.autoclose;
            bs.green = this.insider;
            bs.server = this.server;
            bs.w11 = w11;
            bs.memCodes.Text = "0x" + GenHex(16, GetString("ecode1")) + "\r\n0x" +
                                GenHex(16, GetString("ecode2")) + "\r\n0x" +
                                GenHex(16, GetString("ecode3")) + "\r\n0x" +
                                GenHex(16, GetString("ecode4"));
            bs.waterMarkText.Visible = GetBool("watermark");
            if (GetBool("show_file")) { bs.whatfail = GetString("culprit"); }
            if (GetBool("windowed")) { bs.WindowState = FormWindowState.Normal; bs.FormBorderStyle = FormBorderStyle.Sizable; }
            if (GetBool("show_description"))
            {
                bs.code = GetString("code").Split(' ')[0].ToString();
            }
            else
            {
                bs.code = GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString();
            }
            bs.me = this;
            bs.Show();
        }

        private void SetupWin8(WXBS bs)
        {
            bs.label1.Text = this.GetString("emoticon");
            bs.BackColor = this.GetTheme(true);
            bs.ForeColor = this.GetTheme(false);
            bs.qr = false;
            bs.w8 = true;
            bs.close = GetBool("autoclose");
            bs.green = false;
            bs.server = false;
            bs.memCodes.Text = "0x" + GenHex(16, GetString("ecode1")) + "\r\n0x" +
                                GenHex(16, GetString("ecode2")) + "\r\n0x" +
                                GenHex(16, GetString("ecode3")) + "\r\n0x" +
                                GenHex(16, GetString("ecode4"));
            bs.waterMarkText.Visible = GetBool("watermark");
            if (GetBool("show_file")) { bs.whatfail = GetString("culprit"); }
            if (GetBool("windowed")) { bs.WindowState = FormWindowState.Normal; bs.FormBorderStyle = FormBorderStyle.Sizable; }
            if (GetBool("show_description"))
            {
                bs.code = GetString("code").Split(' ')[0].ToString();
            }
            else
            {
                bs.code = GetString("code").Split(' ')[1].ToString().Replace(")", "").Replace("(", "").ToString();
            }
            bs.me = this;
            bs.Show();
        }

        public string GetString(string name)
        {
            switch (name)
            {
                case "os": return this.os;
                case "emoticon": return this.emoticon;
                case "qr_file": return this.qr_file;
                case "screen_mode": return this.screen_mode;
                case "friendlyname": return this.friendlyname;
                case "code": return this.code;
                case "icon": return this.icon;
                case "culprit": return this.culprit;
                case "ecode1": return this.ecodes[0];
                case "ecode2": return this.ecodes[1];
                case "ecode3": return this.ecodes[2];
                case "ecode4": return this.ecodes[3];
                default:
                    if (this.titles.ContainsKey(name))
                    {
                        return titles[name];
                    }
                    else if (this.texts.ContainsKey(name))
                    {
                        return texts[name];
                    }
                    else
                    {
                        return "";
                    }
            }
        }

        public void ClearAllTitleTexts()
        {
            this.titles.Clear();
            this.texts.Clear();
        }
        public void SetString(string name, string value)
        {
            switch (name)
            {
                case "emoticon": this.emoticon = value; break;
                case "qr_file": this.qr_file = value; break;
                case "screen_mode": this.screen_mode = value; break;
                case "culprit": this.culprit = value; break;
                case "friendlyname": this.friendlyname = value; break;
                case "icon": this.icon = value; break;
                case "code": this.code = value; break;
            }
        }

        public void SetTitle(string name, string value)
        {
            this.titles[name] = value;
        }

        public void PushTitle(string name, string value)
        {
            this.titles.Add(name, value);
        }

        private void PopTitle()
        {
            this.titles.Remove(this.titles.Keys.Last());
        }

        public void SetText(string name, string value)
        {
            this.texts[name] = value;
        }

        public void PushText(string name, string value)
        {
            this.texts.Add(name, value);
        }

        private void PopText()
        {
            this.texts.Remove(this.titles.Keys.Last());
        }

        // theming
        public Color GetTheme(bool bg, bool highlight = false)
        {
            if (highlight)
            {
                if (bg) { return this.highlight_bg; } else { return this.highlight_fg; }
            }
            if (bg) { return this.background; } else { return this.foreground; }
        }

        public void SetTheme(Color bg, Color fg, bool highlight = false)
        {
            if (highlight)
            {
                this.highlight_bg = bg;
                this.highlight_fg = fg;
                return;
            }
            this.background = bg;
            this.foreground = fg;
        }

        // error codes
        public string[] GetCodes()
        {
            return this.ecodes;
        }
        public void SetCodes(string code1, string code2, string code3, string code4)
        {
            string[] code_temp = { code1, code2, code3, code4 };
            this.ecodes = code_temp;
        }

        private Color RGB(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }

        // integers
        public int GetInt(string name)
        {
            switch (name)
            {
                case "blink_speed": return this.blink_speed;
                case "timer": return this.timer;
                case "qr_size": return this.qr_size;
                default: return 0;
            }
        }
        public void SetInt(string name, int value)
        {
            switch (name)
            {
                case "blink_speed": this.blink_speed = value; break;
                case "timer": this.timer = value; break;
                case "qr_size": this.qr_size = value; break;
            }
        }

        public void SetFont(string font_family, float emsize, FontStyle style)
        {
            this.font = new Font(font_family, emsize, style);
        }

        public Font GetFont()
        {
            return this.font;
        }

        public IDictionary<string, string> GetTitles()
        {
            return this.titles;
        }

        public IDictionary<string, string> GetTexts()
        {
            return this.texts;
        }



        // default hacks for specific OS
        public void SetOSSpecificDefaults()
        {
            switch (this.os)
            {
                case "Windows 3.1x":
                    SetTheme(RGB(0, 0, 170), RGB(255, 255, 255));
                    SetTheme(RGB(170, 170, 170), RGB(0, 0, 170), true);
                    SetInt("blink_speed", 100);
                    PushTitle("Main", "Windows");
                    PushText("No unresponsive programs", "Altough you can use CTRL+ALT+DEL to quit an application that has\r\nstopped responding to the system, there is no application in this\r\nstate.\r\nTo quit an application, use the application's quit or exit command,\r\nor choose the Close command from the Control menu.\r\n* Press any key to return to Windows\r\n* Press CTRL + ALT + DEL again to restart your computer.You will\r\nlose any unsaved information in all applications.");
                    PushText("Prompt", "Press any key to continue");
                    SetString("friendlyname", "Windows 3.1 (EGA text mode, Standard)");
                    this.font_support = false;
                    this.blinkblink = true;
                    break;
                case "Windows 9x/Me":
                    SetTheme(RGB(0, 0, 170), RGB(255, 255, 255));
                    SetTheme(RGB(170, 170, 170), RGB(0, 0, 170), true);
                    SetInt("blink_speed", 100);
                    PushTitle("Main", "Windows");
                    PushTitle("System is busy", "System is busy. ");
                    PushTitle("Warning", "WARNING!");
                    PushText("System error", "An error has occurred. To continue:\r\n\r\nPress Enter to return to Windows, or\r\n\r\nPress CTRL + ALT + DEL to restart your computer. If you do this,\r\nyou will lose any unsaved information in all open applications.\r\n\r\nError: {0}");
                    PushText("Application error", "A fatal exception 0E has occurred at {0}:{1}. The current\r\napplication will be terminated.\r\n\r\n* Press any key to terminate current application\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in all applications.");
                    PushText("Driver error", "A fatal exception 0E has occurred at {0}:{1} in VXD VMM(01) +\r\n{2}. The current application will be terminated.\r\n\r\n* Press any key to terminate current application\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in all applications.");
                    PushText("System is busy", "The system is busy waiting for the Close Program dialog box to be\r\ndisplayed. You can wait and see if it appears, or you can restart\r\nyour computer.\r\n\r\n* Press any key to return to Windows and wait.\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in programs that are running.");
                    PushText("System is unresponsive", "The system is either busy or has become unstable. You can wait and\r\nsee if it becomes available again, or you can restart your computer.\r\n\r\n* Press any key to return to Windows and wait.\r\n* Press CTRL + ALT + DEL again to restart your computer. You will\r\n  lose any unsaved information in programs that are running.");
                    PushText("Prompt", "Press any key to continue");
                    SetString("friendlyname", "Windows 9x/Millennium Edition (EGA text mode, Standard)");
                    this.font_support = false;
                    this.blinkblink = true;
                    break;
                case "Windows CE":
                    this.icon = "3D flag";
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));
                    PushText("A problem has occurred...", "A problem has occurred and Windows CE has been shut down to prevent damage to your\r\ncomputer.");
                    PushText("CTRL+ALT+DEL message", "If you will try to restart your computer, press Ctrl+Alt+Delete.");
                    PushText("Technical information", "Technical information:");
                    PushText("Technical information formatting", "*** STOP: {0} ({1})");
                    PushText("Restart message", "The computer will restart automatically\r\nafter {0} seconds.");
                    SetInt("timer", 30);
                    SetFont("Lucida Console", 10.4f, FontStyle.Regular);
                    SetString("friendlyname", "Windows CE 3.0 and later (750x400, Standard)");
                    break;
                case "Windows NT 3.x/4.0":
                    this.icon = "2D flag";
                    SetTheme(RGB(0, 0, 160), RGB(170, 170, 170));
                    PushText("Error code formatting", "*** STOP: {0} ({1})");
                    PushText("CPUID formatting", "CPUID: {0} 6.3.3 irql:lf SYSVER 0xf0000565");
                    PushText("Stack trace heading", "Dll Base DateStmp - Name");
                    PushText("Stack trace table formatting", "{0} {1} - {2}");
                    PushText("Memory address dump heading", "Address  dword dump   Build [1381]                            - Name");

                    PushText("Memory address dump table", "{0} {1} {2} {3} {4} {5}           - {6}");
                    PushText("Troubleshooting text", "Restart and set the recovery options in the system control panel\r\nor the /CRASHDEBUG system start option.");
                    SetInt("blink_speed", 100);
                    SetString("friendlyname", "Windows NT 4.0/3.x (VGA text mode, Standard)");
                    this.font_support = false;
                    this.blinkblink = true;
                    break;
                case "Windows 2000":
                    PushText("Error code formatting", "*** STOP: {0} ({1})");
                    PushText("Troubleshooting introduction", "If this is the first time you've seen this Stop error screen,\r\nrestart your computer. If this screen appears again, follow\r\nthese steps: ");
                    PushText("Troubleshooting text", "Check for viruses on your computer. Remove any newly installed\r\nhard drives or hard drive controllers. Check your hard drive\r\nto make sure it is properly configured and terminated.\r\nRun CHKDSK / F to check for hard drive corruption, and then\r\nrestart your computer.");
                    PushText("Additional troubleshooting information", "Refer to your Getting Started manual for more information on\r\ntroubleshooting Stop errors.");
                    SetFont("Lucida Console", 8.0f, FontStyle.Bold);
                    SetString("friendlyname", "Windows 2000 Professional/Server Family (640x480, Standard)");
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));
                    break;
                case "Windows XP":
                    this.icon = "3D flag";
                    PushText("A problem has been detected...", "A problem has been detected and Windows has been shut down to prevent damage\r\nto your computer.");
                    PushText("Troubleshooting introduction", "If this is the first time you've seen this Stop error screen,\r\nrestart your computer.If this screen appears again, follow\r\nthese steps:");
                    PushText("Troubleshooting", "Check to make sure any new hardware or software is properly installed.\r\nIf this is a new installation, ask your hardware or software manufacturer\r\nfor any Windows updates you might need.\r\n\r\nIf problems continue, disable or remove any newly installed hardware\r\nor software.Disable BIOS memory options such as caching or shadowing.\r\nIf you need to use Safe mode to remove or disable components, restart\r\nyour computer, press F8 to select Advanced Startup Options, and then\r\nselect Safe Mode.");
                    PushText("Technical information", "Technical information:");
                    PushText("Technical information formatting", "*** STOP: {0} ({1})");
                    PushText("Physical memory dump", "Beginning dump of physical memory\r\nPhysical memory dump complete.");
                    PushText("Technical support", "Contact your system administrator or technical support group for further\r\nassistance.");
                    SetFont("Lucida Console", 10.4f, FontStyle.Regular);
                    SetString("friendlyname", "Windows XP (640x480, Standard)");
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));
                    break;
                case "Windows Vista/7":
                    this.icon = "3D flag";
                    PushText("A problem has been detected...", "A problem has been detected and Windows has been shut down to prevent damage\r\nto your computer.");
                    PushText("Troubleshooting introduction", "If this is the first time you've seen this Stop error screen,\r\nrestart your computer. If this screen appears again, follow\r\nthese steps:");
                    PushText("Troubleshooting", "Check to make sure any new hardware or software is properly installed.\r\nIf this is a new installation, ask your hardware or software manufacturer\r\nfor any Windows updates you might need.\r\n\r\nIf problems continue, disable or remove any newly installed hardware\r\nor software.Disable BIOS memory options such as caching or shadowing.\r\nIf you need to use Safe mode to remove or disable components, restart\r\nyour computer, press F8 to select Advanced Startup Options, and then\r\nselect Safe Mode.");
                    PushText("Technical information", "Technical information:");
                    PushText("Technical information formatting", "*** STOP: {0} ({1})");
                    PushText("Physical memory dump", "Dumping physical memory to disk:{0}");
                    PushText("Technical support", "Contact your system admin or technical support group for further assistance.");
                    SetFont("Consolas", 9.4f, FontStyle.Regular);
                    SetString("friendlyname", "Windows Vista/7 (640x480, ClearType)");
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));
                    break;
                case "Windows 8/8.1":
                    this.icon = "3D window";
                    PushText("Information text with dump", "Your PC ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then you can restart. ({0}%\r\n complete)");
                    PushText("Information text without dump", "Your PC ran into a problem that it couldn't\r\nhandle and now it needs to restart.");
                    PushText("Error code", "You can search for the error online: {0}");
                    SetFont("Segoe UI", 19.4f, FontStyle.Regular);
                    SetTheme(RGB(16, 113, 170), RGB(255, 255, 255));
                    SetString("friendlyname", "Windows 8/8.1 (Native, ClearType)");
                    break;
                case "Windows 10":
                    this.icon = "3D window";
                    PushText("Information text with dump", "Your PC ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then we'll restart for you.");
                    PushText("Information text without dump", "Your PC ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then you can restart.");
                    PushText("Additional information", "For more information about this issue and possible fixes, visit http://windows.com/stopcode");
                    PushText("Culprit file", "What failed: {0}");
                    PushText("Error code", "If you call a support person, give them this info:\r\n\r\nStop code: {0}");
                    PushText("Progress", "{0}% complete");
                    SetInt("qr_size", 110);
                    SetString("qr_file", "local:0");
                    SetFont("Segoe UI", 19.4f, FontStyle.Regular);
                    SetTheme(RGB(16, 113, 170), RGB(255, 255, 255));
                    SetString("friendlyname", "Windows 10 (Native, ClearType)");
                    this.winxplus = true;
                    break;
                case "Windows 11":
                    this.icon = "2D window";
                    PushText("Information text with dump", "Your PC ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then we'll restart for you.");
                    PushText("Information text without dump", "Your PC ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then you can restart.");
                    PushText("Additional information", "For more information about this issue and possible fixes, visit http://windows.com/stopcode");
                    PushText("Culprit file", "What failed: {0}");
                    PushText("Error code", "If you call a support person, give them this info:\r\n\r\nStop code: {0}");
                    PushText("Progress", "{0}% complete");
                    SetInt("qr_size", 110);
                    SetString("qr_file", "local:0");
                    SetFont("Segoe UI", 19.4f, FontStyle.Regular);
                    SetTheme(RGB(0, 0, 0), RGB(255, 255, 255));
                    SetString("friendlyname", "Windows 11 (Native, ClearType)");
                    this.winxplus = true;
                    break;
            }
        }
    }
}