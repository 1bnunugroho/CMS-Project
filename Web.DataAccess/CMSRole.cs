namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMSRole")]
    public partial class CMSRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMSRole()
        {
            CMSRoleNavigationPrivilegeMappings = new HashSet<CMSRoleNavigationPrivilegeMapping>();
            CMSUsers = new HashSet<CMSUser>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        public Guid Code { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(100)]
        public string UpdateBy { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMSRoleNavigationPrivilegeMapping> CMSRoleNavigationPrivilegeMappings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMSUser> CMSUsers { get; set; }
    }
}
