using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _67RoleBaseSecurity.CustomSecurity
{
    public class CustomAuthorization : FilterAttribute, IAuthorizationFilter
    {
        public string Role { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.User.Identity.IsAuthenticated) 
            {
                if(!filterContext.HttpContext.User.IsInRole(Role))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Unauthorize" }));
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {controller="Account",action="Login"}));
            }
        }
    }
}