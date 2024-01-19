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

namespace MyCarApp.WebAPI.Tests.Controllers
{
    [TestClass]
    public class AddressSupportControllerTest
    {
        [TestMethod]
        public void GetCountriesTest()
        {
            var data = new List<Country>()
            {
                new Country()
                {
                    CountryName = "country"
                }
            };

            var moq = new Mock<IAddressSupportManager>();
            moq.Setup(x => x.GetCountries()).Returns(data);

            var response = new AddressSupportController(moq.Object).GetCountries() as OkNegotiatedContentResult<IEnumerable<Country>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void GetStateTest()
        {
            var id = new Guid("0E97BF9D-B4D1-4E46-AC91-44819FE2678E");

            var data = new List<State>()
            {
                new State()
                {
                    StateName = "state"
                }
            };

            var moq = new Mock<IAddressSupportManager>();
            moq.Setup(x => x.GetStates(id)).Returns(data);

            var response = new AddressSupportController(moq.Object).GetStates(id) as OkNegotiatedContentResult<IEnumerable<State>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }


        [TestMethod]
        public void GetCitiesTest()
        {
            var id = new Guid("0E97BF9D-B4D1-4E46-AC91-44819FE2678E");

            var data = new List<City>()
            {
                new City()
                {
                    CityName = "city"
                }
            };

            var moq = new Mock<IAddressSupportManager>();
            moq.Setup(x => x.GetCities(id)).Returns(data);

            var response = new AddressSupportController(moq.Object).GetCities(id) as OkNegotiatedContentResult<IEnumerable<City>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void GetPincodesTest()
        {
            var id = new Guid("0E97BF9D-B4D1-4E46-AC91-44819FE2678E");

            var data = new List<Pincode>()
            {
                new Pincode()
                {
                    Pincode1 = 395006
                }
            };

            var moq = new Mock<IAddressSupportManager>();
            moq.Setup(x => x.GetPincodes(id)).Returns(data);

            var response = new AddressSupportController(moq.Object).GetPincodes(id) as OkNegotiatedContentResult<IEnumerable<Pincode>>;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void AddAddressTest()
        {
            var data = new CarDetails()
            {
                LocalAddress = "janata society, L.H.Road, surat- 39605"
            };

            var moq = new Mock<IAddressSupportManager>();
            moq.Setup(x => x.AddAddress(data)).Returns(true);

            var response = new AddressSupportController(moq.Object).CreateAddress(data) as OkResult;

            Assert.IsNotNull(response);
            
        }
    }
}
