using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Windows.Forms;
using SimulatorDatabase;
using static System.Windows.Forms.Design.AxImporter;

namespace UltimateBlueScreenSimulator
{
    public class TemplateRegistry
    {
        private List<BlueScreen> bluescreens;
        private readonly string[] defaults;
        public bool saveFinished = false;
        private string[] nt_errors = Properties.Resources.NTERRORDATABASE.Replace("\r\n", "\n").Split('\n');
        private string[] culprits = Properties.Resources.CULPRIT_FILES.Replace("\r\n", "\n").Split('\n');
        private string[] nx_errors = Properties.Resources._9xERRORS.Replace("\r\n", "\n").Split('\n');

        /// <summary>
        /// Determines if the user has made modifications in the quick and dirty dictionary editor.
        /// </summary>
        public bool qaddeTrip = false;
        
        public TemplateRegistry()
        {
            bluescreens = new List<BlueScreen>();
            defaults = new string[] {
                "Windows 1.x/2.x",
                "Windows 3.1x",
                "Windows 9x/Me",
                "Windows CE",
                "Windows NT 3.1",
                "Windows NT 3.x/4.0",
                "Windows 2000",
                "Windows XP",
                "Windows Vista",
                "Windows 7",
                "Windows 8 Beta",
                "Windows 8/8.1",
                "Windows 10",
                "Windows 11",
                "Windows 11 Beta"};

            Reset();
        }

        /// <summary>
        /// List of all available file formats
        /// </summary>
        public IDictionary<string, string> filters = new Dictionary<string, string>()
        {
            { "Bluescreen simulator 3.0 configuration files", "*.json" },
            { "Bluescreen simulator 2.1 configuration files", "*.bs2cfg;*.bs2" },
            { "Bluescreen simulator 2.0 configuration files", "*.bs2cfg;*.bs2" },
            { "Bluescreen simulator 1.x configuration files", "*.bscfg;*.bsc" },
        };

        /// <summary>
        /// Resets configurations list to default
        /// </summary>
        public void Reset()
        {
            if (Program.gs.ErrorCode != 500)
            {
                qaddeTrip = false;
                bluescreens.Clear();
                foreach (string def in defaults)
                {
                    AddTemplate(def);
                }
            }
            else
            {
                Program.halt = true;
            }
        }

        /// <summary>
        /// Clears all configurations from the list
        /// </summary>
        public void Clear()
        {
            qaddeTrip = false;
            bluescreens.Clear();
        }

        /// <summary>
        /// Allows you to add an OS template
        /// </summary>
        /// <param name="baseOS">Name of the OS to base the template on</param>
        /// <param name="friendlyname">Name to display to the user in the list of configurations</param>
        /// <param name="template">Template, which is used for setting the default settings</param>
        public void AddTemplate(string baseOS, string friendlyname = null, string template = null)
        {
            if ((friendlyname == null) && (template == null))
            {
                bluescreens.Add(new BlueScreen(baseOS));
            }
            else if ((friendlyname != null) && (template == null))
            {
                bluescreens.Add(new BlueScreen(baseOS));
                GetLast().SetString("friendlyname", friendlyname);
            } else
            {
                bluescreens.Add(new BlueScreen(template, false));
                GetLast().SetOSSpecificDefaults();
                GetLast().SetString("os", baseOS);
                GetLast().SetString("friendlyname", friendlyname);
            }
        }

        /// <summary>
        /// Allows you to get the last bluescreen template from the list
        /// </summary>
        public BlueScreen GetLast()
        {
            return bluescreens.Last();
        }
        
        /// <summary>
        /// Allows you to get bluescreen templates as an array
        /// </summary>
        public BlueScreen[] GetAll()
        {
            return bluescreens.ToArray();
        }

        /// <summary>
        /// Gets bluescreen template at the specified index
        /// </summary>
        /// <param name="idx">The index on the list</param>
        /// <returns>Blue screen template</returns>
        public BlueScreen GetAt(int idx)
        {
            return bluescreens[idx];
        }

        /// <summary>
        /// Allows you to edit a bluescreen template at the specified index
        /// </summary>
        /// <param name="idx">The index</param>
        /// <param name="edited">Edited template</param>
        public void EditAt(int idx, BlueScreen edited)
        {
            bluescreens[idx] = edited;
        }

        /// <summary>
        /// Resets a template while retaining the name and icon
        /// </summary>
        /// <param name="idx">Index on the list</param>
        public void ResetTemplate(int idx)
        {
            string friendly = bluescreens[idx].GetString("friendlyname");
            string icon = bluescreens[idx].GetString("icon");
            bluescreens[idx] = new BlueScreen(bluescreens[idx].GetString("os"));
            bluescreens[idx].SetString("icon", icon);
            bluescreens[idx].SetString("friendlyname", friendly);
        }

        /// <summary>
        /// Resets everything for a template under additional options
        /// </summary>
        /// <param name="idx">Index on the list</param>
        public void ResetHacks(int idx)
        {
            bluescreens[idx].ClearAllTitleTexts();
            bluescreens[idx].SetOSSpecificDefaults();
        }

        /// <summary>
        /// Deletes the configuration from the list at the specified index
        /// </summary>
        /// <param name="idx">Index on the list</param>
        public void RemoveAt(int idx)
        {
            bluescreens.RemoveAt(idx);
        }

