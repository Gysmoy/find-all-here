﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace find_all_here
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shell : Xamarin.Forms.Shell
    {
        public Shell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddProductView), typeof(AddProductView));
            Routing.RegisterRoute(nameof(ProfileView), typeof(ProfileView));
        }
    }
}