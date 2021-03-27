using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
