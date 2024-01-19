using MyCarApp.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyCarApp.WebAPI.Controllers
{
    [RoutePrefix("Charts")]
    public class ChartsController : ApiController
    {
        
        private readonly IChartManager _chartManager;
        public ChartsController(IChartManager chartManager)
        {
            _chartManager = chartManager;

        }
        [HttpGet,Route("Cars")]
        public IHttpActionResult TotalCars()
        {
            Dictionary<string, IEnumerable<BE.ViewModels.TotalCarsVM>> cars = new Dictionary<string, IEnumerable<BE.ViewModels.TotalCarsVM>>();
            cars.Add("total", _chartManager.TotalCars());
            cars.Add("purchase", _chartManager.TotalPurchasedCars());
            return Ok(cars);
        }
    }
}
