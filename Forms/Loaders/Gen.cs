using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace UltimateBlueScreenSimulator
{
    public partial class Gen : MaterialForm
    {
        public Gen()
        {
            MaterialSkinManager materialSkinManager = Program.f1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
        }

        private void PreventUserClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void ProgressChecker(object sender, EventArgs e)
        {
            this.Text = Program.load_message;
            if (Program.loadfinished)
            {
                this.Dispose();
                this.Close();
            }
            if (Program.load_progress < 100)
            {
                genProgressBar.Style = ProgressBarStyle.Continuous;
                genProgressBar.Value = Program.load_progress;
                if (Program.load_progress < 10)
                {
                    this.Activate();
                    this.BringToFront();
                }
            }
            else if (Program.load_progress > 100)
            {
                genProgressBar.Value = genProgressBar.Maximum;
            }
            else
            {
                genProgressBar.Style = ProgressBarStyle.Marquee;
            }
            genProgressBar.Refresh();
        }

        private void Gen_Load(object sender, EventArgs e)
        {
            genLabel.BackColor = this.BackColor;
            genProgressBar.MarqueeAnimationSpeed = 30;
        }
    }
}
