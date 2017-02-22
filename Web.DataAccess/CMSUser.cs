namespace Web.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CMSUser")]
    public partial class CMSUser
    {
        public int ID { get; set; }

        public long CMSRoleID { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        public Guid UserPrivateSecret { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [Required]
        [StringLength(200)]
        public string Username { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        [StringLength(100)]
        public string UpdateBy { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public virtual CMSRole CMSRole { get; set; }
    }
}
