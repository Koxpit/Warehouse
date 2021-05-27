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
    public class PositionController : Controller
    {
        private readonly ILogger<PositionController> _logger;
        private readonly WarehouseContext _db;

        public PositionController(ILogger<PositionController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Position position)
        {
            if (ModelState.IsValid)
            {
                if (_db.Positions.FirstOrDefault(x => x.Name == position.Name) != null)
                    return Content("Должность уже существует.");

                _db.Positions.Add(position);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Positions", "Warehouse");
        }

        [HttpGet]
        public IActionResult Edit(int positionId)
        {
            Position currentPosition = _db.Positions.FirstOrDefault(x => x.ID == positionId);

            return View(currentPosition);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                if (_db.Positions.FirstOrDefault(x => x.Name == position.Name && x.ID != position.ID) != null)
                    return Content("Должность уже существует.");

                Position currentPosition = _db.Positions.FirstOrDefault(x => x.ID == position.ID);
                currentPosition.Name = position.Name;

                _db.Positions.Update(currentPosition);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Positions", "Warehouse");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Position position = new Position { ID = id };

            _db.Entry(position).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToAction("Positions", "Warehouse");
        }
    }
}
