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
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly WarehouseContext _db;

        public CustomerController(ILogger<CustomerController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult CustomerNotFound()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Customer customer)
        {
            if (_db.Customers.FirstOrDefault(c => c.PhoneNumber == customer.PhoneNumber) != null)
                return Content("Заказчик с таким номером телефона уже существует.");

            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();

            return RedirectToAction("Customers", "Warehouse");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer customer)
        {
            if (_db.Customers.FirstOrDefault(c => c.PhoneNumber == customer.PhoneNumber && c.ID != customer.ID) != null)
                return Content("Заказчик с таким номером телефона уже существует.");

            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();

            return RedirectToAction("Customers", "Warehouse");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int customerId)
        {
            Customer customer = await _db.Customers.FirstOrDefaultAsync(p => p.ID == customerId);
            if (customer != null)
                return View(customer);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int customerId)
        {
            Customer customer = new Customer { ID = customerId };

            _db.Entry(customer).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToAction("Customers", "Warehouse");
        }
    }
}
