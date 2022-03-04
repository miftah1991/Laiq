using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("LaiqApplicantEdu")]
    public class LaiqApplicantEdu
    {
        [Key]
        public int LApplicantEduID {get;set;}
        [Required]
        public int LApplicantID {get;set;}
        [Required]
        
        public int QualificationID {get;set;}
        [DisplayNameAttribute("Please select qualification area")]
        public int QAID {get;set;}
        [DisplayNameAttribute("Please select field of study")]
        public int EFID {get;set;}
        public string EducationField {get;set;}
        public string University {get;set;}
        public int CountryID {get;set;}
        public int GraduationYear {get;set;}
    }
}