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
            worker.Experience = Math.Abs(worker.Experience);
            worker.Number = Math.Abs(Convert.ToInt32(worker.Number)).ToString();
            worker.Position = _db.Positions.FirstOrDefault(p => p.Name == worker.Position.Name);

            SetWorkerNumber(ref worker);

            if (_db.Positions.FirstOrDefault(x => x.Name == worker.Position.Name) == null)
                return Content($"Должность {worker.Position.Name} недоступна.");

            if (_db.Workers.FirstOrDefault(x => x.Number == worker.Number) != null)
                return Content($"Сотрудник с табельным номером {worker.Number} уже существует.");

            if (_db.Workers.FirstOrDefault(
                x => x.Passport.Series == worker.Passport.Series && 
                x.Passport.Number == worker.Passport.Number || 
                x.PhoneNumber == worker.PhoneNumber) == null)
            {
                _db.Workers.Add(worker);
                await _db.SaveChangesAsync();
            }
            else
            {
                return Content("Сотрудник с введенными паспортными данными / номером телефона уже существует.");
            }

            return RedirectToAction("Workers", "Warehouse");
        }

        private void SetWorkerNumber(ref Worker worker)
        {
            string partOfWorkerNumber = "";

            for (int i = worker.Number.Length; i < 5; i++)
                partOfWorkerNumber += "0";

            partOfWorkerNumber += worker.Number;
            worker.Number = GetWorkerNumberByPosition(worker.Position.Name) + partOfWorkerNumber;
        }

        private string GetWorkerNumberByPosition(string positionName)
        {
            if (positionName == "Грузчик")
                return "0";
            else if (positionName == "Погрузчик")
                return "1";
            else if (positionName == "Кладовщик" || positionName == "Старший кладовщик")
                return "2";

            return "3";
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Positions = _db.Positions.Select(x => x.Name).Distinct();
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int workerId)
        {
            ViewBag.Positions = _db.Positions.Select(x => x.Name).Distinct();
            Worker currentWorker = _db.Workers.Include(x => x.Position).Include(x => x.Passport).FirstOrDefault(x => x.ID == workerId);

            return View(currentWorker);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Worker worker)
        {
            worker.Experience = Math.Abs(worker.Experience);
            worker.Number = Math.Abs(Convert.ToInt32(worker.Number)).ToString();
            worker.Position = _db.Positions.FirstOrDefault(p => p.Name == worker.Position.Name);

            SetWorkerNumber(ref worker);

            if (_db.Positions.FirstOrDefault(x => x.Name == worker.Position.Name) == null)
                return Content($"Должность {worker.Position.Name} недоступна.");

            if (_db.Workers.FirstOrDefault(x => x.Number == worker.Number && x.ID != worker.ID) != null)
                return Content($"Сотрудник с табельным номером {worker.Number} уже существует.");

            if (_db.Workers.FirstOrDefault(
                x => x.Passport.Series == worker.Passport.Series &&
                x.ID != worker.ID &&
                x.Passport.Number == worker.Passport.Number ||
                x.PhoneNumber == worker.PhoneNumber && 
                x.ID != worker.ID) != null)
                return Content("Сотрудник с введенными паспортными данными / номером телефона уже существует.");

            Worker currentWorker = _db.Workers.Include(x => x.Passport).FirstOrDefault(x => x.ID == worker.ID);
            currentWorker.FIO = worker.FIO;
            currentWorker.Birthday = worker.Birthday;
            currentWorker.Position = _db.Positions.FirstOrDefault(p => p.Name == worker.Position.Name);
            currentWorker.Experience = worker.Experience;
            currentWorker.Salary = worker.Salary;
            currentWorker.PhoneNumber = worker.PhoneNumber;
            currentWorker.Passport.Series = worker.Passport.Series;
            currentWorker.Passport.Number = worker.Passport.Number;
            currentWorker.Passport.IssuedAt = worker.Passport.IssuedAt;
            currentWorker.Passport.IssuedWas = worker.Passport.IssuedWas;

            _db.Workers.Update(currentWorker);
            await _db.SaveChangesAsync();

            return RedirectToAction("Workers", "Warehouse");
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
