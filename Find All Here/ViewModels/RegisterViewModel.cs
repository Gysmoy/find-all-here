using Find_All_Here.Models;
using Find_All_Here.RestClient;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Find_All_Here.ViewModels
{
    public class RegisterViewModel : BaseViewModel
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
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Ingrese sus nombres",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.surnames))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Ingrese sus apellidos",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.email))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Ingrese su correo electrónico",
                    "Aceptar");
                return;
            }

            try
            {
                var sp = StoredProcedures.ExistUser;
                string[] parameters = { this.email, this.email };
                var response = Database.Connect(sp, parameters, "one");
                var userValidate = JsonConvert.DeserializeObject<UserValidate>(response);
                if (userValidate.Data.Count != 0)
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error!",
                        "El correo electrónico " + this.email + " ya está registrado",
                        "Aceptar");
                    return;
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar");
            }

            if (string.IsNullOrEmpty(this.phone))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Ingrese su número de teléfono",
                    "Aceptar");
                return;
            }

            if (
                string.IsNullOrEmpty(dateDay.ToString()) ||
                dateDay > 31 || dateDay < 1 ||
                string.IsNullOrEmpty(dateMonth.ToString()) ||
                dateMonth > 12 || dateMonth < 1 ||
                string.IsNullOrEmpty(dateYear.ToString()) ||
                dateYear < 1900 || dateYear > DateTime.Now.Year
            )
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Ingrese una fecha de nacimiento válida",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.username))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Ingrese su nombre de usuario",
                    "Aceptar");
                return;
            }

            try
            {
                var sp = StoredProcedures.ExistUser;
                string[] parameters = { this.username, this.username };
                var response = Database.Connect(sp, parameters, "one");
                var userValidate = JsonConvert.DeserializeObject<UserValidate>(response);
                if (userValidate.Data.Count != 0)
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error!",
                        "El nombre de usuario @" + this.username + " ya está registrado",
                        "Aceptar");
                    return;
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar");
            }

            if (string.IsNullOrEmpty(this.password))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Ingrese su contraseña",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.confirmPassword))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Ingrese su contraseña nuevamente",
                    "Aceptar");
                return;
            }

            if (this.password != this.confirmPassword)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Las contraseñas no coinciden",
                    "Aceptar");
                return;
            }

            try
            {
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
                var responseStr = Database.Connect(sp, parameters, "result");
                var response = JsonConvert.DeserializeObject<Response>(responseStr);
                if (response.Result)
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
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar");
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
