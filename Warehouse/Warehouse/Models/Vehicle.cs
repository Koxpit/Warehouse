using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Vehicle
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessage = "Недопустимая длина строки.")]
        public string Name { get; set; }

        [StringLength(20, ErrorMessage = "Недопустимая длина строки.")]
        public string Number { get; set; }

        [Range(1, 36, ErrorMessage = "Максимальная вместимость: 36 паллет.")]
        public int Capacity { get; set; }

        public int? DriverId { get; set; }
        public Driver Driver { get; set; }

        public List<Order> Orders { get; set; }
    }
}
