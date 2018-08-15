using DataAccessLayer.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DataAccessManager:IDisposable
    {
        private readonly DataAccessRequest _dataAccessRequest;
        private readonly DataAccessConfiguration _dataAccessConfiguration;
        internal DataAccessManager(DataAccessRequest dataAccessRequest, DataAccessConfiguration dataAccessConfiguration)
        {
            ValidateRequest(dataAccessRequest, dataAccessConfiguration);
            _dataAccessRequest = dataAccessRequest;
            _dataAccessConfiguration = dataAccessConfiguration;
        }
        /// <summary>
        /// Creates a security table
        /// </summary>
        /// <returns>Security data table</returns>
        internal DataTable BuildSecurityDataTable()
        {
            DataTable SecurityTable=null;
            SecurityTable = ConstructSecurityTableSchema();
            SecurityTable = ConfigureSecurityTable(SecurityTable);
            return SecurityTable;
        }
        /// <summary>
        /// Creates parameter data table
        /// </summary>
        /// <returns>Parameter DataTable</returns>
        internal DataTable BuildParameterDataTable()
        {
            DataTable ParameterTable = null;
            ParameterTable = ConstructParameterTableSchema();
            //ParameterTable = ConfigureParameterTable(ParameterTable);
            using (DatabaseManager DBManager = new DatabaseManager(ParameterTable))
            {
                ParameterTable = DBManager.PopulateProcedureParameterTable(_dataAccessRequest.SecurityParameter.OperationCode);
            }
            return ParameterTable;
        }
        /// <summary>
        /// ParameterTable has to be updated for the values which are set in configuration table
        /// </summary>
        /// <returns></returns>
      
      


        internal DataAccessResponse BuildResponse(DataTable parameterDataTable)
        {
            DataAccessResponse Response = null;
            DataTable ResultDataTable = null;
            //Thought-1
            //The parameterDataTable table contains parameter values in rows while these values need to be converted in column
            //then only the data table can be passed to stored procedure
            //Thought-2
            //No, let me not do this because of the following problem
            //1. If I convert rows into columns then I cannot use the data table as a parameter to stored procedure because
            //I cannot create a user defined table data type which can satisfy variable number of columns. In this original table I have
            //fixed number of columns so it will be easy for me to create the user defined type for data table parametr to pass as input
            //parameter to stored procedure
            //Thoght-3
            //But the limitation of this final(unchanged) approach is that one parameter can contain only one value
            //Because the parameters are stored in form of rows in this data table so there would be only one value column
            //created in PopulateParameterValuesInTransformedParameterTable method....huh, this is not what I wanted.
            //O...hold on, if I add a Sequence column in data table then I can address this problem. I can repeat the set of
            //parameters multiple times assigning unique sequence value for one set....cool, i got the solution
            //No, it did not work, I have received an exception in DataAccessConfiguration class saying thet the item is already
            //added into the collection, let me park this aside for now and complete the limited functionality
            //I think, I dont have to add anything into the DataAccessConfiguration section of configuration file, I can manage with the
            //values I receive in the _dataAccessRequest object
            DataTable TransformedParameterDataTable = TransformParameterTable(parameterDataTable);
            //Thought-1
            //Now, since the above method returned the transformed data table so we can fill the parameter values
            //Thought-2
            //Since I have not changed the original table at all, so let me extend this data table by adding a column for
            //capturing the value of each parameter
            TransformedParameterDataTable = PopulateParameterValuesInTransformedParameterTable(TransformedParameterDataTable);

            using (DatabaseManager DBManager = new DatabaseManager(TransformedParameterDataTable))
            {
                ResultDataTable = DBManager.PopulateParameterResultTable();
            }

            return Response;
        }

        private DataTable TransformParameterTable(DataTable parameterDataTable)
        {
            DataTable TransformedParameterDataTable = parameterDataTable;
            return TransformedParameterDataTable;
        }



        private DataTable PopulateParameterValuesInTransformedParameterTable(DataTable TransformedParameterDataTable)
        {
            //Extending the data table by adding a bew column to capture the value of each parameter
            TransformedParameterDataTable.Columns.Add("Value", typeof(string));
            for (Int16 index = 0; index <= TransformedParameterDataTable.Rows.Count-1; index++)
            {
                TransformedParameterDataTable.Rows[index]["Value"] = _dataAccessRequest.TransactionParameters[index].Value;
            }
            return TransformedParameterDataTable;
        }

        private DataTable ConstructParameterTableSchema()
        {
            DataTable ParameterTable = new DataTable("ParameterTable");
            ParameterTable.Columns.Add("Name", typeof(string));
            ParameterTable.Columns.Add("Type", typeof(string));
            ParameterTable.Columns.Add("Size", typeof(Int16));
            ParameterTable.Columns.Add("Direction", typeof(Int16));
            ParameterTable.Columns.Add("Nullable", typeof(Int16));
            ParameterTable.Columns.Add("Procedure", typeof(string));
            //ParameterTable.Columns.Add("SetId", typeof(Int16));//The id to represent set of records

            return ParameterTable;
        }

        private DataTable ConstructSecurityTableSchema()
        {
            DataTable SecurityTable = new DataTable("SecurityTable");
            SecurityTable.Columns.Add("UserID", typeof(string));
            SecurityTable.Columns.Add("Opertion", typeof(string));
            return SecurityTable;
        }
        private DataTable ConfigureSecurityTable(DataTable SecurityTable)
        {
            DataRow SecurityRow = SecurityTable.NewRow();
            SecurityRow["UserID"] = _dataAccessRequest.SecurityParameter.UserID;
            SecurityRow["Opertion"] = _dataAccessRequest.SecurityParameter.OperationCode;
            SecurityTable.Rows.Add(SecurityRow);
            return SecurityTable;
        }

        private void ValidateRequest(DataAccessRequest dataAccessRequest, DataAccessConfiguration dataAccessConfiguration)
        {
            if (null == dataAccessRequest)
                throw new DataAccessRequestException("Data Access Request object is null");

            if (null == dataAccessConfiguration)
                throw new DataAccessConfigurationException("Data Access Configuration object is null");
        }

        internal DataAccessResponse ExcuteOperation()
        {
            DataAccessResponse DataAccessResponse = null;

            return DataAccessResponse;
        }


        public void Dispose()
        {
            
        }

    }
}
