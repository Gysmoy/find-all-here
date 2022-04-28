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
            var user = Properties.ContainsKey("user") ? (User)Properties["user"] : new User();
            /* INICIO: AGREGANDO PRODUCTOS 
            var cart = new Cart();
            var coca = new Product
            {
                Name = "Coca Cola",
                Price = 1.5,
                Quantity = 1,
                Image_mini = "https://www.cocacola.es/content/dam/one/es/es2/coca-cola/products/productos/dic-2021/CC_Origal.jpg"
            };
            cart.Products.Add(coca);
            var pepsi = new Product
            {
                Name = "Pepsi",
                Price = 1.5,
                Quantity = 1,
                Image_mini = "https://ihopperu.com/wp-content/uploads/2020/08/103181-1.jpg"
            };
            cart.Products.Add(pepsi);
            
            Properties["cart"] = cart;
            FIN: AGREGANDO PRODUCTOS */
            if (user.Status)
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
