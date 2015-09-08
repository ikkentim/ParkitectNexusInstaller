// ParkitectNexusInstaller
// Copyright 2015 Parkitect, Tim Potze

using CommandLine;

namespace ParkitectNexusInstaller
{
    /// <summary>
    /// Represents a collection of command line options which can be set with the execution of the application.
    /// </summary>
    internal class CommandLineOptions
    {
        /// <summary>
        /// Gets the download URL of an asset file.
        /// </summary>
        [Option('d', "download")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Gets the set-installation-path option value. Should be path to the installation path of the game if set.
        /// </summary>
        [Option("set-installation-path")]
        public string SetInstallationPath { get; set; }
    }
}