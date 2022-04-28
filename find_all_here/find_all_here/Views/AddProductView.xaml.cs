using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using find_all_here.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProductView : ContentPage
    {
        public AddProductView()
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel();
        }
        async void Btn03(object sender, EventArgs e)
        {
            // cerrar el este modal
            await Navigation.PopModalAsync();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsTakePhotoSupported){
                await DisplayAlert("Error","No se soporta el cargar fotos","Cancelar");
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions{
                PhotoSize=Plugin.Media.Abstractions.PhotoSize.Small
            });
            if (file == null){
                return;
            }
            image1.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}