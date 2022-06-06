using Find_All_Here.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Find_All_Here.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        HomeViewModel _homeViewModel;
        public HomeView()
        {
            InitializeComponent();
            BindingContext = _homeViewModel = new HomeViewModel();
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