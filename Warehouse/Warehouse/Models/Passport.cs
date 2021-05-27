using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Passport
    {
        public int ID { get; set; }

        [StringLength(4, MinimumLength = 4, ErrorMessage = "Серия паспорта должна быть длиной 4 символа.")]
        public string Series { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "Номер паспорта должна быть длиной 6 символа.")]
        public string Number { get; set; }

        [StringLength(150, ErrorMessage = "Недопустимая длина строки.")]
        public string IssuedAt { get; set; }
        public DateTime IssuedWas { get; set; }
    }
}
