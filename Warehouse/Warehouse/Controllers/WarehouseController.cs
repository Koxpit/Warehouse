using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
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
            ViewBag.Codes = _db.Products.Select(x => x.Code).Distinct();
            ViewBag.Parties = _db.Products.Select(x => x.Party).Distinct();
            ViewBag.Territories = _db.Storages.Select(x => x.Territory).Distinct();
            ViewBag.StoragesNames = _db.Storages.Select(x => x.Name).Distinct();

            return View();
        }

        [HttpGet]
        public IActionResult GetSelectedProducts(string code, string party)
        {
            ViewBag.SelectedProducts = GetProductsByCodeAndPartyProduct(code, party);

            return View("Products");
        }

        private List<Product> GetProductsByCodeAndPartyProduct(string code, string party)
        {
            if (String.IsNullOrWhiteSpace(party) && String.IsNullOrWhiteSpace(code))
            {
                return _db.Products.Include(p => p.Place).Include(s => s.Place.Storage).ToList();
            }
            else if (String.IsNullOrWhiteSpace(party))
            {
                return _db.Products.Include(p => p.Place).Include(s => s.Place.Storage)
                    .Where(p => p.Code == code).ToList();
            }

            return _db.Products.Include(p => p.Place).Include(s => s.Place.Storage)
                .Where(p => p.Code == code && p.Party == party).ToList();
        }

        [HttpGet]
        public IActionResult GetPdfFile(string code, string party)
        {
            List<Product> items = GetProductsByCodeAndPartyProduct(code, party);
            PdfService.ExportToPDF(ref items);

            return Content("Файл успешно создан.");
        }

        public IActionResult GetPdfFile(string storageName)
        {
            List<Product> items = _db.Products.Where(x => x.Place.Storage.Name == storageName).Include(x => x.Place).Include(x => x.Place.Storage).ToList();
            PdfService.ExportToPDF(ref items);

            return Content("Очет успешно создан.");
        }

        [HttpGet]
        public IActionResult SelectProductsInStorage(string storageName, int page = 1)
        {
            List<Product> products = _db.Products.Include(p => p.Place).Include(s => s.Place.Storage)
                .Where(s => s.Place.Storage.Name == storageName).ToList();

            int pageSize = 15;
            int count = products.Count();
            List<Product> selectedItems = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ProductsPageViewModel viewModel = new ProductsPageViewModel
            {
                PageViewModel = pageViewModel,
                Products = selectedItems
            };

            ViewBag.StorageName = storageName;

            return View("Products", viewModel);
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
        public IActionResult Customers()
        {
            return View(_db.Customers.ToList());
        }

        [HttpGet]
        public JsonResult GetStoragesJson()
        {
            List<Storage> storages = _db.Storages.ToList();
            return Json(new { data = storages });
        }

        [HttpGet]
        public JsonResult GetStorageById(int id)
        {
            Storage storage = _db.Storages.Where(x => x.ID == id).SingleOrDefault();
            return Json(new { data = storage});
        }

        [HttpGet]
        public IActionResult Products(int page = 1)
        {
            int pageSize = 15;
            List<string> storagesNames = _db.Storages.Select(x => x.Name).Distinct().ToList();
            List<Product> products = new List<Product>();

            foreach (string name in storagesNames)
                products.AddRange(_db.Products.Include(p => p.Place.Storage).Include(s => s.Place).Where(s => s.Place.Storage.Name == name).ToList());

            int count = products.Count();
            List<Product> selectedItems = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ProductsPageViewModel viewModel = new ProductsPageViewModel
    		{
                PageViewModel = pageViewModel,
			    Products = selectedItems
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Orders(int page = 1)
        {
            ViewBag.Orders = _db.Orders.Include(c => c.Cargos).ThenInclude(p => p.Product).ToList();
            int pageSize = 10;

            List<Order> orders = _db.Orders.Include(c => c.Cargos).ThenInclude(p => p.Product).ToList();
            var count = orders.Count();
            List<Order> selectedOrders = orders.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            OrdersPageViewModel viewModel = new OrdersPageViewModel
            {
                PageViewModel = pageViewModel,
                Orders = selectedOrders
            };

            return View(viewModel);
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

            return Content("Сообщение успешно отправлено.");
        }

        [HttpGet]
        public IActionResult MapsStorages()
        {
            ViewBag.ListOfStorages = _db.Storages.ToList();
            return View();
        }
    }
}
