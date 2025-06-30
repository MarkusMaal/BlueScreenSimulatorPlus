﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private int progressmillis = 0;
        private bool oldmode = true;
        internal int maxprogressmillis = 0;
        internal BlueScreen me = Program.templates.GetAt(0);
        public WXBS()
        {
            if (new Verifile().RC() && Program.verificate)
            {
                InitializeComponent();
            }
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

        private void WXBS_Load(object sender, EventArgs e)
        {
            try
            {
                oldmode = me.AllProgress().Keys.Count == 0;
                if (!oldmode)
                {
                    progressUpdater.Interval = 1;
                }
                if (w8 || !qr)
                {
                    supportContainer.Margin = new Padding(0,3,3,3);
                    supportInfo.Location = new Point(supportInfo.Location.X - 3, supportInfo.Location.Y);
                    errorCode.Location = new Point(errorCode.Location.X - 3, errorCode.Location.Y);
                    if (w8)
                    {
                        errorCode.Location = supportInfo.Location;
                        supportInfo.Visible = false;
                    }
                }
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
                if (me.GetBool("blackscreen"))
                {
                    this.BackColor = Color.Black;
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
                    if (me.GetBool("device")) { yourPCranLabel.Text = yourPCranLabel.Text.Replace("PC", "device"); }
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
                emoticonLabel.Padding = new Padding(0, Convert.ToInt32(this.Height * ((double)me.GetInt("margin-y") / 100.0)), 0, 0);
                qrMargin.Width = Convert.ToInt32(this.Width * ((double)me.GetInt("margin-x") / 100.0)) - 10;
                yourPCranLabel.Padding = new Padding(qrMargin.Width - 3, 0, 0, 0);
                progressIndicator.Padding = yourPCranLabel.Padding;
                emoticonLabel.Margin = new Padding(yourPCranLabel.Padding.Left - (int)(emoticonLabel.Width * 0.2), 0, 0, 0);
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
                    //supportInfo.Visible = true;
                    //errorCode.Location = new Point(3, 56);
                    Point locationOnForm = qrCode.FindForm().PointToClient(qrCode.Parent.PointToScreen(qrCode.Location));
                    //supportContainer.Location = new Point(qrMargin.Width + qrCode.Width + 20, locationOnForm.Y);
                }
                else
                {
                    qrCode.Visible = false;
                    //supportInfo.Visible = false;
                    //errorCode.Location = new Point(3, 0);
                    Point locationOnForm = horizontalFlowPanel.FindForm().PointToClient(horizontalFlowPanel.Parent.PointToScreen(horizontalFlowPanel.Location));
                    //supportContainer.Location = new Point(qrMargin.Width - 13, locationOnForm.Y);
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
                    Program.dr.Init(this, true);
                }
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                progressUpdater.Enabled = false;
                this.Hide();
                if (Program.gs.EnableEggs) { me.Crash(ex, "OrangeScreen"); }
                else { MessageBox.Show("The blue screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!oldmode) { progressmillis++; }
                if (!w8close)
                {
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
                    } else
                    {
                        progress += me.GetProgression(progressmillis);
                    }
                    progressIndicator.Text = me.GetTexts()["Progress"].Replace("{0}", progress.ToString());
                }
                else
                {
                    if ((oldmode && (progress >= 100)) || (progressmillis == maxprogressmillis))
                    {
                        yourPCranLabel.Text = yourPCranLabel.Text.Replace(progress.ToString() + "%", "100%");
                        progressUpdater.Enabled = false;
                        if (me.GetBool("autoclose"))
                        {
                            this.Close();
                        }
                    }
                    string oldprogress = progress.ToString();
                    if (oldmode)
                    {
                        progress += 1;
                        if (progress > 60) { progressUpdater.Interval = 300; }
                    }
                    else
                    {
                        progress += me.GetProgression(progressmillis);
                    }
                    yourPCranLabel.Text = yourPCranLabel.Text.Replace(oldprogress + "%", progress.ToString() + "%");
                }
            } catch (Exception ex)
            {
                progressUpdater.Enabled = false;
                if (Program.gs.EnableEggs) { me.Crash(ex, "GreenScreen"); }
                else { MessageBox.Show("An error has occoured.\n\n" + ex.Message + "\n\n" + ex.StackTrace.ToString(), "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                
            }
        }

        private void WXBS_FormClosed(object sender, FormClosedEventArgs e)
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

        private void WXBS_Resize(object sender, EventArgs e)
        {
            emoticonLabel.Padding = new Padding(0, Convert.ToInt32(this.Height * ((double)me.GetInt("margin-y") / 100.0)), 0, 0);
            qrMargin.Width = Convert.ToInt32(this.Width * ((double)me.GetInt("margin-x") / 100.0)) - 10;
            yourPCranLabel.Padding = new Padding(qrMargin.Width - 3, 0, 0, 0);
            progressIndicator.Padding = yourPCranLabel.Padding;
            emoticonLabel.Margin = new Padding(yourPCranLabel.Padding.Left - (int)(emoticonLabel.Width * 0.2), 0, 0, 0);
            horizontalFlowPanel.Width = this.Width - 10;

            if (qr == true)
            {
                //errorCode.Location = new Point(3, 56);
                Point locationOnForm = qrCode.FindForm().PointToClient(qrCode.Parent.PointToScreen(qrCode.Location));
                //supportContainer.Location = new Point(qrMargin.Width + qrCode.Width + 20, locationOnForm.Y);
            }
            else
            {
                //errorCode.Location = new Point(3, 0);
                Point locationOnForm = horizontalFlowPanel.FindForm().PointToClient(horizontalFlowPanel.Parent.PointToScreen(horizontalFlowPanel.Location));
                //supportContainer.Location = new Point(qrMargin.Width - 13, locationOnForm.Y);
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
                foreach (WindowScreen ws in Program.dr.wss)
                {
                    Program.dr.Draw(ws, me.GetBool("watermark"));
                }
                this.BringToFront();
                this.Activate();
            }
        }

        private void WXBS_KeyDown(object sender, KeyEventArgs e)
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

        private void WXBS_Paint(object sender, PaintEventArgs e)
        {
        }

        private void WXBS_LocationChanged(object sender, EventArgs e)
        {

        }
    }
}
