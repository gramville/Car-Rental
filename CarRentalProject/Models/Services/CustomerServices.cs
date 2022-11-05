using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly AppDbContext _context;
        public CustomerServices(AppDbContext context)
        {
            _context = context;
        }
        public void Insert(customer customer)
        {
            _context.customers.Add(customer);
            _context.SaveChanges();
            

        }
        public void Update(customer customer)
        {
            var updated = _context.customers.Find(customer.Id);
            updated.FirstName = customer.FirstName;
            updated.MiddleName = customer.MiddleName;
            updated.LastName = customer.LastName;
            updated.Phone = customer.Phone;
            updated.Email = customer.Email;
            updated.Password = customer.Password;
            _context.SaveChanges();
        }
        public void Delete(customer customer)
        {
            //var del = _context.customers.Find(id);
            //_context.customers.Remove(customer);
            customer.Deleted = 1;
            _context.SaveChanges();
        }
        public customer FindById(int id)
        {
            var customer = _context.customers.Find(id);
            return customer;
        }
        public List<customer> Search(String str)
        {
            var customer = _context.customers.Where(temp => temp.FirstName.ToString().Contains(str)).ToList();
            /*var rent1 = _context.customers.Where(temp => temp.CustomerId.ToString().Contains(str)).ToList();
            var rent2 = _context.customers.Where(temp => temp.employeeId.ToString().Contains(str)).ToList();
            var rent3 = _context.customers.Where(temp => temp.CustomerId.ToString().Contains(str)).ToList();*/
            return customer;
        }
        public List<customer> AllCustomers()
        {
            var customers = _context.customers.ToList();
            return customers;
        }
        public customer Login(int id, string password)
        {
            var customer = _context.customers.Where(temp => temp.Id == id && temp.Password == password && temp.Deleted==0).FirstOrDefault();
            return customer;
        }
        public List<customer> verify(int id, string password)
        {
            return _context.customers.Where(temp => temp.Id == id && temp.Password == password && temp.Deleted == 0).ToList();
        }

        public List<customer> DeletedCutomers()
        {
           var deletedCustomers = _context.customers.Where(temp => temp.Deleted == 1).ToList();
            return deletedCustomers;
        }
        public void RestoreCustomer(int id)
        {
            var res = _context.customers.Find(id);
            res.Deleted = 0;
            _context.SaveChanges();
        }
    }
}