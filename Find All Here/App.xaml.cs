using Find_All_Here.Models;
using Find_All_Here.RestClient;
using Find_All_Here.Views;
using Newtonsoft.Json;
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
            var user = new User();
            var cart = new Cart();
            if (Properties.ContainsKey("user"))
            {
                user = JsonConvert.DeserializeObject<User>((string) Properties["user"]);

                if (Properties.ContainsKey("cart"))
                {
                    cart = JsonConvert.DeserializeObject<Cart>((string) Properties["cart"]);
                }
            }
            Properties["user"] = JsonConvert.SerializeObject(user);
            Properties["cart"] = JsonConvert.SerializeObject(cart);

            if (user.Status)
            {
                MainPage = new Shell();
            }
            else
            {
                Properties.Clear();
                MainPage = new LoginView();
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
