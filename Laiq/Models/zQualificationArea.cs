using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zQualificationArea")]
    public class zQualificationArea
    {
        [Key]
        public int QAID { get; set; }
        public string QArea { get; set; }
        public string QAreaEn { get; set; }
    }
}