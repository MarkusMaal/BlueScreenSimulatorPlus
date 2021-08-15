using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class Xvsbs : Form
    {
        public bool fullscreen = true;
        public string whatfail = "";
        private bool naturalclose = false;
        bool inr = false;
        bool ing = false;
        bool inb = false;
        internal BlueScreen me = Program.bluescreens[0];
        Color bg;
        Color fg;
        IDictionary<string, string> txt;

        string state = "0";
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        readonly List<Bitmap> freezescreens = new List<Bitmap>();
        public Xvsbs()
        {
            InitializeComponent();
        }

        private void Xvsbs_Load(object sender, EventArgs e)
        {
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
            if (Program.f1.enableeggs) { 
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
            if (whatfail != "") {
                label5.Text = "***  " + whatfail.ToUpper() + " - Address " + me.GenHex(8, "RRRRRRRR") + " base at " + me.GenHex(8, "RRRRRRRR") + ", DateStamp " + me.GenHex(8, "RRRRRRRR").ToLower();
                errorCode.Text = "The problem seems to be caused by the following file: " + whatfail.ToUpper() + "\n\n" + errorCode.Text;
                supportInfo.Location = new Point(supportInfo.Location.X, supportInfo.Location.Y + 24);
                technicalCode.Location = new Point(label5.Location.X, technicalCode.Location.Y + 24);
                label5.Location = new Point(label5.Location.X, label5.Location.Y + 24);
            }
            label1.Text = txt["A problem has been detected..."];
            supportInfo.Text = txt["Troubleshooting introduction"] + "\n\n" + txt["Troubleshooting"] + "\n\n" + txt["Technical information"];
            string[] esplit = technicalCode.Text.Replace("*** STOP: ", "").Replace(")", "").Replace(" (", "*").Split('*');
            technicalCode.Text = txt["Technical information formatting"].Replace("{0}", esplit[0]).Replace("{1}", esplit[1]);

            try
            { 
                label5.Text = txt["Physical memory dump"].Split('\n')[0].Trim() + "\n" + txt["Physical memory dump"].Split('\n')[1].Trim() + "\n" + txt["Technical support"].Split('\n')[0].Trim() + "\n" + txt["Technical support"].Split('\n')[1].Trim();
            }
            catch
            {
                }

            foreach (Control c in this.Controls)
            {
                if (c is Label)
                {
                    c.Font = me.GetFont();
                }
            }
            if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; this.ShowInTaskbar = true; this.ShowIcon = true; }
            if (!errorCode.Visible && !label5.Visible)
            {
                supportInfo.Visible = false;
                label1.Visible = false;
            }
            errorCode.Text = errorCode.Text.Replace("IRQL", "DRIVER_IRQL");
            errorCode.Text = errorCode.Text.Replace("MANUALLY_INITIATED_CRASH", "The end-user manually generated the crash dump.");
            errorCode.Text = errorCode.Text.Replace("VIDEO_TDR_", "VIDEO_TDR_ERROR");
            technicalCode.Text = technicalCode.Text.Replace("STOP: ERROR", "STOP: 0x00000116");
            Program.loadfinished = true;
            if (fullscreen) { 
                this.TopMost = false;
                if (Screen.AllScreens.Length > 1) { 
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
            if (!errorCode.Visible && this.Visible)
            {
                supportInfo.Location = new Point(supportInfo.Location.X, supportInfo.Location.Y + 39);
                technicalCode.Location = new Point(technicalCode.Location.X, technicalCode.Location.Y + 39);
                label5.Location = new Point(label5.Location.X, label5.Location.Y + 39);
            }
            naturalclose = false;
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
                } else if ((inr == true) && (ing == true) && (inb == true))
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
            }else if (state == "4")
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
            }else if ((r == 255) && (gr == 0) && (b == 0))
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
