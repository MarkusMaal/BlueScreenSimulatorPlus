/*
 * Blue screen simulator plus
 * Codename: *Waffles*
 * 
 * Version 2.0 (development build)
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
 *      AddBluescreen.cs                 - Allows the user to create their own bluescreen configuration
 *      BootMgr.cs                       - Windows Boot Manager startup error simulator (Beta)
 *      bsodhacks.cs                     - Bluescreen hacks (old beta) [*Unused*]
 *      cebsod.cs                        - Windows CE blue screen simulator
 *      ChooseFile.cs                    - Culprit file chooser
 *      ClickIt.cs                       - Classic Click it game easter egg (enable easter eggs in settings)
 *      ClickIt2.cs                      - Click it 2.0 easter egg (trigger classic and click Play 2.0)
 *      DictEdit.cs                      - [DEVTOOL] Dictionary Editor
 *      Form1.cs                         - Main interface
 *      Gen.cs                           - This form is displayed when generating a blue screen
 *      IndexForm.cs                     - Code customization interface
 *      NTBSOD.cs                        - Windows NT blue screen simulator
 *      old_bluescreen.cs                - Windows 3.1x/9x/Me blue screen simulator
 *      PrankMode.cs                     - Prank mode interface
 *      SimulatorDatabase.cs             - A namespace with a blue screen class, which gets used by other parts of the program
 *      Splash.cs                        - Splash screen interface
 *      StringEdit.cs                    - Blue screen hacks (new)
 *      SupportEditor.cs                 - Windows XP/Vista/7 blue screen support text modification interface (old beta)
 *      UpdateInterface.cs               - Interface for update download and installation
 *      w2kbs.cs                         - Windows 2000 blue screen simulator
 *      win.cs                           - Windows 1.x/2.x blue screen simulator
 *      WindowScreen.cs                  - This form is displayed when fullscreen flag is set on non-modern blue screens
 *      WXBS.cs                          - Modern Windows blue screen simulator
 *      Vistabs.cs                       - Windows Vista/7 blue screen simulator
 *      xvsbs.cs                         - Windows XP blue screen simulator
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
 *      CULPRIT_FILES.txt                - Contains culprit files, which the user can choose to display on the error screen
 *      current.gif                      - Symbol for currently processing step in update interface
 *      current1.gif                     - Same as current.gif [*Unused*]
 *      doscii.png                       - Character set used by Windows 1.x/2.x blue screen simulator
 *      dummy.png                        - Dummy image for Windows 1.x/2.x blue screen simulator
 *      failure.gif                      - Symbol for failed step in update interface
 *      msoftware.png                    - Markus' software logo for about dialog
 *      NTERRORDATABASE.txt              - Contains all Windows NT error codes with their descriptions (code   description)
 *      pending.gif                      - Symbol for pending step in update interface
 *      rasterNT.bmp                     - Windows NT blue screen character set
 *      rasters.bmp                      - Old character set for old blue screens [*Unused*]
 *      rasters2.bmp                     - CGA character set for old blue screens
 *      round_corners.png                - Round corners that get displayed on the new splash screen
 *      success.bmp                      - Symbol for successfully complited step in update interface
 *      untitled.wav                     - Beep sound
 *      verifile.bmp                     - Verifile logo for about dialog
 *      win1splash.bmp                   - Windows 1.01 startup logo (B&W)
 *      win2splash.bmp                   - Windows 2.03 startup logo (B&W)
 * 
 * Properties
 *      AssemblyInfo.cs                  - Assembly information for the application (e.g. title, company, version, etc) (auto-generated)
 *      Resources.resx                   - Resource identification (auto-generated)
 *      Settings.settings                - Settings [*Unused*] (auto-generated)
 * 
 * System\Windows\Forms
 *      AliasedLabel.cs                  - A custom control that is used in Windows XP and CE blue screens
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
        public static Main f1;
        public static Splash spl;
        public static DrawRoutines dr;

        public static bool loadfinished = true;

        private static bool bad = false;

        //Command line syntax
        public static string cmds = "/? - Displays command line syntax\n/wv:xx - Set a specific configuration/os (e.g. \"XP\")\n/h - Doesn't show main GUI. If no simulation is started or the simulation is finished, the program will close.\n/hwm - Hides watermark\n/c - Simulates a system crash\n/config:xx - Loads a configuration file (xx is the file name)\n\n/ntc:xx - Specific NT error code to display. Replace xx with the actual code\n/9xc:xx - Specific 9x/Me message to display (system/application/driver/busy/unresponsive)\n/ddesc - Disables error descriptions\n/dqr - Disables QR code on Windows 10 blue screen\n/srv - Displays Windows Server 2016 blue screen when wv is set to 10\n/dac - Disables autoclose feature (Modern blue screens only)\n/gs - Displays green screen when wv is set to 10\n/ap - Displays ACPI blue screen (Windows Vista/7 only)\n/file:xx - Displays the potential culprit file (replace xx with the actual file name)\n/amd - Displays \"AuthenticAMD\" instead of \"GenuineIntel\" on Windows NT blue screen\n/blink - Shows a blinking cursor (NT blue screen)\n/dstack - Does not display stack trace (NT blue screen)\n/win - Enables windowed mode\n/random - Randomizes the blue screen (does NOT randomize any custom attributes set)\n\n/desc - Forcibly enable error description\n/ac - Forcibly enable autoclose feature\n/dap - Forcibly disable ACPI error screen (Windows Vista/7)\n/damd - Forcibly display \"GenuineIntel\" on Windows NT blue screen\n/dblink - Forcibly disable blinking cursor on Windows NT blue screen\n/dgs - Forcibly disable green screen on Windows 10 blue screen\n/qr - Forcibly enable QR code on Windows 10 blue screen\n/dsrv - Forcibly disable server blue screen when version is set to Windows 10\n/stack - Forcible enable stack trace on Windows NT blue screen\n/dfile - Forcible disables potential culprit file\n\n/clr - Clears the verification certificate from this computer, causing the first use message to pop up.\n/hidesplash - Hides the splash screen";

        internal static bool verificate = false;
        public static int load_progress = 100;
        public static string load_message = "";
        public static bool hidden = false;
        public static string multidisplaymode = "blank";

        public static string update_server = "http://markustegelane.tk/app";

        readonly private static ManagementObjectSearcher aa = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        public static List<BlueScreen> bluescreens;

        [STAThread]
        public static void Main(string[] args)
        {
            //Application initialization
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            dr = new DrawRoutines();

            //Initialize forms
            f1 = new Main();
            bluescreens = new List<BlueScreen>();
            ReRe();
            //Load application configuration if it exists
            if (File.Exists("settings.cfg"))
            {
                try
                {
                    string[] fc = File.ReadAllText("settings.cfg").Split('\n');
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
                        else if (element.StartsWith("MultiMode="))
                        {
                            multidisplaymode = element.Replace("MultiMode=", "");
                        }
                        else if (element.StartsWith("Seecrets="))
                        {
                            f1.enableeggs = Convert.ToBoolean(element.Replace("Seecrets=", ""));
                        }
                        else if (element.StartsWith("ScaleMode="))
                        {
                            f1.GMode = element.Replace("ScaleMode=", "");
                        }
                        else if (element.StartsWith("Server="))
                        {
                            update_server = element.Replace("Server=", "");
                        }
                        // this skips checking hidden/visible OS-s
                        // this is a feature that was exclusive to 1.x
                        else if (element.Contains("\""))
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Metaerror me = new Metaerror()
                    {
                        message = ex.Message,
                        stack_trace = ex.StackTrace,
                        type = "VioletScreen"
                    };
                    
                    if (Program.f1.enableeggs)
                    {
                        switch (me.ShowDialog())
                        {
                            case DialogResult.Abort:
                                return;
                            case DialogResult.Retry:
                                Application.Restart();
                                return;
                            case DialogResult.Ignore:
                                break;
                        }
                    }
                    else { MessageBox.Show("There was a problem with the settings file.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            //If hidesplash flag is not set, display the splash screen
            if (!args.Contains("/hidesplash"))
            {
                if (!args.Contains("/finalize_update"))
                {
                    hidden = true;
                    spl = new Splash();
                    spl.ShowDialog();
                    if (args.Contains("/preview_splash"))
                    {
                        return;
                    }
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
                if ((!args.Contains("/hidesplash")) || (!args.Contains("/finalize_update")))
                {
                    spl.Close();
                }
                File.Delete(Environment.GetEnvironmentVariable("USERPROFILE") + @"\bssp_firstlaunch.txt");
                MessageBox.Show("Signature verification file deleted. The program will now close.", "Ultimate blue screen simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (args.Contains("/c"))
            {
                f1.GetOS();
            }


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
            bool done = false;
            foreach (string argument in args)
            {
                //check argument syntax
                if (!argument.StartsWith("/"))
                {
                    f1.error = 23;
                    break;
                }
                //this code loads hack file if specified in arguments
                if (argument.Contains("/config:"))
                {
                    string filename = argument.Split(':')[1];
                    if (File.Exists(filename))
                    {
                        if (filename != "")
                        {
                            AboutSettingsDialog abb = new AboutSettingsDialog();
                            abb.loadBsconfig.FileName = filename;
                            abb.LoadConfig();
                            abb.Close();
                            abb.Dispose();
                        }
                    }
                    else
                    {
                        f1.error = 24;
                    }
                }
                //select Windows version using /wv argument
                if (argument.Contains("/wv"))
                {
                    string ecode = argument.Split(':')[1];
                    if (ecode == "")
                    {
                        f1.error = 15;
                    }
                    int i = 0;
                    foreach (BlueScreen bs in bluescreens)
                    {
                        if (bs.GetString("friendlyname").ToLower().Contains(ecode.ToLower()) || bs.GetString("os").ToLower().Contains(ecode.ToLower()))
                        {
                            f1.me = bs;
                            f1.displayone = true;
                            f1.comboBox1.SelectedIndex = i;
                            done = true;
                            break;
                        }
                        i++;
                    }
                    if (!done)
                    {
                        f1.error = 12;
                    }
                }
            }
            
            //sets other optional flags
            if (args.Contains("/ddesc")) { 
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("show_description", false);
                }
            }
            if (args.Contains("/desc"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("show_description", true);
                }
            }
            if (args.Contains("/dac"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("autoclose", false);
                }
            }
            if (args.Contains("/ac"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("autoclose", true);
                }
            }
            if (args.Contains("/ap"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("acpi", true);
                }
            }
            if (args.Contains("/dap"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("acpi", false);
                }
            }
            if (args.Contains("/amd"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("amd", true);
                }
            }
            if (args.Contains("/damd"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("amd", false);
                }
            }
            if (args.Contains("/blink"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("blink", true);
                }
            }
            if (args.Contains("/dblink"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("blink", false);
                }
            }
            if (args.Contains("/gs"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("insider", true);
                }
            }
            if (args.Contains("/dgs"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("insider", false);
                }
            }
            if (args.Contains("/qr"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("qr", true);
                }
            }
            if (args.Contains("/dqr"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("qr", false);
                }
            }
            if (args.Contains("/srv"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("server", true);
                }
            }
            if (args.Contains("/dsrv"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("server", false);
                }
            }
            if (args.Contains("/stack"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("stack_trace", true);
                }
            }
            if (args.Contains("/dstack"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("stack_trace", false);
                }
            }
            if (args.Contains("/win"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("windowed", true);
                }
            }
            if (args.Contains("/dfile"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("show_file", false);
                    bs.SetString("culprit", "");
                }
            }
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
                    foreach (BlueScreen bs in bluescreens)
                    {
                        bs.SetString("culprit", ecode);
                    }
                    if (ecode == "")
                    {
                        f1.error = 16;
                    }
                    f1.textBox2.Text = ecode;
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
            if (args.Contains("/hwm"))
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    bs.SetBool("watermark", false);
                }
            }

            //Simulate crash if /c flag is set
            if (args.Contains("/c"))
            {
                f1.Crash();
            }
            //run application
            Application.Run(f1);
  
        }

        /// <summary>
        /// Computer verification system
        /// </summary>
        /// <param name="args">key array</param>
        /// <returns>boolean</returns>
        // Verifile
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
        
        static public void ReRe()
        {
            Program.bluescreens.Clear();
            Program.bluescreens.Add(new BlueScreen("Windows 1.x/2.x"));
            Program.bluescreens.Add(new BlueScreen("Windows 3.1x"));
            Program.bluescreens.Add(new BlueScreen("Windows 9x/Me"));
            Program.bluescreens.Add(new BlueScreen("Windows CE"));
            Program.bluescreens.Add(new BlueScreen("Windows NT 3.x/4.0"));
            Program.bluescreens.Add(new BlueScreen("Windows 2000"));
            Program.bluescreens.Add(new BlueScreen("Windows XP"));
            Program.bluescreens.Add(new BlueScreen("Windows Vista/7"));
            Program.bluescreens.Add(new BlueScreen("Windows 8/8.1"));
            Program.bluescreens.Add(new BlueScreen("Windows 10"));
            Program.bluescreens.Add(new BlueScreen("Windows 11"));
        }
    }
}
