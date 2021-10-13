using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Area
    {
        public Int64 AreaId { get; set; } //(PK)
        public String Postcode { get; set; } 
        public String CityName { get; set; }
        public String StateName { get; set; }

    }
}