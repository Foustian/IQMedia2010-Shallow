﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IQMediaGroup.Services.CaptureLog.Config.Sections.Mappings
{
    public class Mappings
    {
        /// <summary>
        /// List of UrlMappings specified in Web.config for mapping
        /// the services URL to the specified command.
        /// </summary>
        public List<UrlMapping> UrlMappings { get; set; }
    }
}