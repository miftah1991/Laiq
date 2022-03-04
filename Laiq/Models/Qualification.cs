using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zQualification")]
    public class Qualification
    {
        [Key]
        public int QualificationID { get; set; }
        [Required]
        public string QualificationName { get; set; }
        public string QualificationNameEn { get; set; }
       // public ICollection<USEREducation> USEREducation { get; set; }
             
    }
}