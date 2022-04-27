using System;
using System.Threading.Tasks;
using System.Windows.Input;
using find_all_here.ViewModels;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterView());
        }
    }
}