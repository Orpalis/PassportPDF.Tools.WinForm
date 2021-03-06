﻿/**********************************************************************
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

namespace PassportPDF.Tools.WinForm.Models
{
    public sealed class OperationsStats
    {
        public int ProcessedFileCount { get; set; }

        public int SuccesfullyProcessedFileCount { get; set; }

        public int UnsuccessfullyProcessedFileCount { get; set; }

        public double TotalInputSize { get; set; }

        public double TotalOutputSize { get; set; }

        public double ReductionRatio { get; set; }

        public int FileConvertedToPDFCount { get; set; }
    }
}
