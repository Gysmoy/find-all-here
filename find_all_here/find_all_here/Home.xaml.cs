using find_all_here.ViewModels;
using System;
using Xamarin.Forms;

namespace find_all_here
{
    public partial class Home : ContentPage
    {
        HomeViewModel _viewModel;
        public Home()
        {
            InitializeComponent();
            BindingContext = _viewModel = new HomeViewModel();
        }
        async void Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        public async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            //Database db = new Database();
            //String response = db.Connect("SELECT * FROM USERS", null, "one");
            //ClsUsers users = JsonConvert.DeserializeObject<ClsUsers>(response);

            //await DisplayAlert("API de Base de Datos", "Codigo: " + users.Status + (users.Status == 200 ? "OK": "ERROR"), "OK");
            Routing.RegisterRoute($"{nameof(Users)}", typeof(Users));

            // simular el comportamiento de un shelContent
            await Shell.Current.GoToAsync($"{nameof(Users)}");
        }
    }
}
