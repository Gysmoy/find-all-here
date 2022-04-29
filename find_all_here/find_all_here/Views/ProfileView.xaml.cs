using System;
using find_all_here.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentPage
    {
        public ProfileView()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
        }

        async void OnConfigUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UserConfig());
        }

        void OnLogOutClicked(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            App.Current.MainPage = new LoginView();
        }
    }
    
}