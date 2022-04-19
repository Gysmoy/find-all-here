using Android.Widget;
using find_all_here.csharp;
using find_all_here.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace find_all_here.ViewModels
{
    public class HomeViewModel: BaseViewModel
    {
        private Product _selectedProduct;
        public ObservableCollection<Product> Products { get; }
        public Command LoadProductsCommand { get; }
        public Command<Product> ProductTapped { get; }
        public HomeViewModel()
        {
            Products = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
        }

        async Task ExecuteLoadProductsCommand()
        {
            Database db = new Database();
            String sp = StoredProcedures.GetAllProducts;
            String[] parameters = { };
            String response = db.Connect(sp, parameters, "all");
            Products products = JsonConvert.DeserializeObject<Products>(response);
            Toast.MakeText(Android.App.Application.Context, products.Message, ToastLength.Short).Show();
            if (products.Status == 200)
            {
                Product product = products.Data[0];
                Toast.MakeText(Android.App.Application.Context, JsonConvert.SerializeObject(product), ToastLength.Short).Show();
                /*
                foreach (Product product in products.Data)
                {
                    // mostrar 
                    Debug.WriteLine(JsonConvert.SerializeObject(product));
                }*/
            } else
            {
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedProduct = null;
        }
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                SetProperty(ref _selectedProduct, value);
                OnProductSelected(value);
            }
        }
        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync($"product_edit?{nameof(Product.Id)}");
        }
        async void OnProductSelected(Product product)
        {
            if (product == null)
                return;
            await Shell.Current.GoToAsync($"product_edit?{nameof(Product.Id)}={product.Id}");
        }
    }
}
