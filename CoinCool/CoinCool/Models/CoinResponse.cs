using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCool.Models
{
    class CoinResponse
    {
        public Status status { get; set; }
        public List<Coin> data { get; set; }
    }

    public class Status
    {
        public DateTime timestamp { get; set; }
        public int error_code { get; set; }
        public object error_message { get; set; }
        public int elapsed { get; set; }
        public int credit_count { get; set; }
    }

    public class Platform
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public string token_address { get; set; }
    }

    public class Currency
    {
        public double price { get; set; }
        public double volume_24h { get; set; }
        public double percent_change_1h { get; set; }
        public double percent_change_24h { get; set; }
        public double percent_change_7d { get; set; }
        public double market_cap { get; set; }
        public DateTime last_updated { get; set; }
    }

    public class Quote
    {
        public Currency USD { get; set; }
    }

    public class Coin
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public double circulating_supply { get; set; }
        public double total_supply { get; set; }
        public long? max_supply { get; set; }
        public DateTime date_added { get; set; }
        public int num_market_pairs { get; set; }
        public List<object> tags { get; set; }
        public Platform platform { get; set; }
        public int cmc_rank { get; set; }
        public DateTime last_updated { get; set; }
        public Quote quote { get; set; }

        public string fullName => name + " | " + symbol;
        public string price => quote.USD.price.ToString();
        public string change24 => quote.USD.percent_change_24h.ToString();

    }
}
