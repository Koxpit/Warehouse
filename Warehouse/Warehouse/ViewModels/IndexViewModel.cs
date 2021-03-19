using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public class IndexViewModel
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<Storage> Storages { get; set; }
    }
}
