; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Write"
#define MyAppVersion "1.0"
#define MyAppPublisher "Michael Wang"
#define MyAppURL "http://michaelwangssite.dx.am/files/write"
#define MyAppExeName "Write.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{E60AF117-8630-4D70-AC32-9641C19CC8B0}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputDir=C:\Users\Michael\Documents\Visual Studio 2015\Projects\Write\Write\bin\Release
OutputBaseFilename=WriteSetup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "C:\Users\Michael\Documents\Visual Studio 2015\Projects\Write\Write\bin\Release\Write.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Michael\Documents\Visual Studio 2015\Projects\Write\Write\bin\Release\Dictionary\*"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Michael\Documents\Visual Studio 2015\Projects\Write\Write\bin\Release\Documentation\*"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\Michael\Documents\Visual Studio 2015\Projects\Write\Write\bin\Release\Images\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
