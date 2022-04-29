using Android.Widget;
using find_all_here.csharp;
using find_all_here.Models;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using static Android.Content.ClipData;

namespace find_all_here.ViewModels
{
    
    public class UpdateDataUserViewModel : BaseViewModel, INotifyPropertyChanged
    {
        
        public string names;
        public string surnames;
        public string email;
        public string phone;
        public string gender;
        public int dateDay;
        public int dateMonth;
        public int dateYear;
        public string address;
        public string username;
        public string password;
        public string profile_full;

        // Booleaos
        public bool isRunning;
        public bool isEnabled;
        public bool isVisible;

        public string Txt_Names
        {
            get { return this.names; }
            set { SetProperty(ref this.names, value);
               }
        }
        public string Txt_Surnames
        {
            get { return this.surnames; }
            set { SetProperty(ref this.surnames, value);
                
            }
        }
        public string Txt_Email
        {
            get { return this.email; }
            set { SetProperty(ref this.email, value); }
        }

        public string Txt_Phone
        {
            get { return this.phone; }
            set { SetProperty(ref this.phone, value); }
        }
        public string Txt_Gender
        {
            get { return this.gender; }
            set { SetProperty(ref this.gender, value); }
        }
        public int Txt_DateDay
        {
            get { return this.dateDay; }
            set { SetProperty(ref this.dateDay, value); }
        }
        public int Txt_DateMonth
        {
            get { return this.dateMonth; }
            set { SetProperty(ref this.dateMonth, value); }
        }
        public int Txt_DateYear
        {
            get { return this.dateYear; }
            set { SetProperty(ref this.dateYear, value); }
        }
        public string Txt_Address
        {
            get { return this.address; }
            set { SetProperty(ref this.address, value); }
        }

        public string Txt_Username
        {
            get { return this.username; }
            set { SetProperty(ref this.username, value); }
        }
        public string Txt_Password
        {
            get { return this.password; }
            set { SetProperty(ref this.password, value); }
        }
        public string Profile_mini
        {
            get { return this.profile_full; }
            set { SetProperty(ref this.profile_full, value); }
        }


        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetProperty(ref this.isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetProperty(ref this.isEnabled, value); }
        }
        public bool IsVisible
        {
            get { return this.isVisible; }
            set { SetProperty(ref this.isVisible, value); }
        }


        

        public async void LoadDateUser()
        {
            try
            {
                User user =  (User) App.Current.Properties["user"];
                string[] date = user.Birth_date.Split('-');
                var year = date[0];
                var month = date[1];
                var day = date[2];
                Txt_Names = user.Names;
                Txt_Surnames = user.Surnames;
                Txt_Email = user.Email;
                Txt_Phone = user.Phone;
                Txt_Gender = user.Gender;
                Txt_DateDay = Int32.Parse(day);
                Txt_DateMonth = Int32.Parse(month);
                Txt_DateYear = Int32.Parse(year);
                Txt_Address = user.Address;
                Txt_Username = user.Username;
                Profile_mini = "https://scriptperu.com/find_all_here/image/user/" + user.Id + "/full/ww";



                Toast.MakeText(
                            Android.App.Application.Context,
                            "Hola "+user.Names,
                            ToastLength.Long
                        ).Show();
                return;


            }
            catch (Exception e)
            {
                Toast.MakeText(
                             Android.App.Application.Context,
                             "No se puede listar los datos" + e.Message,
                             ToastLength.Long
                         ).Show();
                return;
            }
        }
        // commands

        public ICommand Update_Data_User
        {
            get
            {
                return new RelayCommand(UpdateUserMethod);
            }
        }

       


        public async void UpdateUserMethod()
        {
            try
            {

                User miusuario = JsonConvert.DeserializeObject<User>((string)App.Current.Properties["user"]);
                if(string.IsNullOrEmpty(this.names) || 
                    string.IsNullOrEmpty(this.surnames) ||
                    string.IsNullOrEmpty(this.username) ||
                    string.IsNullOrEmpty(this.email) ||
                    string.IsNullOrEmpty(this.gender) ||
                    string.IsNullOrEmpty((this.dateDay).ToString()) ||
                    string.IsNullOrEmpty((this.dateMonth).ToString()) ||
                    string.IsNullOrEmpty((this.dateYear).ToString()) ||
                    string.IsNullOrEmpty(this.address) ||
                    string.IsNullOrEmpty(this.phone) 
                    )
                {
                    Toast.MakeText(
                         Android.App.Application.Context,
                         "Rellene todos los campos para continuar",
                         ToastLength.Long
                     ).Show();
                    return;
                }
                else
                {

                    if (string.IsNullOrEmpty(this.password))
                    {
                        Toast.MakeText(
                              Android.App.Application.Context,
                              "Ingrese su contraseña para poder actualizar sus datos",
                              ToastLength.Long
                          ).Show();
                        return;
                    }
                    else
                    {
                        if (Sha256(this.password) == miusuario.Password)
                        {

                            var idUser = miusuario.Id;
                            var birth_date = Convert.ToString(this.dateYear) + '-' + Convert.ToString(this.dateMonth) + '-' + Convert.ToString(this.dateDay);

                            var db = new Database();
                            var sp = StoredProcedures.UpdateUser;
                            string[] parameters = {
                                this.names,
                                this.surnames,
                                this.username,
                                this.email,
                                this.gender,
                                birth_date,
                                this.address,
                                this.phone,
                                idUser.ToString(),

                            };
                            var responseStr = db.Connect(sp, parameters, "result");
                            var response = JsonConvert.DeserializeObject<Response>(responseStr);
                            if (response.Data)
                            {
                                Toast.MakeText(
                                    Android.App.Application.Context,
                                    "Sus datos fueron actualizados",
                                    ToastLength.Long
                                ).Show();
                                return;
                            }
                        }
                        else
                        {
                            Toast.MakeText(
                                  Android.App.Application.Context,
                                  "contraseña incorrecta ",
                                  ToastLength.Short
                              ).Show();
                        }
                    
                    }
                    

                }
            }
            catch (Exception e)
            {
                Toast.MakeText(
                  Android.App.Application.Context,
                  e.Message,
                  ToastLength.Short
              ).Show();
            }
        }

        public UpdateDataUserViewModel()
        {
              LoadDateUser();
           

            this.isEnabled = true;
            this.isVisible = false;
            this.isRunning = false;
        }

       // User user = JsonConvert.DeserializeObject<User>((string)App.Current.Properties["user"]);

        
    }
}
