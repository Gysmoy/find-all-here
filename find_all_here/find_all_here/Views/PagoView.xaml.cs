﻿using find_all_here.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using find_all_here.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagoView : ContentPage
    {
        public IList<CartViewModel> DBCarritos { get; private set; }
        public PagoView()
        {
            InitializeComponent();
            /*DBCarritos = new List<CartViewModel>();

            DBCarritos.Add(new CartViewModel { Name = "YAPE", Image = "yapelogo.png" });
            DBCarritos.Add(new CartViewModel { Name = "TUNKI", Image = "tunki.png" });
            DBCarritos.Add(new CartViewModel { Name = "INTERBANK", Image = "interbank.png" });

            BindingContext = this;*/
            decimal Total = 0;
            var cart = (Cart) App.Current.Properties["cart"];
            foreach (var product in cart.Products)
            {
                Total += decimal.Parse(product.Total_price);
            }

        }
        async void Btn_Cart(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void Btn_Tarjet(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PaymentTypeView.PagoTargetView());
        }
        async void Btn_Yape(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PaymentTypeView.YapeView());
        }
    }
}