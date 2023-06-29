using SimulatorDatabase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class BootMgr : Form
    {
        readonly List<WindowScreen> wss = new List<WindowScreen>();
        private bool naturalclose = false;
        internal BlueScreen me;
        public BootMgr()
        {
            InitializeComponent();
        }

        private void KeyChecker(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            } else if (e.KeyCode == Keys.F7) { this.Close(); }
        }

        private void Initialization(object sender, EventArgs e)
        {
            try
            {
                this.Icon = me.GetIcon();
                this.Text = me.GetString("friendlyname");
                Color bg = me.GetTheme(true);
                Color fg = me.GetTheme(false);
                Color hbg = me.GetTheme(true, true);
                Color hfg = me.GetTheme(false, true);
                this.BackColor = bg; this.ForeColor = fg;
                IDictionary<string, string> txt = me.GetTexts();
                IDictionary<string, string> titles = me.GetTitles();
                //this.Font = me.GetFont();
                bootmgrTitle.BackColor = fg; bootmgrTitle.ForeColor = bg; bootmgrTitle.Text = titles["Main"];
                bootmgrEnterContinue.BackColor = fg; bootmgrEnterContinue.ForeColor = bg; bootmgrEnterContinue.Text = txt["Continue"];
                bootmgrEscapeExit.BackColor = fg; bootmgrEscapeExit.ForeColor = bg; bootmgrEscapeExit.Text = txt["Exit"];

                bootmgrIntro.BackColor = bg; bootmgrIntro.ForeColor = fg; bootmgrIntro.Text = txt["Troubleshooting introduction"];
                bootmgrTroubleshoot.BackColor = bg; bootmgrTroubleshoot.ForeColor = fg; bootmgrTroubleshoot.Text = txt["Troubleshooting"];
                bootmgrConsultAdmin.BackColor = bg; bootmgrConsultAdmin.ForeColor = fg; bootmgrConsultAdmin.Text = txt["Troubleshooting without disc"];
                bootmgrStatus.BackColor = bg; bootmgrStatus.ForeColor = fg; bootmgrStatus.Text = txt["Status"];
                bootmgrInfo.BackColor = bg; bootmgrInfo.ForeColor = fg; bootmgrInfo.Text = txt["Info"];

                bootmgrStatusCode.BackColor = hbg; bootmgrStatusCode.ForeColor = hfg; bootmgrStatusCode.Text = me.GetString("code").ToLower();
                bootmgrInfoDetails.BackColor = hbg; bootmgrInfoDetails.ForeColor = hfg; bootmgrInfoDetails.Text = txt["Error description"];

                this.TopMost = false;
                Program.loadfinished = true;
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
                            }
                        }
                        wss.Add(ws);
                    }
                }
                foreach (WindowScreen ws in wss)
                {
                    ws.Show();
                }
                this.waterMarkText.Visible = me.GetBool("watermark");
                int[] colors = { this.BackColor.R + 50, this.BackColor.G + 50, this.BackColor.B + 50 };
                if (colors[0] > 255) { colors[0] -= 255; }
                if (colors[1] > 255) { colors[1] -= 255; }
                if (colors[2] > 255) { colors[2] -= 255; }
                waterMarkText.ForeColor = Color.FromArgb(colors[0], colors[1], colors[2]);
                this.Hide();
            } catch (Exception ex)
            {
                Program.loadfinished = true;
                screenUpdater.Enabled = false;
                this.Hide();
                if (Program.f1.enableeggs) { me.Crash(ex.Message, ex.StackTrace, "OrangeScreen"); }
                else { MessageBox.Show("The blue screen cannot be displayed due to an error.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "E R R O R", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                this.Close();
            }
        }

        private void UpdateScreen(object sender, EventArgs e)
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
                    if (!ws.primary && Program.multidisplaymode == "blank")
                    {
                        continue;
                    }
                    var frm = Form.ActiveForm;
                    using (var bmp = new Bitmap(frm.Width, frm.Height))
                    {
                        frm.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                        Bitmap newImage = new Bitmap(ws.Width, ws.Height);
                        using (Graphics g = Graphics.FromImage(newImage))
                        {
                            if (Program.f1.GMode == "HighQualityBicubic") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; }
                            if (Program.f1.GMode == "HighQualityBilinear") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear; }
                            if (Program.f1.GMode == "Bilinear") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear; }
                            if (Program.f1.GMode == "Bicubic") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic; }
                            if (Program.f1.GMode == "NearestNeighbour") { g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor; }
                            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                            g.DrawImage(bmp, new Rectangle(0, 0, ws.Width, ws.Height));
                        }
                        ws.screenDisplay.Image = newImage;
                    }
                }
                catch
                {
                    naturalclose = true;
                    this.Close();
                }
                this.BringToFront();
                this.Activate();
            }
        }

        private void Unloading(object sender, FormClosingEventArgs e)
        {
            if (!naturalclose)
            {
                foreach (WindowScreen ws in wss)
                {
                    ws.Dispose();
                    ws.Close();
                }
                Cursor.Show();
            }
        }
    }
}
