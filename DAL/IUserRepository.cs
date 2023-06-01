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
        UserViewModel Validate(LoginViewModel model);
        List<UserViewModel> GetAll();
        UserViewModel GetById(int id);
        bool AddUser(UserViewModel model);
        bool DeleteUser(int id);
        bool UpdateUser(UserViewModel model);
    }
}
