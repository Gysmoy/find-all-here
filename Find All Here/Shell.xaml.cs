using Find_All_Here.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Find_All_Here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shell : Xamarin.Forms.Shell
    {
        public Shell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddProductView), typeof(AddProductView));
            Routing.RegisterRoute(nameof(ProfileView), typeof(ProfileView));
        }
    }
}
