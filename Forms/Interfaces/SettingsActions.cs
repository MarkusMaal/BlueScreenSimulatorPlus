using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using MaterialSkin2Framework;
using MaterialSkin2Framework.Controls;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator.Forms.Interfaces
{
    internal class SettingsActions
    {
        private static bool Lock = true;

        public static void Initialize(OpenFileDialog loadBsconfig, SaveFileDialog saveBsconfig, Dictionary<string, Control> c, ToolTip helpTip)
        {
            Lock = true;
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
            Program.F1.abopen = true;
            
            c["rtlSwitch"].Visible = Program.gs.DevBuild;
            //Hide settings tabs
            //Hide help/about tabs and get settings
            ((MaterialCheckbox)c["eggHunterButton"]).Checked = Program.gs.EnableEggs;
            ((MaterialCheckbox)c["darkDetectCheck"]).Checked = Program.gs.AutoDark;
            ((MaterialSwitch)c["materialSwitch1"]).Checked = Program.gs.QuickHelp;
            helpTip.Active = Program.gs.QuickHelp;
            ((MaterialComboBox)c["accentBox"]).SelectedIndex = (int)Program.gs.ColorScheme;
            ((MaterialComboBox)c["primaryColorBox"]).SelectedIndex = (int)Program.gs.PrimaryColor;
            ((MaterialSwitch)c["darkMode"]).Checked = Program.gs.NightTheme;
            ((MaterialComboBox)c["scalingModeBox"]).SelectedIndex = (int)Program.gs.ScaleMode;
            ((MaterialCheckbox)c["hideInFullscreenButton"]).Checked = !Program.gs.ShowCursor;
            ((MaterialRadioButton)c["updateImmediatelyRadio"]).Checked = !Program.gs.UpdateAfterExit;
            ((MaterialRadioButton)c["updateOnCloseRadio"]).Checked = Program.gs.UpdateAfterExit;
            ((MaterialRadioButton)c["noUpdatesRadio"]).Checked = !Program.gs.AutoUpdate;
            ((MaterialRadioButton)c["autoUpdateRadio"]).Checked = Program.gs.AutoUpdate;
            ((MaterialCheckbox)c["hashBox"]).Checked = Program.gs.HashVerify;
            c["primaryServerBox"].Text = Program.gs.UpdateServer;
            ((MaterialCheckbox)c["legacyInterfaceCheck"]).Checked = Program.gs.LegacyUI;
            if (!((c["primaryServerBox"].Text == "http://nossl.markustegelane.eu/app") || (c["primaryServerBox"].Text == "http://markustegelane.eu/app")))
            {
                c["primaryServerBox"].Enabled = true;
            }
            Lock = false;
        }


        public static void TabSwitcher(Dictionary<string, Control> c)
        {
            Lock = true;
            MaterialTabControl aboutSettingsTabControl = (MaterialTabControl)c["aboutSettingsTabControl"];
            Control noticeLabel = c["noticeLabel"];
            Control unsignButton = c["unsignButton"];
            Control updateCheckButton = c["updateCheckButton"];
            MaterialRadioButton autoUpdateRadio = (MaterialRadioButton)c["autoUpdateRadio"];
            MaterialRadioButton noUpdatesRadio = (MaterialRadioButton)c["noUpdatesRadio"];
            MaterialCheckbox darkDetectCheck = (MaterialCheckbox)c["darkDetectCheck"];
            MaterialCheckbox hashBox = (MaterialCheckbox)c["hashBox"];
            MaterialRadioButton updateImmediatelyRadio = (MaterialRadioButton)c["updateImmediatelyRadio"];
            MaterialRadioButton updateOnCloseRadio = (MaterialRadioButton)c["updateOnCloseRadio"];
            Control primaryServerBox = c["primaryServerBox"];
            MaterialCheckbox eggHunterButton = (MaterialCheckbox)c["eggHunterButton"];
            MaterialCheckbox autosaveCheck = (MaterialCheckbox)c["autosaveCheck"];
            MaterialComboBox scalingModeBox = (MaterialComboBox)c["scalingModeBox"];
            MaterialComboBox multiDisplayBox = (MaterialComboBox)c["multiDisplayBox"];
            MaterialCheckbox hideInFullscreenButton = (MaterialCheckbox)c["hideInFullscreenButton"];
            MaterialListBox configList = (MaterialListBox)c["configList"];
            MaterialCheckbox randomnessCheckBox = (MaterialCheckbox)c["randomnessCheckBox"];
            Control devFlowPanel = c["devFlowPanel"];
            //Perform specific actions when switching to a specific tab
            if (aboutSettingsTabControl.SelectedTab.Text == "Update settings")
            {
                //I/O test, to make sure that it is possible to write data to current media. If not, then some options become disabled.
                try
                {
                    File.WriteAllText("iotest", "This is a test");
                    File.Delete("iotest");
                }
                catch
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
            Lock = false;
        }


        public static void CheckForUpdates(Control updateCheckButton)
        {
            //This code starts the check for updates
            if (Program.DoWeHaveInternet(1000))
            {
                if (File.Exists(Program.prefix + "vercheck.txt"))
                {
                    File.Delete(Program.prefix + "vercheck.txt");
                }
                updateCheckButton.Enabled = false;
                updateCheckButton.Text = "Please wait now ...";
                UIActions.CheckUpdates(Program.F1, updateCheckButton);
            }
            else
            {
                MessageBox.Show("No internet connection available", "Couldn't check for updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RandomTheme(MaterialComboBox accentBox, MaterialComboBox primaryColorBox)
        {
            accentBox.SelectedIndex = BlueScreen.r.Next(0, accentBox.Items.Count - 1);
            primaryColorBox.SelectedIndex = BlueScreen.r.Next(0, primaryColorBox.Items.Count - 1);
        }

        public static void DefaultTheme(MaterialComboBox accentBox, MaterialComboBox primaryColorBox)
        {
            GlobalSettings dummy = new GlobalSettings();
            accentBox.SelectedIndex = (int)dummy.ColorScheme;
            primaryColorBox.SelectedIndex = (int)dummy.PrimaryColor;
        }

        public static void ConfigSelector(Control resetButton, Control resetHackButton, Control removeCfg, MaterialListBox configList, Control osName, MaterialListBoxItem e)
        {
            if (e != null)
            {
                osName.Text = string.Format("Selected configuration: {0}", Program.templates.GetAt(configList.SelectedIndex).GetString("friendlyname"));
            }
            else
            {
                osName.Text = "Select a configuration to modify/remove it";
            }
            resetButton.Enabled = (e != null);
            resetHackButton.Enabled = (e != null);
            removeCfg.Enabled = (e != null);
        }

        public static void UpdateSettings(Dictionary<string, Control> c)
        {
            if (Lock)
            {
                return;
            }

            Control primaryServerBox = c["primaryServerBox"];
            MaterialRadioButton autoUpdateRadio = (MaterialRadioButton)c["autoUpdateRadio"];
            MaterialCheckbox hashBox = (MaterialCheckbox)c["hashBox"];
            MaterialRadioButton updateOnCloseRadio = (MaterialRadioButton)c["updateOnCloseRadio"];
            MaterialCheckbox randomnessCheckBox = (MaterialCheckbox)c["randomnessCheckBox"];
            MaterialCheckbox hideInFullscreenButton = (MaterialCheckbox)c["hideInFullscreenButton"];
            MaterialCheckbox eggHunterButton = (MaterialCheckbox)c["eggHunterButton"];
            MaterialCheckbox autosaveCheck = (MaterialCheckbox)c["autosaveCheck"];
            MaterialComboBox multiDisplayBox = (MaterialComboBox)c["multiDisplayBox"];
            MaterialComboBox scalingModeBox = (MaterialComboBox)c["scalingModeBox"];
            MaterialSwitch darkMode = (MaterialSwitch)c["darkMode"];
            MaterialCheckbox darkDetectCheck = (MaterialCheckbox)c["darkDetectCheck"];
            MaterialCheckbox legacyInterfaceCheck = (MaterialCheckbox)c["legacyInterfaceCheck"];
            MaterialComboBox primaryColorBox = (MaterialComboBox)c["primaryColorBox"];
            MaterialComboBox accentBox = (MaterialComboBox)c["accentBox"];
            MaterialSwitch materialSwitch1 = (MaterialSwitch)c["materialSwitch1"];
            Program.gs.AutoUpdate = autoUpdateRadio.Checked;
            Program.gs.HashVerify = hashBox.Checked;
            Program.gs.UpdateAfterExit = updateOnCloseRadio.Checked;
            Program.gs.Randomness = randomnessCheckBox.Checked;
            Program.gs.ShowCursor = !hideInFullscreenButton.Checked;
            Program.gs.EnableEggs = eggHunterButton.Checked;
            Program.gs.Autosave = autosaveCheck.Checked;
            Program.gs.DisplayModeEnum = (GlobalSettings.DisplayModes)multiDisplayBox.SelectedIndex;
            Program.gs.ScaleMode = (GlobalSettings.ScaleModes)scalingModeBox.SelectedIndex;
            Program.gs.NightTheme = darkMode.Checked;
            Program.gs.AutoDark = darkDetectCheck.Checked;
            Program.gs.LegacyUI = legacyInterfaceCheck.Checked;
            Program.gs.PrimaryColor = (GlobalSettings.ColorSchemes)primaryColorBox.SelectedIndex;
            Program.gs.ColorScheme = (GlobalSettings.ColorSchemes)accentBox.SelectedIndex;
            Program.gs.QuickHelp = materialSwitch1.Checked;
            Program.gs.UpdateServer = primaryServerBox.Text;
            Program.F1.quickHelp.Active = materialSwitch1.Checked;
            Program.gs.ColorScheme = (GlobalSettings.ColorSchemes)accentBox.SelectedIndex;
            Program.gs.PrimaryColor = (GlobalSettings.ColorSchemes)primaryColorBox.SelectedIndex;
            Program.gs.ApplyScheme();

            // applies the color to titlebars immediately
            Program.F1.Refresh();
            Program.F1.nineXmessage.Refresh();
            if (darkMode.Checked)
            {
                Program.F1.materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            }
            else
            {
                Program.F1.materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            }
            Program.F1.RelocateButtons();
        }


        public static void ChangeUpdateServer(Control sender, Control primaryServerBox)
        {
            switch (sender.Text)
            {
                case "Primary":
                    primaryServerBox.Enabled = false;
                    primaryServerBox.Text = "http://markustegelane.eu/app";
                    break;
                case "Backup":
                    primaryServerBox.Enabled = false;
                    primaryServerBox.Text = "http://nossl.markustegelane.eu/app";
                    break;
                case "Custom":
                    primaryServerBox.Enabled = true;
                    break;
            }
        }

        public static void SimulatorSettingsAction(Form f, Control sender, MaterialListBox configList, OpenFileDialog loadBsconfig, SaveFileDialog saveBsconfig)
        {
            switch (sender.Name)
            {

                case "addCfg":
                    if (new AddBluescreen().ShowDialog() == DialogResult.OK)
                    {
                        configList.Items.Clear();
                        foreach (BlueScreen bs in Program.templates.GetAll())
                        {
                            configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                        }
                    }
                    break;
                case "loadCfg":
                    if ((loadBsconfig.FileName != "") || (loadBsconfig.ShowDialog() == DialogResult.OK))
                    {
                        Thread t = new Thread(() => ConfigLoader(loadBsconfig.FileName, f));
                        t.Start();
                        f.Enabled = false;
                    }
                    break;
                case "saveCfg":
                    if (Program.templates.qaddeTrip)
                    {
                        MessageBox.Show("QADDE tripped, cannot save this configuration.\r\n\r\nThis can be solved by either: resetting all configurations, deleting all configurations, restaring the application or loading an existing configuration file.", AboutSettingsDialog.AssemblyProduct, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (saveBsconfig.ShowDialog() == DialogResult.OK)
                    {
                        Thread t = new Thread(() => {
                            Program.templates.SaveData(saveBsconfig.FileName, saveBsconfig.FilterIndex);
                            f.BeginInvoke(new MethodInvoker(delegate {
                                f.Enabled = true;
                            }));
                        });
                        t.Start();
                        f.Enabled = false;
                    }
                    break;
                case "removeCfg":
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
                        break;
                    }
                    if (MessageBox.Show("Would you like to remove all configurations?", "Nuke mode", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        configList.Items.Clear();
                        Program.templates.Clear();
                        Program.F1.resetHackButton.Enabled = false;
                        Program.F1.resetButton.Enabled = false;
                        Program.F1.removeCfg.Enabled = false;
                        MessageBox.Show("Configurations erased. All configurations must be re-added manually.\nNote: Do not use the main interface before adding any configurations!", "Nuke mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No action was performed.", "Nuke mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "resetHackButton":
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
                        break;
                    }
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
                    break;
                case "resetButton":
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
                        break;
                    }
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
                    break;
            }
            UIActions.GetOS(Program.F1);
        }

        private static void ConfigLoader(string filename, Form f)
        {
            Program.templates = Program.templates.LoadConfig(filename);
            Program.templates.saveFinished = true;
            f.BeginInvoke(new MethodInvoker(delegate {
                f.Enabled = true;
                Program.F1.configList.Items.Clear();
                foreach (BlueScreen bs in Program.templates.GetAll())
                {
                    Program.F1.configList.Items.Add(new MaterialListBoxItem(bs.GetString("friendlyname")));
                }
                Program.F1.loadBsconfig.FileName = "";
                Program.F1.saveBsconfig.FileName = "";
                Program.ReloadNTErrors();
            }));
            Thread.CurrentThread.Abort();
        }
    }
}
