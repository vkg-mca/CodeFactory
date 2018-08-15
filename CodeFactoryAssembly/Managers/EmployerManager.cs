using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text;

internal class EmployerManager : ProcedureManager
{
    [SqlProcedure]
    internal Int32 ReadEmployer()
    {
        Int32 NumRecords=ReadData ("Employer");
        return NumRecords;
    }
}
