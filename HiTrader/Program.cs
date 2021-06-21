using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HiTrader
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
            var url = "https://api.huobi.pro/market/tickers";
            Task<string> response = httpClient.GetStringAsync(url);
            var stringData = response.Result;
            var data = (JObject) JsonConvert.DeserializeObject(stringData);
            Console.WriteLine(data["data"].Count());
            foreach (var item in data["data"]);
        }
    }
}