using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace MyCarApp.WebAPI.Controllers
{
    /// <summary>
    /// Car api controller
    /// </summary>
    [RoutePrefix("Car")]
    public class CarController : ApiController
    {
        private readonly ICarManager _carManager;

        public CarController(ICarManager carManager)
        {
            _carManager = carManager;
        }
        
        /// <summary>
        /// Display all cars
        /// </summary>
        /// <returns></returns>
        [Route("GetAll")]
        [Authorize]
        public IHttpActionResult GetAll()
        {
            var response = _carManager.GetAll();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        
        /// <summary>
        /// Get cars by custom search
        /// </summary>
        /// <param name="category"></param>
        /// <param name="budget"></param>
        /// <param name="brand"></param>
        /// <param name="varient"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpGet,Route("ShowCustomPurchaseSearch")]
        public IHttpActionResult GetCars(string category, string budget, string brand, string varient, string location)
        {
            CustomPurchaseSearch custom = new CustomPurchaseSearch
            {
                Brand = brand==null?"null":brand,
                Budget = budget == null ? "null" : budget,
                Category = category == null ? "null" :category,
                Location = location == null ? "null" :location,
                Varient = varient == null ? "null" :varient
            };
            var response = _carManager.ShowCarsBySearchPurchase(custom);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
        /// <summary>
        /// Get cars by brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetByBrand/{brand}")]
        public IHttpActionResult GetByBrand(string brand)
        {
            var response = _carManager.GetByBrand(brand);
            if (response == null) 
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Show cars by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet,Route("ShowCarsByCategory/{category}")]
        public IHttpActionResult ShowCarsByCategory(string category)
        {
            var response = _carManager.ShowCarsByCategory(category);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Create  car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        [Authorize]
        public IHttpActionResult Create([FromBody]Car car)
        {
            if (car.CreaatedBy == Guid.Empty && car.ModifiedBy == Guid.Empty)
            {
                car.ModifiedBy = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
                car.CreaatedBy = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            }
            var response = _carManager.Add(car);
            if (response == false)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Shows car for rent by city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ShowRentCarByCity")]
        public IHttpActionResult ShowRentCarbyCity(string city)
        {
            var response = _carManager.ShowRentCarbyCity(city);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Update car details
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Update")]
        [Authorize]
        public IHttpActionResult Update(Car car)
        {
            if (car.ModifiedBy == Guid.Empty)
            {
                car.ModifiedBy = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            }
            var response = _carManager.Update(car);
            if (response == false)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Get car by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetCar/{id}")]
        public IHttpActionResult GetCar(Guid id)
        {
            var response = _carManager.GetCar(id);
            if (response ==null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Returns Latest cars
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LatestCars")]
        public IHttpActionResult LatestCars()
        {
            var response = _carManager.LatestCars();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
        [HttpPost,Route("AddRating"),Authorize]
        public IHttpActionResult AddReview(RatingVM rating)
        {
            rating.CreatedBy = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            rating.UserId = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            var response = _carManager.AddReview(rating);
            if (response == false)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
        /// <summary>
        /// Returns top cars
        /// </summary>
        /// <param name="IsValueForMoney"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("TopCars/{IsValueForMoney}")]
        public IHttpActionResult TopCars(bool IsValueForMoney)
        {
            var response = _carManager.TopCars(IsValueForMoney);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Delete car
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete/{id}")]
        [Authorize]
        public IHttpActionResult Delete([FromUri]Guid id)
        {
            var response = _carManager.Delete(id);
            if (response == false)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Car category
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetCateogry")]
        public IHttpActionResult Cateogry()
        {
            var response = _carManager.GetAllCategory();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Adds car varient
        /// </summary>
        /// <param name="carVarient"></param>
        /// <returns></returns>
        [HttpPost, Route("AddVarient")]
        [Authorize]
        public IHttpActionResult AddVarient(CarVarient carVarient)
        {
            if(carVarient.CreatedBy == Guid.Empty)
            {
                carVarient.CreatedBy = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            }
            
            if(carVarient.ModifiedBy == Guid.Empty)
            {
                carVarient.ModifiedBy = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            }
            
            var response = _carManager.AddVarient(carVarient);
            if (response == false)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
        /// <summary>
        /// Shows all rent history for a particular user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Rent history by id</returns>
         [HttpGet, Route("GetAllRentHistory")]
         [Authorize]
        public IHttpActionResult GetAllRentHistory()
        {
         
            var userId = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
          
            var response = _carManager.GetAllRentHistory(userId);
            if(response == null)
            {
                return InternalServerError();
            }
            return Ok(response);

        }
        /// <summary>
        /// Shows all purchase history for a particular user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Purchase history by id</returns>
        [HttpGet, Route("GetAllPurchaseHistory")]
        [Authorize]
        public IHttpActionResult GetAllPurchaseHistory()
        {
            var userId = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            var response = _carManager.GetAllPurchaseHistory(userId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);

        }
    }
}
