using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
