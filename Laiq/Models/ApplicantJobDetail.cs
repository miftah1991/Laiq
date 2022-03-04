using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("ApplicantJobDetail")]
    public class ApplicantJobDetail
    {
        [Key]
        public int  AJDID {get;set;}
        public int LApplicantID {get;set;}
        [Required]
        public string  JobTitle {get;set;}
        [Required]
        public string  Organization {get;set;}
        [Required]
        public int ZDID {get;set;}
    }
}