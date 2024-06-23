/*
 * Blue screen simulator plus
 * Codename: ModestIndigo
 * 
 * Version 3.0 (pre-release)
 *
 * {} markus' software // {} markuse tarkvara
 */

using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using SimulatorDatabase;
using System.Net.NetworkInformation;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace UltimateBlueScreenSimulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //Form creation
        public static NewUI f1;
        //public static Main f2;
        public static Splash spl;
        public static DrawRoutines dr;
        public static GlobalSettings gs = new GlobalSettings();

        public static bool loadfinished = true;


        //Command line syntax
        public static string cmds = "/? - Displays command line syntax\n/wv xx - Set a specific configuration/os (e.g. \"XP\", spaces require the value to be surrounded with double quotes)\n/h - Doesn't show main GUI. If no simulation is started or the simulation is finished, the program will close.\n/hwm - Hides watermark\n/c - Simulates a system crash\n/config xx - Loads a configuration file (xx is the file name, if there are spaces, you must use double quotes)\n\n/ddesc - Disables error descriptions\n/dqr - Disables QR code on Windows 10 blue screen\n/srv - Displays Windows Server 2016 blue screen when wv is set to 10\n/dac - Disables autoclose feature (Modern blue screens only)\n/gs - Displays green screen when wv is set to 10\n/ap - Displays ACPI blue screen (Windows Vista/7 only)\n/win - Enables windowed mode\n/random - Randomizes the blue screen (does NOT randomize any custom attributes set)\n\n/desc - Forcibly enable error description\n/ac - Forcibly enable autoclose feature\n/dap - Forcibly disable ACPI error screen (Windows Vista/7)\n/damd - Forcibly display \"GenuineIntel\" on Windows NT blue screen\n/dblink - Forcibly disable blinking cursor on Windows NT blue screen\n/dgs - Forcibly disable green screen on Windows 10 blue screen\n/qr - Forcibly enable QR code on Windows 10 blue screen\n/dsrv - Forcibly disable server blue screen when version is set to Windows 10\n/stack - Forcible enable stack trace on Windows NT blue screen\n/dfile - Forcible disables potential culprit file\n/ctd - Forcibly enables countdown\n\n/clr - Clears the verification certificate from this computer, causing the first use message to pop up.\n/hidesplash - Hides the splash screen";

        internal static bool verificate = false;
        public static int load_progress = 100;
        public static string load_message = "Initializing...";
        public static bool hidden = false;
        internal static string changelog = "+ New user interface!\n+ Trace logging\n???\n$$$ Profit $$$";

        public static List<BlueScreen> bluescreens;
        public static bool hide_splash = false;
        public static bool halt = false;
        

        public static Verifile verifile;
        public static Thread splt;
        public static CLIProcessor clip;

        [STAThread]
        public static int Main(string[] args)
        {
            //gs.SingleSim = "Windows 11";
            clip = new CLIProcessor(args);
            //Application initialization
            Application.SetCompatibleTextRenderingDefault(false);
            verifile = new Verifile();
            verificate = verifile.Verify;
            gs.Log("Info", "Verifile passed");
            if ((gs.SingleSim != "") && verificate)
            {
                bluescreens = new List<BlueScreen>();
                dr = new DrawRoutines();
                ReRe();
                f1 = new NewUI();
                //gs.PM_Lockout = true;
                Thread th = new Thread(new ThreadStart(() => {

                    // initialize BlueScreen object
                    f1.me = new BlueScreen(gs.SingleSim);
                    // display the crash screen
                    f1.me.Show();
                }));
                th.Start();
                th.Join();
                return 0;
            }
            //If hidesplash flag is not set, display the splash screen
            hide_splash = clip.CheckNoSplash();
            if (!hide_splash)
            {
                hidden = true;
                splt = new Thread(ShowLoading);
                splt.Start();
                if (clip.CheckPreviewSplash())
                {
                    halt = true;
                }
            }
            else
            {
                Application.EnableVisualStyles();
            }
            // this delay makes sure that the splash screen is actually displayed
            Thread.Sleep(100);
            gs.Log("Info", "Initializing draw routines");
            dr = new DrawRoutines();
            //Initialize forms
            //f2 = new Main();
            gs.Log("Info", "Creating initial form");
            f1 = new NewUI();
            gs.Log("Info", "Initializing configurations list");
            bluescreens = new List<BlueScreen>();
            ReRe();
            //Set default selection indexes for combo boxes
            f1.windowVersion.SelectedIndex = 0;
            f1.comboBox2.SelectedIndex = 0;
            clip.ProcessArgs();
            if (halt)
            {
                return 0;
            }
            //Load application configuration if it exists
            if (File.Exists("settings.cfg"))
            {
                try
                {
                    gs.LoadSettings();
                }
                catch (Exception ex)
                {
                    DisplayMetaError(ex, "VioletScreen");
                }
            }


            //Load Windows NT error codes from the database
            gs.Log("Info", $"Initializing NT error code database");
            f1.comboBox1.Items.Clear();
            string database = "";
            try
            {
                database = Properties.Resources.NTERRORDATABASE;
            }
            catch
            {
                gs.ErrorCode = 19;
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
                f1.comboBox1.SelectedIndex = 9;
            }
            catch
            {
                gs.ErrorCode = 20;
            }
            //run application
            Application.Run(f1);
            return gs.ErrorCode;
        }

        private static void ShowLoading()
        {
            spl = new Splash
            {
                args = clip.args
            };
            spl.ShowDialog();
        }

        static public void ReRe()
        {
            if (gs.ErrorCode != 500)
            {
                Program.bluescreens.Clear();
                Program.bluescreens.Add(new BlueScreen("Windows 1.x/2.x"));
                Program.bluescreens.Add(new BlueScreen("Windows 3.1x"));
                Program.bluescreens.Add(new BlueScreen("Windows 9x/Me"));
                Program.bluescreens.Add(new BlueScreen("Windows CE"));
                Program.bluescreens.Add(new BlueScreen("Windows NT 3.x/4.0"));
                Program.bluescreens.Add(new BlueScreen("Windows 2000"));
                Program.bluescreens.Add(new BlueScreen("Windows XP"));
                Program.bluescreens.Add(new BlueScreen("Windows Vista"));
                Program.bluescreens.Add(new BlueScreen("Windows 7"));
                Program.bluescreens.Add(new BlueScreen("Windows 8 Beta"));
                Program.bluescreens.Add(new BlueScreen("Windows 8/8.1"));
                Program.bluescreens.Add(new BlueScreen("Windows 10"));
                Program.bluescreens.Add(new BlueScreen("Windows 11"));
            } else
            {
                halt = true;
            }
        }

        static private void DisplayMetaError(Exception ex, string type)
        {
            gs.Log("Critical", $"{type} exception: {ex.Message}\n{ex.StackTrace}");
            Metaerror me = new Metaerror()
            {
                message = ex.Message,
                stack_trace = ex.StackTrace,
                type = "VioletScreen"
            };

            if (gs.EnableEggs)
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

        public static bool DoWeHaveInternet(long minimumSpeed)
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

    }
}
