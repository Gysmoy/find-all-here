﻿using System;
using System.Collections.Generic;
using System.Text;
using find_all_here.Models;

namespace find_all_here.ViewModels
{
    public class DBCarrito
    {
        public string name { get; set; }

        public string Name { get; set; }

        public string Precio { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return name;
        }
        
        private void OnCartOpen()
        {
            Cart cart = (Cart)App.Current.Properties["cart"];
        }
    }
}
