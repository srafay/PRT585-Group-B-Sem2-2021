using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Models.Product
{
    public class Product_Object
    {
        public int id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public Int64 product_price { get; set; }
        public String product_pictureurl { get; set; }
        public String product_type { get; set; }
        public String product_brand { get; set; }
    }
}
