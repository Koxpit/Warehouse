using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public class CargoOrderViewModel
    {
        public int OrderId { get; set; }
        public Cargo Cargo { get; set; }
    }
}
