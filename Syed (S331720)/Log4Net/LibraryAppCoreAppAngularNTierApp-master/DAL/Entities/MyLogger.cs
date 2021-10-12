using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class MyLogger
    {
        public Int64 LoggerId { get; set; } //(PK)
        public String LoggerMsg { get; set; }
        public String LoggerInfo { get; set; }

    }
}
