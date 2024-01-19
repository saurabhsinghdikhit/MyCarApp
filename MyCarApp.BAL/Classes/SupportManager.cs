
using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.BussinessEntities;
using System.Collections.Generic;
using MyCarApp.DAL.Repository.Interfaces;

namespace MyCarApp.BAL.Classes
{
    public class SupportManager : ISupportManager
    {
        private readonly ISupportRepository _supportRepository;

        public SupportManager(ISupportRepository supportRepository)
        {
            this._supportRepository = supportRepository;
        }

        public bool Create(ContactUs contactus)
        {
            return _supportRepository.Create(contactus);
        }

        public List<ContactUs> getAll()
        {
            return _supportRepository.getAll();
        }

        public List<FAQ> GetFaq()
        {
            return _supportRepository.GetFaq();
        }

        public bool CreateFeedback(Feedback feedback)
        {
            return _supportRepository.CreateFeedback(feedback);
        }

        public IEnumerable<FeedbackCategory> GetFeedbackCategories()
        {
            return _supportRepository.GetFeedbackCategories();
        }

        public List<Feedback> getAllFeedback()
        {
            return _supportRepository.getAllFeedback();
        }
    }
}
