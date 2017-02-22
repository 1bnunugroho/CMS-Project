namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BannerPosition")]
    public partial class BannerPosition
    {
        public long ID { get; set; }

        [Required]
        public string PositionText { get; set; }

        [Required]
        public string PositionValue { get; set; }

        public bool IsDeleted { get; set; }
    }
}
