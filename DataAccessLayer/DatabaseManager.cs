using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DatabaseManager:IDisposable
    {
        private DataTable _procedureTable;
        internal DatabaseManager(DataTable procedureTable)
        {
            _procedureTable = procedureTable;
        }
        internal DataTable PopulateProcedureParameterTable(OperationCodeEnum operationCode)
        {
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@OperationCode", operationCode));
            SqlDataReader DataReader = PrepareDataReader(Parameters, "[dbo].[ReadProcedureNameByOperationCode]");
            DataTable ResultTable = ConstructProcedureParameterTable(DataReader);
            return ResultTable;
        }

       

        internal DataTable PopulateParameterResultTable()
        {
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@TransactionParameterTable", _procedureTable));
            DataTable ResultTable = PrepareDataTable(Parameters, _procedureTable.Rows[0]["Procedure"].ToString());
            return ResultTable;
        }


        private DataTable ConstructProcedureParameterTable(SqlDataReader DataReader)
        {
            DataRow ParameterRow;
            DataTable ProcedureTable = null;

            if (!(null == DataReader))
            {
                ProcedureTable = _procedureTable;
                while (DataReader.Read())
                {
                    if (!("@RETURN_VALUE" == DataReader["PARAMETER_NAME"].ToString()))
                    {
                        ParameterRow = ProcedureTable.NewRow();
                        ParameterRow["Name"] = Convert.ToString(DataReader["PARAMETER_NAME"]);
                        ParameterRow["Type"] = Convert.ToString(DataReader["TYPE_NAME"]);
                        ParameterRow["Size"] = DBNull.Value == DataReader["CHARACTER_MAXIMUM_LENGTH"] ? 0 : Convert.ToInt16(DataReader["CHARACTER_MAXIMUM_LENGTH"]);
                        ParameterRow["Direction"] = Convert.ToInt16(DataReader["PARAMETER_TYPE"]);
                        ParameterRow["Nullable"] = Convert.ToInt16(DataReader["IS_NULLABLE"]);
                        ParameterRow["Procedure"] = Convert.ToString(DataReader["PROCEDURE_NAME"]).Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)[0];
                        ProcedureTable.Rows.Add(ParameterRow);
                    }
                }
                DataReader.Close();
            }
            return ProcedureTable;
        }
        
        

        private SqlDataReader PrepareDataReader(List<SqlParameter> Parameters, string ProcedureName)
        {
            SqlConnection Connection = OpenConnection();
            SqlCommand Command = CreateCommand(Connection, Parameters, ProcedureName);
            SqlDataReader DataReader = Command.ExecuteReader();
            return DataReader;
        }

        private DataTable PrepareDataTable(List<SqlParameter> Parameters, string ProcedureName)
        {
             
            DataTable Table=new DataTable ();
            SqlConnection Connection = OpenConnection();
            SqlCommand Command = CreateCommand(Connection, Parameters, ProcedureName);
            using (SqlDataAdapter Adapter = new SqlDataAdapter(Command))
            {
                Adapter.Fill(Table);
            }
            return Table;
        }
       
        private SqlConnection OpenConnection()
        {
            string ConnectionString=ConfigurationManager.ConnectionStrings["CodeFactoryDbConnectionString"].ToString ();

            SqlConnectionStringBuilder ConnectionStringBuilder=new SqlConnectionStringBuilder(ConnectionString);
            SqlConnection Connection = new SqlConnection(ConnectionString);
            if (!(Connection.State == ConnectionState.Open))
            {
                Connection.Open();
            }
            return Connection;
        }



        private SqlCommand CreateCommand(SqlConnection connection, List<SqlParameter> parameters, string procedureName)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = procedureName;
            Command.CommandType = CommandType.StoredProcedure;
            Command.Connection = connection;

            foreach (SqlParameter Parameter in parameters)
            {
                Command.Parameters.Add(Parameter);
            }
            return Command;
        }

        public void Dispose()
        {
           
        }


       
    }
}
