using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    public class ReportsVM
    {
        public int Counts { get; set; }
        public string Category { get; set; }
    }
    public class ReportsGnderVM
    {
        public int? Male { get; set; }
        public int? Female { get; set; }
        public int? TotalAmount { get; set; }
        public string Category { get; set; }
    }
    public class ApplicantsVM
    {
        public int LApplicantID {get;set;}
        public string EncodeID {get;set;}
        public string Name {get;set;}
        public string Mobile {get;set;}
        public string Mobile2 {get;set;}
        public string Email {get;set;}
        public string QualificationNameEn {get;set;}
        public string QAreaEn {get;set;}
        public string EFNameEn {get;set;}
        public string ExpYearEn {get;set;}
        public int Age {get;set;}
    }
    public class ApplicantPhoneInterViewVM
    {
        public int LApplicantID { get; set; }
        public string EncodeID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string Email { get; set; }
        public string QualificationNameEn { get; set; }
        public string QAreaEn { get; set; }
        public string EFNameEn { get; set; }
        public string ExpYearEn { get; set; }
        public string PhoneNextStep { get; set; }
        public int Age { get; set; }
        
    }
}