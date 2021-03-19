using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Place
    {
        public int ID { get; set; }
        public string Sector { get; set; }
        public string Number { get; set; }
        public int NumOfPalletes { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
