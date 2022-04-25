using Android.Widget;
using find_all_here.csharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Android;
using Xamarin.Forms;
using find_all_here.Models;

namespace find_all_here.ViewModels
{
    public class HomeViewModel: BaseViewModel
    {
        private Product _selectedProduct;
        public ObservableCollection<Product> BindingProducts { get; }
        public Command LoadProductsCommand { get; }
        public Command AddProductCommand { get; }
        public Command<Product> ProductTapped { get; }
        public HomeViewModel()
        {
            Title = "Find All Here";
            BindingProducts = new ObservableCollection<Product>();
            ProductTapped = new Command<Product>(OnProductSelected);
            AddProductCommand = new Command(OnAddProduct);
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
            ExecuteLoadProductsCommand();
        }

        Task ExecuteLoadProductsCommand()
        {
            IsBusy = true;
            try
            {
                BindingProducts.Clear();
                Database db = new Database();
                string sp = StoredProcedures.GetAllProducts;
                string response = db.Connect(sp, null, "all");
                ListaProducts listaProducts = JsonConvert.DeserializeObject<ListaProducts>(response);
                Toast.MakeText(Android.App.Application.Context, listaProducts.Message, ToastLength.Short).Show();
                if (listaProducts.Status == 200)
                {
                    foreach (ProductDetail productDetail in listaProducts.Data)
                    {
                        Product product = productDetail;
                        product.Percent = (1 - (product.Sale_price / product.Purchase_price)) * -100;
                        product.Relative_Percent = (product.Percent > 1) ? "+" + product.Percent + "%": "" + product.Percent + "%";
                        product.Color_percent = (product.Percent > 1) ? "#fc424a" : "#00d25b";
                        product.Relative_time = GetRelativeTime(productDetail.Update_date);

                        Brand brand = new Brand
                        {
                            Id = productDetail.B_id,
                            Name = productDetail.B_name,
                            Status = productDetail.B_status
                        };
                        product.Brand = brand;

                        Category category = new Category
                        {
                            Id = productDetail.C_id,
                            Name = productDetail.C_name,
                            Status = productDetail.C_status
                        };
                        product.Category = category;

                        User user = new User
                        {
                            Id = productDetail.U_id,
                            Names = productDetail.U_names,
                            Surnames = productDetail.U_surnames,
                            Username = productDetail.U_username,
                            Email = productDetail.U_email,
                            Gender = productDetail.U_gender,
                            Address = productDetail.U_address,
                            Phone = productDetail.U_phone,
                            Profile_mini = "https://scriptperu.com/find_all_here/image/user/" + productDetail.U_id + "/mini",
                            Profile_full = "https://scriptperu.com/find_all_here/image/user/" + productDetail.U_id + "/full",
                        };
                        product.User = user;
                        
                        BindingProducts.Add(product);
                        BindingProducts.Add(product);
                    }
                } else
                {
                    Toast.MakeText(Android.App.Application.Context, listaProducts.Message, ToastLength.Short).Show();
                }
            } catch (Exception e)
            {
                Toast.MakeText(Android.App.Application.Context, e.Message, ToastLength.Short).Show();
            } finally
            {
                IsBusy = false;
            }

            return Task.CompletedTask;
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
        private async void OnAddProduct(object obj)
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
