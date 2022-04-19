using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static find_all_here.csharp.Tables2;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Users : ContentPage
    {
        public IList<Activity> Activities { get; set; }

        public Users()
        {
            InitializeComponent();

            Activities = new List<Activity>();

            Activities.Add(new Activity()
            {Id = 1, Name = "Levantarse", Start = "05:00", End = "05:30"}) ;

            Activities.Add(new Activity()
            {Id = 2, Name = "Cambiarse la ropa", Start = "05:30", End = "06:00"
            });

            Activities.Add(new Activity()
            {Id = 3, Name = "Ordenar el cuarto", Start = "06:00", End = "06:45"
            });

            BindingContext = this;


            Activities.Add(new Activity()
            {
                Id = 4,
                Name = "Desayunar",
                Start = "07:00",
                End = "07:45"
            });

            Activities.Add(new Activity()
            {
                Id = 5,
                Name = "Trabajo remoto",
                Start = "08:00",
                End = "13:00"
            });

            Activities.Add(new Activity()
            {
                Id = 6,
                Name = "Almuerzo",
                Start = "13:00",
                End = "13:30"
            });

            Activities.Add(new Activity()
            {
                Id = 7,
                Name = "Clases Bloque I",
                Start = "13:30",
                End = "15:00"
            });

            Activities.Add(new Activity()
            {
                Id = 8,
                Name = "Break corto",
                Start = "15:00",
                End = "15:30"
            });

            Activities.Add(new Activity()
            {
                Id = 9,
                Name = "Clases Bloque II",
                Start = "05:00",
                End = "16:30"
            });

            Activities.Add(new Activity()
            {
                Id = 10,
                Name = "Resto el día",
                Start = "16:30",
                End = "00:00"
            });

            BindingContext = this;
        }



        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ClsUser selectedItem = e.SelectedItem as ClsUser;
        }



        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ClsUser selectedItem = e.Item as ClsUser;
        }
    }

}