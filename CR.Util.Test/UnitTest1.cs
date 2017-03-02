using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CR.Core.Services;

namespace CR.Util.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string dir1 = @"C:\Working\Project\PTDS_Rework\Pshs 3.0.7";
            string dir2 = @"C:\Working\Project\PTDS_Rework\WeatherPTDS_version_1.2.4";
            BuildCheck dc = new BuildCheck();
            //Console.WriteLine(dc.HasBuildErrors(dir1));
            
            Console.WriteLine(dc.HasBuildErrors(dir2));
            foreach(var e in dc.Errors)
            {
                Console.WriteLine(e);
            }



        }

        [TestMethod]
        public void TestSTIGCL()
        {
            try
            {
                CRObjSerializer cros = new CRObjSerializer();
                CHECKLIST ckl = cros.LoadSTIGCKL(@"C:\TEMP\ckl_testSave.xml");
                foreach (var vuln in ckl.STIGS.iSTIG.VULN)
                {
                    if (vuln.STIG_DATA[0].ATTRIBUTE_DATA == "V-70149")
                    {
                        //vuln.FINDING_DETAILS = "finding test test";
                        //Console.WriteLine(vuln.COMMENTS.ToString());
                        Console.WriteLine(vuln.FINDING_DETAILS.ToString());
                        vuln.STATUS = "Open";
                    }
                }

                cros.SaveCRObj(@"C:\TEMP\ckl_testSave.ckl", ckl);
            }
            catch (Exception ex)
            {
                throw new AssertFailedException(ex.Message);
            }
        }

        [TestMethod]
        public void TestAppDirBuilder()
        {
            try
            {
                //AppDirectoryBuilder.BuildAppDirectory();
            }
            catch (Exception ex)
            {
                throw new AssertFailedException(ex.Message);
            }
            
        }


    }
}
