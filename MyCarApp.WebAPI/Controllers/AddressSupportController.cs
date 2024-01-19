using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyCarApp.WebAPI.Controllers
{
    /// <summary>
    /// Address controller
    /// </summary>
    [RoutePrefix("AddressSupport")]
    public class AddressSupportController : ApiController
    {
        private readonly IAddressSupportManager _addressSupportManager;

        public AddressSupportController(IAddressSupportManager addressSupportManager)
        {
            _addressSupportManager = addressSupportManager;
        }

        /// <summary>
        /// Method for get countries
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Countries")]
        public IHttpActionResult GetCountries()
        {
            var response = _addressSupportManager.GetCountries();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Method for getting states from country id
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns>Shows states</returns>
        [HttpGet]
        [Route("States")]
        public IHttpActionResult GetStates(Guid CountryId)
        {
            var response = _addressSupportManager.GetStates(CountryId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Method for getting cities from state id
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns>Shows cities</returns>
        [HttpGet]
        [Route("Cities")]
        public IHttpActionResult GetCities(Guid StateId)
        {
            var response = _addressSupportManager.GetCities(StateId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Method for getting pincodes from city id
        /// </summary>
        /// <param name="CityId"></param>
        /// <returns>Shows pincodes</returns>
        [HttpGet]
        [Route("Pincodes")]
        public IHttpActionResult GetPincodes(Guid CityId)
        {
            var response = _addressSupportManager.GetPincodes(CityId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Saves address into database
        /// </summary>
        /// <param name="addressVM"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateAddress")]
        public IHttpActionResult CreateAddress(CarDetails addressVM)
        {
            var response = _addressSupportManager.AddAddress(addressVM);
            if (response != true)
            {
                return InternalServerError();
            }
            return Ok();
        }

        /// <summary>
        /// Check Pincode Availability
        /// </summary>
        /// <param name="pincode">Pincode</param>
        /// <returns>Available or Not</returns>
        [HttpGet]
        [Route("PincodeCheck")]
        public IHttpActionResult AddressCheckAvail(string pincode)
        {
            var response = _addressSupportManager.AddressCheckAvail(pincode);
            if(response)
            {
                return Ok("Avaiable");
            }
            else
            {
                return Ok("NotAvailable");
            }
            return NotFound();
        }
    }
}
