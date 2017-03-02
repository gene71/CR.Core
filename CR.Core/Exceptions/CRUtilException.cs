using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Util.Exceptions
{
    public class CRUtilException : Exception
    {
        public CRUtilException(string message) : base ("CRUtilException: " + message)
        {

        }
    }
}
