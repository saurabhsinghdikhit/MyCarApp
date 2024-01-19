using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Interfaces
{
    public interface IUserManager
    {
        User Login(UserLoginVM model);
        User Get(Guid id);

        bool Update(User user);

        bool Delete(Guid id);

        bool Create(User user);

        int ForgotPassword(string email);

        bool setNewPassword(string email, string pass);
        bool pendingStatus(Guid id, bool IsRent);
        bool rejectStatus(Guid id, bool IsRent);
        string approveStatus(Guid id, bool IsRent);
    }
}
