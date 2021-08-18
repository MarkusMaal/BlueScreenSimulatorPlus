using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace UltimateBlueScreenSimulator
{
    public partial class Splash : Form
    {
        internal string[] args = { " " };
        public Splash()
        {
            InitializeComponent();
        }


        private void Splash_Load(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            veriFileTimer.Enabled = false;
            Program.verificate = true;
            if (!File.Exists(Environment.GetEnvironmentVariable("USERPROFILE") + @"\bssp_firstlaunch.txt")) { Program.verificate = false; }
            if (Program.verificate == true)
            {
                if (Program.Verifile() != File.ReadAllText(Environment.GetEnvironmentVariable("USERPROFILE") + @"\bssp_firstlaunch.txt"))
                {
                    if (args.Contains("/c") && args.Contains("/hwm"))
                    {
                        MessageBox.Show("A malicious program or script tried to potentially fool you into thinking that your system crashed. Due to signature verification failure, this program has to close.\n\n\nWhat should I do?\n\nIf you did not download the Bluescreen simulator plus yourself, please scan your computer for potential viruses or malware\nIf you DID download blue screen simulator plus, then the problem is most likely caused by a recent hardware change, which can invalidate the signature. To recreate the signature, run following commands in command prompt:\ncd \"" + AppDomain.CurrentDomain.BaseDirectory + "\"\nUltimateBlueScreenSimulator.exe /clr\n\nAfter that, you should be able to relaunch the program after clicking \"OK\".", "Ultimate blue screen simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Program.verificate = false;
                }
            }
            if (!Program.verificate)
            {
                if (MessageBox.Show("It looks like you are using this program for the very first time. If you did not start this program, dont worry. This program is not malicious, but you should click \"No\" below and scan your computer for viruses/malicious programs.\n\n\nThis program can only be used for non-harmful purposes, such as:\n\n* Screenshotting blue screens from different operating systems (for use in a video, article, etc)\n* Non-harmful pranking purposes (ie pranking a friend, relative, etc)\n* Having fun tweaking different blue screens\n* Learning about different blue screens from different operating systems\n* Other testing or reviewing purposes\n\n\nBy clicking or selecting \"Yes\" you accept that you DO NOT use this program maliciously (ie as a part of a malicious program, a way of sacrificing productivity, etc). A verification signature will be created preventing this message from popping up in this computer. \n\nIf you click or select \"No\" then the program will close. The popup will reappear once you relaunch the program from this computer and user account.", "Welcome to Blue screen simulator plus", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    Program.WriteFile();
                    Program.verificate = true;
                }
            }
            this.Close();
        }


    }
}
