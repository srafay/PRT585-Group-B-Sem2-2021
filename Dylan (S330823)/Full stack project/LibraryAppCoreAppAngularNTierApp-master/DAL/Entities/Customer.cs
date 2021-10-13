using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Customer
    {
        public Int64 CustomerID { get; set; } //(PK)
        public String Customer_Name { get; set; }
    }
}
