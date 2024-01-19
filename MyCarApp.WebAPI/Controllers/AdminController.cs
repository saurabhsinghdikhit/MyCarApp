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
    /// Admin api controller
    /// </summary>
    public class AdminController : ApiController
    {
        private readonly IAdminManager _adminManager;

        public AdminController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }

        /// <summary>
        /// Shows all admins
        /// </summary>
        /// <returns>List of all admins</returns>
        [HttpGet,Route("Admin/all")]
        public IHttpActionResult getAdmins()
        {
            return Ok(_adminManager.getAllAdmins());
        }

        /// <summary>
        /// Method for admin login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, Route("admin/login")]
        
        //[Authorize]
        public IHttpActionResult Login(AdminLoginVM model)
        {
            var record = _adminManager.Login(model.Email,model.Passowrd);
            if (record != null)
            {
                return Ok(record);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Method for getting all rented cars history
        /// </summary>
        /// <returns>Rent car history</returns>
        [HttpGet, Route("admin/GetAllRent")]
        public IHttpActionResult GetAllRent()
        {
            var response = _adminManager.GetAllRent();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Method for getting all purchased cars history
        /// </summary>
        /// <returns>Purchase car history</returns>
        [HttpGet, Route("admin/GetAllPurchase")]
        public IHttpActionResult GetAllPurchase()
        {
            var response = _adminManager.GetAllPurchase();
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet, Route("admin/GetAllPendingRefund")]
        public IHttpActionResult GetPurchasePendingRefund(bool IsRent)
        {
            dynamic response;
            if(IsRent)
            {
                response = _adminManager.GetRentPendingRefund();
            }
            else
            {
                response = _adminManager.GetPurchasePendingRefund();
            }
            
            if(response!=null)
            {
                return Ok(response);
            }
            return NotFound();
        }
    }
}
