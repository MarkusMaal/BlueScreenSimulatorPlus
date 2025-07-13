using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
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
            BeginInvoke(new MethodInvoker(delegate {
                for (int i = 1; i <= 10; i++)
                {
                    tableLayoutPanel2.Controls[$"actionLabel{i}"].Text = "";
                    ((PictureBox)tableLayoutPanel2.Controls[$"actionPic{i}"]).Image = null;
                }
            }));
        }

        private void SetActions(string[] actionLabels)
        {
            BeginInvoke(new MethodInvoker(delegate {
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
            BeginInvoke(new MethodInvoker(delegate {
                if (i > 1)
                {
                    ((PictureBox)tableLayoutPanel2.Controls[$"actionPic{i - 1}"]).Image = success ? Properties.Resources.success : Properties.Resources.failure;
                }
                if (i < 11 && ((PictureBox)tableLayoutPanel2.Controls[$"actionPic{i}"]).Image != null)
                {
                    ((PictureBox)tableLayoutPanel2.Controls[$"actionPic{i}"]).Image = Properties.Resources.current;
                }
            }));
            Thread.Sleep(100);
        }

        private void LogError(string testType, string message)
        {
            BeginInvoke(new MethodInvoker(delegate {
                badTestLog.Text += $"[{DateTime.Now}] {testType} - {message}\r\n";
            }));
        }

        private bool CheckBools(Dictionary<string, bool> expectedVals, BlueScreen bs, string Name)
        {
            bool ok = true;
            foreach (KeyValuePair<string, bool> kvp in expectedVals)
            {
                bool actual = bs.GetBool(kvp.Key);
                bool match = (actual == kvp.Value);
                ok = ok && match;
                if (!match)
                {
                    LogError("Simulator settings", $"{Name} invalid boolean value for {kvp.Key}. Expected {kvp.Value}, got {actual}!");
                }
            }
            return ok;
        }

        private bool CheckStrings(Dictionary<string, string> expectedVals, BlueScreen bs, string Name)
        {
            bool ok = true;
            foreach (KeyValuePair<string, string> kvp in expectedVals)
            {
                string actual = bs.GetString(kvp.Key);
                bool match = (actual == kvp.Value);
                ok = ok && match;
                if (!match)
                {
                    LogError("Simulator settings", $"{Name} invalid string value for {kvp.Key}. Expected \"{kvp.Value}\", got \"{actual}\"!");
                }
            }
            return ok;
        }

        private void SettingsTest()
        {
            Thread.Sleep(100);
            TemplateRegistry tempreg = Program.templates;
            tempreg.Clear();
            HighlightSubtest(1, true);
            tempreg.AddTemplate("Windows 1.x/2.x");
            Dictionary<string, bool> ExpectedBools = new Dictionary<string, bool>()
            {
                {"playsound", true },
                {"font_support", true },
                {"blinkblink", true },
                {"halfres", true },
            };
            Dictionary<string, string> ExpectedStrings = new Dictionary<string, string>()
            {
                {"friendlyname", "Windows 1.x/2.x (Text mode, Standard)" },
                {"qr_file", "local:1" }
            };
            HighlightSubtest(2, CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 1.x/2.x") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 1.x/2.x"));
            tempreg.AddTemplate("Windows 3.1x");
            ExpectedBools.Clear();
            ExpectedStrings.Clear();
            ExpectedBools.Add("font_support", false);
            ExpectedBools.Add("blinkblink", true);
            ExpectedStrings.Add("friendlyname", "Windows 3.1 (Text mode, Standard)");
            ExpectedStrings.Add("screen_mode", "No unresponsive programs");
            HighlightSubtest(3, CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 3.1x") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 3.1x"));
            tempreg.AddTemplate("Windows 9x/Me");
            ExpectedBools.Clear();
            ExpectedStrings.Clear();
            ExpectedBools.Add("font_support", false);
            ExpectedBools.Add("blinkblink", true);
            ExpectedStrings.Add("friendlyname", "Windows 9x/Millennium Edition (Text mode, Standard)");
            ExpectedStrings.Add("screen_mode", "System error");
            HighlightSubtest(4, CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 9x/Me") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 9x/Me"));
            bool ok = true;
            tempreg.AddTemplate("Windows NT 3.x/4.0");
            ExpectedBools.Clear();
            ExpectedStrings.Clear();
            ExpectedBools.Add("font_support", false);
            ExpectedBools.Add("blinkblink", true);
            ExpectedBools.Add("troubleshoot", true);
            ExpectedBools.Add("stack_trace", true);
            ExpectedStrings.Add("friendlyname", "Windows NT 4.0/3.5x (Text mode, Standard)");
            ExpectedStrings.Add("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
            ok = ok && CheckBools(ExpectedBools, tempreg.GetLast(), "Windows NT 3.x/4.0") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows NT 3.x/4.0");
            tempreg.AddTemplate("Windows 2000");
            ExpectedBools.Clear();
            ExpectedStrings.Clear();
            ExpectedBools.Add("font_support", false);
            ExpectedBools.Add("show_description", true);
            ExpectedStrings.Add("friendlyname", "Windows 2000 Professional/Server Family (640x480, Standard)");
            ExpectedStrings.Add("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
            ok = ok && CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 2000") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 2000");
            HighlightSubtest(5, ok);
            ok = true;
            tempreg.AddTemplate("Windows XP");
            ExpectedBools.Clear();
            ExpectedStrings.Clear();
            ExpectedBools.Add("font_support", true);
            ExpectedBools.Add("show_description", true);
            ExpectedBools.Add("autoclose", true);
            ExpectedStrings.Add("friendlyname", "Windows XP (640x480, Standard)");
            ExpectedStrings.Add("code", "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)");
            ok = ok && CheckBools(ExpectedBools, tempreg.GetLast(), "Windows XP") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows XP");
            tempreg.AddTemplate("Windows Vista");
            ExpectedStrings["friendlyname"] = "Windows Vista (640x480, Standard)";
            ok = ok && CheckBools(ExpectedBools, tempreg.GetLast(), "Windows Vista") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows Vista");
            tempreg.AddTemplate("Windows 7");
            ExpectedStrings["friendlyname"] = "Windows 7 (640x480, ClearType)";
            ok = ok && CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 7") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 7");
            HighlightSubtest(6, ok);
            tempreg.AddTemplate("Windows CE");
            ExpectedStrings["friendlyname"] = "Windows CE 5.0 and later (750x400, Standard)";
            ExpectedBools.Remove("autoclose");
            ExpectedBools.Remove("show_description");
            HighlightSubtest(7, CheckBools(ExpectedBools, tempreg.GetLast(), "Windows CE") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows CE"));
            tempreg.AddTemplate("BOOTMGR");
            ExpectedStrings.Clear();
            ExpectedBools.Clear();
            ExpectedStrings["code"] = "0x0000000e";
            ExpectedStrings["friendlyname"] = "Windows Boot Manager (1024x768, Standard)";
            HighlightSubtest(8, CheckStrings(ExpectedStrings, tempreg.GetLast(), "BOOTMGR"));
            tempreg.AddTemplate("Windows 8 Beta");
            ExpectedStrings.Clear();
            ExpectedBools.Clear();
            ExpectedStrings["code"] = "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)";
            ExpectedStrings["friendlyname"] = "Windows 8 Beta (Native, ClearType)";
            ExpectedBools["autoclose"] = true;
            ExpectedBools["countdown"] = true;
            ExpectedBools["font_support"] = true;
            HighlightSubtest(9, CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 8 Beta") && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 8 Beta"));
            tempreg.AddTemplate("Windows 8/8.1");
            ok = true;
            ExpectedStrings.Clear();
            ExpectedBools.Clear();
            ExpectedStrings["code"] = "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)";
            ExpectedStrings["friendlyname"] = "Windows 8/8.1 (Native, ClearType)";
            ExpectedStrings["emoticon"] = ":(";
            ExpectedBools["autoclose"] = true;
            ExpectedBools["show_description"] = true;
            ExpectedBools["font_support"] = true;
            ok = ok && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 8/8.1") && CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 8/8.1");
            tempreg.AddTemplate("Windows 10");
            ExpectedStrings["friendlyname"] = "Windows 10 (Native, ClearType)";
            ExpectedStrings["qr_file"] = "local:0";
            ExpectedBools["crashdump"] = true;
            ExpectedBools["qr"] = true;
            ExpectedBools["device"] = true;
            ExpectedBools["winxplus"] = true;
            ok = ok && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 10") && CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 10");
            tempreg.AddTemplate("Windows 11");
            ExpectedStrings["friendlyname"] = "Windows 11 (Native, ClearType)";
            ExpectedBools["blackscreen"] = false;
            ok = ok && CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 10") && CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 10");
            HighlightSubtest(10, ok);
            tempreg.AddTemplate("Windows 11 Beta");
            ExpectedBools.Clear();
            ExpectedStrings.Clear();
            ExpectedStrings["friendlyname"] = "Windows 11 Beta (Native, ClearType)";
            ExpectedStrings["code"] = "IRQL_NOT_LESS_OR_EQUAL (0x0000000A)";
            ExpectedBools["autoclose"] = true;
            ExpectedBools["crashdump"] = true;
            ExpectedBools["show_description"] = true;
            ExpectedBools["font_support"] = true;
            ok = CheckStrings(ExpectedStrings, tempreg.GetLast(), "Windows 10") && CheckBools(ExpectedBools, tempreg.GetLast(), "Windows 10");
            HighlightSubtest(11, ok);
            //NextTest(3);
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
                BeginInvoke(new MethodInvoker(delegate {
                    if (i > 4)
                    {
                        return;
                    }

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
            BeginInvoke(new MethodInvoker(delegate {
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

        private void Blink_Tick(object sender, EventArgs e)
        {
            noticeLabel.ForeColor = ((noticeLabel.ForeColor == SystemColors.ControlText) ? Color.Red : SystemColors.ControlText);
        }

        private void TestSuite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("Screenshot saved as " + Program.dr.Screenshot(this), "Screenshot taken!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Show();
            }
        }
    }
}
