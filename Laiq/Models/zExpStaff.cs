using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zExpStaff")]
    public class zExpStaff
    {
        [Key]
        public int ExpStaffID { get; set; }
        public string ExpStaff { get; set; }
        public string ExpStaffEn { get; set; }
    }
}