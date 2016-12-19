using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Core
{
    [Serializable]
    public class CRScanner
    {

        public string CRVID { get; set; }
        public List<string> Patterns { get; set; }
        public List<string> FileExtensions { get; set; }
        public CRScanner()
        {
            Patterns = new List<string>();
            FileExtensions = new List<string>();
        }
       
    }
}
