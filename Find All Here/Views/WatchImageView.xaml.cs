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
            var image = (string) App.Current.Properties["image"];
            var name = (string) App.Current.Properties["name"];
            imageViewer.Source = image;
            nameViewer.Text = name;
        }
        async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}