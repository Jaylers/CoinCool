using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCool.Services
{
    public static class BaseService
    {
        // URL of REST service
        public static string Key = "16e0ec17-3032-475a-8e45-95d3503adca5";

        public static string BaseUrl = "https://pro-api.coinmarketcap.com";

        public static string Lastest = "/v1/cryptocurrency/listings/latest";
    }
}
