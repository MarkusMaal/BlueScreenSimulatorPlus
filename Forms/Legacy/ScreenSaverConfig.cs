using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    public partial class ScreenSaverConfig : Form
    {
        public ScreenSaverConfig()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Program.gs.SaveSettings();
            Close();
        }

        private void ScreenSaverConfig_Load(object sender, EventArgs e)
        {
            simulatorSettingsNotice.Text = string.Format(simulatorSettingsNotice.Text, UIActions.me.GetString("os"), UIActions.me.GetString("friendlyname"));
            eggHunterButton.Checked = Program.gs.EnableEggs;
            hideInFullscreenButton.Checked = !Program.gs.ShowCursor;
            mouseMoveAutoExitCheckBox.Checked = Program.gs.MouseMoveExit;
            scalingModeBox.SelectedIndex = (int)Program.gs.ScaleMode;
            multiDisplayBox.SelectedIndex = (int)Program.gs.DisplayModeEnum;
        }

        private void MultiDisplaySetup(object sender, EventArgs e)
        {
            Program.gs.DisplayModeEnum = (GlobalSettings.DisplayModes)multiDisplayBox.SelectedIndex;
        }

        private void EggHunterButton_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.EnableEggs = ((CheckBox)sender).Checked;
        }

        private void HideInFullscreenButton_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.ShowCursor = !((CheckBox)sender).Checked;
        }

        private void MouseMoveAutoExitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.MouseMoveExit = ((CheckBox)sender).Checked;
        }

        private void ScalingModeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.gs.ScaleMode = (GlobalSettings.ScaleModes)scalingModeBox.SelectedIndex;
        }
    }
}
