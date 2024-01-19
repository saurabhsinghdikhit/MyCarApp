using MyCarApp.BE.BussinessEntities;
using System;
using System.Collections.Generic;
using MyCarApp.BE.ViewModels;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Repository.Interfaces
{
    public interface IAdminRepository
    {
        IList<Admin> GetAllAdmins();
        Admin Login(string username, string password);

        IEnumerable<PdfVM> GetAllPurchase();

        IEnumerable<RentPdfVM> GetAllRent();

        IEnumerable<CarPurchase> GetPurchasePendingRefund();
        IEnumerable<CarRent> GetRentPendingRefund();

    }
}
