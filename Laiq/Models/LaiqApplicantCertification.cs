using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("LaiqApplicantCertification")]
    public class LaiqApplicantCertification
    {
        [Key]
        public int ACID { get; set; }
        public int? LApplicantID { get; set; }
        public int? CerID { get; set; }
    }
}