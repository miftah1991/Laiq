using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("PackageApplicants")]
    public class PackageApplicants
    {
        [Key]
        public int PAID {get;set;}
        public int LApplicantID {get;set;}
        public int PackID {get;set;}
        public string Remarks {get;set;}
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}