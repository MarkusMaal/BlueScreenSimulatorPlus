using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class W2kbs : Form
    {
        public bool fullscreen = true;
        private bool naturalclose = false;
        public string whatfail = "";
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        readonly List<Bitmap> freezescreens = new List<Bitmap>();
        internal BlueScreen me = Program.bluescreens[0];
        
        public W2kbs()
        {
            InitializeComponent();
        }

        private void W2kbs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Program.f1.lockout;
            }
            else
            {
                e.Cancel = false;
            }
            if (!naturalclose)
            {
                foreach (WindowScreen ws in wss)
                {
                    ws.Close();
                    ws.Dispose();
                }
                foreach (Bitmap bmp in freezescreens)
                {
                    bmp.Dispose();
                }
            }
        }

        private void W2kbs_Load(object sender, EventArgs e)
        {
            string[] esplit = errorCode.Text.Split('\n')[0].Replace("*** STOP: ", "").Replace(")", "").Replace(" (", "*").Split('*');

            errorCode.Text = me.GetTexts()["Error code formatting"].Replace("{0}", esplit[0]).Replace("{1}", esplit[1]) + "\n" + errorCode.Text.Split('\n')[1];
            label2.Text = me.GetTexts()["Troubleshooting introduction"];
            supportInfo.Text = me.GetTexts()["Troubleshooting text"];
            downMessage.Text = me.GetTexts()["Additional troubleshooting information"];
            errorCode.Font = me.GetFont();
            label2.Font = me.GetFont();
            supportInfo.Font = me.GetFont();
            downMessage.Font = me.GetFont();
            if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; this.ShowInTaskbar = true; this.ShowIcon = true; }
            if (Program.f1.supporttext == "")
            {
                supportInfo.Visible = false;
                errorCode.Visible = false;
            }
            if (whatfail != "")
            {
                errorCode.Text += "\n\n*** Address " + me.GenHex(8, "RRRRRRRR") + " base at " + me.GenHex(8, "RRRRRRRR")  + ", DateStamp " + me.GenHex(8, "RRRRRRRR").ToLower() + " - " + whatfail.ToLower();
            }
            errorCode.Text = errorCode.Text.Replace("IRQL", "DRIVER_IRQL");

            Program.loadfinished = true;
            if (fullscreen)
            {
                if (Screen.AllScreens.Length > 1)
                {
                    foreach (Screen s in Screen.AllScreens)
                    {
                        WindowScreen ws = new WindowScreen();
                        if (!s.Primary)
                        {
                            if (Program.multidisplaymode != "none")
                            {
                                ws.StartPosition = FormStartPosition.Manual;
                                ws.Location = s.WorkingArea.Location;
                                ws.Size = new Size(s.WorkingArea.Width, s.WorkingArea.Height);
                                ws.primary = false;

                                if (Program.multidisplaymode == "freeze")
                                {
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
                            }
                        }
                        wss.Add(ws);
                    }
                }
                else
                {
                    wss.Add(new WindowScreen());
                }
                for (int i = 0; i < wss.Count; i++)
                {
                    WindowScreen ws = wss[i];
                    ws.Show();
                    if (!ws.primary)
                    {
                        if (Program.multidisplaymode == "freeze")
                        {
                            ws.pictureBox1.Image = freezescreens[i - 1];
                        }
                    }
                }
                foreach (WindowScreen ws in wss)
                {
                    Program.dr.Draw(ws);
                }
                this.TopMost = false;
                for (int i = 0; i < wss.Count; i++)
                {
                    WindowScreen ws = wss[i];
                    ws.Show();
                    if (!ws.primary)
                    {
                        if (Program.multidisplaymode == "freeze")
                        {
                            ws.pictureBox1.Image = freezescreens[i - 1];
                        }
                    }
                }
                this.Hide();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (fullscreen)
            {
                foreach (WindowScreen ws in wss)
                {
                    if (ws.Visible == false)
                    {
                        naturalclose = true;
                        this.Close();
                    }
                    try
                    {
                        Program.dr.Draw(ws);
                    }
                    catch
                    {
                        naturalclose = true;
                        this.Close();
                    }
                }
            }
        }

        private void W2kbs_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!fullscreen)
            {
                if (Program.f1.closecuzhidden == true)
                {
                    Program.f1.Close();
                }
            }
        }
    }
}
