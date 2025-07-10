/*
 * Blue screen simulator plus
 * Codename: LotsaSpaghetti
 * 
 * Version 3.1 (pre-release)
 *
 * {} markus' software // {} markuse tarkvara
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using SimulatorDatabase;
using UltimateBlueScreenSimulator.Forms.Legacy;

namespace UltimateBlueScreenSimulator
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //Form creation
        public static NewUI F1 { get; set; }
        public static Main F2 { get; set; }
        public static Splash spl;
        public static DrawRoutines dr;
        public static GlobalSettings gs = new GlobalSettings();

        public static bool loadfinished = true;

        //AppData directory
        public readonly static string prefix = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Blue Screen Simulator Plus\";

        //Command line syntax
        public static string cmds = "/? - Displays command line syntax\n/wv xx - Set a specific configuration/os (e.g. \"XP\", spaces require the value to be surrounded with double quotes)\n/h - Doesn't show main GUI. If no simulation is started or the simulation is finished, the program will close.\n/hwm - Hides watermark\n/c - Simulates a system crash\n/config xx - Loads a configuration file (xx is the file name, if there are spaces, you must use double quotes)\n\n/ddesc - Disables error descriptions\n/dqr - Disables QR code on Windows 10/11 crash screen\n/srv - Displays Windows Server bugcheck when wv is set to 10 or 11\n/dac - Disables autoclose feature (Modern blue screens only)\n/gs - Displays green screen when wv is set to 10\n/ap - Displays ACPI blue screen (Windows Vista/7 only)\n/win - Enables windowed mode\n/random - Randomizes the crash screen (does NOT randomize any custom attributes set)\n\n/desc - Forcibly enable error description\n/ac - Forcibly enable autoclose feature\n/dap - Forcibly disable ACPI error screen (Windows Vista/7)\n/damd - Forcibly display \"GenuineIntel\" on Windows NT blue screen\n/dblink - Forcibly disable blinking cursor on Windows NT blue screen\n/dgs - Forcibly disable green screen on Windows 10 blue screen\n/qr - Forcibly enable QR code on Windows 10 blue screen\n/dsrv - Forcibly disable server blue screen when version is set to Windows 10\n/stack - Forcible enable stack trace on Windows NT blue screen\n/dfile - Forcible disables potential culprit file\n/ctd - Forcibly enables countdown\n\n/clr - Clears the verification certificate from this computer, causing the first use message to pop up.\n/hidesplash - Hides the splash screen\n/legacy - Starts the program with Legacy UI";

        internal static bool verificate = false;
        public static int load_progress = 100;
        public static string load_message = "Initializing...";
        public static bool hidden = false;
        internal static string changelog = "*CHANGE THIS*";

        public static bool hide_splash = false;
        public static bool force_legacy = false;
        public static bool halt = false;
        
        // initialize global objects
        public static Verifile verifile;
        public static Thread splt;
        public static CLIProcessor clip;
        public static TemplateRegistry templates;
        public readonly static byte[] footerBytes = new byte[] { 0x42, 0x33, 0x65, 0x72 };
        public static string[] validnames = new string[]
        {
                "blue screen simulator plus",
                "bssp",
                "ultimatebluescreensimulator",
                "blue.screen.simulator.plus"
        };
        public static bool isScreensaver = Process.GetCurrentProcess().MainModule.ModuleName.ToLower().EndsWith(".scr");
        public static RegistryKey wineKey = Registry.LocalMachine.OpenSubKey(@"Software\Wine", false);


        public readonly static string[] tips =
        {
                "Material Design is a design language developed by Google in 2014!",
                "You can close a bugcheck by pressing ALT+F4",
                "There is a crash screen for a program that simulates crash screens, right?",
                "The codename for version 2.0 came from a song that was playing in the background during the development process",
                "If Microsoft decides to change their error screens, I'll push an update that adds these changes",
                "Configuration files store every property about all error screens",
                "Windows Vista/7 blue screen scrolls, when there is too much information on screen",
                "There are rainbow easter eggs for Windows XP, Vista, 7, CE, and 1.x/2.x blue screens",
                "In prank mode, the watermark on a bugcheck is disabled automatically",
                "There are three error screens in this program, that technically aren't blue screens",
                "This program, for the most part, also works in ReactOS, which is an open source Windows clone based on reverse engineering",
                "The first Windows XP bluescreen I ever saw displayed DRIVER_IRQL_NOT_LESS_OR_EQUAL as the error code",
                "You can also use the Enter key to close Windows 9x bluescreens",
                "Microsoft originally planned to replace a blue screen with a black one as early as Windows 8",
                "Every major Windows release, up until later builds of Windows 11, has had some sort of a blue screen",
                "Blue is a color that symbolises peace",
                "Windows 2000 blue screen didn't use rasterized fonts in previous versions, because I figured it looked 'close enough' to the original",
                "If you use the 'choose' button when setting a culprit file, you might see some weird filenames...",
                "The background of the logo graphic in the about screen displays two major colors used by bugcheck screens - black and blue",
                "This program isn't a copy of FlyTech's work, instead it was developed from scratch, because of the limitations I saw when trying out FlyTech's blue screen simulator.",
                "You can use progress tuner to make more realistic progress indicators for modern bugchecks",
                "There is no random factoid here",
                "The splash screen crashes were really annoying to debug when building version 3.1, because they would only occur occasionally",
                "I actually used a super ultrawide monitor for testing this version of BSSP",
                "Is this the last version? Yesn't!",
                "Liftoff, we have liftoff!",
                "Every major version of BSSP (1.x, 2.x, 3.x) has its own save file format. There are rumors that the next simulator will use XML as the save format.",
                "We got Blue Screen Simulator Plus 3.1 before GTA VI",
                "I hope she made lotsa spaghetti!",
                "öӧӧöӧӧӧӧӧӧӧӧӧӧӧöӧӧӧöӧöӧööӧӧӧӧӧöӧӧöӧӧӧöӧӧöö ӧöööӧööӧö ӧöӧӧӧӧöӧöӧӧöӧöӧӧ öӧӧöӧӧӧöӧӧӧöӧööӧöӧööӧöӧӧӧöӧӧöӧӧӧöӧӧöö öӧööӧöööӧööööӧöӧӧӧӧöӧöӧӧӧöö",
                "This simulator gives Microsoft and Crowdstrike PTSD without actually crashing computers",
                "KERNEL PANIC!\n\nPlease reboot your computer.\n\nAttempted to kill init! exitcode=0x0000000b",
                "\"That's what I get for working at Microsoft\"\n - Gabe Newell",
                "Your computer was restarted because of a problem.\n\nClick Report to see more detailed information and send a report to Apple.",
                "There's truth, lies and statistics....",
                "There is a chance you saw this factoid already",
                $"The lucky number for this session is {BlueScreen.r.Next(0,9999)}",
                "In a 2014 presentation, Microsoft discussed the name for the next version of Windows, which they originally wanted to call Windows One, but instead decided to go for Windows 10, because the giants before them already made Windows 1.0.",
                "I'm everyone. I'm everywhere. I see everything. I hear everybody.",
                "There is no escape.",
                "1 + 1 = 10 (at least that's what computers think)",
                "Please stop clicking the \"Random factoid\" button!",
                "target: void"
            };

        [STAThread]
        public static int Main(string[] args)
        {
            try
            {
                // Process CLI args
                clip = new CLIProcessor(args);
                //Application initialization
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                verifile = new Verifile();
                verificate = verifile.Verify;
                gs.Log("Info", "Verifile passed");
                if (AttachmentReader(args))
                {
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
                // this delay makes sure that the splash screen is actually displayed
                Thread.Sleep(100);
                gs.Log("Info", "Initializing configurations list");
                templates = new TemplateRegistry();
                gs.Log("Info", "Initializing draw routines");
                dr = new DrawRoutines();
                //Initialize forms
                gs.Log("Info", "Creating initial form");
                F1 = new NewUI();
                //Set default selection indexes for combo boxes
                F1.windowVersion.SelectedIndex = 0;
                F1.comboBox2.SelectedIndex = 0;
                clip.ProcessArgs();
                if (halt)
                {
                    return 0;
                }
                //Load application configuration if it exists
                try
                {
                    gs = gs.LoadSettings();
                    if (gs.LegacyUI)
                    {
                        F2 = new Main();
                    }
                    if (wineKey != null)
                    {
                        gs.Log("Warning", "Wine registry key detected - the user may have launched this program in Linux or macOS. This may cause unexpected glitches!");
                        if (!gs.LegacyUI)
                        {
                            gs.Log("Warning", "Material UI is not available when application is launched through Wine");
                            gs.LegacyUI = true;
                        }
                    }
                }
                catch (Exception ex) when (!Debugger.IsAttached)
                {
                    DisplayMetaError(ex, "VioletScreen");
                }
                if (gs.Autosave && File.Exists(prefix + "bluescreens.json"))
                {
                    templates = templates.LoadConfig(prefix + "bluescreens.json");
                }


                //Load Windows NT error codes from the database
                gs.Log("Info", $"Initializing NT error code database");
                ReloadNTErrors();
                gs.Log("Info", "Initializing 9x error code database");
                ReloadNxErrors();
                //run application
                if (gs.LegacyUI || force_legacy)
                {
                    Application.Run(F2);
                }
                else
                {
                    Application.Run(F1);
                }
                return gs.ErrorCode;
            }
            catch (Exception e) when (!Debugger.IsAttached)
            {
                MessageBox.Show($"Runtime error.\r\n{e.Message}\r\n{e.StackTrace}", "Blue screen simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 300;
            }
        }

        /// <summary>
        /// Displays the splash screen
        /// </summary>
        private static void ShowLoading()
        {
            try
            {
                spl = new Splash
                {
                    args = clip.args
                };
                spl.ShowDialog();
            } catch (ThreadAbortException)
            {
                Thread.ResetAbort();
                return;
            }
        }

        /// <summary>
        /// Reloads NT error codes on the main form
        /// </summary>
        public static void ReloadNTErrors()
        {
            F1.comboBox1.Items.Clear();
            if (gs.LegacyUI)
            {
                F2.comboBox1.Items.Clear();
            }
            try
            {
                foreach (string element in templates.NtErrors)
                {
                    string[] codesplit = element.Split('\t');
                    string final = codesplit[1].ToString() + " (" + codesplit[0].ToString() + ")";
                    F1.comboBox1.Items.Add(final);
                    if (gs.LegacyUI)
                    {
                        F2.comboBox1.Items.Add(final);
                    }
                }
                F1.comboBox1.SelectedIndex = 9;
                if (gs.LegacyUI)
                {
                    F2.comboBox1.SelectedIndex = 9;
                }
            }
            catch
            {
                gs.ErrorCode = 20;
            }
        }

        public static void ReloadNxErrors()
        {
            F1.nineXErrorCode.Items.Clear();
            if (gs.LegacyUI)
            {
                F2.nineXErrorCode.Items.Clear();
            }
            try
            {
                foreach (string element in templates.NxErrors)
                {
                    string[] codesplit = element.Split('\t');
                    string final = codesplit[0].ToString() + ": " + codesplit[1].ToString();
                    F1.nineXErrorCode.Items.Add(final);
                    if (gs.LegacyUI)
                    {
                        F2.nineXErrorCode.Items.Add(final);
                    }
                }
                F1.nineXErrorCode.SelectedIndex = 9;
                if (gs.LegacyUI)
                {
                    F2.nineXErrorCode.SelectedIndex = 9;
                }
            } catch
            {
                gs.ErrorCode = 20;
            }
        }

        /// <summary>
        /// Displays an error message about missing DLL files
        /// </summary>
        public static void DllError()
        {
            MessageBox.Show("Required DLL files are missing. To use the save and load feature, all DLLs must be present in the application's working directory.", "DLL error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays a meta-error
        /// </summary>
        /// <param name="ex">Caught exception</param>
        /// <param name="type">Error type (e.g. VioletScreen)</param>
        private static void DisplayMetaError(Exception ex, string type)
        {
            gs.Log("Critical", $"{type} exception: {ex.Message}\n{ex.StackTrace}");
            Metaerror me = new Metaerror()
            {
                ex = ex,
                type = type
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

        /// <summary>
        /// Checks for internet connectivity
        /// </summary>
        /// <param name="minimumSpeed">Minimum speed to be considered connected</param>
        /// <returns>Returns true if connected</returns>
        public static bool DoWeHaveInternet(long minimumSpeed)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return false;
            }

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                // discard because of standard reasons
                if ((ni.OperationalStatus != OperationalStatus.Up) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback) ||
                    (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel))
                {
                    continue;
                }

                // this allow to filter modems, serial, etc.
                // I use 10000000 as a minimum speed for most cases
                if (ni.Speed < minimumSpeed)
                {
                    continue;
                }

                // discard virtual cards (virtual box, virtual pc, etc.)
                if ((ni.Description.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (ni.Name.IndexOf("virtual", StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    continue;
                }

                // discard "Microsoft Loopback Adapter", it will not show as NetworkInterfaceType.Loopback but as Ethernet Card.
                if (ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                return true;
            }
            return false;
        }

        /// <summary>
        /// Allows you to test if invalid characters exist within a configuration
        /// </summary>
        /// <param name="letters">Character set</param>
        /// <param name="me">Configuration template</param>
        /// <returns>true when errors are found</returns>
        public static bool TestDicts(string[] letters, BlueScreen me)
        {
            bool errors = TestDict(letters, me.GetTexts().Values.ToArray()) || TestDict(letters, me.GetTitles().Values.ToArray());
            if (errors)
            {
                loadfinished = true;
                MessageBox.Show("Disallowed characters found! Only the following characters are allowed:\n" + string.Join("", letters), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return errors;
        }

        private static bool TestDict(string[] letters, string[] strings)
        {
            bool errors = false;
            foreach (string text in strings)
            {
                string replacedText = text;
                foreach (string c in letters)
                {
                    replacedText = replacedText.Replace(c, "");
                }
                if (replacedText.Replace("\r", "").Replace("\n", "").Replace("{", "").Replace("}", "") != "")
                {
                    errors = true;
                }
            }
            return errors;
        }

        /// <summary>
        /// For self-contained simulator support. Loads a JSON string from the end of executable into memory if the special B3er header is found, then displays a crash screen based on those settings.
        /// </summary>
        /// <returns>If the header is found, returns true</returns>
        private static bool AttachmentReader(string[] args)
        {
            // if we are just using the main program and not a self contained one, just return false
            // trying to load a non-existant footer will increase load times for no good reason
            foreach (string entry in validnames)
            {
                if (System.Diagnostics.Process.GetCurrentProcess().MainModule.ModuleName.ToLower() == $"{entry}.exe")
                {
                    return false;
                }
            }
            string jsondata = GetEmbedded();
            if (jsondata != "")
            {
                gs.LoadSettings();
                if (verificate)
                {
                    templates = new TemplateRegistry();
                    dr = new DrawRoutines();
                    F1 = new NewUI();

                    Thread th = new Thread(new ThreadStart(() => {
                        // initialize BlueScreen object
                        UIActions.me = templates.LoadSingleConfig(jsondata);
                        if (isScreensaver)
                        {
                            if ((!args.Contains("/s") && !args.Contains("/S") && !args.Contains("/p")) || args.Contains("/c"))
                            {
                                UIActions.me = templates.LoadSingleConfig(jsondata);
                                Application.Run(new ScreenSaverConfig());
                                return;
                            }
                            else if (string.Join(" ", args).Contains("/p"))
                            {
                                if (!string.Join(" ", args).Contains(":") && args.Length < 2)
                                {
                                    MessageBox.Show("Window handle was not provided!", "Blue Screen Simulator Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                string ProcessID = args.Length < 2 ? string.Join(" ", args).Split(':')[1] : args[1];
                                IntPtr previewWndHandle = new IntPtr(long.Parse(args[1]));
                                Application.Run(new Forms.Loaders.ScreensaverPreview(previewWndHandle));
                                return;
                            }
                        }
                        // display the crash screen
                        UIActions.me.Show();
                    }));
                    th.Start();
                    th.Join();
                }
            } else
            {
                MessageBox.Show($"Invalid footer data or filename. Please rename the executable back or delete it.\r\n\r\nValid names include the following:\r\n{string.Join("\r\n", validnames)}", "Special footer missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return true;
        }

        public static string GetEmbedded(string appname = null)
        {
            List<byte> data = new List<byte>();
            string filename = appname ?? System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string tempname = Path.GetTempPath() + "\\BSSP.temp";
            File.Copy(filename, tempname);
            _ = new FileInfo(tempname);
            List<byte> discoveredFootBytes = new List<byte>();
            bool footerFound = false;
            bool actualFooterFound = false;
            int i = 0;
            using (BinaryReader reader = new BinaryReader(new FileStream(tempname, FileMode.Open)))
            {
                byte b = 0xFF;
                while (true)
                {
                    try
                    {
                        b = reader.ReadByte();
                    }
                    catch
                    {
                        break;
                    }
                    if (actualFooterFound)
                    {
                        data.Add(b);
                        i++;
                    }
                    else if (footerBytes.Contains(b) && !discoveredFootBytes.Contains(b))
                    {
                        discoveredFootBytes.Add(b);
                        if ((discoveredFootBytes.Count == 4) && footerFound)
                        {
                            actualFooterFound = true;
                        }
                        else if ((discoveredFootBytes.Count == 4))
                        {
                            footerFound = true;
                        }
                    }
                    else
                    {
                        discoveredFootBytes.Clear();
                    }
                }
            }
            File.Delete(tempname);
            List<byte> stripped = new List<byte>();
            foreach (byte b in data)
            {
                if (b != 0x00)
                {
                    stripped.Add(b);
                }
            }
            if (stripped.Count > 0)
            {
                return System.Text.Encoding.Default.GetString(stripped.ToArray());
            } else
            {
                return "";
            }
        }
    }
}
