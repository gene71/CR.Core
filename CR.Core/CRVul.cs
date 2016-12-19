using System;
using System.Text;


namespace CR.Core
{
    [Serializable]
    public class CRVul
    {

        public string CRVID { get; set; }
        public int LineNumber { get; set; }
        public string Line { get; set; }
        public string Path { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0},", CRVID);
            sb.AppendFormat("{0},", LineNumber);
            sb.AppendFormat("{0},", Line);
            sb.AppendFormat("{0},", Path);
            return sb.ToString();
        }
    }
}
