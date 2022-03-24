using Android.Content;
using Android.Widget;
using find_all_here.csharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static find_all_here.csharp.Tables;

namespace find_all_here
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        public async void BtnHome_Clicked(object sender, EventArgs e)
        {
            
        }

        public async void BtnSearch_Clicked(object sender, EventArgs e)
        {

        }
        public async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            String response = db.Connect("SELECT * FROM USERS", null, "one");
            ClsUsers users = JsonConvert.DeserializeObject<ClsUsers>(response);

            await DisplayAlert("API de Base de Datos", "Codigo: " + users.Status + (users.Status == 200 ? "OK": "ERROR"), "OK");
        }
        public async void BtnInbox_Clicked(object sender, EventArgs e)
        {

        }
        public async void BtnProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new User());
        }
    }
}
