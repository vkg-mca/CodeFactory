using DataAccessLayer.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessFacade:IDisposable
    {
        public DataAccessResponse Exceute(DataAccessRequest DataAccessRequest)
        {
            DataAccessResponse Response = null;
            try
            {
                DataTable SecurityDataTable;
                DataTable ParameterDataTable;

                DataAccessConfiguration DataAccessConfig = (DataAccessConfiguration)ConfigurationManager.GetSection("DataAccessConfiguration");
                using (DataAccessManager Manager = new DataAccessManager(DataAccessRequest, DataAccessConfig))
                {
                    SecurityDataTable = Manager.BuildSecurityDataTable();
                    ParameterDataTable = Manager.BuildParameterDataTable();
                    Response = Manager.BuildResponse(ParameterDataTable);
                }
            }
            catch (DataAccessException Exception)
            { }
            return Response;
        }

        public void Dispose()
        {
           
        }
    }
}
