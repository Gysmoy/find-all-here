using Find_All_Here.Models;
using Find_All_Here.Views;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Find_All_Here
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }
        protected override void OnStart()

        {
            if (!Properties.ContainsKey("cart"))
            {
                Cart cart = new Cart();
                cart.Products = new List<Product>();
                Properties["cart"] = cart;
            }

            var user = new User();

            if (Properties.ContainsKey("user"))
            {
                user = (User)Properties["user"];
            }
            else
            {
                Properties["user"] = user;
            }

            if (user.Status)
            {
                MainPage = new Shell();
            }
            else
            {
                Properties.Clear();
                //MainPage = new LoginView();
                MainPage = new WatchImageView();
            }

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
