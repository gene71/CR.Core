using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Core
{
    [Serializable]
    public class CRTemplate
    {

        public string ID { get; set; }
        public string TemplateName { get; set; }
        public string Description { get; set; }
        public List<CRScanner> Scanners { get; set; }
        public CRTemplate()
        {
            Scanners = new List<CRScanner>();
        }
    }
}
