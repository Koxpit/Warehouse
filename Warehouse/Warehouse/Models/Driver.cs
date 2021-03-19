using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Driver : Person
    {
        public override int ID { get; set; }
        public override string FIO { get; set; }
        public override string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public int Experience { get; set; }
    }
}
