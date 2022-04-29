using Android.Widget;
using find_all_here.csharp;
using find_all_here.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace find_all_here.ViewModels
{
    public class ProfileViewModel: BaseViewModel
    {
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

        public async Task LoadUserId(string userId)
        {
            try
            {
                var user = new User();
                if (userId == null)
                {
                    user = (User) App.Current.Properties["user"];
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
            } catch (Exception e)
            {
                try {await App.Current.MainPage.Navigation.PopModalAsync();} catch (Exception) { }
                Toast.MakeText(Android.App.Application.Context, e.Message, ToastLength.Short).Show();
            }
        }

        public ProfileViewModel()
        {
            var userId = App.Current.Properties.ContainsKey("userId") ? (string) App.Current.Properties["userId"] : null;
            LoadUserId(userId);
            CloseProfileCommand = new Command(async () => await OnCloseProfile());
            UserFollowCommand = new Command<string>(OnUserFollow);
        }

        private async Task OnCloseProfile()
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }
        private void OnUserFollow(string userId)
        {
            Toast.MakeText(Android.App.Application.Context, "Ahora sigues a este usuario", ToastLength.Short).Show();
        }

    }
}
