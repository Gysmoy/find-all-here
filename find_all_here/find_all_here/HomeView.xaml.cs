﻿using find_all_here.ViewModels;
using System;
using Xamarin.Forms;

namespace find_all_here
{
    public partial class HomeView : ContentPage
    {
        HomeViewModel _viewModel;
        public HomeView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new HomeViewModel();
        }
        
        async void Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
        async void ir(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductView());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
