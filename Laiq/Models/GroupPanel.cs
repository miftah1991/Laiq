using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("GroupPanel")]
    public class GroupPanel
    {
        [Key]
        public int  GDPanID {get;set;}
        [Required]
        public int  GDID {get;set;}
        [Required]
        public int  USERID {get;set;}
        public int  CreatedBy {get;set;}
        public DateTime  CreatedOn {get;set;}
        public string  Remarks {get;set;}
        public int? Status { get;set;}
        public DateTime? ApproveOn { get;set;}
        public string ApproveRemarks { get;set;}

    }
}