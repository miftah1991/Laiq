using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("PhoneInterviewDetail")]
    public class PhoneInterviewDetail
    {
        [Key]
        public int PIDID { get; set; }
        [Required]
        public int PIntID { get; set; }
        [Required]
        public int QuestionID { get; set; }
        [Required]
        public int Marks { get; set; }
    }
}