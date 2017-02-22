namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            PostWidgets = new HashSet<PostWidget>();
        }

        public long ID { get; set; }

        public long CategoryID { get; set; }

        public long ParentID { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(500)]
        public string MetaTitle { get; set; }

        [StringLength(1000)]
        public string MetaDescription { get; set; }

        [StringLength(500)]
        public string MetaKeyword { get; set; }

        [Required]
        [StringLength(1000)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Slug { get; set; }

        [StringLength(1000)]
        public string Intro { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public string Body { get; set; }

        [StringLength(500)]
        public string ImageURL { get; set; }

        [StringLength(500)]
        public string ThumbURL { get; set; }

        [StringLength(500)]
        public string VideoURL { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? MultilingualGroupID { get; set; }

        public bool? CurrentVersion { get; set; }

        [StringLength(1000)]
        public string Tag { get; set; }

        [StringLength(1000)]
        public string FileURL { get; set; }

        public int Sort { get; set; }

        public DateTime? PublishDate { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int TotalLike { get; set; }

        [StringLength(50)]
        public string WidgetTitle { get; set; }

        public bool IsFeatured { get; set; }

        [StringLength(1000)]
        public string Source { get; set; }

        public long? CategoryPostID { get; set; }

        public int TotalView { get; set; }

        public virtual Category Category { get; set; }

        public virtual CategoryPost CategoryPost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostWidget> PostWidgets { get; set; }
    }
}
