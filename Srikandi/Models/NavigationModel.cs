using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Srikandi.Models
{


    public class NavigationModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Controller { get; set; }
        public int sort { get; set; }
        public long? ParentID { get; set; }
        public bool IsHide { get; set; }
        public long[] Previlage { get; set; }
    }

    public class RoleModel
    {
        public long ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public long[] NavigationPrevilage { get; set; }
    }

    public class PrivilegeModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
    }

}