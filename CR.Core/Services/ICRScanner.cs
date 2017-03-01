using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Core.Services
{
    public interface ICRScanner
    {
        CRVData Scan(string dirPath);
    }
}
