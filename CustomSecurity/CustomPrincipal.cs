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
            UserName=username;
            RoleName = new List<string>();
        }
        public IIdentity Identity {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            foreach(string userRole in RoleName)
            {
                if (role == userRole)
                {
                    return true;
                }
            }
            return false;
        }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> RoleName { get; set; }
    }
}