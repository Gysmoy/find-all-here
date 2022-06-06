using System;
using System.Collections.Generic;
using System.Text;

namespace Find_All_Here.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public decimal Purchase_price { get; set; }
        public decimal Sale_price { get; set; }
        public string Proportions { get; set; }
        public int Stock { get; set; }
        public string Tags { get; set; }
        public string Image_mini { get; set; }
        public string Image_full { get; set; }
        public string Product_status { get; set; }
        public int Quantity { get; set; }
        public string Total_price { get; set; }
        public User User { get; set; }
        public DateTime Update_date { get; set; }
        public string Relative_time { get; set; }
        public decimal Percent { get; set; }
        public string Relative_Percent { get; set; }
        public string Color_percent { get; set; }
        public bool Status { get; set; }
    }
}
