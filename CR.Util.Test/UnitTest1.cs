using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CR.Util.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string dir1 = @"C:\Working\Project\PTDS_Rework\Pshs 3.0.7";
            string dir2 = @"C:\Working\Project\PTDS_Rework\WeatherPTDS_version_1.2.2";
            BuildCheck dc = new BuildCheck();
            Console.WriteLine(dc.HasBuildErrors(dir1));
            
            Console.WriteLine(dc.HasBuildErrors(dir2));
            foreach(var e in dc.Errors)
            {
                Console.WriteLine(e);
            }



        }
    }
}
