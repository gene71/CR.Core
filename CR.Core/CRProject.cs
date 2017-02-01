using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Core
{
    [Serializable]
    public class CRProject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string ScanDir { get; set; }
        public List<string> CRScanners;
        public string Template { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0},", Name);
            sb.AppendFormat("{0},", Path);
            sb.AppendFormat("{0},", ScanDir);
            sb.AppendFormat("{0},", Template);
            return sb.ToString();
        }
        public CRProject()
        {
            CRScanners = new List<string>();
        }

    }
}
