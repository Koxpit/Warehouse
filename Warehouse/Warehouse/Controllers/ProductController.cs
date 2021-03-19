using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Controllers
{
    public class ProductController : Controller
    {
        [HttpPost]
        public IActionResult Add()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
