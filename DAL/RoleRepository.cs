using _67RoleBaseSecurity.DataModel;
using _67RoleBaseSecurity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _67RoleBaseSecurity.DAL
{
    public class RoleRepository : IRoleRepository
    {
        UserManagementEntities2 db = new UserManagementEntities2();
        IMapper mapper = AutoMapperConfig.Mapper;
        public List<RoleViewModel> GetAll()
        {
            var lst = mapper.Map<List<RoleViewModel>>(db.Roles.ToList());
            return lst;
        }
    }
}