using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            Storage foundStorage = FoundStorage(place.Storage);

            if (!_db.Storages.Contains(foundStorage))
                return Content("Склад не существует");
            else
            {
                place.Storage = foundStorage;
                place.StorageId = foundStorage.ID;
            }

            string foundCode = FoundCode(place.Product.Code);

            if (foundCode == null && place.Product.BoxesInPallete == 0)
                return Content("Введите количество коробов");
            else
                place.Product.BoxesInPallete = FindBoxesInPallete(place.Product.Code);

            if (place.Product.Party == null)
            {
                string foundParty = FindParty(place.Product.Term);
                if (foundParty == null)
                    return Content($"Введите партию вручную. По сроку {place.Product.Term.ToShortDateString()} партия не найдена.");
                else
                    place.Product.Party = foundParty;
            }
            else
            {
                string existParty = _db.Products
                    .Where(x => x.Code != place.Product.Code && x.Party == place.Product.Party)
                    .Select(x => x.Party).FirstOrDefault();
                if (existParty != null)
                    return Content("Введенная партия принадлежит уже другому коду продукта.");
            }

            _db.Places.Add(place);
            await _db.SaveChangesAsync();

            return RedirectToAction("Products", "Warehouse");
        }

        private Storage FoundStorage(Storage storage)
        {
            string storageName = storage.Name;
            string territoryStorage = storage.Territory;

            return _db.Storages.FirstOrDefault(x => x.Name == storageName && x.Territory == territoryStorage);
        }

        private string FoundCode(string sourceCode)
        {
            return _db.Products.Select(x => x.Code)
                .FirstOrDefault(code => code == sourceCode);
        }

        private DateTime FoundTerm(string sourceParty)
        {
            return _db.Products.Where(x => x.Party == sourceParty)
                .Select(x => x.Term).FirstOrDefault();
        }

        private int FindBoxesInPallete(string code)
        {
            return _db.Products.Where(x => x.Code == code)
               .Select(x => x.BoxesInPallete).FirstOrDefault();
        }

        private string FindParty(DateTime term)
        {
            return _db.Products.Where(x => x.Term == term)
                .Select(x => x.Party).FirstOrDefault();
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

        [HttpPost]
        public async Task<IActionResult> Edit(Place place)
        {
            int numPalletes = NumPalletesInPlace(place) + place.NumOfPalletes;
            if (numPalletes > 22)
                return Content($"Нехватает места для {numPalletes - 22} паллет в позиции {place.Sector + "/" + place.Number}.");

            Storage foundStorage = FoundStorage(place.Storage);
            if (!_db.Storages.Contains(foundStorage))
                return Content("Склад не существует");
            else
            {
                place.Storage = foundStorage;
                place.StorageId = foundStorage.ID;
            }

            Place currentPlace = FoundPlace(place.ID);
            SetProductData(ref currentPlace, ref place, ref foundStorage);

            _db.Places.Update(currentPlace);
            await _db.SaveChangesAsync();

            return RedirectToAction("Products", "Warehouse");
        }

        private int NumPalletesInPlace(Place place)
        {
            int numPalletes = 0;

            foreach (var item in _db.Places.Where(
                    x => x.Sector == place.Sector && 
                    x.Number == place.Number && 
                    x.ID != place.ID && 
                    x.Storage.Name == place.Storage.Name &&
                    x.Storage.Address == place.Storage.Address &&
                    x.Storage.Territory == place.Storage.Territory))
                numPalletes += item.NumOfPalletes;

            return numPalletes;
        }

        private Place FoundPlace(int placeId)
        {
            return _db.Places.Include(p => p.Product).Include(s => s.Storage).FirstOrDefault(x => x.ID == placeId);
        }

        private void SetProductData(ref Place currentPlace, ref Place newPlace, ref Storage foundStorage)
        {
            currentPlace.Sector = newPlace.Sector;
            currentPlace.Number = newPlace.Number;
            currentPlace.NumOfPalletes = newPlace.NumOfPalletes;
            currentPlace.Product.Name = newPlace.Product.Name;
            currentPlace.Product.Code = newPlace.Product.Code;
            currentPlace.Product.Party = newPlace.Product.Party;
            currentPlace.Product.Term = newPlace.Product.Term;
            currentPlace.Product.Cost = newPlace.Product.Cost;
            currentPlace.Storage = foundStorage;
        }

        [HttpGet]
        public IActionResult Edit(int placeId)
        {
            ViewBag.StorageNames = _db.Storages.Select(s => s.Name).Distinct().ToList();
            ViewBag.StorageTerritories = _db.Storages.Select(s => s.Territory).Distinct().ToList();
            ViewBag.Products = _db.Products.ToList();
            ViewBag.Codes = _db.Products.Select(x => x.Code).Distinct().ToList();
            var currentPlace = _db.Places.Include(p => p.Product).Include(s => s.Storage).FirstOrDefault(x => x.ID == placeId);

            return View(currentPlace);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Place place = await _db.Places.FirstOrDefaultAsync(p => p.ID == id);
            if (place != null)
                return View(place);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Place place = new Place { ID = id };

            _db.Entry(place).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToAction("Products", "Warehouse");
        }
    }
}
