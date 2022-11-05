using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Services
{
    public interface ICarServices
    {
        void Insert(car car);
        void Update(car car);
        void Delete(car car);
        car  FindById(int id);
        List<car> Search(String str);
        List<car> AllCars();
        List<car> AVailableCars();
        List<car> DeletedCars();
        void RestoreCar(int id);
    }
}
