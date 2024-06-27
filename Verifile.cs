using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace UltimateBlueScreenSimulator
{
    /*
     *         /
     *        / 
     * +-----/  This program uses Verifile
     * \    /|  Signature verification technology
     * |\  / |
     * +-\/--+
     * 
     */
    internal class Verifile
    {
        private readonly ManagementObjectSearcher aa;
        private bool bad;

        // saving to Local instead of Roaming to avoid error messages about Verifile when transferring the data between computers
        // in a domain-joined system, each computer will need to be verified separately before running the program
        private readonly string filename = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Verifile\bssp3.key";

        public Verifile()
        {
            bad = false;
            aa = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        }


        public bool Bad {
            get { return bad; }
        }

        public bool Verify {
            get {
                return Verikey(new string[] {});
            }
        }

        /// <summary>
        /// Computer verification system
        /// </summary>
        /// <param name="args">key array</param>
        /// <returns>boolean</returns>
        // Verifile
        internal bool Verikey(string[] args)
        {
            RecursePaths(new FileInfo(filename).Directory);
            bool verifi = File.Exists(filename);
            if (verifi)
            {
                if (Vfile() != File.ReadAllText(filename))
                {
                    Program.gs.Log("Error", "Verifile attestation result: TAMPERED");
                    MessageBox.Show("A malicious program or script tried to potentially fool you into thinking that your system crashed. Due to signature verification failure, this program has to close.\n\n\nWhat should I do?\n\nIf you did not download the Bluescreen simulator plus yourself, please scan your computer for potential viruses or malware\nIf you DID download blue screen simulator plus, then the problem is most likely caused by a recent hardware change, which can invalidate the signature. To recreate the signature, run following commands in command prompt:\ncd \"" + AppDomain.CurrentDomain.BaseDirectory + "\"\nBlue screen simulator plus.exe /clr\n\nAfter that, you should be able to relaunch the program after clicking \"OK\".", "Ultimate blue screen simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bad = true;
                    Program.halt = true;
                    return false;
                }
                else
                {
                    Program.gs.Log("Info", "Verifile attestation result: VERIFIED");
                }
            }
            if (!verifi)
            {
                bool preversion = false;
                if (File.Exists(filename))
                {
                    Program.gs.Log("Warning", "Verifile attestation result: LEGACY");
                    preversion = true;
                    File.Delete(filename);
                }
                else
                {
                    Program.gs.Log("Warning", "Verifile attestation result: FOREIGN");
                }
                string usetype = "";
                if (preversion) { usetype = "version of the "; }
                if (MessageBox.Show("It looks like you are using this " + usetype + "program for the very first time. If you did not start this program, dont worry. This program is not malicious, but you should click \"No\" below and scan your computer for viruses/malicious programs.\n\n\nThis program can only be used for non-harmful purposes, such as:\n\n* Screenshotting blue screens from different operating systems (for use in a video, article, etc)\n* Non-harmful pranking purposes (ie pranking a friend, relative, etc)\n* Having fun tweaking different blue screens\n* Learning about different blue screens from different operating systems\n* Other testing or reviewing purposes\n\n\nBy clicking or selecting \"Yes\" you accept that you DO NOT use this program maliciously (ie as a part of a malicious program, a way of sacrificing productivity, etc). A verification signature will be created preventing this message from popping up in this computer. \n\nIf you click or select \"No\" then the program will close. The popup will reappear once you relaunch the program from this computer and user account.", "Welcome to Blue screen simulator plus", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    Program.halt = true;
                    Application.Exit();
                    return false;
                }
                else
                {
                    Program.gs.Log("Info", "Registering Verifile data");
                    WriteFile();
                    return true;
                }
            }
            return verifi;
        }

        /// <summary>
        /// Recursively creates parent directories if they don't exist
        /// </summary>
        /// <param name="di">Directory info of current path to check</param>
        private void RecursePaths(DirectoryInfo di)
        {
            Program.gs.Log("Info", $"Directory \"{di.FullName}\" doesn't exist. Creating it...");
            if (!Directory.Exists(di.Parent.FullName))
            {
                RecursePaths(di.Parent);
            }
            if (!Directory.Exists(di.FullName))
            {
                Directory.CreateDirectory(di.FullName);
            }
        }
        internal string Vfile()
        {
            string verificatable = Q();
            return verificatable;
        }

        internal void WriteFile()
        {
            string verificatable = Q();
            if (verificatable == "error")
            {
                return;
            }
            else
            {
                File.WriteAllText(filename, verificatable, Encoding.ASCII);
            }

        }
        string Q()
        {
            string gg = "CPI" + Ff();
            try
            {
                return (H(J(gg.Substring(1, gg.Length - 2) + gg.Substring(0, 1) + gg.Substring(gg.Length - 1, 1))).ToLower() + J(Uu()).ToLower() + J(B)).ToLower();
            }
            catch
            {
                MessageBox.Show("Unable to write signature information. To remove first use message, please run the application as administrator at least once.", "Verifile error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "error";
            }
        }

        string Uu()
        {
            using (ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS"))

            using (ManagementObjectCollection moc = o.Get())

            {

                StringBuilder t = new StringBuilder();
                foreach (ManagementObject mo in moc)

                {

                    string[] BIOSVersions = (string[])mo["BIOSVersion"];
                    foreach (string version in BIOSVersions)
                    {
                        t.AppendLine(string.Format("{0}", version));
                    }

                }
                return t.ToString().Split('\n')[0].ToString();
            }
        }

        public static string Ff()
        {
            string l = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                if (l == "")
                {
                    try
                    {
                        l = mo.Properties["processorID"].Value.ToString();
                    }
                    catch
                    {
                        l = "a";
                    }
                    break;
                }
            }
            return l;
        }
        public static string J(string z)
        {
            SHA1 cx = SHA1.Create();
            byte[] xx = Encoding.ASCII.GetBytes(z);
            byte[] hash = cx.ComputeHash(xx);

            StringBuilder t = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                t.Append(hash[i].ToString("X2"));
            }
            return t.ToString();
        }
        public static string H(string z)
        {
            MD5 cx = MD5.Create();
            byte[] xx = Encoding.ASCII.GetBytes(z);
            byte[] hash = cx.ComputeHash(xx);

            StringBuilder t = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                t.Append(hash[i].ToString("X2"));
            }
            return t.ToString();
        }
        public bool RC() { return Vfile() == File.ReadAllText(filename); }
        public string B {
            get {
                try
                {
                    foreach (ManagementObject queryObj in aa.Get())
                    {
                        return queryObj["Product"].ToString();
                    }
                    return "";
                }
                catch
                {
                    return "";
                }
            }
        }

    }
}
