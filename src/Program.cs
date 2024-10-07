using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace LockBitLockerDrive
{
    class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// Validates input and ensures the system drive is not locked.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!ValidateInput(args)) return;

            string driveLetter = ExtractDriveLetter(args[0]);

            if (!IsValidDriveLetter(driveLetter))
            {
                ShowErrorMessage($"Invalid drive letter: {driveLetter}");
                return;
            }

            if (IsSystemDrive(driveLetter))
            {
                ShowErrorMessage("Locking the system drive (C:\\) is not allowed.");
                return;
            }

            ConfirmAndLockDrive(driveLetter);
        }

        /// <summary>
        /// Validates that the input contains a drive letter.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>True if valid input is provided, false otherwise.</returns>
        private static bool ValidateInput(string[] args)
        {
            if (args.Length == 0)
            {
                ShowErrorMessage("No drive letter provided.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Extracts the drive letter from the provided path.
        /// </summary>
        /// <param name="drivePath">The full drive path.</param>
        /// <returns>The drive letter as a string.</returns>
        private static string ExtractDriveLetter(string drivePath)
        {
            return drivePath.TrimEnd('\\').Substring(0, 1).ToUpperInvariant();
        }

        /// <summary>
        /// Checks if the extracted drive letter is valid on the system.
        /// </summary>
        /// <param name="driveLetter">The drive letter to validate.</param>
        /// <returns>True if the drive letter is valid, false otherwise.</returns>
        private static bool IsValidDriveLetter(string driveLetter)
        {
            return Directory.GetLogicalDrives().Any(drive => drive.StartsWith(driveLetter, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Checks if the drive letter corresponds to the system drive (C:).
        /// </summary>
        /// <param name="driveLetter">The drive letter to check.</param>
        /// <returns>True if it is the system drive, false otherwise.</returns>
        private static bool IsSystemDrive(string driveLetter)
        {
            return driveLetter == "C";
        }

        /// <summary>
        /// Displays an error message to the user.
        /// </summary>
        /// <param name="message">The message to display.</param>
        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Confirms with the user if they want to lock the specified drive.
        /// If confirmed, locks the drive.
        /// </summary>
        /// <param name="driveLetter">The drive letter to lock.</param>
        private static void ConfirmAndLockDrive(string driveLetter)
        {
            var result = MessageBox.Show($"Are you sure you want to lock BitLocker drive {driveLetter}:?", "Confirm Lock", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
                StartProcessToLockDrive(driveLetter);
        }

        /// <summary>
        /// Starts the process to lock the specified BitLocker drive using the manage-bde.exe tool.
        /// </summary>
        /// <param name="driveLetter">The drive letter to lock.</param>
        private static void StartProcessToLockDrive(string driveLetter)
        {
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "manage-bde.exe",
                        Arguments = $"-lock {driveLetter}: -ForceDismount",
                        Verb = "runas",
                        UseShellExecute = true
                    }
                };
                process.Start();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Failed to lock the drive: {ex.Message}");
            }
        }
    }
}
