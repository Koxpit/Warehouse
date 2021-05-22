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
    public class ReportController : Controller
    {
        private readonly ILogger<WorkerController> _logger;
        private readonly WarehouseContext _db;

        public ReportController(ILogger<WorkerController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IActionResult Expiration()
        {
            return View();
        }
    }
}
