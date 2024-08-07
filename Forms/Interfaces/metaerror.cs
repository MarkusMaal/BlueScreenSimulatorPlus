﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator
{
    public partial class Metaerror : Form
    {
        internal Exception ex = null;
        private string message = "";
        private string stack_trace = "";
        internal string type = "GreenScreen";
        public Metaerror()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    break;
                case Keys.Enter:
                    this.DialogResult = DialogResult.Ignore;
                    this.Close();
                    break;
                case Keys.Space:
                    this.DialogResult = DialogResult.Retry;
                    this.Close();
                    break;
            }
            Program.gs.Log("Fatal", technicalinfoLabel.Text);
        }

        private void Metaerror_Load(object sender, EventArgs e)
        {
            if (ex != null)
            {
                message = ex.Message;
                stack_trace = ex.StackTrace;
                if (stack_trace == null)
                {
                    stack_trace = "There is no stack trace available for this error.";
                }
                technicalinfoLabel.Text = type + " Exception\n\n" + message + "\n\n" + stack_trace;
            }
            switch (type)
            {
                case "GreenScreen":
                    this.BackColor = Color.ForestGreen;
                    this.ForeColor = Color.White;
                    break;
                case "OrangeScreen":
                    this.BackColor = Color.DarkOrange;
                    this.ForeColor = Color.White;
                    break;
                case "VioletScreen":
                    this.BackColor = Color.BlueViolet;
                    this.ForeColor = Color.White;
                    retryButton.Visible = true;
                    abortButton.Visible = true;
                    break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void Metaerror_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F7))
            {
                Close();
            }
        }

        public static string GetOSFriendlyName()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }

        private void DumpTracelog(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Log files|*.log";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string preLine = "Blue Screen Simulator Plus version " + Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(0, 1) + "." + Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(1) + " [TRACE LOG]\n";
                    preLine += "Operating System: " + GetOSFriendlyName() + "\n";
                    File.WriteAllText(saveFileDialog1.FileName, preLine + Program.gs.GetLog(false), Encoding.Unicode);
                    MessageBox.Show("Trace log dumped successfully!", "Blue Screen Simulator Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch 
            {
                try
                {
                    string preLine = "Blue Screen Simulator Plus version " + Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(0, 1) + "." + Assembly.GetExecutingAssembly().GetName().Version.ToString().Replace(".", "").Substring(1) + " [TRACE LOG]\n";
                    preLine += "Operating System: " + GetOSFriendlyName() + "\n";
                    File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)  + "\\bssp_dump.log", preLine + Program.gs.GetLog(false), Encoding.Unicode);
                    MessageBox.Show("Trace log dumped successfully! Due to the fact this error was triggered from a secondary thread, we were unable to ask where to save the log file, so we saved it to the desktop as bssp_dump.log.", "Blue Screen Simulator Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Couldn't save trace log file. This may be due to the fact that the error was triggered from a secondary thread. Please click \"Continue\" and send the trace log through the main interface if possible. If it isn't possible to send a trace log, please send a screenshot of this metacrash screen making sure that the text below \"Technical info\" is visible.", "Error saving trace log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteConfigs(object sender, EventArgs e)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Blue Screen Simulator Plus\\";
            string file1 = "bluescreens.json";
            string file2 = "settings.json";
            if (File.Exists(path + file1)) { File.Delete(path + file1); }
            if (File.Exists(path + file2)) { File.Delete(path + file2); }
            MessageBox.Show("Files deleted successfully! The application will now halt.", "Blue Screen Simulator Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.GetCurrentProcess().Kill();
        }
    }
}
