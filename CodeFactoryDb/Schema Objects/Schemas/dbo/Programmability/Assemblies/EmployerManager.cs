using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;
namespace CodeFactoryDb
{
    public class EmployerManager
    {
        [SqlProcedure]
        public static Int32 ReadEmployer()
        {
            Int32 NumRecords = ProcedureManager.ReadData("Employer");
            return NumRecords;
        }
    }
}
