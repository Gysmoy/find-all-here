using Find_All_Here.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Find_All_Here.Views
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
            await Navigation.PushModalAsync(new UserConfigView());
        }

        void OnLogOutClicked(object sender, EventArgs e)
        {
            App.Current.Properties.Clear();
            App.Current.MainPage = new LoginView();
        }
    }
}