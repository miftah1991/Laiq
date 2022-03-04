using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("LaiqApplicantLang")]
    public class LaiqApplicantLang
    {
        [Key]
        public int LApplicantLangID {get;set;}
        public int LApplicantID {get;set;}
        [Required]
        [DisplayName("Please select language")]
        public int LangID {get;set;}
        [Required]
        [DisplayName("Please select reading")]
        public int ReadingID {get;set;}
        [DisplayName("Please select Speaking")]
        public int SpeakingID { get;set;}
        [DisplayName("Please select Writing")]
        public int WritingID {get;set;}
    }
}