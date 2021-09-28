using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.Product
{
    public class Product_ResultSet
    {
        public Int64 product_id { get; set; }
        public String product_description { get; set; }
        public String product_name { get; set; }
        public Int64 product_price { get; set; }
        public String product_pictureurl { get; set; }
        public String product_type { get; set; }
        public String product_brand { get; set; }
    }
}
