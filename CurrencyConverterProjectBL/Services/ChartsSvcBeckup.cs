using System.Net.Http;

namespace CurrencyConverterProjectBL.Services
{
    internal class ChartsSvcBeckup
    {
        /// private memmbers
        private readonly string accessKey;
        private string chartApiUrl
        {
            get
            {
                return "http://api.currencylayer.com/live?access_key={0}&source{1}&currencies={2}&format=1";
            }
        }


        /// ctor 
        public ChartsSvcBeckup(string key)
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
