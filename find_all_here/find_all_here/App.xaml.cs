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
            /* INICIO: AGREGANDO PRODUCTOS */
            Cart cart = new Cart();
            Product product = new Product();
            product.Name = "Coca Cola";
            product.Price = 1.5;
            product.Quantity = 1;
            product.Image_mini = "https://www.cocacola.es/content/dam/one/es/es2/coca-cola/products/productos/dic-2021/CC_Origal.jpg";
            cart.Products.Add(product);
            product.Name = "Pepsi";
            product.Price = 1.5;
            product.Quantity = 1;
            product.Image_mini = "https://ihopperu.com/wp-content/uploads/2020/08/103181-1.jpg";
            cart.Products.Add(product);
            
            Properties["cart"] = cart;
            /* FIN: AGREGANDO PRODUCTOS */
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
