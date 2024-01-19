using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.DAL.Repository.Interfaces;
using System.Diagnostics;

namespace MyCarApp.DAL.Repository.Classes
{
    public class SupportRepository : ISupportRepository
    {
        private readonly DAL.Database.MyCarDBEntities _dbContext;

        public SupportRepository()
        {
            this._dbContext = new Database.MyCarDBEntities();
        }

        /// <summary>
        /// Create contact us entry in database table
        /// </summary>
        /// <param name="contactus"></param>
        /// <returns>Create entry in table</returns>
        public bool Create(ContactUs contactus)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.ContactU, ContactUs>();
                });
                var mapper = config.CreateMapper();
                var entity = mapper.Map<Database.ContactU>(contactus);
                entity.Id = Guid.NewGuid();
                _dbContext.ContactUs.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Fetch all entries of contact us
        /// </summary>
        /// <returns>List of contact us details</returns>
        public List<ContactUs> getAll()
        {
            List<ContactUs> data = new List<ContactUs>();

            try
            {
                var fetch = _dbContext.ContactUs.ToList();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ContactUs, Database.ContactU>();
                });
                var mapper = config.CreateMapper();
                foreach (var entity in fetch)
                {
                    data.Add(mapper.Map<ContactUs>(entity));
                }
                return data;
            }
            catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Fetch data from FAQ table
        /// </summary>
        /// <returns>List of FAQ</returns>
        public List<FAQ> GetFaq()
        {
            try
            {
                List<FAQ> data = new List<FAQ>();

                var fetch = _dbContext.FAQs.ToList();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<FAQ, Database.FAQ>();
                });
                var mapper = config.CreateMapper();
                foreach (var entity in fetch)
                {
                    data.Add(mapper.Map<FAQ>(entity));
                }
                return data;
            
            }
            catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Fetch categories of feedback
        /// </summary>
        /// <returns>Feedback categories list</returns>
        public IEnumerable<FeedbackCategory> GetFeedbackCategories()
        {
            List<FeedbackCategory> categories = new List<FeedbackCategory>();
            try
            {
                IEnumerable<Database.FeedbackCategory> entities = _dbContext.FeedbackCategories.ToList();
                foreach (var entity in entities)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<FeedbackCategory, Database.FeedbackCategory>();
                    });
                    var mapper = config.CreateMapper();
                    categories.Add(mapper.Map<FeedbackCategory>(entity));
                }
                return categories;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Create feedback entry in database
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns>Adds feedback in database</returns>
        public bool CreateFeedback(Feedback feedback)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Feedback, Feedback>();
                });
                var mapper = config.CreateMapper();
                var entity = mapper.Map<Database.Feedback>(feedback);
                entity.FeedbackId = Guid.NewGuid();
                _dbContext.Feedbacks.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Feedback> getAllFeedback()
        {
            try
            {
                List<Feedback> data = new List<Feedback>();

                var fetch = _dbContext.Feedbacks.ToList();
                foreach (var entity in fetch)
                {
                    data.Add(new Feedback
                    {
                        Name=entity.Name,
                        Description=entity.Description
                    });
                }
                return data;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
