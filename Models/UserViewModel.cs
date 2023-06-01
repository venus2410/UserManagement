using _67RoleBaseSecurity.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _67RoleBaseSecurity.Models
{
    public class UserViewModel
    {
        public int? UserId { get; set; }
        [Required]
        [Display(Name ="User name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        [Display(Name ="Alias Name")]
        public string AliasName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> HiringDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        [DefaultValue(true)]
        public Nullable<bool> IsActive { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> CreateDate { get; set; }
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> LastUploadDate { get; set; }
        [DefaultValue(false)]
        public Nullable<bool> IsDeleted { get; set; }
        public List<string> RoleName { get; set; }
        public List<int> RoleId { get; set; }
    }
}