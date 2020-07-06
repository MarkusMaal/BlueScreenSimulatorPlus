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
    public partial class Xvsbs : Form
    {
        public bool fullscreen = true;
        public bool w6mode = false;
        public string whatfail = "";
        private bool naturalclose = false;
        private int progress = 0;
        bool inr = false;
        bool ing = false;
        bool inb = false;

        string state = "0";
        WindowScreen ws = new WindowScreen();
        public Xvsbs()
        {
            InitializeComponent();
        }

        private void Xvsbs_Load(object sender, EventArgs e)
        {
            if (Program.f1.enableeggs) { 
                if (Program.f1.textBox2.Text.ToLower() == "tardis.sys")
                {
                    tardisFade.Enabled = true;
                }
                if (Program.f1.bsodxvs[0] == Program.f1.bsodxvs[1])
                {
                    this.BackColor = Color.FromArgb(255, 0, 0);
                    rainBowScreen.Enabled = true;
                }
            }
            if (whatfail != "") {
                label6.Text = "";
                label7.Text = "";
                label5.Text = "***  " + whatfail.ToUpper() + " - Address " + Program.f1.GenHex(8, "RRRRRRRR") + " base at " + Program.f1.GenHex(8, "RRRRRRRR") + ", DateStamp " + Program.f1.GenHex(8, "RRRRRRRR").ToLower();
                errorCode.Text = "The problem seems to be caused by the following file: " + whatfail.ToUpper() + "\n\n" + errorCode.Text;
            }
            label1.Text = Program.bh.textBox27.Text;
            supportInfo.Text = Program.bh.textBox30.Text + "\n\n" + Program.bh.textBox31.Text + "\n\n" + Program.bh.textBox32.Text;
            string[] esplit = technicalCode.Text.Replace("*** STOP: ", "").Replace(")", "").Replace(" (", "*").Split('*');
            technicalCode.Text = Program.bh.textBox33.Text.Replace("{0}", esplit[0]).Replace("{1}", esplit[1]);
            if (!w6mode) { 
                try
                { 
                    label5.Text = Program.bh.textBox34.Text.Split('\n')[0].Trim();
                    label6.Text = Program.bh.textBox34.Text.Split('\n')[1].Trim();
                    label7.Text = Program.bh.textBox35.Text.Split('\n')[0].Trim() + "\n" +Program.bh.textBox35.Text.Split('\n')[1].Trim();
                }
                catch
                {
                }
            }
            foreach (Control c in this.flowLayoutPanel1.Controls)
            {
                if (c is Label)
                {
                    c.Font = Program.bh.label49.Font;
                }
            }
            if (w6mode == true) 
            {
                errorCode.Text = errorCode.Text.Replace("CRITICAL_OBJECT_TERMINATION", "A process or thread crucial to system operation has unexpectedly exited or been terminated.");
                Font f1 = Program.bh.label50.Font;
                label1.Font = f1;
                supportInfo.Font = f1;
                label5.Font = f1;
                label6.Font = f1;
                label7.Font = f1;
                errorCode.Font = f1;
                technicalCode.Font = f1;
                if (whatfail == "") { label5.Text = "Collecting data for crash dump ..."; label6.Text = "Initializing disk for crash dump ..."; } else { label6.Visible = false; }
                label7.Text = "Beginning dump of physical memory.\nDumping physical memory to disk:   0";
                if (whatfail != "") { label7.Margin = new Padding(3, 15, 3, 0); }
                errorCode.Margin = new Padding(3, 15, 3, 0);
                supportInfo.Margin = new Padding(3, 15, 3, 0);
                technicalCode.Margin = new Padding(3, 15, 3, 0);
                supportInfo.Text = supportInfo.Text.Replace("\n\n\n", "\n\n");
                label5.Margin = new Padding(3, 15, 3, 0);
            }
            if (!fullscreen) { this.FormBorderStyle = FormBorderStyle.FixedSingle; this.ShowInTaskbar = true; this.ShowIcon = true; }
            if (Program.f1.supporttext == "")
            {
                supportInfo.Visible = false;
                label1.Visible = false;
            }
            if (!w6mode) { errorCode.Text = errorCode.Text.Replace("IRQL", "DRIVER_IRQL"); }
            if (!w6mode) { errorCode.Text = errorCode.Text.Replace("MANUALLY_INITIATED_CRASH", "The end-user manually generated the crash dump."); }
            if (!w6mode) { errorCode.Text = errorCode.Text.Replace("VIDEO_TDR_", "VIDEO_TDR_ERROR"); }
            if (!w6mode) { technicalCode.Text = technicalCode.Text.Replace("STOP: ERROR", "STOP: 0x00000116"); }
            if (fullscreen) { 
                this.TopMost = false;
                ws.Show();
                this.Hide();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (w6mode)
            {
                string spaces = "";
                for (int i = 0; i < (4 - (progress + 1).ToString().Length); i++)
                {
                    spaces += " ";
                }
                if (progress == 100)
                {
                    naturalclose = true;
                    this.Close();
                }
                label7.Text = "Beginning dump of physical memory.\nDumping physical memory to disk:" + spaces + (progress + 1).ToString();
                if ((progress + 1) == 100)
                {
                    label7.Text += "\nPhysical memory dump complite.\nContact your system admin or technical support group for further assistance.";
                }
                progress++;
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
            if (tardisFade.Enabled == true) { return; }
            if (rainBowScreen.Enabled == true) { return; }
            if (w6mode == false)
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
                if (fullscreen) { 
                    naturalclose = true;
                    this.Close();
                }
            }
        }

        private void Xvsbs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!naturalclose)
            {
                ws.Close();
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
            int target_r = Program.f1.bsodxvs[0].R;
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
            int target_g = Program.f1.bsodxvs[0].G;
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
            int target_b = Program.f1.bsodxvs[0].B;
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
}
