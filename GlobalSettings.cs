using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ms = MaterialSkin;
using System.Text.Json;
using System.Text.Json.Serialization; // alias to ms to avoid conflict with ColorScheme

namespace UltimateBlueScreenSimulator
{
    public class GlobalSettings
    {
        /*
         * // Example usage
         * GlobalSettings gs = new GlobalSettings();
         * gs.EnableEggs = true; // set value
         * 
         * if (gs.EnableEggs) {  // get value
         *  MessageBox.Show("I stored a setting!");
         * }
         */

        // stored settings (these are saved)
        private bool postponeupdate;
        private bool hashverify;
        private bool autoupdate;
        private bool showcursor;
        private bool enableeggs;
        private bool randomness;
        private bool autodark;
        private string singlesim;
        private string update_server;
        private bool quickhelp;
        private bool autosave;

        // runtime settings (these are not persistent)
        [JsonIgnore]
        private int errorcode;

        [JsonIgnore]
        private bool realpostpone;

        [JsonIgnore]
        private bool nighttheme;

        [JsonIgnore]
        private string supporttext;

        [JsonIgnore]
        private bool displayone;

        // prank mode
        private MessageBoxIcon MsgBoxIcon;
        private MessageBoxButtons MsgBoxType;
        private string MsgBoxTitle;
        private string MsgBoxMessage;
        private string appname;
        private bool lockout;
        private bool closecuzhidden;
        private bool showmsg;
        private string[] usb_device;
        private int[] time;
        private bool timecatch;
        private bool devmode;

        [JsonIgnore]
        public List<string> log1;


        ///<summary>
        ///Multi-monitor display method for fullscreen mode.
        ///</summary>
        public DisplayModes DisplayModeEnum { get; set; }

        ///<summary>
        ///Scaling mode for legacy OS templates, i.e. Windows 7 and earlier.
        ///</summary>
        public ScaleModes ScaleMode { get; set; }

        ///<summary>
        ///Accent color used by the application
        ///</summary>
        public ColorSchemes ColorScheme { get; set; }

        ///<summary>
        ///Accent color used by the application
        ///</summary>
        public ColorSchemes PrimaryColor { get; set; }

        // define enums
        public enum DisplayModes
        {
            None,
            Blank,
            Mirror,
            Freeze
        }

        public enum ColorSchemes
        {
            Amber, Blue, Cyan, DeepOrange, DeepPurple,
            Green, Indigo, LightBlue, LightGreen, Lime,
            Orange, Pink, Purple, Red, Teal, Yellow
        }

        public enum ScaleModes
        {
            HighQualityBicubic,
            HighQualityBilinear,
            Bilinear,
            Bicubic,
            NearestNeighbour
        }

        ///<summary>
        ///Settings stored by the application, no initialization parameters required
        ///</summary>
        public GlobalSettings()
        {
            postponeupdate = false;
            autoupdate = true;
            hashverify = true;
            showcursor = false;
            enableeggs = true;
            randomness = false;
            autodark = true;
            devmode = false;
            quickhelp = true;
            autosave = true;
            singlesim = "";
            update_server = "http://markustegelane.eu/app/";

            // runtime settings (these are not persistent)
            errorcode = 0;
            realpostpone = false;
            nighttheme = false;
            supporttext = "If this is the first time you've seen this Stop error screen,\nrestart your computer. If this screen appears again, follow\nthese steps:\n\nCheck to make sure any new hardware or software is properly installed.\nIf this is a new installation, ask your hardware or software manufacturer\nfor any Windows updates you might need.\n\nIf problems continue, disable or remove any newly installed hardware\nor software. Disable BIOS memory options such as caching or shadowing.\nIf you need to use Safe mode to remove or disable components, restart\nyour computer, press F8 to select Advanced Startup Options, and then\nselect Safe Mode.";
            displayone = false;

            // prank mode
            time = new int[]{ 0, 5, 0 };
            timecatch = true;

            log1 = new List<string>();
            Log("Info", "Log started");

            DisplayModeEnum = DisplayModes.None;
            ScaleMode = ScaleModes.HighQualityBicubic;
            ColorScheme = ColorSchemes.Blue;
            PrimaryColor = ColorSchemes.Indigo;
        }

