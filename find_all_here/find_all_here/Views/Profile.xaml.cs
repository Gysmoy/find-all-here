﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.Util;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }
        async void Ir(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserConfig());
        }

        async void Logout_btn(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            App.Current.MainPage = new LoginView();
        } 
       

    }
    
}