using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public class OrdersPageViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
