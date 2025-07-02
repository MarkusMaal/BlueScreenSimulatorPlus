using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    ///<summary>
    ///Command line interface processor
    ///</summary>
    internal class CLIProcessor
    {
        internal readonly string[] args;
        private bool checkvalue;

        public CLIProcessor(string[] args)
        {
            this.args = args;
            this.checkvalue = false;
        }

        ///<summary>
        ///Processes all provided arguments
        ///</summary>
        public void ProcessArgs()
        {
            string lastArg = "";
            foreach (string arg in args)
            {
                if (arg.StartsWith("/"))
                {
                    ProcessFlag(arg);
                }
                if (checkvalue)
                {
                    ProcessValue(lastArg, arg);
                }
                lastArg = arg;
            }
            PostProcess();
        }

        ///<summary>
        ///Forces a boolean on all configurations to a specific value
        ///</summary>
        ///<param name="name">Name of the boolean</param>
        ///<param name="value">Value of the boolean</param>
        private void ForceBool(string name, bool value)
        {
            Program.gs.Log("Info", $"Forcing {name} to {(value?"enabled":"disabled")} state");
            foreach (BlueScreen bs in Program.templates.GetAll())
            {
                bs.SetBool(name, value);
            }
        }

        ///<summary>
        ///Processes a value after a specific flag
        ///</summary>
        ///<param name="flag">The specific flag</param>
        ///<param name="value">The value</param>
        private void ProcessValue(string flag, string value)
        {
            string ecode;
            if (flag.Length < 2)
            {
                return;
            }
            switch (flag.Substring(1))
            {
                case "wv":
                    //select Windows version using /wv argument
                    ecode = value;
                    if (ecode == "")
                    {
                        Program.gs.ErrorCode = 15;
                    }
                    int i = 0;
                    bool done = false;
                    foreach (BlueScreen bs in Program.templates.GetAll())
                    {
                        if (bs.GetString("friendlyname").ToLower().Contains(ecode.ToLower()) || bs.GetString("os").ToLower().Contains(ecode.ToLower()))
                        {
                            UIActions.me = bs;
                            Program.gs.DisplayOne = true;
                            //Program.f1.comboBox1.SelectedIndex = i;
                            done = true;
                            break;
                        }
                        i++;
                    }
                    if (!done)
                    {
                        Program.gs.ErrorCode = 12;
                    }
                    break;
                case "config":
                    //this code loads hack file if specified in arguments
                    string filename = value;
                    Program.gs.Log("Info", $"Loading configuration file: {filename}");
                    if (File.Exists(filename))
                    {
                        if (filename != "")
                        {
                            AboutSettingsDialog abb = new AboutSettingsDialog();
                            Program.templates = Program.templates.LoadConfig(filename);
                            abb.Close();
                            abb.Dispose();
                        }
                    }
                    else
                    {
                        Program.gs.ErrorCode = 24;
                    }
                    break;
                case "file":
                    //displays errror cuplrit file if specified in arguments
                    Program.gs.Log("Info", "Setting culprit file");
                    Program.f1.checkBox2.Checked = true;
                    ecode = value;
                    foreach (BlueScreen bs in Program.templates.GetAll())
                    {
                        bs.SetString("culprit", ecode);
                    }
                    if (ecode == "")
                    {
                        Program.gs.ErrorCode = 16;
                    }
                    Program.f1.textBox2.Text = ecode;
                    break;
            }
        }
        ///<summary>
        ///Closes the splash screen
        ///</summary>
        internal void ExitSplash(Form f = null)
        {
            if (!CheckNoSplash())
            {
                new Thread(() => {
                    Program.gs.Log("Info", "Safely closing splash screen");
                    Thread.Sleep(500);
                    if (f != null)
                    {
                        f.BeginInvoke(new MethodInvoker(delegate {
                            Program.splt.Abort();
                            Program.splt.Join();
                            f.TopMost = true;
                            f.TopMost = false;
                            f.Focus();
                        }));
                    } else
                    {
                        Program.splt.Abort();
                        Program.splt.Join();
                    }
                }).Start();
            }
        }

        ///<summary>
        ///Processes a command line parameter which has a slash in front of it
        ///</summary>
        ///<param name="arg">The argument with the / character</param>
        private void ProcessFlag(string arg)
        {
            // key is the flag, value determines which boolean to force
            var forceFlags = new Dictionary<string, string>()
            {
                {"wm", "watermark"}, {"desc", "show_description"}, {"ac", "autoclose"},
                {"ap", "acpi"}, {"amd", "amd"}, {"blink", "blink"}, {"gs", "insider"},
                {"qr", "qr"}, {"srv", "server"}, {"stack", "stack_trace"},
                {"win", "windowed"}, {"file", "show_file"}, {"ctd", "countdown"},
            };
            foreach (KeyValuePair<string, string> kv in forceFlags)
            {
                if (arg.Substring(1).Equals(kv.Key))
                {
                    ForceBool(kv.Value, true);
                } else if (arg.Substring(1).Equals($"d{kv.Key}"))
                {
                    ForceBool(kv.Value, false);
                }
            }

            switch (arg.Substring(1))
            {
                case "?":
                    ExitSplash();
                    MessageBox.Show(Program.cmds, "Command line argument usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Program.gs.ErrorCode = 999;
                    Program.halt = true;
                    break;
                case "finalize_update":
                case "hidesplash":
                    Program.hide_splash = true;
                    break;
                case "clr":
                    //Clears Verifile verification certificate
                    ExitSplash();
                    File.Delete(Environment.GetEnvironmentVariable("USERPROFILE") + @"\bssp2_firstlaunch.txt");
                    MessageBox.Show("Signature verification file deleted. The program will now close.", "Ultimate blue screen simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                    break;
                case "c":
                    ExitSplash();
                    UIActions.GetOS(Program.f1);
                    break;
                case "doneupdate":
                    File.Delete("BSSP.exe");
                    break;
                case "random":
                    Program.f1.RandFunction(false);
                    break;
                case "hwm":
                    ForceBool("watermark", false);
                    break;
                case "legacy":
                    Program.force_legacy = true;
                    break;
                case "config":
                case "file":
                case "wv":
                    checkvalue = true;
                    break;
            }
        }

        ///<summary>
        ///Processes arguments which should be dealt with last
        ///</summary>
        private void PostProcess()
        {
            //hide main interface if /h flag is set
            if (args.Contains("/h"))
            {
                Program.gs.Log("Info", "Hiding main interface");
                Program.f1.WindowState = FormWindowState.Minimized;
                Program.f1.ShowInTaskbar = false;
                Program.f1.ShowIcon = false;
                Program.gs.PM_CloseMainUI = true;
                if (!args.Contains("/c"))
                {
                    Program.gs.ErrorCode = 1;
                }
            }
            //Simulate crash if /c flag is set
            if (args.Contains("/c"))
            {
                Program.gs.Log("Info", "Starting simulation from command line");
                UIActions.Crash(Program.f1);
            }
            //Post update scripts
            if (args.Contains("/finalize_update"))
            {
                Program.gs.Log("Info", $"Performing update (Stage 2)");
                UpdateInterface ui = new UpdateInterface
                {
                    finalize = true
                };
                Application.Run(ui);
                Program.halt = true;
            }
        }

        ///<summary>
        ///Returns true if splash screen cannot be displayed
        ///</summary>
        public bool CheckNoSplash()
        {
            return this.args.Contains("/finalize_update") || this.args.Contains("/hidesplash");
        }

        ///<summary>
        ///Returns true if splash screen preview is enabled
        ///</summary>
        public bool CheckPreviewSplash()
        {
            return this.args.Contains("/preview_splash");
        }
    }
}
