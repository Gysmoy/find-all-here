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
    public partial class ACarrito : ContentPage
    {
        public IList<DBCarrito> DBCarritos { get; private set; }
        public HomeView MainPage { get; private set; }

        public ACarrito()
        {
            InitializeComponent();
            DBCarritos = new List<DBCarrito>();

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon negro de cuero",
                Precio = "S/,00,00",
                Url = "https://plazavea.vteximg.com.br/arquivos/ids/291411-450-450/image-43c8b295e4194004a74d5589a9d5d99f.jpg?v=637165299516970000"
            });

            DBCarritos.Add(new DBCarrito
            {
                name = "Sillon blanco de cuero",
                Precio = "S/,00,00",
                Url = "https://promart.vteximg.com.br/arquivos/ids/4436046-1000-1000/10012119.jpg?v=637805479991770000"
            });

            BindingContext = this;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            DBCarrito selectedItem = e.SelectedItem as DBCarrito;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            DBCarrito selectedItem = e.Item as DBCarrito;
        }

        async void Btn_Home(object sender, EventArgs e)
        {
            // cerrar el este modal
            await Navigation.PopModalAsync();
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new APago());
        }
    }
}