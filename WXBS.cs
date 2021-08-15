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
        List<WindowScreen> wss = new List<WindowScreen>();
        List<Bitmap> freezescreens = new List<Bitmap>();
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
            memCodes.Visible = me.GetBool("extracodes");
            Font textfont = me.GetFont();
            float textsize = textfont.Size;
            Font emotifont = new Font(me.GetFont().FontFamily, textsize * 5f, me.GetFont().Style);
            Font modernDetailFont = new Font(me.GetFont().FontFamily, textsize * 0.55f, me.GetFont().Style);
            label1.Font = emotifont;
            label2.Font = textfont;
            label3.Font = textfont;
            label4.Font = modernDetailFont;
            label5.Font = modernDetailFont;
            label2.Text = me.GetTexts()["Information text with dump"];
            
            pictureBox1.Size = new Size(me.GetInt("qr_size"), me.GetInt("qr_size"));

            if (me.GetString("qr_file") == "local:1") { pictureBox1.Image = Properties.Resources.bsodqr_transparent; }
            else if (me.GetString("qr_file") == "local:0") { pictureBox1.Image = Properties.Resources.bsodqr; }
            else { try { pictureBox1.Image = Image.FromFile(me.GetString("qr_file")); } catch { pictureBox1.Image = Properties.Resources.bsodqr; } }
            if (w8 == true)
            {
                label2.Text = me.GetTexts()["Information text with dump"].Replace("{0}", "0");
                if (close == true) { close = false; w8close = true; }

            } else
            {
                label3.Text = me.GetTexts()["Progress"].Replace("{0}", "0");
                label4.Text = me.GetTexts()["Additional information"];
            }
            if (!w8close)
            { 
                if (close == false)
                {
                    label2.Text = me.GetTexts()["Information text without dump"];
                }
                if (green)
                {
                    this.BackColor = Color.FromArgb(47, 121, 42);
                    label2.Text = label2.Text.Replace("PC", "Windows Insider Build");
                }
                if (server)
                {
                    label1.Visible = false;
                    label2.Margin = new Padding(label2.Margin.Left, 80, 0, 0);
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
            label1.Padding = new Padding(0, Convert.ToInt32(this.Height * 0.12), 0, 0);
            panel2.Width = Convert.ToInt32(this.Width * 0.09) - 10;
            label2.Padding = new Padding(panel2.Width - 3, 0, 0, 0);
            label3.Padding = label2.Padding;
            label1.Margin = new Padding(Convert.ToInt32(panel2.Width * 0.8), 0, 0, 0);
            flowLayoutPanel2.Width = this.Width - 10;
            if (w8 == false)
            {
                if (whatfail == "")
                { 
                    label5.Text = me.GetTexts()["Error code"].Replace("{0}", code);
                } else
                {
                    label5.Location = new Point(3, 36);
                    label5.Text = me.GetTexts()["Error code"].Replace("{0}", code + "\n\n" + me.GetTexts()["Culprit file"].Replace("{0}", whatfail.ToLower()));
                }
            }
            if (w8 == true)
            {
                label3.Visible = false;
                if (whatfail == "")
                {
                    label5.Text = me.GetTexts()["Error code"].Replace("{0}", code);
                } else
                {
                    label5.Text = me.GetTexts()["Error code"].Replace("{0}", code + " (" + whatfail.ToLower() + ")");
                }
            }
            if (qr == true)
            {
                pictureBox1.Visible = true;
                label4.Visible = true;
                label5.Location = new Point(3, 56);
                Point locationOnForm = pictureBox1.FindForm().PointToClient(pictureBox1.Parent.PointToScreen(pictureBox1.Location));
                panel1.Location = new Point(panel2.Width + pictureBox1.Width + 20, locationOnForm.Y);
            } else
            {
                pictureBox1.Visible = false;
                label4.Visible = false;
                label5.Location = new Point(3, 0);
                Point locationOnForm = flowLayoutPanel2.FindForm().PointToClient(flowLayoutPanel2.Parent.PointToScreen(flowLayoutPanel2.Location));
                panel1.Location = new Point(panel2.Width, locationOnForm.Y);
            }
            if (qr == false)
            { 
                if (close == false)
                {
                    if (w8)
                    {
                        Point locationOnForm = label2.FindForm().PointToClient(label2.Parent.PointToScreen(label2.Location));
                        panel1.Location = new Point(panel1.Location.X, locationOnForm.Y + 150);
                    }
                }
            }
            if (w8)
            {
                if (w8close == false)
                {
                    label2.Text = me.GetTexts()["Information text without dump"];
                    timer1.Enabled = false;
                    label3.Visible = false;
                    Point locationOnForm = label2.FindForm().PointToClient(label2.Parent.PointToScreen(label2.Location));
                    panel1.Location = new Point(panel2.Width, locationOnForm.Y + 120);
                }
            }
            if (w8close == true)
            {
                timer1.Enabled = true;
            }

            if (Screen.AllScreens.Length > 1)
            {
                foreach (Screen s in Screen.AllScreens)
                {
                    if (!s.Primary)
                    {
                        if (Program.multidisplaymode != "none")
                        {
                            WindowScreen ws = new WindowScreen();
                            ws.StartPosition = FormStartPosition.Manual;
                            ws.Location = s.WorkingArea.Location;
                            ws.Size = new Size(s.WorkingArea.Width, s.WorkingArea.Height);
                            ws.primary = false;
                            if (Program.multidisplaymode == "freeze")
                            {
                                timer2.Enabled = false;
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
                        ws.pictureBox1.Image = freezescreens[i];
                    }
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!w8close) { 
                if (progress >= 100)
                {
                    timer1.Enabled = false;
                    if (close == true) { this.Close(); }
                    label3.Text = me.GetTexts()["Progress"].Replace("{0}", "100");
                }
                progress += 1;
                if (progress > 60) { timer1.Interval = 300; }
                label3.Text = me.GetTexts()["Progress"].Replace("{0}", progress.ToString());
            } else
            {
                if (progress >= 100)
                {
                    label2.Text = label2.Text.Replace(progress.ToString() + "%", "100%");
                    timer1.Enabled = false;
                    if (w8close == true) { this.Close(); }
                }
                string oldprogress = progress.ToString();
                progress += 1;
                if (progress > 60) { timer1.Interval = 300; }
                label2.Text = label2.Text.Replace(oldprogress + "%", progress.ToString() + "%");
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
            Program.f1.Show();
        }

        private void WXBS_Resize(object sender, EventArgs e)
        {
            label1.Padding = new Padding(0, Convert.ToInt32(this.Height * 0.12), 0, 0);
            panel2.Width = Convert.ToInt32(this.Width * 0.09) - 10;
            label2.Padding = new Padding(panel2.Width - 3, 0, 0, 0);
            label3.Padding = label2.Padding;
            label1.Margin = new Padding(Convert.ToInt32(panel2.Width * 0.77), 0, 0, 0);
            flowLayoutPanel2.Width = this.Width - 10;

            if (qr == true)
            {
                label5.Location = new Point(3, 56);
                Point locationOnForm = pictureBox1.FindForm().PointToClient(pictureBox1.Parent.PointToScreen(pictureBox1.Location));
                panel1.Location = new Point(panel2.Width + pictureBox1.Width + 20, locationOnForm.Y);
            }
            else
            {
                label5.Location = new Point(3, 0);
                Point locationOnForm = flowLayoutPanel2.FindForm().PointToClient(flowLayoutPanel2.Parent.PointToScreen(flowLayoutPanel2.Location));
                panel1.Location = new Point(panel2.Width, locationOnForm.Y);
            }
            if (qr == false)
            {
                if (close == false)
                {
                    if (w8)
                    {
                        Point locationOnForm = label2.FindForm().PointToClient(label2.Parent.PointToScreen(label2.Location));
                        panel1.Location = new Point(panel1.Location.X, locationOnForm.Y + 150);
                    }
                }
            }
            if (w8)
            {
                if (w8close == false)
                {
                    Point locationOnForm = label2.FindForm().PointToClient(label2.Parent.PointToScreen(label2.Location));
                    panel1.Location = new Point(panel2.Width, locationOnForm.Y + 120);
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
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
