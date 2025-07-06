using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class BootMgr : Form
    {
        private bool naturalclose = false;
        internal BlueScreen me;
        private int moves = 0;
        public BootMgr()
        {
            //
            // forcibly disable DPI scaling for these legacy configurations
            // otherwise, the font won't be pixel perfect
            //
            // to upscale on higher DPI settings, use fullscreen mode
            //
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
            if ((Program.verificate ? 3 : 1) + (Program.verifile.RC() ? 1 : 3) == 4)
            {
                InitializeComponent();
            }
        }

        private void KeyChecker(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            } else if (e.KeyCode == Keys.F7) { this.Close(); }
            else if ((e.KeyCode == Keys.F2) && me.GetBool("windowed"))
            {
                string output = Program.dr.Screenshot(this);
                Cursor.Show();
                MessageBox.Show($"Image saved as {output}", "Screenshot taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Initialization(object sender, EventArgs e)
        {
            try
            {
                this.Icon = me.GetIcon();
                this.Text = me.GetString("friendlyname");
                Color bg = me.GetTheme(true);
                Color fg = me.GetTheme(false);
                Color hbg = me.GetTheme(true, true);
                Color hfg = me.GetTheme(false, true);
                this.BackColor = bg; this.ForeColor = fg;
                IDictionary<string, string> txt = me.GetTexts();
                IDictionary<string, string> titles = me.GetTitles();
                //this.Font = me.GetFont();
                bootmgrTitle.BackColor = fg; bootmgrTitle.ForeColor = bg; bootmgrTitle.Text = titles["Main"];
                bootmgrEnterContinue.BackColor = fg; bootmgrEnterContinue.ForeColor = bg; bootmgrEnterContinue.Text = txt["Continue"];
                bootmgrEscapeExit.BackColor = fg; bootmgrEscapeExit.ForeColor = bg; bootmgrEscapeExit.Text = txt["Exit"];

                bootmgrIntro.ForeColor = fg; bootmgrIntro.Text = txt["Troubleshooting introduction"];
                bootmgrTroubleshoot.ForeColor = fg; bootmgrTroubleshoot.Text = txt["Troubleshooting"];
                bootmgrConsultAdmin.ForeColor = fg; bootmgrConsultAdmin.Text = txt["Troubleshooting without disc"];
                bootmgrStatus.ForeColor = fg; bootmgrStatus.Text = txt["Status"];
                bootmgrInfo.ForeColor = fg; bootmgrInfo.Text = txt["Info"];

                bootmgrStatusCode.BackColor = hbg != bg ? hbg : Color.Transparent; bootmgrStatusCode.ForeColor = hfg; bootmgrStatusCode.Text = me.GetString("code").ToLower();
                bootmgrInfoDetails.BackColor = hbg != bg ? hbg : Color.Transparent; bootmgrInfoDetails.ForeColor = hfg; bootmgrInfoDetails.Text = txt["Error description"];

                this.TopMost = false;
                if (me.GetBool("rainbow"))
                {
                    Program.dr.DrawRainbow(this);
                }
                Program.loadfinished = true;
                if (!me.GetBool("windowed") && (this.Opacity != 0.0))
                {
                    Program.dr.Init(this);
                } else
                {
                    this.Text = me.GetString("friendlyname");
                    this.Icon = me.GetIcon();
                    this.FormBorderStyle = FormBorderStyle.FixedSingle;
                }
                this.waterMarkText.Visible = me.GetBool("watermark");
                int[] colors = { this.BackColor.R + 50, this.BackColor.G + 50, this.BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                this.Hide();
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                this.Hide();
                if (Program.gs.EnableEggs) { me.Crash(ex, "OrangeScreen"); }
                else { MessageBox.Show("The crash screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Close();
            }
        }

        private void UpdateScreen(object sender, EventArgs e)
        {
            if (this.Opacity != 0.0)
            {
                Program.dr.DrawAll();
            }
        }

        private void Unloading(object sender, FormClosingEventArgs e)
        {
            if (!naturalclose)
            {
                Program.dr.Dispose();
                Cursor.Show();
            }
            if (Program.gs.PM_CloseMainUI)
            {
                Application.Exit();
            }
        }

        private void BootMgr_MouseMove(object sender, MouseEventArgs e)
        {
            moves++;
            if (moves > 50 && Program.isScreensaver && Program.gs.MouseMoveExit)
            {
                this.Close();
            }
        }
    }
}
