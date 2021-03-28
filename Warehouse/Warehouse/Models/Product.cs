using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Party { get; set; }
        public DateTime Term { get; set; }
        public string Comment { get; set; }
        public int BoxesInPallete { get; set; }
        public decimal Cost { get; set; }
    }
}
