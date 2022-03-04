using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zCertification")]
    public class zCertification
    {
        [Key]
        public int CerID { get; set; }
        public string CerName { get; set; }
        public string CerNameEn { get; set; }
    }
}