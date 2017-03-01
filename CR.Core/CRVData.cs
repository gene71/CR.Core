using System;
using System.Collections.Generic;


namespace CR.Core
{
    [Serializable]
    public class CRVData
    {
        public string CRID { get; set; }
        public string Notes { get; set; }
        public List<CRIndicator> Indicators { get; set; }
        /// <summary>
        /// Positive indicates a vulnerability was detected
        /// </summary>
        public bool Positive { get; set; }

    }
}
