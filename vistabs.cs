using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class Vistabs : Form
    {
        public bool fullscreen = true;
        public string whatfail = "";
        private bool naturalclose = false;
        private int progress = 0;
        bool inr = false;
        bool ing = false;
        bool inb = false;
        internal BlueScreen me = Program.bluescreens[0];
        string h1;
        string h2;
        string h3;
        Color bg;
        Color fg;
        IDictionary<string, string> txt;

        string state = "0";
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        readonly List<Bitmap> freezescreens = new List<Bitmap>();
        public Vistabs()
        {
            InitializeComponent();
        }

        private void Xvsbs_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = me.GetString("friendlyname");
                h1 = me.GenHex(8, me.GetFiles().ElementAt(0).Value[0]);
                h2 = me.GenHex(8, me.GetFiles().ElementAt(0).Value[1]);
                h3 = me.GenHex(8, me.GetFiles().ElementAt(0).Value[2]);
                bg = me.GetTheme(true);
                fg = me.GetTheme(false);
                txt = me.GetTexts();
                foreach (Control c in this.Controls)
                {
                    if (c is AliasedLabel)
                    {
                        c.BackColor = this.BackColor;
                        c.ForeColor = this.ForeColor;
                    }
                }
                if (Program.f1.enableeggs)
                {
                    if (me.GetString("culprit").ToLower() == "tardis.sys")
                    {
                        tardisFade.Enabled = true;
                    }
                    if (bg == fg)
                    {
                        this.BackColor = Color.FromArgb(255, 0, 0);
                        rainBowScreen.Enabled = true;
                    }
                }
                float HeightInPixels;
                using (Graphics g = this.CreateGraphics())
                {
                    var points = me.GetFont().SizeInPoints;
                    HeightInPixels = points * g.DpiX / 72;
                }
                errorCode.Visible = me.GetBool("show_description");
                label5.Text = txt["Collecting data for crash dump"]; label5.Text += "\n" + txt["Initializing crash dump"];
                label5.Text += "\n" + txt["Begin dump"] + "\n" + txt["Physical memory dump"] + "   0";
                if (whatfail != "")
                {
                    errorCode.Text = txt["Culprit file"] + whatfail.ToUpper() + "\n\n" + errorCode.Text;
                    label5.Margin = new Padding(3, 15, 3, 0);
                }
                supportInfo.Location = new Point(supportInfo.Location.X, errorCode.Location.Y + errorCode.Size.Height + (2 * (int)HeightInPixels));
                technicalCode.Location = new Point(technicalCode.Location.X, supportInfo.Location.Y + supportInfo.Size.Height + (int)HeightInPixels);
                errorCode.Margin = new Padding(3, 15, 3, 0);
                supportInfo.Margin = new Padding(3, 15, 3, 0);
                technicalCode.Margin = new Padding(3, 15, 3, 0);
                supportInfo.Text = supportInfo.Text.Replace("\n\n\n", "\n\n");
                label5.Margin = new Padding(3, 15, 3, 0);


                label1.Text = txt["A problem has been detected..."];
                supportInfo.Text = txt["Troubleshooting introduction"] + "\n\n" + txt["Troubleshooting"] + "\n\n" + txt["Technical information"];
                string[] esplit = technicalCode.Text.Replace("*** STOP: ", "").Replace(")", "").Replace(" (", "*").Split('*');
                technicalCode.Text = txt["Technical information formatting"].Replace("{0}", esplit[0]).Replace("{1}", esplit[1]);
                foreach (Control c in this.Controls)
                {
                    if (c is Label && (c.Name != "waterMarkText"))
                    {
                        c.Font = me.GetFont();
                    }
                }
                if (me.GetBool("extrafile") && (me.GetBool("show_file")))
                {
                    technicalCode.Text += "\r\n\r\n" + txt["Culprit file memory address"].Replace("{0}", whatfail.ToUpper()).Replace("{1}", h1).Replace("{2}", h1).Replace("{3}", h3.ToLower());
                }
                technicalCode.Size = new Size(technicalCode.Size.Width, (int)((technicalCode.Text.Split('\n').Length + 2) * HeightInPixels));
                label5.Location = new Point(label5.Location.X, technicalCode.Location.Y + technicalCode.Size.Height);
                if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; this.ShowInTaskbar = true; this.ShowIcon = true; }
                if (!errorCode.Visible && !label5.Visible)
                {
                    supportInfo.Visible = false;
                    label1.Visible = false;
                }
                Program.loadfinished = true;
                if (fullscreen)
                {
                    this.TopMost = false;
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
                    this.Hide();
                }
                errorCode.Visible = me.GetBool("show_description");
                errorCode.Text = errorCode.Text.Replace("CRITICAL_OBJECT_TERMINATION", "A process or thread crucial to system operation has unexpectedly exited or been terminated.");
                if (!errorCode.Visible && this.Visible)
                {
                    supportInfo.Location = new Point(supportInfo.Location.X, supportInfo.Location.Y + 39);
                    technicalCode.Location = new Point(technicalCode.Location.X, technicalCode.Location.Y + 39);
                    label5.Location = new Point(label5.Location.X, label5.Location.Y + 39);
                }
                naturalclose = false;
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                MessageBox.Show("A blue screen couldn't be displayed due to an error\n\n" + ex.Message + "\n\n" + ex.StackTrace, "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (me.GetBool("autoclose"))
            {
                if (progress < 100)
                {
                    string labeltxt = "";
                    if (whatfail != "")
                    {
                        labeltxt = label5.Text.Split('\n')[0].Replace("Collecting data for crash dump ...", "") + "\n\n";
                    }
                    if (!labeltxt.Contains(me.GetTexts()["Collecting data for crash dump"]))
                    {
                        labeltxt += me.GetTexts()["Collecting data for crash dump"];
                    }
                    labeltxt += "\n" + me.GetTexts()["Initializing crash dump"];
                    progress++;
                    string ntext = "";
                    int spaces = 3 - progress.ToString().Length;
                    for (int i = 0; i < spaces; i++) { ntext += " "; }
                    ntext += progress.ToString();
                    labeltxt += "\n" + me.GetTexts()["Begin dump"] + "\n" + me.GetTexts()["Physical memory dump"].Replace("{0}", " " + ntext);
                    label5.Text = labeltxt;
                    if (progress == 100)
                    {
                        label5.Text += "\n" + me.GetTexts()["End dump"] + "\n" + me.GetTexts()["Technical support"];
                    }
                    float HeightInPixels;
                    using (Graphics g = this.CreateGraphics())
                    {
                        var points = label5.Font.SizeInPoints;
                        HeightInPixels = points * g.DpiX / 72;
                    }
                    if (label5.Location.Y + (int)(HeightInPixels * label5.Text.Split('\n').Length + 2) > this.ClientSize.Height)
                    {
                        int delta = 0;
                        while (label5.Location.Y + (int)(HeightInPixels * (label5.Text.Split('\n').Length + 2)) - delta >= this.ClientSize.Height)
                        {
                            delta += 1;
                        }
                        //delta += errorCode.Height;
                        foreach (Control c in this.Controls)
                        {
                            if (c.Name != "waterMarkText")
                            {
                                c.Location = new Point(c.Location.X, c.Location.Y - delta);
                            }
                        }
                    }
                }
            }
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
            if (tardisFade.Enabled == true) { return; }
            if (rainBowScreen.Enabled == true) { return; }
        }

        private void Xvsbs_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Xvsbs_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!fullscreen)
            {
                if (Program.f1.closecuzhidden == true)
                {
                    Program.f1.Close();
                }
            }
        }

        private void TardisFade_Tick(object sender, EventArgs e)
        {
            int r = this.BackColor.R;
            int target_r = bg.R;
            if (r > 0)
            {
                if (inr == false)
                {
                    r -= 1;
                }
                else if ((inr == true) && (ing == true) && (inb == true))
                {
                    r += 1;
                }
                if (r >= target_r)
                {
                    inr = false;
                }
            }
            else
            {
                inr = true;
                r += 1;
            }
            int gr = this.BackColor.G;
            int target_g = bg.G;
            if (gr > 0)
            {
                if (ing == false)
                {
                    gr -= 1;
                }
                else if ((inr == true) && (ing == true) && (inb == true))
                {
                    gr += 1;
                }
                if (gr >= target_g)
                {
                    ing = false;
                }
            }
            else
            {
                ing = true;
                gr += 1;
            }
            int b = this.BackColor.B;
            int target_b = bg.B;
            if (b > 0)
            {
                if (inb == false)
                {
                    b -= 1;
                }
                else if ((inr == true) && (ing == true) && (inb == true))
                {
                    b += 1;
                }
                if (b >= target_b)
                {
                    inb = false;
                }
            }
            else
            {
                inb = true;
                b += 1;
            }
            this.BackColor = Color.FromArgb(r, gr, b);
            foreach (WindowScreen ws in wss)
            {
                if (!ws.Visible)
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


        private void RainBowScreen_Tick(object sender, EventArgs e)
        {
            int r = this.BackColor.R;
            int gr = this.BackColor.G;
            int b = this.BackColor.B;
            if (state == "1")
            {
                if (inr == false)
                {
                    gr += 1;
                    if (gr == 255)
                    {
                        inr = true;
                        b += 1;
                        r -= 1;
                        state = "2";
                    }
                }
            }
            else if (state == "3")
            {
                r += 1;
                if (r > 255)
                {
                    r = 255;
                }
                if (ing == true)
                {
                    gr -= 1;
                    if (gr == 0)
                    {
                        ing = false;
                    }
                }
                if ((r == 255) && (gr == 0))
                {
                    inb = true;
                    state = "4";
                }
            }
            else if (state == "2")
            {
                b += 1;
                if (b > 255)
                {
                    b = 255;
                }
                if (inr == true)
                {
                    r -= 1;
                    if (r == 0)
                    {
                        inr = false;
                    }
                }
                if ((r == 0) && (b == 255))
                {
                    ing = true;
                    r = 1;
                    state = "3";
                }
            }
            else if (state == "4")
            {
                state = "4";
                if (inb == true)
                {
                    b -= 1;
                    if (b == 0)
                    {
                        state = "0";
                        inb = false;
                    }
                }
            }
            else if ((r == 255) && (gr == 0) && (b == 0))
            {
                state = "1";
                gr += 1;
            }
            this.BackColor = Color.FromArgb(r, gr, b);

            foreach (WindowScreen ws in wss)
            {
                try
                {
                    Program.dr.Draw(ws);
                }
                catch
                {
                    ws.Close();
                    this.naturalclose = true;
                }
            }
        }
    }
}
