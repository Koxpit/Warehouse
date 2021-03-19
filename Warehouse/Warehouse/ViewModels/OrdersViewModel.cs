using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Database;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public class OrdersViewModel
    {
        public ICollection<Order> Orders { get; set; }
    }
}
