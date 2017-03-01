using System.Collections.Generic;

namespace CR.Core.Services
{
    public interface ICRISE
    {
        List<CRIndicator> GetIndicators(string dirPath, CRScanner scanner);
       // void LoadScanner(string dirPath);
    }
}
