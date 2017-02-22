namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Navigation")]
    public partial class Navigation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Navigation()
        {
            NavigationContentMappings = new HashSet<NavigationContentMapping>();
        }

        public long ID { get; set; }

        public long ParentID { get; set; }

        public long LanguageID { get; set; }

        public string GroupID { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string RedirectURL { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string Position { get; set; }

        public int Sort { get; set; }

        public Guid? MultilingualGroupID { get; set; }

        public string PermanentRedirect { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NavigationContentMapping> NavigationContentMappings { get; set; }
    }
}
