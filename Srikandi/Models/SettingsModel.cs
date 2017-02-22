using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Srikandi.Models
{
    public class SettingsModel
    {
        public int ID { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }

    }
}