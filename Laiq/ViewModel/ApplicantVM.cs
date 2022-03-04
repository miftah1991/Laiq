using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laiq.ViewModel
{
    public class ApplicantVM
    {
        public int LApplicantID {get;set;}
        public string Name {get;set;}
        public string NIDNumber {get;set;}
        public string Gender {get;set;}
        public string Mobile {get;set;}
        public string Mobile2 {get;set;}
        public string Email {get;set;}
        public int Age {get;set;}
        public string CountryName {get;set;}
        public string PRNameEn {get;set;}
        public string QualificationNameEn {get;set;}
        public string QAreaEn {get;set;}
        public string EFNameEn {get;set;}
        public string EducationField {get;set;}
        public string AddressCountry {get;set;}
        public int? GraduationYear {get;set;}
        public string University {get;set;}
        public string ExpLevelEn {get;set;}
        public string ExpStaffEn {get;set;}
        public string ExpYearEn {get;set;}
        public string Status { get;set;}
        public string EncodeID {get;set;}
        public string NPRNameEn { get;set;}
        public string DISNameEn { get;set;}
        public string NDISNameEn { get;set;}
    }
    public class ApplicantProfileVM
    {
        public int LApplicantID { get; set; }
        public string Name { get; set; }
        public string NIDNumber { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string CountryName { get; set; }
        public string PRNameEn { get; set; }
        public string QualificationNameEn { get; set; }
        public string QAreaEn { get; set; }
        public string EFNameEn { get; set; }
        public string EducationField { get; set; }
        public string AddressCountry { get; set; }
        public int? GraduationYear { get; set; }
        public string University { get; set; }
        public string ExpLevelEn { get; set; }
        public string ExpStaffEn { get; set; }
        public string ExpYearEn { get; set; }
        public string EncodeID { get; set; }
        public string DISName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string WorkExp { get; set; }
        public decimal? HighSalary { get; set; }
        public decimal? ExpectedSalary { get; set; }
    }
    public class ApplicantInterviewedVM
    {
        public int LApplicantID { get; set; }
        public string Name { get; set; }
        public string NIDNumber { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string CountryName { get; set; }
        public string PRNameEn { get; set; }
        public string QualificationNameEn { get; set; }
        public string QAreaEn { get; set; }
        public string EFNameEn { get; set; }
        public string EducationField { get; set; }
        public string AddressCountry { get; set; }
        public int? GraduationYear { get; set; }
        public string University { get; set; }
        public string ExpLevelEn { get; set; }
        public string ExpStaffEn { get; set; }
        public string ExpYearEn { get; set; }
        public string Status { get; set; }
        public string EncodeID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string InterviewedBy { get; set; }
        public string MgmtStyle { get; set; }
        public string PersonalityType { get; set; }
        public string NextStep { get; set; }
        public string InterviewRemarks { get; set; }
        public string ExpectedPosition { get; set; }

    }
    public class GroupDiscResultCategoryVM
    {
        public int LApplicantID { get; set; }
        public string Name { get; set; }
        public string NIDNumber { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string CountryName { get; set; }
        public string PRNameEn { get; set; }
        public string QualificationNameEn { get; set; }
        public string QAreaEn { get; set; }
        public string EFNameEn { get; set; }
        public string EducationField { get; set; }
        public string AddressCountry { get; set; }
        public int? GraduationYear { get; set; }
        public string University { get; set; }
        public string ExpLevelEn { get; set; }
        public string ExpStaffEn { get; set; }
        public string ExpYearEn { get; set; }
        public string Status { get; set; }
        public string EncodeID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CategoryID { get; set; }
        public string GDName { get; set; }
        public string PackName { get; set; }
        public string Organization { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string PositionLevel { get; set; }
        public string HireRemarks { get; set; }
        public Decimal? Salary { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? ARID { get; set; }

    }
    public class ApplicantInGroupVM
    {
        public int LApplicantID { get; set; }
        public string Name { get; set; }
        public string NIDNumber { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string CountryName { get; set; }
        public string PRNameEn { get; set; }
        public string QualificationNameEn { get; set; }
        public string QAreaEn { get; set; }
        public string EFNameEn { get; set; }
        public string EducationField { get; set; }
        public string AddressCountry { get; set; }
        public int? GraduationYear { get; set; }
        public string University { get; set; }
        public string ExpLevelEn { get; set; }
        public string ExpStaffEn { get; set; }
        public string ExpYearEn { get; set; }
        public string Status { get; set; }
        public string EncodeID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string InterviewedBy { get; set; }
        public string MgmtStyle { get; set; }
        public string PersonalityType { get; set; }
        public string NextStep { get; set; }
        public string InterviewRemarks { get; set; }
        public string ExpectedPosition { get; set; }
        public string GDName { get; set; }
    }

}