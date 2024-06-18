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
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        readonly List<Bitmap> freezescreens = new List<Bitmap>(); // secondary display content
        int time = 0;
        public JupiterBSOD()
        {
            InitializeComponent();
        }

        private void JupiterBSOD_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void JupiterBSOD_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = me.GetString("friendlyname");
            this.Width = 1024;
            this.Height = 768;
            this.StartPosition = FormStartPosition.CenterScreen;
            Watermark.Visible = me.GetBool("watermark");
            texts = me.GetTexts();
            time = me.GetInt("timer");
            HeaderLabel.Text = texts["Your computer needs to restart"];
            DetailsLabel.Text = string.Format(texts["Information text with dump"] + "\n" + texts["Error code"], me.GetString("code").Split(' ')[1].Replace(")", "").Replace("(", ""));

            ProgressLabel.Text = string.Format(texts["Progress"], time);

            Font basefont = me.GetFont();

            HeaderLabel.Font = basefont;
            DetailsLabel.Font = new Font(basefont.FontFamily, basefont.Size - 16f, basefont.Style);
            ProgressLabel.Font = new Font(basefont.FontFamily, basefont.Size - 10.5f, basefont.Style);

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
                if (Screen.AllScreens.Length > 1)
                {
                    foreach (Screen s in Screen.AllScreens)
                    {
                        if (!s.Primary)
                        {
                            if (Program.multidisplaymode != "none")
                            {
                                WindowScreen ws = new WindowScreen
                                {
                                    StartPosition = FormStartPosition.Manual,
                                    Location = s.WorkingArea.Location,
                                    Size = new Size(s.WorkingArea.Width, s.WorkingArea.Height),
                                    primary = false
                                };
                                if (Program.multidisplaymode == "freeze")
                                {
                                    screenUpdater.Enabled = false;
                                    Bitmap screenshot = new Bitmap(s.Bounds.Width,
                                        s.Bounds.Height,
                                        System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                                    Graphics gfxScreenshot = Graphics.FromImage(screenshot);
                                    gfxScreenshot.CopyFromScreen(
                                        s.Bounds.X,
                                        s.Bounds.Y,
                                        0,
                                        0,
                                        s.Bounds.Size,
                                        CopyPixelOperation.SourceCopy
                                        );
                                    freezescreens.Add(screenshot);

                                }
                                wss.Add(ws);
                            }
                        }
                    }
                    for (int i = 0; i < wss.Count; i++)
                    {
                        WindowScreen ws = wss[i];
                        ws.Show();
                        if (Program.multidisplaymode == "freeze")
                        {
                            ws.screenDisplay.Image = freezescreens[i];
                        }
                    }
                }
            }
            Program.loadfinished = true;
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
                foreach (WindowScreen ws in wss)
                {
                    if (ws.Visible == false)
                    {
                        this.Close();
                    }
                    try
                    {
                        Program.dr.Draw(ws);
                    }
                    catch
                    {
                        this.Close();
                    }
                }
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
                    e.Cancel = Program.f1.lockout;
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
                if (wss.Count > 0)
                {
                    foreach (WindowScreen ws in wss)
                    {
                        ws.Close();
                        ws.Dispose();
                    }
                }
                screenUpdater.Enabled = false;
            }
        }

        // for prank mode purposes
        private void JupiterBSOD_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.f1.closecuzhidden == true)
            {
                Application.Exit();
            }
            if (Program.f1.showmsg == true)
            {
                MessageBox.Show(Program.f1.MsgBoxMessage, Program.f1.MsgBoxTitle, Program.f1.MsgBoxType, Program.f1.MsgBoxIcon);
                Program.f1.showmsg = false;
            }
        }
    }
}
