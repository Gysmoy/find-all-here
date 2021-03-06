using Find_All_Here.Models;
using Find_All_Here.Views;
using Find_All_Here.RestClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Find_All_Here.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private Product _selectedProduct;
        public ObservableCollection<Product> BindingProducts { get; }
        public Command LoadProductsCommand { get; }
        public Command AddProductCommand { get; }
        public Command OpenCartCommand { get; }
        public Command<Product> ProductTapped { get; }
        public Command<User> OpenImageUserCommand { get; }
        public Command<Product> OpenImageProductCommand { get; }

        #region ProductCommands
        public Command<Product> AddToCartCommand { get; }
        public Command<Product> OpenUserProfileCommand { get; }
        public Command<Product> OpenCommentsCommand { get; }
        #endregion

        public HomeViewModel()
        {
            Title = "Find All Here";
            BindingProducts = new ObservableCollection<Product>();
            ProductTapped = new Command<Product>(OnProductSelected);
            AddProductCommand = new Command(OnAddProduct);
            OpenCartCommand = new Command(OnOpenCart);

            AddToCartCommand = new Command<Product>(OnAddToCart);
            OpenUserProfileCommand = new Command<Product>(OnOpenUserProfile);
            OpenCommentsCommand = new Command<Product>(OnOpenComments);
            OpenImageUserCommand = new Command<User>(OnOpenImageUser);
            OpenImageProductCommand = new Command<Product>(OnOpenImageProduct);

            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
            ExecuteLoadProductsCommand();
        }
        
        public async Task ExecuteLoadProductsCommand()
        {
            IsBusy = true;
            try
            {
                BindingProducts.Clear();
                string sp = StoredProcedures.GetAllProducts;
                string response = Database.Connect(sp, null, "all");
                ListaProducts listaProducts = JsonConvert.DeserializeObject<ListaProducts>(response);
                
                if (listaProducts.Status == 200)
                {
                    foreach (ProductDetail productDetail in listaProducts.Data)
                    {
                        //Product product = productDetail;
                        Product product = new Product();
                        product.Id = productDetail.Id;
                        product.Name = productDetail.Name;
                        product.Description = productDetail.Description;

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

                        product.Purchase_price = productDetail.Purchase_price;
                        product.Sale_price = productDetail.Sale_price;
                        product.Proportions = productDetail.Proportions;
                        product.Stock = productDetail.Stock;
                        product.Tags = productDetail.Tags;
                        Guid guid = Guid.NewGuid();
                        product.Image_mini = "https://scriptperu.com/find_all_here/image/product/" + product.Id + "/mini/" + guid.ToString();
                        product.Image_full = "https://scriptperu.com/find_all_here/image/product/" + product.Id + "/full/" + guid.ToString();
                        product.Product_status = productDetail.Product_status;

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
                            Profile_mini = "https://scriptperu.com/find_all_here/image/user/" + productDetail.U_id + "/mini/" + guid.ToString(),
                            Profile_full = "https://scriptperu.com/find_all_here/image/user/" + productDetail.U_id + "/full/" + guid.ToString(),
                        };
                        product.User = user;
                        product.Update_date = productDetail.Update_date;
                        product.Relative_time = GetRelativeTime(product.Update_date);
                        product.Percent = decimal.Round((1 - (product.Sale_price / product.Purchase_price)) * -100, 2);
                        product.Relative_Percent = (product.Percent > 1) ? "+" + product.Percent + "%" : "" + product.Percent + "%";
                        product.Color_percent = (product.Percent > 1) ? "#fc424a" : "#00d25b";
                        product.Status = productDetail.Status;

                        BindingProducts.Add(product);
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    listaProducts.Message,
                    "Aceptar");
                    return;
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

        public void OnAppearing()
        {
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
            await Shell.Current.Navigation.PushModalAsync(new AddProductView());
        }
        private async void OnOpenCart(object obj)
        {
            await Shell.Current.Navigation.PushModalAsync(new CartView());
        }

        private async static void OnAddToCart(Product product)
        {
            if (product == null) return;

            try
            {
                var cart = JsonConvert.DeserializeObject<Cart>((string)App.Current.Properties["cart"]);
                var exist = cart.Products.Any(p => p.Id == product.Id);
                if (!exist)
                {
                    product.Quantity = product.Quantity == 0 ? 1 : product.Quantity;
                    cart.Products.Add(product);
                    App.Current.Properties["cart"] = JsonConvert.SerializeObject(cart);
                    await App.Current.MainPage.DisplayAlert(
                        "Correcto!",
                        "Producto agregado al carrito",
                        "Aceptar");
                    return;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error!",
                        "Producto ya existe en el carrito",
                        "Aceptar");
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar");
            }

        }
        private async void OnOpenUserProfile(Product product)
        {
            if (product == null)
                return;
            App.Current.Properties["userId"] = product.User.Id.ToString();
            await Shell.Current.Navigation.PushModalAsync(new ProfileView());
            App.Current.Properties["userId"] = null;

        }
        private async void OnOpenImageProduct(Product product)
        {
            if (product == null)
                return;
            App.Current.Properties["image"] = product.Image_full;
            App.Current.Properties["name"] = product.Name;
            await Shell.Current.Navigation.PushModalAsync(new WatchImageView());
            App.Current.Properties["image"] = null;
            App.Current.Properties["name"] = null;
        }
        private async void OnOpenImageUser(User user)
        {
            if (user == null)
                return;
            App.Current.Properties["image"] = user.Profile_full;
            App.Current.Properties["name"] = $"{user.Names} {user.Surnames}";
            await Shell.Current.Navigation.PushModalAsync(new WatchImageView());
            App.Current.Properties["image"] = null;
            App.Current.Properties["name"] = null;
        }
        private async void OnOpenComments(object obj)
        {
            Product product = obj as Product;
            await App.Current.MainPage.DisplayAlert(
                "Error!",
                product.Description,
                "Aceptar");
        }
        async void OnProductSelected(Product product)
        {
            if (product == null)
                return;
            await Shell.Current.GoToAsync($"product_edit?{nameof(Product.Id)}={product.Id}");
        }
    }
}
