namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            CategoryPosts = new HashSet<CategoryPost>();
            Posts = new HashSet<Post>();
        }

        public long ID { get; set; }

        public long ParentID { get; set; }

        [Required]
        [StringLength(1000)]
        public string Slug { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string ImageURL { get; set; }

        public int Sort { get; set; }

        public Guid? MultilingualGroupID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
