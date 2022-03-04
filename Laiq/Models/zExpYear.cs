using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zExpYear")]
    public class zExpYear
    {
        [Key]
        public int ExpYearID  {get;set;}
        public string ExpYear  {get;set;}
        public string ExpYearEn  {get;set;}
    }
}