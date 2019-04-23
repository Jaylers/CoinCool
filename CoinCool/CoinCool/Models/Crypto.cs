using System.Numerics;
using Xamarin.Forms;

namespace CoinCool.Models
{
    public class Crypto
    {
        public string id { get; set; }
        public string last { get; set; }
        public string lowestAsk { get; set; }
        public string highestBid { get; set; }
        public string percentChange { get; set; }
        public string baseVolume { get; set; }
        public string quoteVolume { get; set; }
        public string isFrozen { get; set; }
        public string high24hr { get; set; }
        public string low24hr { get; set; }
    }

    public class CryptoInfo
    {
        public string id { get; set; }
        public string key { get; set; }
        public string imgUrl { get; set; }
        public string name { get; set; }
        public string last { get; set; }
        public string lowestAsk { get; set; }
        public string highestBid { get; set; }
        public string percentChange { get; set; }
        public string baseVolume { get; set; }
        public string quoteVolume { get; set; }
        public string isFrozen { get; set; }
        public string high24hr { get; set; }
        public string low24hr { get; set; }

        public Color color => BigInteger.Parse(percentChange) < 0 ? Color.Red : Color.Green;
    }

    public class SocketCrypto
    {
        public string stream { get; set; }
        public string id { get; set; }
        public string last { get; set; }
        public string lowestAsk { get; set; }
        public string highestBid { get; set; }
        public string percentChange { get; set; }
        public string baseVolume { get; set; }
        public string quoteVolume { get; set; }
        public string isFrozen { get; set; }
        public string high24hr { get; set; }
        public string low24hr { get; set; }
}
}
