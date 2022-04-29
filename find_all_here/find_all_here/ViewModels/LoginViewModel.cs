

using System;
using System.Collections.Generic;
using Android.Widget;
using find_all_here.Models;
using Newtonsoft.Json;
using System.Windows.Input;
using find_all_here.csharp;
using GalaSoft.MvvmLight.Command;

namespace find_all_here.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attribute
        public string email;
        public string password;
        public bool isRunning;
        public bool isVisible;
        public bool isEnabled;
        #endregion

        #region Properties
        public string EmailTxt
        {
            get { return this.email; }
            set { SetProperty(ref this.email, value); }
        }

        public string PasswordTxt
        {
            get { return this.password; }
            set { SetProperty(ref this.password, value); }
        }

        public bool IsRunningTxt
        {
            get { return this.isRunning; }
            set { SetProperty(ref this.isRunning, value); }
        }


        public bool IsVisibleTxt
        {
            get { return this.isVisible; }
            set { SetProperty(ref this.isVisible, value); }
        }

        public bool IsEnabledTxt
        {
            get { return this.isEnabled; }
            set { SetProperty(ref this.isEnabled, value); }
        }

        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }
        }
        #endregion

        #region Methods


        public async void LoginMethod()
        {
            
            if (string.IsNullOrEmpty(this.email))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Debes ingresar un usuario o un correo",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.password))
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "Debes ingresar una contraseña",
                    "Aceptar");
                return;
            }

            this.IsRunningTxt = true;
            this.IsVisibleTxt = true;
            this.IsEnabledTxt = false;
            try
            {
                Database db = new Database();
                string sp = StoredProcedures.GetUserByUsernameAndPassword;
                string password = Sha256(this.password);
                string[] parameters = { this.email, this.email, password };
                string response = db.Connect(sp, parameters, "one");
                var userValidate = JsonConvert.DeserializeObject<UserValidate>(response);
                Toast.MakeText(Android.App.Application.Context, userValidate.Message, ToastLength.Short).Show();
                if (userValidate.Status == 200)
                {
                    if (userValidate.Data.Count == 0)
                    {
                        await App.Current.MainPage.DisplayAlert(
                            "Error!",
                            "Usuario o contraseña incorrecta",
                            "Aceptar");
                        return;
                    }
                    else
                    {
                        var user = userValidate.Data[0];
                        user.Status = true;
                        App.Current.Properties["user"] = user;
                        Cart cart = new Cart();
                        cart.Products = new List<Product>();
                        App.Current.Properties["cart"] = cart;


                        await App.Current.MainPage.DisplayAlert(
                            "Hola " + user.Names,
                            "Bienvenido a Find All Here",
                            "Aceptar");
                        App.Current.MainPage = new Shell();
                    }
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    "No se pudo conectar con el servidor",
                    "Aceptar");
            } 
            finally
            {
                this.IsRunningTxt = false;
                this.IsVisibleTxt = false;
                this.IsEnabledTxt = true;
            }
            
        }

        public async void ResetPasswordEmail()
        {


        }

        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsEnabledTxt = true;
        }
        #endregion
    }
}