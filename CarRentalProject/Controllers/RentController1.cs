using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models.Services;
using CarRental.Models;

namespace CarRentalProject.Controllers
{
    public class RentController1 : Controller
    {
        private readonly AppDbContext _services;
        // private readonly ICarServices _carServices;
        public RentController1(AppDbContext services)//, ICarServices carServices)
        {
            _services = services;
           // _carServices = carServices;
        }
        public IActionResult Index()
        {
            var rents = _services.rents.Where(temp=>temp.Returned==0).ToList();
            return View(rents);
        }
       public IActionResult RegisterRent(int id)
        {
            var rent = _services.cars.Find(id);
            rent r = new rent();
            r.ModelNumber = rent.ModelNumber;
            r.ManufactureDate = rent.ManufactureDate;
            r.PlateNumber = rent.PlateNumber;
            r.CarId = rent.Id;
            r.Fare = 500;
            r.TotalAmount = 500;
            r.StartDate = r.EndDate=DateTime.Now;
            r.Returned = 0;
            r.FPicture = rent.Fpicture;
            r.RPicture = rent.Rpicture;
            r.LPicture = rent.Lpicture;
            r.BPicture = rent.Bpicture;
            return View(r);
        }
        [HttpPost]
        public IActionResult RegisterRent(rent rent)
        { 
            _services.rents.Add(rent);
            var rentedCar = _services.cars.Find(rent.CarId);
            rentedCar.Available = 0;
            rent.Fare = 500;
            rent.Returned = 0;
            TimeSpan ts = rent.EndDate - rent.StartDate;
            if (ts.Days == 0) rent.TotalAmount = 500;
            else
            {
                rent.TotalAmount = ts.Days * rent.Fare;
            }
            _services.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public IActionResult Update(int id)
        {
            var updated = _services.rents.Find(id);
            return View(updated);
        }

        [HttpPost]
        public IActionResult Update(rent rent)
        {
           // var Return_rent = _services.rents.Where(temp => temp.CarId == rent.CarId).OrderByDescending(s=>s.Returned).Last();
            var return_car = _services.cars.Where(temp => temp.Id == rent.CarId).FirstOrDefault();
            return_car.Available = 1;
            //Return_rent.Returned = 1;
            _services.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }
        public IActionResult ViewRentHistory(int id)
        {
            var rentHistory=_services.rents.Where(temp => temp.CustomerId == id).ToList();
            return View(rentHistory);
        }
        /*public IActionResult Rent(rent rent)
        {
           // _services.Insert(rent);
            return RedirectToAction("Index", "Customer");
        }*/
    }
}
