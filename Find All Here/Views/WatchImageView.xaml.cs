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
    public partial class WatchImageView : ContentPage
    {
        public WatchImageView()
        {
            InitializeComponent();
            // var image = (string)App.Current.Properties["image"];
            var image = "https://scriptperu.com/find_all_here/image/product/undefined/mini/abcd1234";
            imageViewer.Source = image;
        }
        async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}