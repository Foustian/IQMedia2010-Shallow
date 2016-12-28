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
    internal class RoleModel : IQMediaGroupDataLayer,IRoleModel
    {
        /// <summary>
        /// This method gets Role information.
        /// Added By: Bhavik Barot
        /// </summary>
        /// <returns>Dataset containig Role information.</returns>
        public DataSet GetRoleInfo(bool? p_IsActive)
        {
            try
            {
                DataSet _DataSet = null;

                List<DataType> _ListOfDataType = new List<DataType>();

                _ListOfDataType.Add(new DataType("@IsActive", DbType.Boolean, p_IsActive, ParameterDirection.Input));

                _DataSet = this.GetDataSet("usp_Role_SelectAll", _ListOfDataType);                

                return _DataSet;
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
        }

        /// <summary>
        /// This method inserts Role information.
        /// Added By: Bhavik Barot
        /// </summary>
        /// <param name="p_Role">Object of Role class</param>
        /// <returns>RoleKey</returns>
        //public string InsertRole(Role p_Role)
        //{
        //    try
        //    {
        //        string _Result = string.Empty;

        //        List<DataType> _ListOfDataType = new List<DataType>();

        //        _ListOfDataType.Add(new DataType("@RoleName", DbType.String, p_Role.RoleName, ParameterDirection.Input));
        //        _ListOfDataType.Add(new DataType("@RoleKey", DbType.Int32, p_Role.RoleID, ParameterDirection.Output));

        //        _Result = ExecuteNonQuery("usp_Role_Insert", _ListOfDataType);

        //        return _Result;
        //    }
        //    catch (Exception _Exception)
        //    {
        //        throw _Exception;
        //    }
        //}

        /// <summary>
        /// This method updates Role information.
        /// Added By: Bhavik Barot
        /// </summary>
        /// <param name="p_Role">Object of Role class</param>
        /// <returns>RoleKey</returns>
        //public string UpdateRole(Role p_Role)
        //{
        //    try
        //    {
        //        string _Result = string.Empty;

        //        List<DataType> _ListOfDataType = new List<DataType>();

        //        _ListOfDataType.Add(new DataType("@RoleName", DbType.String, p_Role.RoleName, ParameterDirection.Input));
        //        _ListOfDataType.Add(new DataType("@Active", DbType.Boolean, p_Role.IsActive, ParameterDirection.Input));
        //        _ListOfDataType.Add(new DataType("@RoleKey", DbType.Int32, p_Role.RoleID, ParameterDirection.Input));

        //        _Result = ExecuteNonQuery("usp_Role_Update", _ListOfDataType);

        //        return _Result;
        //    }
        //    catch (Exception _Exception)
        //    {
        //        throw _Exception;
        //    }
        //}

        /// <summary>
        /// This method gets Role Key.
        /// Added By: Bhavik Barot
        /// </summary>
        /// <returns>Dataset containig Role information.</returns>
        public DataSet GetRoleName(string p_RoleName)
        {
            try
            {
                DataSet _DataSet = null;

                List<DataType> _ListOfDataType = new List<DataType>();

                _ListOfDataType.Add(new DataType("@RoleName", DbType.String, p_RoleName, ParameterDirection.Input));

                _DataSet = this.GetDataSet("usp_Roles_SelectByRoleName", _ListOfDataType);

                return _DataSet;
            }
            catch (Exception _Exception)
            {
                throw _Exception;
            }
        }
    }
}