namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMSPrivilege")]
    public partial class CMSPrivilege
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMSPrivilege()
        {
            CMSNavigationPrivilegeMappings = new HashSet<CMSNavigationPrivilegeMapping>();
        }

        public long ID { get; set; }

        public Guid Code { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

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
        public virtual ICollection<CMSNavigationPrivilegeMapping> CMSNavigationPrivilegeMappings { get; set; }
    }
}
