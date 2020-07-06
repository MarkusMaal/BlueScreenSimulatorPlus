using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    public partial class w2kbs : Form
    {
        public bool fullscreen = true;
        private bool naturalclose = false;
        public string whatfail = "";
        WindowScreen ws = new WindowScreen();
        public w2kbs()
        {
            InitializeComponent();
        }

        private void W2kbs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!naturalclose)
            {
                ws.Close();
            }
        }

        private void W2kbs_Load(object sender, EventArgs e)
        {
            string[] esplit = errorCode.Text.Split('\n')[0].Replace("*** STOP: ", "").Replace(")", "").Replace(" (", "*").Split('*');

            errorCode.Text = Program.bh.textBox25.Text.Replace("{0}", esplit[0]).Replace("{1}", esplit[1]) + "\n" + errorCode.Text.Split('\n')[1];
            label2.Text = Program.bh.textBox26.Text;
            supportInfo.Text = Program.bh.textBox28.Text;
            downMessage.Text = Program.bh.textBox29.Text;
            errorCode.Font = Program.bh.label39.Font;
            label2.Font = Program.bh.label39.Font;
            supportInfo.Font = Program.bh.label39.Font;
            downMessage.Font = Program.bh.label39.Font;
            if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; this.ShowInTaskbar = true; this.ShowIcon = true; }
            if (Program.f1.supporttext == "")
            {
                supportInfo.Visible = false;
                errorCode.Visible = false;
            }
            if (whatfail != "")
            {
                errorCode.Text += "\n\n*** Address " + Program.f1.GenHex(8, "RRRRRRRR") + " base at " + Program.f1.GenHex(8, "RRRRRRRR")  + ", DateStamp " + Program.f1.GenHex(8, "RRRRRRRR").ToLower() + " - " + whatfail.ToLower();
            }
            errorCode.Text = errorCode.Text.Replace("IRQL", "DRIVER_IRQL");

            if (fullscreen)
            {
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
                this.TopMost = false;
                ws.Show();
                this.Hide();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (fullscreen)
            {
                if (ws.Visible == false)
                {
                    naturalclose = true;
                    this.Close();
                }
                try
                {
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

        private void W2kbs_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!fullscreen)
            {
                if (Program.f1.closecuzhidden == true)
                {
                    Program.f1.Close();
                }
            }
        }
    }
}
