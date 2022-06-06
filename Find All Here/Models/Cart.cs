using System;
using System.Collections.Generic;
using System.Text;

namespace Find_All_Here.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; }
        public decimal Total { get; set; }
        public Cart()
        {
            Products = new List<Product>();
        }
    }
}
