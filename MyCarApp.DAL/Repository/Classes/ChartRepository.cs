using MyCarApp.BE.ViewModels;
using MyCarApp.Common.Enums;
using MyCarApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Repository.Classes
{
    public class ChartRepository : IChartRepository
    {
        private readonly DAL.Database.MyCarDBEntities _dbContext;
        public ChartRepository()
        {
            _dbContext = new Database.MyCarDBEntities();
        }
        public IEnumerable<TotalCarsVM> TotalCars()
        {
            List<TotalCarsVM> totalCarsVM = new List<TotalCarsVM>();
            foreach (BrandEnum val in Enum.GetValues(typeof(BrandEnum)))
            {
                
                totalCarsVM.Add(new TotalCarsVM
                {   CarCount= _dbContext.Cars.Where(x => x.Brand == val.ToString()).Count(),
                    CarName=val.ToString()
                });
            }
            return totalCarsVM;
        }

        public IEnumerable<TotalCarsVM> TotalPurchasedCars()
        {
            List<TotalCarsVM> totalCarsVM = new List<TotalCarsVM>();
            foreach (BrandEnum val in Enum.GetValues(typeof(BrandEnum)))
            {

                totalCarsVM.Add(new TotalCarsVM
                {
                    CarCount = _dbContext.CarPurchases.Where(x => x.CarVarient.Car.Brand == val.ToString()).Count(),
                    CarName = val.ToString()
                });
            }
            return totalCarsVM;
        }
    }
}
