using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Services
{
    public interface ICustomerServices
    {
        void Insert(customer customer);
        void Update(customer customer);
        void Delete(customer customer);
        customer FindById(int id);
        List<customer> Search(String str);
        List<customer> AllCustomers();
        List<customer> verify(int id, string password);
        customer Login(int id, string password);
        List<customer> DeletedCutomers();
        void RestoreCustomer(int id);
    }
}
