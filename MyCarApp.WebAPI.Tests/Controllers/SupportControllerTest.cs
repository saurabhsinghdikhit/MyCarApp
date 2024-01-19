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
    public class SupportControllerTest
    {

        [TestMethod]
        public void GetAllTest()
        {
            var data = new List<ContactUs>()
            { new ContactUs()
            {
                Email = "ram@gmail.com",
                Name = "abc",
                Query = "query"
            } };

            var moq = new Mock<ISupportManager>();

            moq.Setup(x => x.getAll()).Returns(data);

            var response = new SupportController(moq.Object).GetAll() as OkNegotiatedContentResult<List<ContactUs>>;
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }

        [TestMethod]
        public void CreateContactUsTest()
        {
            var data =  new ContactUs()
            {
                Email = "ram@gmail.com",
                Name = "abc",
                Query = "query"
            };

            var moq = new Mock<ISupportManager>();

            moq.Setup(x => x.Create(data)).Returns(true);

            var response = new SupportController(moq.Object).Create(data) as OkNegotiatedContentResult<bool>;
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, true);
        }

        [TestMethod]
        public void GetFaqTest()
        {
            var data = new List<FAQ>()
            {
                new FAQ()
                {
                    Answer = "answer",
                    Question = "question"
                }
            };

            var moq = new Mock<ISupportManager>();

            moq.Setup(x => x.GetFaq()).Returns(data);

            var response = new SupportController(moq.Object).GetFaq() as OkNegotiatedContentResult<List<FAQ>>;
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);

        }

        [TestMethod]
        public void CreateFeedbackTest()
        {
            var data = new Feedback()
            {
                Description = "description"
            };

            var moq = new Mock<ISupportManager>();

            moq.Setup(x => x.CreateFeedback(data)).Returns(true);

            var response = new SupportController(moq.Object).CreateFeedback(data) as OkResult;
            Assert.IsNotNull(response);
            
        }

        [TestMethod]
        public void FeedbackCategoryTest()
        {
            var data = new List<FeedbackCategory>()
            { new FeedbackCategory()
            {
                Category ="category"
            }
            };

            var moq = new Mock<ISupportManager>();

            moq.Setup(x => x.GetFeedbackCategories()).Returns(data);

            var response = new SupportController(moq.Object).GetFeedbackCategories() as OkNegotiatedContentResult<IEnumerable<FeedbackCategory>>;
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content, data);
        }
    }
}
