using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CR.Core.Scanners.SN17001;

namespace CR.Core.Scanners.Test
{
    [TestClass]
    public class SN17001Test
    {
        [TestMethod]
        public void SN17001TestMethod1()
        {
            string dirPath = @"C:\Working\Project\CampaignPlanner\Source Code";
            string scannerPath = @"C:\Working\RegexScanner\Scanners\X509Chain.xml";
            SN171001main sn17 = new SN171001main(dirPath, scannerPath);
            sn17.Scan();
        }
    }
}
