using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using CoinCool.Models;
using CoinCool.Services;
using CoinCool.Views;

namespace CoinCool.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<CryptoInfo> Coins { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Coin cool";
            Coins = new ObservableCollection<CryptoInfo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //Subscribe Item in NewItemPage.cs to add to the list show
            MessagingCenter.Subscribe<NewItemPage, CryptoInfo>(this, "Subscribe", async (obj, item) =>
            {
                
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            Coins.Clear();

            try
            {
                var data = new CoinService().GetAllCoins().Result;
                foreach (var value in data)
                {
                    Coins.Add(value);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}