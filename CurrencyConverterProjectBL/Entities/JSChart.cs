using System.Collections.Generic;

namespace CurrencyConverterProjectBL.Entities
{
    //{
    //"success": true,
    //"timestamp": 1637054524,
    //"base": "EUR",
    //"date": "2021-11-16",
    //"rates": {
    //    "USD": 1.13655,
    //    "ILS": 3.531078
    //}

    public class JSChart
    {
        public bool success;
        public long timestamp;
        public string @base;
        public string date;
        public Dictionary<string, object> rates;
    }
}
