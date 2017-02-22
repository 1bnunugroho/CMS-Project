namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostWidget")]
    public partial class PostWidget
    {
        public long ID { get; set; }

        public long PostId { get; set; }

        [Required]
        [StringLength(50)]
        public string WidgetTitle { get; set; }

        [Required]
        public string WidgetDesc { get; set; }

        [Required]
        [StringLength(150)]
        public string ImageUrl { get; set; }

        public int Order { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Post Post { get; set; }
    }
}
