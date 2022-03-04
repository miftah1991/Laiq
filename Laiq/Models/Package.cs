using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("Package")]
    public class Package
    {
        [Key]
        public int PackID {get;set;}
        public string PackName {get;set;}
        public DateTime CreatedOn { get; set; }
        public string Remarks {get;set;}
    }
}