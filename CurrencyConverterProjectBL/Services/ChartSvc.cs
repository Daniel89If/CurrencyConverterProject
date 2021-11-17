using System.Net.Http;

namespace CurrencyConverterProjectBL.Services
{
    internal class ChartSvc
    {
        /// private memmbers
        private readonly string accessKey;
        private string chartApiUrl
        {
            get
            {
                return "http://api.exchangeratesapi.io/v1/latest?access_key={0}&base={1}&symbols={2}";
            }
        }


        /// ctor 
        public ChartSvc(string key)
        {
            accessKey = key;
        }

        public string Get(string baseCoin, string symbols)
        {
            string uri = string.Format(chartApiUrl, accessKey, baseCoin, symbols);
            using (HttpClient client = new HttpClient())
            {
                return client.GetStringAsync(uri).Result;
            }
        }
    }

}
