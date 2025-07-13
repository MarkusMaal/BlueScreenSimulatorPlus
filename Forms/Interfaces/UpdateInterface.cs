using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using MaterialSkin2Framework.Controls;
using MaterialSkin2Framework;

namespace UltimateBlueScreenSimulator
{
    public partial class UpdateInterface : MaterialForm
    {
        public bool finalize = false;
        private WebClient webClient;               // Our WebClient that will be doing the downloading for us
        private readonly Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        private string GoodHash = "6ABA5BC55589EE8D64E30B36596E5517";

        public UpdateInterface()
        {
            MaterialSkinManager materialSkinManager = Program.F1.materialSkinManager;
            materialSkinManager.AddFormToManage(this);
            InitializeComponent();
            Font = new Font(Font.Name, 8.25f * 96f / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont);
        }

        private void UpdateInterface_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (Launchstatus.Image == Properties.Resources.current)
            {
                e.Cancel = false;
            }
            if (finalize)
            {
                e.Cancel = false;
            }
        }

        public void DownloadFile(string urlAddress, string location)
        {
            try
            {
                using (webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                    // The variable that will be holding the url address (making sure it starts with http://)
                    Uri URL = urlAddress.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("http://" + urlAddress);

                    // Start the stopwatch which we will be using to calculate the download speed
                    sw.Start();

                    try
                    {
                        // Start downloading the file
                        webClient.DownloadFileAsync(URL, location);
                    }
                    catch (Exception ex) when (!Debugger.IsAttached)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (location.EndsWith(".txt"))
                {
                    File.SetAttributes(location, FileAttributes.Hidden);
                }
            } catch (Exception ex)
            {
                if (Program.gs.EnableEggs)
                {
                    Metaerror me = new Metaerror
                    {
                        ex = ex,
                        type = "VioletScreen"
                    };
                    switch (me.ShowDialog())
                    {
                        case DialogResult.Abort:
                            Application.Exit();
                            return;
                        case DialogResult.Retry:
                            DownloadFile(urlAddress, location);
                            return;
                        case DialogResult.Ignore:
                            break;
                    }
                } else
                {
                    MessageBox.Show("An error has occoured.\n\n" + ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            if (!this.Visible) {
                return;
            }
            dloadState.Text = string.Format("{0} KB downloaded (Transfer rate: {1} kb/s)", (e.BytesReceived / 1024d).ToString("0.00"), (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            updateProgress.Value = e.ProgressPercentage;

        }

        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            if (e.Cancelled == true)
            {
                SetStatus(DownloadStatus, "Failure");
            }
            else
            {
                if (this.Visible)
                { 
                    dloadState.Visible = false;
                    SetStatus(DownloadStatus, "Success");
                    if (Program.gs.HashVerify)
                    { 
                        SetStatus(HashStatus, "Processing");
                        hashWait.Enabled = true;
                    }
                    else
                    {
                        SetStatus(HashStatus, "Success");
                        SetStatus(Launchstatus, "Processing");
                        installWait.Enabled = true;
                    }
                }
            }
        }


        private void UpdateInterface_Load(object sender, EventArgs e)
        {
            if (Program.gs.HashVerify == false) { hashCheckLabel.Text = "Hashchecking (will be skipped)"; }
            GoodHash = File.ReadAllText("hash.txt").Trim();
            if (!finalize)
            { 
                SetStatus(DownloadStatus, "Processing");
                SetStatus(HashStatus, "Pending");
                SetStatus(Launchstatus, "Pending");
                SetStatus(TempStatus, "Pending");
                DownloadFile(Program.gs.UpdateServer + "/BSSP_latest.zim", "BSSP.exe");
            }
            if (finalize)
            {
                SetStatus(DownloadStatus, "Success");
                SetStatus(HashStatus, "Success");
                SetStatus(Launchstatus, "Success");
                SetStatus(TempStatus, "Processing");
                updateProgress.Visible = false;
                dloadState.Visible = false;
                cleanWait.Enabled = true;
            }
        }

        private void SetStatus(PictureBox pb, string status)
        {
            if (status == "Success")
            {
                pb.Image = Properties.Resources.success;
            }
            if (status == "Fail")
            {
                pb.Image = Properties.Resources.failure;
            }
            if (status == "Pending")
            {
                pb.Image = Properties.Resources.pending;
            }
            if (status == "Processing")
            {
                pb.Image = Properties.Resources.current;
            }
        }

        private void HashWait_Tick(object sender, EventArgs e)
        {
            updateProgress.Visible = false;
            hashWait.Enabled = false;
            MD5 d5 = MD5.Create();
            byte[] hash = d5.ComputeHash(File.ReadAllBytes("BSSP.exe"));
            string comparate = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            if (comparate.ToUpper() == GoodHash)
            {
                SetStatus(HashStatus, "Success");
                SetStatus(Launchstatus, "Processing");
                installWait.Enabled = true;
            } else
            {
                SetStatus(HashStatus, "Fail");
                if (MessageBox.Show("Hashcheck failed. Would you like to try again?", "Update unsuccessful", MessageBoxButtons.YesNo, MessageBoxIcon.Error)==DialogResult.Yes)
                {
                    SetStatus(DownloadStatus, "Processing");
                    SetStatus(HashStatus, "Pending");
                    SetStatus(Launchstatus, "Pending");
                    SetStatus(TempStatus, "Pending");
                    DownloadFile(Program.gs.UpdateServer + "/BSSP_latest.zim", "BSSP.exe");
                } else
                {
                    SetStatus(Launchstatus, "Processing");
                    Program.F1.Show();
                    Hide();
                    Close();
                }
            }
        }

        private void InstallWait_Tick(object sender, EventArgs e)
        {
            installWait.Enabled = false;
            File.Copy("BSSP.exe", "BSSP_new.exe");
            Process p = new Process();
            p.StartInfo.FileName = "BSSP.exe";
            p.StartInfo.Arguments = "/finalize_update";
            p.Start();
            Program.F1.Close();
            Close();
        }

        private void CleanWait_Tick(object sender, EventArgs e)
        {
            cleanWait.Enabled = false;
            if (!File.Exists("Blue screen simulator plus.exe"))
            {
                if (File.Exists("UltimateBlueScreenSimulator.exe"))
                {
                    File.Move("UltimateBlueScreenSimulator.exe", "Blue screen simulator plus.exe");
                } else if (File.Exists("Blue.screen.simulator.plus.exe"))
                {
                    File.Move("Blue.screen.simulator.plus.exe", "Blue screen simulator plus.exe");
                }
            }
            File.SetAttributes("Blue screen simulator plus.exe", FileAttributes.Hidden);
            File.Delete("Blue screen simulator plus.exe");
            File.Move("BSSP_new.exe", "Blue screen simulator plus.exe");
            System.IO.File.WriteAllText("finish.bat", Properties.Resources.final);
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = "finish.bat";
            p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
            p.Start();
            Close();
        }

        private void BlinkBlink_Tick(object sender, EventArgs e)
        {
            if (warningLabel.ForeColor == SystemColors.ControlText)
            {
                warningLabel.ForeColor = Color.Red;
            } else
            {
                warningLabel.ForeColor = SystemColors.ControlText;
            }
        }

        private void UpdateInterface_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}
