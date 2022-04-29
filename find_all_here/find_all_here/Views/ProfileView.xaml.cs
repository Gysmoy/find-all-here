using System;
using find_all_here.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentPage
    {
        public ProfileView(string userId = null)
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel(userId);
        }

        async void OnConfigUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UserConfig());
        }

        async void OnLogOutClicked(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            App.Current.MainPage = new LoginView();
        }
    }
    
}