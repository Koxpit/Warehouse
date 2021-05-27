using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse.Database;
using Warehouse.Models;
using Warehouse.ViewModels;

namespace Warehouse.Controllers
{
    public class CargoController : Controller
    {
        private readonly ILogger<CargoController> _logger;
        private readonly WarehouseContext _db;

        public CargoController(ILogger<CargoController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Info(int cargoId)
        {
            var cargo = _db.Cargos.Include(c => c.Order).FirstOrDefault(i => i.ID == cargoId);

            return View(cargo);
        }

        [HttpGet]
        public IActionResult Add(int orderId)
        {
            ViewBag.Products = _db.Products.ToList();
            ViewBag.OrderId = orderId;
            ViewBag.OrdersIds = _db.Orders.Select(x => x.ID).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                Product product = _db.Products.Where(x => x.ID == cargo.Product.ID).FirstOrDefault();
                cargo.ProductId = product.ID;
                cargo.Product = product;
                Order order = _db.Orders.Where(x => x.ID == cargo.OrderId).FirstOrDefault();
                cargo.OrderId = order.ID;
                cargo.Order = order;

                Cargo existCargo = _db.Cargos.Where(x => x.Number == cargo.Number && x.Product.Name == cargo.Product.Name).FirstOrDefault();
                if (existCargo != null)
                {
                    int numPalletes = 0;
                    foreach (Cargo item in _db.Cargos.Where(x => x.OrderId == cargo.OrderId))
                        numPalletes += item.NumOfPalletes;

                    numPalletes += cargo.NumOfPalletes;
                    if (numPalletes > 22)
                        return Content("Превышено максимальное количество паллет(22) для заказа " + cargo.OrderId);
                    else
                        existCargo.NumOfPalletes += cargo.NumOfPalletes;

                    _db.Cargos.Update(existCargo);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Orders", "Warehouse");
                }

                int palletes = 0;
                foreach (Cargo item in _db.Cargos.Where(x => x.OrderId == cargo.OrderId))
                    palletes += item.NumOfPalletes;
                palletes += cargo.NumOfPalletes;

                if (palletes > 22)
                    return Content("Превышено максимальное количество паллет(22) для заказа " + cargo.OrderId);

                string newCargoNumber = UpdateCargoNumber(cargo.Number);
                cargo.Number = newCargoNumber;

                _db.Cargos.Add(cargo);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Orders", "Warehouse");
        }

        private string UpdateCargoNumber(string number)
        {
            if (number.Length < 8)
                for (int i = number.Length; i < 8; i++)
                    number = "0" + number;

            return number;
        }

        [HttpGet]
        public IActionResult Edit(int cargoId, int orderId)
        {
            Cargo cargo = _db.Cargos.Include(c => c.Order).FirstOrDefault(i => i.ID == cargoId);
            ViewBag.Products = _db.Products.ToList();
            ViewBag.OrderId = orderId;
            ViewBag.OrdersIds = _db.Orders.Select(x => x.ID).ToList();

            return View(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                if (_db.Cargos.FirstOrDefault(x => x.Number == cargo.Number && x.ID != cargo.ID) != null)
                    return Content("Груз с таким номером уже существует.");

                Product product = _db.Products.Where(x => x.ID == cargo.Product.ID).FirstOrDefault();
                if (product == null)
                    return Content("Продукт не существует.");

                cargo.ProductId = product.ID;
                cargo.Product = product;

                Order order = _db.Orders.Where(x => x.ID == cargo.OrderId).FirstOrDefault();
                if (order == null)
                    return Content("Заказ не существует.");

                cargo.OrderId = order.ID;
                cargo.Order = order;

                int numPalletes = 0;
                foreach (Cargo item in _db.Cargos.Where(x => x.OrderId == cargo.OrderId && x.ID != cargo.ID))
                    numPalletes += item.NumOfPalletes;

                if (numPalletes > 22)
                    return Content("Превышено максимальное количество паллет(22) для заказа " + cargo.OrderId);

                string newCargoNumber = UpdateCargoNumber(cargo.Number);
                cargo.Number = newCargoNumber;

                _db.Cargos.Update(cargo);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Orders", "Warehouse");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Cargo cargo = new Cargo { ID = id };

            _db.Entry(cargo).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToAction("Orders", "Warehouse");
        }
    }
}
