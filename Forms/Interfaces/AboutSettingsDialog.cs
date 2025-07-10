using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using SimulatorDatabase;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using MaterialSkin2Framework.Controls;
using MaterialSkin2Framework;
using System.Text;
using System.Text.Json;
using System.Windows.Media.Animation;
using UltimateBlueScreenSimulator.Forms.Interfaces;

namespace UltimateBlueScreenSimulator
{
    partial class AboutSettingsDialog : MaterialForm
    {
        //If this flag is set, then help tabs are hidden and setting tabs are visible
        public bool SettingTab = false;
        public int tab_id = 0;
        public bool finished = false;
        internal bool Demo = false;
        private readonly Random r = new Random();
        private int reelTime = 0;
        private bool closed = false;


        public AboutSettingsDialog()
        {
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            string all = "All bluescreen simulator plus configuration files|" + string.Join(";", Program.templates.filters.Values) + "|";
            StringBuilder filters = new StringBuilder();
            foreach (KeyValuePair<string, string> filter in Program.templates.filters)
            {
                filters.Append(filter.Key) // description
                        .Append("|")
                        .Append(filter.Value) // filter
                        .Append("|");
            }
            loadBsconfig.Filter = all + filters.ToString().Substring(0, filters.Length - 1);
            saveBsconfig.Filter = filters.ToString().Substring(0, filters.Length - 1);
            //Get assembly information about the program
            this.Text = String.Format("About {0}", AssemblyTitle);
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

        }

