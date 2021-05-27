using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Driver
    {
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = "Недопустимая длина строки.")]
        public string FIO { get; set; }

        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Некорректный номер телефона")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Номер телефона должен быть от 6 до 12 символов.")]
        public string PhoneNumber { get; set; }

        public DateTime Birthday { get; set; }

        [Range(1, 90, ErrorMessage = "Недопустимый опыт.")]
        public int Experience { get; set; }

        public int? PassportId { get; set; }
        public Passport Passport { get; set; }
    }
}
