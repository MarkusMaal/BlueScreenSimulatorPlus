using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class WXBS : Form
    {
        public bool server = false;
        public bool qr = true;
        public bool green = false;
        public bool close = true;
        public string code = "";
        public string whatfail = "";
        public bool w8 = false;
        public bool w11 = false;
        private bool w8close = false;
        private int progress = 0;
        internal BlueScreen me = Program.bluescreens[0];
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        readonly List<Bitmap> freezescreens = new List<Bitmap>();
        public WXBS()
        {
            InitializeComponent();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WXBS_FormClosing(object sender, FormClosingEventArgs e)
        {
            // prevent closing with Alt + F4
            // if Windows is shutting down, this will not prevent closing of
            // WXBS
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Program.f1.lockout;
            }
            else
            {
                e.Cancel = false;
            }
            if (wss.Count > 0)
            {
                foreach (WindowScreen ws in wss)
                {
                    ws.Close();
                    ws.Dispose();
                }
            }
            if (!Program.f1.showcursor)
            {
                Cursor.Show();
            }
        }

        private void WXBS_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = me.GetIcon();
                this.Text = me.GetString("friendlyname");
                memCodes.Visible = me.GetBool("extracodes");
                Font textfont = me.GetFont();
                float textsize = textfont.Size;
                Font emotifont = new Font(me.GetFont().FontFamily, textsize * 5f, me.GetFont().Style);
                Font modernDetailFont = new Font(me.GetFont().FontFamily, textsize * 0.55f, me.GetFont().Style);
                emoticonLabel.Font = emotifont;
                yourPCranLabel.Font = textfont;
                progressIndicator.Font = textfont;
                supportInfo.Font = modernDetailFont;
                errorCode.Font = modernDetailFont;
                yourPCranLabel.Text = me.GetTexts()["Information text with dump"];

                qrCode.Size = new Size(me.GetInt("qr_size"), me.GetInt("qr_size"));

                if (me.GetString("qr_file") == "local:1") { qrCode.Image = Properties.Resources.bsodqr_transparent; }
                else if (me.GetString("qr_file") == "local:0") { qrCode.Image = Properties.Resources.bsodqr; }
                else { try { qrCode.Image = Image.FromFile(me.GetString("qr_file")); } catch { qrCode.Image = Properties.Resources.bsodqr; } }
                if (w8 == true)
                {
                    yourPCranLabel.Text = me.GetTexts()["Information text with dump"].Replace("{0}", "0");
                    if (close == true) { close = false; w8close = true; }

                }
                else
                {
                    progressIndicator.Text = me.GetTexts()["Progress"].Replace("{0}", "0");
                    supportInfo.Text = me.GetTexts()["Additional information"];
                }
                if (!w8close)
                {
                    if (close == false)
                    {
                        yourPCranLabel.Text = me.GetTexts()["Information text without dump"];
                    }
                    if (green)
                    {
                        this.BackColor = Color.FromArgb(47, 121, 42);
                        yourPCranLabel.Text = yourPCranLabel.Text.Replace("PC", "Windows Insider Build");
                    }
                    if (server)
                    {
                        emoticonLabel.Visible = false;
                        yourPCranLabel.Margin = new Padding(yourPCranLabel.Margin.Left, 80, 0, 0);
                    }
                }
                try { waterMarkText.ForeColor = Color.FromArgb(this.BackColor.R + 60, this.BackColor.G + 60, this.BackColor.B + 60); } catch { }
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    if (!Program.f1.showcursor)
                    {
                        Cursor.Hide();
                    }
                }
                emoticonLabel.Padding = new Padding(0, Convert.ToInt32(this.Height * 0.12), 0, 0);
                qrMargin.Width = Convert.ToInt32(this.Width * 0.09) - 10;
                yourPCranLabel.Padding = new Padding(qrMargin.Width - 3, 0, 0, 0);
                progressIndicator.Padding = yourPCranLabel.Padding;
                emoticonLabel.Margin = new Padding(Convert.ToInt32(qrMargin.Width * 0.8), 0, 0, 0);
                horizontalFlowPanel.Width = this.Width - 10;
                if (w8 == false)
                {
                    if (whatfail == "")
                    {
                        errorCode.Text = me.GetTexts()["Error code"].Replace("{0}", code);
                    }
                    else
                    {
                        errorCode.Location = new Point(3, 36);
                        errorCode.Text = me.GetTexts()["Error code"].Replace("{0}", code + "\n\n" + me.GetTexts()["Culprit file"].Replace("{0}", whatfail.ToLower()));
                    }
                }
                if (w8 == true)
                {
                    progressIndicator.Visible = false;
                    if (whatfail == "")
                    {
                        errorCode.Text = me.GetTexts()["Error code"].Replace("{0}", code);
                    }
                    else
                    {
                        errorCode.Text = me.GetTexts()["Error code"].Replace("{0}", code + " (" + whatfail.ToLower() + ")");
                    }
                }
                if (qr == true)
                {
                    qrCode.Visible = true;
                    supportInfo.Visible = true;
                    errorCode.Location = new Point(3, 56);
                    Point locationOnForm = qrCode.FindForm().PointToClient(qrCode.Parent.PointToScreen(qrCode.Location));
                    supportContainer.Location = new Point(qrMargin.Width + qrCode.Width + 20, locationOnForm.Y);
                }
                else
                {
                    qrCode.Visible = false;
                    supportInfo.Visible = false;
                    errorCode.Location = new Point(3, 0);
                    Point locationOnForm = horizontalFlowPanel.FindForm().PointToClient(horizontalFlowPanel.Parent.PointToScreen(horizontalFlowPanel.Location));
                    supportContainer.Location = new Point(qrMargin.Width - 13, locationOnForm.Y);
                }
                if (qr == false)
                {
                    if (close == false)
                    {
                        if (w8)
                        {
                            Point locationOnForm = yourPCranLabel.FindForm().PointToClient(yourPCranLabel.Parent.PointToScreen(yourPCranLabel.Location));
                            supportContainer.Location = new Point(supportContainer.Location.X, locationOnForm.Y + 150);
                        }
                    }
                }
                if (w8)
                {
                    if (w8close == false)
                    {
                        yourPCranLabel.Text = me.GetTexts()["Information text without dump"];
                        progressUpdater.Enabled = false;
                        progressIndicator.Visible = false;
                        Point locationOnForm = yourPCranLabel.FindForm().PointToClient(yourPCranLabel.Parent.PointToScreen(yourPCranLabel.Location));
                        supportContainer.Location = new Point(qrMargin.Width - 13, locationOnForm.Y + 120);
                    }
                }
                if (w8close == true)
                {
                    progressUpdater.Enabled = true;
                }
                Program.loadfinished = true;
                if (!me.GetBool("windowed"))
                {
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
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                MessageBox.Show("The blue screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!w8close)
                {
                    if (progress >= 100)
                    {
                        progressUpdater.Enabled = false;
                        if (close == true) { this.Close(); }
                        progressIndicator.Text = me.GetTexts()["Progress"].Replace("{0}", "100");
                    }
                    progress += 1;
                    if (progress > 60) { progressUpdater.Interval = 300; }
                    progressIndicator.Text = me.GetTexts()["Progress"].Replace("{0}", progress.ToString());
                }
                else
                {
                    if (progress >= 100)
                    {
                        yourPCranLabel.Text = yourPCranLabel.Text.Replace(progress.ToString() + "%", "100%");
                        progressUpdater.Enabled = false;
                       this.Close();
                    }
                    string oldprogress = progress.ToString();
                    progress += 1;
                    if (progress > 60) { progressUpdater.Interval = 300; }
                    yourPCranLabel.Text = yourPCranLabel.Text.Replace(oldprogress + "%", progress.ToString() + "%");
                }
            } catch (Exception ex)
            {
                progressUpdater.Enabled = false;
                MessageBox.Show("An error has occoured.\n\n" + ex.Message + "\n\n" + ex.StackTrace.ToString(), "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WXBS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.f1.closecuzhidden == true)
            {
                Program.f1.Close();
            }
            if (Program.f1.showmsg == true)
            {
                MessageBox.Show(Program.f1.MsgBoxMessage, Program.f1.MsgBoxTitle, Program.f1.MsgBoxType, Program.f1.MsgBoxIcon);
                Program.f1.showmsg = false;
            }
        }

        private void WXBS_Resize(object sender, EventArgs e)
        {
            emoticonLabel.Padding = new Padding(0, Convert.ToInt32(this.Height * 0.12), 0, 0);
            qrMargin.Width = Convert.ToInt32(this.Width * 0.09) - 10;
            yourPCranLabel.Padding = new Padding(qrMargin.Width - 3, 0, 0, 0);
            progressIndicator.Padding = yourPCranLabel.Padding;
            emoticonLabel.Margin = new Padding(Convert.ToInt32(qrMargin.Width * 0.77), 0, 0, 0);
            horizontalFlowPanel.Width = this.Width - 10;

            if (qr == true)
            {
                errorCode.Location = new Point(3, 56);
                Point locationOnForm = qrCode.FindForm().PointToClient(qrCode.Parent.PointToScreen(qrCode.Location));
                supportContainer.Location = new Point(qrMargin.Width + qrCode.Width + 20, locationOnForm.Y);
            }
            else
            {
                errorCode.Location = new Point(3, 0);
                Point locationOnForm = horizontalFlowPanel.FindForm().PointToClient(horizontalFlowPanel.Parent.PointToScreen(horizontalFlowPanel.Location));
                supportContainer.Location = new Point(qrMargin.Width - 13, locationOnForm.Y);
            }
            if (qr == false)
            {
                if (close == false)
                {
                    if (w8)
                    {
                        Point locationOnForm = yourPCranLabel.FindForm().PointToClient(yourPCranLabel.Parent.PointToScreen(yourPCranLabel.Location));
                        supportContainer.Location = new Point(supportContainer.Location.X, locationOnForm.Y + 150);
                    }
                }
            }
            if (w8)
            {
                if (w8close == false)
                {
                    Point locationOnForm = yourPCranLabel.FindForm().PointToClient(yourPCranLabel.Parent.PointToScreen(yourPCranLabel.Location));
                    supportContainer.Location = new Point(qrMargin.Width - 13, locationOnForm.Y + 120);
                }
            }
        }

        private void Timer2_Tick(object sender, EventArgs e)
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
            }
        }
    }
}
