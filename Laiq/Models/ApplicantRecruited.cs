using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Laiq.Models
{
    [Table("ApplicantRecruited")]
    public class ApplicantRecruited
    {
        [Key]
        public int ARID { get; set; }
        public int LApplicantID {get;set;}
        public string Organization {get;set;}
        public string Division     {get;set;}
        public string Department   {get;set;}
        public string Position     {get;set;}
        public decimal? Salary       {get;set;}
        public DateTime? JoinDate     {get;set;}
        public string PositionLevel{get;set;}
        public string Remarks { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}