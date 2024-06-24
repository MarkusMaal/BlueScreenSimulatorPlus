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
        internal BlueScreen me = Program.templates.GetAt(0);
        string h1;
        string h2;
        string h3;
        Color bg;
        Color fg;
        IDictionary<string, string> txt;

        string state = "0";
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        readonly List<Bitmap> freezescreens = new List<Bitmap>();
        Font commonFont;
        public Vistabs()
        {
            //
            // forcibly disable DPI scaling for these legacy configurations
            // otherwise, the font won't be pixel perfect
            //
            // to upscale on higher DPI settings, use fullscreen mode
            //
            
            InitializeComponent();
        }

        private void Xvsbs_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = me.GetIcon();
                this.Text = me.GetString("friendlyname");
                h1 = me.GenHex(8, me.GetFiles().ElementAt(0).Value[0]);
                h2 = me.GenHex(8, me.GetFiles().ElementAt(0).Value[1]);
                h3 = me.GenHex(8, me.GetFiles().ElementAt(0).Value[2]);
                // disable ClearType, if the OS is Windows Vista
                if (me.GetString("os") == "Windows Vista")
                {
                    introductionText.UseCompatibleTextRendering = true;
                    errorCode.UseCompatibleTextRendering = true;
                    supportInfo.UseCompatibleTextRendering = true;
                    technicalCode.UseCompatibleTextRendering = true;
                    dumpText.UseCompatibleTextRendering = true;
                }
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
                if (Program.gs.EnableEggs)
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
                commonFont = new Font(me.GetFont().FontFamily, me.GetFont().Size * 96f / CreateGraphics().DpiX, me.GetFont().Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                using (Graphics g = this.CreateGraphics())
                {
                    var points = commonFont.SizeInPoints;
                    HeightInPixels = points * g.DpiX / 72;
                }

                introductionText.Text = txt["A problem has been detected..."];
                supportInfo.Text = txt["Troubleshooting introduction"] + "\n\n" + txt["Troubleshooting"] + "\n\n" + txt["Technical information"];
                string[] esplit = technicalCode.Text.Replace("*** STOP: ", "").Replace(")", "").Replace(" (", "*").Split('*');
                technicalCode.Text = txt["Technical information formatting"].Replace("{0}", esplit[0]).Replace("{1}", esplit[1]);
                foreach (Control c in this.Controls)
                {
                    if (c is Label && (c.Name != "waterMarkText"))
                    {
                        c.Font = commonFont;
                    }
                }
                if (me.GetBool("extrafile") && (me.GetBool("show_file")))
                {
                    technicalCode.Text += "\r\n\r\n" + txt["Culprit file memory address"].Replace("{0}", whatfail.ToUpper()).Replace("{1}", h1).Replace("{2}", h2).Replace("{3}", h3.ToLower());
                }
                errorCode.Visible = me.GetBool("show_description");
                if (me.GetBool("autoclose"))
                {
                    dumpText.Text = txt["Collecting data for crash dump"]; dumpText.Text += "\n" + txt["Initializing crash dump"];
                    dumpText.Text += "\n" + txt["Begin dump"] + "\n" + txt["Physical memory dump"] + "   0";
                } else
                {
                    dumpText.Visible = false;
                }
                if (whatfail != "")
                {
                    errorCode.Text = txt["Culprit file"] + whatfail.ToUpper() + "\n\n" + errorCode.Text;
                    dumpText.Margin = new Padding(3, 15, 3, 0);
                }
                int addsome = 0;
                if (errorCode.Visible)
                {
                    addsome = (int)(2.25 * HeightInPixels);
                    if (whatfail != "")
                    {
                        addsome += (int)(HeightInPixels * 2);
                    }
                }
                int support = introductionText.Location.Y + introductionText.Size.Height + (int)(HeightInPixels / 2) + addsome;
                int ecode = introductionText.Location.Y + (int)(HeightInPixels / 2) + introductionText.Size.Height;
                if (me.GetString("os") == "Windows 7")
                {
                    ecode += (int)(HeightInPixels);
                    support += (int)(HeightInPixels * 1.5);
                }
                supportInfo.Location = new Point(supportInfo.Location.X, support);
                errorCode.Location = new Point(errorCode.Location.X, ecode);
                technicalCode.Location = new Point(technicalCode.Location.X, (int)(support + supportInfo.Size.Height + HeightInPixels));
                errorCode.Margin = new Padding(3, 15, 3, 0);
                supportInfo.Margin = new Padding(3, 15, 3, 0);
                technicalCode.Margin = new Padding(3, 15, 3, 0);
                supportInfo.Text = supportInfo.Text.Replace("\n\n\n", "\n\n");
                dumpText.Margin = new Padding(3, 15, 3, 0);
                technicalCode.Size = new Size(technicalCode.Size.Width, (int)((technicalCode.Text.Split('\n').Length + 2) * HeightInPixels));
                dumpText.Location = new Point(dumpText.Location.X, technicalCode.Location.Y + 4 * (int)HeightInPixels);
                if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; this.ShowInTaskbar = true; this.ShowIcon = true; }
                if (!errorCode.Visible && !dumpText.Visible)
                {
                    supportInfo.Visible = false;
                    introductionText.Visible = false;
                }
                int[] colors = { this.BackColor.R + 50, this.BackColor.G + 50, this.BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
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
                                if (Program.gs.DisplayMode != "none")
                                {
                                    ws.StartPosition = FormStartPosition.Manual;
                                    ws.Location = s.WorkingArea.Location;
                                    ws.Size = new Size(s.WorkingArea.Width, s.WorkingArea.Height);
                                    ws.primary = false;

                                    if (Program.gs.DisplayMode == "freeze")
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
                            if (Program.gs.DisplayMode == "freeze")
                            {
                                ws.screenDisplay.Image = freezescreens[i - 1];
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
                    dumpText.Location = new Point(dumpText.Location.X, dumpText.Location.Y + 39);
                }
                naturalclose = false;
                if (me.GetBool("acpi"))
                {
                    supportInfo.Text = technicalCode.Text;
                    errorCode.Visible = false;
                    technicalCode.Visible = false;
                    dumpText.Visible = false;
                    introductionText.Visible = false;
                }
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                this.Hide();
                if (Program.gs.EnableEggs) { me.Crash(ex.Message, ex.StackTrace, "OrangeScreen"); }
                else { MessageBox.Show("The blue screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (me.GetBool("autoclose"))
                {
                    if (progress < 100)
                    {
                        string labeltxt = "";
                        if (whatfail != "")
                        {
                            labeltxt = dumpText.Text.Split('\n')[0].Replace("Collecting data for crash dump ...", "") + "\n\n";
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
                        dumpText.Text = labeltxt;
                        if (progress == 100)
                        {
                            dumpText.Text += "\n" + me.GetTexts()["End dump"] + "\n" + me.GetTexts()["Technical support"];
                        }
                        float HeightInPixels;
                        using (Graphics g = this.CreateGraphics())
                        {
                            var points = dumpText.Font.SizeInPoints;
                            HeightInPixels = points * g.DpiX / 72;
                        }
                        if (dumpText.Location.Y + (int)(HeightInPixels * dumpText.Text.Split('\n').Length + 2) > this.ClientSize.Height)
                        {
                            int delta = 0;
                            while (dumpText.Location.Y + (int)(HeightInPixels * (dumpText.Text.Split('\n').Length + 2)) - delta >= this.ClientSize.Height)
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
                    this.BringToFront();
                    this.Activate();
                }
                if (tardisFade.Enabled == true) { return; }
                if (rainBowScreen.Enabled == true) { return; }
            } catch (Exception ex)
            {
                screenUpdater.Enabled = false;
                me.Crash(ex.Message, ex.StackTrace, "OrangeScreen");
                this.Close();
            }
        }

        private void Xvsbs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = Program.gs.PM_Lockout;
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
                if (Program.gs.PM_CloseMainUI)
                {
                    Application.Exit();
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
            foreach (Control c in this.Controls)
            {
                c.BackColor = this.BackColor;
            }
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
            foreach (Control c in this.Controls)
            {
                c.BackColor = this.BackColor;
                int[] colorsa = { this.BackColor.R - 100, this.BackColor.G - 100, this.BackColor.B - 100 };
                if (colorsa[0] < 0) { colorsa[0] += 255; }
                if (colorsa[1] < 0) { colorsa[1] += 255; }
                if (colorsa[2] < 0) { colorsa[2] += 255; }
                c.ForeColor = Color.FromArgb(colorsa[0], colorsa[1], colorsa[2]);
            }
            int[] colors = { this.BackColor.R + 20, this.BackColor.G + 20, this.BackColor.B + 20 };
            if (colors[0] > 255) { colors[0] -= 255; }
            if (colors[1] > 255) { colors[1] -= 255; }
            if (colors[2] > 255) { colors[2] -= 255; }
            waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
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

        private void Vistabs_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F7))
            {
                foreach (WindowScreen ws in wss)
                {
                    try { if (ws.Visible == true) { ws.Close(); } }
                    catch { }
                }
                Close();
            }
        }
    }
}
