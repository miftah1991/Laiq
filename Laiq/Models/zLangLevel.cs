using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zLangLevel")]
    public class zLangLevel
    {
        [Key]
        public int LLID { get; set; }
        public string LangLevel { get; set; }
        //public string Remarks { get; set; } 

    }
}