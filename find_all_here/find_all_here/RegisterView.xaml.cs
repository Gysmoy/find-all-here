﻿using System;
using find_all_here.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterView : ContentPage
    {
        public RegisterView()
        {
            InitializeComponent();
            BindingContext = new RegisterViewModel();
        }

        private async void LogIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}