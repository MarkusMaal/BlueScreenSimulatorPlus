/*
 * Blue screen simulator plus
 * Codename: BlueSmith
 * 
 * Version 1.01
 *
 * {} markus' software // {} markuse tarkvara
 * 
 *         /
 *        / 
 * +-----/  This program uses Verifile - 
 * \    /|  Signature verification technology
 * |\  / |
 * +-\/--+
 * 
 * The following section contains quick documentation for each file in the project.
 * 
 * Directory
 *      File name                        - Description
 * 
 * *ROOT*
 *      AboutBox1.cs                     - Help, about and settings
 *      bsodhacks.cs                     - Bluescreen hacks (old beta) [*Unused*]
 *      cebsod.cs                        - Windows CE blue screen simulator
 *      ClickIt.cs                       - Classic Click it game easter egg (enable easter eggs in settings)
 *      ClickIt2.cs                      - Click it 2.0 easter egg (trigger classic and click Play 2.0)
 *      Form1.cs                         - Main interface
 *      IndexForm.cs                     - Code customization interface
 *      NTBSOD.cs                        - Windows NT blue screen simulator
 *      old_bluescreen.cs                - Windows 3.1x/9x/Me blue screen simulator
 *      PrankMode.cs                     - Prank mode interface
 *      Splash.cs                        - Splash screen interface
 *      StringEdit.cs                    - Blue screen hacks (new)
 *      SupportEditor.cs                 - Windows XP/Vista/7 blue screen support text modification interface (old beta)
 *      UpdateInterface.cs               - Interface for update download and installation
 *      w2kbs.cs                         - Windows 2000 blue screen simulator
 *      WindowScreen.cs                  - This form is displayed when fullscreen flag is set on non-modern blue screens
 *      WXBS.cs                          - Modern Windows blue screen simulator
 *      xvsbs.cs                         - Windows XP/Vista/7 blue screen simulator
 *      *.Designer.cs                    - Form interface designs (generated using Visual Studio's designer)
 *      *.resx                           - Resource identification (auto-generated)
 *      app.config                       - Application configuration [*Unused*]
 *      bsodgen_npJ_icon.ico             - Blue screen simulator plus icon
 *      Program.cs                       - Program initialization code
 * 
 * bin\Release
 *      default.bscfg                    - Default blue screen hack configuration file
 *      final.bat                        - Update finalization script
 *      UltimateBlueScreenSimulator.exe  - Compiled executable
 *      UltimateBlueScreenSimulator.pdb  - Program debug database (contains essential things for debugging purposes, such as variable names, break points, etc)
 * 
 * Resources
 *      bsodbanner.png                   - Banner for about dialog
 *      bsodqr.bmp                       - QR code for Widnows 10 blue screen
 *      bsodqr_transparent.png           - Transparent QR code for Windows 10 blue screen
 *      current.gif                      - Symbol for currently processing step in update interface
 *      current1.gif                     - Same as current.gif [*Unused*]
 *      failure.gif                      - Symbol for failed step in update interface
 *      msoftware.png                    - Markus' software logo for about dialog
 *      NTERRORDATABASE.txt              - Contains all Windows NT error codes with their descriptions (code   description)
 *      pending.gif                      - Symbol for pending step in update interface
 *      rasterNT.bmp                     - Windows NT blue screen character set
 *      rasters.bmp                      - Old character set for old blue screens [*Unused*]
 *      rasters2.bmp                     - CGA character set for old blue screens
 *      success.bmp                      - Symbol for successfully complited step in update interface
 *      verifile.bmp                     - Verifile logo for about dialog
 * 
 * Properties
 *      AssemblyInfo.cs                  - Assembly information for the application (e.g. title, company, version, etc) (auto-generated)
 *      Resources.resx                   - Resource identification (auto-generated)
 *      Settings.settings                - Settings [*Unused*] (auto-generated)
 */

