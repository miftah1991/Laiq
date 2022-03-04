using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("PhoneInterview")]
    public class PhoneInterview
    {
        [Key]
        public int PIntID {get;set;}
        public int LApplicantID {get;set;}
        //public int QuestionID {get;set;}
        //public int Marks {get;set;}
        public string Rmarks {get;set;}
        public string PersonalityType {get;set;}
        public string MgmtStyle {get;set;}
        public int USERID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string NextStep { get; set; }
        public string ExpectedPosition { get; set; }
        public ICollection<PhoneInterviewDetail> PhoneInterviewDetail { get; set; }
    }
}