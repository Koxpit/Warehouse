using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Database;

namespace Warehouse.Models
{
    public class Order
    {
        public int ID { get; set; }

        [StringLength(5, MinimumLength = 1, ErrorMessage = "Номер заказа должен быть от 1 до 5 символов.")]
        public string Number { get; set; }

        [StringLength(40, ErrorMessage = "Недопустимая длина строки.")]
        public string Type { get; set; }

        public DateTime ArrivalTime { get; set; }

        public List<Cargo> Cargos { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
