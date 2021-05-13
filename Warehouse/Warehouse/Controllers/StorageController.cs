using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Database;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class StorageController : Controller
    {
        private readonly ILogger<StorageController> _logger;
        private readonly WarehouseContext _db;

        public StorageController(ILogger<StorageController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Storage storage)
        {
            if (_db.Storages.FirstOrDefault(x => x.Name == storage.Name && x.Territory == storage.Territory) == null)
            {
                _db.Storages.Add(storage);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Storages", "Warehouse");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Storage storage)
        {
            if (_db.Storages.FirstOrDefault(x => x.Name == storage.Name && x.Territory == storage.Territory) != null)
                return Content("Склад уже существует");

            Storage currentStorage = _db.Storages.FirstOrDefault(x => x.ID == storage.ID);
            currentStorage.Name = storage.Name;
            currentStorage.Territory = storage.Territory;
            currentStorage.Address = storage.Address;

            _db.Storages.Update(currentStorage);
            await _db.SaveChangesAsync();

            return RedirectToAction("Storages", "Warehouse");
        }

        [HttpGet]
        public IActionResult Edit(int storageId)
        {
            ViewBag.NamesStorages = _db.Storages.Select(s => s.Name).Distinct().ToList();
            ViewBag.StoragesTerritories = _db.Storages.Select(s => s.Territory).Distinct().ToList();

            Storage currentStorage = _db.Storages.FirstOrDefault(x => x.ID == storageId);

            return View(currentStorage);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Storage storage = await _db.Storages.FirstOrDefaultAsync(p => p.ID == id);
            if (storage != null)
                return View(storage);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Storage storage = new Storage { ID = id };

            _db.Entry(storage).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToAction("Storages", "Warehouse");
        }
    }
}
