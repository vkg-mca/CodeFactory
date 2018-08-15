using DataAccessLayer;
using DataAccessLayer.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            DataAccessResponse Response=null;
            List<TransactionParameter> TransactionParameters= new List<TransactionParameter>();
            TransactionParameters.Add(new TransactionParameter() {DataType=DataTypeEnum.STRING,Value="Vinod"});
            TransactionParameters.Add(new TransactionParameter() { DataType = DataTypeEnum.STRING, Value = "Kumar" });
            TransactionParameters.Add(new TransactionParameter() { DataType = DataTypeEnum.STRING, Value = "Gupta" });
            DataAccessRequest Request = new DataAccessRequest()
            {
                SecurityParameter = new SecurityParameter() 
                { 
                   UserID="VGupta",
                   OperationCode=OperationCodeEnum.GET_USER
                },
                TransactionParameters = TransactionParameters,
            };
            
            using (DataAccessFacade facade=new DataAccessFacade())
            {
                Response = facade.Exceute(Request);
            }
             
        }
    }
}
