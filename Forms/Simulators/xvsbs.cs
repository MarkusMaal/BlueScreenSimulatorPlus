﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class Xvsbs : Form
    {
        public bool fullscreen = true;
        public string whatfail = "";
        private bool naturalclose = false;
        private int moves = 0;
        bool inr = false;
        bool ing = false;
        bool inb = false;
        internal BlueScreen me = Program.templates.GetAt(0);
        Color bg;
        Color fg;
        IDictionary<string, string> txt;

        string state = "0";
        public Xvsbs()
        {
            if (Program.verificate)
            {
                InitializeComponent();
            }
        }

        private void Xvsbs_Load(object sender, EventArgs e)
        {
            try
            {
                this.Icon = me.GetIcon();
                this.Text = me.GetString("friendlyname");
                bg = me.GetTheme(true);
                fg = me.GetTheme(false);
                txt = me.GetTexts();
                foreach (Control c in this.Controls)
                {
                    if (c is AliasedLabel)
                    {
                        c.BackColor = Color.Transparent;
                        c.ForeColor = fg;
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
                if (whatfail != "")
                {

                    errorCode.Text = txt["Culprit file"] + whatfail.ToUpper() + "\n\n" + errorCode.Text;
                    supportInfo.Location = new Point(supportInfo.Location.X, supportInfo.Location.Y + 24);
                    technicalCode.Location = new Point(dumpLabel.Location.X, technicalCode.Location.Y + 24);
                    dumpLabel.Location = new Point(dumpLabel.Location.X, dumpLabel.Location.Y + 24);
                }
                introductionText.Text = txt["A problem has been detected..."];
                supportInfo.Text = txt["Troubleshooting introduction"] + "\n\n" + txt["Troubleshooting"] + "\n\n\n" + txt["Technical information"];
                string[] esplit = technicalCode.Text.Replace("*** STOP: ", "").Replace(")", "").Replace(" (", "*").Split('*');
                technicalCode.Text = txt["Technical information formatting"].Replace("{0}", esplit[0]).Replace("{1}", esplit[1]);

                if (me.GetBool("extrafile") && (whatfail != ""))
                {
                    technicalCode.Text += "\r\n\r\n\r\n***  " + whatfail.ToUpper() + " - Address " + me.GenHex(8, me.GetFiles().ElementAt(0).Value[0]) + " base at " + me.GenHex(8, me.GetFiles().ElementAt(0).Value[1]) + ", DateStamp " + me.GenHex(8, me.GetFiles().ElementAt(0).Value[2]).ToLower() + "\r\n\r\n\r\n";
                }
                try
                {
                    if (me.GetBool("autoclose") && !me.GetBool("extrafile"))
                    {
                        dumpLabel.Text = txt["Physical memory dump"].Split('\n')[0].Trim();
                    }
                    dumpTimer.Enabled = (me.GetBool("autoclose") && !me.GetBool("extrafile"));
                }
                catch
                {
                }
                // for DPI awereness
                Font commonFont = new Font(me.GetFont().FontFamily, me.GetFont().Size * 96f / CreateGraphics().DpiX, me.GetFont().Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
                foreach (Control c in this.Controls)
                {
                    if (c is Label && (c.Name != "waterMarkText"))
                    {
                        //c.Font = me.GetFont();
                        c.Font = commonFont;
                    }
                }
                if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; this.ShowInTaskbar = true; this.ShowIcon = true; }
                if (!errorCode.Visible && !dumpLabel.Visible)
                {
                    supportInfo.Visible = false;
                    introductionText.Visible = false;
                }
                errorCode.Text = errorCode.Text.Replace("MANUALLY_INITIATED_CRASH", "The end-user manually generated the crash dump.");
                errorCode.Text = errorCode.Text.Replace("VIDEO_TDR_", "VIDEO_TDR_ERROR");
                technicalCode.Text = technicalCode.Text.Replace("STOP: ERROR", "STOP: 0x00000116");
                int[] colors = { this.BackColor.R + 50, this.BackColor.G + 50, this.BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                technicalCode.Location = new Point(supportInfo.Location.X, supportInfo.ClientRectangle.Height + supportInfo.ClientRectangle.Top + errorCode.ClientRectangle.Top + errorCode.ClientRectangle.Height + introductionText.ClientRectangle.Height + introductionText.ClientRectangle.Top + 54);
                dumpLabel.Location = new Point(technicalCode.Location.X, technicalCode.Location.Y + 48);
                waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                Program.loadfinished = true;
                if (fullscreen && (this.Opacity != 0.0))
                {
                    this.TopMost = false;
                    Program.dr.Init(this);
                    this.Hide();
                }
                errorCode.Visible = me.GetBool("show_description");
                if (!errorCode.Visible && this.Visible)
                {
                    supportInfo.Location = new Point(supportInfo.Location.X, supportInfo.Location.Y - 35);
                    technicalCode.Location = new Point(technicalCode.Location.X, technicalCode.Location.Y - 35);
                    dumpLabel.Location = new Point(dumpLabel.Location.X, dumpLabel.Location.Y - 35);
                }
                if (me.GetBool("rainbow"))
                {
                    Program.dr.DrawRainbow(this);
                }
                naturalclose = false;
                dumpLabel.Visible = me.GetBool("autoclose") && !me.GetBool("extrafile");
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                if (Program.gs.EnableEggs) { me.Crash(ex, "OrangeScreen"); }
                else { MessageBox.Show("The crash screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (tardisFade.Enabled == true) { return; }
            if (rainBowScreen.Enabled == true) { return; }
            try
            {
                if (me.GetBool("autoclose") && !dumpLabel.Text.Contains(txt["Physical memory dump"].Split('\n')[1].Trim()))
                {
                    dumpLabel.Text += "\n" + txt["Physical memory dump"].Split('\n')[1].Trim() + "\n" + txt["Technical support"].Split('\n')[0].Trim() + "\n" + txt["Technical support"].Split('\n')[1].Trim();
                }
            } catch (Exception ex)
            {
                dumpTimer.Enabled = false;
                if (Program.gs.EnableEggs) { me.Crash(ex, "OrangeScreen"); }
                else { MessageBox.Show("An error occoured.\r\n\r\n" + ex.Message + "\r\n\r\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                Program.dr.Dispose();
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
            foreach (Control c in this.Controls)
            {
                c.BackColor = this.BackColor;
            }
            Program.dr.DrawAll();
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
            foreach (WindowScreen ws in Program.dr.wss)
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

        private void ScreenUpdater_Tick(object sender, EventArgs e)
        {
            if (fullscreen)
            {
                Program.dr.DrawAll();
                this.BringToFront();
                this.Activate();
            }
        }

        private void Xvsbs_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F7))
            {
                Program.dr.Dispose();
                Close();
            }
            else if ((e.KeyCode == Keys.F2) && me.GetBool("windowed"))
            {
                string output = Program.dr.Screenshot(this);
                Cursor.Show();
                MessageBox.Show($"Image saved as {output}", "Screenshot taken", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Xvsbs_MouseMove(object sender, MouseEventArgs e)
        {
            moves++;
            if (moves > 50 && Program.isScreensaver && Program.gs.MouseMoveExit)
            {
                Close();
            }
        }
    }
}
