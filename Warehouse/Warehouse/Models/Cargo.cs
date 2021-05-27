using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Cargo
    {
        public int ID { get; set; }

        [StringLength(8, MinimumLength = 1, ErrorMessage = "Номер груза должен быть от 1 до 8 символов.")]
        public string Number { get; set; }

        [Range(1, 36, ErrorMessage = "Максимальное кол-во паллет: 36.")]
        public int NumOfPalletes { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