using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //Form creation
        public static StringEdit bh;
        public static Form1 f1;
        public static Splash spl;

        private static bool bad = false;

        //Command line syntax
        public static string cmds = "/? - Displays command line syntax\n/wv:xx - Set the specific Windows version (3.1/9x/CE/Millennium/2000/XP/NT/Vista/7/8/8.1/10)\n/h - Doesn't show main GUI. If no simulation is started or the simulation is finished, the program will close.\n/hwm - Hides watermark\n/c - Simulates a system crash\n/hackfile:xx - Loads a hack file (xx is the file name)\n\n/ntc:xx - Specific NT error code to display. Replace xx with the actual code\n/9xc:xx - Specific 9x/Me message to display (system/application/driver/busy/unresponsive)\n/ddesc - Disables error descriptions\n/dqr - Disables QR code on Windows 10 blue screen\n/srv - Displays Windows Server 2016 blue screen when wv is set to 10\n/dac - Disables autoclose feature (Modern blue screens only)\n/gs - Displays green screen when wv is set to 10\n/ap - Displays ACPI blue screen (Windows Vista/7 only)\n/file:xx - Displays the potential culprit file (replace xx with the actual file name)\n/amd - Displays \"AuthenticAMD\" instead of \"GenuineIntel\" on Windows NT blue screen\n/blink - Shows a blinking cursor (NT blue screen)\n/dstack - Does not display stack trace (NT blue screen)\n/win - Enables windowed mode\n/random - Randomizes the blue screen (does NOT randomize any custom attributes set)\n\n/desc - Forcibly enable error description\n/ac - Forcibly enable autoclose feature\n/dap - Forcibly disable ACPI error screen (Windows Vista/7)\n/damd - Forcibly display \"GenuineIntel\" on Windows NT blue screen\n/dblink - Forcibly disable blinking cursor on Windows NT blue screen\n/dgs - Forcibly disable green screen on Windows 10 blue screen\n/qr - Forcibly enable QR code on Windows 10 blue screen\n/dsrv - Forcibly disable server blue screen when version is set to Windows 10\n/stack - Forcible enable stack trace on Windows NT blue screen\n/dfile - Forcible disables potential culprit file\n\n/code:xxxxxxxxxxxxxxxx,xxxxxxxxxxxxxxxx,xxxxxxxxxxxxxxxx,xxxxxxxxxxxxxxxx - Method for displaying error codes (0 - null, R - random, 1-F - static)\n/clr - Clears the verification certificate from this computer, causing the first use message to pop up.\n/hidesplash - Hides the splash screen";

        internal static bool verificate = false;
        public static bool hidden = false;
        private static ManagementObjectSearcher aa = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        public static List<BlueScreen> bluescreens;

        [STAThread]
        public static void Main(string[] args)
        {
            //Application initialization
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //If hidesplash flag is not set, display the splash screen
            if (!args.Contains("/hidesplash"))
            {
                if (!args.Contains("/finalize_update"))
                {
                    hidden = true;
                    spl = new Splash();
                    spl.ShowDialog();
                }
                else
                {
                    verificate = Verikey(args);
                }
            }
            else
            {
                verificate = Verikey(args);
            }
            if (bad) { return; }
            if (!verificate) { return; }

            //Clear verification certificate if clr flag is set
            if (args.Contains("/clr"))
            {
                if (!args.Contains("/hidesplash"))
                {
                    if (!args.Contains("/finalize_update"))
                    {
                        spl.Close();
                    }
                }
                File.Delete(Environment.GetEnvironmentVariable("USERPROFILE") + @"\bssp_firstlaunch.txt");
                MessageBox.Show("Signature verification file deleted. The program will now close.", "Ultimate blue screen simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Initialize forms
            f1 = new Form1();
            bh = new StringEdit();
            bluescreens = new List<BlueScreen>();

            //Load application configuration if it exists
            if (File.Exists("settings.cfg"))
            {
                try
                {
                    string[] fc = File.ReadAllText("settings.cfg").Split('\n');
                    string[] comboitems = File.ReadAllText("settings.cfg").Split('\"')[1].Split('\n');
                    //This part hides specified operating systems
                    bool show1 = false;
                    bool show2 = false;
                    bool show3 = false;
                    bool show4 = false;
                    bool show5 = false;
                    bool show6 = false;
                    bool show7 = false;
                    bool show8 = false;
                    bool show9 = false;
                    if (comboitems.Contains("Windows 10 (Native, Safe mode: 640x480, ClearType)")) { show1 = true; }
                    if (comboitems.Contains("Windows 8/8.1 (Native, Safe mode: 640x480, ClearType)")) { show2 = true; }
                    if (comboitems.Contains("Windows Vista/7 (640x480, ClearType)")) { show3 = true; }
                    if (comboitems.Contains("Windows XP (640x480, Standard)")) { show4 = true; }
                    if (comboitems.Contains("Windows 2000 Professional/Server Family (640x480, Standard)")) { show5 = true; }
                    if (comboitems.Contains("Windows 9x/Millennium Edition (EGA text mode, Standard)")) { show6 = true; }
                    if (comboitems.Contains("Windows CE 3.0 and later (750x400, Standard)")) { show7 = true; }
                    if (comboitems.Contains("Windows NT 4.0/3.x (VGA text mode, Standard)")) { show8 = true; }
                    if (comboitems.Contains("Windows 3.1 (EGA text mode, Standard)")) { show9 = true; }
                    bool[] shows = { show1, show2, show3, show4, show5, show6, show7, show8, show9, true };
                    f1.osshows = shows;
                    foreach (string element in fc)
                    {
                        //Other configurations
                        if (element.StartsWith("UpdateClose="))
                        {
                            f1.postponeupdate = Convert.ToBoolean(element.Replace("UpdateClose=", ""));
                        }
                        else if (element.StartsWith("HashVerify="))
                        {
                            f1.hashverify = Convert.ToBoolean(element.Replace("HashVerify=", ""));
                        }
                        else if (element.StartsWith("AutoUpdate="))
                        {
                            f1.autoupdate = Convert.ToBoolean(element.Replace("AutoUpdate=", ""));
                        }
                        else if (element.StartsWith("ShowCursor="))
                        {
                            f1.showcursor = Convert.ToBoolean(element.Replace("ShowCursor=", ""));
                        }
                        else if (element.StartsWith("Seecrets="))
                        {
                            f1.enableeggs = Convert.ToBoolean(element.Replace("Seecrets=", ""));
                        }
                        else if (element.StartsWith("ScaleMode="))
                        {
                            f1.GMode = element.Replace("ScaleMode=", "");
                        }
                    }
                }
                catch
                {
                    //Configuration seems to be corrupted, if this part is executed...
                }
            }
            //Load default settings on bluescreen hacks dialog
            bh.ReRe();

            //Load Windows NT error codes from the database
            f1.comboBox1.Items.Clear();
            string database = "";
            try
            {
                database = Properties.Resources.NTERRORDATABASE;
            }
            catch
            {
                f1.error = 19;
            }
            try
            {
                string[] databaselines = database.Split('\n');
                foreach (string element in databaselines)
                {
                    string[] codesplit = element.Split('\t');
                    string final = codesplit[1].ToString().Substring(0, codesplit[1].ToString().Length - 1) + " (" + codesplit[0].ToString() + ")";
                    f1.comboBox1.Items.Add(final);
                }
            }
            catch
            {
                f1.error = 20;
            }
            //Set default selection indexes for combo boxes
            f1.comboBox1.SelectedIndex = 9;
            f1.windowVersion.SelectedIndex = 0;
            f1.comboBox2.SelectedIndex = 0;
            //Post update scripts
            if (args.Contains("/doneupdate"))
            {
                System.IO.File.Delete("BSSP.exe");
            }
            if (args.Contains("/finalize_update"))
            {
                UpdateInterface ui = new UpdateInterface
                {
                    finalize = true
                };
                Application.Run(ui);
            }
            //Generate random blue screen when /random flag is set
            if (args.Contains("/random")) { f1.RandFunction(); }
            //Hide watermark if hwm flag is set
            if (args.Contains("/hvm")) { f1.waterBox.Checked = false; }
            //Simulate crash if /c flag is set
            if (args.Contains("/c"))
            {
                f1.timer1.Enabled = true;
            }
            bool done = false;
            foreach (string argument in args)
            {
                //check argument syntax
                if (!argument.StartsWith("/"))
                {
                    f1.error = 23;
                    break;
                }
                //select Windows version using /wv argument
                if (argument.Contains("/wv"))
                {
                    string ecode = argument.Split(':')[1];
                    if (ecode == "")
                    {
                        f1.error = 15;
                    }
                    for (int i = 0; i < f1.windowVersion.Items.Count; i++)
                    {
                        if (f1.windowVersion.Items[i].ToString().ToLower().Contains(ecode.ToLower()))
                        {
                            //f1.windowVersion.SelectedIndex = i;
                            f1.specificos = f1.windowVersion.Items[i].ToString();
                            done = true;
                        }
                    }
                    if (!done)
                    {
                        f1.error = 12;
                    }
                }
                //this code loads hack file if specified in arguments
                else if (argument.Contains("/hackfile:"))
                {
                    string filename = argument.Split(':')[1];
                    if (File.Exists(filename))
                    { 
                        if (filename != "") { /*bh.LoadHack(filename);*/ }
                    } else
                    {
                        f1.error = 24;
                    }
                }
                //this code sets error code mode if specified in arguments
                else if (argument.Contains("/code:"))
                {
                    string[] codes = argument.Split(':')[1].Split(',');
                    f1.c1 = codes[0].ToUpper();
                    f1.c2 = codes[1].ToUpper();
                    f1.c3 = codes[2].ToUpper();
                    f1.c4 = codes[3].ToUpper();
                }
            }
            //sets other optional flags
            if (args.Contains("/ddesc")) { f1.checkBox1.Checked = false; }
            if (args.Contains("/desc")) { f1.checkBox1.Checked = true; }
            if (args.Contains("/dac")) { f1.autoBox.Checked = false; }
            if (args.Contains("/ac")) { f1.autoBox.Checked = true; }
            if (args.Contains("/ap")) { f1.acpiBox.Checked = true; }
            if (args.Contains("/dap")) { f1.acpiBox.Checked = false; }
            if (args.Contains("/amd")) { f1.amdBox.Checked = true; }
            if (args.Contains("/damd")) { f1.amdBox.Checked = false; }
            if (args.Contains("/blink")) { f1.blinkBox.Checked = true; }
            if (args.Contains("/dblink")) { f1.blinkBox.Checked = false; }
            if (args.Contains("/gs")) { f1.greenBox.Checked = true; }
            if (args.Contains("/dgs")) { f1.greenBox.Checked = false; }
            if (args.Contains("/qr")) { f1.qrBox.Checked = true; }
            if (args.Contains("/dqr")) { f1.qrBox.Checked = false; }
            if (args.Contains("/srv")) { f1.serverBox.Checked = true; }
            if (args.Contains("/dsrv")) { f1.serverBox.Checked = false; }
            if (args.Contains("/stack")) { f1.stackBox.Checked = true; }
            if (args.Contains("/dstack")) { f1.stackBox.Checked = false; }
            if (args.Contains("/win")) { f1.winMode.Checked = true; }
            if (args.Contains("/dfile")) { f1.textBox2.Text = ""; f1.checkBox2.Checked = false; }
            //displays help
            if (args.Contains("/?"))
            {
                MessageBox.Show(cmds, "Command line argument usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                f1.error = 999;
            }
            //displays errror cuplrit file if specified in arguments
            foreach (string argument in args)
            {
                if (argument.StartsWith("/file:"))
                {
                    f1.checkBox2.Checked = true;
                    string ecode = argument.Split(':')[1].ToString();
                    if (ecode == "")
                    {
                        f1.error = 16;
                    }
                    f1.textBox2.Text = ecode;
                }
            }
            //set NT error code if specified in arguments
            foreach (string argument in args)
            {
                if (argument.StartsWith("/ntc:"))
                {
                    string ecode = argument.Split(':')[1];
                    if (ecode == "")
                    {
                        f1.error = 17;
                    }
                    bool finished = false;
                    for (int i = 0; i < f1.comboBox1.Items.Count; i++)
                    {
                        if (f1.comboBox1.Items[i].ToString().ToLower().Contains(ecode.ToLower()))
                        {
                            f1.comboBox1.SelectedIndex = i;
                            finished = true;
                        }
                    }
                    if (!finished)
                    {
                        f1.error = 13;
                    }
                }
            }
            //set 9x error type if specified in arguments
            foreach (string argument in args)
            {
                if (argument.StartsWith("/9xc:"))
                {
                    string ecode = argument.Split(':')[1];
                    if (ecode == "")
                    {
                        f1.error = 18;
                    }
                    bool finished = false;
                    for (int i = 0; i < f1.comboBox2.Items.Count; i++)
                    {
                        if (f1.comboBox2.Items[i].ToString().ToLower().Contains(ecode.ToLower()))
                        {
                            f1.comboBox2.SelectedIndex = i;
                        }
                    }
                    if (!finished)
                    {
                        f1.error = 14;
                    }
                }
            }
            //hide main interface if /h flag is set
            if (args.Contains("/h"))
            {
                f1.WindowState = FormWindowState.Minimized;
                f1.ShowInTaskbar = false;
                f1.ShowIcon = false;
                f1.closecuzhidden = true;
                if (!args.Contains("/c"))
                {
                    f1.error = 1;
                }
            }
            if (args.Contains("/hwm")) { f1.waterBox.Checked = false; }

            //run application
            Application.Run(f1);
  
        }

        /// <summary>
        /// Computer verification system
        /// </summary>
        /// <param name="args">key array</param>
        /// <returns>boolean</returns>
        //undocumented code
        internal static bool Verikey(string[] args)
        {

            bool verifi = true;
            if (!File.Exists(Environment.GetEnvironmentVariable("USERPROFILE") + @"\bssp_firstlaunch.txt")) { verifi = false; }
            if (verifi == true)
            {
                if (Program.Verifile() != File.ReadAllText(Environment.GetEnvironmentVariable("USERPROFILE") + @"\bssp_firstlaunch.txt"))
                {
                    if (args.Contains("/c") && args.Contains("/hwm"))
                    {
                        MessageBox.Show("A malicious program or script tried to potentially fool you into thinking that your system crashed. Due to signature verification failure, this program has to close.\n\n\nWhat should I do?\n\nIf you did not download the Bluescreen simulator plus yourself, please scan your computer for potential viruses or malware\nIf you DID download blue screen simulator plus, then the problem is most likely caused by a recent hardware change, which can invalidate the signature. To recreate the signature, run following commands in command prompt:\ncd \"" + AppDomain.CurrentDomain.BaseDirectory + "\"\nUltimateBlueScreenSimulator.exe /clr\n\nAfter that, you should be able to relaunch the program after clicking \"OK\".", "Ultimate blue screen simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    bad = true;
                    return false;
                }
            }
            if (!verifi)
            {
                if (MessageBox.Show("It looks like you are using this program for the very first time. If you did not start this program, dont worry. This program is not malicious, but you should click \"No\" below and scan your computer for viruses/malicious programs.\n\n\nThis program can only be used for non-harmful purposes, such as:\n\n* Screenshotting blue screens from different operating systems (for use in a video, article, etc)\n* Non-harmful pranking purposes (ie pranking a friend, relative, etc)\n* Having fun tweaking different blue screens\n* Learning about different blue screens from different operating systems\n* Other testing or reviewing purposes\n\n\nBy clicking or selecting \"Yes\" you accept that you DO NOT use this program maliciously (ie as a part of a malicious program, a way of sacrificing productivity, etc). A verification signature will be created preventing this message from popping up in this computer. \n\nIf you click or select \"No\" then the program will close. The popup will reappear once you relaunch the program from this computer and user account.", "Welcome to Blue screen simulator plus", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return verifi;
                }
                else
                {
                    WriteFile();
                }
            }
            return verifi;
        }
        internal static string Verifile()
        {
            string verificatable = Q();
            return verificatable;
        }

        internal static void WriteFile()
        {
            string verificatable = Q();
            if (verificatable == "error")
            {
                return;
            }
            else
            { 
                File.WriteAllText(Environment.GetEnvironmentVariable("USERPROFILE") + "\\bssp_firstlaunch.txt", verificatable, Encoding.ASCII);
            }

        }
        static string Q()
        {
            string gg = "CPI" + Ff();
            bool maspc = true;
            try
            { 
                if (!Directory.Exists(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas"))
                {
                    maspc = false;
                    Directory.CreateDirectory(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas");
                    File.WriteAllText(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\edition.txt", "a");
                }
                string pp = J(Y(System.IO.File.ReadAllText(Environment.GetEnvironmentVariable("HOMEDRIVE").ToString() + "\\mas\\edition.txt")));
                if (!maspc)
                {
                    File.Delete(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas\\edition.txt");
                    Directory.Delete(Environment.GetEnvironmentVariable("HOMEDRIVE") + "\\mas");
                }
                return (H(pp + J(gg.Substring(1, gg.Length - 2) + gg.Substring(0, 1) + gg.Substring(gg.Length - 1, 1))).ToLower() + J(Uu()).ToLower() + J(B)).ToLower();
            } catch
            {
                MessageBox.Show("Unable to write signature information. To remove first use message, please run the application as administrator at least once.", "Verifile technology", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "error";
            }
        }

        static string Y(string s)
        {
            string[] sar = s.Split('\n');
            string ns = "";
            for (int i = 0; i < sar.Length - 3; i++)
            {
                ns += sar[i].ToString() + "\n";
            }
            return ns;
        }
        static string Uu()
        {
            using (ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS"))

            using (ManagementObjectCollection moc = o.Get())

            {

                StringBuilder t = new StringBuilder();
                foreach (ManagementObject mo in moc)

                {

                    string[] BIOSVersions = (string[])mo["BIOSVersion"];
                    foreach (string version in BIOSVersions)
                    {
                        t.AppendLine(string.Format("{0}", version));
                    }

                }
                return t.ToString().Split('\n')[0].ToString();
            }
        }

        public static string Ff()
        {
            string l = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (l == "")
                {
                    try { 
                    l = mo.Properties["processorID"].Value.ToString();
                    } catch
                    {
                        l = "a";
                    }
                    break;
                }
            }
            return l;
        }
        public static string J(string z)
        {
            SHA1 cx = SHA1.Create();
            byte[] xx = Encoding.ASCII.GetBytes(z);
            byte[] hash = cx.ComputeHash(xx);

            StringBuilder t = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                t.Append(hash[i].ToString("X2"));
            }
            return t.ToString();
        }
        public static string H(string z)
        {
            MD5 cx = MD5.Create();
            byte[] xx = Encoding.ASCII.GetBytes(z);
            byte[] hash = cx.ComputeHash(xx);

            StringBuilder t = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                t.Append(hash[i].ToString("X2"));
            }
            return t.ToString();
        }
        static public string B
        {
            get
            {
                try
                {
                    foreach (ManagementObject queryObj in aa.Get())
                    {
                        return queryObj["Product"].ToString();
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}

namespace SimulatorDatabase
{

    // Blue screen template struct
    public class BlueScreen
    {
        // constructor
        private System.Drawing.Color background;
        private System.Drawing.Color foreground;
        private System.Drawing.Color highlight_bg;
        private System.Drawing.Color highlight_fg;

        private string[] ecodes;

        private string code;
        private string emoticon;
        private string screen_mode;
        private string qr_file;

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

        private int blink_speed;
        private int timer;
        private int qr_size;

        private System.Drawing.Font font;

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
            this.background = System.Drawing.Color.FromArgb(0, 0, 0);
            this.foreground = System.Drawing.Color.FromArgb(255, 255, 255);
            this.os = base_os;
            string[] codes_temp = { "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR", "RRRRRRRRRRRRRRRR" };
            this.ecodes = codes_temp;
            this.code = "IRQL_NOT_LESS_OR_EQUAL";
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
            this.highlight_bg = System.Drawing.Color.FromArgb(255, 255, 255);
            this.highlight_fg = System.Drawing.Color.FromArgb(0, 0, 0);
            this.icon = "2D flag";
            this.blink_speed = 100;
            this.titles = new Dictionary<string, string>();
            this.texts = new Dictionary<string, string>();
            this.timer = 30;
            this.font = new System.Drawing.Font("Lucida Console", 10.4f, System.Drawing.FontStyle.Regular);
            this.qr_size = 110;
            this.qr_file = "local:0";
            this.blinkblink = false;
            this.font_support = true;
            this.winxplus = false;
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
            }
        }

        public string GetString(string name)
        {
            switch (name)
            {
                case "os": return this.os;
                case "emoticon": return this.emoticon;
                case "qr_file": return this.qr_file;
                case "screen_mode": return this.screen_mode;
                case "code": return this.code;
                case "icon": return this.icon;
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

        public void SetString(string name, string value)
        {
            switch (name)
            {
                case "emoticon": this.emoticon = value; break;
                case "qr_file": this.qr_file = value; break;
                case "screen_mode": this.screen_mode = value; break;
                case "code": this.code = value; break;
            }
        }

        public void SetTitle(string name, string value)
        {
            this.titles[name] = value;
        }

        private void PushTitle(string name, string value)
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

        private void PushText(string name, string value)
        {
            this.texts.Add(name, value);
        }

        private void PopText()
        {
            this.texts.Remove(this.titles.Keys.Last());
        }

        // theming
        public System.Drawing.Color GetTheme(bool bg, bool highlight = false)
        {
            if (highlight)
            {
                if (bg) { return this.highlight_bg; } else { return this.highlight_fg; }
            }
            if (bg) { return this.background; } else { return this.foreground; }
        }

        public void SetTheme(System.Drawing.Color bg, System.Drawing.Color fg, bool highlight = false)
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

        private System.Drawing.Color RGB(int r, int g, int b)
        {
            return System.Drawing.Color.FromArgb(r, g, b);
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

        public void SetFont(string font_family, float emsize, System.Drawing.FontStyle style)
        {
            this.font = new System.Drawing.Font(font_family, emsize, style);
        }

        public System.Drawing.Font GetFont()
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
                    SetFont("Lucida Console", 10.4f, System.Drawing.FontStyle.Regular);
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
                    this.font_support = false;
                    this.blinkblink = true;
                    break;
                case "Windows 2000":
                    PushText("Error code formatting", "*** STOP: {0} ({1})");
                    PushText("Troubleshooting introduction", "If this is the first time you've seen this Stop error screen,\r\nrestart your computer.If this screen appears again, follow\r\nthese steps: ");
                    PushText("Troubleshooting text", "Check for viruses on your computer. Remove any newly installed\r\nhard drives or hard drive controllers.Check your hard drive\r\nto make sure it is properly configured and terminated.\r\nRun CHKDSK / F to check for hard drive corruption, and then\r\n restart your computer.");
                    PushText("Additional troubleshooting information", "Refer to your Getting Started manual for more information on\r\ntroubleshooting Stop errors.");
                    SetFont("Lucida Console", 8.0f, System.Drawing.FontStyle.Bold);
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
                    SetFont("Lucida Console", 10.4f, System.Drawing.FontStyle.Regular);
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));
                    break;
                case "Windows Vista/7":
                    this.icon = "3D flag";
                    PushText("A problem has been detected...", "A problem has been detected and Windows has been shut down to prevent damage\r\nto your computer.");
                    PushText("Troubleshooting introduction", "If this is the first time you've seen this Stop error screen,\r\nrestart your computer.If this screen appears again, follow\r\nthese steps:");
                    PushText("Troubleshooting", "Check to make sure any new hardware or software is properly installed.\r\nIf this is a new installation, ask your hardware or software manufacturer\r\nfor any Windows updates you might need.\r\n\r\nIf problems continue, disable or remove any newly installed hardware\r\nor software.Disable BIOS memory options such as caching or shadowing.\r\nIf you need to use Safe mode to remove or disable components, restart\r\nyour computer, press F8 to select Advanced Startup Options, and then\r\nselect Safe Mode.");
                    PushText("Technical information", "Technical information:");
                    PushText("Technical information formatting", "*** STOP: {0} ({1})");
                    PushText("Physical memory dump", "Dumping physical memory to disk:{0}");
                    PushText("Technical support", "Contact your system admin or technical support group for further assistance.");
                    SetFont("Consolas", 9.4f, System.Drawing.FontStyle.Regular);
                    SetTheme(RGB(0, 0, 128), RGB(255, 255, 255));
                    break;
                case "Windows 8/8.1":
                    this.icon = "3D window";
                    PushText("Information text with dump", "Your PC ran into a problem and needs to restart. We're just\r\ncollecting some error info, and then you can restart. ({0}%\r\n complete)");
                    PushText("Information text without dump", "Your PC ran into a problem that it couldn't\r\nhandle and now it needs to restart.");
                    PushText("Error code", "You can search for the error online: {0}");
                    SetFont("Segoe UI", 19.4f, System.Drawing.FontStyle.Regular);
                    SetTheme(RGB(16, 113, 170), RGB(255, 255, 255));
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
                    SetFont("Segoe UI", 19.4f, System.Drawing.FontStyle.Regular);
                    SetTheme(RGB(16, 113, 170), RGB(255, 255, 255));
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
                    SetFont("Segoe UI", 19.4f, System.Drawing.FontStyle.Regular);
                    SetTheme(RGB(0, 0, 0), RGB(255, 255, 255));
                    this.winxplus = true;
                    break;
            }
        }
    }
}