        /// <summary>
        /// Checks if any of the specified operating systems exist on the bluescreens list
        /// </summary>
        /// <param name="os1">OS name 1</param>
        /// <param name="os2">OS name 2</param>
        /// <param name="os3">OS name 3</param>
        /// <returns>Indication whether or not the OS exists on the list</returns>
        private bool CheckExist(string os1, string os2 = "", string os3 = "")
        {
            foreach (BlueScreen bs in Program.templates.GetAll())
            {
                if ((bs.GetString("os") == os1) || (bs.GetString("os") == os2) || (bs.GetString("os") == os3))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if current file format is the specified version number
        /// </summary>
        /// <param name="filterIndex">Filter index on filters dictionary</param>
        /// <param name="version">Desired format version</param>
        /// <returns>Indication of whether or not selected filter contains the specified version number</returns>
        private bool CheckFormat(int filterIndex, string version)
        {
            string format;
            try
            {
                format = filters.Keys.ToArray()[filterIndex];
            } catch
            {
                format = $"Bluescreen simulator {version} configuration files";
            }
            return format == $"Bluescreen simulator {version} configuration files";
        }

        /// <summary>
        /// Saves a file with the filename and format specified
        /// </summary>
        /// <param name="filename">Full file path</param>
        /// <param name="filterIndex">File format filterIndex</param>
        /// <param name="ignoreErrors">For internal use only: avoid displaying dialog boxes when warnings or errors occur</param>
        public void SaveData(string filename, int filterIndex, bool ignoreErrors = false)
        {
            string filedata;
            filterIndex--;
            if (CheckFormat(filterIndex, "3.0"))
            {
                try
                {
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    filedata = JsonSerializer.Serialize(Program.templates, options);
                    File.WriteAllText(filename, filedata);
                    saveFinished = true;
                    return;
                }
                catch (DllNotFoundException) when (!Debugger.IsAttached)
                {
                    Program.DllError();
                    saveFinished = true;
                    return;
                }
                catch (IOException) when (!Debugger.IsAttached)
                {
                    Program.DllError();
                    return;
                }
            }
            else if (CheckFormat(filterIndex, "2.1"))
            {
                if (!ignoreErrors) MessageBox.Show("Warning: Custom NT error codes and culprit files will not be saved with this format.", "Legacy format selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                filedata = "*** Blue screen simulator plus 2.1 ***";
            }
            else if (CheckFormat(filterIndex, "2.0"))
            {
                if (!ignoreErrors) MessageBox.Show("Warning: Custom NT error codes, culprit files and progress tuner data will not be saved and there won't be Windows Vista/7 separation with this format.", "Legacy format selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                filedata = "*** Blue screen simulator plus 2.0 ***";
            }
            else
            {
                filedata = LegacySave();
                if (filedata != " * ERROR * ")
                {
                    File.WriteAllText(filename, filedata, System.Text.Encoding.Unicode);
                    if (!ignoreErrors) MessageBox.Show("Blue screen configuration saved successfully", "Blue screen simulator 1.x configuration file creator", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (!ignoreErrors) MessageBox.Show("Blue screen configuration was not saved, because an error occoured.\n\nBefore attempting to save to 1.x format, make sure that the following operating systems exist in your configuration list:\n\nWindows 10 and/or 11\nWindows Vista or Windows 7\nWindows XP\nWindows CE\nWindows NT 3.x/4.0\nWindows 9x/Me\nWindows 3.1x", "Blue screen simulator 1.x configuration file creator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                saveFinished = true;
                Thread.CurrentThread.Abort();
            }
            foreach (BlueScreen bs in bluescreens)
            {
                if (CheckFormat(filterIndex, "2.0"))
                {
                    filedata += "\n\n\n#" + bs.GetString("os") + "\n\n";
                }
                else
                {
                    filedata += "\n\n\n#" + bs.GetString("os").Replace("Windows Vista", "Windows Vista/7").Replace("Windows 7", "Windows Vista/7") + "\n\n";
                }
                if (bs.AllStrings().Count > 0)
                {
                    filedata += "\n\n[string]";
                    foreach (KeyValuePair<string, string> entry in bs.AllStrings())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace(":", "::").Replace("#", ":h:").Replace(";", ":sc:").Replace("[", ":sb:").Replace("]", ":eb:") + ";";
                    }
                }
                filedata += "\necode1=" + bs.GetString("ecode1") + ";";
                filedata += "\necode2=" + bs.GetString("ecode2") + ";";
                filedata += "\necode3=" + bs.GetString("ecode3") + ";";
                filedata += "\necode4=" + bs.GetString("ecode4") + ";";
                filedata += "\nicon=" + bs.GetString("icon") + ";";
                if ((bs.AllProgress().Count > 0) && CheckFormat(filterIndex, "2.1"))
                {
                    filedata += "\n\n[progress]";
                    foreach (KeyValuePair<int, int> entry in bs.AllProgress())
                    {
                        filedata += string.Format("\n{0}={1};", entry.Key, entry.Value);
                    }
                }
                if (bs.GetFiles().Count > 0)
                {
                    filedata += "\n\n[nt_codes]";
                    foreach (KeyValuePair<string, string[]> entry in bs.GetFiles())
                    {
                        filedata += "\n" + entry.Key + "=" + string.Join(",", entry.Value) + ";";
                    }
                }

                if (bs.AllBools().Count > 0)
                {
                    filedata += "\n\n[boolean]";
                    foreach (KeyValuePair<string, bool> entry in bs.AllBools())
                    {
                        if (!((entry.Key == "font_support") && (bs.GetString("os") == "Windows 2000") && !CheckFormat(filterIndex, "2.1")))
                        {
                            filedata += "\n" + entry.Key + "=" + entry.Value.ToString() + ";";
                        }
                        else
                        {
                            // makes sure that Windows 2k blue screens have font support if saving in older format
                            filedata += "\nfont_support=True;";
                        }
                    }
                }

                if (bs.AllInts().Count > 0)
                {
                    filedata += "\n\n[integer]";
                    foreach (KeyValuePair<string, int> entry in bs.AllInts())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.ToString() + ";";
                    }
                }

                filedata += "\n\n[theme]";
                filedata += "\nbg=" + RGB_String(bs.GetTheme(true)) + ";";
                filedata += "\nfg=" + RGB_String(bs.GetTheme(false)) + ";";
                filedata += "\nhbg=" + RGB_String(bs.GetTheme(true, true)) + ";";
                filedata += "\nhfg=" + RGB_String(bs.GetTheme(false, true)) + ";";

                if (bs.GetTitles().Count > 0)
                {
                    filedata += "\n\n[title]";
                    foreach (KeyValuePair<string, string> entry in bs.GetTitles())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace(":", "::").Replace("#", ":h:").Replace(";", ":sc:").Replace("[", ":sb:").Replace("]", ":eb:") + ";";
                    }
                }

                if (bs.GetTexts().Count > 0)
                {
                    filedata += "\n\n[text]";
                    foreach (KeyValuePair<string, string> entry in bs.GetTexts())
                    {
                        filedata += "\n" + entry.Key + "=" + entry.Value.Replace(":", "::").Replace("#", ":h:").Replace(";", ":sc:").Replace("[", ":sb:").Replace("]", ":eb:") + ";";
                    }
                }

                if (bs.GetBool("font_support") || (CheckFormat(filterIndex, "2.0") && (bs.GetString("os") == "Windows 2000")))
                {
                    if (bs.GetString("os") != "Windows 2000")
                    {
                        filedata += "\n\n[format]";
                        filedata += "\nfontfamily=" + bs.GetFont().FontFamily.Name + ";";
                        filedata += "\nsize=" + bs.GetFont().Size.ToString() + ";";
                        filedata += "\nstyle=" + bs.GetFont().Style.ToString() + ";";
                    }
                    else
                    {
                        // Added to support saving to version 2.0 format
                        filedata += "\n\n[format]";
                        filedata += "\nfontfamily=Lucida Console;";
                        filedata += "\nsize=8;";
                        filedata += "\nstyle=Bold;";
                    }
                }
            }
            File.WriteAllText(filename, filedata);
            saveFinished = true;
        }


        /// <summary>
        /// Converts comma separated string containing RGB values to a color
        /// </summary>
        /// <param name="rgb">Comma separated string</param>
        private Color StringToRGB(string rgb)
        {
            string[] splitted_rgb = rgb.Split(',');
            return Color.FromArgb(Convert.ToInt32(splitted_rgb[0]), Convert.ToInt32(splitted_rgb[1]), Convert.ToInt32(splitted_rgb[2]));
        }

        /// <summary>
        /// Converts color to a string containing comma separated RGB values
        /// </summary>
        /// <param name="rgb">Color to convert</param>
        /// <returns>Comma separated value</returns>
        private string RGB_String(Color rgb)
        {
            return rgb.R.ToString() + "," + rgb.G.ToString() + "," + rgb.B.ToString();
        }


        /// <summary>
        /// This function allows for loading a single blue screen template from a json string. This is useful for creating a single bluescreen object and doing fun things with it.
        /// </summary>
        /// <param name="data">JSON input</param>
        /// <returns>BlueScreen object as the output</returns>
        public BlueScreen LoadSingleConfig(string data)
        {
            BlueScreen me = new BlueScreen();
            try
            {
                // single line to load is pretty cool ngl
                me = JsonSerializer.Deserialize<BlueScreen>(data);
                return me;
            }
            catch (DllNotFoundException) when (!Debugger.IsAttached)
            {
                Program.DllError();
            }
            catch (IOException) when (!Debugger.IsAttached)
            {
                Program.DllError();
            }
            catch (Exception ex) when (!Debugger.IsAttached)
            {
                MessageBox.Show($"Whoops, something went wrong while trying to load the embedded configuration! The application cannot continue.\r\n\r\nError details:\r\n{ex.Message}\r\n{ex.StackTrace}", "Blue screen simulator plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return me;
            }
            return me;
        }

        /// <summary>
        /// Serializes a specified bluescreen configuration data into JSON data
        /// </summary>
        /// <param name="me">BlueScreen object you want to convert</param>
        /// <returns>JSON string</returns>
        public string SaveSingleConfig(BlueScreen me)
        {
            return JsonSerializer.Serialize(me);
        }


        /// <summary>
        /// Loads a configuration file from the path specified
        /// </summary>
        /// <param name="filename">Full path to file</param>
        public TemplateRegistry LoadConfig(string filename)
        {
            string filedata = File.ReadAllText(filename);
            string version = filedata.Split('\n')[0];
            string databases = "";
            bool added_randomness = false;
            if (version.StartsWith("*** Blue screen simulator plus 1."))
            {
                LegacyLoad(File.ReadAllLines(filename));
            }
            else if (version.StartsWith("*** Blue screen simulator plus 2."))
            {
                string[] primary_section_tokens = filedata.Split('#');
                Clear();
                foreach (string section in primary_section_tokens)
                {
                    Thread.Sleep(10);
                    string[] subsection_tokens = section.Split('[');
                    if (section.StartsWith("*")) { continue; }
                    // replace Windows Vista/7 with Windows 7 for backwards compatibility reasons
                    string os_name = subsection_tokens[0].Replace("\n", "").Replace("Windows Vista/7", "Windows 7");
                    if (os_name == "") { continue; }
                    BlueScreen bs = new BlueScreen(os_name, false);
                    bs.ClearAllTitleTexts();
                    bs.ClearFiles();
                    foreach (string subsection in subsection_tokens)
                    {
                        if (subsection.IndexOf("]") > 0)
                        {
                            string type = subsection.Substring(0, subsection.IndexOf("]"));
                            string subsection_withoutheading = subsection.Substring(type.Length + 1);
                            string[] entries = subsection_withoutheading.Split(';');
                            Color theme_bg = Color.Black;
                            Color theme_fg = Color.White;
                            Color theme_hbg = Color.White;
                            Color theme_hfg = Color.Black;
                            string fontfamily = "";
                            float size = 1.0f;
                            FontStyle style = FontStyle.Regular;
                            foreach (string entry in entries)
                            {
                                if (entry.Replace("\n", "") != "")
                                {
                                    string key = entry.Split('=')[0].Replace("\n", "");
                                    string value = entry.Substring(entry.IndexOf("=") + 1);
                                    switch (type)
                                    {
                                        case "string":
                                            bs.SetString(key, value.Replace("::", ":/:/:").Replace(":h:", "#").Replace(":sc:", ";").Replace(":sb:", "[").Replace(":eb:", "]").Replace(":/:/:", ":"));
                                            break;
                                        case "integer":
                                            bs.SetInt(key, Convert.ToInt32(value));
                                            break;
                                        case "boolean":
                                            bs.SetBool(key, Convert.ToBoolean(value));
                                            break;
                                        case "title":
                                            bs.PushTitle(key, value.Replace("::", ":/:/:").Replace(":h:", "#").Replace(":sc:", ";").Replace(":sb:", "[").Replace(":eb:", "]").Replace(":/:/:", ":"));
                                            break;
                                        case "progress":
                                            added_randomness = true;
                                            bs.SetProgression(int.Parse(key), int.Parse(value));
                                            break;
                                        case "nt_codes":
                                            bs.PushFile(key, value.Split(','));
                                            break;
                                        case "text":
                                            bs.PushText(key, value.Replace("::", ":/:/:").Replace(":h:", "#").Replace(":sc:", ";").Replace(":sb:", "[").Replace(":eb:", "]").Replace(":/:/:", ":"));
                                            break;
                                        case "theme":
                                            switch (key)
                                            {
                                                case "bg":
                                                    theme_bg = StringToRGB(value);
                                                    bs.SetTheme(theme_bg, theme_fg);
                                                    break;
                                                case "fg":
                                                    theme_fg = StringToRGB(value);
                                                    bs.SetTheme(theme_bg, theme_fg);
                                                    break;
                                                case "hbg":
                                                    theme_hbg = StringToRGB(value);
                                                    bs.SetTheme(theme_hbg, theme_hfg, true);
                                                    break;
                                                case "hfg":
                                                    theme_hfg = StringToRGB(value);
                                                    bs.SetTheme(theme_hbg, theme_hfg, true);
                                                    break;
                                            }
                                            break;
                                        case "format":
                                            switch (key)
                                            {
                                                case "fontfamily":
                                                    fontfamily = value;
                                                    break;
                                                case "size":
                                                    size = (float)Convert.ToDouble(value);
                                                    break;
                                                case "style":
                                                    style = (FontStyle)Enum.Parse(typeof(FontStyle), value);
                                                    break;
                                            }
                                            break;
                                    }
                                }
                            }
                            bs.SetFont(fontfamily, size, style);
                        }
                    }
                    if (!Program.gs.Randomness)
                    {
                        added_randomness = true;
                    }
                    if (!added_randomness)
                    {
                        bs.SetDefaultProgression();
                    }
                    bluescreens.Add(bs);
                }
            } else
            {
                try
                {
                    // single line to load is pretty cool ngl
                    TemplateRegistry tempreg = new TemplateRegistry();
                    tempreg = JsonSerializer.Deserialize<TemplateRegistry>(filedata);
                    return tempreg;
                }
                catch (DllNotFoundException) when (!Debugger.IsAttached)
                {
                    Program.DllError();
                    saveFinished = true;
                    return this;
                }
                catch (IOException) when (!Debugger.IsAttached)
                {
                    Program.DllError();
                    return this;
                }
            }
            return this;
        }


        /// <summary>
        /// Loads a legacy configuration from the path specified
        /// </summary>
        /// <param name="filelines">Full path of the configuration file</param>

        // This function only exists to support backwards compatibility with older BSSP config files
        // don't judge it
        // it is a reworked version of spaghetti that existed in the first version
        public void LegacyLoad(string[] filelines)
        {
            try
            {
                // remove versions that aren't supported by 1.x files
                Clear();
                AddTemplate("Windows 3.1x");
                AddTemplate("Windows 9x/Me");
                AddTemplate("Windows CE");
                AddTemplate("Windows NT 3.x/4.0");
                AddTemplate("Windows 2000");
                AddTemplate("Windows XP");
                AddTemplate("Windows 7");
                AddTemplate("Windows 8/8.1");
                AddTemplate("Windows 10");
                foreach (string fileline in filelines)
                {
                    if (fileline.Contains("***")) { continue; }
                    if (fileline.StartsWith("FACE "))
                    {
                        bluescreens[7].SetString("emoticon", fileline.Replace("FACE ", ""));
                        bluescreens[8].SetString("emoticon", fileline.Replace("FACE ", ""));
                    }
                    else if (fileline.StartsWith("MODERN "))
                    {
                        bluescreens[7].SetTheme(Color.FromArgb(Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[0].ToString().Split(':')[2].ToString())), Color.FromArgb(Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("MODERN ", "").Split(',')[1].ToString().Split(':')[2].ToString())));
                        bluescreens[8].SetTheme(bluescreens[7].GetTheme(true), bluescreens[7].GetTheme(false));
                    }
                    else if (fileline.StartsWith("W2K "))
                    {
                        Color[] modests = { Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[2].ToString())), Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[2].ToString())) };
                        bluescreens[4].SetTheme(modests[0], modests[1]);
                    }
                    else if (fileline.StartsWith("NT34 "))
                    {
                        Color[] modests = { Color.FromArgb(Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("NT34 ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[0].ToString().Split(':')[2].ToString())), Color.FromArgb(Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W2K ", "").Split(',')[1].ToString().Split(':')[2].ToString())) };
                        bluescreens[3].SetTheme(modests[0], modests[1]);
                    }
                    else if (fileline.StartsWith("W9XME "))
                    {
                        Color me9xbsodbg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                        Color me9xbsodfg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                        bluescreens[0].SetTheme(me9xbsodbg, me9xbsodfg);
                        bluescreens[1].SetTheme(me9xbsodbg, me9xbsodfg);
                    }
                    else if (fileline.StartsWith("W9XME_HL "))
                    {
                        Color me9xbsodhlbg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[0].ToString().Split(':')[2].ToString()));
                        Color me9xbsodhlfg = Color.FromArgb(Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[0].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[1].ToString()), Convert.ToInt32(fileline.Replace("W9XME_HL ", "").Split(',')[1].ToString().Split(':')[2].ToString()));
                        bluescreens[0].SetTheme(me9xbsodhlbg, me9xbsodhlfg, true);
                        bluescreens[1].SetTheme(me9xbsodhlbg, me9xbsodhlfg, true);
                    }
                }
                string restof = "";
                for (int i = 7; i < filelines.Length; i++)
                {
                    restof += filelines[i] + "\n";
                }
                string[] sections = restof.Replace("--", "\t").Split('\t');
                string strings = "";
                string fonts = "";
                string miscs = "";
                for (int i = 0; i < sections.Length; i++)
                {
                    Thread.Sleep(10);
                    if (sections[i] == "STRINGBUILD START")
                    {
                        strings = sections[i + 1];
                    }
                    if (sections[i] == "FONT START")
                    {
                        fonts = sections[i + 1];
                    }
                    if (sections[i] == "MISC START")
                    {
                        miscs = sections[i + 1];
                    }
                }
                string[] stringlist = { };
                string[] misclist = { };
                string[] fontlist = { };
                try
                {
                    stringlist = strings.Substring(1, strings.Length - 1).Replace("http://", "\\\\").Replace("//", "\t").Replace("\\\\", "http://").Split('\t');
                    misclist = miscs.Substring(1, miscs.Length - 1).Split('\n');
                    fontlist = fonts.Substring(1, fonts.Length - 1).Split('\n');
                }
                catch { }
                bool fontok = true;
                foreach (string element in fontlist)
                {
                    try
                    {
                        if (!element.Contains(",")) { continue; }
                        string[] subfont = element.Replace("label26: ", "").Replace("label39: ", "").Replace("label49: ", "").Replace("label50: ", "").Replace("modernDetailFont: ", "").Replace("emotiFont: ", "").Replace("modernTextFont: ", "").Replace(",4", "").Split(',');
                        FontStyle fs = new FontStyle();
                        fs = FontStyle.Regular;
                        if (subfont[5] == "Bold=True") { fs |= FontStyle.Bold; }
                        if (subfont[6] == "Italic=True") { fs |= FontStyle.Italic; }
                        if (subfont[7] == "Underline=True") { fs |= FontStyle.Underline; }
                        string family = subfont[0].ToString();
                        int fontsize = Convert.ToInt32(subfont[1].Replace("Size=", ""));
                        if (element.StartsWith("modernTextFont: "))
                        {
                            bluescreens[7].SetFont(family, fontsize, fs);
                            bluescreens[8].SetFont(family, fontsize, fs);
                        }
                        if (element.StartsWith("label50: ")) { bluescreens[6].SetFont(family, fontsize, fs); }
                        if (element.StartsWith("label49: ")) { bluescreens[5].SetFont(family, fontsize, fs); }
                        if (element.StartsWith("label39: ")) { bluescreens[4].SetFont(family, fontsize, fs); }
                        if (element.StartsWith("label26: ")) { bluescreens[3].SetFont(family, fontsize, fs); }
                    }
                    catch { fontok = false; }
                }
                try
                {
                    foreach (string element in misclist)
                    {
                        if (element.StartsWith("qrType: "))
                        {
                            string decide = element.Replace("qrType: ", "");
                            if (decide == "Default")
                            {
                                bluescreens[7].SetString("qr_file", "local:0");
                                bluescreens[8].SetString("qr_file", "local:0");
                            }
                            if (decide == "Transparent")
                            {
                                bluescreens[7].SetString("qr_file", "local:1");
                                bluescreens[8].SetString("qr_file", "local:1");
                            }
                        }

                        else if (element.StartsWith("qrPath: "))
                        {
                            bluescreens[7].SetString("qr_file", element.Replace("qrPath: ", ""));
                            bluescreens[8].SetString("qr_file", element.Replace("qrPath: ", ""));
                        }
                        else if (element.StartsWith("qrSize: "))
                        {
                            bluescreens[7].SetInt("qr_file", Convert.ToInt32(element.Replace("qrSize: ", "")));
                            bluescreens[8].SetInt("qr_size", Convert.ToInt32(element.Replace("qrSize: ", "")));
                        }
                    }
                }
                catch { }

                // Windows 3.1/9x
                bluescreens[0].SetTitle("Main", stringlist[0].Replace("\n", Environment.NewLine));
                bluescreens[1].SetTitle("Main", stringlist[0].Replace("\n", Environment.NewLine));
                bluescreens[1].SetTitle("System is busy", stringlist[1].Replace("\n", Environment.NewLine));
                bluescreens[1].SetTitle("Warning", stringlist[2].Replace("\n", Environment.NewLine));
                bluescreens[1].SetText("System error", stringlist[3].Replace("\n", Environment.NewLine));
                bluescreens[1].SetText("Prompt", stringlist[4].Replace("\n", Environment.NewLine));
                bluescreens[0].SetText("No unresponsive programs", stringlist[5].Replace("\n", Environment.NewLine));
                bluescreens[0].SetInt("blink_speed", Convert.ToInt32(stringlist[6].Replace("\n", Environment.NewLine)));
                bluescreens[1].SetInt("blink_speed", Convert.ToInt32(stringlist[6].Replace("\n", Environment.NewLine)));
                bluescreens[3].SetInt("blink_speed", Convert.ToInt32(stringlist[6].Replace("\n", Environment.NewLine)));
                bluescreens[1].SetText("Application error", stringlist[7].Replace("\n", Environment.NewLine));
                bluescreens[1].SetText("Driver error", stringlist[8].Replace("\n", Environment.NewLine));
                bluescreens[1].SetText("System is busy", stringlist[9].Replace("\n", Environment.NewLine));
                bluescreens[1].SetText("System is unresponsive", stringlist[10].Replace("\n", Environment.NewLine));

                // Windows CE
                bluescreens[2].SetText("A problem has occurred...", stringlist[11].Replace("\n", Environment.NewLine));
                bluescreens[2].SetText("CTRL+ALT+DEL message", stringlist[12].Replace("\n", Environment.NewLine));
                bluescreens[2].SetText("Technical information", stringlist[13].Replace("\n", Environment.NewLine));
                bluescreens[2].SetText("Technical information formatting", stringlist[14].Replace("\n", Environment.NewLine));
                bluescreens[2].SetText("Restart message", stringlist[15].Replace("\n", Environment.NewLine));
                bluescreens[2].SetInt("timer", Convert.ToInt32(stringlist[16].Replace("\n", Environment.NewLine)));
                bluescreens[2].SetInt("timer", Convert.ToInt32(stringlist[16].Replace("\n", Environment.NewLine)));

                // Windows NT
                bluescreens[3].SetText("Error code formatting", stringlist[17].Replace("\n", Environment.NewLine));
                bluescreens[3].SetText("CPUID formatting", stringlist[18].Replace("\n", Environment.NewLine));
                bluescreens[3].SetText("Stack trace heading", stringlist[19].Replace("\n", Environment.NewLine));
                bluescreens[3].SetText("Stack trace table formatting", stringlist[20].Replace("\n", Environment.NewLine));
                bluescreens[3].SetText("Memory address dump heading", stringlist[21].Replace("\n", Environment.NewLine));
                bluescreens[3].SetText("Memory address dump table", stringlist[22].Replace("\n", Environment.NewLine));
                bluescreens[3].SetText("Troubleshooting text", stringlist[23].Replace("\n", Environment.NewLine));

                // Windows 2000
                bluescreens[4].SetText("Error code formatting", stringlist[24].Replace("\n", Environment.NewLine));
                bluescreens[4].SetText("Troubleshooting introduction", stringlist[25].Replace("\n", Environment.NewLine));
                bluescreens[4].SetText("Troubleshooting text", stringlist[27].Replace("\n", Environment.NewLine));
                bluescreens[4].SetText("Additional troubleshooting information", (stringlist[28]).Replace("\n", Environment.NewLine));

                // Windows XP/Vista
                bluescreens[5].SetText("A problem has been detected...", stringlist[26].Replace("\n", Environment.NewLine));
                bluescreens[6].SetText("A problem has been detected...", stringlist[26].Replace("\n", Environment.NewLine));
                bluescreens[5].SetText("Troubleshooting introduction", stringlist[29].Replace("\n", Environment.NewLine));
                bluescreens[6].SetText("Troubleshooting introduction", stringlist[29].Replace("\n", Environment.NewLine));
                bluescreens[5].SetText("Troubleshooting", stringlist[30].Replace("\n", Environment.NewLine));
                bluescreens[6].SetText("Troubleshooting", stringlist[30].Replace("\n", Environment.NewLine));
                bluescreens[5].SetText("Technical information", stringlist[31].Replace("\n", Environment.NewLine));
                bluescreens[6].SetText("Technical information", stringlist[31].Replace("\n", Environment.NewLine));
                bluescreens[5].SetText("Technical information formatting", stringlist[32].Replace("\n", Environment.NewLine));
                bluescreens[6].SetText("Technical information formatting", stringlist[32].Replace("\n", Environment.NewLine));
                bluescreens[5].SetText("Physical memory dump", stringlist[33].Replace("\n", Environment.NewLine));
                bluescreens[6].SetText("Physical memory dump", stringlist[35].Replace("\n", Environment.NewLine));
                string xp_support = stringlist[34].Split('\n')[0] + "\n" + stringlist[34].Split('\n')[1];
                string vista_support = stringlist[34].Split('\n')[2];
                bluescreens[5].SetText("Technical support", xp_support.Replace("\n", Environment.NewLine));
                bluescreens[6].SetText("Technical support", vista_support.Replace("\n", Environment.NewLine));

                // Windows 8
                bluescreens[7].ClearProgress();
                bluescreens[7].SetText("Information text with dump", stringlist[36].Replace("\n", Environment.NewLine));
                bluescreens[7].SetText("Information text without dump", stringlist[37].Replace("\n", Environment.NewLine));
                bluescreens[7].SetText("Error code", stringlist[38].Replace("\n", Environment.NewLine));
                if (Program.gs.Randomness)
                {
                    bluescreens[7].SetDefaultProgression();
                }

                // Windows 10
                bluescreens[8].ClearProgress();
                bluescreens[8].SetText("Information text with dump", stringlist[40].Replace("\n", Environment.NewLine));
                bluescreens[8].SetText("Information text without dump", stringlist[39].Replace("\n", Environment.NewLine));
                bluescreens[8].SetText("Additional information", stringlist[41].Replace("\n", Environment.NewLine));
                bluescreens[8].SetText("Culprit file", stringlist[42].Replace("\n", Environment.NewLine));
                bluescreens[8].SetText("Progress", stringlist[43].Replace("\n", Environment.NewLine));
                bluescreens[8].SetText("Error code", stringlist[44].Replace("\n", Environment.NewLine));
                if (Program.gs.Randomness)
                {
                    bluescreens[8].SetDefaultProgression();
                }
                if (!fontok)
                {
                    MessageBox.Show("The configuration file was loaded, but some fonts weren't changed due to an error.", "Config loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// Generates save data in legacy 1.x format
        /// </summary>
        /// <returns>Save data contents</returns>
        private string LegacySave()
        {
            string filedata = "*** Blue screen simulator plus 1.11 ***";
            BlueScreen winmodern = bluescreens.First();
            BlueScreen wineight = bluescreens.First();
            BlueScreen vista7 = bluescreens.First();
            BlueScreen xp = bluescreens.First();
            BlueScreen win2k = bluescreens.First();
            BlueScreen winnt = bluescreens.First();
            BlueScreen ninexme = bluescreens.First();
            BlueScreen ce = bluescreens.First();
            BlueScreen threeone = bluescreens.First();
            bool bsdefined = false;
            // select winModern (Windows 10 or 11)
            if (!CheckExist("Windows 10", "Windows 11")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in bluescreens) { if ((bs.GetString("os") == "Windows 11") || (bs.GetString("os") == "Windows 10")) { if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for modern blue screens and text data for Windows 10 blue screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { winmodern = bs; bsdefined = true; break; } } }
            }

            if (!CheckExist("Windows 8/8.1")) { return " * ERROR * "; }
            bsdefined = false;
            while (!bsdefined)
            {
                foreach (BlueScreen bs in bluescreens) { if ((bs.GetString("os") == "Windows 11") || (bs.GetString("os") == "Windows 10") || (bs.GetString("os") == "Windows 8/8.1")) { if (MessageBox.Show(string.Format("Would you like to use the following blue screen's text data for Windows 8/8.1 blue screens:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { wineight = bs; bsdefined = true; break; } } }
            }


            if (!CheckExist("Windows Vista", "Windows 7")) { return " * ERROR * "; }
            bsdefined = false;
            while (!bsdefined)
            {
                foreach (BlueScreen bs in bluescreens) { if ((bs.GetString("os") == "Windows Vista") || (bs.GetString("os") == "Windows 7")) { if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows Vista/7 blue screens:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { vista7 = bs; bsdefined = true; break; } } }
            }
            if (!CheckExist("Windows XP")) { return " * ERROR * "; }
            bsdefined = false;
            while (!bsdefined)
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    if ((bs.GetString("os") == "Windows XP"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows XP blue screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            xp = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            if (!CheckExist("Windows 2000")) { return " * ERROR * "; }
            bsdefined = false;
            while (!bsdefined)
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    if ((bs.GetString("os") == "Windows 2000"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows 2000 blue screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            win2k = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            bsdefined = false;
            if (!CheckExist("Windows NT 3.x/4.0")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    if ((bs.GetString("os") == "Windows NT 3.x/4.0"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows NT 3.x/4.0 blue screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            winnt = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            bsdefined = false;
            if (!CheckExist("Windows 9x/Me")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    if ((bs.GetString("os") == "Windows 9x/Me"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows 9x/Me blue screens:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ninexme = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            bsdefined = false;
            if (!CheckExist("Windows CE")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    if ((bs.GetString("os") == "Windows CE"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows CE blue screens:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ce = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            bsdefined = false;
            if (!CheckExist("Windows 3.1x")) { return " * ERROR * "; }
            while (!bsdefined)
            {
                foreach (BlueScreen bs in bluescreens)
                {
                    if ((bs.GetString("os") == "Windows 3.1x"))
                    {
                        if (MessageBox.Show(string.Format("Would you like to use the following blue screen as the configuration base for Windows 3.1x CTRL+ALT+DELETE screen:\n\n{0}", bs.GetString("friendlyname")), "Legacy save function", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            threeone = bs; bsdefined = true; break;
                        }
                    }
                }
            }
            filedata += string.Format("\nFACE {0}", winmodern.GetString("emoticon"));
            filedata += string.Format("\nMODERN {0}:{1}:{2},{3}:{4}:{5}", winmodern.GetTheme(true).R, winmodern.GetTheme(true).G, winmodern.GetTheme(true).B, winmodern.GetTheme(false).R, winmodern.GetTheme(false).G, winmodern.GetTheme(false).B);
            filedata += string.Format("\nW2K {0}:{1}:{2},{3}:{4}:{5}", win2k.GetTheme(true).R, win2k.GetTheme(true).G, win2k.GetTheme(true).B, win2k.GetTheme(false).R, win2k.GetTheme(false).G, win2k.GetTheme(false).B);
            filedata += string.Format("\nNT34 {0}:{1}:{2},{3}:{4}:{5}", winnt.GetTheme(true).R, winnt.GetTheme(true).G, winnt.GetTheme(true).B, winnt.GetTheme(false).R, winnt.GetTheme(false).G, winnt.GetTheme(false).B);
            filedata += string.Format("\nW9XME {0}:{1}:{2},{3}:{4}:{5}", ninexme.GetTheme(true).R, ninexme.GetTheme(true).G, ninexme.GetTheme(true).B, ninexme.GetTheme(false).R, ninexme.GetTheme(false).G, ninexme.GetTheme(false).B);
            filedata += string.Format("\nW9XME_HL {0}:{1}:{2},{3}:{4}:{5}", ninexme.GetTheme(true, true).R, ninexme.GetTheme(true, true).G, ninexme.GetTheme(true, true).B, ninexme.GetTheme(false, true).R, ninexme.GetTheme(false, true).G, ninexme.GetTheme(false, true).B);
            filedata += "\n--STRINGBUILD START--\n";
            filedata += string.Format("{0}//{1}//{2}//{3}//{4}//{5}//{6}//{7}//{8}//{9}//{10}//{11}//{12}//{13}//{14}//{15}//{16}//{17}//{18}//{19}//{20}//{21}//{22}//{23}//{24}//{25}//{26}//{27}//{28}//{29}//{30}//{31}//{32}//{33}//{34}//{35}//{36}//{37}//{38}//{39}//{40}//{41}//{42}//{43}//{44}//--STRINGBUILD END--",
                        ninexme.GetTitles()["Main"],
                        ninexme.GetTitles()["System is busy"],
                        ninexme.GetTitles()["Warning"],
                        ninexme.GetTexts()["System error"],
                        ninexme.GetTexts()["Prompt"],
                        threeone.GetTexts()["No unresponsive programs"],
                        ninexme.GetInt("blink_speed"),
                        ninexme.GetTexts()["Application error"],
                        ninexme.GetTexts()["Driver error"],
                        ninexme.GetTexts()["System is busy"],
                        ninexme.GetTexts()["System is unresponsive"],
                        ce.GetTexts()["A problem has occurred..."],
                        ce.GetTexts()["CTRL+ALT+DEL message"],
                        ce.GetTexts()["Technical information"],
                        ce.GetTexts()["Technical information formatting"],
                        ce.GetTexts()["Restart message"],
                        ce.GetInt("timer"),
                        winnt.GetTexts()["Error code formatting"],
                        winnt.GetTexts()["CPUID formatting"],
                        winnt.GetTexts()["Stack trace heading"],
                        winnt.GetTexts()["Stack trace table formatting"],
                        winnt.GetTexts()["Memory address dump heading"],
                        winnt.GetTexts()["Memory address dump table"],
                        winnt.GetTexts()["Troubleshooting text"],
                        win2k.GetTexts()["Error code formatting"],
                        win2k.GetTexts()["Troubleshooting introduction"],
                        xp.GetTexts()["A problem has been detected..."],
                        win2k.GetTexts()["Troubleshooting text"],
                        win2k.GetTexts()["Additional troubleshooting information"],
                        xp.GetTexts()["Troubleshooting introduction"],
                        xp.GetTexts()["Troubleshooting"],
                        xp.GetTexts()["Technical information"],
                        xp.GetTexts()["Technical information formatting"],
                        xp.GetTexts()["Physical memory dump"],
                        xp.GetTexts()["Technical support"] + "\n" + vista7.GetTexts()["Technical support"],
                        vista7.GetTexts()["Physical memory dump"],
                        wineight.GetTexts()["Information text with dump"],
                        wineight.GetTexts()["Information text without dump"],
                        wineight.GetTexts()["Error code"],
                        winmodern.GetTexts()["Information text without dump"],
                        winmodern.GetTexts()["Information text with dump"],
                        winmodern.GetTexts()["Additional information"],
                        winmodern.GetTexts()["Culprit file"],
                        winmodern.GetTexts()["Progress"],
                        winmodern.GetTexts()["Error code"]);
            filedata += "\n--FONT START--";
            Font textfont = winmodern.GetFont();
            float textsize = textfont.Size;
            Font emotifont = new Font(winmodern.GetFont().FontFamily, textsize * 5f, winmodern.GetFont().Style);
            Font modernDetailFont = new Font(winmodern.GetFont().FontFamily, textsize * 0.55f, winmodern.GetFont().Style);

            filedata += string.Format("\nemotiFont: {0},Bold={1},Italic={2},Underline={3}", emotifont.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), winmodern.GetFont().Bold, winmodern.GetFont().Italic, winmodern.GetFont().Underline);
            filedata += string.Format("\nmodernTextFont: {0},Bold={1},Italic={2},Underline={3}", textfont.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), winmodern.GetFont().Bold, winmodern.GetFont().Italic, winmodern.GetFont().Underline);
            filedata += string.Format("\nmodernDetailFont: {0},Bold={1},Italic={2},Underline={3}", modernDetailFont.ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), winmodern.GetFont().Bold, winmodern.GetFont().Italic, winmodern.GetFont().Underline);
            filedata += string.Format("\nlabel50: {0},Bold={1},Italic={2},Underline={3}", vista7.GetFont().ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), vista7.GetFont().Bold, vista7.GetFont().Italic, vista7.GetFont().Underline);
            filedata += string.Format("\nlabel49: {0},Bold={1},Italic={2},Underline={3}", xp.GetFont().ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), xp.GetFont().Bold, xp.GetFont().Italic, xp.GetFont().Underline);
            filedata += "\nlabel39: Lucida Console,Size=8,Units=3,GdiCharSet=1,GdiVerticalFont=False,Bold=True,Italic=False,Underline=False";
            filedata += string.Format("\nlabel26: {0},Bold={1},Italic={2},Underline={3}", ce.GetFont().ToString().Replace("[Font: Name=", "").Replace("]", "").Replace(", ", ","), ce.GetFont().Bold, ce.GetFont().Italic, ce.GetFont().Underline);
            filedata += "\n--FONT END--";
            filedata += "\n--MISC START--";
            filedata += string.Format("\nqrSize: {0}", winmodern.GetInt("qr_size"));
            if (winmodern.GetString("qr_file").Contains("local:"))
            {
                if (winmodern.GetString("qr_file").Contains("local:0"))
                {
                    filedata += "\nqrType: Default";
                }
                else
                {
                    filedata += "\nqrType: Transparent";
                }
            }
            else
            {
                filedata += "\nqrType: Custom";
            }
            filedata += string.Format("\nqrPath: {0}", winmodern.GetString("qr_file"));
            filedata += "\n--MISC END--\n";
            return filedata;
        }

        /// <summary>
        /// Gets the total number of templates
        /// </summary>
        [JsonIgnore]
        public int Count {
            get { return bluescreens.Count; }
        }

        /// <summary>
        /// Allows you to get and set NT error codes (such as "0x0000000A   IRQL_NOT_LESS_OR_EQUAL").
        /// By default, NTERRORDATABASE.txt from project resources is used.
        /// </summary>
        public string[] NtErrors {
            get {
                if (nt_errors == null)
                {
                    return Properties.Resources.NTERRORDATABASE.Replace("\r\n", "\n").Split('\n');
                }
                return nt_errors;
            }
            set {
                nt_errors = value;
            }
        }

        /// <summary>
        /// Allows you to get and set possible culprit files (such as "CI.dll:Code Integrity Module").
        /// By default, CULPRIT_FILES.txt from project resources is used.
        /// </summary>
        public string[] CulpritFiles {
            get {
                if (culprits == null)
                {
                    return Properties.Resources.CULPRIT_FILES.Replace("\r\n", "\n").Split('\n');
                }
                return culprits;
            }
            set { culprits = value; }
        }

        /// <summary>
        /// Allows you to get and set possible 9x error codes (such as "00  Division fault")
        /// By default, 9xERRORS.TXT from project resources is used.
        /// </summary>
        public string[] NxErrors {
            get {
                return nx_errors;
            }
            set {
                nx_errors = value;
            }
        }

        /// <summary>
        /// Gets and sets all of the configuration templates. You should only use this when saving/loading configurations.
        /// </summary>
        public BlueScreen[] BlueScreens {
            get { return this.bluescreens.ToArray(); }
            set { bluescreens = value.ToList(); }
        }
    }
}
