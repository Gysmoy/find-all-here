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
        async void ir(object sender, EventArgs e)
        {
            // Abrir APago.xaml como modal
            await Navigation.PushModalAsync(new APago());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _homeViewModel.OnAppearing();
        }
    }
}
