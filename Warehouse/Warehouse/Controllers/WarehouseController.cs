﻿using iTextSharp.text;
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

        public void GetPdfFile(string code, string party)
        {
            List<Product> items = GetProductsByCodeAndPartyProduct(code, party);
            PdfService.ExportToPDF(ref items);
        }

        [HttpGet]
        public IActionResult SelectProductsInStorage(string storageName)
        {
            ViewBag.SelectedProducts = _db.Products.Include(p => p.Place).Include(s => s.Place.Storage)
                .Where(s => s.Place.Storage.Name == storageName).ToList();

            return View("Products");
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
        public IActionResult Products()
        {
            List<string> storagesNames = _db.Storages.Select(x => x.Name).Distinct().ToList();
            List<Product> products = new List<Product>();

            foreach (string name in storagesNames)
                products.AddRange(_db.Products.Include(p => p.Place.Storage).Include(s => s.Place).Where(s => s.Place.Storage.Name == name).ToList());

            ViewBag.SelectedProducts = products;

            return View();
        }

        [HttpGet]
        public IActionResult Orders()
        {
            ViewBag.Orders = _db.Orders.Where(d => d.ArrivalTime > DateTime.Now).Include(c => c.Cargos).ThenInclude(p => p.Product).ToList();

            return View();
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
