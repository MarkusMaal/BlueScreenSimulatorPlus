using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class BootMgr : Form
    {
        List<WindowScreen> wss = new List<WindowScreen>();
        private bool naturalclose = false;
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
                        }
                    }
                    wss.Add(ws);
                }
            }
            foreach (WindowScreen ws in wss)
            {
                ws.Show();
            }
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
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
                        ws.pictureBox1.Image = newImage;
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
