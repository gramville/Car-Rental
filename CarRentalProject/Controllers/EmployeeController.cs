using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models.Services;
using CarRental.Models;

namespace CarRentalProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _services;
        public EmployeeController(IEmployeeServices services)
        {
            _services = services;
        }
        public IActionResult Index()
        {
            return RedirectToAction("CarsToDisplayForEmployees","Car");
        }
        public IActionResult RegisterEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterEmployee(employee employee)
        {
            _services.Insert(employee);
            return RedirectToAction();
        }
        public IActionResult UPdateEmployee(int id)
        {
            var employee=_services.FindById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult UPdateEmployee(employee employee)
        {
            _services.Update(employee);
            return RedirectToAction();
        }
        public IActionResult DeleteEmployee(int id)
        {
            var employee=_services.FindById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int id, employee employee)
        {
           var del=_services.FindById(id);
            _services.Delete(del);
            return RedirectToAction();
        }
        
        public IActionResult DeletedCars()
        {
            return RedirectToAction("DeletedCars", "Car");
        }

        public IActionResult DeletedCutomers()
        {
            return RedirectToAction("DeletedCutomers", "CustomerController");
        }

        


    }
}
