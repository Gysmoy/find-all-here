using find_all_here.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagoView : ContentPage
    {
        public IList<DBCarrito> DBCarritos { get; private set; }
        public PagoView()
        {
            InitializeComponent();
            DBCarritos = new List<DBCarrito>();

            DBCarritos.Add(new DBCarrito { Name = "YAPE", Image = "yapelogo.png" });
            DBCarritos.Add(new DBCarrito { Name = "TUNKI", Image = "tunki.png" });
            DBCarritos.Add(new DBCarrito { Name = "INTERBANK", Image = "interbank.png" });

            BindingContext = this;
        }
        async void Btn_Cart(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        async void Btn_Tarjet(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PaymentTypeView.PagoTargetView());
        }
        async void Btn_Yape(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PaymentTypeView.YapeView());
        }
    }
}