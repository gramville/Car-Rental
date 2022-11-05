using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Services
{
    public interface IRentServices
    {
        void Insert(rent rent);
        void Update(rent rent);
        void Delete(rent rent);
        rent FindById(int id);
        List<rent> Search(String str);
        List<rent> AllRents();
        List<rent> ViewRentHistory(int id);
    }
}
