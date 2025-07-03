using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimulatorDatabase;

namespace UltimateBlueScreenSimulator.Forms.Interfaces
{
    public partial class TestSuite : Form
    {
        public TestSuite()
        {
            InitializeComponent();
        }

        private void TestSuite_Load(object sender, EventArgs e)
        {
            StartTest(1);
        }

        private void ClearActions()
        {
            this.BeginInvoke(new MethodInvoker(delegate {
                for (int i = 1; i <= 10; i++)
                {
                    tableLayoutPanel2.Controls[$"actionLabel{i}"].Text = "";
                    ((PictureBox)tableLayoutPanel2.Controls[$"actionPic{i}"]).Image = null;
                }
            }));
        }

        private void SetActions(string[] actionLabels)
        {
            this.BeginInvoke(new MethodInvoker(delegate {
                for (int i = 1; i <= 10; i++)
                {
                    if (i > actionLabels.Length)
                    {
                        break;
                    }
                    tableLayoutPanel2.Controls[$"actionLabel{i}"].Text = actionLabels[i - 1];
                    ((PictureBox)tableLayoutPanel2.Controls[$"actionPic{i}"]).Image = Properties.Resources.pending;
                }
            }));
        }

        private void HighlightSubtest(int i, bool success)
        {
            this.BeginInvoke(new MethodInvoker(delegate {
                if (i > 1)
                {
                    ((PictureBox)tableLayoutPanel2.Controls[$"actionPic{i - 1}"]).Image = success ? Properties.Resources.success : Properties.Resources.failure;
                }
                if (((PictureBox)tableLayoutPanel2.Controls[$"actionPic{i}"]).Image != null)
                {
                    ((PictureBox)tableLayoutPanel2.Controls[$"actionPic{i}"]).Image = Properties.Resources.current;
                }
            }));
        }

        private void LogError(string testType, string message)
        {
            this.BeginInvoke(new MethodInvoker(delegate {
                badTestLog.Text += $"[{DateTime.Now}] {testType} - {message}";
            }));
        }

        private void SettingsTest()
        {
            Thread.Sleep(1000);
            throw new NotImplementedException();
        }

        private void SaveLoadTest()
        {
            TemplateRegistry backup = Program.templates;
            int numindicies = 4;
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            HighlightSubtest(1, true);
            Thread.Sleep(1000);
            HighlightSubtest(2, true);
            Program.templates.AddTemplate("Windows 10", "TestSuite testing configuration");
            bool ok = (Program.templates.GetLast().GetString("friendlyname") == "TestSuite testing configuration") && (Program.templates.GetLast().GetString("os") == "Windows 10");
            if (!ok) { LogError("Save/load configurations", "Failed to add template!"); }
            HighlightSubtest(3, ok);
            ok = Program.templates.GetLast().GetString("emoticon") == ":(";
            Program.templates.GetLast().SetString("emoticon", ";)");
            ok = ok && Program.templates.GetLast().GetString("emoticon") == ";)";
            if (!ok) { LogError("Save/load configurations", "Failed to change emoticon!"); }
            HighlightSubtest(4, ok);
            ok = true;
            for (int i = 0; i < numindicies; i++)
            {
                Program.templates.SaveData(documents + $"\\test{i + 1}.json", i, true);
                ok = ok && File.Exists(documents + $"\\test{i + 1}.json");
            }
            if (!ok) { LogError("Save/load configurations", "Save data missing!"); }
            HighlightSubtest(5, ok);
            Program.templates.Clear();
            HighlightSubtest(6, Program.templates.Count == 0);
            ok = true;
            for (int i = 1; i <= numindicies; i++)
            {
                TemplateRegistry tempreg = Program.templates;
                this.BeginInvoke(new MethodInvoker(delegate {
                    if (i > 4) return;
                    tempreg.LoadConfig(documents + $"\\test{i}.json");
                    bool has_cust_emoticon = false;
                    bool has_bad_emoticon = false;
                    foreach (BlueScreen bs in tempreg.GetAll())
                    {
                        if (bs.GetString("friendlyname") == "TestSuite testing configuration")
                        {
                            string emoticon = bs.GetString("emoticon");
                            if (emoticon == ";)") { has_cust_emoticon = true; break; }
                            else
                            {
                                has_bad_emoticon = true;
                                LogError("Save/load configurations", $"Wrong emoticon for file test{i}.json! Expected ;)  Actual {emoticon}");
                            }
                        }
                    }
                    if (!has_cust_emoticon && !has_bad_emoticon)
                    {
                        LogError("Save/load configurations", $"Couldn't find TestSuite configuration from test{i}.json!");
                    }
                    ok = ok && has_cust_emoticon;
                }));
            }
            HighlightSubtest(7, ok);
            Program.templates = backup;
            NextTest(2);
        }

        private void NextTest(int id)
        {
            this.BeginInvoke(new MethodInvoker(delegate {
                string LastTestName = tableLayoutPanel1.Controls["label" + (id - 1)].Text;
                bool hasFailed = false;
                foreach (Control c in tableLayoutPanel2.Controls)
                {
                    if (c is PictureBox pb)
                    {
                        int idx = int.Parse(c.Name.Replace("actionPic", ""));
                        if (pb.Image == Properties.Resources.failure)
                        {
                            string FailedSubTestName = tableLayoutPanel2.Controls[$"actionLabel{idx}"].Text;
                            badTestLog.Text += $"[FAILED] {LastTestName} - {FailedSubTestName}";
                            hasFailed = true;
                        }
                    }
                }
                ((PictureBox)tableLayoutPanel1.Controls["testProgress" + (id - 1)]).Image = hasFailed ? Properties.Resources.failure : Properties.Resources.success;
            }));
            StartTest(id);
        }

        private void StartTest(int id)
        {
            ClearActions();
            ((PictureBox)tableLayoutPanel1.Controls[$"testProgress{id}"]).Image = Properties.Resources.current;
            switch (id)
            {
                case 1:
                    SetActions(new string[] { "Wait 1000ms", "Create a new configuration with Windows 10 template", "Change emoticon", "Save configuration", "Clear configurations", "Load and check if changed emoticon is present" });
                    new Thread(SaveLoadTest).Start();
                    break;
                case 2:
                    SetActions(new string[] { "Windows 1.x/2.x", "Windows 3.1", "Windows 9x", "Windows NT/2000", "Windows XP/Vista/7", "Windows CE", "BOOTMGR", "Windows 8 Beta", "Windows 8.x-11", "Windows 11 Beta" });
                    new Thread(SettingsTest).Start();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
            }
        }

        private void blink_Tick(object sender, EventArgs e)
        {
            noticeLabel.ForeColor = ((noticeLabel.ForeColor == SystemColors.ControlText) ? Color.Red : SystemColors.ControlText);
        }
    }
}
