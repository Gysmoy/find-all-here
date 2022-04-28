using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using find_all_here.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            await Navigation.PushModalAsync(new HomeView());
        }
    }
}