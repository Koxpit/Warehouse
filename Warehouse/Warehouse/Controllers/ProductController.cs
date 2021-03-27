using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Warehouse.Database;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly WarehouseContext _db;

        public ProductController(ILogger<ProductController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Place place)
        {
            string storageName = place.Storage.Name;
            string territoryStorage = place.Storage.Territory;

            var storage = _db.Storages.FirstOrDefault(x => x.Name == storageName && x.Territory == territoryStorage);

            if (!_db.Storages.Contains(storage))
            {
                return View("Склад не существует");
            }

            place.Product.BoxesInPallete = FirstData.codesNumBoxes.FirstOrDefault(x => x.Key == place.Product.Code).Value;
            place.Product.Party = FirstData.partyTerm.FirstOrDefault(x => x.Value == Convert.ToDateTime(place.Product.Term)).Key;
            place.Storage = storage;
            place.StorageId = storage.ID;

            _db.Places.Add(place);
            await _db.SaveChangesAsync();

            return RedirectToAction("Products", "Warehouse");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.StorageNames = _db.Storages.Select(s => s.Name).Distinct().ToList();
            ViewBag.StorageTerritories = _db.Storages.Select(s => s.Territory).Distinct().ToList();
            ViewBag.Products = _db.Products.ToList();

            return View();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Edit(Place place)
        {
            Place currentPlace = _db.Places.First(p => p.Product.ID == place.Product.ID);

           /* currentPlace.Sector = place.Sector;
            currentPlace.Number = place.Number;
            currentPlace.Product.Name = place.Product.Name;
            currentPlace.Product.Code = place.Product.Code;
            currentPlace.Product.CodeOfPallete = place.Product.CodeOfPallete;*/
            _db.Places.Update(place);
            _db.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
