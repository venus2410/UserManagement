using _67RoleBaseSecurity.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _67RoleBaseSecurity.Models
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}