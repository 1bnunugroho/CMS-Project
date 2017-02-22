namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Setting
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string Code { get; set; }

        [Required]
        [StringLength(200)]
        public string Key { get; set; }

        [Required]
        [StringLength(200)]
        public string Value { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(200)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(200)]
        public string UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
