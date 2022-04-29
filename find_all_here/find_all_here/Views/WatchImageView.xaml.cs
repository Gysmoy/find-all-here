using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchImageView : ContentPage
    {
        public WatchImageView()
        {
            InitializeComponent();
            var image = (string) App.Current.Properties["image"];
            imageViewer.Source = image;
        }
    }
}