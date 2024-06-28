using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class JupiterBSOD : Form
    {
        internal BlueScreen me;
        private IDictionary<string, string> texts;
        int time = 0;
        public JupiterBSOD()
        {
            if (Program.verificate)
            {
                InitializeComponent();
            }
        }

        private void JupiterBSOD_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
            {
                Close();
            }
            else if ((e.KeyCode == Keys.F2) && me.GetBool("windowed"))
            {
                string output = Program.dr.Screenshot(this);
                Cursor.Show();
                MessageBox.Show($"Image saved as {output}", "Screenshot taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private float DpiDelta(float emSize)
        {
            return (emSize * 96f / CreateGraphics().DpiX);
        }

        private void JupiterBSOD_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Text = me.GetString("friendlyname");
                if (!Program.gs.ShowCursor && !me.GetBool("windowed"))
                {
                    Cursor.Hide();
                }
                this.Width = 1024;
                this.Height = 768;
                this.StartPosition = FormStartPosition.CenterScreen;
                Watermark.Visible = me.GetBool("watermark");
                texts = me.GetTexts();
                time = me.GetInt("timer");
                HeaderLabel.Text = texts["Your computer needs to restart"];
                DetailsLabel.Text = string.Format(texts["Information text with dump"] + "\n" + texts["Error code"], me.GetString("code").Split(' ')[1].Replace(")", "").Replace("(", ""));

                ProgressLabel.Text = string.Format(texts["Progress"], time);

                Font basefont = new Font(me.GetFont().FontFamily, me.GetFont().Size * 96f / CreateGraphics().DpiX, me.GetFont().Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);

                HeaderLabel.Font = basefont;
                DetailsLabel.Font = new Font(basefont.FontFamily, basefont.Size - DpiDelta(16f), basefont.Style);
                ProgressLabel.Font = new Font(basefont.FontFamily, basefont.Size - DpiDelta(10.5f), basefont.Style);

                int mx = me.GetInt("margin-x");
                int my = me.GetInt("margin-y");

                HeaderLabel.Location = new Point(mx, my);
                DetailsLabel.Location = new Point(mx, my + 52);
                ProgressLabel.Location = new Point(mx, my + 208);
                if (me.GetBool("countdown"))
                {
                    timecounter.Start();
                }
                else
                {
                    ProgressLabel.Visible = false;
                    time = 0;
                }
                this.Icon = me.GetIcon();
                if (!me.GetBool("windowed"))
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.WindowState = FormWindowState.Maximized;
                    // for multimonitor support
                    Program.dr.Init(this, true);
                }
                if (me.GetBool("rainbow"))
                {
                    Program.dr.DrawRainbow(this);
                }
                Program.loadfinished = true;
            } catch (Exception ex)
            {
                if (!Program.verificate)
                {
                    Application.Exit();
                }
                else
                {
                    me.Crash(ex, "YellowScreen");
                    this.Close();
                }
            }
        }

        private void Timecounter_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                ProgressLabel.Text = string.Format(texts["Progress"], time);
            } else
            {
                timecounter.Enabled = false;
                if (me.GetBool("autoclose"))
                {
                    Close();
                }
            }
        }

        private void screenUpdater_Tick(object sender, EventArgs e)
        {
            if (!me.GetBool("windowed"))
            {
                Program.dr.DrawAll();
                this.BringToFront();
                this.Activate();
            }
        }

        private void JupiterBSOD_FormClosing(object sender, FormClosingEventArgs e)
        {
            // prevent closing with Alt + F4
            // if Windows is shutting down, this will not prevent closing of
            // WXBS
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (time > 0)
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

        // for prank mode purposes
        private void JupiterBSOD_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
