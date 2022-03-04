using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zProvince")]
    public class Province
    {
        [Key]
        public int PRID { get; set; }
        [Required]
        public string PRName { get; set; }
        public string Remarks { get; set; }
        public ICollection<District> District { get; set; }

    }
}