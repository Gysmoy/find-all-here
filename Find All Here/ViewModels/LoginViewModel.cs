using Find_All_Here.Models;
using Find_All_Here.RestClient;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Input;

namespace Find_All_Here.ViewModels
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
                string password = Sha256(this.password);

                Response response = User.GetUserByUsernameAndPassword(email, password);

                if (response.Result == true)
                {
                    if (response.Rows == 0)
                    {
                        throw new Exception("Usuario o contraseña incorrecta");
                    }
                    else
                    {
                        var u = response.Data[0];
                        var user = new User
                        {
                            Id = int.Parse(u["id"]),
                            Names = u["names"],
                            Surnames = u["surnames"],
                            Username = u["username"],
                            Email = u["email"],
                            Password = u["password"],
                            Gender = u["gender"],
                            Birth_date = u["birth_date"],
                            Address = u["address"],
                            Phone = u["phone"],
                            Status = true
                        };

                        App.Current.Properties["user"] = JsonConvert.SerializeObject(user);
                        var cart = new Cart();
                        App.Current.Properties["cart"] = JsonConvert.SerializeObject(cart);


                        await App.Current.MainPage.DisplayAlert(
                            "Hola " + user.Names,
                            "Bienvenido a Find All Here",
                            "Aceptar");
                        App.Current.MainPage = new Shell();
                    }
                } else
                {
                    throw new Exception(response.Message);
                }
            }
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error!",
                    e.Message,
                    "Aceptar"
                );
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
