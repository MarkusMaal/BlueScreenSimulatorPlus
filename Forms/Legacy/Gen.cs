﻿using System;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator.Forms.Legacy
{
    public partial class Gen : Form
    {
        public Gen()
        {
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
            Text = Program.load_message;
            if (Program.loadfinished)
            {
                Dispose();
                Close();
            }
            if (Program.load_progress < 100)
            {
                genProgressBar.Style = ProgressBarStyle.Continuous;
                genProgressBar.Value = Program.load_progress;
                if (Program.load_progress < 10)
                {
                    Activate();
                    BringToFront();
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
        }

        private void Gen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}
