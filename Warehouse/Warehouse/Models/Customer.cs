using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Customer : Person
    {
        public override int ID { get; set; }
        public override string FIO { get; set; }
        public override string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
