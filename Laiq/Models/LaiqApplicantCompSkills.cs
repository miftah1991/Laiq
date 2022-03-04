using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("LaiqApplicantCompSkills")]
    public class LaiqApplicantCompSkills
    {
        [Key]
        public int LApplicantCompSkID {get;set;}
        public int LApplicantID {get;set;}
        [DisplayName("Please select computer skill")]
        [Required]
        public int CSID {get;set;}
        [DisplayName("Please select computer skill rating")]
        public int CSValue {get;set;}
    }
}