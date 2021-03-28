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
            var foundStorage = _db.Storages.FirstOrDefault(x => x.Name == storageName && x.Territory == territoryStorage);

            if (!_db.Storages.Contains(foundStorage))
                return Content("Склад не существует");
            else
            {
                place.Storage = foundStorage;
                place.StorageId = foundStorage.ID;
            }

            var foundCode = _db.Products.Select(x => x.Code)
                .FirstOrDefault(code => code == place.Product.Code);

            if (foundCode == null && place.Product.BoxesInPallete == 0)
                return Content("Введите количество коробов");
            if (foundCode != null)
                place.Product.BoxesInPallete = FirstData.codesNumBoxes
                    .FirstOrDefault(x => x.Key == place.Product.Code).Value;

            var foundTerm = _db.Products.Select(x => x.Term)
                .FirstOrDefault(term => term == place.Product.Term);

            if (foundTerm == DateTime.MinValue && place.Product.Party == null)
                return Content("Введите партию");
            if (foundTerm != DateTime.MinValue)
                place.Product.Party = FirstData.partyTerm
                    .FirstOrDefault(x => x.Value == Convert.ToDateTime(place.Product.Term)).Key;

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
            ViewBag.Codes = _db.Products.Select(x => x.Code).Distinct().ToList();

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
