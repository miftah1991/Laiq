using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("LaiqApplicants")]
    public class LaiqApplicants
    {
        [Key]
        public int LApplicantID {get;set;}
        public Guid EncodeID {get;set;}
        public string Name {get;set;}
        public string LName {get;set;}
        public string NIDNumber {get;set;}
        public string Gender {get;set;}
        public string Mobile {get;set;}
        public string Mobile2 {get;set;}
        public int DOBYear {get;set;}
        public int DOBMonth {get;set;}
        public int DOBDay {get;set;}
        public string Email {get;set;}
        public int AddressCountryID {get;set;}
        [DisplayName("Province")]
        public int? PPRID {get;set;}
        [DisplayName("District")]
        public int? PDISID {get;set;}
        public string City {get;set;}
        public string Street {get;set;}
        public string WorkExp {get;set;}
        [DisplayName("Experiance Year")]
        public int? ExpYearID {get;set;}
        [DisplayName("Experiance Level")]
        public int? ExpLevlID {get;set;}
        [DisplayName("Experiance Staff")]
        public int? ExpStaffID {get;set;}
        [DisplayName("Salary")]
        public decimal? HighSalary {get;set;}
        [DisplayName("Expect Salary")]
        public decimal? ExpectedSalary {get;set;}
        public ICollection<LaiqApplicantEdu> LaiqApplicantEdu { get; set; }
        public ICollection<LaiqApplicantLang> LaiqApplicantLang { get; set; }
        public ICollection<LaiqApplicantSoftSkils> LaiqApplicantSoftSkils { get; set; }
        public ICollection<LaiqApplicantCompSkills> LaiqApplicantCompSkills { get; set; }
        public ICollection<LaiqApplicantCertification> LaiqApplicantCertification { get; set; }
        public ICollection<ApplicantJobDetail> ApplicantJobDetail { get; set; }
        
        public DateTime? CreatedOn { get; set; }
        public string IPAddress { get; set; }
        public int? NAddressCountryID { get; set; }
        public int? NPRID { get; set; }
        public int? NDISID { get; set; }
        public string NCity { get; set; }
    }
}