using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("GroupDiscResult")]
    public class GroupDiscResult
    {
        [Key]
        public int  GRID {get;set;}
        public int  LApplicantID {get;set;}
        public int  USERID {get;set;}
        public int  Communication {get;set;}
        public int  Creativity {get;set;}
        public int  Leadership {get;set;}
        public int  English {get;set;}
        public int  Dari {get;set;}
        public int  Pashto {get;set;}
        public string  Remarks {get;set;}
        public DateTime? CreatedOn { get; set; }
    }
}