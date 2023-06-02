using _67RoleBaseSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _67RoleBaseSecurity.DAL
{
    public interface IUserRepository
    {
        UserModel Validate(LoginViewModel model);
        List<UserModel> GetAll();
        UserModel GetById(int id);
        bool AddUser(UserModel model);
        bool DeleteUser(int id);
        bool UpdateUser(UserModel model);
        bool IsEmailExist(string email);
        bool IsUserNameExist(string userName);
    }
}
