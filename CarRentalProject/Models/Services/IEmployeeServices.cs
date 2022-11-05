using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Services
{
    public interface IEmployeeServices
    {
        void Insert(employee employee);
        void Update(employee employee);
        void Delete(employee employee);
        employee FindById(int id);
        List<employee> Search(String str);
        List<employee> AllEmployees();

    }
}
