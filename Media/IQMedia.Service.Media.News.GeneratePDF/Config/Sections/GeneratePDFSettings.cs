﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQMedia.Service.Media.News.GeneratePDF.Config.Sections
{
    public class GeneratePDFSettings
    {
        public int MaxTimeOut { get; set; }

        public int NoOfTasks { get; set; }

        public int PollInterval { get; set; }

        public int QueueLimit { get; set; }

        public string WkhtmltopdfPath { get; set; }

        public int WkhtmltopdfTimeout { get; set; }

        public int WorkerThreads { get; set; }        

        public string WorkingDirectory { get; set; }      
    }
}