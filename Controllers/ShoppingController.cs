using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _67RoleBaseSecurity.CustomSecurity;

namespace _67RoleBaseSecurity.Controllers
{
    [CustomAuthentication]
    [CustomAuthorization(Role = "user")]
    public class ShoppingController : Controller
    {
        // GET: Shopping

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shopping()
        {
            return View();
        }
    }
}