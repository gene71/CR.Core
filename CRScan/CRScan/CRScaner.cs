using CodeRecon.Core;
using CodeRecon.CVulScan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//change test
namespace CRScan
{
    public class CRScaner
    {
        public void Scan(CRScanProject crScanProj)
        {
                     

            try
            {
                CRFac crfac = new CRFac();
                List<CRFile> files = crfac.BuildCRFiles(crScanProj.ScanDirectory);
                fileReport(crScanProj.ReportDirectory, files, crScanProj.ProjectName);

                VulRecFac vrf = new VulRecFac();
                vulReport(crScanProj.ReportDirectory, vrf.GetVul(files), crScanProj.ProjectName);
               
               
            }
            catch (Exception ex)
            {
                throw new CRScanException(ex.Message);
            }

          
        }
        private void vulReport(string reportDir, List<CRVul> vuls, string scanName)
        {
            StringBuilder sb = new StringBuilder();//make vul report
            sb.AppendFormat("{0},{1},{2},{3}\n",
                    "Vulnerability ID", "Line Number", "Line", "File");
            foreach (var v in vuls)
            {

                sb.AppendFormat("{0},{1},{2},{3}\n",
                    v.VulID, v.LineNumber, v.Line.Replace(',', ' ').Trim(), v.Path);
            }
            File.WriteAllText(reportDir + "\\" +
                scanName+ "_VulReport.csv", sb.ToString());
        }

        private void fileReport(string reportDir, List<CRFile> files, string scanName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7}\n",
                    "Component", "File Name", "Size", "Line Count",
                    "Exec Lines", "Extension", "MD5 Hash", "Path");
            foreach (var f in files)
            {
                sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7}\n",
                    f.AppComponent, f.Name, f.Size, f.Lines, f.ExecLines, f.Extension, 
                    f.Hash, f.Path);
            }
            File.WriteAllText(reportDir + "\\" +
                scanName + "_FilesScanned.csv", sb.ToString());
        }

    }
}
