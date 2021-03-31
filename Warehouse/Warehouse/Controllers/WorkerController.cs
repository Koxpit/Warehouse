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

        [HttpGet]
        public IActionResult FullInfo(string number)
        {
            Worker worker = _db.Workers.Include(p => p.Passport).Include(p => p.Position).FirstOrDefault(w => w.Number == number);

            return View(worker);
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Worker worker = await _db.Workers.FirstOrDefaultAsync(p => p.ID == id);
            if (worker != null)
                return View(worker);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Worker worker = new Worker { ID = id };

            _db.Entry(worker).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToAction("Workers", "Warehouse");
        }
    }
}
