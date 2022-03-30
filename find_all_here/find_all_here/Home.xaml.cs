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
using System.Windows.Input;
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

        public async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //Database db = new Database();
            //String response = db.Connect("SELECT * FROM USERS", null, "one");
            //ClsUsers users = JsonConvert.DeserializeObject<ClsUsers>(response);

            //await DisplayAlert("API de Base de Datos", "Codigo: " + users.Status + (users.Status == 200 ? "OK": "ERROR"), "OK");
            Routing.RegisterRoute($"{nameof(Users)}", typeof(Users));
            await Shell.Current.GoToAsync($"{nameof(Users)}");
        }
    }
}
