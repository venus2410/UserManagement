using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _67RoleBaseSecurity.CustomSecurity;
using _67RoleBaseSecurity.DAL;
using _67RoleBaseSecurity.Models;

namespace _67RoleBaseSecurity.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository userRepository=new UserRepository();
        public ActionResult Index()
        {
            List<UserModel> users = userRepository.GetAll();
            return View(users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}