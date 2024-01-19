    using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.DAL.Repository.Interfaces;
using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Classes
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository _adminRepository;
        public AdminManager(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public IList<Admin> getAllAdmins()
        {
            return _adminRepository.GetAllAdmins();
        }

        public Admin Login(string username, string password)
        {
            return _adminRepository.Login(username, password);
        }

        public IEnumerable<PdfVM> GetAllPurchase()
        {
            return _adminRepository.GetAllPurchase();
        }

        public IEnumerable<RentPdfVM> GetAllRent()
        {
            return _adminRepository.GetAllRent();
        }

        public IEnumerable<CarPurchase> GetPurchasePendingRefund()
        {
            return _adminRepository.GetPurchasePendingRefund();
        }
        public IEnumerable<CarRent> GetRentPendingRefund()
        {
            return _adminRepository.GetRentPendingRefund();
        }
    }
}
