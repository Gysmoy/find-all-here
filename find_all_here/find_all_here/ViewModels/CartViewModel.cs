using System;
using System.Collections.ObjectModel;
using System.Linq;
using Android.Widget;
using find_all_here.Models;
using Xamarin.Forms;

namespace find_all_here.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        private Product _selectedProduct;
        public ObservableCollection<Product> BindingProducts { get; set; }
        public Command LoadProductsCommand { get; }
        public Command CloseCartCommand { get; }
        public Command<Product> RemoveProductCommand { get; }
        public Command<Product> IncreaseProductCommand { get; }
        public Command<Product> DecreaseProductCommand { get; }
        public Command PaymentCommand { get; }
        public decimal Subtotal { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        
        public CartViewModel()
        {
            Title = "Carrito de compras";
            Subtotal = 0;
            Igv = 0;
            Total = 0;
            BindingProducts = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(ExecuteLoadProductsCommand);
            CloseCartCommand = new Command(ExecuteCloseCartCommand);
            RemoveProductCommand = new Command<Product>(ExecuteRemoveProductCommand);
            IncreaseProductCommand = new Command<Product>(ExecuteIncreaseProductCommand);
            DecreaseProductCommand = new Command<Product>(ExecuteDecreaseProductCommand);
            PaymentCommand = new Command(ExecutePaymentCommand);
            ExecuteLoadProductsCommand();
        }

        private void ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                BindingProducts.Clear();
                var cart = (Cart) App.Current.Properties["cart"];
                var products = cart.Products;
                Total = 0;
                foreach (var product in products)
                {
                    product.Total_price = "S/" + product.Sale_price * product.Quantity;
                    Total += product.Sale_price * product.Quantity;
                    BindingProducts.Add(product);
                }
                Igv = decimal.Round(Total * decimal.Parse("0.18"), 2);
                Subtotal = decimal.Round(Total - Igv, 2);
                Total = decimal.Round(Total, 2);
            }
            catch (Exception e)
            {
                Toast.MakeText(Android.App.Application.Context, e.Message, ToastLength.Long).Show();
            }
            finally
            {
                IsBusy = false;
            }
        }
        private static async void ExecuteCloseCartCommand()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
        private void ExecuteRemoveProductCommand(Product product)
        {
            IsBusy = true;

            try
            {
                var cart = (Cart) App.Current.Properties["cart"];
                foreach (var p in cart.Products.Where(p => p.Id == product.Id))
                {
                    cart.Products.Remove(p);
                    break;
                }
                App.Current.Properties["cart"] = cart;
            }
            catch (Exception e)
            {
                Toast.MakeText(Android.App.Application.Context, e.Message, ToastLength.Short).Show();
            }
            finally
            {
                ExecuteLoadProductsCommand();
                IsBusy = false;
            }
        }
        private void ExecuteIncreaseProductCommand(Product product)
        {
            IsBusy = true;

            try
            {
                var cart = (Cart) App.Current.Properties["cart"];
                cart.Products.FirstOrDefault(p => p.Id == product.Id).Quantity++;
                cart.Products.FirstOrDefault(p => p.Id == product.Id).Total_price
                    = "S/"
                        + cart.Products.FirstOrDefault(p => p.Id == product.Id).Sale_price
                        * cart.Products.FirstOrDefault(p => p.Id == product.Id).Quantity;
                App.Current.Properties["cart"] = cart;
            }
            catch (Exception e)
            {
                Toast.MakeText(Android.App.Application.Context, e.Message, ToastLength.Short).Show();
            }
            finally
            {
                ExecuteLoadProductsCommand();
                IsBusy = false;
            }
        }
        private void ExecuteDecreaseProductCommand(Product product)
        {
            IsBusy = true;

            try
            {
                var cart = (Cart) App.Current.Properties["cart"];
                cart.Products.FirstOrDefault(p => p.Id == product.Id).Quantity--;
                cart.Products.FirstOrDefault(p => p.Id == product.Id).Total_price
                    = "S/" 
                        + cart.Products.FirstOrDefault(p => p.Id == product.Id).Sale_price
                        * cart.Products.FirstOrDefault(p => p.Id == product.Id).Quantity;
                App.Current.Properties["cart"] = cart;
            }
            catch (Exception e)
            {
                Toast.MakeText(Android.App.Application.Context, e.Message, ToastLength.Short).Show();
            }
            finally
            {
                ExecuteLoadProductsCommand();
                IsBusy = false;
            }
        }

        private void ExecutePaymentCommand()
        {
            Application.Current.MainPage.Navigation.PushAsync(new PagoView());
        }
    }
}
