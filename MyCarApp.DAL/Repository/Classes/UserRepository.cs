using AutoMapper;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity.Migrations;
using System.Net.Mail;
using System.Configuration;
using MyCarApp.Common.HashAndSalt;
using System.IO;

namespace MyCarApp.DAL.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly Database.MyCarDBEntities _dbContext;

        public UserRepository()
        {
            _dbContext = new Database.MyCarDBEntities();
        }

        /// <summary>
        /// Create user entry in database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Create(User user)
        {
            try
            {
                var salt = HashSalt.GenerateSalt();
                var hashcode = HashSalt.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(user.Password), salt);
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.User, User>();
                });
                user.UserId = Guid.NewGuid();
                user.PasswordSalt = salt;
                user.HashPassword = hashcode;
                var mapper = config.CreateMapper();
                var entity = mapper.Map<Database.User>(user);
                
                if(user.Address!=null)
                {
                    IAddressRepository addressRepository = new AddressRepository();
                    entity.Address = addressRepository.Add(user.Address);
                    entity.AddressId = entity.Address.AddressId;
                }

                MailMessage mail = new MailMessage();
                mail.To.Add(user.Email);
                mail.From = new MailAddress("17it097@charusat.edu.in");
                mail.Subject = "Welcome to MyCarApp!";
                //string Body = "<h3>Hey " + user.Name + "!</h3><br><h4> Welcome to MyCarApp.<br> Your account is now set up and ready to use.Let's get started!</h4>";
                string FilePath = "D:\\Major Project\\MyCarApp.Solution\\MyCarApp.Solution\\MyCarApp.DAL\\EmailFormates\\Registration.html";
                StreamReader str = new StreamReader(FilePath);
                string Body = str.ReadToEnd();
                str.Close();
                Body = Body.Replace("{{ user }}", user.Name.Trim());
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "in-v3.mailjet.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("3a83b0df7fefd394b27eba461e3b0612", "743845caa86d2ae7c29646826d524275");
                smtp.EnableSsl = true;
                smtp.Send(mail);
               
                _dbContext.Users.Add(entity);
                _dbContext.SaveChanges();
                return true;

            }
            catch(Exception e)
            {
                Debug.Fail(e.Message);
                return false;
            }
            
        }

        /// <summary>
        /// delete user entry from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            try
            {
                Database.User user = _dbContext.Users.Where(c => c.UserId == id).FirstOrDefault();
                if (user != null)
                {
                    user.IsDeleted = true;
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Send email to user for password recovery
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int ForgotPassword(string email)
        {
            Database.User user = _dbContext.Users.Where(x => x.Email == email).FirstOrDefault();

            if (user != null)
            {
                Random _random = new Random();
                var number = _random.Next(100000, 999999);
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("17it097@charusat.edu.in");
                mail.Subject = "One Time Password Of MyCar App";
                string Body = "<br><h4>Your OTP is: " + number +"</h4>";
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "in-v3.mailjet.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("3a83b0df7fefd394b27eba461e3b0612", "743845caa86d2ae7c29646826d524275");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return number;
            }
            return -1;
        }

        /// <summary>
        /// Fetch user record by user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Get(Guid id)
        {
            try
            {
                var model = _dbContext.Users.Where(c => c.UserId == id).FirstOrDefault();

                if(model!=null)
                {  
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Database.User, User>()
                        .ForMember(x => x.CarPurchases, y => y.Ignore())
                        .ForMember(x => x.Password, opt => opt.Ignore())
                        .ForMember(x => x.CarRents, y => y.Ignore())
                        .ForMember(x => x.Address, y => y.Ignore())
                        .PreserveReferences();
                        //cfg.CreateMap<Database.Address, Address>();
                    });
                    config.AssertConfigurationIsValid();
                    var mapper = config.CreateMapper();
                    
                    return mapper.Map<User>(model);
                }

                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Login for user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public User Login(UserLoginVM model)
        {
            Database.User user = _dbContext.Users.Where(x => x.Email.Equals(model.Email)).FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Database.User, User>()
                .ForMember(x => x.CarPurchases, y => y.Ignore())
                .ForMember(x => x.CarRents, y => y.Ignore())
                .ForMember(x => x.Address, y => y.Ignore())
                .PreserveReferences();
            });
            
            var mapper = config.CreateMapper();
            var record = mapper.Map<User>(user);
            var oldHash = user.HashPassword;
            var newHash = HashSalt.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(model.Password), user.PasswordSalt);
            if (record != null)
            {
                if (newHash.SequenceEqual(oldHash))
                    return record;
                else
                    return null;
            }
            return null;
        }

        /// <summary>
        /// update user data
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Update(User user)
        {
            try
            {
                Database.User userEntity = _dbContext.Users.Where(c => c.UserId == user.UserId).FirstOrDefault();
                if (userEntity != null)
                {
                    user.Email = userEntity.Email;
                    user.AddressId = userEntity.AddressId;
                    user.ModifiedBy = user.UserId;
                    user.CreatedBy = userEntity.CreatedBy;
                    user.CreatedAt = userEntity.CreatedAt;
                    user.HashPassword = userEntity.HashPassword;
                    user.PasswordSalt = userEntity.PasswordSalt;

                    if (user.Image == "")
                        user.Image = userEntity.Image;
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Database.User, User>()
                        .ForMember(x => x.Password, opt => opt.Ignore())
                        .ForMember(x => x.CarPurchases, y => y.Ignore())
                        .ForMember(x => x.CarRents, y => y.Ignore())
                        .ForMember(dest => dest.Address, opt => opt.Ignore());
                    });
                    var mapper = config.CreateMapper();
                    var entity = mapper.Map<Database.User>(user);
                    _dbContext.Users.AddOrUpdate(entity);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
                return false;
            }
        }

        public bool setNewPassword(string email, string pass)
        {
            try
            {
                var salt = HashSalt.GenerateSalt();
                var hashcode = HashSalt.ComputeHMAC_SHA256(Encoding.UTF8.GetBytes(pass), salt);
                Database.User userEntity = _dbContext.Users.Where(c => c.Email == email).FirstOrDefault();
                userEntity.HashPassword = hashcode;
                userEntity.PasswordSalt = salt;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public bool pendingStatus(Guid id, bool IsRent)
        {
            try
            {
                dynamic model;
                if(IsRent)
                {
                    model = _dbContext.CarRents.Where(x => x.CarRentId == id).FirstOrDefault();
                }
                else
                {
                    model = _dbContext.CarPurchases.Where(x => x.CarPurchaseId == id).FirstOrDefault();
                }
                
                model.Status = true;
                model.IsDeleted = false;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string approveStatus(Guid id, bool IsRent)
        {
            try
            {
                dynamic model;
                if (IsRent)
                {
                    model = _dbContext.CarRents.Where(x => x.CarRentId == id).FirstOrDefault();
                }
                else
                {
                    model = _dbContext.CarPurchases.Where(x => x.CarPurchaseId == id).FirstOrDefault();
                }
                Guid Id = (Guid)model.UserId;
                var user = _dbContext.Users.Where(x => x.UserId == Id).FirstOrDefault();
                model.Status = false;
                model.IsDeleted = true;
                _dbContext.SaveChanges();
                MailMessage mail = new MailMessage();
                mail.To.Add(user.Email);
                mail.From = new MailAddress("17it097@charusat.edu.in");
                mail.Subject = "Welcome to MyCarApp!";
                string Body = "<h3>Hey " + user.Name + "!</h3><br><h4> Welcome to MyCarApp.<br> Happy to inform you that your refund request has been accepted!!</h4>";

                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "in-v3.mailjet.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("3a83b0df7fefd394b27eba461e3b0612", "743845caa86d2ae7c29646826d524275");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                Guid invoiceId = (Guid)model.InvoiceId;
                var invoice = _dbContext.Invoices.Where(x => x.InvoiceId == invoiceId).FirstOrDefault();
                string transaction = invoice.TranscationId;
                return transaction;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public bool rejectStatus(Guid id, bool IsRent)
        {
            try
            {

                dynamic model;
                if (IsRent)
                {
                    model = _dbContext.CarRents.Where(x => x.CarRentId == id).FirstOrDefault();
                }
                else
                {
                    model = _dbContext.CarPurchases.Where(x => x.CarPurchaseId == id).FirstOrDefault();
                }
                Guid Id = (Guid)model.UserId;
                var user = _dbContext.Users.Where(x => x.UserId == Id).FirstOrDefault();
                model.Status = true;
                model.IsDeleted = true;
                _dbContext.SaveChanges();
                MailMessage mail = new MailMessage();
                mail.To.Add(user.Email);
                mail.From = new MailAddress("17it097@charusat.edu.in");
                mail.Subject = "Welcome to MyCarApp!";
                string Body = "<h3>Hey " + user.Name + "!</h3><br><h4> Welcome to MyCarApp.<br> Sorry to inform you that your request has been rejected!!</h4>";
                
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "in-v3.mailjet.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("3a83b0df7fefd394b27eba461e3b0612", "743845caa86d2ae7c29646826d524275");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
