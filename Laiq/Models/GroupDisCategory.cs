using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("GroupDisCategory")]
    public class GroupDisCategory
    {
        [Key]
        public int GACID {get;set;}
        public int LApplicantID {get;set;}
        public string CategoryID { get;set;}
        public string Remarks {get;set;}
        public int CreatedBy {get;set;}
        public DateTime? CreatedOn {get;set;}
    }
}