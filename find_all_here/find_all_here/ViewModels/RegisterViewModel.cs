using System;
using Android.Widget;
using find_all_here.Models;
using Newtonsoft.Json;
using System.Windows.Input;
using find_all_here.csharp;
using GalaSoft.MvvmLight.Command;
using Java.Util;

namespace find_all_here.ViewModels
{
    public class RegisterViewModel: BaseViewModel
    {
        #region Attribute
        public string names;
        public string surnames;
        public string email;
        public string phone;
        public int dateDay;
        public int dateMonth;
        public int dateYear;
        public string username;
        public string password;
        public string confirmPassword;
        
        // Booleanos
        public bool isRunning;
        public bool isEnabled;
        public bool isVisible;
        #endregion
        
        #region Properties
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
        public string Txt_ConfirmPassword
        {
            get { return this.confirmPassword; }
            set { SetProperty(ref this.confirmPassword, value); }
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
        #endregion
        
        #region Commands
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
        }
        #endregion

        #region

        public async void RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.names))
            {
                Toast.MakeText(Android.App.Application.Context, "Ingrese su nombre", ToastLength.Short).Show();
                return;
            }

            if (string.IsNullOrEmpty(this.surnames))
            {
                Toast.MakeText(Android.App.Application.Context, "Ingrese sus apellidos", ToastLength.Short).Show();
                return;
            }

            if (string.IsNullOrEmpty(this.email))
            {
                Toast.MakeText(Android.App.Application.Context, "Ingrese su correo electrónico", ToastLength.Short).Show();
                return;
            }

            try
            {
                var db = new Database();
                var sp = StoredProcedures.ExistUser;
                string[] parameters = { this.email, this.email};
                var responseStr = db.Connect(sp, parameters, "one");
                Response response = JsonConvert.DeserializeObject<Response>(responseStr);
                if (response.Data.Count != 0)
                {
                    Toast.MakeText(
                        Android.App.Application.Context, 
                        "El correo electrónico " + this.email + " ya está registrado", 
                        ToastLength.Short
                    ).Show();
                    return;
                }
            }
            catch (Exception e)
            {
                Toast.MakeText(
                    Android.App.Application.Context, 
                    "No hay respuesta del servidor",  
                    ToastLength.Short
                ).Show();
            }

            if (string.IsNullOrEmpty(this.phone))
            {
                Toast.MakeText(Android.App.Application.Context, "Ingrese su número de teléfono", ToastLength.Short).Show();
                return;
            }

            if (
                string.IsNullOrEmpty(this.dateDay.ToString()) ||
                this.dateDay > 31 || this.dateDay < 1 || 
                string.IsNullOrEmpty(this.dateMonth.ToString()) ||
                this.dateMonth > 12 || this.dateMonth < 1 ||
                string.IsNullOrEmpty(this.dateYear.ToString()) ||
                this.dateYear < 1900 || this.dateYear > DateTime.Now.Year
            )
            {
                Toast.MakeText(Android.App.Application.Context, "Ingrese una fecha de nacimiento válida", ToastLength.Short).Show();
                return;
            }

            if (string.IsNullOrEmpty(this.username))
            {
                Toast.MakeText(Android.App.Application.Context, "Ingrese su nombre de usuario", ToastLength.Short).Show();
                return;
            }

            try
            {
                var db = new Database();
                var sp = StoredProcedures.ExistUser;
                string[] parameters = { this.username, this.username };
                var responseStr = db.Connect(sp, parameters, "one");
                Response response = JsonConvert.DeserializeObject<Response>(responseStr);
                if (response.Data.Count != 0)
                {
                    Toast.MakeText(
                        Android.App.Application.Context,
                        "El nombre de usuario @" + this.username + " ya está registrado",
                        ToastLength.Short
                    ).Show();
                    return;
                }
            }
            catch (Exception e)
            {
                Toast.MakeText(
                    Android.App.Application.Context, 
                    "No hay respuesta del servidor",  
                    ToastLength.Short
                ).Show();
            }

            if (string.IsNullOrEmpty(this.password))
            {
                Toast.MakeText(Android.App.Application.Context, "Ingrese su contraseña", ToastLength.Short).Show();
                return;
            }

            if (string.IsNullOrEmpty(this.confirmPassword))
            {
                Toast.MakeText(Android.App.Application.Context, "Ingrese su contraseña nuevamente", ToastLength.Short).Show();
                return;
            }

            if (this.password != this.confirmPassword)
            {
                Toast.MakeText(Android.App.Application.Context, "Las contraseñas no coinciden", ToastLength.Short).Show();
                return;
            }

            try
            {
                var db = new Database();
                var sp = StoredProcedures.SetUser;
                var birthDate = this.dateYear + "-" + this.dateMonth + "-" + this.dateDay;
                string[] parameters = {
                    this.names,
                    this.surnames,
                    this.username,
                    this.email,
                    Sha256(this.password),
                    birthDate,
                    this.phone
                };
                var responseStr = db.Connect(sp, parameters, "result");
                var response = JsonConvert.DeserializeObject<Response>(responseStr);
                if (response.Status == 200)
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Correcto!",
                        "Usuario registrado exitosamente",
                        "Aceptar");
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion

        #region Constructor
        public RegisterViewModel()
        {
            this.isEnabled = true;
            this.isVisible = false;
            this.isRunning = false;
        }
        #endregion
    }
}