//------------------------------------------------------------------------------
// <copyright file="CSSqlClassFile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Data;
using vkg.codefactory.clrsql;
namespace CodeFactoryDb
{
    /// <summary>
    /// CodeSetManager class
    /// </summary>
    public class CodeSetManager
    {
       /// <summary>
       /// Constructor
       /// </summary>
        public CodeSetManager()
        {
        }

        /// <summary>
        /// Reading the codeset information
        /// </summary>
        /// <returns></returns>
        [SqlProcedure]
        public static Int32 ReadCodeSet()
        {
            Int32 NumRecords = ProcedureManager.ReadData("CodeSet");
           //DataSet ds = new DataSet();
            //StringBuilder CodeSetQuery = new StringBuilder();
            //Int32 NumRecords = 0;
            //CodeSetQuery.Append("SELECT * FROM  CodeSet");
            //using (SqlConnection connection = new SqlConnection("context connection=true"))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand(CodeSetQuery.ToString(), connection);
            //    SqlDataAdapter Adapter = new SqlDataAdapter(command);
            //    NumRecords = Adapter.Fill(ds);
            //    ProcessDatSet.SendDataSet(ds);
            //}
            return NumRecords;
            
        }
        [SqlProcedure]
        public static Int32 AddCodeSet(string Code, string ShortValue, string LongValue,
                                                string EffectiveFromDate, string EffectiveToDate, string CategoryCode)
        {
            Int32 Result = 0;
            StringBuilder CodeSetQuery = new StringBuilder();
            CodeSetQuery.Append("INSERT INTO  CodeSet(Code,ShortValue,LongValue,EffectiveFromDate,EffectiveToDate,CategoryCode) ");
            CodeSetQuery.Append("VALUES (");
            CodeSetQuery.Append(string.Format("'{0}','{1}','{2}','{3}','{4}','{5}'", Code, ShortValue, LongValue, EffectiveFromDate, EffectiveToDate, CategoryCode));
            CodeSetQuery.Append(" )");

            
            //CodeSetQuery.Append(string.Format("'{0}','{1}','{2}','{3}','{4}','{5}'", Code, ShortValue, LongValue, EffectiveFromDate, EffectiveToDate, CategoryCode));
            using (SqlConnection connection = new SqlConnection("context connection=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(CodeSetQuery.ToString(), connection);
                SqlDataAdapter Adapter = new SqlDataAdapter(command);
                Result = command.ExecuteNonQuery();
            }
            return Result;
        }
    }
}

