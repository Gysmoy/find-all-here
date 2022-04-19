using System;
using System.Collections.Generic;
using System.Text;

namespace find_all_here.Models
{
    public class ListaProducts: Response
    {
        public List<ProductDetail> Data { get; set; }
    }
}
