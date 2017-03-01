using CR.Core.Exceptions;
using CR.Core.Services;
using CR.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CR.Core.Scanners.SN17001
{
    public class SN171001IndicatorScan : ICRISE
    {
        List<CRIndicator> indis;

        public SN171001IndicatorScan()
        {
            indis = new List<CRIndicator>();
        }
        public List<CRIndicator> GetIndicators(string dirPath, CRScanner scanner)
        {
            try
            {
                FileUtil fu = new FileUtil();
                foreach (var f in fu.GetFiles(dirPath))
                {
                    FileInfo fi = new FileInfo(f);
                    foreach (var ex in scanner.FileExtensions)
                    {
                        if (fi.Extension == ex)
                        {
                            //do scan
                            getIndis(f, scanner);

                        }
                    }//end foreach ex
                }//end foreach f
                //May need to add a clean function here to remove duplicate 
                //line triggers
                return indis;
                
            }
            catch (Exception ex)
            {
                throw new CRServicesException(ex.Message);
            }
            
        }

        private void getIndis(string filePath, CRScanner crs)
        {
            try
            {
                foreach (var p in crs.Patterns)
                {
                    var lines = File.ReadAllLines(filePath);
                    for (int i = 0; i < lines.Length; i++)
                    {
                        var matches = Regex.Matches(lines[i], p);
                        if (matches.Count > 0)
                        {
                            //found match make vul
                            CRIndicator crvul = new CRIndicator();
                            crvul.CRVID = crs.CRVID;
                            crvul.Line = lines[i].ToString();
                            crvul.LineNumber = i + 1;//account for 0
                            crvul.Path = filePath;
                            crvul.MVal = matches[0].Value;
                            //TODO: clean indi
                            indis.Add(crvul);
                        }

                    }//end for 

                }//end foreach
            }
            catch (Exception ex)
            {
                throw new CRServicesException(ex.Message);
            }
        }

    }
}
