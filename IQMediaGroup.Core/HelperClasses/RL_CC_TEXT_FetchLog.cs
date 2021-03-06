﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQMediaGroup.Core.HelperClasses
{
    /// <summary>
    /// Contains Request URL With Start Time And End Time
    /// </summary>
    public class RL_CC_TEXT_FetchLog
    {
        /// <summary>
        /// Represents Start Time Of The Request
        /// </summary>
        public string Startdatetimestamp { get; set; }


        public string CCTextFileName { get; set; }

        /// <summary>
        /// Represents RL_Stations_Exception
        /// </summary>
        public string RL_Stations_Exception{ get; set; }

        /// <summary>
        /// Represents Databasereadorwritefailure
        /// </summary>
        public string Databasereadorwritefailure { get; set; }

        /// <summary>
        /// Represents End Time Of The Request
        /// </summary>
        public string Enddatetimestamp { get; set; }

    }
}
