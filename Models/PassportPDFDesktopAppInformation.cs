/**********************************************************************
 * Project:                  PassportPDF.Tools.WinForm
 * Authors:                 - Evan Carrère.
 *                          - Loïc Carrère.
 *
 * (C) Copyright 2018, ORPALIS.
 ** Licensed under the Apache License, Version 2.0 (the "License");
 ** you may not use this file except in compliance with the License.
 ** You may obtain a copy of the License at
 ** http://www.apache.org/licenses/LICENSE-2.0
 ** Unless required by applicable law or agreed to in writing, software
 ** distributed under the License is distributed on an "AS IS" BASIS,
 ** WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 ** See the License for the specific language governing permissions and
 ** limitations under the License.
 *
 **********************************************************************/

using System;
using System.Drawing;

namespace PassportPDF.Tools.WinForm.Models
{
    public sealed class PassportPDFDesktopAppInformation
    {
        public string ProductName { get; }

        public string AppID { get; }

        public string AppExecutableName { get; }

        public string AppSourceCodeUrl { get; }

        public Version AppVersion { get; }

        public Icon AppIcon { get; }

        public Bitmap AppLogo { get; }

        public AcceptedInputFilesType InputFilesType { get; }

        public string ConfigurationFilePath { get; }

        public bool AutoRun { get; }

        public string[] CommandLineArguments { get; }


        public PassportPDFDesktopAppInformation(string productName, string appID, string appExecutableName, string appSourceCodeUrl, Version appVersion, Icon appIcon, Bitmap appLogo, AcceptedInputFilesType acceptedInputFilesType, string configurationFilePath, bool autoRun, string[] commandLineArgs)
        {
            ProductName = productName;
            AppID = appID;
            AppExecutableName = appExecutableName;
            AppSourceCodeUrl = appSourceCodeUrl;
            AppVersion = appVersion;
            AppIcon = appIcon;
            AppLogo = appLogo;
            InputFilesType = acceptedInputFilesType;
            ConfigurationFilePath = configurationFilePath;
            AutoRun = autoRun;
            CommandLineArguments = commandLineArgs;
        }


        public enum AcceptedInputFilesType
        {
            Document,
            Image
        }
    }
}