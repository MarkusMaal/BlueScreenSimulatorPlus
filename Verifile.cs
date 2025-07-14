using System;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading;

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
        private readonly string legacykey = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\bssp2_firstlaunch.txt";
        private readonly string badkey = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\bssp_firstlaunch.txt";

        public Verifile()
        {
            // renew legacy key (when upgrading from a previous version)
            if (File.Exists(legacykey) && !File.Exists(filename))
            {
                if (!Directory.Exists(new FileInfo(filename).Directory.FullName))
                {
                    RecursePaths(new FileInfo(filename).Directory);
                }
                File.Copy(legacykey, filename);
                File.Delete(legacykey);
            }
            Program.gs.Log("Info", "Checking Verifile signature");
            if (File.Exists(badkey))
            {
                File.Delete(badkey);
            }
            bad = false;
            aa = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
        }

        public void HideUI()
        {
            if (Program.gs.LegacyUI)
            {
                Program.F2.BeginInvoke(new MethodInvoker(delegate {
                    Program.F2.Hide();
                }));
            }
            else
            {
                Program.F1.BeginInvoke(new MethodInvoker(delegate {
                    Program.F1.Hide();
                }));
            }
        }

        public void ShowBad()
        {
            if (!Program.clip.args.Contains("/clr"))
            {
                MessageBox.Show("A malicious program or script tried to potentially fool you into thinking that your system crashed. Due to signature verification failure, this program has to close.\n\n\nWhat should I do?\n\nIf you did not download the Bluescreen simulator plus yourself, please scan your computer for potential viruses or malware\nIf you DID download blue screen simulator plus, then the problem is most likely caused by a recent hardware change, which can invalidate the signature. To recreate the signature, run following commands in command prompt:\ncd \"" + AppDomain.CurrentDomain.BaseDirectory + "\"\n\"Blue screen simulator plus.exe\" /clr\n\nAfter that, you should be able to relaunch the program after clicking \"OK\".", "Ultimate blue screen simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                try
                {
                    if (Vfile() != File.ReadAllText(filename))
                    {
                        Program.gs.Log("Error", "Verifile attestation result: TAMPERED");
                        Program.clip.ExitSplash();
                        ShowBad();
                        bad = true;
                        Program.halt = true;
                        return false;
                    }
                    else
                    {
                        Program.gs.Log("Info", "Verifile attestation result: VERIFIED");
                    }
                } catch
                {
                    verifi = false;
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
                // Sleep 0.5 seconds to avoid race issues
                if (!Program.clip.CheckNoSplash())
                {
                    Thread.Sleep(500);
                }

                Program.clip.ExitSplash();
                if (MessageBox.Show("It looks like you are using this " + usetype + "program for the very first time. If you did not start this program, dont worry. This program is not malicious, but you should click \"No\" below and scan your computer for viruses/malicious programs.\n\n\nThis program can only be used for non-harmful purposes, such as:\n\n* Screenshotting crash screens from different operating systems (for use in a video, article, etc)\n* Non-harmful pranking purposes (ie pranking a friend, relative, etc)\n* Having fun tweaking different blue screens\n* Learning about different blue screens from different operating systems\n* Other testing or reviewing purposes\n\n\nBy clicking or selecting \"Yes\" you accept that you DO NOT use this program maliciously (ie as a part of a malicious program, a way of sacrificing productivity, etc). A verification signature will be created preventing this message from popping up in this computer. \n\nIf you click or select \"No\" then the program will close. The popup will reappear once you relaunch the program from this computer and user account.", "Welcome to Blue screen simulator plus", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    Program.halt = true;
                    Application.Exit();
                    return false;
                }
                else
                {
                    new Thread(() => {
                        Program.gs.Log("Info", "Registering Verifile data");
                        WriteFile();
                    }).Start();
                    if (!Program.clip.CheckNoSplash())
                    {
                        Program.hidden = true;
                        Program.splt = new Thread(Program.ShowLoading);
                        Program.splt.Start();
                        if (Program.clip.CheckPreviewSplash())
                        {
                            Program.halt = true;
                        }
                    }
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
                try
                {
                    File.WriteAllText(filename, verificatable, Encoding.ASCII);
                } catch
                {
                }
            }

        }
        private string Q()
        {
            string gg = "CPI" + Ff();
            try
            {
                return (H(J(gg.Substring(1, gg.Length - 2) + gg.Substring(0, 1) + gg.Substring(gg.Length - 1, 1))).ToLower() + J(Uu()).ToLower() + J(B)).ToLower();
            }
            catch
            {
                if (Program.wineKey != null)
                {
                    MessageBox.Show("Signature verification didn't work, most likely because you tried to run this app with Wine. You'll see this message every time you attempt to launch the program unless you run it under Windows or when WineHQ finally decide to fix their mess by releasing a patch...", "Verifile error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Unable to write signature information. To remove first use message, please run the application as administrator at least once.", "Verifile error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return "error";
            }
        }

        private string Uu()
        {
            using (ManagementObjectSearcher o = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS"))

            using (ManagementObjectCollection moc = o.Get())

            {

                StringBuilder t = new StringBuilder();
                foreach (string version in from ManagementObject mo in moc
                                        let BIOSVersions = (string[])mo["BIOSVersion"]
                                        from string version in BIOSVersions
                                        select version)
                {
                    t.AppendLine(string.Format("{0}", version));
                }

                return t.ToString().Split('\n')[0].ToString();
            }
        }

        public static string Ff()
        {
            string l = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in from ManagementObject mo in moc
                               where l == ""
                               select mo)
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
        public bool RC() {
            try
            {
                return Vfile() == File.ReadAllText(filename);
            } catch
            {
                return false;
            }
        }
        public string B {
            get {
                try
                {
                    foreach (ManagementObject queryObj in aa.Get().Cast<ManagementObject>())
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
