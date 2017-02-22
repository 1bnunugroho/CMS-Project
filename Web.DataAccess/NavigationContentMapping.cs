namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NavigationContentMapping")]
    public partial class NavigationContentMapping
    {
        public long ID { get; set; }

        public long NavID { get; set; }

        public long ContentTypeID { get; set; }

        [Required]
        public string ContentID { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ContentType ContentType { get; set; }

        public virtual Navigation Navigation { get; set; }
    }
}
