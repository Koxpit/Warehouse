using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int Capacity { get; set; }

        public int? DriverId { get; set; }
        public Driver Driver { get; set; }

        public List<Order> Orders { get; set; }
    }
}
