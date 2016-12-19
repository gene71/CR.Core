using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CRScan
{
    [Serializable]
    public class CRScanProject
    {
        public string ProjectName { get; set; }
        public string ScanDirectory { get; set; }
        public string ReportDirectory { get; set; }
        public DateTime CreateDate { get; set; }
        public void Save(string FileName)
        {
            using (var writer = new System.IO.StreamWriter(FileName))
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(writer, this);
                writer.Flush();
            }
        }
        public static CRScanProject Load(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(CRScanProject));
                return serializer.Deserialize(stream) as CRScanProject;
            }
        }
    }
}
