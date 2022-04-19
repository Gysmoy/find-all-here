using System;
using System.Collections.Generic;
using System.Text;

namespace find_all_here.Models
{
    public class ProductDetail: Product
    {
        public int B_id { get; set; }
        public string B_name { get; set; }
        public bool B_status { get; set; }
        public int C_id { get; set; }
        public string C_name { get; set; }
        public bool C_status { get; set; }
        public int U_id { get; set; }
        public string U_names { get; set; }
        public string U_surnames { get; set; }
        public string U_username { get; set; }
        public string U_email { get; set; }
        public string U_gender { get; set; }
        public string U_address { get; set; }
        public string U_phone { get; set; }
    }
}
