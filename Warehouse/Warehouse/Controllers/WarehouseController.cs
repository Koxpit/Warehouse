using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Database;
using Warehouse.Models;
using Warehouse.Services;
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
            return View(_db.Workers.Include(x => x.Position).ToList());
        }

        [HttpGet]
        public IActionResult Storages()
        {
            return View(_db.Storages.ToList());
        }

        [HttpGet]
        public JsonResult GetStoragesJson()
        {
            List<Storage> storages = _db.Storages.ToList();
            return Json(new { data = storages });
        }

        [HttpGet]
        public IActionResult Products()
        {
            var storagesNames = _db.Storages.Select(x => x.Name).Distinct().ToList();
            List<Place> products = new List<Place>();

            foreach (var name in storagesNames)
                products.AddRange(_db.Places.Include(p => p.Product).Include(s => s.Storage).Where(s => s.Storage.Name == name).ToList());

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

        [HttpGet]
        public IActionResult Positions()
        {
            return View(_db.Positions.ToList());
        }

        [HttpGet]
        public IActionResult Email()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Email(string emailAddress, string subject, string message)
        {
            EmailService emailService = new EmailService();

            await emailService.SendEmailAsync(emailAddress, subject, message);

            return Content("<h1>Сообщение успешно отправлено.</h1>");
        }

        [HttpGet]
        public IActionResult MapsStorages()
        {
            return View(new { data = _db.Storages.ToList() });
        }
    }
}
