using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("ApplicantCategory")]
    public class ApplicantCategory
    {
        [Key]
        public int AppCatID {get;set;}
        public int LApplicantID {get;set;}
        public int CateID {get;set;}
        public int USERID {get;set;}
        public DateTime? CreatedOn {get;set;}
        public string Remarks {get;set;}
    }
}