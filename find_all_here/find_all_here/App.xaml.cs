using System;
using Android.App;
using Android.Widget;
using Xamarin.Forms.Xaml;
using find_all_here.Models;
using Application = Xamarin.Forms.Application;

namespace find_all_here
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override void OnStart()

        {
            var status = Properties.ContainsKey("status") ? (bool)Properties["status"] : false;
            if (status)
            {
                MainPage = new Shell();
            }
            else
            {
                MainPage = new LoginView();
            }
            
        }
        public void Logout()
        {
            Properties.Clear();
            MainPage = new LoginView();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
