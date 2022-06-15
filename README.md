# BlueScreenSimulatorPlus (experimental branch)
Open source code for BSSP. This is an enhanced blue screen simulator application for Windows. Use Visual Studio to recompile.
This is an unfinished code for the next version of blue screen simulator plus.

Codename: *Waffles*, Version 2.0 (development build), {} markus' software // {} markuse tarkvara

The following section contains quick documentation for each file in the project.
  
[ROOT]
	* AboutBox1.cs                     - Help, about and settings
	* AddBluescreen.cs                 - Allows the user to create their own bluescreen configuration
	* BootMgr.cs                       - Windows Boot Manager startup error simulator (Beta)
	* bsodhacks.cs                     - Bluescreen hacks (old beta) [*Unused*]
	* cebsod.cs                        - Windows CE blue screen simulator
	* ChooseFile.cs                    - Culprit file chooser
	* ClickIt.cs                       - Classic Click it game easter egg (enable easter eggs in settings)
	* ClickIt2.cs                      - Click it 2.0 easter egg (trigger classic and click Play 2.0)
	* DictEdit.cs                      - [DEVTOOL] Dictionary Editor
	* Form1.cs                         - Main interface
	* Gen.cs                           - This form is displayed when generating a blue screen
	* IndexForm.cs                     - Code customization interface
	* NTBSOD.cs                        - Windows NT blue screen simulator
	* old_bluescreen.cs                - Windows 3.1x/9x/Me blue screen simulator
	* PrankMode.cs                     - Prank mode interface
	* SimulatorDatabase.cs             - A namespace with a blue screen class, which gets used by other parts of the program
	* Splash.cs                        - Splash screen interface
	* StringEdit.cs                    - Blue screen hacks (new)
	* SupportEditor.cs                 - Windows XP/Vista/7 blue screen support text modification interface (old beta)
	* UpdateInterface.cs               - Interface for update download and installation
	* w2kbs.cs                         - Windows 2000 blue screen simulator
	* win.cs                           - Windows 1.x/2.x blue screen simulator
	* WindowScreen.cs                  - This form is displayed when fullscreen flag is set on non-modern blue screens
	* WXBS.cs                          - Modern Windows blue screen simulator
	* Vistabs.cs                       - Windows Vista/7 blue screen simulator
	* xvsbs.cs                         - Windows XP blue screen simulator
	* *.Designer.cs                    - Form interface designs (generated using Visual Studio's designer)
	* *.resx                           - Resource identification (auto-generated)
	* app.config                       - Application configuration [*Unused*]
	* bsodgen_npJ_icon.ico             - Blue screen simulator plus icon
	* Program.cs                       - Program initialization code

bin\Release
	* default.bscfg                    - Default blue screen hack configuration file
	* final.bat                        - Update finalization script
	* UltimateBlueScreenSimulator.exe  - Compiled executable
	* UltimateBlueScreenSimulator.pdb  - Program debug database (contains essential things for debugging purposes, such as variable names, break points, etc)

 Resources
	 * bsodbanner.png                   - Banner for about dialog
	 * bsodqr.bmp                       - QR code for Widnows 10 blue screen
	 * bsodqr_transparent.png           - Transparent QR code for Windows 10 blue screen
	 * CULPRIT_FILES.txt                - Contains culprit files, which the user can choose to display on the error screen
	 * current.gif                      - Symbol for currently processing step in update interface
	 * current1.gif                     - Same as current.gif [*Unused*]
	 * doscii.png                       - Character set used by Windows 1.x/2.x blue screen simulator
	 * dummy.png                        - Dummy image for Windows 1.x/2.x blue screen simulator
	 * failure.gif                      - Symbol for failed step in update interface
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
 
 Properties
	 * AssemblyInfo.cs                  - Assembly information for the application (e.g. title, company, version, etc) (auto-generated)
	 * Resources.resx                   - Resource identification (auto-generated)
	 * Settings.settings                - Settings [*Unused*] (auto-generated)
	 
System\Windows\Forms
	 * AliasedLabel.cs                  - A custom control that is used in Windows XP and CE blue screens

TEST