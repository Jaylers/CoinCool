using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCool.Models
{
    static class CryptoName
    {
        /// <summary>
        /// Static string Dictionary example
        /// </summary>
        static Dictionary<string, string> _cryptoNameDict = new Dictionary<string, string>
        {
            {"THB_BTC", "Bitcoin | BTC"},
            {"THB_ETH", "Ethereum | ETH"},
            {"THB_XRP", "XRP | XRP"},
            {"THB_BCH", "Bitcoin Cash | BCH"},
            {"THB_LTC", "Litecoin | LTC"},
            {"THB_DASH", "Dash | DASH"},
            {"THB_XEM", "NEM | XEM"},
            {"THB_BCC", ""},
            {"THB_XMR", "Monero | XMR"},
            {"THB_NEO", "NEO | NEO"},
            {"THB_MIOTA", "IOTA | MIOTA"},
            {"THB_BTG", "Bitcoin Gold | BTG"},
            {"THB_XLM", "Stellar | XLM"},
            {"THB_ADA", "Cardano | ADA"},
            {"THB_IOTA", "IOTA | MIOTA"},
            {"THB_TRX", "TRON | TRX"},
            {"THB_EOS", "EOS | EOS"},
            {"THB_ABT", "Arcblock"},
            {"THB_AST", "AirSwap"},
            {"THB_BSV", "Bitcoin SV"},
            {"THB_CTXC", "Cortex | CTXC"},
            {"THB_CVC", "Civic | CVC"},
            {"THB_ENG", "Enigma | ENG"},
            {"THB_GNT", "Golem | GNT"},
            {"THB_GUSD", "Gemini Dollar | GUSD"},
            {"THB_INF", "InfChain | INF"},
            {"THB_IOST", "IOST | IOST"},
            {"THB_KNC", "Kyber Network | KNC"},
            {"THB_LINK", "Chainlink | LINK"},
            {"THB_MANA", "Decentraland | MANA"},
            {"THB_OMG", "OmiseGO | OMG"},
            {"THB_RDN", "Raiden Network Token | RDN"},
            {"THB_SIX", "SIX | SIX"},
            {"THB_SNT", "Status | SNT"},
            {"THB_STORJ", "Storj | STORJ"},
            {"THB_USDT", "Tether | USDT"},
            {"THB_WAN", "Wanchain | WAN"},
            {"THB_ZIL", "Zilliqa | ZIL"},
            {"THB_ZRX", "0x | ZRX"}
        };

        /// <summary>
        /// Access the Dictionary from external sources
        /// </summary>
        public static string GetCryptoName(string word)
        {
            // Try to get the result in the static Dictionary
            return _cryptoNameDict.TryGetValue(word, out var result) ? result : "";
        }
    }

    static class CryptoImage
    {
        /// <summary>
        /// Static string Dictionary example
        /// </summary>
        static Dictionary<string, string> _cryptoImageDict = new Dictionary<string, string>
        {
            {"THB_BTC", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1508609483/bitcoin_eqld4v.png"},
            {"THB_ETH", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1508609485/ethereum_nw0chu.png"},
            {"THB_XRP", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1508609486/ripple_p0xeut.png"},
            {"THB_BCH", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1516327336/bch_2x_hahroi.png"},
            {"THB_LTC", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1512427497/ltc_fjbqjf.png"},
            {"THB_DASH", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1508609484/dash_oltvqi.png"},
            {"THB_XEM", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1508609486/nem_imprip.png"},
            {"THB_BCC", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1508609486/bitconnect_oj1bo5.png"},
            {"THB_XMR", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1508609486/monero_wzk3ur.png"},
            {"THB_NEO", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1508609486/neo_fvoo6c.png"},
            {"THB_MIOTA", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1512510148/miota_2x_xkby9u.png"},
            {"THB_BTG", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1513434542/bitcoiimagen-gold_reytam.png"},
            {"THB_XLM", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1516326886/xlm_2x_jfwlwt.png"},
            {"THB_ADA", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1516326874/ada_2x_g4fs0c.png"},
            {"THB_IOTA", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1516327102/miota_2x_zsvtqc.png"},
            {"THB_TRX", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1516326885/trx_2x_ukhxjm.png"},
            {"THB_EOS", "https://res.cloudinary.com/da7jhtpgh/image/upload/v1516326878/eos_2x_dvr7p0.png"},
            {"THB_ABT", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/arcblock.png"},
            {"THB_AST", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/airswap.png"},
            {"THB_BSV", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/bitcoin-sv.png"},
            {"THB_CTXC", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/cortex.png"},
            {"THB_CVC", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/civic.png"},
            {"THB_ENG", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/enigma.png"},
            {"THB_GNT", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/golem-network-tokens.png"},
            {"THB_GUSD", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/gemini-dollar.png"},
            {"THB_INF", "https://s2.coinmarketcap.com/static/img/coins/64x64/1880.png"},
            {"THB_IOST", "https://s2.coinmarketcap.com/static/img/coins/64x64/2405.png"},
            {"THB_KNC", "https://s2.coinmarketcap.com/static/img/coins/64x64/1982.png"},
            {"THB_LINK", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/chainlink.png"},
            {"THB_MANA", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/decentraland.png"},
            {"THB_OMG", "https://s2.coinmarketcap.com/static/img/coins/64x64/1808.png"},
            {"THB_RDN", "https://s2.coinmarketcap.com/static/img/coins/64x64/2161.png"},
            {"THB_SIX", "https://s2.coinmarketcap.com/static/img/coins/64x64/3327.png"},
            {"THB_SNT", "https://s2.coinmarketcap.com/static/img/coins/64x64/1759.png"},
            {"THB_STORJ", "https://s2.coinmarketcap.com/static/img/coins/64x64/1772.png"},
            {"THB_USDT", "https://s2.coinmarketcap.com/static/img/coins/64x64/825.png"},
            {"THB_WAN", "https://s2.coinmarketcap.com/static/img/coins/64x64/2606.png"},
            {"THB_ZIL", "https://s2.coinmarketcap.com/static/img/coins/64x64/2469.png"},
            {"THB_ZRX", "https://raw.githubusercontent.com/ErikThiart/cryptocurrency-icons/master/64/0x.png"}
        };

        /// <summary>
        /// Access the Dictionary from external sources
        /// </summary>
        public static string GetCryptoImageUrl(string word)
        {
            // Try to get the result in the static Dictionary
            return _cryptoImageDict.TryGetValue(word, out var result) ? result : "";
        }
    }
}
