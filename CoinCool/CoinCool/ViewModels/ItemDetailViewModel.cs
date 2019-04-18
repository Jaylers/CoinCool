﻿using System;

using CoinCool.Models;

namespace CoinCool.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public CryptoInfo Item { get; set; }
        public ItemDetailViewModel(CryptoInfo item = null)
        {
            Title = item?.name;
            Item = item;
        }
    }
}
