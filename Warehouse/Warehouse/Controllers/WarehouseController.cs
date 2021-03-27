using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Database;
using Warehouse.Models;
using Warehouse.ViewModels;

namespace Warehouse.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly ILogger<WarehouseController> _logger;
        private readonly WarehouseContext _db;

        public WarehouseController(ILogger<WarehouseController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            var storages = _db.Storages.ToList();
            var indexViewModel = new IndexViewModel
            {
                Products = products,
                Storages = storages
            };

            return View(indexViewModel);
        }

        [HttpGet]
        public IActionResult GetSelectedProducts(string code, string party)
        {
            List<Place> selectedProducts;

            if (String.IsNullOrWhiteSpace(party))
            {
                selectedProducts = _db.Places.Include(p => p.Product).Include(s => s.Storage)
                    .Where(p => p.Product.Code == code).ToList();
            }
            else
            {
                selectedProducts = _db.Places.Include(p => p.Product).Include(s => s.Storage)
                    .Where(p => p.Product.Code == code && p.Product.Party == party).ToList();
            }

            var productsViewModel = new ProductsViewModel
            {
                Products = selectedProducts
            };

            return View("Products", productsViewModel);
        }

        [HttpGet]
        public IActionResult SelectProductsInStorage(string storageName)
        {
            List<Place> selectedProducts =_db.Places.Include(p => p.Product).Include(s => s.Storage)
                .Where(s => s.Storage.Name == storageName).ToList();

            var productsViewModel = new ProductsViewModel
            {
                Products = selectedProducts
            };

            return View("Products", productsViewModel);
        }

        [HttpGet]
        public IActionResult GetStorages()
        {
            List<Storage> storages = _db.Storages.ToList();

            return View("Storages", storages);
        }

        [HttpGet]
        public IActionResult Drivers()
        {
            return View(_db.Drivers.ToList());
        }

        [HttpGet]
        public IActionResult Workers()
        {
            return View(_db.Workers.ToList());
        }

        [HttpGet]
        public IActionResult Storages()
        {
            return View(_db.Storages.ToList());
        }

        [HttpGet]
        public IActionResult Products()
        {
            var storages = _db.Storages.Distinct().ToList();
            List<Place> products = new List<Place>();

            foreach (var item in storages)
                products.AddRange(_db.Places.Include(p => p.Product).Include(s => s.Storage).Where(s => s.Storage.Name == item.Name).ToList());

            var productsViewModel = new ProductsViewModel
            {
                Products = products
            };

            return View(productsViewModel);
        }

        [HttpGet]
        public IActionResult Orders()
        {
            var orders = _db.Orders.Where(d => d.ArrivalTime > DateTime.Now).Include(c => c.Cargos).ThenInclude(p => p.Product).ToList();
            var ordersViewModel = new OrdersViewModel
            {
                Orders = orders
            };

            return View(ordersViewModel);
        }
    }
}
