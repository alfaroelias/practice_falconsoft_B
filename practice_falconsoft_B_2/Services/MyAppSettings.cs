using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace practice_falconsoft_B_2.Services
{
    public class MyAppSettings
    {
        public const string SectionName = "MySettings";

        public string FolderPath { get; set; }
        public string UrlSample { get; set; }
    }
}
