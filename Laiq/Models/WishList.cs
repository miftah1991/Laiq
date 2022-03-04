using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("WishList")]
    public class WishList
    {
        [Key]
        public int WLID {get;set;}
        public int LApplicantID {get;set;}
        public int USERID {get;set;}
        public string Location {get;set;}
        public string Category {get;set;}
        public DateTime? CreatedOn { get; set; }
    }
}