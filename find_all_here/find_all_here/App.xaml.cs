using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using find_all_here.Models;

namespace find_all_here
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Shell();
            //MainPage = new NavigationPage(new HomeView());
        }

        protected override void OnStart()
        {
            // Abrir loginView como primeiro view
            
            // Comprobar si el usuario a iniciado sesión
            /*if (string.IsNullOrEmpty(Settings.UserId))
            {*/
                MainPage = new LoginView();
            /*}
            else
            {
                MainPage = new NavigationPage(new Shell());
            }*/
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
