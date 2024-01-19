using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Interfaces
{
    public interface ICarManager
    {
        bool AddReview(RatingVM rating);

        bool Add(Car car);
        IEnumerable<Car> GetAll();
        IEnumerable<Car> GetByBrand(string brand);
        IEnumerable<Car> ShowCarsByCategory(string category);
        IEnumerable<Car> ShowCarsBySearchPurchase(CustomPurchaseSearch custom);
        IEnumerable<Car> ShowRentCarbyCity(string city);
        bool Update(Car car);
        bool Delete(Guid Carid);
        IEnumerable<Car> LatestCars();
        IEnumerable<Car> TopCars(bool IsValueForMoney);
        Car GetCar(Guid Carid);
        IEnumerable<CustomDropdown> GetAllCategory();
        bool AddVarient(CarVarient varient);
        IEnumerable<RentPdfVM> GetAllRentHistory(Guid id);
        IEnumerable<PdfVM> GetAllPurchaseHistory(Guid id);
    }
}
