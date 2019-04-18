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
using CoinCool.Services;
using Newtonsoft.Json;

namespace CoinCool.Services
{
    class CoinService : ICoinService<List<CryptoInfo>>
    {
        private readonly WebClient _client;
        public CryptoInfo Items { get; set; }

        public CoinService()
        {
            _client = new WebClient();
        }

        public async Task<List<CryptoInfo>> GetAllCoins()
        {
            try
            {
                var coin = GetCoins();
                var res = JsonConvert.DeserializeObject<Dictionary<string, Crypto>>(coin);

                return SetCryptoInfo(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<CryptoInfo>();
            }
        }

        private List<CryptoInfo> SetCryptoInfo(Dictionary<string, Crypto> res)
        {
            var cryptoInfos = new List<CryptoInfo>();
            cryptoInfos.Clear();

            foreach (var resKey in res.Keys)
            {
                var crypto = res[resKey];

                var cryptoInfo = new CryptoInfo();
                cryptoInfo.id = crypto.id;
                cryptoInfo.key = resKey;
                cryptoInfo.name = CryptoName.GetCryptoName(resKey);
                cryptoInfo.imgUrl = CryptoImage.GetCryptoImageUrl(resKey);
                cryptoInfo.last = crypto.last;
                cryptoInfo.lowestAsk = crypto.lowestAsk;
                cryptoInfo.highestBid = crypto.highestBid;
                cryptoInfo.percentChange = crypto.percentChange;
                cryptoInfo.baseVolume = crypto.baseVolume;
                cryptoInfo.quoteVolume = crypto.quoteVolume;
                cryptoInfo.isFrozen = crypto.isFrozen;
                cryptoInfo.high24hr = crypto.high24hr;
                cryptoInfo.low24hr = crypto.low24hr;

                cryptoInfos.Add(cryptoInfo);
            }

            return cryptoInfos;
        }

        private string GetCoins()
        {
            var url = new UriBuilder(BaseService.BaseUrl);
            _client.Headers.Add("Accepts", "application/json");
            return _client.DownloadString(url.ToString());
        }
    }
}
