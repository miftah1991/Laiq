using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laiq.ViewModel
{
    public class AppEduVM
    {
        public int  LApplicantEduID{get;set;}
        public int? LApplicantID {get;set;}
        public int? QualificationID {get;set;}
        public int? QAID {get;set;}
        public int? EFID {get;set;}
        public string  EducationField{get;set;}
        public string  University{get;set;}
        public int? CountryID {get;set;}
        public int? GraduationYear {get;set;}
        public string  QualificationNameEn{get;set;}
        public string  QAreaEn{get;set;}
        public string  EFNameEn{get;set;}
        public string  CountryNameEn{get;set;}
    }
    public class AppLangVM
    {
        public int LApplicantLangID {get;set;}
        public string LangNameEn {get;set;}
        public string Reading {get;set;}
        public string Speaking {get;set;}
        public string Writing {get;set;}
    }
    public class AppSoftVM
    {
        public int LApplicantSoftID {get;set;}
        public int LApplicantID {get;set;}
        public int SkillsID {get;set;}
        public string RatingID {get;set;}
        public string SkillNameEn {get;set;}
    }
    public class AppCompSkillVM
    {
        public int LApplicantCompSkID {get;set;}
        public int LApplicantID {get;set;}
        public int CSID {get;set;}
        public int CSValue {get;set;}
        public string CompSkillEn {get;set;}
        public string CSValueName {get;set;}
    }

    public class AppCVMarksAVGVM
    {
        public int LApplicantID {get;set;}
        public decimal? Communication {get;set;}
        public decimal? Creativity {get;set;}
        public decimal? Leadership {get;set;}
        public decimal? English {get;set;}
        public decimal? Dari {get;set;}
        public decimal? Pashto {get;set;}
    }
    public class GroupDisCategoryVM
    {
        public int GACID {get;set;}
        public int LApplicantID {get;set;}
        public string CategoryID {get;set;}
        public string Remarks {get;set;}
    }
}