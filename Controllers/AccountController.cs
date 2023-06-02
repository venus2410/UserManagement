using _67RoleBaseSecurity.DAL;
using _67RoleBaseSecurity.DataModel;
using _67RoleBaseSecurity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _67RoleBaseSecurity.Controllers
{
    public class AccountController : Controller
    {
        IUserRepository userRepository=new UserRepository();
        IRoleRepository roleRepository=new RoleRepository();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel userModel = userRepository.Validate(model);
                if (userModel == null)
                {
                    ModelState.AddModelError("", "Wrong username or password");
                }
                else
                {
                    string userData = string.Format("{0}|{1}|{2}|{3}",userModel.UserName,userModel.FirstName,userModel.LastName,userModel.Email);
                    foreach(string ur in userModel.RoleName)
                    {
                        userData += "|" + ur;
                    }
                    //create forms authentication ticket
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userModel.UserName, DateTime.Now, DateTime.Now.AddHours(2), false, userData);
                    //encrypt ticket
                    string encryptTicket = FormsAuthentication.Encrypt(ticket);
                    //add ticket to cookies
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index","Home");
                }
            }
            else 
            {
                ModelState.AddModelError("", "Invalid Data");
            }
            return View(model);
        }
        public ActionResult Unauthorize()
        {
            return View();
        }
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public PartialViewResult Create()
        {
            ViewBag.Roles=roleRepository.GetAll();
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (userRepository.AddUser(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
            else 
            { return View(model); }
        }

        public PartialViewResult Edit(int id)
        {
            var model=userRepository.GetById(id);
            ViewBag.Roles = roleRepository.GetAll();
            return PartialView("_Edit",model);
        }
        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            if (ModelState.IsValid)
            {
                if(userRepository.UpdateUser(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult CheckExistingEmail(string email)
        {
             return Json(!userRepository.IsEmailExist(email), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CheckExistingUserName(string userName)
        {
            return Json(!userRepository.IsUserNameExist(userName), JsonRequestBehavior.AllowGet);
        }
    }
}