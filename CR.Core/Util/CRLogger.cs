using CR.Core.Exceptions;
using CR.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Util
{
    public class CRLogger
    {

        public enum CRLogTitle { Info, Error, Status };
        private string logDir = "CRLog.txt";
        /// <summary>
        /// WriteLog writes the specified  title and message to the logging directory. 
        /// If a logging directory has not been set it writes to the default path.
        /// The default path is the execution directory for the
        /// hosting application.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="msg"></param>
        public void WriteLog(CRLogTitle title, string msg)
        {
            try
            {
                using (FileStream fs = new FileStream(logDir, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(DateTime.Now + " " + title + ": " + msg);
                }
            }
            catch (Exception ex)
            {
                throw new CRUtilException(ex.Message);
            }

        }

        /// <summary>
        /// SetLogDir sets the logging directory for the logger.  If the
        /// directoyr doesn't exist SetLogDir will attempt to create the directory
        /// and set the path.  The default path is the execution directory for the
        /// hosting application.
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="CRLoggerException">CRLoggerException</exception>
        public void SetLogDir(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    logDir = path + "\\" + logDir;

                }
                else
                {
                    logDir = path + "\\" + logDir;
                }
            }
            catch (Exception ex)
            {
                throw new CRUtilException(ex.Message);
            }


        }
    }
}
