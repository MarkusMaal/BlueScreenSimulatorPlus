using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator.Forms.Simulators
{
    public partial class SunValleyBSOD : Form
    {
        public bool close = true;
        private bool oldmode = true;
        public bool green = false;
        public string code = "";
        public string whatfail = "";
        private int progress = 0;
        private int progressmillis = 0;
        internal int maxprogressmillis = 0;
        public BlueScreen me;

        public SunValleyBSOD()
        {
            if (new Verifile().RC() && Program.verificate)
            {
                InitializeComponent();
            }
        }

        private string TrimZeroes(string input)
        {
            string output = input;
            while (output.StartsWith("0x0"))
            {
                output = "0x" + output.Substring(3);
            }
            if (output.Length < 4)
            {
                output = $"0x0{output.Substring(output.Length - 1)}";
            }
            return output;
        }

        private void SunValleyBSOD_Load(object sender, System.EventArgs e)
        {
            try
            {
                oldmode = me.AllProgress().Keys.Count == 0;
                if (!oldmode)
                {
                    progressUpdater.Interval = 1;
                }
                this.Icon = me.GetIcon();
                this.Text = me.GetString("friendlyname");
                memCodes.Visible = me.GetBool("extracodes");
                Font textfont = me.GetFont();
                float textsize = textfont.Size;
                Font modernDetailFont = new Font(me.GetFont().FontFamily, textsize * 0.54f, me.GetFont().Style);
                this.Font = textfont;
                errorCode.Font = modernDetailFont;
                yourPCranLabel.Text = me.GetTexts()["Information text"];
                if (green)
                {
                    this.BackColor = Color.FromArgb(47, 121, 42);
                }
                try { waterMarkText.ForeColor = Color.FromArgb(this.BackColor.R + 60, this.BackColor.G + 60, this.BackColor.B + 60); } catch { }
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    if (!Program.gs.ShowCursor && Program.verificate)
                    {
                        Cursor.Hide();
                    }
                }
                if (me.GetBool("rainbow"))
                {
                    Program.dr.DrawRainbow(this);
                }
                    errorCode.Text = string.Format(me.GetTexts()["Error code"], code.Split(' ')[0], TrimZeroes(code.Split(' ')[1].Replace("(", "").Replace(")", "")));

                if (whatfail != "")
                {
                    errorCode.Text += "\r\n" + me.GetTexts()["Culprit file"].Replace("{0}", whatfail.ToLower());
                }
                if (me.GetBool("crashdump") && !me.GetBool("autoclose")) { yourPCranLabel.Text += "\r\n" + me.GetTexts()["No autorestart"]; }
                if (!me.GetBool("crashdump") && me.GetBool("autoclose")) { yourPCranLabel.Text += "\r\n" + me.GetTexts()["No crashdump with autorestart"]; }
                if (!me.GetBool("crashdump") && !me.GetBool("autoclose")) { yourPCranLabel.Text += "\r\n" + me.GetTexts()["No crashdump"]; }
                Program.loadfinished = true;
                if (!me.GetBool("windowed"))
                {
                    Program.dr.Init(this, true);
                }
            }
            catch (Exception ex) when (!Debugger.IsAttached)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                progressUpdater.Enabled = false;
                Hide();
                if (Program.gs.EnableEggs) { me.Crash(ex, "OrangeScreen"); }
                else { MessageBox.Show("The blue screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                Close();
            }
        }

        private void SunValleyBSOD_FormClosing(object sender, FormClosingEventArgs e)
        {
            // prevent closing with Alt + F4
            // if Windows is shutting down, this will not prevent closing of
            // WXBS
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (progress < 100)
                {
                    e.Cancel = Program.gs.PM_Lockout;
                }
                else
                {
                    e.Cancel = false;
                }
            }
            else
            {
                e.Cancel = false;
            }
            if (!e.Cancel)
            {
                Program.dr.Dispose();
                screenUpdater.Enabled = false;
            }
        }

        private void progressUpdater_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!oldmode) { progressmillis++; }
                if (!me.GetBool("crashdump")) { progress = 100; }

                if (!Program.verificate) { throw new NotImplementedException(); }
                if ((oldmode && (progress >= 100)) || (progressmillis == maxprogressmillis))
                {
                    progressUpdater.Enabled = false;
                    if (me.GetBool("autoclose")) { this.Close(); }
                    progressIndicator.Text = me.GetTexts()["Progress"].Replace("{0}", "100");
                }
                if (oldmode)
                {
                    progress += 1;
                    if (progress > 60) { progressUpdater.Interval = 300; }
                }
                else
                {
                    progress += me.GetProgression(progressmillis);
                }
                progressIndicator.Text = me.GetTexts()["Progress"].Replace("{0}", progress.ToString());
            } catch (Exception ex) when (!Debugger.IsAttached)
            {
                progressUpdater.Enabled = false;
                if (Program.gs.EnableEggs) { me.Crash(ex, "GreenScreen"); }
                else { MessageBox.Show("An error has occoured.\n\n" + ex.Message + "\n\n" + ex.StackTrace.ToString(), "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void SunValleyBSOD_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.gs.PM_CloseMainUI)
            {
                Application.Exit();
            }
            if (Program.gs.PM_ShowMessage)
            {
                MessageBox.Show(Program.gs.PM_MsgText, Program.gs.PM_MsgTitle, Program.gs.PM_MsgType, Program.gs.PM_MsgIcon);
                Program.gs.PM_ShowMessage = false;
            }
        }

        private void screenUpdater_Tick(object sender, EventArgs e)
        {
            if (!me.GetBool("windowed"))
            {
                foreach (WindowScreen ws in Program.dr.wss)
                {
                    Program.dr.Draw(ws, false);
                }
                BringToFront();
                Activate();
            }
        }

        private void SunValleyBSOD_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F7))
            {
                // debug here
                UIActions.me.GetString("a");
                Close();
            }
            else if ((e.KeyCode == Keys.F2) && me.GetBool("windowed"))
            {
                string output = Program.dr.Screenshot(this);
                Cursor.Show();
                MessageBox.Show($"Image saved as {output}", "Screenshot taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void yourPCranLabel_Click(object sender, EventArgs e)
        {

        }

        private void progressIndicator_Click(object sender, EventArgs e)
        {

        }
    }
}
