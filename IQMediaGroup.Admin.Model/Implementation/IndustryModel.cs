﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IQMediaGroup.Admin.Model.Interface;
using IQMediaGroup.Admin.Model.Base;
using System.Data;
using IQMediaGroup.Admin.Core.HelperClasses;

namespace IQMediaGroup.Admin.Model.Implementation
{
    internal class IndustryModel : IQMediaGroupDataLayer, IIndustryModel
    {
        /// <summary>
        /// This method gets Industry information.
        /// Added By: Bhavik Barot
        /// </summary>
        /// <returns>Dataset containig Role information.</returns>
        public DataSet GetIndustryInfo()
        {
            try
            {
                DataSet _DataSet = null;

                List<DataType> _ListOfDataType = new List<DataType>();

                _DataSet = this.GetDataSet("usp_Industry_SelectAll", _ListOfDataType);                

                return _DataSet;
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
        }
    }
}