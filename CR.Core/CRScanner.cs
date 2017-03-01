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
        /// <summary>
        /// CRVID is not used at this time
        /// </summary>
        public string CRVID { get; set; }
        public string CRID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Positive indicates a vulnerability was detected if there are
        /// scan results (matches)
        /// </summary>
        public bool Positive { get; set; }
        public List<string> Patterns { get; set; }
        public List<string> FileExtensions { get; set; }
        public CRScanner()
        {
            Patterns = new List<string>();
            FileExtensions = new List<string>();
        }
       
    }
}
