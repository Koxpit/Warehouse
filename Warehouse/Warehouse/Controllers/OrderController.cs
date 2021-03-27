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
    }
}
