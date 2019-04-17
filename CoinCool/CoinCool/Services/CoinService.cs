using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CoinCool.Models;
using Newtonsoft.Json;

namespace CoinCool.Services
{
    class CoinService : ICoinService<CoinResponse>
    {
        WebClient client;
        public CoinResponse Items { get; private set; }

        public CoinService()
        {
            client = new WebClient();
        }

        public async Task<CoinResponse> GetAllCoins()
        {
            try
            {
                var coin = GetCoins();
                Debug.WriteLine("IIIIIIIIIIIIIIIIIIIIIIIIIIi : " + coin);
                var res = JsonConvert.DeserializeObject<CoinResponse>(coin);
                Debug.WriteLine(@"XXXXXXXXXXXXXXXXXXXXXXXXXXXx {0} EIEI", res.status.timestamp);

                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string GetCoins()
        {
            var url = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            url.Query = queryString.ToString();

            client.Headers.Add("X-CMC_PRO_API_KEY", BaseService.Key);
            client.Headers.Add("Accepts", "application/json");
            return client.DownloadString(url.ToString());
        }

        public async Task<CoinResponse> GetCoinInfo(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CoinResponse> AddFavoriteCoin(string coinId, string myId)
        {
            throw new NotImplementedException();
        }

        public async Task<CoinResponse> RemoveFavoriteCoin(string coinId, string myId)
        {
            throw new NotImplementedException();
        }
    }
}
