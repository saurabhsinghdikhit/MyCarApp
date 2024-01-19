using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyCarApp.BAL.Interfaces;
using MyCarApp.WebAPI.Controllers;
using MyCarApp.BE.BussinessEntities;
using System.Web.Http.Results;
using MyCarApp.BE.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyCarApp.WebAPI.Tests.Controllers
{
    [TestClass]
    public class TransactionControllerTest
    {
        /*[TestMethod]
        public void CarPurchaseTest()
        {
            var returnId = new Guid("BD4725B3-CAB7-4A4D-A391-8FEF46A1A99B");
            string id = "id";
            
            var data = new CarPurchase()
            {
                UserId = Guid.NewGuid(),
                Status = false,
                Amount = 2548
            };

            var extraData = new CarPurchaseModel()
            {
                CarPurchase = data,
                TransactionId = id
                
            };

            var moq = new Mock<ITransactionManager>();
            moq.Setup(x => x.CarPurchase(id, data)).Returns(returnId);

            var response = new TransactionController(moq.Object).Purchase(extraData) as OkNegotiatedContentResult<Guid>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, returnId);
        }


        [TestMethod]
        public void ConfirmPurchaseTest()
        {
            var id = new Guid("BD4725B3-CAB7-4A4D-A391-8FEF46A1A99B");

            var data = new CarVarient()
            {
                Car = null,
                Name = "xyz",
                Price = 5478
            };

            var moq = new Mock<ITransactionManager>();
            moq.Setup(x => x.ConfirmPurchase(id)).Returns(data);

            var response = new TransactionController(moq.Object).ConfirmPurchase(id) as OkNegotiatedContentResult<CarVarient>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }


        [TestMethod]
        public void CarRentTest()
        {
            var returnId = new Guid("BD4725B3-CAB7-4A4D-A391-8FEF46A1A99B");
            string id = "id";

            var data = new CarRent()
            {
                UserId = Guid.NewGuid(),
                Status = false,
                Amount = 2548
            };

            var extraData = new CarRentModel()
            {
                carRent = data,
                TransactionId = id
            };

            var moq = new Mock<ITransactionManager>();
            moq.Setup(x => x.CarRent(id, data)).Returns(returnId);

            var response = new TransactionController(moq.Object).CarRent(extraData) as OkNegotiatedContentResult<Guid>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, returnId);
        }


        [TestMethod]
        public void GeneratePdfPurchaseTest()
        {
            var id = new Guid("BD4725B3-CAB7-4A4D-A391-8FEF46A1A99B");
            var UserId = new Guid("BD4725B3-CAB7-4A4D-A391-8FEF46A1A99B");
            var data = new PdfVM()
            {
                Price = 545787,
                CarName = "abc",
                CarVarientName = "abc-1",
                DealerName = "ram"
            };

            var moq = new Mock<ITransactionManager>();
            moq.Setup(x => x.GeneratePDF(id, UserId)).Returns(data);

            var response = new TransactionController(moq.Object).GeneratePDF(id) as OkNegotiatedContentResult<PdfVM>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void GeneratePdfRentTest()
        {
            var id = new Guid("BD4725B3-CAB7-4A4D-A391-8FEF46A1A99B");
            var UserId = new Guid("BD4725B3-CAB7-4A4D-A391-8FEF46A1A99B");

            var data = new RentPdfVM()
            {
                Price = 545787,
                CarName = "abc",
                CarVarientName = "abc-1"
            };

            var moq = new Mock<ITransactionManager>();
            moq.Setup(x => x.GenerateRentPDF(id,UserId)).Returns(data);

            var response = new TransactionController(moq.Object).GenerateRentPDF(id) as OkNegotiatedContentResult<RentPdfVM>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }*/
    }
}
