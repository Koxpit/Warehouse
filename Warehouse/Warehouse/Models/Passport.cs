using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Passport
    {
        public int ID { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string IssuedAt { get; set; }
        public DateTime IssuedWas { get; set; }
    }
}
