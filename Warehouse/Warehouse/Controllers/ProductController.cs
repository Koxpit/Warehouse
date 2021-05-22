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
        public async Task<IActionResult> Add(Product product)
        {
            Storage foundStorage = FoundStorage(product.Place.Storage);
            if (!_db.Storages.Contains(foundStorage))
                return Content("Склад не существует");
            Place place = _db.Places.Where(x => x.Sector == product.Place.Sector && x.Number == product.Place.Number && x.StorageId == foundStorage.ID).FirstOrDefault();
            if (place != null)
            {
                int numPalletes = 0;
                foreach (Product item in _db.Products.Where(x => x.PlaceId == place.ID))
                    numPalletes += item.NumOfPalletes;
                numPalletes += product.NumOfPalletes;

                if (numPalletes > place.MaxPalletes)
                    return Content($"Нехватает места для {numPalletes - place.MaxPalletes} паллет в позиции {place.Sector + "/" + place.Number}.");

                product.PlaceId = place.ID;
                product.Place = place;
            }

            if (!_db.Places.Contains(place))
            {
                place = new Place()
                {
                    MaxPalletes = product.Place.MaxPalletes,
                    Sector = product.Place.Sector,
                    Number = product.Place.Number,
                    StorageId = foundStorage.ID,
                    Storage = foundStorage
                };

                int numPalletes = 0;
                if (product.NumOfPalletes < place.MaxPalletes)
                    return Content($"Нехватает места для {numPalletes - place.MaxPalletes} паллет в позиции {place.Sector + "/" + place.Number}.");
            }

            string foundCode = FoundCode(product.Code);
            if (foundCode == null && product.BoxesInPallete == 0)
                return Content("Введите количество коробов");
            else
                product.BoxesInPallete = FindBoxesInPallete(product.Code);

            if (product.Party == null)
            {
                string foundParty = FindParty(product.Term);
                if (foundParty == null)
                    return Content($"Введите партию вручную. По сроку {product.Term.ToShortDateString()} партия не найдена.");
                else
                    product.Party = foundParty;
            }
            else
            {
                string existParty = _db.Products
                    .Where(x => x.Code != product.Code && x.Party == product.Party)
                    .Select(x => x.Party).FirstOrDefault();
                if (existParty != null)
                    return Content("Введенная партия принадлежит уже другому коду продукта.");
            }

            _db.Products.Add(product);
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
        public async Task<IActionResult> Edit(Product product)
        {
            Storage foundStorage = FoundStorage(product.Place.Storage);
            if (!_db.Storages.Contains(foundStorage))
                return Content("Склад не существует");

            Place place = _db.Places.Where(x => x.Sector == product.Place.Sector && x.Number == product.Place.Number && x.StorageId == foundStorage.ID).FirstOrDefault();
            if (!_db.Places.Contains(place))
            {
                place = new Place()
                {
                    MaxPalletes = product.Place.MaxPalletes,
                    Sector = product.Place.Sector,
                    Number = product.Place.Number,
                    StorageId = foundStorage.ID,
                    Storage = foundStorage
                };
            }

            product.PlaceId = place.ID;
            product.Place = place;
            product.Place.StorageId = foundStorage.ID;
            product.Place.Storage = foundStorage;

            int currPalletes = _db.Products.Where(x => x.ID == product.ID).Select(x => x.NumOfPalletes).FirstOrDefault();
            int arrange = product.NumOfPalletes - currPalletes;
            if (arrange < 0) arrange = 0;

            int numPalletes = NumPalletesInPlace(place.ID) + arrange;
            if (numPalletes > product.Place.MaxPalletes)
                return Content($"Нехватает места для {numPalletes - product.Place.MaxPalletes} паллет в позиции {product.Place.Sector + "/" + product.Place.Number}.");

            Product currentProduct = FoundProduct(product.ID);
            SetProductData(ref currentProduct, ref product);

            _db.Products.Update(currentProduct);
            await _db.SaveChangesAsync();

            return RedirectToAction("Products", "Warehouse");
        }

        private int NumPalletesInPlace(int placeId)
        {
            int numPalletes = 0;

            foreach (Product item in _db.Products.Where(x => x.PlaceId == placeId))
                numPalletes += item.NumOfPalletes;

            return numPalletes;
        }

        private Product FoundProduct(int productId)
        {
            return _db.Products.Where(x => x.ID == productId).Include(p => p.Place).Include(s => s.Place.Storage).FirstOrDefault();
        }

        private void SetProductData(ref Product currentProduct, ref Product newProduct)
        {
            currentProduct.NumOfPalletes = newProduct.NumOfPalletes;
            currentProduct.Name = newProduct.Name;
            currentProduct.Code = newProduct.Code;
            currentProduct.Party = newProduct.Party;
            currentProduct.Term = newProduct.Term;
            currentProduct.Cost = newProduct.Cost;
            currentProduct.PlaceId = newProduct.PlaceId;
            currentProduct.Place = newProduct.Place;
            currentProduct.Place.StorageId = newProduct.Place.StorageId;
            currentProduct.Place.Storage = newProduct.Place.Storage;
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            ViewBag.StorageNames = _db.Storages.Select(s => s.Name).Distinct().ToList();
            ViewBag.StorageTerritories = _db.Storages.Select(s => s.Territory).Distinct().ToList();
            ViewBag.Products = _db.Products.ToList();
            ViewBag.Codes = _db.Products.Select(x => x.Code).Distinct().ToList();
            var currentPlace = _db.Products.Where(x => x.ID == productId).Include(p => p.Place).Include(s => s.Place.Storage).FirstOrDefault();

            return View(currentPlace);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Product product = await _db.Products.FirstOrDefaultAsync(p => p.ID == id);
            if (product != null)
                return View(product);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = new Product { ID = id };

            _db.Entry(product).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToAction("Products", "Warehouse");
        }
    }
}
