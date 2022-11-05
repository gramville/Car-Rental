using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.Services;
using CarRentalProject.Models;

namespace CarRentalProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerServices _service;
        
        public CustomerController(ICustomerServices services)
        {
            _service = services;
        }
       

        public IActionResult Index()
        {
            return RedirectToAction("CarsToDisplayForCustomers","Car");
        }
        public IActionResult ListOfCustomers()
        {
            return View();
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(customer customer)
        {
            /*_service.customers.Add(customer);
            _service.SaveChanges();*/
            _service.Insert(customer);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateUser(int id)
        {
            var updated = _service.FindById(id);
            return View(updated);
        }
        [HttpPost]
        public IActionResult UpdateUser(customer customer)
        {
            /*_service.customers.Update(customer);
            _service.SaveChanges();*/
            _service.Update(customer);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteUser(int id)
        {
            var deleted = _service.FindById(id);
            return View(deleted);
        }
        [HttpPost]
        public IActionResult DeleteUser(customer customer)
        {
            /*_service.customers.Remove(customer);
            _service.SaveChanges();*/
            _service.Delete(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Rent(int id)
        {

            return RedirectToAction("Rent", "Car");
        }

        public IActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerLogin(Login login)
        {
            
            var check = _service.verify(login.id ,login.password);
            if (check.Count>0)
            {
                
                string emailstring = login.id.ToString();
                byte[] bytearray = System.Text.Encoding.ASCII.GetBytes(emailstring);
                HttpContext.Session.Set("Id", bytearray);
                return RedirectToAction("Index");
            }
            else
            {
                // HttpContext.Current.Session.Add("Title", "Data");
                return RedirectToAction("LoginError");
            }
            
        }
        public IActionResult LoginError()
        {
            
            return View();
        }
        public IActionResult DeletedCutomers()
        {
            var del = _service.DeletedCutomers();
            return View(del);
        }
        public IActionResult RestoreCustomer(int id)
        {
            _service.RestoreCustomer(id);
            return RedirectToAction("Index", "Employee");
        }

    }
}
