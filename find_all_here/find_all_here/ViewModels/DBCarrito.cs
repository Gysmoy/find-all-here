using System;
using System.Collections.Generic;
using System.Text;

namespace find_all_here.ViewModels
{
    public class DBCarrito
    {
        public string name { get; set; }

        public string Precio { get; set; }

        public string Url { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
