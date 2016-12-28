﻿using IQMediaGroup.Services.CaptureLog.Config.Sections.Mappings;
using System.Configuration;

namespace IQMediaGroup.Services.CaptureLog.Config
{
    public sealed class ConfigSettings
    {
        private const string MAPPING_SECTION = "Mappings";

        /// <summary>
        /// The Singleton instance of the Mappings Configuration Section
        /// </summary>
        public static Mappings Mappings
        {
            get { return ConfigurationManager.GetSection(MAPPING_SECTION) as Mappings; }
        }
    }
}