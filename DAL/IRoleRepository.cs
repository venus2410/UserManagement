using _67RoleBaseSecurity.DataModel;
using _67RoleBaseSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _67RoleBaseSecurity.DAL
{
    public interface IRoleRepository
    {
        List<RoleViewModel> GetAll();
    }
}