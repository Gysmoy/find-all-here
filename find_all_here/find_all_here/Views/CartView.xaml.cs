﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using find_all_here.ViewModels;

namespace find_all_here
{
    public partial class CartView : ContentPage
    {
        CartViewModel _cartViewModel;
        
        public CartView()
        {
            InitializeComponent();
            BindingContext = _cartViewModel = new CartViewModel();
            
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as CartViewModel;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = e.Item as CartViewModel;
        }

        async void Btn_Home(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Btn_Pago(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PagoView());
        }
    }
}