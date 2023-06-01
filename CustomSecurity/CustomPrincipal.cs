using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace _67RoleBaseSecurity.CustomSecurity
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(string username) 
        {
            Identity=new GenericIdentity(username);
        }
        public IIdentity Identity {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            if (role == RoleName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}