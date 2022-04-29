using Android.Widget;
using find_all_here.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace find_all_here.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public class ProfileViewModel: BaseViewModel
    {
        private string userId;
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
        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                LoadUserId(value);
            }
        }
        public async void LoadUserId(string userId)
        {
            Toast.MakeText(Android.App.Application.Context, userId, ToastLength.Short).Show();
            if (userId == null)
            {
                var user = (User) App.Current.Properties["user"];
                Id = user.Id.ToString();
                Names = user.Names;
                Surnames = user.Surnames;
                Username = user.Username;
                Email = user.Email;
                Gender = user.Gender;
                Address = user.Address;
                Phone = user.Phone;
                Profile_mini = user.Profile_mini;
                Profile_full = user.Profile_full;
            }
        }

        public ProfileViewModel()
        {

        }
    }
}
