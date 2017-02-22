using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Web.DataAccess;

namespace Srikandi.Models
{
    public class UserModel
    {
        public long ID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReEnterPassword { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long CMSRoleID { get; set; }
        public CMSRole Role { get; set; }
    }

    public class UserLoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class NavigationPrivilegeModel
    {
        public long ID { get; set; }
        [Required]
        public long CMSNavigationID { get; set; }
        [Required]
        public long CMSPrivilegeID { get; set; }
    }

    public class RoleNavigationPrivilegeModel
    {
        public long ID { get; set; }
        [Required]
        public long CMSRoleID { get; set; }
        [Required]
        public long CMSNavigationPrivilegeID { get; set; }
    }

    public class UserAccessModel
    {
        public long ID { get; set; }
        public string Controler { get; set; }
        public Guid Action { get; set; }
    }
}