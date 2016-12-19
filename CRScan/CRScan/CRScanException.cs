using CodeRecon.CVulScan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRScan
{
    public class CRScanException : CVulScanException
    {
        public CRScanException(string message) : base("CRScanException " + message)
        {

        }
    }
}
