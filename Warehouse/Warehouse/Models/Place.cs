using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Place
    {
        public int ID { get; set; }

        [StringLength(4, ErrorMessage = "Недопустимый номер сектора.")]
        public string Sector { get; set; }

        [StringLength(4, ErrorMessage = "Недопустимый номер ряда.")]
        public string Number { get; set; }

        [Range(1, 36, ErrorMessage = "Максимальное кол-во паллет: 36.")]
        public int MaxPalletes { get; set; }

        public List<Product> Products { get; set; }

        public int StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
