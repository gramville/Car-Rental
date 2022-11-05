using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Models.Services;

namespace CarRental.Models.Services
{
    public class RentServices:IRentServices
    {
        private readonly AppDbContext _context;
        public RentServices(AppDbContext context)
        {
            _context = context;
        }
        public void Insert(rent rent)
        {
            rent.Fare = 500;
            rent.Returned = 0;
            TimeSpan ts = rent.EndDate - rent.StartDate;
            rent.TotalAmount = ts.Days * rent.Fare;
            Console.WriteLine(rent.CarId);
            Console.WriteLine(rent.CustomerId);
            _context.cars.Find(rent.CarId).Available = 0;
            _context.rents.Add(rent);
            _context.SaveChanges();
        }
        public void Update(rent rent)
        {
            var updated=_context.rents.Find(rent.CustomerId);
            var return_car=_context.cars.Find(rent.CarId);
            return_car.Available = 1;
            updated.Returned = 1;
            _context.SaveChanges();
        }
       public void Delete(rent rent)
        {
            //var del = _context.rents.Find(id);
            _context.rents.Remove(rent);
        }
        public rent FindById(int id)
        {
            var rent = _context.rents.Find(id);
            return rent;
        }
        public List<rent> Search(String str)
        {
           // var rent = _context.rents.Where(temp => temp.Id.ToString().Contains(str)).ToList();
            var rent1=_context.rents.Where(temp => temp.CustomerId.ToString().Contains(str)).ToList();
            var rent2 = _context.rents.Where(temp => temp.CarId.ToString().Contains(str)).ToList();
            var rent3 = _context.rents.Where(temp => temp.CustomerId.ToString().Contains(str)).ToList();
            return rent1;
        }
        public List<rent> AllRents()
        {
            var rents = _context.rents.Where(temp=>temp.Returned==0).ToList();
            return rents;
        }
        public List<rent> ViewRentHistory(int id)
        {
            var rentHistory = _context.rents.Where(temp => temp.CustomerId == id).ToList();
            return rentHistory;
        }
    }
}