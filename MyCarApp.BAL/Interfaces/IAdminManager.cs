using MyCarApp.BE.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyCarApp.BE.ViewModels;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Interfaces
{
    public interface IAdminManager
    {
        IList<Admin> getAllAdmins();
        Admin Login(string username, string password);

        IEnumerable<PdfVM> GetAllPurchase();

        IEnumerable<RentPdfVM> GetAllRent();

        IEnumerable<CarPurchase> GetPurchasePendingRefund();
        IEnumerable<CarRent> GetRentPendingRefund();
    }
}
