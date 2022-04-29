using System;
using System.Collections.Generic;

namespace find_all_here.Models
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