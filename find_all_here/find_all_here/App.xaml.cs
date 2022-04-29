﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Xamarin.Forms.Xaml;
using find_all_here.Models;
using Newtonsoft.Json;
using Application = Xamarin.Forms.Application;

namespace find_all_here
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override void OnStart()

        {
            /* Creando carrito */
            if (!Properties.ContainsKey("cart"))
            {
                Cart cart = new Cart();
                cart.Products = new List<Product>();
                Properties["cart"] = cart;
            }
            var user = Properties.ContainsKey("user") ? (User) Properties["user"] : new User();
            if (user.Status)
            {
                MainPage = new Shell();
            }
            else
            {
                Properties.Clear();
                MainPage = new LoginView();
            }
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
