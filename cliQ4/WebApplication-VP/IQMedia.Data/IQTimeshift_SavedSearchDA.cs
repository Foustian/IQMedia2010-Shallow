﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IQMedia.Data.Base;
using IQMedia.Model;
using System.Data;

namespace IQMedia.Data
{
    public class IQTimeshift_SavedSearchDA : IDataAccess
    {
        public string InsertTimeshiftSavedSearch(Timeshift_SavedSearchModel timeshift_SavedSearchModel)
        {
            try
            {
                Int32 SavedSearchID = 0;
                List<DataType> dataTypeList = new List<DataType>();
                string SearchTermXml = IQMedia.Shared.Utility.CommonFunctions.SerializeToXml(timeshift_SavedSearchModel.SearchTerm);

                dataTypeList.Add(new DataType("@Title", DbType.String, timeshift_SavedSearchModel.Title, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@SearchTerm", DbType.Xml, SearchTermXml, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@ClientGuid", DbType.Guid, timeshift_SavedSearchModel.ClientGuid, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@CustomerGuid", DbType.Guid, timeshift_SavedSearchModel.CustomerGuid, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@SavedSearchID", DbType.Int32, SavedSearchID, ParameterDirection.Output));

                string _Result = DataAccess.ExecuteNonQuery("usp_v4_IQTimeshift_SavedSearch_Insert", dataTypeList);
                return _Result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public string UpdateTimeshiftSavedSearch(Timeshift_SavedSearchModel timeshift_SavedSearchModel)
        {
            try
            {
                int RowUpdated = 0;
                List<DataType> dataTypeList = new List<DataType>();
                string SearchTermXml = IQMedia.Shared.Utility.CommonFunctions.SerializeToXml(timeshift_SavedSearchModel.SearchTerm);

                dataTypeList.Add(new DataType("@Title", DbType.String, timeshift_SavedSearchModel.Title, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@SavedSearchID", DbType.Int32, timeshift_SavedSearchModel.ID, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@SearchTerm", DbType.Xml, SearchTermXml, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@CustomerGuid", DbType.Guid, timeshift_SavedSearchModel.CustomerGuid, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@RowUpdated", DbType.Int32, RowUpdated, ParameterDirection.Output));
                

                string _Result = DataAccess.ExecuteNonQuery("usp_v4_IQTimeshift_SavedSearch_Update", dataTypeList);
                return _Result;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Timeshift_SavedSearchModel> SelectTimeshiftSavedSearch(Int32? p_PageNumber, Int32 p_Pagesize, Guid p_CustomerGUID, out Int64 totalRecords)
        {
            try
            {
                totalRecords = 0;
                Dictionary<string, string> p_outParameter;
                List<DataType> dataTypeList = new List<DataType>();
                dataTypeList.Add(new DataType("@PageNumber", DbType.String, p_PageNumber, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@PageSize", DbType.String, p_Pagesize, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@CustomerGuid", DbType.Guid, p_CustomerGUID, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@TotalRecords", DbType.Int64, totalRecords, ParameterDirection.Output));
                DataSet dSet = DataAccess.GetDataSetWithOutParam("usp_v4_IQTimeshift_SavedSearch_Select", dataTypeList, out p_outParameter);

                if (p_outParameter != null && p_outParameter.Count > 0)
                {
                    totalRecords = !string.IsNullOrWhiteSpace(p_outParameter["@TotalRecords"]) ? Convert.ToInt32(p_outParameter["@TotalRecords"]) : 0;
                }

                return FillSavedSearch(dSet);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public List<Timeshift_SavedSearchModel> SelectTimeshiftSavedSearchByID(Int64 p_ID, Guid p_CustomerGuid)
        {
            try
            {
                List<DataType> dataTypeList = new List<DataType>();
                dataTypeList.Add(new DataType("@ID", DbType.Int64, p_ID, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@CustomerGuid", DbType.Guid, p_CustomerGuid, ParameterDirection.Input));
                DataSet dSet = DataAccess.GetDataSet("usp_v4_IQTimeshift_SavedSearch_SelectByID", dataTypeList);

                return FillSavedSearch(dSet);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public string DeleteTimeshiftSavedSearchByID(Int64 p_ID, Guid p_CustomerGUID)
        {
            try
            {
                List<DataType> dataTypeList = new List<DataType>();
                dataTypeList.Add(new DataType("@ID", DbType.Int64, p_ID, ParameterDirection.Input));
                dataTypeList.Add(new DataType("@CustomerGuid", DbType.Guid, p_CustomerGUID, ParameterDirection.Input));
                string result = DataAccess.ExecuteNonQuery("usp_v4_IQTimeshift_SavedSearch_Delete", dataTypeList);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected List<Timeshift_SavedSearchModel> FillSavedSearch(DataSet dataSet)
        {

            List<Timeshift_SavedSearchModel> lstTimeshift_SavedSearchModel = new List<Timeshift_SavedSearchModel>();
            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                if (dataSet.Tables[0] != null)
                {

                    DataTable dataTable = dataSet.Tables[0];

                    foreach (DataRow dr in dataSet.Tables[0].Rows)
                    {
                        Timeshift_SavedSearchModel timeshift_SavedSearchModel = new Timeshift_SavedSearchModel();

                        if (dataTable.Columns.Contains("ID") && !dr["ID"].Equals(DBNull.Value))
                        {
                            timeshift_SavedSearchModel.ID = Convert.ToInt32(dr["ID"]);
                        }

                        if (dataTable.Columns.Contains("Title") && !dr["Title"].Equals(DBNull.Value))
                        {
                            timeshift_SavedSearchModel.Title = Convert.ToString(dr["Title"]);
                        }

                        if (dataTable.Columns.Contains("SearchTerm") && !dr["SearchTerm"].Equals(DBNull.Value))
                        {
                            timeshift_SavedSearchModel.SearchTerm = new TimeShiftSearchTerm();
                            timeshift_SavedSearchModel.SearchTerm = IQMedia.Shared.Utility.CommonFunctions.DeserialiazeXml(Convert.ToString(dr["SearchTerm"]),timeshift_SavedSearchModel.SearchTerm) as TimeShiftSearchTerm;
                        }

                        lstTimeshift_SavedSearchModel.Add(timeshift_SavedSearchModel);
                    }
                }
            }
            return lstTimeshift_SavedSearchModel;
        }
    }
}
