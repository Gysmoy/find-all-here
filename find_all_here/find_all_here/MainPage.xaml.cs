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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            String response = db.Connect("SELECT * FROM USERS", null, "one");
            ClsUsers users = JsonConvert.DeserializeObject<ClsUsers>(response);
            
            lbl_estado.Text = JsonConvert.SerializeObject(users.Data[0]);
        }
    }
}
