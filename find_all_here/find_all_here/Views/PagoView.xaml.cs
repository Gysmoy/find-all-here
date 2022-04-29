using find_all_here.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using find_all_here.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagoView : ContentPage
    {
        public PagoView()
        {
            InitializeComponent();
            var cart = (Cart) Application.Current.Properties["cart"];
            cart.Total = 0;
            foreach (var product in cart.Products)
            {
                var price = product.Sale_price;
                var quantity = product.Quantity;
                cart.Total += price * quantity;
            }
            var igv = cart.Total * (decimal)0.18;
            var subtotal = cart.Total - igv;
            
            var user = (User) App.Current.Properties["user"];
            
            // Variables
            var guid = Guid.NewGuid();
            img_mini.Source = "https://scriptperu.com/find_all_here/image/user/" + user.Id + "/mini/" + guid.ToString();
            lbl_nombre.Text = "Hola, " + user.Names;
            txt_igv.Text = "S/" + igv;
            txt_subtotal.Text = "S/" + subtotal;
            txt_total.Text = "S/" + cart.Total;
        }

        private void OnRegisterSale(object sender, EventArgs e)
        {
            Toast.MakeText(Android.App.Application.Context, "La compra ha sido registrada correctamente", ToastLength.Short).Show();
        }
    }
}