using Android.Widget;
using find_all_here.csharp;
using find_all_here.Models;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace find_all_here.ViewModels
{
    internal class UpdateDataUserViewModel: BaseViewModel
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

        // Booleaos
        public bool isRunning;
        public bool isEnabled;
        public bool isVisible;

        public string Txt_Names
        {
            get { return this.names; }
            set { SetProperty(ref this.names, value); }
        }
        public string Txt_Surnames
        {
            get { return this.surnames; }
            set { SetProperty(ref this.surnames, value); }
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
                if (Sha256(this.password) == miusuario.Password)
                {

                    var idUser = miusuario.Id;
                    var birth_date = Convert.ToString(this.dateDay) + '-' + Convert.ToString(this.dateMonth) + '-' + Convert.ToString(this.dateYear);

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
                            responseStr,
                            ToastLength.Long
                        ).Show();
                        return;
                    }
                }
                else
                {
                    Toast.MakeText(
                          Android.App.Application.Context,
                          "contraseña incorrecta " + miusuario.Password,
                          ToastLength.Short
                      ).Show();
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
            this.isEnabled = true;
            this.isVisible = false;
            this.isRunning = false;
        }
    }
}
