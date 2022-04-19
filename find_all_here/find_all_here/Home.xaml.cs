using find_all_here.ViewModels;
using System;
using Xamarin.Forms;

namespace find_all_here
{
    public partial class Home : ContentPage
    {
        HomeViewModel _viewModel;
        public Home()
        {
            InitializeComponent();
            BindingContext = _viewModel = new HomeViewModel();
        }
        async void Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
