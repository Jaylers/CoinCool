using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CoinCool.Models;
using CoinCool.ViewModels;

namespace CoinCool.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new CryptoInfo()
            {
                key = "Item 1",
                name = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}