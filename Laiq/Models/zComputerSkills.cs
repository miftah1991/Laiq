using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("zComputerSkills")]
    public class zComputerSkills
    {
        [Key]
        public int CSID { get; set; }
        public string CompSkill { get; set; }
        public string CompSkillEn { get; set; }
    }
}