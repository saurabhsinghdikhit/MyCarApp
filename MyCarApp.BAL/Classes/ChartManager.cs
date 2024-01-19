using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Classes
{
    public class ChartManager : IChartManager
    {
        private readonly IChartRepository _chartRepository;
        public ChartManager(IChartRepository chartRepository)
        {
            _chartRepository = chartRepository;
        }
        public IEnumerable<TotalCarsVM> TotalCars()
        {
            return _chartRepository.TotalCars();
        }

        public IEnumerable<TotalCarsVM> TotalPurchasedCars()
        {
            return _chartRepository.TotalPurchasedCars();
        }
    }
}
