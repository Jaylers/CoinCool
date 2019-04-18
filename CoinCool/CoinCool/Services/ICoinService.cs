using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinCool.Services
{
    public interface ICoinService<T>
    {
        Task<T> GetAllCoins();
    }
}
