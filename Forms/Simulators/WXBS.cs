﻿using System;
using System.Drawing;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class WXBS : Form
    {
        public bool server = false;
        public bool qr = true;
        public bool close = true;
        public bool w8 = false;
        public bool w11 = false;
        private bool w8close = false;
        private bool oldmode = true;
        public bool green = false;
        public string code = "";
        public string whatfail = "";
        private int progress = 0;
        private int progressmillis = 0;
        internal int maxprogressmillis = 0;
        private string secondPart = "";
        private Point initialCursorPosition;
        internal BlueScreen me = Program.templates.GetAt(0);
        
        public WXBS()
        {
            if (new Verifile().RC() && Program.verificate)
            {
                InitializeComponent();
            } else
            {
                Program.loadfinished = true;
                Program.verifile.HideUI();
                Program.verifile.ShowBad();
                Application.Exit();
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
                    errorCode.Location = new Point(errorCode.Location.X - 6, errorCode.Location.Y);
                    if (!me.GetBool("qr"))
                    {
                        errorCode.Location = new Point(errorCode.Location.X + 3, errorCode.Location.Y);
                    }
                    if (w8)
                    {
                        errorCode.Location = supportInfo.Location;
                        supportInfo.Visible = false;
                    }
                }
                Icon = me.GetIcon();
                Text = me.GetString("friendlyname");
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
                if (me.GetTexts()["Information text with dump"].Contains("."))
                {
                    yourPCranLabel.Text = me.GetTexts()["Information text with dump"].Split('.')[0] + ".\r\n\r\n";
                } else
                {
                    yourPCranLabel.Text = me.GetTexts()["Information text with dump"];
                }
                try
                {
                    secondPart = me.GetTexts()["Information text with dump"].Substring(yourPCranLabel.Text.Length - 4);
                }
                catch
                {
                    secondPart = "";
                }

                qrCode.Size = new Size(me.GetInt("qr_size"), me.GetInt("qr_size"));

                if (me.GetString("qr_file") == "local:1") { qrCode.Image = Properties.Resources.bsodqr_transparent; }
                else if (me.GetString("qr_file") == "local:0") { qrCode.Image = Properties.Resources.bsodqr; }
                else { try { qrCode.Image = Image.FromFile(me.GetString("qr_file")); } catch { qrCode.Image = Properties.Resources.bsodqr; } }
                if (w8 == true)
                {
                    yourPCranLabel.Text = me.GetTexts()["Information text with dump"].Split('.')[0] + ".\r\n\r\n\r\n";
                    secondPart = me.GetTexts()["Information text with dump"].Substring(yourPCranLabel.Text.Length - 6);
                    if (close == true) { close = false; w8close = true; }

                }
                else
                {
                    //progressIndicator.Text = me.GetTexts()["Progress"].Replace("{0}", "0");
                    supportInfo.Text = me.GetTexts()["Additional information"];
                }
                if (me.GetBool("blackscreen"))
                {
                    BackColor = Color.Black;
                }
                if (!w8close)
                {
                    if (close == false)
                    {
                        yourPCranLabel.Text = me.GetTexts()["Information text without dump"].Split('.')[0] + ".\r\n\r\n";
                        secondPart = me.GetTexts()["Information text without dump"].Substring(yourPCranLabel.Text.Length - 4);
                    }
                    if (green)
                    {
                        BackColor = Color.FromArgb(47, 121, 42);
                        yourPCranLabel.Text = yourPCranLabel.Text.Replace("PC", "Windows Insider Build");
                    }
                    if (server)
                    {
                        emoticonLabel.Visible = false;
                        yourPCranLabel.Margin = new Padding(yourPCranLabel.Margin.Left, 80, 0, 0);
                    }
                    if (me.GetBool("device")) { yourPCranLabel.Text = yourPCranLabel.Text.Replace("PC", "device"); }
                }
                try { waterMarkText.ForeColor = Color.FromArgb(BackColor.R + 60, BackColor.G + 60, BackColor.B + 60); } catch { }
                if (FormBorderStyle == FormBorderStyle.None)
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
                emoticonLabel.Padding = new Padding(0, Convert.ToInt32(Height * ((double)me.GetInt("margin-y") / 100.0)), 0, 0);
                qrMargin.Width = Convert.ToInt32(Width * ((double)me.GetInt("margin-x") / 100.0)) - 10;
                yourPCranLabel.Padding = new Padding(qrMargin.Width - 3, 0, 0, 0);
                progressIndicator.Padding = yourPCranLabel.Padding;
                emoticonLabel.Margin = new Padding(yourPCranLabel.Padding.Left - (int)(emoticonLabel.Width * 0.2), 0, 0, 0);
                horizontalFlowPanel.Width = Width - 10;
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
                if (!w8 && !me.GetBool("crashdump") && me.GetBool("autoclose") && me.GetTexts().Keys.Contains("No crashdump with autorestart"))
                {
                    yourPCranLabel.Text = yourPCranLabel.Text.Substring(0,yourPCranLabel.Text.Length - 2);
                    secondPart = " " + (me.GetTexts()["No crashdump with autorestart"]);
                } else if (!w8 && !me.GetBool("crashdump") && !me.GetBool("autoclose") && me.GetTexts().Keys.Contains("No crashdump"))
                {
                    yourPCranLabel.Text = yourPCranLabel.Text.Substring(0,yourPCranLabel.Text.Length - 2);
                    secondPart = " " + (me.GetTexts()["No crashdump"]) + "\r\n";
                }
                if (Opacity == 0.0)
                {
                    yourPCranLabel.Text = yourPCranLabel.Text.Replace("\r\n", "");
                    yourPCranLabel.Text += secondPart;
                    if (!w8)
                    {
                        progressIndicator.Visible = true;
                        progressIndicator.Text = string.Format(me.GetTexts()["Progress"], "0");
                    } else
                    {
                        yourPCranLabel.Text = string.Format(yourPCranLabel.Text, "0");
                    }
                }
                Program.loadfinished = true;
                if (!me.GetBool("windowed") && (Opacity != 0.0))
                {
                    Program.dr.Init(this, true);
                }
                initialCursorPosition = Cursor.Position;
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                progressUpdater.Enabled = false;
                Hide();
                if (Program.gs.EnableEggs) { me.Crash(ex, "OrangeScreen"); }
                else { MessageBox.Show("The crash screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                Close();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!oldmode) { progressmillis++; }
                if (oldmode && progressmillis != 21) { progressmillis = 20; }
                if (!w8close && progressmillis > 20)
                {
                    progressIndicator.Visible = true;
                    if (!Program.verificate) { throw new NotImplementedException(); }
                    if ((oldmode && (progress >= 100)) || (progressmillis == maxprogressmillis))
                    {
                        progressUpdater.Enabled = false;
                        if (me.GetBool("autoclose") && !Program.isScreensaver) { Close(); }
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
                    progressIndicator.Text = string.Format(me.GetTexts()["Progress"], progress);
                }
                else
                {
                    if ((oldmode && (progress >= 100)) || (progressmillis == maxprogressmillis))
                    {
                        yourPCranLabel.Text = yourPCranLabel.Text.Replace(progress.ToString() + "%", "100%");
                        progressUpdater.Enabled = false;
                        if (me.GetBool("autoclose") && !Program.isScreensaver)
                        {
                            Close();
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
                if ((progressmillis == 20) && (secondPart != ""))
                {
                    string s = yourPCranLabel.Text.Replace("\r\n", "");
                    if (w8)
                    {
                        yourPCranLabel.Text = s + secondPart.ToString().Replace("{0}", progress.ToString());
                    } else
                    {
                        if (me.GetBool("crashdump")) { progressIndicator.Text = me.GetTexts()["Progress"].Replace("{0}", progress.ToString()); }
                        else { progressUpdater.Enabled = false; }
                        yourPCranLabel.Text = s + secondPart.ToString();
                    }
                    if (oldmode) { progressmillis += 1; maxprogressmillis = 9999; }
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
            if (Program.gs.PM_ShowMessage)
            {
                MessageBox.Show(Program.gs.PM_MsgText, Program.gs.PM_MsgTitle, Program.gs.PM_MsgType, Program.gs.PM_MsgIcon);
                Program.gs.PM_ShowMessage = false;
            }
            if (Program.gs.PM_CloseMainUI)
            {
                Application.Exit();
            }
        }

        private void WXBS_Resize(object sender, EventArgs e)
        {
            emoticonLabel.Padding = new Padding(0, Convert.ToInt32(Height * ((double)me.GetInt("margin-y") / 100.0)), 0, 0);
            qrMargin.Width = Convert.ToInt32(Width * ((double)me.GetInt("margin-x") / 100.0)) - 10;
            yourPCranLabel.Padding = new Padding(qrMargin.Width - 3, 0, 0, 0);
            progressIndicator.Padding = yourPCranLabel.Padding;
            emoticonLabel.Margin = new Padding(yourPCranLabel.Padding.Left - (int)(emoticonLabel.Width * 0.2), 0, 0, 0);
            horizontalFlowPanel.Width = Width - 10;

            if (qr == true)
            {
                //errorCode.Location = new Point(3, 56);
                _ = qrCode.FindForm().PointToClient(qrCode.Parent.PointToScreen(qrCode.Location));
                //supportContainer.Location = new Point(qrMargin.Width + qrCode.Width + 20, locationOnForm.Y);
            }
            else
            {
                //errorCode.Location = new Point(3, 0);
                _ = horizontalFlowPanel.FindForm().PointToClient(horizontalFlowPanel.Parent.PointToScreen(horizontalFlowPanel.Location));
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
                BringToFront();
                Activate();
            }
            if (Program.isScreensaver && Program.gs.MouseMoveExit && (Cursor.Position.X != initialCursorPosition.X) && (Cursor.Position.Y != initialCursorPosition.Y))
            {
                Close();
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
    }
}
