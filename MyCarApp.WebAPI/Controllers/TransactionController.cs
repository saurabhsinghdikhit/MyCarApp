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
    /// <summary>
    /// Transaction Controller
    /// </summary>
    [RoutePrefix("Transaction")]
    
    public class TransactionController : ApiController
    {
        private readonly ITransactionManager _transactionManager;
        public TransactionController(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }

        /// <summary>
        /// Method for car purchase
        /// </summary>
        /// <param name="carPurchaseModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Purchase")]
        public IHttpActionResult Purchase(CarPurchaseModel carPurchaseModel)
        {
            if(carPurchaseModel.CarPurchase.UserId == Guid.Empty)
            {
                carPurchaseModel.CarPurchase.UserId = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            }
            
            var response = _transactionManager.CarPurchase(carPurchaseModel.LocalAddress,carPurchaseModel.PincodeData, carPurchaseModel.TransactionId, carPurchaseModel.CarPurchase);
            
            return Ok(response);
        }

        /// <summary>
        /// Method for confirm purchase
        /// </summary>
        /// <param name="carVarientId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ConfirmPurchase")]
        public IHttpActionResult ConfirmPurchase(Guid carVarientId)
        {
            var response = _transactionManager.ConfirmPurchase(carVarientId);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        /// <summary>
        /// Method for car rent
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CarRent")]
        public IHttpActionResult CarRent(CarRentModel model)
        {
            if (model.carRent.UserId == Guid.Empty)
            {
                model.carRent.UserId = Guid.Parse(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(c => c.Type == "Username").Value);
            }
            
            var response = _transactionManager.CarRent(model.LocalAddress,model.PincodeData, model.TransactionId, model.carRent);
            if (response ==null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        /// Method for generating pdf of car purchase
        /// </summary>
        /// <param name="PurchaseId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GeneratePurchasePDF/{PurchaseId}")]
        public IHttpActionResult GeneratePDF(Guid PurchaseId)
        {
            var response = _transactionManager.GeneratePDF(PurchaseId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }

        /// <summary>
        ///  Method for generating pdf of car rent
        /// </summary>
        /// <param name="RentId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GenerateRentPDF/{RentId}")]
        public IHttpActionResult GenerateRentPDF(Guid RentId)
        {
            var response = _transactionManager.GenerateRentPDF(RentId);
            if (response == null)
            {
                return InternalServerError();
            }
            return Ok(response);
        }
    }
}
