using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class JupiterBSOD : Form
    {
        internal BlueScreen me;
        private IDictionary<string, string> texts;
        int time = 0;
        public JupiterBSOD()
        {
            InitializeComponent();
        }

        private void JupiterBSOD_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F7) || (e.KeyCode == Keys.Escape))
            {
                Close();
            }
        }

        private void JupiterBSOD_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = me.GetString("friendlyname");
            this.Width = 1024;
            this.Height = 768;
            this.StartPosition = FormStartPosition.CenterScreen;
            Watermark.Visible = me.GetBool("watermark");
            texts = me.GetTexts();
            time = me.GetInt("timer");
            HeaderLabel.Text = texts["Your computer needs to restart"];
            DetailsLabel.Text = string.Format(texts["Information text with dump"] + "\n" + texts["Error code"], me.GetString("code").Split(' ')[1].Replace(")", "").Replace("(", ""));

            ProgressLabel.Text = string.Format(texts["Progress"], time);

            Font basefont = me.GetFont();

            HeaderLabel.Font = basefont;
            DetailsLabel.Font = new Font(basefont.FontFamily, basefont.Size - 16f, basefont.Style);
            ProgressLabel.Font = new Font(basefont.FontFamily, basefont.Size - 10.5f, basefont.Style);

            int mx = me.GetInt("margin-x");
            int my = me.GetInt("margin-y");
            
            HeaderLabel.Location = new Point(mx, my);
            DetailsLabel.Location = new Point(mx, my + 52);
            ProgressLabel.Location = new Point(mx, my + 208);
            if (me.GetBool("countdown"))
            {
                timecounter.Start();
            }
            else
            {
                ProgressLabel.Visible = false;
            }
            if (!me.GetBool("windowed"))
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            Program.loadfinished = true;
        }

        private void Timecounter_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time--;
                ProgressLabel.Text = string.Format(texts["Progress"], time);
            } else
            {
                timecounter.Enabled = false;
                if (me.GetBool("autoclose"))
                {
                    Close();
                }
            }
        }
    }
}
