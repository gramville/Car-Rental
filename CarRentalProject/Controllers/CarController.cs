using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using CarRental.Models;
using CarRental.Models.Services;
using System.Web;
namespace CarRentalProject.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarServices _services;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarController(ICarServices services, IWebHostEnvironment webHostEnvironment)
        {
            _services = services;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult CarsToDisplayForCustomers()
        {
            var AvailableCars = _services.AVailableCars();
            return View(AvailableCars);
        }
        public IActionResult CarsToDisplayForEmployees()
        {
            var AllCars = _services.AllCars();
            return View(AllCars);
        }
        public IActionResult RegisterCar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterCar(car car)
        {
            //if (car.Picture != null && car.RightPicture != null && car.LeftPicture != null && car.BackPicture != null)
            {
                string FrontPath = "Images/Front/";
                string RightPath = "Images/Right/";
                string LeftPath = "Images/Left/";
                string BackPath = "Images/Back/";
                FrontPath += car.Picture.FileName.Substring(0,car.Picture.FileName.ToString().Length-4) + Guid.NewGuid().ToString()+car.Picture.FileName.Substring(car.Picture.FileName.Length - 4);
                RightPath += car.RightPicture.FileName.Substring(0, car.RightPicture.FileName.Length - 4) + Guid.NewGuid().ToString() + car.RightPicture.FileName.Substring(car.RightPicture.FileName.Length - 4);
                LeftPath += car.LeftPicture.FileName.Substring(0, car.LeftPicture.FileName.Length - 4) + Guid.NewGuid().ToString() + car.LeftPicture.FileName.Substring(car.LeftPicture.FileName.Length - 4);
                BackPath += car.BackPicture.FileName.Substring(0, car.BackPicture.FileName.Length - 4) + Guid.NewGuid().ToString() + car.BackPicture.FileName.Substring(car.BackPicture.FileName.Length - 4);
                string FrontserverFolder = Path.Combine(_webHostEnvironment.WebRootPath, FrontPath);
                string RightserverFolder = Path.Combine(_webHostEnvironment.WebRootPath, RightPath);
                string LeftserverFolder = Path.Combine(_webHostEnvironment.WebRootPath, LeftPath);
                string BackserverFolder = Path.Combine(_webHostEnvironment.WebRootPath, BackPath);
                car.Picture.CopyToAsync(new FileStream(FrontserverFolder, FileMode.Create));
                car.RightPicture.CopyToAsync(new FileStream(RightserverFolder, FileMode.Create));
                car.LeftPicture.CopyToAsync(new FileStream(LeftserverFolder, FileMode.Create));
                car.BackPicture.CopyToAsync(new FileStream(BackserverFolder, FileMode.Create));
                car.Fpicture = "/"+FrontPath;
                car.Rpicture = "/" + RightPath;
                car.Lpicture = "/" + LeftPath;
                car.Bpicture = "/" + BackPath;

                _services.Insert(car);
                return RedirectToAction("RegisterCar");
            }
        }
        public IActionResult UpdateCar(int id)
        {
            var updated = _services.FindById(id);
            return View(updated);
        }
        [HttpPost]
        public IActionResult UpdateCar(car car)
        {
            /* _services.cars.Update(car);
             _services.SaveChanges();*/
            _services.Update(car);
            return RedirectToAction("RegisterCar");
        }
        public IActionResult DeleteCar(int id)
        {
            var deleted = _services.FindById(id);
            return View(deleted);
        }
        [HttpPost]
        public IActionResult DeleteCar(int  id , car car)
        {
            /*_services.cars.Remove(car);
            _services.SaveChanges();*/
            var del=_services.FindById(id);
            _services.Delete(del);
            return RedirectToAction("RegisterCar");
        }
       /* public IActionResult Rent(int id)
        {
            var details = _services.FindById(id);
           // return RedirectToAction("RegisterRent", "rent");
            return View(details);
        }
        */
       public IActionResult DeletedCars()
        {
            var del = _services.DeletedCars();
            return View(del);
        }
        public IActionResult RestoreCars(int id)
        {
            _services.RestoreCar(id);
            return RedirectToAction("Index", "Employee");
        }
    }

    
}

