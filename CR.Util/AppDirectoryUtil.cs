using CR.Core;
using CR.Core.Exceptions;
using CR.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Core.Util
{
    /// <summary>
    /// AppDirectoryUtil this class contains static methods to assist with
    /// setting up and maintaining the CRApp file structure
    /// </summary>
    public static class AppDirectoryUtil
    {
        public static void BuildAppDirectory()
        {
            try
            {
                Directory.CreateDirectory(CRGlobal.CRAppCache);
                Directory.CreateDirectory(CRGlobal.CRScanners);
                Directory.CreateDirectory(CRGlobal.CRScanData);
            }
            catch (Exception ex)
            {
                throw new Exceptions.CRUtilException(ex.Message);
            }
           
        }

        


    }
}
