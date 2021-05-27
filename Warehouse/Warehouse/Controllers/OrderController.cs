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
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly WarehouseContext _db;

        public OrderController(ILogger<OrderController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Info(string orderId)
        {
            var order = _db.Orders.Include(c => c.Customer).Include(x => x.Vehicle).Include(x => x.Vehicle.Driver).FirstOrDefault(i => i.ID == Convert.ToInt32(orderId));

            return View(order);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ClientsPhones = _db.Customers.Select(x => x.PhoneNumber);
            ViewBag.NumbersVehicles = _db.Vehicles.Select(x => x.Number);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            if (ModelState.IsValid)
            {
                Customer currentCustomer = _db.Customers.FirstOrDefault(x => x.PhoneNumber == order.Customer.PhoneNumber);
                Vehicle currentVehicle = _db.Vehicles.FirstOrDefault(x => x.Number == order.Vehicle.Number);

                if (currentCustomer == null)
                    return RedirectToAction("CustomerNotFound", "Customer");
                else
                    order.Customer = currentCustomer;

                if (currentVehicle == null)
                    return Content("Авто не найден.");
                else
                    order.Vehicle = currentVehicle;

                UpdateOrderNumber(ref order);

                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Orders", "Warehouse");
        }

        private void UpdateOrderNumber(ref Order order)
        {
            string number = order.Number;

            if (number.Length < 5)
                for (int i = number.Length; i < 5; i++)
                    number = "0" + number;

            order.Number = number;
        }

        [HttpGet]
        public IActionResult Edit(int orderId)
        {
            ViewBag.ClientsPhones = _db.Customers.Select(x => x.PhoneNumber);
            ViewBag.NumbersVehicles = _db.Vehicles.Select(x => x.Number);
            Order order = _db.Orders.Where(x => x.ID == orderId).Include(x => x.Customer).Include(x => x.Vehicle).Include(x => x.Vehicle.Driver).FirstOrDefault();

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                if (_db.Orders.FirstOrDefault(x => x.Number == order.Number && x.ID != order.ID) != null)
                    return Content("Заказ с таким номером уже существует.");

                Customer currentCustomer = _db.Customers.FirstOrDefault(x => x.PhoneNumber == order.Customer.PhoneNumber);
                if (currentCustomer == null)
                    return RedirectToAction("CustomerNotFound", "Customer");
                else
                    order.Customer = currentCustomer;

                Vehicle currentVehicle = _db.Vehicles.FirstOrDefault(x => x.Number == order.Vehicle.Number);
                if (currentVehicle == null)
                    return Content("Авто не найден.");
                else
                    order.Vehicle = currentVehicle;

                UpdateOrderNumber(ref order);

                _db.Orders.Update(order);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Orders", "Warehouse");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Order order = new Order { ID = id };

            _db.Entry(order).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToAction("Orders", "Warehouse");
        }
    }
}
