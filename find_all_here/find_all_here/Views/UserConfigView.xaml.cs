﻿using find_all_here.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserConfig : ContentPage
    {
        public UserConfig()
        {
            InitializeComponent();
            BindingContext = new UpdateDataUserViewModel();
        }

    }
}