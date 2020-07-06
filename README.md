# BlueScreenSimulatorPlus
Open source code for BSSP. This is an enhanced blue screen simulator application for Windows. Use Visual Studio to recompile.

Codename: BlueSmith, Version 1.01, {} markus' software // {} markuse tarkvara

The following section contains quick documentation for each file in the project.
  
[ROOT]
* Program.cs            - Program initialization code
* AboutBox1.cs          - Help, about and settings
* bsodhacks.cs          - Bluescreen hacks (old beta) [Unused]
* cebsod.cs             - Windows CE blue screen simulator
* ClickIt.cs            - Classic Click it game easter egg (enable easter eggs in settings)
* ClickIt2.cs           - Click it 2.0 easter egg (trigger classic and click Play 2.0)
* Form1.cs              - Main interface
* IndexForm.cs          - Code customization interface
* NTBSOD.cs             - Windows NT blue screen simulator
* old_bluescreen.cs     - Windows 3.1x/9x/Me blue screen simulator
* PrankMode.cs          - Prank mode interface
* Splash.cs             - Splash screen interface
* StringEdit.cs         - Blue screen hacks (new)
* SupportEditor.cs      - Windows XP/Vista/7 blue screen support text modification interface (old beta)
* UpdateInterface.cs    - Interface for update download and installation
* w2kbs.cs              - Windows 2000 blue screen simulator
* WindowScreen.cs       - This form is displayed when fullscreen flag is set on non-modern blue screens
* WXBS.cs               - Modern Windows blue screen simulator
* xvsbs.cs              - Windows XP/Vista/7 blue screen simulator
* *.Designer.cs         - Form interface designs (generated using Visual Studio's designer)
* *.resx                - Resource identification (auto-generated)
* app.config            - Application configuration [Unused]
* bsodgen_npJ_icon.ico  - Blue screen simulator plus icon

 Resources
* bsodbanner.png         - Banner for about dialog
* bsodqr.bmp             - QR code for Widnows 10 blue screen
* bsodqr_transparent.png - Transparent QR code for Windows 10 blue screen
* current.gif            - Symbol for currently processing step in update interface
* current1.gif           - Same as current.gif [*Unused*]
* failure.gif            - Symbol for failed step in update interface
* msoftware.png          - Markus' software logo for about dialog
* NTERRORDATABASE.txt    - Contains all Windows NT error codes with their descriptions (code   description)
* pending.gif            - Symbol for pending step in update interface
* rasterNT.bmp           - Windows NT blue screen character set
* rasters.bmp            - Old character set for old blue screens [Unused]
* rasters2.bmp           - CGA character set for old blue screens
* success.bmp            - Symbol for successfully complited step in update interface
* verifile.bmp           - Verifile logo for about dialog
 
 Properties
* AssemblyInfo.cs        - Assembly information for the application (e.g. title, company, version, etc) (auto-generated)
* Resources.resx         - Resource identification (auto-generated)
* Settings.settings      - Settings [Unused] (auto-generated)
