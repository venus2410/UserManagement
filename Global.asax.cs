﻿using _67RoleBaseSecurity.CustomSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace _67RoleBaseSecurity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperConfig.Init();
        }
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie authCookie= Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

                string data = ticket.UserData;
                string[] userData = data.Split('|');

                CustomPrincipal customPrincipal=new CustomPrincipal(userData[0]);
                customPrincipal.Name = userData[1];
                customPrincipal.Contact = userData[2];
                customPrincipal.Email = userData[3];
                customPrincipal.RoleName = userData[4];

                HttpContext.Current.User = customPrincipal;
            }
        }
    }
}
