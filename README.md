# BlueScreenSimulatorPlus (experimental branch)
Open source code for BSSP. This is an enhanced blue screen simulator application for Windows. Use Visual Studio to recompile.

Codename: ModestBlue

Version 3.0

\{ \} markus' software // \{ \} markuse tarkvara

## Downloading the simulator
To download the latest version of simulator, you can use two methods:
* Manual download  - go to the releases section of this repostiory (on the right side of this web page) and download the latest version.
* Automatic update - when launching BlueScreenSimulatorPlus, it should automatically check if new version is available and if it is, then notify the user to download it. The download will happen within the program and after the download is finished, the updated version will be launched automatically.

## End-user documentation
The online documentation for the latest stable release can be found at [markustegelane.eu/bssp/help.pdf](https://markustegelane.eu/bssp/help.pdf).

## Developer documentation
This documentation is contained within the readme and is meant for people who want to modify and further develop/contribute to this repository or just curious nerds.

### Table of contents
* [Global settings](#global-settings)
* [Logging events](#logging-events)
* [Blue screen class](#blue-screen-class)
* [Developer mode](#developer-mode)
* [File structure](#file-structure)
	* [Interfaces](#interfaces)
	* [Legacy interfaces](#legacy-interfaces)
	* [Load screens](#load-screens)
	* [Simulators](#simulators)
	* [Special classes](#special-classes)
	* [Miscellaneous](#miscellaneous)
	* [Runtime](#runtime)
	* [Assets](#assets)
	* [Properties](#properties)
	* [Custom controls](#custom-controls)

### Global settings
Settings can be defined inside the GlobalSettings class. Each setting has a summary, which is displayed if IntelliSense is enabled for your code editor.

Defining a global setting:
```C#
	private bool my_setting = false;

	///<summary>
	///A short summary about what the setting is used for
	///</summary>
	public bool MySetting {
		get { return my_setting; }
		set { my_setting = value; }
	}
```

Enums can be defined like so:
```C#
	///<summary>
	///Type of user for something something
	///</summary>
	public Roles UserType = Roles.Admin;


	public enum Roles
	{
		Admin,
		Restricted,
		Developer
	}
```

To make a setting persistent you may add these lines to SaveSettings method:
```C#
	public void SaveSettings()
	{
		//...
		sb.AppendLine($"MySetting={MySetting}");
		//...
	}
```

### Logging events

You can log events through GlobalSettings class. To add an application-wide log, you may use the following code snippet.

```C#
	Program.gs.Log("Info", "This is a log event!");
```

Which may result in the following log line:
`[2024-06-19 00:00:00] Info - This is a log event!`

Optionally, you can pass the source, which will be appended to the end with an @ symbol, like so:
```C#
	Program.gs.Log("Info", "This is a log event!", "A source");
```

Which may result in the following log line:
`[2024-06-19 00:00:00] Info - This is a log event! @ A source`

Please note that a source should accurately describe where the event was triggered from. An accurate source may be a class name or name of a configuration (if called from SimulatorDatabase)

Logs can be dumped with the GetLog method. There's also an optional "reverse" argument, which if set to false will produce a log, where each event is sorted from oldest to newest, otherwise, for example:

```C#
	string log_dump = Program.gs.GetLog(false);
```

### Blue screen class

You can define a bluescreen using the SimulatorDatabase namespace. Here's an example

```
using SimulatorDatabase;
using System.Drawing;
	
namespace UltimateBlueScreenSimulator {
	static class Program {
		[STAThread]
		public static void Main(string[] args) {
			// initialize BlueScreen object
			BlueScreen me = new BlueScreen("Windows Vista");
			// change font
			me.SetFont("Comic Sans MS", 10.4f, FontStyle.Italic);
			// disable watermark
			me.SetBool("watermark", false);
			// change colors to Yellow on Red
			me.SetTheme(Color.Red, Color.Yellow);
			// display the crash screen
			me.Show();
		}
	}
}

```

Each **BlueScreen** object contains the following dictionaries:

* titles/texts  - Strings, which directly change text on the blue screen and which the user can modify under the additional options menu. The difference between titles and texts is semantic.
* strings       - Strings, which change various aspects of the blue screen, but which can't be directly changed through the additional options dialog.
* codefiles     - NT error codes with files
* bools         - Boolean values, which turn features on/off or change a condition. Generally, these options are changed on the main window by checking/unchecking a checkbox.
* ints          - Integer values, which can be made visible under the additional options menu.
* progression   - Progress tuner keyframes and increments

These dictionaries are available no matter, which OS template you use, however depending on the simulator, they might not be used. To see what kind of values each OS templates use, you may want to have a look at ***SetOSSpecificDefaults*** method and see which values are set under each OS template.

### Developer mode

Developer mode provides certain useful tests and devtools, which aren't normally available on the release version. Depending on the build you clone, the developer mode may already be enabled, however if it isn't, you can follow these steps:

1. Open AboutSettingsDialog.cs in a text editor or IDE
2. Find the DevBuild variable and make sure it's set to true
3. Build and run the application
4. Open the hamburger menu (if you're on new UI) and click on the settings button
5. Go to the simulator settings tab
6. You should now see a bunch of buttons at the top-right of the window with the prefix [DEV] or [TEST]

The following developer options may be available:

* [DEV] Restart application - aborts current session and forcibly reset the application
* [TEST] Gen                - allows you to test blue screen generation interface
* [DEV] New All             - resets all configurations
* [DEV] DictEdit            - allows you to edit dictionaries for the selected configuration during runtime
* [DEV] Splash Screen       - displays the splash screen, which you can close by pressing ESC

***Important***: Developer mode should only be enabled on beta builds. It should be disabled before releasing stable versions.

### File structure

The following section contains quick documentation for each file in the project.

#### Interfaces
* AboutSettingsDialog.cs           - Help, about and settings
* AddBluescreen.cs                 - Allows the user to create their own bluescreen configuration
* ChooseFile.cs                    - Culprit file chooser
* IndexForm.cs                     - Code customization interface
* NewUI.cs                         - Main window interface with new UI
* metaerror.cs                     - BSSP crash screen
* PrankMode.cs                     - Prank mode interface
* ProgressTuner.cs                 - Progress tuner interface
* TextView.cs                      - Text document viewer
* UpdateInterface.cs               - Interface for update download and installation

#### Legacy interfaces
* Main.cs                          - Old layout
* StringEdit.cs                    - Blue screen hacks a.k.a. additional options
* SupportEditor.cs                 - Windows XP/Vista/7 blue screen support text modification interface (old beta)

#### Load screens
* Gen.cs                           - This form is displayed when generating a blue screen
* Splash.cs                        - Splash screen interface

#### Simulators
* BootMgr.cs                       - Windows Boot Manager startup error simulator (Beta)
* cebsod.cs                        - Windows CE blue screen simulator
* JupiterBSOD.cs                   - Windows 8 Beta blue screen simulator
* NTBSOD.cs                        - Windows NT blue screen simulator
* old_bluescreen.cs                - Windows 3.1x/9x/Me blue screen simulator
* vistabs.cs                       - Windows 7 blue screen simulator
* w2kbs.cs                         - Windows 2000 blue screen simulator
* win.cs                           - Windows 1.x/2.x blue screen simulator
* WXBS.cs                          - Modern Windows blue screen simulator
* xvsbs.cs                         - Windows XP/Vista blue screen simulator

#### Special classes
* SimulatorDatabase.cs             - A namespace with a blue screen class, which gets used by other parts of the program
* GlobalSettings.cs				   - A class used for storing/manipulating runtime and permanent settings
* Program.cs                       - Program initialization code

#### Miscellaneous
* DictEdit.cs                      - [DEVTOOL] Quick and Dirty Dictionary Editor
* WindowScreen.cs                  - This form is displayed when fullscreen flag is set on non-modern blue screens
* BTS.cs                           - Displays character sets used by the application
* ClickIt.cs                       - Classic Click it game easter egg (enable easter eggs in settings)
* ClickIt2.cs                      - Click it 2.0 easter egg (trigger classic and click Play 2.0)
* *.Designer.cs                    - Form interface designs (generated using Visual Studio's designer)
* *.resx                           - Resource identification (auto-generated)

#### Runtime
* default.bscfg                    - Default blue screen hack configuration file
* final.bat                        - Update finalization script

#### Assets
* bsodgen_npJ_icon.ico             - Blue screen simulator plus icon
* bsodbanner.png                   - Banner for about dialog
* bsodqr.bmp                       - QR code for Widnows 10 blue screen
* bsodqr_transparent.png           - Transparent QR code for Windows 10 blue screen
* bssp2.ico                        - Blue screen simulator plus icon (version 2)
* bssp3_icon.ico                   - Blue screen simulator plus icon (version 3)
* CULPRIT_FILES.txt                - Contains culprit files, which the user can choose to display on the error screen
* current.gif                      - Symbol for currently processing step in update interface
* current1.gif                     - Same as current.gif [*Unused*]
* doscii.png                       - Character set used by Windows 1.x/2.x blue screen simulator
* dummy.png                        - Dummy image for Windows 1.x/2.x blue screen simulator
* failure.gif                      - Symbol for failed step in update interface
* legacy_template.txt			   - Legacy configuration file template
* msoftware.png                    - Markus' software logo for about dialog
* NTERRORDATABASE.txt              - Contains all Windows NT error codes with their descriptions (code   description)
* pending.gif                      - Symbol for pending step in update interface
* rasterNT.bmp                     - Windows NT blue screen character set
* rasters.bmp                      - Old character set for old blue screens [*Unused*]
* rasters2.bmp                     - CGA character set for old blue screens
* round_corners.png                - Round corners that get displayed on the new splash screen
* success.bmp                      - Symbol for successfully complited step in update interface
* untitled.wav                     - Beep sound
* verifile.bmp                     - Verifile logo for about dialog
* win1splash.bmp                   - Windows 1.01 startup logo (B&W)
* win2splash.bmp                   - Windows 2.03 startup logo (B&W)

#### Properties
* AssemblyInfo.cs                  - Assembly information for the application (e.g. title, company, version, etc) (auto-generated)
* Resources.resx                   - Resource identification (auto-generated)
* Settings.settings                - Settings [*Unused*] (auto-generated)

#### Custom controls
* AliasedLabel.cs                  - A custom control that is used in Windows XP and CE blue screens