using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessRequest
    {
        public SecurityParameter SecurityParameter { get; set; }
        public List<TransactionParameter> TransactionParameters { get; set; }
    }

    public class SecurityParameter
    {
        public string UserID { get; set; }
        public OperationCodeEnum OperationCode { get; set; }
    }

    public class TransactionParameter
    {
        //public string Name { get; set; }
        public DataTypeEnum DataType { get; set; }
        public string Value { get; set; }
        //public Int16 OrdinalPosition { get; set; }
    }

    public enum DataTypeEnum
    { 
        SHORT,
        LONG,
        DOUBLE,
        STRING,
        DATE,
        TIME,
        DATETIME,
        BOOLEAN
    }
    public enum OperationCodeEnum
    { 
        GET_USER,
        ADD_USER,
        DELETE_USER,
        UPDATE_USER
    }
}
