using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Repository.Interfaces
{
    public interface IChartRepository
    {
        IEnumerable<TotalCarsVM> TotalCars();
        IEnumerable<TotalCarsVM> TotalPurchasedCars();
    }
}
