using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;

namespace CoinCool.Services
{
    public static class Example
    {
        private static string API_KEY = BaseService.Key;

        public static string MakeApiCall()
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
          

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(URL.ToString());

        }
    }
}
