using Find_All_Here.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Find_All_Here.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentView : ContentPage
    {
        public PaymentView()
        {
            InitializeComponent();
            var cart = (Cart)Application.Current.Properties["cart"];
            cart.Total = 0;
            foreach (var product in cart.Products)
            {
                var price = product.Sale_price;
                var quantity = product.Quantity;
                cart.Total += price * quantity;
            }
            var igv = cart.Total * (decimal)0.18;
            var subtotal = cart.Total - igv;

            var user = (User)App.Current.Properties["user"];

            // Variables
            var guid = Guid.NewGuid();
            img_mini.Source = "https://scriptperu.com/find_all_here/image/user/" + user.Id + "/mini/" + guid.ToString();
            lbl_nombre.Text = "Hola, " + user.Names;
            txt_igv.Text = "S/" + igv;
            txt_subtotal.Text = "S/" + subtotal;
            txt_total.Text = "S/" + cart.Total;
        }

        private async void OnRegisterSale(object sender, EventArgs e)
        {
            await App.Current.MainPage.DisplayAlert(
                "Error!",
                "La compra ha sido registrada correctamente",
                "Aceptar"
            );
        }
    }
}