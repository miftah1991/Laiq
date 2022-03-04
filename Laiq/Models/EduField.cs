using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zEduField")]

    public class EduField
    {
        [Key]
        public int EFID { get; set; }
        [Required]
        [MinLength(3)]
        public string EFName { get; set; }
    }
}