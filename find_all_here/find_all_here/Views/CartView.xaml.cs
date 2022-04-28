using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using find_all_here.ViewModels;

namespace find_all_here
{
    public partial class CartView : ContentPage
    {
        public IList<CartViewModel> DBCarritos { get; private set; }
        public HomeView MainPage { get; private set; }

        public CartView()
        {
            InitializeComponent();
            DBCarritos = new List<CartViewModel>();

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new CartViewModel
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            BindingContext = this;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CartViewModel selectedItem = e.SelectedItem as CartViewModel;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            CartViewModel selectedItem = e.Item as CartViewModel;
        }

        async void Btn_Home(object sender, EventArgs e)
        {
            // cerrar el este modal
            await Navigation.PopModalAsync();
        }

        async void Btn_Pago(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PagoView());
        }
    }
}