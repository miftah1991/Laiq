using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zSkills")]
    public class zSkills
    {
        [Key]
        public int SkillID { get; set; }
        [Required]
        public string SkillName { get; set; }
        public string SkillNameEn { get; set; }
    }
}