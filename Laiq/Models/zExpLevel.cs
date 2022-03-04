using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zExpLevel")]
    public class zExpLevel
    {
        [Key]
        public int ExpLevID { get; set; }
        public string ExpLevel { get; set; }
        public string ExpLevelEn { get; set; }
    }
}