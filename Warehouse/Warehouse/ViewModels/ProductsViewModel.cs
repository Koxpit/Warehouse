using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Models;

namespace Warehouse.ViewModels
{
    public class ProductsViewModel
    {
        public ICollection<Place> Products { get; set; }
    }
}
