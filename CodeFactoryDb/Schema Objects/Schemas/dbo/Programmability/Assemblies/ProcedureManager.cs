using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;
using vkg.codefactory.clrsql;

namespace CodeFactoryDb
{
    public class ProcedureManager
    {

        public static Int32 ReadData(string Entity)
        {
            DataSet ds = new DataSet();
            StringBuilder CodeSetQuery = new StringBuilder();
            Int32 NumRecords = 0;
            CodeSetQuery.Append(string.Format("SELECT * FROM  {0}", Entity));
            using (SqlConnection connection = new SqlConnection("context connection=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(CodeSetQuery.ToString(), connection);
                SqlDataAdapter Adapter = new SqlDataAdapter(command);
                NumRecords = Adapter.Fill(ds);
                ProcessDatSet.SendDataSet(ds);
            }
            return NumRecords;

        }

    }
}
