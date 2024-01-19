using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Interfaces
{
    public interface IChartManager
    {
        IEnumerable<TotalCarsVM> TotalCars();
        IEnumerable<TotalCarsVM> TotalPurchasedCars();
    }
}
