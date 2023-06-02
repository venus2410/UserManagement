using _67RoleBaseSecurity.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _67RoleBaseSecurity.Models
{
    public class UserModel
    {
        public int? UserId { get; set; }
        [Required]
        [Remote("IsValidUserName", "Account",AdditionalFields = "UserId", ErrorMessage = "User Name already exists!")]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Alias Name")]
        public string AliasName { get; set; }
        [Required]
        [EmailAddress]
        [Remote("IsValidEmail", "Account",AdditionalFields = "UserId", ErrorMessage = "Email already exists!")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Hiring Date")]
        public Nullable<System.DateTime> HiringDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Birth Day")]
        public Nullable<System.DateTime> BirthDay { get; set; }
        public string Address { get; set; }
        [Display(Name ="Job Title")]
        public string JobTitle { get; set; }
        [DefaultValue(true)]
        [Display(Name ="Active?")]
        public Nullable<bool> IsActive { get; set; } = true;
        [DataType(DataType.Date)]
        [Display(Name = "Create Date")]
        public Nullable<System.DateTime> CreateDate { get; set; }=DateTime.Now;
        [DataType(DataType.Date)]
        [Display(Name = "Last Login Date")]
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Last Upload Date")]
        public Nullable<System.DateTime> LastUploadDate { get; set; }
        [DefaultValue(false)]
        public Nullable<bool> IsDeleted { get; set; } = false;
        [Display(Name ="Roles")]
        public List<string> RoleName { get; set; }
        public List<int> RoleId { get; set; }
        
    }
}