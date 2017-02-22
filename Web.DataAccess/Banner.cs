namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public long ID { get; set; }

        public long ParentID { get; set; }

        [Required]
        [StringLength(500)]
        public string Position { get; set; }

        [Required]
        [StringLength(500)]
        public string Type { get; set; }

        public Guid Code { get; set; }

        [StringLength(1000)]
        public string RedirectURL { get; set; }

        [StringLength(500)]
        public string RedirectType { get; set; }

        [StringLength(1000)]
        public string LinkURL { get; set; }

        [Required]
        [StringLength(1000)]
        public string ImageURL { get; set; }

        public int Sort { get; set; }

        public DateTime? PublishDate { get; set; }

        public DateTime? ExpiredDate { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(1000)]
        public string CustomText1 { get; set; }

        [StringLength(1000)]
        public string CustomText2 { get; set; }

        [StringLength(1000)]
        public string CustomText3 { get; set; }

        public Guid? MultilingualGroupID { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [StringLength(1000)]
        public string ImageURLMobile { get; set; }
    }
}
