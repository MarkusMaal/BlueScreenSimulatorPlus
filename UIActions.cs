using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;
using Microsoft.Win32;
using SimulatorDatabase;
using static System.Windows.Forms.Design.AxImporter;

namespace UltimateBlueScreenSimulator
{
    public static class UIActions
    {
        public static ThreadStart ts;
        public static Thread bsod_starter;
        public static BlueScreen me;
        public static WindowScreen specialwindow;
        public static string version = Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(0, 1) + "." + Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(1);

        /// <summary>
        /// Hides controls related to settings from current form
        /// </summary>
        /// <param name="f">Current form (can be Main or NewUI)</param>
        public static void HideSelection(Control f)
        {
            //hide all controls
            FlowLayoutPanel container = ((FlowLayoutPanel)FindControl(f, "flowLayoutPanel1"));
            if (f is FlowLayoutPanel panel) container = panel;
            if (container is null)
            {
                return;
            }

            foreach (Control c in container.Controls)
            {
                if (c is FlowLayoutPanel)
                {
                    HideSelection(c);
                }
                switch (c.Name)
                {
                    case "WXOptions":
                    case "errorCode":
                    case "crashDumpBox":
                    case "nineXmessage":
                    case "serverBox":
                    case "greenBox":
                    case "qrBox":
                    case "checkBox1":
                    case "winMode":
                    case "acpiBox":
                    case "amdBox":
                    case "stackBox":
                    case "ntPanel":
                    case "memoryBox":
                    case "dumpBox":
                    case "winPanel":
                    case "advNTButton":
                    case "eCodeEditButton":
                    case "devPCBox":
                    case "playSndBox":
                    case "countdownBox":
                    case "progressTuneButton":
                    case "halfBox":
                    case "troubleshootBox":
                    case "blackScreenBox":
                    case "panel2":
                        c.Visible = false;
                        Program.gs.Log("Info", $"Hiding {c}");
                        break;
                    case "checkBox2":
                        c.Visible = true;
                        break;
                    case "embedExeButton":
                        c.Visible = !Program.templates.qaddeTrip;
                        break;
                }
                switch (c.Name)
                {
                    case "addInfFile":
                        c.Enabled = false;
                        break;
                    case "dumpBox":
                    case "checkBox2":
                        c.Enabled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Find a control from a container (recursive search)
        /// </summary>
        /// <param name="container">The container where to search the control from</param>
        /// <param name="Name">Name of the control you want to find</param>
        /// <returns>Control with the specified name</returns>
        private static Control FindControl(Control container, string Name)
        {
            Program.gs.Log("Info", $"Searching for {Name} from {container.Name}");
            foreach (Control c in container.Controls)
            {
                Control FoundControl = null;
                if (c is FlowLayoutPanel flp)
                {
                    FoundControl = FindControl(flp, Name);
                }
                else if (c is Panel p)
                {
                    FoundControl = FindControl(p, Name);
                }
                else if (c is MaterialTabControl tc)
                {
                    FoundControl = FindControl(tc, Name);
                }
                else if (c is TabPage tp)
                {
                    FoundControl = FindControl(tp, Name);
                }
                if (FoundControl != null)
                {
                    return FoundControl;
                }
                if (c.Name == Name)
                {
                    return c;
                }
            }
            return null;
        }

        /// <summary>
        /// Allows you to check or uncheck either a CheckBox or MaterialCheckbox from a container
        /// </summary>
        /// <param name="container">The container to search the control from</param>
        /// <param name="Name">Name of the control</param>
        /// <param name="Checked">Check value you want to apply to the control</param>
        /// <exception cref="FormatException">The type of the control is invalid</exception>
        private static void SetControlChecked(Control container, string Name, bool Checked)
        {
            Program.gs.Log("Info", $"Setting checked to {Checked} for {Name}");
            Control c = FindControl(container, Name);
            if (c is CheckBox ch)
            {
                ch.Checked = Checked;
                return;
            }
            else if (c is MaterialCheckbox mch)
            {
                mch.Checked = Checked;
                return;
            }
            else if (c is RadioButton rb)
            {
                rb.Checked = Checked;
                return;
            }
            else if (c is MaterialRadioButton mrb)
            {
                mrb.Checked = Checked;
                return;
            }
            throw new FormatException();
        }

        /// <summary>
        /// Allows you to show or hide a control from a specific container
        /// </summary>
        /// <param name="container">The container to search the control from</param>
        /// <param name="Name">Name of the control</param>
        /// <param name="Visible">Visible value you want to apply to the control</param>
        private static void SetControlVisible(Control container, string Name, bool Visible)
        {
            Program.gs.Log("Info", $"Setting visible to {Visible} for {Name}");
            FindControl(container, Name).Visible = Visible;
        }

        /// <summary>
        /// Allows you to enable or disable a control from a specific container
        /// </summary>
        /// <param name="container">The container to search the control from</param>
        /// <param name="Name">Name of the control</param>
        /// <param name="Visible">Enabled value you want to apply to the control</param>
        private static void SetControlEnabled(Control container, string Name, bool Enabled)
        {
            Program.gs.Log("Info", $"Setting enabled to {Enabled} for {Name}");
            FindControl(container, Name).Enabled = Enabled;
        }

        public static void UpdateBool(Form f, CheckBox c)
        {
            if (me == null)
            {
                return;
            }

            Dictionary<string, string> kvp = new Dictionary<string, string>()
            {
                { "autoBox", "autoclose" },
                { "serverBox", "server" },
                { "greenBox", "insider" },
                { "qrBox", "qr" },
                { "memoryBox", "extracodes" },
                { "devPCBox", "device" },
                { "blackScreenBox", "blackscreen" },
                { "addInfFile", "extrafile" },
                { "amdBox", "amd" },
                { "stackBox", "stack_trace" },
                { "blinkBox", "blink" },
                { "acpiBox", "acpi" },
                { "waterBox", "watermark" },
                { "checkBox1", "show_description" },
                { "dumpBox", "autoclose" },
                { "playSndBox", "playsound" },
                { "countdownBox", "countdown" },
                { "displayOsBox", "bootscreen" },
                { "halfBox", "halfres" },
                { "rainbowBox", "rainbow" },
                { "troubleshootBox", "troubleshoot" },
                { "winMode", "windowed" },
                { "checkBox2", "show_file" },
                { "crashDumpBox", "crashdump" }
            };

            switch (c.Name)
            {
                case "acpiBox":
                    SetControlEnabled(f, "dumpBox", !c.Checked);
                    SetControlChecked(f, "dumpBox", !c.Checked);
                    break;
                case "halfBox":
                    SetControlEnabled(f, "winPanel", !c.Checked);
                    if (me.GetBool("halfres"))
                    {
                        SetControlChecked(f, "nostartup", true);
                    }
                    break;
                case "checkBox2":
                    SetControlEnabled(f, "textBox2", c.Checked);
                    SetControlEnabled(f, "button2", c.Checked);
                    break;
                case "winMode":
                    SetControlVisible(f, "label7", !c.Checked);
                    break;
            }
            if (kvp.Keys.Contains(c.Name))
            {
                me.SetBool(kvp[c.Name], c.Checked);
            } else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Sets the visibility and values of setting controls on the current form
        /// </summary>
        /// <param name="f">Main or NewUI form object</param>
        /// <param name="me">Selected template</param>
        public static void ResetSelection(Form f, BlueScreen me)
        {
            //progressTunerToolStripMenuItem.Enabled = fal
            FlowLayoutPanel fp = (FlowLayoutPanel)FindControl(f, "flowLayoutPanel1");
            SetControlVisible(fp, "rainbowBox", me.GetBool("font_support") || me.GetString("os") == "BOOTMGR");
            SetControlEnabled(fp, "addInfFile", false);
            // set control visibility for specific OS-es
            List<string> ExplicitShow = new List<string>();
            switch (me.GetString("os"))
            {
                case "Windows 11 Beta":
                    ExplicitShow.AddRange(new string[] { "WXOptions","errorCode", "winMode", "checkBox1", "memoryBox", "eCodeEditButton", "progressTuneButton", "greenBox", "crashDumpBox" });
                    SetControlVisible(fp, "serverBox", false);
                    SetControlVisible(fp, "blackScreenBox", false);
                    SetControlVisible(fp, "devPCBox", false);
                    SetControlVisible(fp, "qrBox", false);
                    break;
                case "Windows 11":
                    ExplicitShow.AddRange(new string[]
                    {
                        "WXOptions",
                        "serverBox",
                        "qrBox",
                        "errorCode",
                        "checkBox1",
                        "winMode",
                        "memoryBox",
                        "eCodeEditButton",
                        "blackScreenBox",
                        "progressTuneButton"
                    });
                    SetControlVisible(fp, "devPCBox", false);
                    SetControlChecked(fp, "autoBox", true);
                    SetControlChecked(fp, "blackScreenBox", me.GetBool("blackscreen"));
                    break;
                case "Windows 10":
                    ExplicitShow.AddRange(new string[]
                    {
                        "WXOptions",
                        "serverBox",
                        "greenBox",
                        "qrBox",
                        "errorCode",
                        "checkBox1",
                        "winMode",
                        "memoryBox",
                        "eCodeEditButton",
                        "devPCBox",
                        "progressTuneButton"
                    });
                    SetControlVisible(fp, "blackScreenBox", false);
                    SetControlChecked(fp, "autoBox", true);
                    break;
                case "Windows 8/8.1":
                    ExplicitShow.AddRange(new string[]
                    {
                        "WXOptions",
                        "errorCode",
                        "checkBox1",
                        "winMode",
                        "memoryBox",
                        "eCodeEditButton",
                        "progressTuneButton",
                        "blackScreenBox"
                    });
                    SetControlVisible(fp, "crashDumpBox", false);
                    SetControlVisible(fp, "greenBox", false);
                    SetControlVisible(fp, "serverBox", false);
                    SetControlChecked(fp, "blackScreenBox", me.GetBool("blackscreen"));
                    break;
                case "Windows 8 Beta":
                    ExplicitShow.AddRange(new string[]
                    {
                        "errorCode",
                        "winMode",
                        "memoryBox",
                        "eCodeEditButton",
                        "countdownBox"
                    });
                    SetControlEnabled(fp, "checkBox2", false);
                    break;
                case "Windows Vista":
                case "Windows 7":
                    ExplicitShow.AddRange(new string[]
                    {
                        "errorCode",
                        "winMode",
                        "acpiBox",
                        "checkBox1",
                        "autoBox",
                        "dumpBox",
                        "advNTButton",
                        "eCodeEditButton"
                    });
                    SetControlEnabled(fp, "addInfFile", true);
                    //progressTunerToolStripMenuItem.Enabled = true;
                    break;
                case "Windows XP":
                    ExplicitShow.AddRange(new string[]
                    {
                        "errorCode",
                        "winMode",
                        "checkBox1",
                        "autoBox",
                        "dumpBox",
                        "advNTButton",
                        "eCodeEditButton"
                    });
                    SetControlEnabled(fp, "addInfFile", true);
                    break;
                case "Windows 2000":
                    ExplicitShow.AddRange(new string[]
                    {
                        "errorCode",
                        "winMode",
                        "eCodeEditButton",
                        "advNTButton"
                    });
                    SetControlChecked(fp, "checkBox1", true);
                    break;
                case "Windows 9x/Me":
                    ExplicitShow.AddRange(new string[]
                    {
                        "nineXmessage",
                        "winMode",
                        "eCodeEditButton",
                        "panel2"
                    });
                    break;
                case "Windows CE":
                    ExplicitShow.AddRange(new string[]
                    {
                        "winMode",
                        "errorCode"
                    });
                    SetControlChecked(fp, "checkBox2", false);
                    SetControlEnabled(fp, "checkBox2", false);
                    SetControlEnabled(fp, "textBox2", false);
                    break;
                case "Windows NT 3.x/4.0":
                    ExplicitShow.AddRange(new string[]
                    {
                        "errorCode",
                        "stackBox",
                        "ntPanel",
                        "winMode",
                        "advNTButton",
                        "eCodeEditButton",
                        "troubleshootBox"
                    });
                    SetControlVisible(fp, "amdBox", !me.GetBool("threepointone"));
                    SetControlVisible(fp, "displayOsBox", me.GetBool("threepointone"));
                    break;
                case "Windows 3.1x":
                    SetControlVisible(fp, "winMode", true);
                    break;
                case "Windows 1.x/2.x":
                    ExplicitShow.AddRange(new string[]
                    {
                        "winMode",
                        "winPanel",
                        "playSndBox",
                        "halfBox",
                    });
                    SetControlEnabled(fp, "winPanel", !me.GetBool("halfres"));
                    break;
                case "BOOTMGR":
                    SetControlVisible(fp, "winMode", true);
                    break;
            }
            foreach (string s in ExplicitShow)
            {
                SetControlVisible(fp, s, true);
            }
            bool inlist = false;
            foreach (string item in ((ComboBox)FindControl(fp.Controls["errorCode"], "comboBox1")).Items)
            {
                if (item == me.GetString("code"))
                {
                    inlist = true;
                }
            }
            if (fp.Controls["nineXmessage"].Visible)
            {
                ((ComboBox)FindControl(fp, "comboBox2")).Items.Clear();
                foreach (string text in me.GetTexts().Keys)
                {
                    if (text != "Prompt")
                    {
                        ((ComboBox)FindControl(fp, "comboBox2")).Items.Add(text);
                    }
                }
            }
            //codeCustomizationToolStripMenuItem.Enabled = eCodeEditButton.Visible;
            //advancedNTOptionsToolStripMenuItem.Enabled = advNTButton.Visible;
            // load options for current bluescreen
            string nx_code;
            try
            {
                nx_code = me.GetCodes()[0].Substring(0, 2);
            }
            catch
            {
                nx_code = "00";
            }
            ((ComboBox)FindControl(fp, "nineXErrorCode")).SelectedIndex = -1;
            for (int i = 0; i < Program.templates.NxErrors.Length; i++)
            {
                string selc = Program.templates.NxErrors[i].Split('\t')[0];
                if (nx_code == selc)
                {
                    ((ComboBox)FindControl(fp, "nineXErrorCode")).SelectedIndex = i;
                }
            }
            Program.gs.Log("Info", "Loading settings for configuration template", me.GetString("friendlyname"));
            SetControlChecked(fp, "autoBox", me.GetBool("autoclose"));
            SetControlChecked(fp, "serverBox", me.GetBool("server"));
            SetControlChecked(fp, "greenBox", me.GetBool("insider"));
            SetControlChecked(fp, "qrBox", me.GetBool("qr"));
            SetControlChecked(fp, "checkBox1", me.GetBool("show_description"));
            SetControlChecked(fp, "checkBox2", me.GetBool("show_file"));
            SetControlChecked(fp, "amdBox", me.GetBool("amd"));
            SetControlChecked(fp, "stackBox", me.GetBool("stack_trace"));
            SetControlChecked(fp, "blinkBox", me.GetBool("blink"));
            SetControlChecked(fp, "acpiBox", me.GetBool("acpi"));
            SetControlChecked(fp, "playSndBox", me.GetBool("playsound"));
            SetControlChecked(fp, "waterBox", me.GetBool("watermark"));
            SetControlChecked(fp, "winMode", me.GetBool("windowed"));
            SetControlChecked(fp, "countdownBox", me.GetBool("countdown"));
            SetControlChecked(fp, "displayOsBox", me.GetBool("bootscreen"));
            SetControlChecked(fp, "halfBox", me.GetBool("halfres"));
            SetControlChecked(fp, "rainbowBox", me.GetBool("rainbow"));
            SetControlChecked(fp, "memoryBox", me.GetBool("extracodes"));
            SetControlChecked(fp, "troubleshootBox", me.GetBool("troubleshoot"));
            SetControlChecked(fp, "crashDumpBox", me.GetBool("crashdump"));
            SetControlVisible(fp, "advNTButton", me.GetFiles().Count > 0);


            FindControl(fp, "textBox2").Text = me.GetString("culprit");
            ((ComboBox)FindControl(fp, "comboBox1")).SelectedItem = me.GetString("code");
            ((ComboBox)FindControl(fp, "comboBox2")).SelectedItem = me.GetString("screen_mode");

            if (((CheckBox)FindControl(fp, "acpiBox")).Checked)
            {
                SetControlEnabled(fp, "dumpBox", false);
            }
            SetControlChecked(fp, "win1startup", false);
            SetControlChecked(fp, "win2startup", false);
            SetControlChecked(fp, "nostartup", false);
            switch (me.GetString("qr_file"))
            {
                case "local:0":
                    SetControlChecked(fp, "win1startup", true);
                    break;
                case "local:1":
                    SetControlChecked(fp, "win2startup", true);
                    break;
                case "local:null":
                    SetControlChecked(fp, "nostartup", true);
                    break;
            }
        }


        /// <summary>
        /// Get the current OS and automatically select a template based on it
        /// </summary>
        /// <param name="f">Name of the form to set the selection for</param>
        public static void GetOS(Form f)
        {
            Control fp = f;
            ComboBox wv = ((ComboBox)FindControl(fp, "windowVersion"));
            wv.Items.Clear();
            for (int i = Program.templates.Count - 1; i >= 0; i--)
            {
                wv.Items.Add(Program.templates.GetAt(i).GetString("friendlyname"));
            }
            SetControlVisible(fp, "WXOptions", false);
            SetControlVisible(fp, "errorCode", false);
            SetControlVisible(fp, "nineXmessage", false);
            SetControlVisible(fp, "serverBox", false);
            SetControlVisible(fp, "greenBox", false);
            SetControlVisible(fp, "qrBox", false);
            SetControlVisible(fp, "checkBox1", false);
            SetControlVisible(fp, "winMode", false);
            SetControlVisible(fp, "acpiBox", false);
            SetControlVisible(fp, "amdBox", false);
            SetControlVisible(fp, "stackBox", false);
            SetControlVisible(fp, "ntPanel", false);
            SetControlEnabled(fp, "checkBox2", true);
            if (wv.Items.Count > 0) { wv.SelectedIndex = 0; }
            string winver = "";
            int os_build = 0;
            /*if (specificos != "")
            {
                winver = specificos;
                specificos = "";
            }*/
            try
            {
                winver = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "").ToString();
                os_build = Convert.ToInt32(Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CurrentBuild", "0").ToString());
            }
            catch
            {
                if (os_build == 0)
                {
                    Program.gs.Log("Error", "CurrentBuild missing, Windows registry may be corrupted...");
                }
                if (winver == "")
                {
                    Program.gs.Log("Error", "ProductName missing, Windows registry may be corrupted...");
                }
            }
            //this code identifies Windows 11
            if (os_build >= 22000)
            {
                SetOS("Windows 11 (", f);
            }
            //this code identifies Windows 10
            else if (winver.Contains("Windows 10"))
            {
                SetOS("Windows 10", f);
            }
            //this code identifies Windows 8 or Windows 8.1
            else if (winver.Contains("Windows 8"))
            {
                SetOS("Windows 8", f);
            }
            //this code identifies Windows 7
            else if (winver.Contains("Windows 7"))
            {
                SetOS("Windows 7", f);
            }
            //this code identifies Windows Vista
            else if (winver.Contains("Windows Vista"))
            {
                SetOS("Windows Vista", f);
            }
            //this code identifies Windows XP
            else if (winver.Contains("Windows XP"))
            {
                SetOS("Windows XP", f);
            }
            //this code identifies Windows 2000
            else if ((winver.Contains("Windows 2000")) || (winver.Contains("Windows NT 5")))
            {
                SetOS("Windows 2000", f);
            }
            //this code identifies Windows 95 or Windows 98
            else if ((winver.Contains("Windows 95")) || (winver.Contains("Windows 98")))
            {
                SetOS("Windows 9x", f);
            }
            //this code identifies old Windows NT versions
            else if ((winver.Contains("Windows NT 4")) || (winver.Contains("Windows NT 3")))
            {
                SetOS("Windows NT", f);
            }
        }

        /// <summary>
        /// Sets OS selection based on the host version
        /// </summary>
        /// <param name="winver">Your Windows version (e.g. Windows Vista)</param>
        /// <param name="f">Name of the form to set the selection for</param>
        private static void SetOS(string winver, Form f)
        {
            Control fp = f;
            ComboBox wv = ((ComboBox)FindControl(fp, "windowVersion"));
            for (int i = 0; i < wv.Items.Count; i++)
            {
                if (wv.Items[i].ToString().Contains(winver))
                {
                    wv.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// Perform neccessary steps for initializing a form
        /// </summary>
        /// <param name="f">Name of the form to initialize</param>
        public static void InitializeForm(Form f)
        {
            if (Program.gs.ErrorCode != 0)
            {
                ProcessErrors(f);
            }
            string verStr = Convert.ToDouble(version.Replace(".", ",")).ToString().Replace(",", ".");
            while (verStr.EndsWith("0"))
            {
                verStr = verStr.Substring(0, verStr.Length - 1);
            }
            if (!verStr.Contains("."))
            {
                verStr += ".0";
            }
            f.Text = $"Blue Screen Simulator Plus {verStr}";
            if (Program.gs.DevBuild)
            {
                f.Text += "          // UNDER CONSTRUCTION //";
            }
            ((ComboBox)FindControl(f, "windowVersion")).Items.Clear();
            for (int i = Program.templates.Count - 1; i >= 0; i--)
            {
                ((ComboBox)FindControl(f, "windowVersion")).Items.Add(Program.templates.GetAt(i).GetString("friendlyname"));
            }
            //SetControlVisible(fp, "WXOptions", false);
            SetControlVisible(f, "errorCode", false);
            SetControlVisible(f, "nineXmessage", false);
            SetControlVisible(f, "serverBox", false);
            SetControlVisible(f, "greenBox", false);
            SetControlVisible(f, "qrBox", false);
            SetControlVisible(f, "checkBox1", false);
            SetControlVisible(f, "winMode", false);
            SetControlVisible(f, "acpiBox", false);
            SetControlVisible(f, "amdBox", false);
            SetControlVisible(f, "stackBox", false);
            SetControlVisible(f, "ntPanel", false);
            SetControlEnabled(f, "checkBox2", true);
            if (((ComboBox)FindControl(f, "windowVersion")).Items.Count > 0) { ((ComboBox)FindControl(f, "windowVersion")).SelectedIndex = 0; }
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
            if (Program.gs.DisplayOne)
            {
                ((ComboBox)FindControl(f, "windowVersion")).Items.Clear();
                for (int i = Program.templates.Count - 1; i >= 0; i--)
                {
                    ((ComboBox)FindControl(f, "windowVersion")).Items.Add(Program.templates.GetAt(i).GetString("friendlyname"));
                }
                ((ComboBox)FindControl(f, "windowVersion")).SelectedItem = me.GetString("friendlyname");
                if (f is Main)
                {
                    SetControlVisible(f, "windowVersion", false);
                    FindControl(f, "label1").Text = "Selected preset: " + ((ComboBox)FindControl(f, "windowVersion")).SelectedItem.ToString();
                    FindControl(f, "linkLabel1").Location = new Point(FindControl(f, "label1").Location.X + FindControl(f, "label1").Width, FindControl(f, "linkLabel1").Location.Y);
                    FindControl(f, "linkLabel1").Visible = true;
                }
            }
            else
            {
                GetOS(f);
            }
            if (Program.gs.PM_CloseMainUI)
            {
                f.WindowState = FormWindowState.Minimized;
                f.Hide();
                return;
            }
        }

        /// <summary>
        /// Display an error message to the user if something goes wrong
        /// </summary>
        /// <param name="f">Name of the form, which to display the message for</param>
        private static void ProcessErrors(Form f)
        {
            Program.clip.ExitSplash(f);

            switch (Program.gs.ErrorCode)
            {
                case 0:
                    break;
                case 1:
                    MessageBox.Show("No command specified in hidden mode\nAre you missing the /c argument?\n\n0x001: COMMAND_DEADLOCK", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Program.halt = true;
                    Application.Exit();
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
                    Application.Exit();
                    f.Close();
                    break;
            }
        }

        /// <summary>
        /// Start simulation
        /// </summary>
        /// <param name="f">Name of the form which triggered the crash</param>
        public static void ShowBlueScreen(Form f)
        {
            if (((ComboBox)FindControl(f, "windowVersion")).Items.Count < 1)
            {
                Program.loadfinished = true;
                if (Program.gs.EnableEggs && (Program.gs.ErrorCode != 500))
                {
                    MessageBox.Show("Please select a Windows version! Also, how in the world did you deselect a dropdown list?", "Error displaying crash screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Program.gs.ErrorCode == 500)
                {
                    Thread.CurrentThread.Abort();
                    return;
                }
                else
                {
                    MessageBox.Show("No configuration selected", "Error displaying crash screen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            me.Show();
            Thread.CurrentThread.Abort();
        }

        /// <summary>
        /// Start simulation without checks
        /// </summary>
        /// <param name="f">Name of the form that triggered the crash</param>
        public static void Crash(Form f)
        {
            ts = new ThreadStart(() => { ShowBlueScreen(f); });
            bsod_starter = new Thread(ts);
            bsod_starter.Start();
        }

        /// <summary>
        /// Generate a random bugcheck based on a seed
        /// </summary>
        /// <param name="f">Name of the form, where the seed is entered</param>
        /// <param name="shiftDown">Is the user holding down the SHIFT key? If they are, force the generator to use the selected OS</param>
        /// <returns>Generated bugcheck</returns>
        public static BlueScreen RandFunction(Form f, bool shiftDown)
        {
            Control tb1;
            if (f is MaterialForm)
            {
                tb1 = FindControl(f, "textBox1") as MaterialTextBox2;
            } else
            {
                tb1 = FindControl(f, "textBox1") as TextBox;
            }
            CheckBox winMode = (CheckBox)FindControl(f, "winMode");
            CheckBox waterBox = (CheckBox)FindControl(f, "waterBox");
            ComboBox comboBox1 = (ComboBox)FindControl(f, "comboBox1");
            ComboBox comboBox2 = (ComboBox)FindControl(f, "comboBox2");
            if (me == null) { me = new BlueScreen(); }
            ulong seed = (ulong)DateTime.Now.Ticks;
            bool isNumeric = ulong.TryParse(tb1.Text, out _);
            if (tb1.Text != "")
            {
                if (!isNumeric)
                {
                    seed = BinaryPrimitives.ReadUInt64BigEndian(GetHash(tb1.Text));
                }
                else
                {
                    seed = ulong.Parse(tb1.Text);
                }
            }
            Random r = new Random((int)seed);
            string base_os = Program.templates.GetAt(r.Next(Program.templates.Count - 1)).GetString("os");
            if (shiftDown)
            {
                base_os = me.GetString("os");
            }
            BlueScreen bs = new BlueScreen(base_os, true, r);
            foreach (string kvp in bs.AllBools().Keys.ToArray<string>())
            {
                bool value = r.Next(0, 100) > 50;
                bs.SetBool(kvp, value);
            }
            foreach (string kvp in bs.AllInts().Keys.ToArray<string>())
            {
                if (!kvp.Contains("margin"))
                {
                    int value = r.Next(0, 1000);
                    bs.SetInt(kvp, value);
                }
            }
            if (r.Next(0, 100) > 75)
            {
                Color[] c1 = RandInvColor(r);
                Color[] c2 = RandInvColor(r);
                bs.SetTheme(c1[0], c1[1], false);
                bs.SetTheme(c2[0], c2[1], true);
            }
            if (r.Next(0, 100) > 95)
            {
                bs.SetString("emoticon", ":)");
            }
            if (comboBox1.Items.Count == 0) { Program.ReloadNTErrors(); }
            bs.SetString("code", comboBox1.Items[r.Next(0, comboBox1.Items.Count - 1)].ToString());
            if (bs.GetString("os") != "Windows 3.1x")
            {
                bs.SetString("screen_mode", comboBox2.Items[r.Next(0, comboBox2.Items.Count - 1)].ToString());
            }
            bs.SetBool("troubleshoot", r.Next(0, 100) > 50);
            bs.SetBool("rainbow", r.Next(0, 100) > 50);
            bs.SetBool("windowed", winMode.Checked);
            bs.SetBool("amd", winMode.Checked);
            bs.SetBool("blink", winMode.Checked);
            bs.SetBool("watermark", waterBox.Checked);
            bs.SetString("culprit", me.GenFile());
            if (isNumeric && (tb1.Text != ""))
            {
                bs.SetString("friendlyname", "Random template #" + seed.ToString());
            }
            else if (tb1.Text == "")
            {
                bs.SetString("friendlyname", "Random template #" + seed.ToString() + " (from clock time)");
            }
            else
            {
                bs.SetString("friendlyname", "Random template #" + seed.ToString() + " (seed: " + tb1.Text + ")");
            }
            Thread th = new Thread(new ThreadStart(() => {
                bs.Show();
            }));
            th.Start();
            th.Join();
            return bs;
        }

        /// <summary>
        /// Generates a SHA256 hash based on a string
        /// </summary>
        /// <param name="inputString">String, which we use to generate the hash</param>
        /// <returns>SHA256 hash based on the input string</returns>
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        /// <summary>
        /// Generate a random color and an inverse for that random color
        /// </summary>
        /// <param name="r">Random number generator</param>
        /// <returns>Color array containing both the random color and the inverted color</returns>
        private static Color[] RandInvColor(Random r)
        {
            Color gen = Color.FromArgb(r.Next(0, 255), r.Next(255, 255), r.Next(0, 255));
            Color inv = Color.FromArgb(255 - gen.R, 255 - gen.G, 255 - gen.B);
            return new Color[] { gen, inv };
        }

        /// <summary>
        /// Generate a dictionary from a list of controls
        /// </summary>
        /// <param name="controls">Array of controls you want to turn into a dictionary</param>
        /// <returns>Keys containing the names of the controls and values, which contain the controls themselves</returns>
        public static Dictionary<string, Control> GenerateControlDictionary(Control[] controls)
        {
            Dictionary<string, Control> result = new Dictionary<string, Control>();
            foreach (Control control in controls)
            {
                result[control.Name] = control;
            }
            return result;
        }

        /// <summary>
        /// Generate a dictionary from a list of radio buttons
        /// </summary>
        /// <param name="controls">Array of radiobuttons you want to turn into a dictionary</param>
        /// <returns>Keys containing the names of the controls and values, which contain the radio buttons themselves</returns>
        public static Dictionary<string, MaterialRadioButton> GenerateRadioButtonDictionary(MaterialRadioButton[] controls)
        {
            Dictionary<string, MaterialRadioButton> result = new Dictionary<string, MaterialRadioButton>();
            foreach (MaterialRadioButton control in controls)
            {
                result[control.Name] = control;
            }
            return result;
        }

    }
}
