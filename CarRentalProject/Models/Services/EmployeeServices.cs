using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly AppDbContext _context;
        public EmployeeServices(AppDbContext context)
        {
            _context = context;
        }
        public void Insert(employee employee)
        {
            _context.employees.Add(employee);
            _context.SaveChanges();
            
        }
        public void Update(employee employee)
        {
            var updated=_context.employees.Find(employee.Id);
            updated.FirstName = employee.FirstName;
            updated.MiddleName = employee.MiddleName;
            updated.LastName = employee.LastName;
            updated.Phone = employee.Phone;
            updated.Email = employee.Email;
            updated.Password = employee.Password;
            updated.Salary = employee.Salary;
            _context.SaveChanges();
        }
        public void Delete(employee employee)
        {
            //var del = _context.employees.Find(id);
            //_context.employees.Remove(employee);
            employee.Deleted = 1;
            _context.SaveChanges();
        }
        public employee FindById(int id)
        {
            var employee = _context.employees.Find(id);
            return employee;
        }
        public List<employee> Search(String str)
        {
            var rent = _context.employees.Where(temp => temp.FirstName.ToString().Contains(str)).ToList();
            /*var rent1 = _context.employees.Where(temp => temp.CustomerId.ToString().Contains(str)).ToList();
            var rent2 = _context.employees.Where(temp => temp.employeeId.ToString().Contains(str)).ToList();
            var rent3 = _context.employees.Where(temp => temp.CustomerId.ToString().Contains(str)).ToList();*/
            return rent;
        }
        public List<employee> AllEmployees()
        {
            var employees = _context.employees.ToList();
            return employees;
        }
    }
}