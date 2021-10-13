using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Services.Models.CustomerContact
{
    public class CustomerContact_ResultSet
    {
        public Int64 customercontact_id { get; set; }
        public String customer_name { get; set; }
        public String customer_number { get; set; }
        public String customer_email { get; set; }
        public String customer_address { get; set; }
    }
}