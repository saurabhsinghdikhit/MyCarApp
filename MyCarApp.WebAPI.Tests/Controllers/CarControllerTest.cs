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
using System.Net;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;

namespace MyCarApp.WebAPI.Tests.Controllers
{
    [TestClass]
    public class CarControllerTest
    {
        [TestMethod]
        public void AddCarTest()
        {
            var data = new Car()
            {
                Kilometers = 50,
                Name = "Rolls-Royce",
                ModifiedBy = Guid.NewGuid(),
                CreaatedBy = Guid.NewGuid()
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.Add(data)).Returns(true);
          
            var response = new CarController(moq.Object).Create(data) as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, true);
        }


        [TestMethod]
        public void GetAllTest()
        {
            var data = new List<Car>()
            {
                new Car()
                {
                Kilometers = 50,
                Name = "Rolls-Royce"
                }
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.GetAll()).Returns(data);

            var response = new CarController(moq.Object).GetAll() as OkNegotiatedContentResult<IEnumerable<Car>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void GetByBrandTest()
        {
            var data = new List<Car>()
            {
                new Car()
                {
                Kilometers = 50,
                Name = "Rolls-Royce"
                }
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.GetByBrand("brand")).Returns(data);

            var response = new CarController(moq.Object).GetByBrand("brand") as OkNegotiatedContentResult<IEnumerable<Car>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void ShowCarsByCategoryTest()
        {
            var data = new List<Car>()
            {
                new Car()
                {
                Kilometers = 50,
                Name = "Rolls-Royce"
                }
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.ShowCarsByCategory("used")).Returns(data);

            var response = new CarController(moq.Object).ShowCarsByCategory("used") as OkNegotiatedContentResult<IEnumerable<Car>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void ShowCarsBySearchPurchaseTest()
        {
            var data = new List<Car>()
            {
                new Car()
                {
                    Kilometers = 50,
                    Name = "Rolls-Royce"
                }
            };

            var extraData = new CustomPurchaseSearch()
            {
                Brand = "abc",
                Category = "xyz",
                Location = "surat",
                Varient = "null",
                Budget = "null"
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.ShowCarsBySearchPurchase(extraData)).Returns(data);

            var response = new CarController(moq.Object).GetCars("xyz","null","abc","null","surat") as OkNegotiatedContentResult<IEnumerable<Car>>;

            Assert.IsNotNull(response);

            var store = response.Content;
          
        }

        [TestMethod]
        public void ShowRentCarbyCityTest()
        {
            var data = new List<Car>()
            {
                new Car()
                {
                Kilometers = 50,
                Name = "Rolls-Royce"
                }
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.ShowRentCarbyCity("surat")).Returns(data);

            var response = new CarController(moq.Object).ShowRentCarbyCity("surat") as OkNegotiatedContentResult<IEnumerable<Car>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var data = new Car()
            {
                Kilometers = 50,
                Name = "Rolls-Royce",
                ModifiedBy = Guid.NewGuid()
            };
            

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.Update(data)).Returns(true);

            var response = new CarController(moq.Object).Update(data) as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, true);
        }

        [TestMethod]
        public void DeleteTest()
        { 
            var id = new Guid("0E97BF9D-B4D1-4E46-AC91-44819FE2678E");

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.Delete(id)).Returns(true);

            var response = new CarController(moq.Object).Delete(id) as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, true);
        }

        [TestMethod]
        public void LatestCarTest()
        {
            var data = new List<Car>()
            {
                new Car()
                {
                Kilometers = 50,
                Name = "Rolls-Royce"
                }
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.LatestCars()).Returns(data);

            var response = new CarController(moq.Object).LatestCars() as OkNegotiatedContentResult<IEnumerable<Car>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }


        [TestMethod]
        public void TopCarsTest()
        {
            var data = new List<Car>()
            {
                new Car()
                {
                Kilometers = 50,
                Name = "Rolls-Royce"
                }
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.TopCars(true)).Returns(data);

            var response = new CarController(moq.Object).TopCars(true) as OkNegotiatedContentResult<IEnumerable<Car>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void GetCarTest()
        {
            var id = new Guid("0E97BF9D-B4D1-4E46-AC91-44819FE2678E");

            var data = new Car()
            {
                Kilometers = 50,
                Name = "Rolls-Royce"
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.GetCar(id)).Returns(data);

            var response = new CarController(moq.Object).GetCar(id) as OkNegotiatedContentResult<Car>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void GetAllCategoryTest()
        {
            var data = new List<CustomDropdown>()
            {
                new CustomDropdown()
                {
                  Name = "first"
                }
            };
            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.GetAllCategory()).Returns(data);

            var response = new CarController(moq.Object).Cateogry() as OkNegotiatedContentResult<IEnumerable<CustomDropdown>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void AddVarientTest()
        {
            var data = new CarVarient()
            {
                CreatedBy = Guid.NewGuid(),
                ModifiedBy = Guid.NewGuid(),
                Name = "varient1",
                Price = 23435
            };

            var moq = new Mock<ICarManager>();
            moq.Setup(x => x.AddVarient(data)).Returns(true);

            var response = new CarController(moq.Object).AddVarient(data) as OkNegotiatedContentResult<bool>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, true);
        }

        

    }
}
