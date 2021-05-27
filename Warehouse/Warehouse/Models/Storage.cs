using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Storage
    {
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = "Недопустимая длина строки.")]
        public string Name { get; set; }

        [StringLength(100, ErrorMessage = "Недопустимая длина строки.")]
        public string Territory { get; set; }

        [StringLength(300, ErrorMessage = "Недопустимая длина строки.")]
        public string Address { get; set; }
        public double GeoLong { get; set; }
        public double GeoLat { get; set; }
        public byte[] StorageImage { get; set; }
        public string StorageImageBase64 { get; set; }

        public List<Place> Places { get; set; }
    }
}
