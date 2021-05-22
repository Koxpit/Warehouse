using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Database;

namespace Warehouse.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public DateTime ArrivalTime { get; set; }

        public List<Cargo> Cargos { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
