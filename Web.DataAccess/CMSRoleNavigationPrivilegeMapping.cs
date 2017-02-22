namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMSRoleNavigationPrivilegeMapping")]
    public partial class CMSRoleNavigationPrivilegeMapping
    {
        public long ID { get; set; }

        public long CMSRoleID { get; set; }

        public long CMSNavigationPrivilegeID { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(100)]
        public string UpdateBy { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public virtual CMSNavigationPrivilegeMapping CMSNavigationPrivilegeMapping { get; set; }

        public virtual CMSRole CMSRole { get; set; }
    }
}
