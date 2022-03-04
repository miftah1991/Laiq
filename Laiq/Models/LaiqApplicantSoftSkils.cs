using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{

    [Table("LaiqApplicantSoftSkils")]
    public class LaiqApplicantSoftSkils
    {
        [Key]
        public int LApplicantSoftID {get;set;}
        public int LApplicantID {get;set;}
        [DisplayName("Please select skill")]
        [Required]
        public int SkillsID {get;set;}
        [DisplayName("Please select rating")]
        public string RatingID {get;set;}
    }
}