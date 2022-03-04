using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zLanguage")]
    public class Language
    {
        [Key]
        public int LangID { get; set; }
        [Required]
        public string LangName { get; set; }
    }
}