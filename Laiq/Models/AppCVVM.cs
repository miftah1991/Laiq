using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    public class AppCVVM
    {
        public int LApplicantID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Mobile2 { get; set; }
        public string PhdArea { get; set; }
        public string PhdEFName { get; set; }
        public string PHDEducationField { get; set; }
        public string PhdYear { get; set; }
        public string PhdUniversity { get; set; }
        public string PhdCountry { get; set; }
        public string MSArea { get; set; }
        public string MSEFName { get; set; }
        public string MSEducationField { get; set; }
        public string MSYear { get; set; }
        public string MSUniversity { get; set; }
        public string MSCountry { get; set; }
        public string BCArea { get; set; }
        public string BCEFName { get; set; }
        public string BCEducationField { get; set; }
        public string BCYear { get; set; }
        public string BCUniversity { get; set; }
        public string BCCountry { get; set; }
        public string ExpYearEn { get; set; }
        public string ExpLevelEn { get; set; }
        public string ExpStaffEn { get; set; }
        public decimal? HighSalary { get; set; }
        public decimal? ExpectedSalary { get; set; }
        public string CountryNameEn { get; set; }
        public string PRNameEn { get; set; }
        public int? Age { get; set; }
    }
}