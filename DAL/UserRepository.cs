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
using System.Runtime.Serialization;
using System.Web.Helpers;

namespace _67RoleBaseSecurity.DAL
{
    
    public class UserRepository : IUserRepository
    {
        UserManagementEntities2 db =new UserManagementEntities2();
        IMapper mapper = AutoMapperConfig.Mapper;
        MD5Hash mD5Hash= new MD5Hash();
        public UserModel Validate(LoginViewModel model)
        {
            string hashPassword=mD5Hash.ComputeMd5Hash(model.Password);
            User user=db.Users.Where(u => u.UserName == model.Username && u.Password == hashPassword).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            UserModel userMdl= mapper.Map<UserModel>(user);
            userMdl.RoleName = new List<string>();
            foreach(User_Role ur in user.User_Role)
            {
                userMdl.RoleName.Add(ur.Role.RoleName);
            }
            return userMdl;
        }
        public List<UserModel> GetAll()
        {
            var lstUser = db.Users.Where(u => u.IsDeleted == false).ToList();
            var lstUserMdl= new List<UserModel>();
            foreach(var user in lstUser) {
                var userMdl=mapper.Map<UserModel>(user);
                //var user_Role=db.User_Role.Where(u => u.UserId==user.UserId).ToList();
                //var role = db.Roles.Where(r => user_Role.Where(m => m.RoleId == r.RoleId) != null);
                //List<RoleViewModel> roleModel=mapper.Map<List<RoleViewModel>>(role);
                userMdl.RoleId = new List<int>();
                userMdl.RoleName = new List<string>();
                foreach (var ur in user.User_Role)
                {
                    userMdl.RoleId.Add(ur.Role.RoleId);
                    userMdl.RoleName.Add(ur.Role.RoleName);
                }

                lstUserMdl.Add(userMdl);
            }
            return lstUserMdl;
        }
        public UserModel GetById(int id)
        {
            var user = db.Users.Where(u => u.UserId == id && u.IsDeleted == false).FirstOrDefault();
            var userMdl= mapper.Map<UserModel>(user);

            userMdl.RoleId = new List<int>();
            userMdl.RoleName = new List<string>();

            foreach (User_Role ur in user.User_Role)
            {
                userMdl.RoleId.Add(ur.Role.RoleId);
                userMdl.RoleName.Add(ur.Role.RoleName);
            }
            userMdl.Password = "none show password";

            return userMdl;
        }
        public bool AddUser(UserModel model)
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
                if (model.RoleId != null)
                {
                    foreach (int rid in model.RoleId)
                    {
                        Role r = db.Roles.Find(rid);
                        if (r != null)
                        {
                            User_Role user_Role = new User_Role();
                            user_Role.RoleId = rid;
                            user_Role.UserId = user.UserId;

                            db.User_Role.Add(user_Role);
                        }
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

        public bool UpdateUser(UserModel model)
        {
            try
            {
                User user = db.Users.Find(model.UserId);
                if (user == null) return false;

                //User newUser = mapper.Map<User>(model);
                //user = mapper.Map<User, User>(newUser);
                //db.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;

                user.UserName=model.UserName;
                user.FirstName=model.FirstName;
                user.LastName=model.LastName;
                user.AliasName=model.AliasName;
                user.Email=model.Email;
                user.Phone=model.Phone;
                user.Gender=model.Gender;
                user.HiringDate=model.HiringDate;
                user.BirthDay=model.BirthDay;
                user.Address=model.Address;
                user.JobTitle=model.JobTitle;
                user.IsActive=model.IsActive;
                user.CreateDate=model.CreateDate;
                user.LastLoginDate=model.LastLoginDate;
                user.LastUploadDate=model.LastUploadDate;



                db.SaveChanges();
                //update user_role?
                List<User_Role> oldUR = db.User_Role.Where(u => u.UserId == user.UserId).ToList();
                List<int> newURId = model.RoleId.ToList();
                //delete oldUR that not contain in newUR
                foreach (var ur in oldUR)
                {
                    if (!newURId.Any(m => m == ur.RoleId))
                    {
                        db.User_Role.Remove(ur);
                    }
                }
                foreach (var ur in newURId)
                {
                    if (!oldUR.Any(m => m.RoleId == ur))
                    {
                        User_Role userRole=new User_Role();
                        userRole.RoleId = ur;
                        userRole.UserId= user.UserId;
                        db.User_Role.Add(userRole);
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

        public bool IsEmailExist(string email, int? id)
        {
            if (id == null)
            {
                var user = db.Users.Where(u => u.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
                return user != null;
            }
            else
            {
                var user=db.Users.Where(u=>u.UserId==id).FirstOrDefault();
                string oldEmail = user.Email;
                if(oldEmail==email) return false;
                var user1 = db.Users.Where(u => u.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
                return user1 != null;
            }
        }

        public bool IsUserNameExist(string userName, int? id)
        {
            if (id == null)
            {
                var user = db.Users.Where(u => u.UserName.ToUpper() == userName.ToUpper()).FirstOrDefault();
                return user != null;
            }
            else
            {
                var user = db.Users.Where(u => u.UserId == id).FirstOrDefault();
                string oldUserName = user.UserName;
                if (oldUserName == userName) return false;
                var user1 = db.Users.Where(u => u.UserName.ToUpper() == userName.ToUpper()).FirstOrDefault();
                return user1 != null;
            }
        }
    }
}