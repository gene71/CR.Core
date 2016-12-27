using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Core.Exceptions
{
    public class CRServicesException : Exception
    {
        public CRServicesException(string message) : base ("CRServicesException: " + message)
        {

        }
    }
}
