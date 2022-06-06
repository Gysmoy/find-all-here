using Find_All_Here.Models;
using Find_All_Here.RestClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Find_All_Here.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        #region BindingUser
        private string id;
        private string names;
        private string surnames;
        private string username;
        private string email;
        private string gender;
        private string address;
        private string phone;
        private string profile_mini;
        private string profile_full;
        private bool btnCloseVisible;
        private bool btnFollowVisible;
        private bool btnCompraVentaVisible;
        private string btnProductsTxt;
        private int btnProductsColSpan;
        public Command<string> UserFollowCommand { get; }
        public Command CloseProfileCommand { get; }
        #endregion

        public string Id { get; set; }
        public string Names
        {
            get => names;
            set => SetProperty(ref names, value);
        }
        public string Surnames
        {
            get => surnames;
            set => SetProperty(ref surnames, value);
        }
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }
        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }
        public string Profile_mini
        {
            get => profile_mini;
            set => SetProperty(ref profile_mini, value);
        }
        public string Profile_full
        {
            get => profile_full;
            set => SetProperty(ref profile_full, value);
        }
        public bool BtnCloseVisible
        {
            get => btnCloseVisible;
            set => SetProperty(ref btnCloseVisible, value);
        }
        public bool BtnFollowVisible
        {
            get => btnFollowVisible;
            set => SetProperty(ref btnFollowVisible, value);
        }
        public bool BtnCompraVentaVisible
        {
            get => btnCompraVentaVisible;
            set => SetProperty(ref btnCompraVentaVisible, value);
        }
        public string BtnProductsTxt
        {
            get => btnProductsTxt;
            set => SetProperty(ref btnProductsTxt, value);
        }
        public int BtnProductsColSpan
        {
            get => btnProductsColSpan;
            set => SetProperty(ref btnProductsColSpan, value);
        }

        #region BindingProducts
        public ObservableCollection<Product> BindingProducts { get; }
        public Command LoadProductsCommand { get; }
        #endregion


        public ProfileViewModel()
        {
            // Constructor Usuario
            var userId = App.Current.Properties.ContainsKey("userId") ? (string)App.Current.Properties["userId"] : null;
            LoadUserId(userId);
            CloseProfileCommand = new Command(async () => await OnCloseProfile());
            UserFollowCommand = new Command<string>(OnUserFollow);

            // Contructor Productos
            BindingProducts = new ObservableCollection<Product>();
            LoadProductsCommand = new Command(async () => await OnLoadProducts());
            OnLoadProducts();
        }
        private async Task OnCloseProfile()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private async void OnUserFollow(string userId)
        {
            await App.Current.MainPage.DisplayAlert(
                "Correcto!",
                "Ahora sigues a este usuario",
                "Aceptar");
        }
        public async Task LoadUserId(string userId)
        {
            try
            {
                var user = new User();
                if (userId == null)
                {
                    user = (User)App.Current.Properties["user"];
                    BtnCloseVisible = false;
                    BtnFollowVisible = false;
                    BtnCompraVentaVisible = true;
                    BtnProductsTxt = "Mis productos";
                    BtnProductsColSpan = 1;
                }
                else
                {
                    var db = new Database();
                    var sp = StoredProcedures.GetUserById;
                    string[] parameters = { userId };
                    var response = db.Connect(sp, parameters, "one");
                    var userValidate = JsonConvert.DeserializeObject<UserValidate>(response);
                    if (userValidate.Data.Count != 0)
                    {
                        user = userValidate.Data[0];
                        BtnCloseVisible = true;
                        BtnFollowVisible = true;
                        BtnCompraVentaVisible = false;
                        BtnProductsTxt = "Productos de " + user.Names;
                        BtnProductsColSpan = 3;
                    }
                    else
                    {
                        throw new Exception("No se encontró este usuario");
                    }
                }
                Id = user.Id.ToString();
                Names = user.Names;
                Surnames = user.Surnames;
                Username = user.Username;
                Email = user.Email;
                Gender = user.Gender;
                Address = user.Address;
                Phone = user.Phone;
                var guid = Guid.NewGuid();
                Profile_mini = "https://scriptperu.com/find_all_here/image/user/" + user.Id + "/mini/" + guid.ToString();
                Profile_full = "https://scriptperu.com/find_all_here/image/user/" + user.Id + "/full/" + guid.ToString();
            }
            catch (Exception e)
            {
                try { await App.Current.MainPage.Navigation.PopModalAsync(); } catch (Exception) { }
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar");
            }
        }
        public async Task OnLoadProducts()
        {
            try
            {
                var db = new Database();
                var sp = StoredProcedures.GetProductsByUserId;
                string[] parameters = { Id };
                var response = db.Connect(sp, parameters, "all");
                var products = JsonConvert.DeserializeObject<ListaProducts>(response);
                if (products.Data.Count != 0)
                {
                    foreach (var productDetail in products.Data)
                    {
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
                    throw new Exception("No se encontraron productos");
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
    }
}
