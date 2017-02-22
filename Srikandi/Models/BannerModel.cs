using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Srikandi.Models
{
    public class BannerModel
    {
        public long ID { get; set; }
        public long ApplicationID { get; set; }
        public long LanguageID { get; set; }
        public long ParentID { get; set; }
        [Required]
        public string Position { get; set; }
        public string Type { get; set; }
        public string RedirectURL { get; set; }
        public string RedirectType { get; set; }

        [Required]
        public string ImageURL { get; set; }
        [Required]
        public string ImageURLMobile { get; set; }
        public int Sort { get; set; }

        public DateTime PublishDate { get; set; }

        [Required]
        public string PublishDay { get; set; }

        [Required]
        public string PublishHour { get; set; }

        [Required]
        public string PublishMinute { get; set; }

        public DateTime ExpiredDate { get; set; }

        [Required]
        public string ExpiredDay { get; set; }

        [Required]
        public string ExpiredHour { get; set; }

        [Required]
        public string ExpiredMinute { get; set; }

        public bool IsDeleted { get; set; }

        public Guid? MultilingualGroupID { get; set; }
        public string CustomText1 { get; set; }
        public string CustomText2 { get; set; }
        public string CustomText3 { get; set; }
    }
}