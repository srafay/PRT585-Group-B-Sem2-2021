using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CustomerContact
    {
        public Int64 CustomerContactID { get; set; } //(PK)
        public String Customer_Name { get; set; }
        public String Customer_Number { get; set; }
        public String Customer_Email { get; set; }
        public String Customer_Address { get; set; }
    }
}
