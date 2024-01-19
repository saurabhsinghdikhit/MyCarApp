using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Classes
{
    public class UserManager : IUserManager
    {
        private readonly UserRepository _userRepository;

        public UserManager(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Create(User user)
        {
            return _userRepository.Create(user);
        }

        public bool Delete(Guid id)
        {
            return _userRepository.Delete(id);
        }

        public User Get(Guid id)
        {
            return _userRepository.Get(id);
        }

        public User Login(UserLoginVM model)
        {
            return _userRepository.Login(model);
        }

        public bool Update(User user)
        {
            return _userRepository.Update(user);
        }

        public int ForgotPassword(string email)
        {
            return _userRepository.ForgotPassword(email);
        }

        public bool setNewPassword(string email, string pass)
        {
            return _userRepository.setNewPassword(email, pass);
        }

        public bool pendingStatus(Guid id, bool IsRent)
        {
            return _userRepository.pendingStatus(id, IsRent);
        }
        public bool rejectStatus(Guid id, bool IsRent)
        {
            return _userRepository.rejectStatus(id, IsRent);
        }
        public string approveStatus(Guid id, bool IsRent)
        {
            return _userRepository.approveStatus(id,IsRent);
        }
    }
}
