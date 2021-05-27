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

        [StringLength(200, ErrorMessage = "Недопустимая длина строки.")]
        public string Name { get; set; }

        [StringLength(7, ErrorMessage = "Недопустимая длина строки.")]
        public string Code { get; set; }

        [StringLength(10, ErrorMessage = "Недопустимая длина строки.")]
        public string Party { get; set; }

        public DateTime Term { get; set; }

        [StringLength(500, ErrorMessage = "Недопустимая длина строки.")]
        public string Comment { get; set; }

        [Range(1, 1000, ErrorMessage = "Максимальное кол-во.")]
        public int BoxesInPallete { get; set; }

        public int NumOfPalletes { get; set; }
        public decimal Cost { get; set; }

        public int PlaceId { get; set; }
        public Place Place { get; set; }
    }
}
