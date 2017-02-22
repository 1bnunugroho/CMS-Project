namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMSNavigationPrivilegeMapping")]
    public partial class CMSNavigationPrivilegeMapping
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMSNavigationPrivilegeMapping()
        {
            CMSRoleNavigationPrivilegeMappings = new HashSet<CMSRoleNavigationPrivilegeMapping>();
        }

        public long ID { get; set; }

        public long CMSNavigationID { get; set; }

        public long CMSPrivilegeID { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(100)]
        public string UpdateBy { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public virtual CMSNavigation CMSNavigation { get; set; }

        public virtual CMSPrivilege CMSPrivilege { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMSRoleNavigationPrivilegeMapping> CMSRoleNavigationPrivilegeMappings { get; set; }
    }
}
