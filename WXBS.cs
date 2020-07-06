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
    public partial class WXBS : Form
    {
        public bool server = false;
        public bool qr = true;
        public bool green = false;
        public bool close = true;
        public string code = "";
        public string whatfail = "";
        public bool w8 = false;
        private bool w8close = false;
        private int progress = 0;
        public WXBS()
        {
            InitializeComponent();
        }

        private void FlowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WXBS_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Program.f1.showcursor)
            {
                Cursor.Show();
            }
        }

        private void WXBS_Load(object sender, EventArgs e)
        {
            label1.Font = Program.bh.emotiFont.Font;
            label2.Font = Program.bh.modernTextFont.Font;
            label3.Font = Program.bh.modernTextFont.Font;
            label4.Font = Program.bh.modernDetailFont.Font;
            label5.Font = Program.bh.modernDetailFont.Font;
            label2.Text = Program.bh.textBox41.Text;
            pictureBox1.Size = new Size(Program.bh.trackBar1.Value, Program.bh.trackBar1.Value);
            if (Program.bh.transparentQR.Checked == true) { pictureBox1.Image = Properties.Resources.bsodqr_transparent; }
            if (Program.bh.defactoQR.Checked == true) { pictureBox1.Image = Properties.Resources.bsodqr; }
            try { if (Program.bh.customQR.Checked == true) { pictureBox1.Image = Image.FromFile(Program.bh.qrFile.Text); } } catch { pictureBox1.Image = Properties.Resources.bsodqr; }
            if (w8 == true)
            {
                label2.Text = Program.bh.textBox37.Text.Replace("{0}", "0");
                if (close == true) { close = false; w8close = true; }

            } else
            {
                label3.Text = Program.bh.textBox44.Text.Replace("{0}", "0");
                label4.Text = Program.bh.textBox42.Text;
            }
            if (!w8close)
            { 
                if (close == false)
                {
                    label2.Text = Program.bh.textBox40.Text;
                }
                if (green)
                {
                    this.BackColor = Color.FromArgb(47, 121, 42);
                    label2.Text = label2.Text.Replace("PC", "Windows Insider Build");
                }
                if (server)
                {
                    label1.Visible = false;
                    label2.Margin = new Padding(label2.Margin.Left, 80, 0, 0);
                }
            }
            try { waterMarkText.ForeColor = Color.FromArgb(this.BackColor.R + 60, this.BackColor.G + 60, this.BackColor.B + 60); } catch { }
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                if (!Program.f1.showcursor)
                { 
                    Cursor.Hide();
                }
            }
            label1.Padding = new Padding(0, Convert.ToInt32(this.Height * 0.12), 0, 0);
            panel2.Width = Convert.ToInt32(this.Width * 0.09) - 10;
            label2.Padding = new Padding(panel2.Width - 3, 0, 0, 0);
            label3.Padding = label2.Padding;
            label1.Margin = new Padding(Convert.ToInt32(panel2.Width * 0.8), 0, 0, 0);
            flowLayoutPanel2.Width = this.Width - 10;
            if (w8 == false)
            {
                if (whatfail == "")
                { 
                    label5.Text = Program.bh.textBox45.Text.Replace("{0}", code);
                } else
                {
                    label5.Location = new Point(3, 36);
                    label5.Text = Program.bh.textBox45.Text.Replace("{0}", code + "\n\n" + Program.bh.textBox43.Text.Replace("{0}", whatfail.ToLower()));
                }
            }
            if (w8 == true)
            {
                label3.Visible = false;
                if (whatfail == "")
                {
                    label5.Text = Program.bh.textBox39.Text.Replace("{0}", code);
                } else
                {
                    label5.Text = Program.bh.textBox39.Text.Replace("{0}", code + " (" + whatfail.ToLower() + ")");
                }
            }
            if (qr == true)
            {
                pictureBox1.Visible = true;
                label4.Visible = true;
                label5.Location = new Point(3, 56);
                Point locationOnForm = pictureBox1.FindForm().PointToClient(pictureBox1.Parent.PointToScreen(pictureBox1.Location));
                panel1.Location = new Point(panel2.Width + pictureBox1.Width + 20, locationOnForm.Y);
            } else
            {
                pictureBox1.Visible = false;
                label4.Visible = false;
                label5.Location = new Point(3, 0);
                Point locationOnForm = flowLayoutPanel2.FindForm().PointToClient(flowLayoutPanel2.Parent.PointToScreen(flowLayoutPanel2.Location));
                panel1.Location = new Point(panel2.Width, locationOnForm.Y);
            }
            if (qr == false)
            { 
                if (close == false)
                {
                    if (w8)
                    {
                        Point locationOnForm = label2.FindForm().PointToClient(label2.Parent.PointToScreen(label2.Location));
                        panel1.Location = new Point(panel1.Location.X, locationOnForm.Y + 150);
                    }
                }
            }
            if (w8)
            {
                if (w8close == false)
                {
                    label2.Text = Program.bh.textBox38.Text;
                    timer1.Enabled = false;
                    label3.Visible = false;
                    Point locationOnForm = label2.FindForm().PointToClient(label2.Parent.PointToScreen(label2.Location));
                    panel1.Location = new Point(panel2.Width, locationOnForm.Y + 120);
                }
            }
            if (w8close == true)
            {
                timer1.Enabled = true;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!w8close) { 
                if (progress >= 100)
                {
                    timer1.Enabled = false;
                    if (close == true) { this.Close(); }
                    label3.Text = Program.bh.textBox44.Text.Replace("{0}", "100");
                }
                progress += 1;
                if (progress > 60) { timer1.Interval = 300; }
                label3.Text = Program.bh.textBox44.Text.Replace("{0}", progress.ToString());
            } else
            {
                if (progress >= 100)
                {
                    label2.Text = label2.Text.Replace(progress.ToString() + "%", "100%");
                    timer1.Enabled = false;
                    if (w8close == true) { this.Close(); }
                }
                string oldprogress = progress.ToString();
                progress += 1;
                if (progress > 60) { timer1.Interval = 300; }
                label2.Text = label2.Text.Replace(oldprogress + "%", progress.ToString() + "%");
            }
        }

        private void WXBS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Program.f1.closecuzhidden == true)
            {
                Program.f1.Close();
            }
            if (Program.f1.showmsg == true)
            {
                MessageBox.Show(Program.f1.MsgBoxMessage, Program.f1.MsgBoxTitle, Program.f1.MsgBoxType, Program.f1.MsgBoxIcon);
                Program.f1.showmsg = false;
            }
            Program.f1.Show();
        }

        private void WXBS_Resize(object sender, EventArgs e)
        {
            label1.Padding = new Padding(0, Convert.ToInt32(this.Height * 0.12), 0, 0);
            panel2.Width = Convert.ToInt32(this.Width * 0.09) - 10;
            label2.Padding = new Padding(panel2.Width - 3, 0, 0, 0);
            label3.Padding = label2.Padding;
            label1.Margin = new Padding(Convert.ToInt32(panel2.Width * 0.77), 0, 0, 0);
            flowLayoutPanel2.Width = this.Width - 10;

            if (qr == true)
            {
                label5.Location = new Point(3, 56);
                Point locationOnForm = pictureBox1.FindForm().PointToClient(pictureBox1.Parent.PointToScreen(pictureBox1.Location));
                panel1.Location = new Point(panel2.Width + pictureBox1.Width + 20, locationOnForm.Y);
            }
            else
            {
                label5.Location = new Point(3, 0);
                Point locationOnForm = flowLayoutPanel2.FindForm().PointToClient(flowLayoutPanel2.Parent.PointToScreen(flowLayoutPanel2.Location));
                panel1.Location = new Point(panel2.Width, locationOnForm.Y);
            }
            if (qr == false)
            {
                if (close == false)
                {
                    if (w8)
                    {
                        Point locationOnForm = label2.FindForm().PointToClient(label2.Parent.PointToScreen(label2.Location));
                        panel1.Location = new Point(panel1.Location.X, locationOnForm.Y + 150);
                    }
                }
            }
            if (w8)
            {
                if (w8close == false)
                {
                    Point locationOnForm = label2.FindForm().PointToClient(label2.Parent.PointToScreen(label2.Location));
                    panel1.Location = new Point(panel2.Width, locationOnForm.Y + 120);
                }
            }
        }
    }
}
