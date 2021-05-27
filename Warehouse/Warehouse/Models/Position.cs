using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Position
    {
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = "Недопустимая длина строки.")]
        public string Name { get; set; }
    }
}
