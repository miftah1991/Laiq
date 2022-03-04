using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zDistrict")]
    public class District
    {
        [Key]
        public int DISID { get; set; }
        public int PRID { get; set; }
        [Required]
        public string DISName { get; set; }
        public string Remarks { get; set; }
        public Province Province { get; set; }
    }
}