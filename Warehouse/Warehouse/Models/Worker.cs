using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Worker
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public int Experience { get; set; }
        public decimal Salary { get; set; }
        public string Number { get; set; }

        public int? PassportId { get; set; }
        public Passport Passport { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
