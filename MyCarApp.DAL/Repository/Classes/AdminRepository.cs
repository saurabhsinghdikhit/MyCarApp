using AutoMapper;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.DAL.Repository.Interfaces;
using System;
using MyCarApp.BE.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Repository.Classes
{
    /// <summary>
    /// Admin Repository
    /// </summary>
    public class AdminRepository : IAdminRepository
    {
        private readonly Database.MyCarDBEntities _dbContext;

        public AdminRepository()
        {
            _dbContext = new Database.MyCarDBEntities();
        }

        /// <summary>
        /// Display all admins
        /// </summary>
        /// <returns>List of admins</returns>
        public IList<Admin> GetAllAdmins()
        {
            List<Admin> adminList = new List<Admin>();
            adminList.Add(new Admin()
            {
                Id = new Guid(),
                Name = "Raj",
                Role = "Owner"
            });
            return adminList;
        }

        /// <summary>
        /// Admin login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Admin Login(string username, string password)
        {
            Database.Admin admin = _dbContext.Admins.Where(user => user.Email.Equals(username)
            && user.Passowrd == password).FirstOrDefault();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Database.Admin, Admin>();
            });
            var mapper = config.CreateMapper();
            var record=mapper.Map<Admin>(admin);
            if (record != null)
            {
                return record;
            }
            return null;
        }

        /// <summary>
        /// Shows all purchases details
        /// </summary>
        /// <returns>List of purchase</returns>
        public IEnumerable<PdfVM> GetAllPurchase()
        {
            List<PdfVM> store = new List<PdfVM>();

            List<Database.CarPurchas> fetch = _dbContext.CarPurchases.Include("CarVarient")
                .Include("User")
                .ToList();

            foreach (var item in fetch)
            {
                PdfVM tmp = new PdfVM()
                {
                    CarName = item.CarVarient.Car.Name,
                    CarVarientName = item.CarVarient.Name,
                    CarPurchaseId = item.CarPurchaseId,
                    Date = DateTime.Parse(item.CreatedAt.ToString()),
                    UserName = item.User.Name,
                    DealerName = item.Dealer.Name,
                    DealerContact = item.Dealer.ContactNo,
                    DealerAddress = item.Dealer.Address.LocalAddress
                    + ", \n"
                    + item.Dealer.Address.Pincode.City.CityName
                    + ", "
                    + item.Dealer.Address.Pincode.City.State.StateName
                    + ",\n"
                    + item.Dealer.Address.Pincode.City.State.Country.CountryName
                    + " -"
                    + item.Dealer.Address.Pincode.Pincode1,
                    UserAddress = item.User.Address.LocalAddress
                    + ", \n"
                    + item.User.Address.Pincode.City.CityName
                    + ", "
                    + item.User.Address.Pincode.City.State.StateName
                    + ",\n"
                    + item.User.Address.Pincode.City.State.Country.CountryName
                    + " -"
                    + item.User.Address.Pincode.Pincode1,
                    Price = item.Amount

                };
                store.Add(tmp);
            }
            return store;
        }

        /// <summary>
        /// Shows all rents details
        /// </summary>
        /// <returns>List of rent</returns>
        public IEnumerable<RentPdfVM> GetAllRent()
        {
            List<RentPdfVM> store = new List<RentPdfVM>();

            List<Database.CarRent> fetch = _dbContext.CarRents.Include("CarVarient")
                .Include("User")
                .ToList();

            foreach (var item in fetch)
            {
                RentPdfVM tmp = new RentPdfVM()
                {
                    CarName = item.CarVarient.Car.Name,
                    CarVarientName = item.CarVarient.Name,
                    CarRentId = item.CarRentId,
                    StartDate = item.BookingDate,
                    EndDate = item.ReturningDate,
                    UserName = item.User.Name,

                    UserAddress = item.User.Address.LocalAddress
                    + ", \n"
                    + item.User.Address.Pincode.City.CityName
                    + ", "
                    + item.User.Address.Pincode.City.State.StateName
                    + ",\n"
                    + item.User.Address.Pincode.City.State.Country.CountryName
                    + " -"
                    + item.User.Address.Pincode.Pincode1,
                    Price = item.Amount
                };
                store.Add(tmp);
            }

            return store;
        }

        public IEnumerable<CarPurchase> GetPurchasePendingRefund()
        {
            var model = _dbContext.CarPurchases.Include("User").Where(x => x.Status == true && x.IsDeleted == false).ToList();
            List<CarPurchase> returnModel = new List<CarPurchase>();
            foreach (var item in model)
            {
                var entity = new CarPurchase();
                entity.User = new User();
                entity.User.UserId = item.User.UserId;
                entity.User.Name = item.User.Name;
                entity.CarPurchaseId = item.CarPurchaseId;
                entity.CarVarientId = item.CarVarientId;
                entity.Amount = item.Amount;
                entity.Status = item.Status;
                entity.IsDeleted = item.IsDeleted;
                entity.CreatedAt = item.CreatedAt;
                returnModel.Add(entity);
            }
            return returnModel;

        }

        public IEnumerable<CarRent> GetRentPendingRefund()
        {
            var model = _dbContext.CarRents.Include("User").Where(x => x.Status == true && x.IsDeleted == false).ToList();
            List<CarRent> returnModel = new List<CarRent>();
            foreach (var item in model)
            {
                var entity = new CarRent();
                entity.User = new User();
                entity.User.UserId = item.User.UserId;
                entity.User.Name = item.User.Name;
                entity.CarRentId = item.CarRentId;
                entity.CarVarientId = item.CarVarientId;
                entity.Amount = item.Amount;
                entity.ReturningDate = item.ReturningDate;
                entity.BookingDate = item.BookingDate;
                entity.Status = item.Status;
                entity.IsDeleted = item.IsDeleted;
                returnModel.Add(entity);
            }
            return returnModel;

        }
    }
}
