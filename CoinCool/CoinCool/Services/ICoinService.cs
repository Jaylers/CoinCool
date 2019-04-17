using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinCool.Services
{
    public interface ICoinService<T>
    {
        Task<T> GetAllCoins();
        Task<T> GetCoinInfo(string id);
        Task<T> AddFavoriteCoin(string coinId, string myId);
        Task<T> RemoveFavoriteCoin(string coinId, string myId);
    }
}
