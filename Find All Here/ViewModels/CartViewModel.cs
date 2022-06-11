using Find_All_Here.Models;
using Find_All_Here.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Find_All_Here.ViewModels
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

        public CartViewModel()
        {
            Title = "Carrito de compras";

            BindingProducts = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(ExecuteLoadProductsCommand);
            CloseCartCommand = new Command(ExecuteCloseCartCommand);
            RemoveProductCommand = new Command<Product>(ExecuteRemoveProductCommand);
            IncreaseProductCommand = new Command<Product>(ExecuteIncreaseProductCommand);
            DecreaseProductCommand = new Command<Product>(ExecuteDecreaseProductCommand);
            PaymentCommand = new Command(ExecutePaymentCommand);

            ExecuteLoadProductsCommand();
        }

        private async void ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            try
            {
                BindingProducts.Clear();
                var cart = JsonConvert.DeserializeObject<Cart>((string) App.Current.Properties["cart"]);
                var products = cart.Products;
                foreach (var product in products)
                {
                    product.Total_price = "S/" + product.Sale_price * product.Quantity;
                    BindingProducts.Add(product);
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar");
                return;
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
        private async void ExecuteRemoveProductCommand(Product product)
        {
            IsBusy = true;

            try
            {
                var cart = JsonConvert.DeserializeObject<Cart>((string)App.Current.Properties["cart"]);
                foreach (var p in cart.Products.Where(p => p.Id == product.Id))
                {
                    cart.Products.Remove(p);
                    break;
                }
                App.Current.Properties["cart"] = JsonConvert.SerializeObject(cart);
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar");
                return;
            }
            finally
            {
                ExecuteLoadProductsCommand();
                IsBusy = false;
            }
        }
        private async void ExecuteIncreaseProductCommand(Product product)
        {
            IsBusy = true;

            try
            {
                var cart = JsonConvert.DeserializeObject<Cart>((string)App.Current.Properties["cart"]);
                cart.Products.FirstOrDefault(p => p.Id == product.Id).Quantity++;
                cart.Products.FirstOrDefault(p => p.Id == product.Id).Total_price
                    = "S/"
                        + cart.Products.FirstOrDefault(p => p.Id == product.Id).Sale_price
                        * cart.Products.FirstOrDefault(p => p.Id == product.Id).Quantity;
                App.Current.Properties["cart"] = JsonConvert.SerializeObject(cart);
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar");
                return;
            }
            finally
            {
                ExecuteLoadProductsCommand();
                IsBusy = false;
            }
        }
        private async void ExecuteDecreaseProductCommand(Product product)
        {
            IsBusy = true;

            try
            {
                var cart = JsonConvert.DeserializeObject<Cart>((string)App.Current.Properties["cart"]);
                cart.Products.FirstOrDefault(p => p.Id == product.Id).Quantity--;
                cart.Products.FirstOrDefault(p => p.Id == product.Id).Total_price
                    = "S/"
                        + cart.Products.FirstOrDefault(p => p.Id == product.Id).Sale_price
                        * cart.Products.FirstOrDefault(p => p.Id == product.Id).Quantity;
                App.Current.Properties["cart"] = JsonConvert.SerializeObject(cart);
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar");
                return;
            }
            finally
            {
                ExecuteLoadProductsCommand();
                IsBusy = false;
            }
        }

        private void ExecutePaymentCommand()
        {
            Application.Current.MainPage.Navigation.PushAsync(new PaymentView());
        }
    }
}
