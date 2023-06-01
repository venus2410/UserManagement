﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace _67RoleBaseSecurity.CustomSecurity
{
    public class CustomAuthentication : FilterAttribute, IAuthenticationFilter
    {
        //before action method
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.Result = new HttpUnauthorizedResult();
        }
        //before generate result of action method
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if(filterContext.Result==null||filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {controller="Account", action="Login"}));
            }
        }
    }
}