namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMSNavigation")]
    public partial class CMSNavigation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CMSNavigation()
        {
            CMSNavigation1 = new HashSet<CMSNavigation>();
            CMSNavigationPrivilegeMappings = new HashSet<CMSNavigationPrivilegeMapping>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Controller { get; set; }

        public int sort { get; set; }

        public bool IsChild { get; set; }

        public long? ParentID { get; set; }

        public bool IsHide { get; set; }

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
        public virtual ICollection<CMSNavigation> CMSNavigation1 { get; set; }

        public virtual CMSNavigation CMSNavigation2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CMSNavigationPrivilegeMapping> CMSNavigationPrivilegeMappings { get; set; }
    }
}
