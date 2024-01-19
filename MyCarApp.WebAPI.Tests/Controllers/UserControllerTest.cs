using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyCarApp.WebAPI.Controllers;
using Moq;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BAL.Interfaces;
using System.Web.Http.Results;
using MyCarApp.BE.ViewModels;

namespace MyCarApp.WebAPI.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
       

        [TestMethod]
        public void UpdateUserTest()
        {
            var data = new BE.BussinessEntities.User()
            {
                Name = "ram1",
                ContactNo = "7575878787",
                Email = "ram@gmail.com",
                Password = "123456",
                UserId = Guid.NewGuid()
            };

            var moq = new Mock<IUserManager>();

            moq.Setup(x => x.Update(data)).Returns(true);

            var result = new UserController(moq.Object).Update(data) as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(result);

            Assert.AreEqual(result.Content, true);
        }

        [TestMethod]
        public void DeleteUserTest()
        {

            var moq = new Mock<IUserManager>();

            moq.Setup(x => x.Delete(new Guid("BD4725B3-CAB7-4A4D-A391-8FEF46A1A99B"))).Returns(true);

            var result = new UserController(moq.Object).Delete(new Guid("BD4725B3-CAB7-4A4D-A391-8FEF46A1A99B")) as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(result);

            Assert.AreEqual(result.Content, true);
        }

        [TestMethod]
        public void CreateUserTest()
        {       
            var data = new BE.BussinessEntities.User()
            {
                Name = "ram",
                ContactNo = "7575878787",
                Email = "ram@gmail.com",
                Password = "123456"
            };

            var moq = new Mock<IUserManager>();

            moq.Setup(x => x.Create(data)).Returns(true);

            var result = new UserController(moq.Object).Create(data) as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(result);

            Assert.AreEqual(result.Content, true);
        }

        [TestMethod]
        public void ForgotPasswordTest()
        {
            var email = "ram@gmail.com";
            
            var moq = new Mock<IUserManager>();

            moq.Setup(x => x.ForgotPassword(email)).Returns(124578);

            var result = new UserController(moq.Object).ForgotPassword(email) as OkNegotiatedContentResult<int>;

            Assert.IsNotNull(result);

            Assert.AreEqual(result.Content, 124578);
        }

        [TestMethod]
        public void LoginTest()
        {
            var data = new UserLoginVM()
            {
                Email = "ram@gmail.com",
                Password = "123456"
            };

            var returnData = new User()
            {
                Name = "ram",
                Email = "ram@gmail.com",
                ContactNo = "9584754784"
            };

            var moq = new Mock<IUserManager>();

            moq.Setup(x => x.Login(data)).Returns(returnData);

            var result = new UserController(moq.Object).Login(data) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);

            Assert.AreEqual(result.Content, returnData);
        }
    }
}
