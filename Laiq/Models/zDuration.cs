using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zDuration")]
    public class zDuration
    {
        [Key]
        public int ZDID {get;set;}
        public string DurName {get;set;}
        public string DurNameEn {get;set;}
        public string DurNamePs {get;set;}
    }
}