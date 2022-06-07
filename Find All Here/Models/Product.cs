using Find_All_Here.RestClient;
using Find_All_Here.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public List<Product> GetProductsByUserId(string userid)
        {
            var db = new Database();
            var sp = StoredProcedures.GetProductsByUserId;
            var parameters = new NameValueCollection
            {
                [":userid"] = userid
            };
            var res_product = db.Fetch(sp, parameters);
            var data_product = JsonConvert.DeserializeObject<Response>(res_product);

            var list_products = new List<Product>();

            foreach (NameValueCollection p in data_product.Data)
            {
                var product = new Product();
                product.Id = int.Parse(p["id"]);
                product.Name = p["name"];
                product.Description = p["description"];

                var brand = new Brand();
                brand.Id = int.Parse(p["b_id"]);
                brand.Name = p["b_name"];
                brand.Status = p["b_status"] == "1";

                product.Brand = brand;

                var category = new Category();
                category.Id = int.Parse(p["c_id"]);
                category.Name = p["c_name"];
                category.Status = p["b_status"] == "1";

                product.Category = category;

                product.Purchase_price = decimal.Parse(p["purchase_price"]);
                product.Sale_price = decimal.Parse(p["sale_price"]);
                product.Proportions = p["proportions"];
                product.Stock = int.Parse(p["stock"]);
                product.Tags = p["tags"];

                var guid = new Guid();

                product.Image_mini = "https://scriptperu.com/find_all_here/image/product/" + p["id"] + "/mini/" + guid.ToString();
                product.Image_mini = "https://scriptperu.com/find_all_here/image/product/" + p["id"] + "/full/" + guid.ToString();

                product.Product_status = p["product_status"];
                product.Update_date = DateTime.Parse(p["update_date"]);
                product.Percent = decimal.Round((1 - (product.Sale_price / product.Purchase_price)) * -100, 2);
                product.Relative_Percent = (product.Percent > 1) ? "+" + product.Percent + "%" : "" + product.Percent + "%";
                product.Color_percent = (product.Percent > 1) ? "#fc424a" : "#00d25b";
                product.Status = p["status"] == "1";

                list_products.Add(product);
            }

            return list_products;
        }
    }
}
