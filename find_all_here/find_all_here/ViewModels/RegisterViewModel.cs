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
            try
            {
                if (string.IsNullOrEmpty(this.names))
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su nombre",
                        "Aceptar");
                    return;
                }

                if (string.IsNullOrEmpty(this.surnames))
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su apellido",
                        "Aceptar");
                    return;
                }

                if (string.IsNullOrEmpty(this.email))
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su correo",
                        "Aceptar");
                    return;
                }

                if (string.IsNullOrEmpty(this.phone))
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su telefono",
                        "Aceptar");
                    return;
                }

                if (
                    string.IsNullOrEmpty(this.dateDay.ToString()) ||
                    string.IsNullOrEmpty(this.dateMonth.ToString()) ||
                    string.IsNullOrEmpty(this.dateYear.ToString()))
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su fecha de nacimiento",
                        "Aceptar");
                    return;
                }
                var dateBirth = new Date(this.dateDay, this.dateMonth, this.dateYear);
                
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    dateBirth.ToString(),
                    "Aceptar");

                if (string.IsNullOrEmpty(this.username))
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su nombre de usuario",
                        "Aceptar");
                    return;
                }

                if (string.IsNullOrEmpty(this.password))
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su contraseña",
                        "Aceptar");
                    return;
                }

                if (string.IsNullOrEmpty(this.confirmPassword))
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "Ingrese su contraseña de confirmación",
                        "Aceptar");
                    return;
                }

                if (this.password != this.confirmPassword)
                {
                    await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "Las contraseñas no coinciden",
                        "Aceptar");
                    return;
                }
            }
            catch (Exception e)
            {
                Toast.MakeText(Android.App.Application.Context, e.Message, ToastLength.Long).Show();
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