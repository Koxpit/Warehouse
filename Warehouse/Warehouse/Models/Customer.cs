using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = "Недопустимая длина строки.")]
        public string FIO { get; set; }

        [RegularExpression(@"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$", ErrorMessage = "Некорректный номер телефона")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Номер телефона должен быть от 6 до 12 символов.")]
        public string PhoneNumber { get; set; }

        [StringLength(50, ErrorMessage = "Недопустимая длина строки.")]
        public string CompanyName { get; set; }

        [StringLength(30, ErrorMessage = "Недопустимая длина строки.")]
        public string City { get; set; }
    }
}
