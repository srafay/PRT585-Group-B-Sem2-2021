using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        public Int64 ProductID { get; set; } //(PK)
        public String Product_Name { get; set; }
        public String Product_Description { get; set; }
    }
}
