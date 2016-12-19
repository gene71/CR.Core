using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Core
{
    [Serializable]
    public class CRFile
    {

        public string Path { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public string Hash { get; set; }
        public string Name { get; set; }
        public int Lines { get; set; }
        public int ExecLines { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0},", Name);
            sb.AppendFormat("{0},", Path);
            sb.AppendFormat("{0},", Extension);
            sb.AppendFormat("{0},", Size);
            sb.AppendFormat("{0},", Hash);
            sb.AppendFormat("{0},", Lines);
            sb.AppendFormat("{0},", ExecLines);
            return sb.ToString();
        }
    }
}
