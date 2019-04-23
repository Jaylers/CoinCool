using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CoinCool.Models;

namespace CoinCool.Views
{
    public partial class NewItemPage : ContentPage
    {
        public CryptoInfo Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new CryptoInfo
            {
                key = "Key",
                name = "Name"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "Subscribe", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}