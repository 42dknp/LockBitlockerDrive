# Lock BitLocker Drive Tool

This tool adds a custom context menu entry to lock BitLocker-encrypted drives directly from File Explorer. The context menu entry will appear only for BitLocker-protected drives that are unlocked.

## Features

- Adds a context menu option to lock BitLocker-encrypted drives.
- Prevents the system drive (`C:`) from being locked.

## Requirements

- **.NET SDK 8.0 or higher** - Required to compile the application.
- **Inno Setup** - Required to compile the installer for distribution.
- **Windows 10/11** - The tool relies on Windows-specific features such as BitLocker and the File Explorer shell extension.
- Requires **administrative privileges** to perform the lock operation.


## Security Notice

For security reasons, the source code is provided without precompiled executables. You are required to compile the application yourself to ensure that the code has not been tampered with and is safe to use.
You can also add the Windows Registry Entries manually and avoid creating the Installer. 

## Setup

### 1. Clone the Repository

First, clone this repository to your local machine:

```bash
git clone https://github.com/42dknp/LockBitlockerDrive.git
cd LockBitlockerDrive
```

### 2. Install .NET SDK

If you don't have the .NET SDK installed, download and install the latest version of the .NET SDK (8.0 or higher) from [here](https://dotnet.microsoft.com/download).

### 3. Install Inno Setup

To create the installer, you'll need Inno Setup. Download and install Inno Setup from [here](https://jrsoftware.org/isinfo.php).

### 4. Compile the Source Code

Once the .NET SDK is installed, you can compile the application by running the following commands inside the `src` folder:

```bash
dotnet restore
dotnet build
```

Or, for a release build, use:

```bash
dotnet publish -c Release
```

This will generate the compiled executable in the `bin/Release/net8.0-windows10.X.XXXXX.X/win-x64/publish` directory ().

### 5. Modify and Build the Installer

You can create an installer for this tool using the provided Inno Setup script (`LockBitLockerDrive.iss`). To compile the installer:

1. Open **Inno Setup**.
2. Load the `LockBitLockerDrive.iss` script file.
3. Modify  
4. Compile the script by pressing **F9** or clicking **Build** > **Compile**.
5. The compiled installer will be generated in the same directory as the script file.

### 6. Customize the Tool

The source code for the application is in the `Program.cs` file, located in the `src` folder. You can modify the tool to suit your needs and recompile the application by following the steps above.

## Usage

After compiling and installing the tool:

1. Right-click on any unlocked BitLocker-encrypted drive in File Explorer.
2. Select **"Lock BitLocker Drive"** from the context menu.
3. The tool will prompt you for confirmation and will lock the selected BitLocker drive if confirmed.

Note that the context menu option will **not** appear for the system drive (`C:`) or drives that are not protected by BitLocker.

## Limitations

- This tool requires **administrative privileges** to run because it interacts with BitLocker via the `manage-bde` command.
- The tool cannot lock the system drive (`C:`) as a precaution to avoid unintended issues.

## Known Issues

The context menu appears currently also for drive C. Since I implemented a prevention mechanism it can’t lock your Drive C anyway.

## License

This project is open-source and licensed under the MIT License. Feel free to modify and distribute it as you see fit.

## Contributing

Feel free to submit issues, fork the repository, and create pull requests to improve the tool.
