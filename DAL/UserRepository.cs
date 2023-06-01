using _67RoleBaseSecurity.DataModel;
using _67RoleBaseSecurity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using System.Security.Cryptography;
using System.Text;
using _67RoleBaseSecurity.Util;

namespace _67RoleBaseSecurity.DAL
{
    
    public class UserRepository : IUserRepository
    {
        UserManagementEntities2 db =new UserManagementEntities2();
        IMapper mapper = AutoMapperConfig.Mapper;
        MD5Hash mD5Hash= new MD5Hash();
        public UserViewModel Validate(LoginViewModel model)
        {
            string hashPassword=mD5Hash.ComputeMd5Hash(model.Password);
            User user=db.Users.Where(u => u.UserName == model.Username && u.Password == hashPassword).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            return mapper.Map<UserViewModel>(model);
        }
        public List<UserViewModel> GetAll()
        {
            var lstUser = db.Users.Where(u => u.IsDeleted == false).ToList();
            var lstUserMdl= new List<UserViewModel>();
            foreach(var user in lstUser) {
                var userMdl=mapper.Map<UserViewModel>(user);
                //var user_Role=db.User_Role.Where(u => u.UserId==user.UserId).ToList();
                //var role = db.Roles.Where(r => user_Role.Where(m => m.RoleId == r.RoleId) != null);
                //List<RoleViewModel> roleModel=mapper.Map<List<RoleViewModel>>(role);
                foreach(var ur in user.User_Role)
                {
                    userMdl.RoleId = new List<int>();
                    userMdl.RoleName= new List<string>();
                    userMdl.RoleId.Add(ur.Role.RoleId);
                    userMdl.RoleName.Add(ur.Role.RoleName);
                }

                lstUserMdl.Add(userMdl);
            }
            return lstUserMdl;
        }
        public UserViewModel GetById(int id)
        {
            var user = db.Users.Where(u => u.UserId == id && u.IsDeleted == false).FirstOrDefault();
            var userMdl= mapper.Map<UserViewModel>(user);
            foreach(User_Role ur in user.User_Role)
            {
                userMdl.RoleId = new List<int>();
                userMdl.RoleName = new List<string>();
                userMdl.RoleId.Add(ur.Role.RoleId);
                userMdl.RoleName.Add(ur.Role.RoleName);
            }

            return userMdl;
        }
        public bool AddUser(UserViewModel model)
        {
            try
            {
                User user = mapper.Map<User>(model);

                //hash password
                user.Password = mD5Hash.ComputeMd5Hash(user.Password);

                //add user
                db.Users.Add(user);
                db.SaveChanges();

                //add user_role
                foreach(int rid in model.RoleId)
                {
                    Role r = db.Roles.Find(rid);
                    if(r != null)
                    {
                        User_Role user_Role= new User_Role();
                        user_Role.RoleId = rid;
                        user_Role.UserId = user.UserId;

                        db.User_Role.Add(user_Role);
                    }
                }
                
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                var user=db.Users.Where(u=>u.UserId== id&&u.IsDeleted==false).FirstOrDefault();
                if (user == null) { return false;}
                user.IsDeleted=true;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateUser(UserViewModel model)
        {
            try
            {
                User user = db.Users.Find(model.UserId);
                if (user == null) return false;

                User newUser = mapper.Map<User>(model);
                user = mapper.Map<User, User>(newUser);
                //update user_role?
                //List<User_Role> oldUR=db.User_Role.Where(u=>u.UserId==user.UserId).ToList();
                //List<User_Role> newUR=user.User_Role as List<User_Role>;
                ////delete oldUR that not contain in newUR
                //foreach(var ur in oldUR)
                //{
                //    if(!newUR.Any(m=>m.RoleId==ur.RoleId))
                //    {
                //        db.User_Role.Remove(ur);
                //    }
                //}
                //foreach (var ur in newUR)
                //{
                //    if (!oldUR.Any(m => m.RoleId == ur.RoleId))
                //    {
                //        db.User_Role.Add(ur);
                //    }
                //}

                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        
    }
}