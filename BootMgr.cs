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

        private void BootMgr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }

        private void BootMgr_Load(object sender, EventArgs e)
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
            label1.BackColor = fg; label1.ForeColor = bg; label1.Text = titles["Main"];
            label5.BackColor = fg; label5.ForeColor = bg; label5.Text = txt["Continue"];
            label6.BackColor = fg; label6.ForeColor = bg; label6.Text = txt["Exit"];

            label2.BackColor = bg; label2.ForeColor = fg; label2.Text = txt["Troubleshooting introduction"];
            label3.BackColor = bg; label3.ForeColor = fg; label3.Text = txt["Troubleshooting"];
            label4.BackColor = bg; label4.ForeColor = fg; label4.Text = txt["Troubleshooting without disc"];
            label7.BackColor = bg; label7.ForeColor = fg; label7.Text = txt["Status"];
            label8.BackColor = bg; label8.ForeColor = fg; label8.Text = txt["Info"];

            label9.BackColor = hbg; label9.ForeColor = hfg; label9.Text = me.GetString("code").ToLower();
            label10.BackColor = hbg; label10.ForeColor = hfg; label10.Text = txt["Error description"];

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
        }

        private void Timer1_Tick(object sender, EventArgs e)
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
            }
        }

        private void BootMgr_FormClosing(object sender, FormClosingEventArgs e)
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
