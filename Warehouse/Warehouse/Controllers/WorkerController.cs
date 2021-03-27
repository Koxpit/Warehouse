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
    public class WorkerController : Controller
    {
        private readonly ILogger<WorkerController> _logger;
        private readonly WarehouseContext _db;

        public WorkerController(ILogger<WorkerController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Worker worker)
        {
            if (_db.Workers.FirstOrDefault(x => x.Passport.Series == worker.Passport.Series 
            && x.Passport.Number == worker.Passport.Number
            || x.PhoneNumber == worker.PhoneNumber) == null)
            {
                _db.Workers.Add(worker);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Workers", "Warehouse");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
