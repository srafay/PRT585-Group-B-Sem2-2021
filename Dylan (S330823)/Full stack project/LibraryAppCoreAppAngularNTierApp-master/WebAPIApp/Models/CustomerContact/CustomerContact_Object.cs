using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIApp.Models.CustomerContact
{
    public class CustomerContact_Object
    {
        public int customercontact_id { get; set; }
        public String customer_name { get; set; }
        public string customer_number { get; set; }
        public string customer_email { get; set; }
        public string customer_address { get; set; }

    }
}