        public static void GetAbout(Dictionary<string, Control> controls)
        {
            controls["labelProductName"].Text = "Blue Screen Simulator Plus";
            if (Program.gs.DevBuild) {
                controls["labelProductName"].Text += "[Development Build]"; }
            string asmVer = AssemblyVersion.Replace(".0", "");
            if (!asmVer.Contains("."))
            {
                asmVer += ".0";
            }
            controls["labelVersion"].Text = String.Format("Version {0} with Verifile 1.2", asmVer);
            controls["labelCopyright"].Text = AssemblyCopyright;
            controls["labelCompanyName"].Text = "Codename LotsaSpaghetti\nLanguage: C# (.NET framework, Windows Forms)\nCreated by: Markus Maal a.k.a. MarkusTegelane\n\nThis program can only be provided free of charge (if you had to pay for this, please ask for a refund). This program is provided as is, without a warranty.\nMarkuse tarkvara (Markus' software)";
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void SetInitalInterface(object sender, EventArgs e)
        {
            //Ping main form that the about box/help/settings dialog is open
            if (Demo)
            {
                demoReelTimer.Enabled = true;
                return;
            }
            Program.f1.abopen = true;
            rtlSwitch.Visible = Program.gs.DevBuild;
            //Hide settings tabs
            //Hide help/about tabs and get settings
            if (SettingTab)
            {
                eggHunterButton.Checked = Program.gs.EnableEggs;
                darkDetectCheck.Checked = Program.gs.AutoDark;
                materialSwitch1.Checked = Program.gs.QuickHelp;
                helpTip.Active = Program.gs.QuickHelp;
                accentBox.SelectedIndex = (int)Program.gs.ColorScheme;
                primaryColorBox.SelectedIndex = (int)Program.gs.PrimaryColor;
                darkMode.Checked = Program.gs.NightTheme;
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.HighQualityBicubic) { scalingModeBox.SelectedIndex = 0; }
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.HighQualityBilinear) { scalingModeBox.SelectedIndex = 1; }
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.Bilinear) { scalingModeBox.SelectedIndex = 4; }
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.Bicubic) { scalingModeBox.SelectedIndex = 3; }
                if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.NearestNeighbour) { scalingModeBox.SelectedIndex = 2; }
                hideInFullscreenButton.Checked = !Program.gs.ShowCursor;
                updateImmediatelyRadio.Checked = !Program.gs.UpdateAfterExit;
                updateOnCloseRadio.Checked = Program.gs.UpdateAfterExit;
                noUpdatesRadio.Checked = !Program.gs.AutoUpdate;
                autoUpdateRadio.Checked = Program.gs.AutoUpdate;
                hashBox.Checked = Program.gs.HashVerify;
                primaryServerBox.Text = Program.gs.UpdateServer;
                legacyInterfaceCheck.Checked = Program.gs.LegacyUI;
                if (!((primaryServerBox.Text == "http://nossl.markustegelane.eu/app") || (primaryServerBox.Text == "http://markustegelane.eu/app")))
                {
                    primaryServerBox.Enabled = true;
                }
                aboutSettingsTabControl.TabIndex++;
                aboutSettingsTabControl.TabIndex--;
            }
            aboutSettingsTabControl.SelectedIndex = tab_id;
        }

        private void TabSwitcher(object sender, EventArgs e)
        {
            //Perform specific actions when switching to a specific tab
            if (aboutSettingsTabControl.SelectedTab.Text == "Update settings")
            {
                //I/O test, to make sure that it is possible to write data to current media. If not, then some options become disabled.
                try
                {
                    File.WriteAllText("iotest", "This is a test");
                    File.Delete("iotest");
                } catch
                {
                    noticeLabel.Text = "Cannot write to current directory. Settings will not be saved.";
                    unsignButton.Enabled = false;
                    updateCheckButton.Enabled = false;
                    autoUpdateRadio.Enabled = false;
                }
                //Loads update configuration
                autoUpdateRadio.Checked = Program.gs.AutoUpdate;
                noUpdatesRadio.Checked = !Program.gs.AutoUpdate;
                darkDetectCheck.Checked = Program.gs.AutoDark;
                hashBox.Checked = Program.gs.HashVerify;
                updateImmediatelyRadio.Checked = !Program.gs.PostponeUpdate;
                updateOnCloseRadio.Checked = Program.gs.PostponeUpdate;
                primaryServerBox.Text = Program.gs.UpdateServer;
                if (!((primaryServerBox.Text == "http://nossl.markustegelane.eu/app") || (primaryServerBox.Text == "http://markustegelane.eu/app")))
                {
                    primaryServerBox.Enabled = true;
                }
                primaryServerBox.Update();
            }
            if (aboutSettingsTabControl.SelectedTab.Text == "Simulator settings")
            {
                //Loads simulator configuration
                eggHunterButton.Checked = Program.gs.EnableEggs;
                autosaveCheck.Checked = Program.gs.Autosave;
                switch (Program.gs.ScaleMode)
                {
                    case GlobalSettings.ScaleModes.HighQualityBicubic:
                        scalingModeBox.SelectedIndex = 0;
                        break;
                    case GlobalSettings.ScaleModes.HighQualityBilinear:
                        scalingModeBox.SelectedIndex = 1;
                        break;
                    case GlobalSettings.ScaleModes.Bilinear:
                        scalingModeBox.SelectedIndex = 4;
                        break;
                    case GlobalSettings.ScaleModes.Bicubic:
                        scalingModeBox.SelectedIndex = 3;
                        break;
                    case GlobalSettings.ScaleModes.NearestNeighbour:
                        scalingModeBox.SelectedIndex = 2;
                        break;
                }
                switch (Program.gs.DisplayMode)
                {
                    case "none":
                        multiDisplayBox.SelectedIndex = 0;
                        break;
                    case "blank":
                        multiDisplayBox.SelectedIndex = 1;
                        break;
                    case "mirror":
                        multiDisplayBox.SelectedIndex = 2;
                        break;
                    case "freeze":
                        multiDisplayBox.SelectedIndex = 3;
                        break;
                }
                hideInFullscreenButton.Checked = !Program.gs.ShowCursor;
                configList.Items.Clear();
                randomnessCheckBox.Checked = Program.gs.Randomness;
                foreach (BlueScreen bs in Program.templates.GetAll())
                {
                    configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                }
                devFlowPanel.Visible = Program.gs.DevBuild;
            }
        }

        //Help texts
        public static void QuickHelp_Help(Control c)
        {
            c.Text = "How to quickly get help?\n\nFor items that have [?] at the end, you can just hover over them for more information.".Replace("\n", Environment.NewLine);
        }

        public static void QuickHelp_Purpose(Control c)
        {
            c.Text = "What is the purpose of this program?\n\nThis program can be used as a way of screenshotting bluescreens without actually crashing your computer or messing with virtual machines. You can also use this program for pranking purposes (no harm will be done to the system).".Replace("\n", Environment.NewLine);
        }

        public static void QuickHelp_SystemRequirements(Control c)
        {
            c.Text = "System requirements:\n\nOS: Windows 7 or later (Windows Vista partially works as well)\nInstalled fonts: Segoe UI (with Semilight variant), Consolas, Lucida Console\n200MB of available RAM (recommended minimum)\n100MB of available RAM (absolute minimum)\nx86 or compatible processor\nRead-Write storage media\nMicrosoft.NET Framework 4.8.1\n1000+ bps internet connection (for updates and online help functionality)\nScreen resolution: 1024x720 or higher (1280x720 or higher recommended)".Replace("\n", Environment.NewLine);
        }

        //Closes the dialog and sets dialogresult to ok
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UnsignMe(object sender, EventArgs e)
        {
            //Removes verification signature from the system
            try
            {
                if (File.Exists(Environment.GetEnvironmentVariable("USERPROFILE") + "\\bssp2_firstlaunch.txt"))
                {
                    File.Delete(Environment.GetEnvironmentVariable("USERPROFILE") + "\\bssp2_firstlaunch.txt");
                    MessageBox.Show("Signature removed successfully.", "Verifile verification system", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) when (!Debugger.IsAttached)
            {
                MessageBox.Show("Something went wrong. Please send the following details to the developer:\n\n" + ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        private void CheckForUpdates(object sender, EventArgs e)
        {
            //This code starts the check for updates
            if (Program.DoWeHaveInternet(1000))
            {
                if (File.Exists(Program.prefix + "vercheck.txt"))
                {
                    File.Delete(Program.prefix + "vercheck.txt");
                }
                UpdateInterface ui = new UpdateInterface();
                ui.DownloadFile(Program.gs.UpdateServer + "/bssp_version.txt", Program.prefix + "vercheck.txt");
                updateCheckButton.Enabled = false;
                updateCheckButton.Text = "Please wait now ...";
                updateCheckerTimer.Enabled = true;
                Program.f1.updateCheckerTimer.Interval = 5998;
                Program.f1.updateCheckerTimer.Enabled = true;
            } else
            {
                MessageBox.Show("No internet connection available", "Couldn't check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //Checks if check for updates has finished
            if (!Program.f1.updateCheckerTimer.Enabled)
            {
                updateCheckerTimer.Enabled = false;
                updateCheckButton.Enabled = true;
                updateCheckButton.Text = "Check for updates";
            }
        }

        //Saves configuration
        private void EnableDisableUpdateSetup(object sender, EventArgs e)
        {
            Program.gs.AutoUpdate = autoUpdateRadio.Checked;
        }

        private void UpdateWhenDoneSetup(object sender, EventArgs e)
        {
            Program.gs.PostponeUpdate = updateImmediatelyRadio.Checked;
        }

        private void HashcheckSetup(object sender, EventArgs e)
        {
            Program.gs.HashVerify = hashBox.Checked;
        }

        private void ScalingModeSetup(object sender, EventArgs e)
        {
            if (scalingModeBox.SelectedIndex == 0)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.HighQualityBicubic;
            }
            else if (scalingModeBox.SelectedIndex == 1)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.HighQualityBilinear;
            }
            else if (scalingModeBox.SelectedIndex == 2)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.NearestNeighbour;
            }
            else if (scalingModeBox.SelectedIndex == 4)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.Bilinear;
            }
            else if (scalingModeBox.SelectedIndex == 3)
            {
                Program.gs.ScaleMode = GlobalSettings.ScaleModes.Bicubic;
            }
        }

        private void CursorVisibilitySetup(object sender, EventArgs e)
        {
            Program.gs.ShowCursor = hideInFullscreenButton.Checked;
        }



        private void ExitMe(object sender, FormClosingEventArgs e)
        {
            //Makes sure that the configuration is saved when closing the form
            Program.f1.abopen = false;
            if (SettingTab && !closed)
            {
                closed = true;
                if (Program.gs.LegacyUI)
                {
                    Program.gs.SaveSettings();
                    Application.Restart();
                    return;
                }
                UIActions.GetOS(Program.f1);
            }
        }

        private void EggHunter(object sender, EventArgs e)
        {
            Program.gs.EnableEggs = eggHunterButton.Checked;
        }

        private void OnMeResized(object sender, EventArgs e)
        {
        }

        private void ConfigSelector(object sender, MaterialListBoxItem e)
        {
            if (e != null)
            {
                osName.Text = string.Format("Selected configuration: {0}", Program.templates.GetAt(configList.SelectedIndex).GetString("friendlyname"));
            } else
            {
                osName.Text = "Select a configuration to modify/remove it";
            }
            resetButton.Enabled = (e != null);
            resetHackButton.Enabled = (e != null);
            removeCfg.Enabled = (e != null);
        }

        private void ConfigHackEraser(object sender, EventArgs e)
        {
            if (configList.SelectedItem != null)
            {
                if (MessageBox.Show("Warning: This will remove any custom settings from this configuration. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to continue?", "Reset bugcheck", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Program.templates.ResetTemplate(configList.SelectedIndex);
                    MessageBox.Show("Configuration was reset", "Reset everything", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else
            {
                if (MessageBox.Show("Would you restore default configurations?", "Seecret factory defaults option", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    configList.Items.Clear();
                    Program.templates.Reset();
                    foreach (BlueScreen bs in Program.templates.GetAll())
                    {
                        configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                    }
                    MessageBox.Show("Configurations were reset", "Seecret factory defaults", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No action was performed.", "Seecret factory defaults", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ResetConfig(object sender, EventArgs e)
        {
            if (configList.SelectedItem != null)
            {
                if (MessageBox.Show("Warning: This will remove any setting set under the 'additional options' menu. Other settings set in the main screen will remain the same. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to continue?", "Reset hacks", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Program.templates.ResetHacks(configList.SelectedIndex);
                    MessageBox.Show("Hacks were reset", "Reset hacks", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else
            {
                if (MessageBox.Show("Would you like to reset everything under the 'additional options' menu to defaults for all configurations?", "Seecret factory hacks defaults", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    configList.Items.Clear();
                    foreach (BlueScreen bs in Program.templates.GetAll())
                    {
                        bs.ClearAllTitleTexts();
                        bs.SetOSSpecificDefaults();
                    }
                    MessageBox.Show("Hacks were reset", "Seecret factory hacks defaults", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No action was performed.", "Seecret factory hacks defaults", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ConfigEraser(object sender, EventArgs e)
        {
            if (configList.SelectedItem != null)
            {
                if (MessageBox.Show("Warning: This will remove this configuration from the repository. ANY UNSAVED CHANGES WILL BE LOST!!! Are you sure you want to do that?", "Delete bugcheck", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    Program.templates.RemoveAt(configList.SelectedIndex);
                    configList.Items.Clear();
                    foreach (BlueScreen bs in Program.templates.GetAll())
                    {
                        configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                    }
                    MessageBox.Show("Config removed successfully", "Configuration deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Reason: The user clicked no", "No changes were made", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else
            {
                if (MessageBox.Show("Would you like to remove all configurations?", "Nuke mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    configList.Items.Clear();
                    Program.templates.Clear();
                    resetHackButton.Enabled = false;
                    resetButton.Enabled = false;
                    removeCfg.Enabled = false;
                    MessageBox.Show("Configurations erased. All configurations must be re-added manually.\nNote: Do not use the main interface before adding any configurations!", "Nuke mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("No action was performed.", "Nuke mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void AddConfig(object sender, EventArgs e)
        {
            if (new AddBluescreen().ShowDialog() == DialogResult.OK)
            {
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.templates.GetAll())
                {
                    configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                }
            }
        }

        private void MultiDisplaySetup(object sender, EventArgs e)
        {
            switch (multiDisplayBox.SelectedIndex)
            {
                case 0: Program.gs.DisplayMode = "none"; break;
                case 1: Program.gs.DisplayMode = "blank"; break;
                case 2: Program.gs.DisplayMode = "mirror"; break;
                case 3: Program.gs.DisplayMode = "freeze"; break;
            }
        }

        private void SaveConfig(object sender, EventArgs e)
        {
            if (Program.templates.qaddeTrip)
            {
                MessageBox.Show("QADDE tripped, cannot save this configuration.\r\n\r\nThis can be solved by either: resetting all configurations, deleting all configurations, restaring the application or loading an existing configuration file.", AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveBsconfig.ShowDialog() == DialogResult.OK)
            {
                Thread t = new Thread(() => Program.templates.SaveData(saveBsconfig.FileName, saveBsconfig.FilterIndex));
                t.Start();
                checkIfLoadedSaved.Enabled = true;
                this.Enabled = false;
            }
        }

        private Color StringToRGB(string rgb)
        {
            string[] splitted_rgb = rgb.Split(',');
            return Color.FromArgb(Convert.ToInt32(splitted_rgb[0]), Convert.ToInt32(splitted_rgb[1]), Convert.ToInt32(splitted_rgb[2]));
        }

        private string RGB_String(Color rgb)
        {
            return rgb.R.ToString() + "," + rgb.G.ToString() + "," + rgb.B.ToString();
        }

        private void ConfigLoader(string filename)
        {
            Program.templates = Program.templates.LoadConfig(filename);
            Program.templates.saveFinished = true;
            Thread.CurrentThread.Abort();
        }

        private void BrowseConfig(object sender, EventArgs e)
        {
            if ((loadBsconfig.FileName != "")||(loadBsconfig.ShowDialog() == DialogResult.OK))
            {
                Thread t = new Thread(() => ConfigLoader(loadBsconfig.FileName));
                t.Start();
                finished = false;
                checkIfLoadedSaved.Enabled = true;
                this.Enabled = false;
            }
        }

        private void DevNewAll(object sender, EventArgs e)
        {
            Program.templates.Reset();
            configList.Items.Clear();
            foreach (BlueScreen bs in Program.templates.GetAll())
            {
                configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
            }
        }

        private void DevDictEdit(object sender, EventArgs e)
        {
            try
            {
                DictEdit de = new DictEdit
                {
                    me = Program.templates.GetAt(configList.SelectedIndex)
                };
                de.Show();
            } catch
            {
                MessageBox.Show("Please select a configuration, silly", AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DevNukeAll(object sender, EventArgs e)
        {
            Program.templates.Clear();
            configList.Items.Clear();
            foreach (BlueScreen bs in Program.templates.GetAll())
            {
                configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
            }
        }

        private void ChangeUpdateServer(object sender, EventArgs e)
        {
            if (primaryServerBox.Text != "")
            {
                Program.gs.UpdateServer = primaryServerBox.Text;
            }
        }

        private void SetToPrimaryServer(object sender, EventArgs e)
        {
            primaryServerBox.Enabled = false;
            primaryServerBox.Text = "http://markustegelane.eu/app";
        }

        private void SetToBackupServer(object sender, EventArgs e)
        {
            primaryServerBox.Enabled = false;
            primaryServerBox.Text = "http://nossl.markustegelane.eu/app";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            primaryServerBox.Enabled = true;
        }

        public static void UserManualButtonClick()
        {
            if (Program.DoWeHaveInternet(1000))
            {
                // online user manual
                Process p = new Process();
                p.StartInfo.FileName = "https://markustegelane.eu/bssp/help.pdf";
                p.Start();
            }
            else
            {
                File.WriteAllBytes(Environment.GetEnvironmentVariable("TEMP") + "\\bssp_manual.pdf", Properties.Resources.BSSP_manual);

                Process p = new Process();
                p.StartInfo.FileName = Environment.GetEnvironmentVariable("TEMP") + "\\bssp_manual.pdf";
                p.Start();
            }
        }

        private void DisplayDevSplashScreen(object sender, EventArgs e)
        {
            Splash spl = new Splash();
            spl.SplashText.Text = "Idling. Press ESC to exit.";
            spl.veriFileTimer.Enabled = false;
            spl.Show();
        }

        private void RestartAll(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void WaitUntilComplete(object sender, EventArgs e)
        {
            if (Program.templates.saveFinished)
            {
                this.Enabled = true;
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.templates.GetAll())
                {
                    configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                }
                loadBsconfig.FileName = "";
                saveBsconfig.FileName = "";
                checkIfLoadedSaved.Enabled = false;
                Program.ReloadNTErrors(); 
            }
        }

        public static void SourceCode(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "https://github.com/MarkusMaal/BlueScreenSimulatorPlus";
            p.Start();
        }

        public static void Copying(object sender, EventArgs e)
        {
            TextView tv = new TextView
            {
                Text = Properties.Resources.COPYING,
                Title = "Copying"
            };
            tv.ShowDialog();
            tv.Dispose();
        }

        public static void RandomFact(object sender, EventArgs e)
        {
            if (Program.gs.EnableEggs)
            {
                string[] tips =
                {
                "Material Design is a design language developed by Google in 2014!",
                "You can close a bugcheck by pressing ALT+F4",
                "There is a crash screen for a program that simulates crash screens, right?",
                "The codename came from a song that was playing in the background during the development process",
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
                "Every major Windows release, up until Windows 11, has had some sort of a blue screen",
                "Blue is a color that symbolises peace",
                "Windows 2000 blue screen didn't use rasterized fonts in previous versions, because I figured it looked 'close enough' to the original",
                "If you use the 'choose' button when setting a culprit file, you might see some weird filenames...",
                "The background of the logo graphic in the about screen displays two major colors used by bugcheck screens - black and blue",
                "This program isn't a copy of FlyTech's work, instead it was developed from scratch, because of the limitations I saw when trying out FlyTech's blue screen simulator.",
                "You can use progress tuner to make more realistic progress indicators for modern bugchecks",
                "There is no random factoid here",
                "target: void"
            };
                Random r = new Random();
                MessageBox.Show(tips[r.Next(0, tips.Length - 1)], "Random fact", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            ProgressTuner pt = new ProgressTuner();
            pt.Show();
            MessageBox.Show("Testing ended");
        }

        private void RandomnessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.Randomness = randomnessCheckBox.Checked;
        }

        private void SelectAllBox_CheckedChanged(object sender, EventArgs e)
        {
            if (selectAllBox.Checked)
            {
                resetHackButton.Enabled = true;
                resetButton.Enabled = true;
                removeCfg.Enabled = true;
                removeCfg.Text = "Remove configs [?]";
                configList.Enabled = false;
                configList.SelectedItem = null;
                helpTip.SetToolTip(resetHackButton, "Deletes everything under the 'additional options' menu for all configurations");
                helpTip.SetToolTip(resetButton, "Reset all settings within all configurations");
                helpTip.SetToolTip(removeCfg, "Removes all configurations. This is useful, if you're making your own custom skin packs and want only a few operating systems to be visible.");
                osName.Text = "All selected";
                configList.SelectedItems.Clear();
                return;
            }
            resetHackButton.Enabled = false;
            resetButton.Enabled = false;
            removeCfg.Enabled = false;
            configList.Enabled = true;
            configList.SelectedItems.Clear();
            removeCfg.Text = "Remove config [?]";
            helpTip.SetToolTip(resetHackButton, "Deletes everything under the 'additional options' menu for this configuration");
            helpTip.SetToolTip(resetButton, "Reset all settings in this configuration");
            helpTip.SetToolTip(removeCfg, "Removes the configuration, meaning it will no longer be accessible in the main menu or any other part of the program.");
            osName.Text = "Select a configuration to modify/remove it";
        }

        public static void Changelog(object sender, EventArgs e)
        {
            MessageBox.Show(Program.changelog + "\n\nYou can find a more detailed changelog in the official BlueScreenSimulatorPlus GitHub page.", "What's new?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void darkDetectCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.AutoDark = darkDetectCheck.Checked;
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            Program.loadfinished = false;
            Gen g = new Gen();
            g.Show();
            Program.load_message = "Testing...";
            Thread dummyThread = new Thread(new ThreadStart(() => {
                for (int i = 0; i <= 100; i++)
                {
                    Program.load_progress = i;
                    Thread.Sleep(50);
                }
                Thread.Sleep(150);
                Program.loadfinished = true;
            }));
            dummyThread.Start();
        }

        private void accentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.gs.ColorScheme = (GlobalSettings.ColorSchemes)accentBox.SelectedIndex;
            Program.gs.ApplyScheme();
        }

        private void darkMode_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.NightTheme = darkMode.Checked;
            if (darkMode.Checked)
            {
                Program.f1.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                Program.f1.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            Program.f1.RelocateButtons();
        }

        private void rtlSwitch_CheckedChanged(object sender, EventArgs e)
        {
            Program.f1.RightToLeft = rtlSwitch.Checked ? RightToLeft.Yes : RightToLeft.Inherit;
        }

        private void materialButton6_Click_1(object sender, EventArgs e)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Program.templates, options);
            TextView tv = new TextView
            {
                Title = "Output",
                Text = jsonString.ToString()
            };
            tv.Show();
        }

        private void configList_DoubleClick(object sender, EventArgs e)
        {
            AddBluescreen ab = new AddBluescreen();
            BlueScreen me = Program.templates.GetAt(configList.SelectedIndex);
            ab.Preload(me);
            if (ab.ShowDialog() == DialogResult.OK)
            {
                configList.Items.Clear();
                foreach (BlueScreen bs in Program.templates.GetAll())
                {
                    configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                }
                osName.Text = string.Format("Selected configuration: {0}", Program.templates.GetAt(configList.SelectedIndex).GetString("friendlyname"));
            }
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.QuickHelp = materialSwitch1.Checked;
            this.helpTip.Active = materialSwitch1.Checked;
        }

        private void helpTip_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl != null)
            {
                if (e.AssociatedControl is MaterialButton mb)
                {
                    helpTip.ToolTipTitle = mb.Text.Replace(" [?]", "");
                }
                else if (e.AssociatedControl is MaterialLabel ml)
                {
                    helpTip.ToolTipTitle = ml.Text.Replace(" [?]", "");
                }
                else if (e.AssociatedControl is MaterialCheckbox mc)
                {
                    helpTip.ToolTipTitle = mc.Text.Replace(" [?]", "");
                }
                else if (e.AssociatedControl is MaterialSwitch ms)
                {
                    helpTip.ToolTipTitle = ms.Text.Replace(" [?]", "");
                }
                else
                {
                    helpTip.ToolTipTitle = "Quick help";
                }
            }
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.gs.PrimaryColor = (GlobalSettings.ColorSchemes)primaryColorBox.SelectedIndex;
            Program.gs.ApplyScheme();

            // applies the color to titlebars immediately
            Program.f1.Refresh();
            Program.f1.nineXmessage.Refresh();
            this.Refresh();
        }

        private void ShowEmbedded(object sender, EventArgs e)
        {
            this.Enabled = false;
            string filename = "";
            string backup = loadBsconfig.Filter;
            loadBsconfig.Filter = "Executables|*.exe";
            if (loadBsconfig.ShowDialog() == DialogResult.OK)
            {
                filename = loadBsconfig.FileName;
            }
            if ((filename != "") && MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
                Program.f1.Hide();
                string jsonString = Program.GetEmbedded(filename);
                if (jsonString != "")
                {
                    if (MessageBox.Show("Embedded data found! Press Yes to preview error message. Press No to view embedded data.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Program.dr = new DrawRoutines();
                        Thread th = new Thread(new ThreadStart(() => {
                            // initialize BlueScreen object
                            UIActions.me = Program.templates.LoadSingleConfig(jsonString);
                            // display the crash screen
                            UIActions.me.Show();
                        }));
                        th.Start();
                        th.Join();
                    }
                    else
                    {
                        TextView tv = new TextView();
                        tv.Text = jsonString;
                        tv.Title = "JSON data";
                        tv.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No embedded data was found.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Program.f1.Show();
                this.Show();
                this.BringToFront();
            }
            loadBsconfig.Filter = backup;
            loadBsconfig.FileName = "";
            this.Enabled = true;
        }

        private void AutosaveCheckChanged(object sender, EventArgs e)
        {
            Program.gs.Autosave = autosaveCheck.Checked;
        }

        private void demoReelTimer_Tick(object sender, EventArgs e)
        {
            if (reelTime < 20)
            {
                primaryColorBox.SelectedIndex = r.Next(0, primaryColorBox.Items.Count - 1);
                accentBox.SelectedIndex = r.Next(0, accentBox.Items.Count - 1);
                darkMode.Checked = r.Next(0, 1) == 1;
            } else
            {
                reelTime = 0;
                demoReelTimer.Enabled = false;
                this.Close();
            }
            reelTime++;
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            // Get primary and accent colors from an empty GlobalSettings object
            GlobalSettings dummy = new GlobalSettings();
            accentBox.SelectedIndex = (int)dummy.ColorScheme;
            primaryColorBox.SelectedIndex = (int)dummy.PrimaryColor;
        }

        private void materialButton11_Click(object sender, EventArgs e)
        {
            accentBox.SelectedIndex = r.Next(0, accentBox.Items.Count - 1);
            primaryColorBox.SelectedIndex = r.Next(0, primaryColorBox.Items.Count - 1);
        }

        private void legacyInterfaceCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.LegacyUI = legacyInterfaceCheck.Checked;
        }

        private void materialButton12_Click(object sender, EventArgs e)
        {
            new TestSuite().Show();
        }

        private void AboutSettingsDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}
