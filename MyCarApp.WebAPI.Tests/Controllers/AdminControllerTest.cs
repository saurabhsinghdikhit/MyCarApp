using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyCarApp.BAL.Interfaces;
using MyCarApp.WebAPI.Controllers;
using MyCarApp.BE.BussinessEntities;
using System.Collections.Generic;
using System.Web.Http.Results;
using MyCarApp.BE.ViewModels;

namespace MyCarApp.WebAPI.Tests.Controllers
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void getAdminsTest()
        {
            // Making Fake Object
            var moqAdmin = new Mock<IAdminManager>();

            Admin passValue = new Admin()
            {
                Name = "ram",
                Email = "ram@gmail.com",
                Passowrd = "123456",
                Contact = "5783387977",
                Role = "owner"
            };

            IList<Admin> pass = new List<Admin>() { passValue };

            // Set Value of Fake Object and return List of admins
            moqAdmin.Setup(x => x.getAllAdmins()).Returns(pass);

            // Passing Fake object to the Action Method
            var result = new AdminController(moqAdmin.Object).getAdmins();

            // collecting the data
            var contentResult = result as OkNegotiatedContentResult<IList<Admin>>;

            // Check Content
            Assert.IsNotNull(contentResult);

            // Check Content
            Assert.AreEqual(contentResult.Content, pass);

        }


        [TestMethod]
        public void AdminLoginTest()
        {
          
            var data = new Admin()
            {
                Name = "ram",
                Passowrd = "123456",
                Contact = "75782654578"
            };

            var moqAdmin = new Mock<IAdminManager>();
            moqAdmin.Setup(x => x.Login("ram@gmail.com","123456")).Returns(data);
            var result = new AdminController(moqAdmin.Object).Login(new AdminLoginVM()
            { Email = "ram@gmail.com", Passowrd = "123456" });

            var contentResult = result as OkNegotiatedContentResult<Admin>;

            // Check Content
            Assert.IsNotNull(contentResult);

            // Check Content
            Assert.AreEqual(contentResult.Content, data);

        }

        [TestMethod]
        public void GetAllPurchaseTest()
        {
            var purchase = new List<PdfVM>()
            {
                new PdfVM()
                {
                    CarName = "xyz",
                    CarVarientName = "xyz-1",
                    DealerName = "abc"
                }
            };

            var moq = new Mock<IAdminManager>();
            moq.Setup(x => x.GetAllPurchase()).Returns(purchase);
            var result = new AdminController(moq.Object).GetAllPurchase();

            var contentResult = result as OkNegotiatedContentResult<IEnumerable<PdfVM>>;

            // Check response is null or not
            Assert.IsNotNull(contentResult);

            // Check Content is correct or not
            Assert.AreEqual(contentResult.Content, purchase);

        }


        [TestMethod]
        public void GetAllRentTest()
        {
            var rent = new List<RentPdfVM>()
            {
                new RentPdfVM()
                {
                    CarName = "xyz",
                    CarVarientName = "xyz-1",
                    UserName = "ram"
                }
            };

            var moq = new Mock<IAdminManager>();
            moq.Setup(x => x.GetAllRent()).Returns(rent);
            var result = new AdminController(moq.Object).GetAllRent();

            var contentResult = result as OkNegotiatedContentResult<IEnumerable<RentPdfVM>>;

            // Check response is null or not
            Assert.IsNotNull(contentResult);

            // Check Content is correct or not
            Assert.AreEqual(contentResult.Content, rent);

        }



    }
}
