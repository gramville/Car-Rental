using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Models.Services;

namespace CarRental.Models
{
    public class CarServices : ICarServices
    {
        private readonly AppDbContext _context;
        public CarServices(AppDbContext context)
        {
            _context = context;
        }
        public void Insert(car car)
        {
            _context.cars.Add(car);
            _context.SaveChanges();
        }
        public void Update(car car)
        {
            var updated=_context.cars.Find(car.Id);
            updated.ModelNumber = car.ModelNumber;
            updated.ManufactureDate = car.ManufactureDate;
            updated.Available = car.Available;
            updated.PlateNumber = car.PlateNumber;
            /*updated.Picture = car.Picture;
            updated.LeftPicture = car.LeftPicture;
            updated.RightPicture = car.RightPicture;
            updated.BackPicture = car.BackPicture;*/
            _context.SaveChanges();
        }
        public void Delete(car car)
        {
            //var del = _context.cars.Find(id);
            //_context.cars.Remove(car);
            car.Deleted = 1;
            _context.SaveChanges();
        }
        public car FindById(int id)
        {
            var car = _context.cars.Find(id);
            return car;
        }
        public List<car> Search(String str)
        {
            var rent = _context.cars.Where(temp => temp.Id.ToString().Contains(str)).ToList();
            /*var rent1 = _context.cars.Where(temp => temp.CustomerId.ToString().Contains(str)).ToList();
            var rent2 = _context.cars.Where(temp => temp.CarId.ToString().Contains(str)).ToList();
            var rent3 = _context.cars.Where(temp => temp.CustomerId.ToString().Contains(str)).ToList();*/
            return rent;
        }
        public List<car> AllCars()
        {
            var cars = _context.cars.Where(temp=>temp.Deleted==0).ToList();
            return cars;
        }
        public List<car> DeletedCars()
        {
            var deletedCars = _context.cars.Where(temp => temp.Deleted == 1).ToList();
            return deletedCars;
        }
        public List<car> AVailableCars()
        {
            var availableCars = _context.cars.Where(temp => temp.Available == 1).ToList();
            return availableCars;
        }
        public void RestoreCar(int id)
        {
            var restoredCar = _context.cars.Find(id);
            restoredCar.Deleted = 0;
            _context.SaveChanges();
        }
    }
}