using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("GroupDiscussion")]
    public class GroupDiscussion
    {
         [Key]
         public int GDID {get;set;}
         public string GDName {get;set;}
         public DateTime GDDate {get;set;}
         public int CreatedBy {get;set;}
         public DateTime CreatedOn {get;set;}
         public string Remarks {get;set;}
        public ICollection<GroupPanel> GroupPanel { get; set; }

    }
    public class GroupsVM
    {
        public int GDID { get; set; }
        public string GDName { get; set; }
    }
    public class GroupDiscResultVM
    {
        public int?  GRID {get;set;}
        public int  LApplicantID {get;set;}
        public int?  USERID {get;set;}
        public int?  Communication {get;set;}
        public int?  Creativity {get;set;}
        public int?  Leadership {get;set;}
        public int?  English {get;set;}
        public int?  Dari {get;set;}
        public int?  Pashto {get;set;}
        public string  Remarks {get;set;}
        public DateTime?  CreatedOn {get;set;}
    }
    public class GroupDiscAvgVM
    {
        public int  LApplicantID {get;set;}
        public decimal?  Communication {get;set;}
        public decimal Creativity {get;set;}
        public decimal Leadership {get;set;}
        public decimal English {get;set;}
        public decimal Dari {get;set;}
        public decimal Pashto {get;set;}
        public string Name {get;set;}
        public string QualificationNameEn {get;set;}
        public string EFNameEn {get;set;}
        public string EducationField {get;set;}
    }
    public class GroupAllPanelMarks
    {
        public string Name {get;set;}
        public int LApplicantID {get;set;}
        public int Communication {get;set;}
        public int Creativity {get;set;}
        public int Leadership {get;set;}
        public int English {get;set;}
        public int Dari {get;set;}
        public int Pashto {get;set;}
        public string Remarks {get;set;}
    }
    public class WishListVM
    {
        public int WLID {get;set;}
        public int LApplicantID {get;set;}
        public string Location {get;set;}
        public int USERID {get;set;}
        public string Category {get;set;}
        public DateTime? CreatedOn {get;set;}
        public string Name {get;set;}
        public string QualificationNameEn {get;set;}
        public string EFNameEn {get;set;}
        public string EducationField {get;set;}
        public string ExpYearEn { get;set;}
        public string EncodeID { get;set;}
        public string Remarks { get;set;}
        
    }
}