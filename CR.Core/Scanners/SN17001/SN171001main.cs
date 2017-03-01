using CR.Core.Services;
using System.Collections.Generic;

namespace CR.Core.Scanners.SN17001
{
    public class SN171001main
    {
        private string dPath, sPath;
        public SN171001main(string directoryPath, string scannerPath)
        {
            dPath = directoryPath;
            sPath = scannerPath;
        }

        public CRVData Scan()
        {
            //Get the scanner object
            CRObjSerializer cros = new CRObjSerializer();
            CRScanner crscanner = cros.LoadCRScanner(sPath);

            //Call the ICRISE implementation for this scanner
            ICRISE icrise = new SN171001IndicatorScan();
            List<CRIndicator> indicators = icrise.GetIndicators(dPath, crscanner);

            //Call the ICRIAE implementation for this scanner
            ICRIAE icriae = new SN17001AnalyzerScan();
            CRVData crd = icriae.GetCRVData(indicators, null);

            return null;
        }
    }
}