        ///<summary>
        ///Installs updates only when the application is closed
        ///</summary>
        public bool PostponeUpdate {
            get { return postponeupdate; }
            set { postponeupdate = value; }
        }


        ///<summary>
        ///Automatically checks for updates
        ///</summary>
        public bool AutoUpdate {
            get { return autoupdate; }
            set { autoupdate = value; }
        }

        ///<summary>
        ///Checks the hash of the executable and any dependencies when downloading updates
        ///</summary>
        public bool HashVerify {
            get { return hashverify; }
            set { hashverify = value; }
        }

        ///<summary>
        ///Checks the hash of the executable and any dependencies when downloading updates
        ///</summary>
        [JsonIgnore]
        public string SupportText {
            get { return supporttext; }
            set { supporttext= value; }
        }

        ///<summary>
        ///Shows the cursor during simulation
        ///</summary>
        public bool ShowCursor {
            get { return showcursor; }
            set { showcursor = value; }
        }

        ///<summary>
        ///Toggles easter eggs
        ///</summary>
        public bool EnableEggs {
            get { return enableeggs; }
            set { enableeggs = value; }
        }

        ///<summary>
        ///Toggles whether or not to add randomness to legacy configurations loaded from an old bs2cfg or bscfg file
        ///</summary>
        public bool Randomness {
            get { return randomness; }
            set { randomness = value; }
        }

        ///<summary>
        ///Selected update server, where the updates are downloaded from
        ///</summary>
        public string UpdateServer {
            get { return update_server; }
            set { update_server = value; }
        }

        ///<summary>
        ///Toggles Windows dark mode detection
        ///</summary>
        public bool AutoDark {
            get { return autodark; }
            set { autodark = value; }
        }

        /// <summary>
        /// Toggles autosave/load feature
        /// </summary>
        public bool Autosave {
            get { return autosave; }
            set { autosave = value; }
        }

        /// <summary>
        /// Toggles tooltips
        /// </summary>
        public bool QuickHelp {
            get { return quickhelp; }
            set { quickhelp = value; }
        }

        ///<summary>
        ///This value allows for selecting a configuration through command line arguments
        ///</summary>
        [JsonIgnore]
        public bool DisplayOne {
            get { return displayone; }
            set { displayone = value; }
        }


        ///<summary>
        ///Sets the error code for current session
        ///</summary>
        [JsonIgnore]
        public int ErrorCode {
            get { return errorcode; }
            set { errorcode = value; }
        }

        ///<summary>
        ///Icon for the message box that may pop up after prank mode ends
        ///</summary>
        [JsonIgnore]
        public MessageBoxIcon PM_MsgIcon {
            get { return MsgBoxIcon; }
            set { MsgBoxIcon = value; }
        }

        ///<summary>
        ///Button layout for the message box that may pop up after prank mode ends
        ///</summary>
        [JsonIgnore]
        public MessageBoxButtons PM_MsgType {
            get { return MsgBoxType; }
            set { MsgBoxType = value; }
        }

        ///<summary>
        ///Title for the message box that may pop up after prank mode ends
        ///</summary>
        [JsonIgnore]
        public string PM_MsgTitle {
            get { return MsgBoxTitle; }
            set { MsgBoxTitle = value; }
        }

        ///<summary>
        ///Text content for the message box that may pop up after prank mode ends
        ///</summary>
        [JsonIgnore]
        public string PM_MsgText {
            get { return MsgBoxMessage; }
            set { MsgBoxMessage = value; }
        }

        ///<summary>
        ///Prevent ending the simulation by pressing Alt+F4 or any other key
        ///</summary>
        [JsonIgnore]
        public bool PM_Lockout {
            get { return lockout; }
            set { lockout = value; }
        }

