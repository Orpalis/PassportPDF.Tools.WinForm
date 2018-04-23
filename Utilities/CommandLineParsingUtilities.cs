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


using System.IO;
using PassportPDF.Model;
using PassportPDF.Tools.Framework.Configuration;
using PassportPDF.Tools.Framework;

namespace PassportPDF.Tools.WinForm.Utilities
{
    public static class CommandLineParsingUtilities
    {
        public static void ParseCommandLineArgs(string[] args, ApplicationConfiguration applicationConfiguration, ReduceActionConfiguration reduceActionConfiguration = null, OCRActionConfiguration ocrActionConfiguration = null)
        {
            for (int index = 0; index < args.Length; index++)
            {
                if (!ParseApplicationConfigurationArgument(args, index, applicationConfiguration))
                {
                    if (reduceActionConfiguration != null)
                    {
                        ParseReduceActionConfigurationArgument(args, index, reduceActionConfiguration);
                    }
                    if (ocrActionConfiguration != null)
                    {
                        ParseOCRActionConfigurationArgument(args, index, ocrActionConfiguration);
                    }
                }
            }
        }


        private static bool ParseApplicationConfigurationArgument(string[] args, int index, ApplicationConfiguration applicationConfiguration)
        {
            switch (args[index].ToUpper())
            {
                case "/MIN": //start application with minimized window state
                    applicationConfiguration.MinimizedWindow = true;
                    break;

                case "/P": //input folder is the next parameter
                    if (args.Length > index + 1)
                    {
                        applicationConfiguration.InputPath = args[index + 1].Trim();
                    }
                    break;

                case "/F": //input files is the next parameter
                    if (args.Length > index + 1)
                    {
                        applicationConfiguration.InputPath = args[index + 1].Trim();
                    }
                    break;

                case "/IF": //input formats is the next parameters
                    if (args.Length > index + 1)
                    {
                        string inputFormats = args[index + 1].Trim().ToUpper();
                        applicationConfiguration.InputFileFormats = inputFormats;
                    }
                    break;

                case "/D": //destination folder is the next parameter
                    if (args.Length > index + 1)
                    {
                        string folder = args[index + 1].Trim();
                        if (Directory.Exists(folder))
                        {
                            applicationConfiguration.OutputPath = folder;
                        }
                    }
                    break;

                case "/LOGS": //log file is the next parameter
                    if (args.Length > index + 1)
                    {
                        applicationConfiguration.LogsPath = args[index + 1].Trim();
                        applicationConfiguration.ExportLogs = true;
                    }
                    break;

                case "/T": //number of threads is the next parameter
                    if (args.Length > index + 1)
                    {
                        if (int.TryParse(args[index + 1], out int threads))
                        {
                            if (threads > 0 && threads <= FrameworkGlobals.PassportPDFConfiguration.SuggestedMaxClientThreads)
                            {
                                applicationConfiguration.ThreadCount = threads;
                            }
                        }
                    }
                    break;

                case "/NS": //don't process subfolders
                    applicationConfiguration.ProcessSubFolders = false;
                    break;

                case "/DW": //disable warning when input and output folder are the same
                    applicationConfiguration.WarnWhenSameInputOutputDirectory = false;
                    break;

                case "/KT": //keep last access and edition time
                    applicationConfiguration.FileProductionRules.KeepWriteAndAccessTime = true;
                    break;

                case "/DO": //delete original file on reduction success:
                    applicationConfiguration.FileProductionRules.DeleteOriginalFileOnSuccess = true;
                    break;

                default:
                    return false;
            }

            return true;
        }


        private static void ParseReduceActionConfigurationArgument(string[] args, int index, ReduceActionConfiguration reduceActionConfiguration)
        {
            switch (args[index].ToString())
            {
                case "/DC": //disable the "color detection" option
                    reduceActionConfiguration.EnableColorDetection = false;
                    break;

                case "/CR": //enable the "automatic char repair" option
                    reduceActionConfiguration.EnableCharRepair = true;
                    break;

                case "/DR": //disable the "recompress images" option
                    reduceActionConfiguration.RecompressImages = false;
                    break;

                case "/DU": //disable the "discard unused objects" option
                    reduceActionConfiguration.PackDocument = false;
                    break;

                case "/DD": //disable the "downscale images" option
                    reduceActionConfiguration.DownscaleImages = false;
                    break;

                case "/Q": //image quality
                    if (args.Length > index + 1)
                    {
                        int quality;
                        if (int.TryParse(args[index + 1], out quality))
                        {
                            if (quality >= (int)PDFReduceParameters.ImageQualityEnum.ImageQualityLow && quality <= (int)PDFReduceParameters.ImageQualityEnum.ImageQualityVeryHigh)
                            {
                                reduceActionConfiguration.ImageQuality = (PDFReduceParameters.ImageQualityEnum)quality;
                            }
                        }
                    }
                    break;

                case "/R": //downscale resolution
                    if (args.Length > index + 1)
                    {
                        int resolution;
                        if (int.TryParse(args[index + 1], out resolution))
                        {
                            if (resolution > 0)
                            {
                                reduceActionConfiguration.DownscaleResolution = resolution;
                            }
                        }
                    }
                    break;

                case "/DJ2K": //disable the "JPEG 2000 compression" option
                    reduceActionConfiguration.EnableJPEG2000 = false;
                    break;

                case "/DJ2": //disable the "JBIG2 compression" option:
                    reduceActionConfiguration.EnableJBIG2 = false;
                    break;

                case "/RF": //remove formfields
                    reduceActionConfiguration.RemoveFormFields = true;
                    break;

                case "/RA": //remove annotations
                    reduceActionConfiguration.RemoveAnnotations = true;
                    break;

                case "/RH": //remove hyperlinks
                    reduceActionConfiguration.RemoveHyperlinks = true;
                    break;

                case "/RB": //remove bookmarks
                    reduceActionConfiguration.RemoveBookmarks = true;
                    break;

                case "/RBP": //remove blank pages
                    reduceActionConfiguration.RemoveBlankPages = true;
                    break;

                case "/RE": //remove embedded files
                    reduceActionConfiguration.RemoveEmbeddedFiles = true;
                    break;

                case "/RJ": // remove JavaScript 
                    reduceActionConfiguration.RemoveJavaScript = true;
                    break;

                case "/LINEARIZED": //enable fast web view
                    reduceActionConfiguration.FastWebView = true;
                    break;

                case "/MRC": //enable MRC
                    reduceActionConfiguration.EnableMRC = true;
                    break;
            }
        }


        private static void ParseOCRActionConfigurationArgument(string[] args, int index, OCRActionConfiguration ocrActionConfiguration)
        {
            switch (args[index].ToUpper())
            {
                case "/L": //language is the next parameter
                    if (args.Length > index + 1)
                    {
                        ocrActionConfiguration.OCRLanguage = args[index + 1].Trim();
                    }
                    break;

                case "/SKIPPAGESWITHTEXT":
                    ocrActionConfiguration.SkipPagesWithText = true;
                    break;
            }
        }
    }
}