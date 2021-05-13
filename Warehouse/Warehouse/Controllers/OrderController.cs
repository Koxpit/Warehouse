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
            var order = _db.Orders.Include(c => c.Customer).FirstOrDefault(i => i.ID == Convert.ToInt32(orderId));

            return View(order);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Order order)
        {
            Customer currentCustomer = _db.Customers.FirstOrDefault(x => x.FIO == order.Customer.FIO && x.PhoneNumber == order.Customer.PhoneNumber);

            if (currentCustomer == null)
                return RedirectToAction("CustomerNotFound", "Customer");
            else
                order.Customer = currentCustomer;



            return View();
        }

        [HttpGet]
        public IActionResult AddCargo(int orderId)
        {
            ViewBag.Products = _db.Products.ToList();

            CargoOrderViewModel cargoOrderViewModel = new CargoOrderViewModel
            {
                OrderId = orderId,
                Cargo = new Cargo()
                {
                    Product = new Product()
                }
            };

            return View(cargoOrderViewModel);
        }

        [HttpPost]
        public IActionResult AddCargo(CargoOrderViewModel cargoOrderViewModel)
        {
            Order currentOrder = _db.Orders.Include(x => x.Cargos).Where(x => x.ID == cargoOrderViewModel.OrderId).FirstOrDefault();
            var currentCargos = currentOrder.Cargos;
            if (currentCargos.FirstOrDefault(x => x.Number == cargoOrderViewModel.Cargo.Number) != null)
            {
                return Content("Груз с выбранным номером принадлежит другому заказу. Измените номер груза.");
            }

            return View();
        }
    }
}