        ///<summary>
        ///Prevents re-showing the main interface when exiting prank mode
        ///</summary>
        [JsonIgnore]
        public bool PM_CloseMainUI {
            get { return closecuzhidden; }
            set { closecuzhidden = value; }
        }

        ///<summary>
        ///Displays a message when exiting prank mode
        ///</summary>
        [JsonIgnore]
        public bool PM_ShowMessage {
            get { return showmsg; }
            set { showmsg = value; }
        }


        ///<summary>
        ///Specifies which process triggers prank mode (if process trigger is selected)
        ///</summary>
        [JsonIgnore]
        public string PM_AppName {
            get { return appname; }
            set { appname = value; }
        }

        ///<summary>
        ///Specifies which USB device triggers prank mode (if device trigger is selected)
        ///</summary>
        [JsonIgnore]
        public string[] PM_UsbDevice {
            get { return usb_device; }
            set { usb_device = value; }
        }

        ///<summary>
        ///Specifies the timer, which triggers prank mode (if time based trigger is selected) in [hours, minutes, seconds] format
        ///</summary>
        [JsonIgnore]
        public int[] PM_Time {
            get { return time; }
            set { time = value; }
        }

        ///<summary>
        ///Determines whether or not the trigger is time based. Device based trigger is only used if the length of PM_UsbDevice is greater than zero, otherwise application based trigger is used.
        ///</summary>
        [JsonIgnore]
        public bool PM_Timecatch {
            get { return timecatch; }
            set { timecatch = value; }
        }

        ///<summary>
        ///Starts the update process after exiting the program
        ///</summary>
        [JsonIgnore]
        public bool UpdateAfterExit {
            get { return realpostpone; }
            set { realpostpone = value; }
        }

        ///<summary>
        ///Determines if the interface should have a night theme or not
        ///</summary>
        [JsonIgnore]
        public bool NightTheme {
            get { return nighttheme; }
            set { nighttheme = value; }
        }

        ///<summary>
        ///Allows the program to be run as a single simulator based on the specified OS template (e.g. Windows Vista, Windows 10, etc.)
        ///</summary>
        [JsonIgnore]
        public string SingleSim {
            get { return singlesim; }
            set { singlesim = value; }
        }

        ///<summary>
        ///Unlocks certain developer only features, such as DictEdit, Restart application, etc. Also throws exceptions rather than catching them.
        ///</summary>
        [JsonIgnore]
        public bool DevBuild {
            get { return devmode; }
            set { devmode = value; }
        }


        ///<summary>
        ///Saves application configuration settings
        ///</summary>
        public void SaveSettings()
        {
            Log("Info", "Saving settings");
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
                };
                string jsonString = JsonSerializer.Serialize(this, options);
                File.WriteAllText(Program.prefix + "settings.json", jsonString);
            }
            catch (DllNotFoundException)
            {
                Program.DllError();
                return;
            }
            catch (IOException)
            {
                Program.DllError();
                return;
            } catch (Exception ex)
            {
                if (MessageBox.Show($"Unable to save settings! Reason: {ex.Message}\r\n{ex.StackTrace}", "Blue screen simulator plus", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    SaveSettings();
                } else
                {
                    return;
                }
            }
        }

