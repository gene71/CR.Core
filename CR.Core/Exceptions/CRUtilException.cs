using System;

namespace CR.Util.Exceptions
{
    public class CRUtilException : Exception
    {
        public CRUtilException(string message) : base ("CRUtilException: " + message)
        {

        }
    }
}
