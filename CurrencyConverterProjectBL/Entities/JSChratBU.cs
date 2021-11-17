using System.Collections.Generic;

namespace CurrencyConverterProjectBL.Entities
{
    // {
    //    "success": true,
    //    "terms": "https://currencylayer.com/terms",
    //    "privacy": "https://currencylayer.com/privacy",
    //    "timestamp": 1637136604,
    //    "source": "USD",
    //    "quotes": {
    //        "USDEUR": 0.884575
    //    }
    //}
    public class JSChartBU
    {
        public bool success;
        public long timestamp;
        public string source;
        public string date;
        public Dictionary<string, object> quotes;
    }
}