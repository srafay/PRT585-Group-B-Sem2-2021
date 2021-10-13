using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Logger
    {
        public Int64 ID { get; set; } //(PK)
        public String Level { get; set; }
        public String Description { get; set; }
    }
}
