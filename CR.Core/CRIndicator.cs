using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Core
{
    [Serializable]
    public class CRIndicator : CRVul
    {
        public string MVal { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0},", CRVID);
            sb.AppendFormat("{0},", LineNumber);
            sb.AppendFormat("{0},", MVal);
            sb.AppendFormat("{0},", Line);
            sb.AppendFormat("{0},", Path);
            return sb.ToString();
        }
    }
}
