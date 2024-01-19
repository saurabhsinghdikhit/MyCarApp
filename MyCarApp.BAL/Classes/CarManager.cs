using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Classes
{
    public class CarManager : ICarManager
    {
        private readonly CarRepository _carRepository;

        public CarManager(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public bool Add(Car car)
        {
            return _carRepository.Add(car);
        }

        public IEnumerable<Car> ShowRentCarbyCity(string city)
        {
            return _carRepository.ShowRentCarbyCity(city);
        }

        public bool AddVarient(CarVarient varient)
        {
            return _carRepository.AddVarient(varient);
        }

        public bool Delete(Guid Carid)
        {
            return _carRepository.Delete(Carid);
        }

        public IEnumerable<Car> GetAll()
        {
            return _carRepository.GetAll();
        }

        public IEnumerable<Car> GetByBrand(string brand)
        {
            return _carRepository.GetByBrand(brand);
        }

        public IEnumerable<CustomDropdown> GetAllCategory()
        {
            return _carRepository.GetAllCategory();
        }

        public Car GetCar(Guid Carid)
        {
            return _carRepository.GetCar(Carid);
        }

        public IEnumerable<Car> LatestCars()
        {
            return _carRepository.LatestCars();
        }

        public IEnumerable<Car> TopCars(bool IsValueForMoney)
        {
            return _carRepository.TopCars(IsValueForMoney);
        }

        public IEnumerable<Car> ShowCarsByCategory(string category)
        {
            return _carRepository.ShowCarsByCategory(category);
        }

        public bool Update(Car car)
        {
            return _carRepository.Update(car);
        }

        public IEnumerable<Car> ShowCarsBySearchPurchase(CustomPurchaseSearch custom)
        {
            return _carRepository.ShowCarsBySearchPurchase(custom);
        }

        public IEnumerable<RentPdfVM> GetAllRentHistory(Guid id)
        {
            return _carRepository.GetAllRentHistory(id);
        }

        public IEnumerable<PdfVM> GetAllPurchaseHistory(Guid id)
        {
            return _carRepository.GetAllPurchaseHistory(id);
        }

        public bool AddReview(RatingVM rating)
        {
            return _carRepository.AddReview(rating);
        }
    }
}
