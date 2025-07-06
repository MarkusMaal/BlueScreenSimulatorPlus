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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
            if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.HighQualityBicubic) { scalingModeBox.SelectedIndex = 0; }
            if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.HighQualityBilinear) { scalingModeBox.SelectedIndex = 1; }
            if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.Bilinear) { scalingModeBox.SelectedIndex = 4; }
            if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.Bicubic) { scalingModeBox.SelectedIndex = 3; }
            if (Program.gs.ScaleMode == GlobalSettings.ScaleModes.NearestNeighbour) { scalingModeBox.SelectedIndex = 2; }
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

        private void eggHunterButton_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.EnableEggs = ((CheckBox)sender).Checked;
        }

        private void hideInFullscreenButton_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.ShowCursor = !((CheckBox)sender).Checked;
        }

        private void mouseMoveAutoExitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Program.gs.MouseMoveExit = ((CheckBox)sender).Checked;
        }

        private void scalingModeBox_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
