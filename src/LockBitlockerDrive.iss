[Setup]
AppName=LockBitLockerDrive
AppVersion=1.0
AppPublisher=Dominic Kneup
DefaultDirName={pf}\LockBitLockerDrive
DefaultGroupName=Lock BitLocker Drive
DisableProgramGroupPage=yes
OutputDir=.
OutputBaseFilename=LockBitLockerDriveSetup
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin

[Files]
; Add your correct Path the the LockBitLockerDrive.exe you compiled with .NET SDK
Source: "Path\to\your\LockBitLockerDrive.exe"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\Lock BitLocker Drive"; Filename: "{app}\LockBitLockerDrive.exe"

[Registry]
; Add context menu entry only for unlocked BitLocker drives, excluding C:\
Root: HKCR; Subkey: "Drive\shell\LockBitLockerDrive"; ValueType: string; ValueName: ""; ValueData: "Lock BitLocker Drive"; Flags: uninsdeletekey
Root: HKCR; Subkey: "Drive\shell\LockBitLockerDrive"; ValueType: string; ValueName: "Icon"; ValueData: "imageres.dll,-078"
Root: HKCR; Subkey: "Drive\shell\LockBitLockerDrive"; ValueType: string; ValueName: "AppliesTo"; ValueData: "System.Volume.BitLockerProtection:=1"
Root: HKCR; Subkey: "Drive\shell\LockBitLockerDrive\command"; ValueType: string; ValueName: ""; ValueData: """{app}\LockBitLockerDrive.exe"" ""%1"""; Flags: uninsdeletekey

[Run]
; Optionally, run the application after installation
; Filename: "{app}\LockBitLockerDrive.exe"; Description: "{cm:LaunchProgram,Lock BitLocker Drive}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Type: filesandordirs; Name: "{app}"