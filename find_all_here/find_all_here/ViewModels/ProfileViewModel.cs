using Android.Widget;
using find_all_here.csharp;
using find_all_here.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace find_all_here.ViewModels
{
    public class ProfileViewModel: BaseViewModel
    {
        private string names;
        private string surnames;
        private string username;
        private string email;
        private string gender;
        private string address;
        private string phone;
        private string profile_mini;
        private string profile_full;

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
        public Task LoadUserId(string userId)
        {
            try
            {
                User user = new User();
                if (userId == null)
                {
                    user = (User) App.Current.Properties["user"];
                    Id = user.Id.ToString();
                    Names = user.Names;
                    Surnames = user.Surnames;
                    Username = user.Username;
                    Email = user.Email;
                    Gender = user.Gender;
                    Address = user.Address;
                    Phone = user.Phone;
                    Guid guid = Guid.NewGuid();
                    Profile_mini = "https://scriptperu.com/find_all_here/image/user/" + user.Id + "/mini/" + guid.ToString();
                    Profile_full = "https://scriptperu.com/find_all_here/image/user/" + user.Id + "/full/" + guid.ToString();
                }
                else
                {
                    Database db = new Database();
                    string sp = StoredProcedures.GetUserById;
                    string[] parameters = { userId };
                    string response = db.Connect(sp, parameters, "one");
                    var userValidate = JsonConvert.DeserializeObject<UserValidate>(response);

                }
            } catch (Exception e)
            {
               
                Toast.MakeText(Android.App.Application.Context, e.Message, ToastLength.Short).Show();
            }
            return Task.CompletedTask;
        }

        public ProfileViewModel()
        {
            var userId = App.Current.Properties.ContainsKey("userId") ? (string) App.Current.Properties["userId"] : null;
            Toast.MakeText(Android.App.Application.Context, userId, ToastLength.Short).Show();
            LoadUserId(userId);
        }
    }
}