        ///<summary>
        ///Loads application configuration settings
        ///</summary>
        public GlobalSettings LoadSettings()
        {
            if (!Directory.Exists(Program.prefix))
            {
                Directory.CreateDirectory(Program.prefix);
            }
            if (File.Exists(Program.prefix + "settings.json"))
            {
                GlobalSettings settings = new GlobalSettings();
                this.Log("Info", $"Loading settings from JSON file");
                try
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                    }
                    };
                    settings = JsonSerializer.Deserialize<GlobalSettings>(File.ReadAllText(Program.prefix + "settings.json"), options);
                    if (File.Exists(Program.prefix + "settings.cfg"))
                    {
                        File.Delete(Program.prefix + "settings.cfg");
                    }
                }
                catch (DllNotFoundException)
                {
                    Program.DllError();
                    return this;
                }
                catch (IOException)
                {
                    Program.DllError();
                    return this;
                }
                return settings;
            } else if (File.Exists("settings.cfg"))
            {
                this.Log("Info", $"Loading settings from legacy configuration file");
                string[] fc = File.ReadAllText("settings.cfg").Split('\n');
                foreach (string element in fc)
                {
                    //Other configurations
                    if (element.StartsWith("UpdateClose="))
                    {
                        PostponeUpdate = Convert.ToBoolean(element.Replace("UpdateClose=", ""));
                    }
                    else if (element.StartsWith("HashVerify="))
                    {
                        HashVerify = Convert.ToBoolean(element.Replace("HashVerify=", ""));
                    }
                    else if (element.StartsWith("AutoUpdate="))
                    {
                        AutoUpdate = Convert.ToBoolean(element.Replace("AutoUpdate=", ""));
                    }
                    else if (element.StartsWith("ShowCursor="))
                    {
                        ShowCursor = Convert.ToBoolean(element.Replace("ShowCursor=", ""));
                    }
                    else if (element.StartsWith("MultiMode="))
                    {
                        DisplayMode = element.Replace("MultiMode=", "");
                    }
                    else if (element.StartsWith("Seecrets="))
                    {
                        EnableEggs = Convert.ToBoolean(element.Replace("Seecrets=", ""));
                    }
                    else if (element.StartsWith("ScaleMode="))
                    {
                        SetScalingFromString(element.Replace("ScaleMode=", ""));
                    }
                    else if (element.StartsWith("Server="))
                    {
                        UpdateServer = element.Replace("Server=", "");
                    }
                    else if (element.StartsWith("Randomness="))
                    {
                        Randomness = Convert.ToBoolean(element.Replace("Randomness=", ""));
                    }
                    else if (element.StartsWith("AutoDark="))
                    {
                        AutoDark = Convert.ToBoolean(element.Replace("AutoDark=", ""));
                    }
                    // this skips checking hidden/visible OS-s
                    // this is a feature that was exclusive to 1.x
                    else if (element.Contains("\""))
                    {
                        break;
                    }
                }
            } else
            {
                this.Log("Warning", "Settings file does not exist, using defaults");
            }
            return this;
        }

        ///<summary>
        ///Returns current scale mode as a string (e.g. ScaleModes.Bilinear would return "Bilinear" etc.)
        ///</summary>
        private string GetScaleModeAsString()
        {
            this.Log("Info", $"Requested scale mode as string");
            switch (this.ScaleMode)
            {
                case ScaleModes.HighQualityBicubic:
                    return "HighQualityBicubic";
                case ScaleModes.HighQualityBilinear:
                    return "HighQualityBilinear";
                case ScaleModes.Bicubic:
                    return "Bicubic";
                case ScaleModes.Bilinear:
                    return "Bilinear";
                case ScaleModes.NearestNeighbour:
                    return "NearestNeighbour";
                default:
                    throw new NotImplementedException();
            }
        }

        ///<summary>
        ///Converts current interpolation mode to System.Drawing.Drawing2D.InterpolationMode. This should be used when setting scaling mode for System.Drawing.Graphics (to avoid a bunch of unnecessary conditional statements).
        ///</summary>
        public System.Drawing.Drawing2D.InterpolationMode GetInterpolationMode()
        {
            this.Log("Info", $"Requested interpolation mode");
            switch (ScaleMode)
            {
                case ScaleModes.HighQualityBicubic:
                    return System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                case ScaleModes.HighQualityBilinear:
                    return System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
                case ScaleModes.Bilinear:
                    return System.Drawing.Drawing2D.InterpolationMode.Bilinear;
                case ScaleModes.Bicubic:
                    return System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                case ScaleModes.NearestNeighbour:
                    return System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                default:
                    throw new NotImplementedException();
            }
        }

        ///<summary>
        ///Sets current scaling mode based on a string. Please note that passing an invalid value will throw NotImplementedException.
        ///</summary>
        private void SetScalingFromString(string algorithm)
        {
            this.Log("Info", $"Changed scaling mode to {algorithm}");
            switch (algorithm)
            {
                case "HighQualityBicubic":
                    ScaleMode = ScaleModes.HighQualityBicubic;
                    break;
                case "HighQualityBilinear":
                    ScaleMode = ScaleModes.HighQualityBilinear;
                    break;
                case "Bicubic":
                    ScaleMode = ScaleModes.Bicubic;
                    break;
                case "Bilinear":
                    ScaleMode = ScaleModes.Bilinear;
                    break;
                case "NearestNeighbour":
                    ScaleMode = ScaleModes.NearestNeighbour;
                    break;
            }
        }

        ///<summary>
        ///Multi-monitor display method (string input/output). The value must be one of the following: none, mirror, blank or freeze, in any other case NotImplementedException is thrown.
        ///</summary>
        [JsonIgnore]
        public string DisplayMode {
            get {
                this.Log("Info", "Requested display mode");
                switch (DisplayModeEnum)
                {
                    case DisplayModes.None:
                        return "none";
                    case DisplayModes.Mirror:
                        return "mirror";
                    case DisplayModes.Blank:
                        return "blank";
                    case DisplayModes.Freeze:
                        return "freeze";
                    default:
                        throw new NotImplementedException();
                }
            }
            set {
                this.Log("Info", $"Changed display mode to {value}");
                switch (value)
                {
                    case "none":
                        DisplayModeEnum = DisplayModes.None;
                        break;
                    case "mirror":
                        DisplayModeEnum = DisplayModes.Mirror;
                        break;
                    case "blank":
                        DisplayModeEnum = DisplayModes.Blank;
                        break;
                    case "freeze":
                        DisplayModeEnum = DisplayModes.Freeze;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }


        ///<summary>
        ///Creates color scheme from accent color
        ///</summary>
        private ms.ColorScheme MakeScheme(ms.Accent accent, ms.Primary[] primary)
        {
            return new ms.ColorScheme(primary[0], primary[1], primary[2], accent, ms.TextShade.WHITE);
        }

        ///<summary>
        ///Applies accent color
        ///</summary>
        public void ApplyScheme()
        {
            this.Log("Info", $"Applying color scheme {ColorScheme}");
            ms.Primary[] primaryScheme = GetPrimaryColors();
            switch (ColorScheme)
            {
                case ColorSchemes.Indigo:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Indigo700, primaryScheme);
                    break;
                case ColorSchemes.Lime:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Lime700, primaryScheme);
                    break;
                case ColorSchemes.Red:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Red700, primaryScheme);
                    break;
                case ColorSchemes.Pink:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Pink700, primaryScheme);
                    break;
                case ColorSchemes.Orange:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Orange700, primaryScheme);
                    break;
                case ColorSchemes.Amber:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Amber700, primaryScheme);
                    break;
                case ColorSchemes.Blue:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Blue700, primaryScheme);
                    break;
                case ColorSchemes.Cyan:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Cyan700, primaryScheme);
                    break;
                case ColorSchemes.DeepOrange:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.DeepOrange700, primaryScheme);
                    break;
                case ColorSchemes.DeepPurple:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.DeepPurple700, primaryScheme);
                    break;
                case ColorSchemes.Green:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Green700, primaryScheme);
                    break;
                case ColorSchemes.LightBlue:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.LightBlue700, primaryScheme);
                    break;
                case ColorSchemes.LightGreen:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.LightGreen700, primaryScheme);
                    break;
                case ColorSchemes.Purple:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Purple700, primaryScheme);
                    break;
                case ColorSchemes.Teal:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Teal700, primaryScheme);
                    break;
                case ColorSchemes.Yellow:
                    Program.f1.materialSkinManager.ColorScheme = MakeScheme(ms.Accent.Yellow700, primaryScheme);
                    break;
            }
        }

        ///<summary>
        ///Gets primary colors
        ///</summary>
        private ms.Primary[] GetPrimaryColors()
        {
            this.Log("Info", $"Applying primary color {PrimaryColor}");
            switch (PrimaryColor)
            {
                default:
                    return new ms.Primary[] { ms.Primary.Indigo800, ms.Primary.Indigo900, ms.Primary.Indigo400 };
                case ColorSchemes.Lime:
                    return new ms.Primary[] { ms.Primary.Lime800, ms.Primary.Lime900, ms.Primary.Lime400 };
                case ColorSchemes.Red:
                    return new ms.Primary[] { ms.Primary.Red800, ms.Primary.Red900, ms.Primary.Red400 };
                case ColorSchemes.Pink:
                    return new ms.Primary[] { ms.Primary.Pink800, ms.Primary.Pink900, ms.Primary.Pink400 };
                case ColorSchemes.Orange:
                    return new ms.Primary[] { ms.Primary.Orange800, ms.Primary.Orange900, ms.Primary.Orange400 };
                case ColorSchemes.Amber:
                    return new ms.Primary[] { ms.Primary.Amber800, ms.Primary.Amber900, ms.Primary.Amber400 };
                case ColorSchemes.Blue:
                    return new ms.Primary[] { ms.Primary.Blue800, ms.Primary.Blue900, ms.Primary.Blue400 };
                case ColorSchemes.Cyan:
                    return new ms.Primary[] { ms.Primary.Cyan800, ms.Primary.Cyan900, ms.Primary.Cyan400 };
                case ColorSchemes.DeepOrange:
                    return new ms.Primary[] { ms.Primary.DeepOrange800, ms.Primary.DeepOrange900, ms.Primary.DeepOrange400 };
                case ColorSchemes.DeepPurple:
                    return new ms.Primary[] { ms.Primary.DeepPurple800, ms.Primary.DeepPurple900, ms.Primary.DeepPurple400 };
                case ColorSchemes.Green:
                    return new ms.Primary[] { ms.Primary.Green800, ms.Primary.Green900, ms.Primary.Green400 };
                case ColorSchemes.LightBlue:
                    return new ms.Primary[] { ms.Primary.LightBlue800, ms.Primary.LightBlue900, ms.Primary.LightBlue400 };
                case ColorSchemes.LightGreen:
                    return new ms.Primary[] { ms.Primary.LightGreen800, ms.Primary.LightGreen900, ms.Primary.LightGreen400 };
                case ColorSchemes.Purple:
                    return new ms.Primary[] { ms.Primary.Purple800, ms.Primary.Purple900, ms.Primary.Purple400 };
                case ColorSchemes.Teal:
                    return new ms.Primary[] { ms.Primary.Teal800, ms.Primary.Teal900, ms.Primary.Teal400 };
                case ColorSchemes.Yellow:
                    return new ms.Primary[] { ms.Primary.Yellow800, ms.Primary.Yellow900, ms.Primary.Yellow400 };
            }
        }

        ///<summary>
        ///Logs an event
        ///</summary>
        ///<param name="e">Desired event type</param>
        ///<param name="message">Description of the event</param>
        public void Log(string e, string message, string source = "")
        {
            string msg = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + e + " - " + message;
            if (source != "")
            {
                msg += $" @{source}";
            }
            Program.load_message = message;
            log1.Add(msg);
        }

        ///<summary>
        ///Gets all logged events
        ///</summary>
        ///<param name="reverse">Allows the log to be reversed, making the recent events show up first (default behaviour). If you don't want the log to be reverse, set this value to false.</param>
        ///<returns>A string containing all logged events</returns>
        public string GetLog(bool reverse = true)
        {
            if (reverse) { log1.Reverse(); }
            string ret = string.Join("\n", log1.ToArray());
            if (reverse) { log1.Reverse(); }
            return ret;
        }


    }
}
