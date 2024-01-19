using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.BussinessEntities;

namespace MyCarApp.WebAPI.Controllers
{
    /// <summary>
    /// Support controller
    /// </summary>
    public class SupportController : ApiController
    {
        private readonly ISupportManager _supportManager;

        public SupportController(ISupportManager supportManager)
        {
            this._supportManager = supportManager;
        }

        /// <summary>
        /// Shows all contact us details
        /// </summary>
        /// <returns>List of contact us</returns>
        [HttpGet,Route("Support/GetAll")]
        public IHttpActionResult GetAll()
        {
            var response = _supportManager.getAll();
            if(response!=null)
            {
                return Ok(response);
            }
            else
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Create contact us entry in database
        /// </summary>
        /// <param name="contactUs"></param>
        /// <returns>Contact us details in database</returns>
        [HttpPost, Route("Support/Create")]
        public IHttpActionResult Create(ContactUs contactUs)
        {
            var response = _supportManager.Create(contactUs);
            if(response)
            {
                return Ok(response);
            }
            else
            {
                return InternalServerError();
            }
            
        }

        /// <summary>
        /// Shows FAQs
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("FAQ/GetAll")]
        public IHttpActionResult GetFaq()
        {
            var response = _supportManager.GetFaq();

            if(response!=null)
            {
                return Ok(response);
            }
            return InternalServerError();
        }
        [HttpGet, Route("Feedback/GetAll")]
        public IHttpActionResult GetFeedbacks()
        {
            var response = _supportManager.getAllFeedback();

            if (response != null)
            {
                return Ok(response);
            }
            return InternalServerError();
        }

        /// <summary>
        /// Create feedback entry in database
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns>Feedback details in database</returns>
        [HttpPost]
        [Route("Support/CreateFeedback")]
        public IHttpActionResult CreateFeedback(Feedback feedback)
        {
            
            var response = _supportManager.CreateFeedback(feedback);
            if (response == false)
            {
                return InternalServerError();
            }
            return Ok();
        }

        /// <summary>
        /// Shows feedback categories
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetFeedbackCategories()
        {
            var response = _supportManager.GetFeedbackCategories();
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
    }
}