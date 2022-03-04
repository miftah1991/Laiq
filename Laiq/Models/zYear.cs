using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zYear")]
    public class zYear
    {
        [Key]
        public int YID { get; set; }
        public int Year { get; set; }

    }
}