using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zLevel")]
    public class zLevel
    {
        [Key]
        public int LevelID {get;set;}
        [Required]
        public string LevelName {get;set;}
        public string LevelNameEn {get;set;}
    }
}