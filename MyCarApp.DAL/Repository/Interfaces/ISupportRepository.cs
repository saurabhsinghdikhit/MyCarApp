using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarApp.BE.BussinessEntities;

namespace MyCarApp.DAL.Repository.Interfaces
{
    public interface ISupportRepository
    {
        List<ContactUs> getAll();
        List<Feedback> getAllFeedback();
        bool Create(ContactUs contactus);
        List<FAQ> GetFaq();
        bool CreateFeedback(Feedback feedback);
        IEnumerable<FeedbackCategory> GetFeedbackCategories();
    }
}
