using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        User Login(UserLoginVM model);

        bool Create(User user);
        bool Update(User user);
        bool Delete(Guid id);
        User Get(Guid id);
        int ForgotPassword(string email);
        bool setNewPassword(string email, string pass);
        bool pendingStatus(Guid id, bool IsRent);
        bool rejectStatus(Guid id, bool IsRent);
        string approveStatus(Guid id, bool IsRent);
    }
}
