using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
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
        public async Task<IActionResult> Add(Storage storage, IFormFile uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (_db.Storages.FirstOrDefault(x => x.Name == storage.Name 
                && x.Territory == storage.Territory
                && x.Address == storage.Address) != null)
                    return Content($"Добавление не осуществлено. По адресу {storage.Address} Cклад с именем {storage.Name} на территории {storage.Territory} уже существует.");

                string position = GetLongAndLat(storage.Address);
                string[] coordinates = position.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                double geoLong = Convert.ToDouble(coordinates[0].Replace('.', ','));
                double geoLat = Convert.ToDouble(coordinates[1].Replace('.', ','));

                if (_db.Storages.FirstOrDefault(x => x.GeoLong == geoLong || x.GeoLat == geoLat) != null)
                    return Content($"Добавление не осуществлено. Склад по адресу {storage.Address} уже существует.");

                storage.GeoLong = geoLong;
                storage.GeoLat = geoLat;

                byte[] imageData = GetImageData(uploadImage);
                string base64image = Convert.ToBase64String(imageData);

                storage.StorageImage = imageData;
                storage.StorageImageBase64 = base64image;

                _db.Storages.Add(storage);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Storages", "Warehouse");
        }

        private string GetLongAndLat(string address)
        {
            string url = string.Format($"https://geocode-maps.yandex.ru/1.x/?apikey=730a2c65-310f-4c14-a9e1-2b1ee50da7ef&format=json&geocode={address}&results=1");
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            string position = JObject.Parse(responsereader).SelectToken("response.GeoObjectCollection.featureMember[0].GeoObject.Point.pos").ToString();
            response.Close();

            return position;
        }

        private byte[] GetImageData(IFormFile uploadImage)
        {
            byte[] imageData = null;
            using (BinaryReader binaryReader = new BinaryReader(uploadImage.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)uploadImage.Length);
            }
            return imageData;
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Storage storage, IFormFile uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (_db.Storages.FirstOrDefault(x => x.Name == storage.Name 
                && x.Territory == storage.Territory 
                && x.Address == storage.Address
                && x.ID == storage.ID) != null)
                    return Content($"Добавление не осуществлено. По адресу {storage.Address} Cклад с именем {storage.Name} на территории {storage.Territory} уже существует.");

                string position = GetLongAndLat(storage.Address);
                string[] coordinates = position.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                double geoLong = Convert.ToDouble(coordinates[0].Replace('.', ','));
                double geoLat = Convert.ToDouble(coordinates[1].Replace('.', ','));

                if (_db.Storages.FirstOrDefault(x => x.GeoLong == geoLong || x.GeoLat == geoLat) != null)
                    return Content($"Изменение не осуществлено. Склад по адресу {storage.Address} уже существует.");

                byte[] imageData = GetImageData(uploadImage);
                string base64image = Convert.ToBase64String(imageData);

                Storage currentStorage = _db.Storages.FirstOrDefault(x => x.ID == storage.ID);
                currentStorage.Name = storage.Name;
                currentStorage.Territory = storage.Territory;
                currentStorage.Address = storage.Address;
                storage.GeoLong = geoLong;
                storage.GeoLat = geoLat;
                storage.StorageImage = imageData;
                storage.StorageImageBase64 = base64image;

                _db.Storages.Update(currentStorage);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Storages", "Warehouse");
        }

        [HttpGet]
        public IActionResult Edit(int storageId)
        {
            ViewBag.NamesStorages = _db.Storages.Select(s => s.Name).Distinct().ToList();
            ViewBag.StoragesTerritories = _db.Storages.Select(s => s.Territory).Distinct().ToList();
            ViewBag.AddressStorages = _db.Storages.Select(s => s.Address).Distinct().ToList();

            Storage currentStorage = _db.Storages.FirstOrDefault(x => x.ID == storageId);

            return View(currentStorage);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.NamesStorages = _db.Storages.Select(s => s.Name).Distinct().ToList();
            ViewBag.StoragesTerritories = _db.Storages.Select(s => s.Territory).Distinct().ToList();
            ViewBag.AddressStorages = _db.Storages.Select(s => s.Address).Distinct().ToList();

            return View();
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
