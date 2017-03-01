using CR.Core.Exceptions;
using CR.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CR.Core.Scanners.SN17001
{
    public class SN17001AnalyzerScan : ICRIAE
    {
        public CRVData GetCRVData(List<CRIndicator> indicators, CRScanner crscanner)
        {
            try
            {
                foreach(var i in indicators)
                {
                    //analyze new rules here
                    //1. does the file have the appropriate reference? //if yes then
                    if (refCheck(i.Path))
                    {
                        //2. is the appropriate method called?
                        //if yes then no vulnerability else positive 
                    }
                    else
                    {
                        //create vul
                    }
                    
                }
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw new CRServicesException(ex.Message);
            }
            
        }
        /// <summary>
        /// This methods checks for a using statement to certificates
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private bool refCheck(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    //TODO: add CRScanner
                    var matches = Regex.Matches(lines[i], "using[ ]+System.Security.Cryptography.X509Certificates;");
                    if (matches.Count > 0)
                    {
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new CRServicesException(ex.Message);
            }
            return false;
        }

        private bool methCheck(string filePath)
        {

            try
            {
                var lines = File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    //TODO: add CRScanner
                    var matches = Regex.Matches(lines[i], "chain.");
                    if (matches.Count > 0)
                    {
                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new CRServicesException(ex.Message);
            }
            return false;
        }
    }
}
