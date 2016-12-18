using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Util.Exceptions
{
    public class FileUtilException : Exception 
    {
        public FileUtilException(string message) : base ("FileUtilException: " + message)
        {

        }
    }
}
