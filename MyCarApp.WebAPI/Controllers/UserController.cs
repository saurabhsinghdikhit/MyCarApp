using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace MyCarApp.WebAPI.Controllers
{

    //User api controller
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Method for user login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost,Route("Login")]
        public IHttpActionResult Login(UserLoginVM model)
        {
            var record = _userManager.Login(model);
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
        /// Get details of user from user id
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("Get")]
        [Authorize]
        public IHttpActionResult Get()
        {
            var userId = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            var response = _userManager.Get(userId);
            if(response!=null)
            {
                return Ok(response);
            }
            return InternalServerError();
            
        }

        /// <summary>
        /// Method for creating user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost,Route("Create")]
        public IHttpActionResult Create([FromBody]User user)
        {
            var response = _userManager.Create(user);
            if(response)
            {
                return Ok(response); 
            }
            return InternalServerError();

        }

        /// <summary>
        /// Method to update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut, Route("Update")]
        [Authorize]
        public IHttpActionResult Update([FromBody]User user)
        {

            if(user.UserId == Guid.Empty)
            {
                user.UserId = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            }

            var response = _userManager.Update(user);
            if(response)
            {
                return Ok(response); 
            }

            return InternalServerError();

        }

        /// <summary>
        /// Method to delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("Delete")]
        [Authorize]
        public IHttpActionResult Delete([FromUri]Guid id)
        {
            var response = _userManager.Delete(id);
            if(response)
            {
                return Ok(response); 
            }

            return InternalServerError();
        }

        /// <summary>
        /// Method for forgot password action of user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet, Route("ForgotPassword")]
        public IHttpActionResult ForgotPassword(string email)
        {
            var response = _userManager.ForgotPassword(email);
            if(response!=-1)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpPost, Route("SetPassword")]
        public IHttpActionResult SetPassword(AdminLoginVM model)
        {
            var response = _userManager.setNewPassword(model.Email, model.Passowrd);
            if(response)
            {
                return Ok(response);
            }
            return InternalServerError();
        }

        [HttpPost, Route("StatusPending")]
        public IHttpActionResult pendingStatus(UpdateStatus status)
        {
            var response = _userManager.pendingStatus(status.id, status.IsRent);
            if (response)
            {
                return Ok(response);
            }
            return InternalServerError();
        }

        [HttpPost, Route("StatusReject")]
        public IHttpActionResult rejectStatus(UpdateStatus status)
        {
            var response = _userManager.rejectStatus(status.id, status.IsRent);
            if (response)
            {
                return Ok(response);
            }
            return InternalServerError();
        }
        [HttpPost, Route("StatusApprove")]

        public IHttpActionResult approveStatus(UpdateStatus status)
        {
            var response = _userManager.approveStatus(status.id, status.IsRent);
            return Ok(response);
        }
    }
}
