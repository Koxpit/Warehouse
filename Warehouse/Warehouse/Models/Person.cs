using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public abstract class Person
    {
        public abstract int ID { get; set; }
        public abstract string FIO { get; set; }
        public abstract string PhoneNumber { get; set; }
    }
}
