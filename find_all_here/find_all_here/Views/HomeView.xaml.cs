using find_all_here.ViewModels;
using System;
using Xamarin.Forms;

namespace find_all_here
{
    public partial class HomeView : ContentPage
    {
        HomeViewModel _homeViewModel;
        public HomeView()
        {
            InitializeComponent();
            BindingContext = _homeViewModel = new HomeViewModel();
        }
        
        async void Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginView());
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _homeViewModel.OnAppearing();
        }
        private void OnLogOutClicked(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            App.Current.MainPage = new LoginView();
        }
    }
}
