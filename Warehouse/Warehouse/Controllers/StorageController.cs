using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Warehouse.Database;
using Warehouse.Models;

namespace Warehouse.Controllers
{
    public class StorageController : Controller
    {
        private readonly ILogger<StorageController> _logger;
        private readonly WarehouseContext _db;

        public StorageController(ILogger<StorageController> logger, WarehouseContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Storage storage)
        {
            if (_db.Storages.FirstOrDefault(x => x.Name == storage.Name && x.Territory == storage.Territory) == null)
            {
                string url = string.Format("https://maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key=AIzaSyA7wuEtL3ZAzIeRhSPIJ21K3Y6vEIP9hfk");
                //Выполняем запрос к универсальному коду ресурса (URI).
                System.Net.HttpWebRequest request =
                    (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                //Получаем ответ от интернет-ресурса.
                System.Net.WebResponse response =
                    request.GetResponse();

                //Экземпляр класса System.IO.Stream 
                //для чтения данных из интернет-ресурса.
                System.IO.Stream dataStream =
                    response.GetResponseStream();

                //Инициализируем новый экземпляр класса 
                //System.IO.StreamReader для указанного потока.
                System.IO.StreamReader sreader =
                    new System.IO.StreamReader(dataStream);

                //Считывает поток от текущего положения до конца.            
                string responsereader = sreader.ReadToEnd();
                return Content(responsereader);

                //Закрываем поток ответа.
                response.Close();

                _db.Storages.Add(storage);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Storages", "Warehouse");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Storage storage)
        {
            if (_db.Storages.FirstOrDefault(x => x.Name == storage.Name && x.Territory == storage.Territory) != null)
                return Content("Склад уже существует");

            Storage currentStorage = _db.Storages.FirstOrDefault(x => x.ID == storage.ID);
            currentStorage.Name = storage.Name;
            currentStorage.Territory = storage.Territory;
            currentStorage.Address = storage.Address;

            _db.Storages.Update(currentStorage);
            await _db.SaveChangesAsync();

            return RedirectToAction("Storages", "Warehouse");
        }

        [HttpGet]
        public IActionResult Edit(int storageId)
        {
            ViewBag.NamesStorages = _db.Storages.Select(s => s.Name).Distinct().ToList();
            ViewBag.StoragesTerritories = _db.Storages.Select(s => s.Territory).Distinct().ToList();

            Storage currentStorage = _db.Storages.FirstOrDefault(x => x.ID == storageId);

            return View(currentStorage);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            Storage storage = await _db.Storages.FirstOrDefaultAsync(p => p.ID == id);
            if (storage != null)
                return View(storage);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Storage storage = new Storage { ID = id };

            _db.Entry(storage).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return RedirectToAction("Storages", "Warehouse");
        }
    }
}
