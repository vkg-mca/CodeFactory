using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataAccessException:ApplicationException 
    {
        public DataAccessException(string message)
        { }
        public string Message { get; set; }
    }

    public class DataAccessRequestException : DataAccessException
    {
        public DataAccessRequestException(string message)
            : base(message)
        { }
        public string Message { get; set; }
    }
    public class DataAccessConfigurationException : DataAccessException
    {
        public DataAccessConfigurationException(string message)
            : base(message)
        { }
        public string Message { get; set; }
    }
}
