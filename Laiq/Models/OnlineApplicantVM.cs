using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    public class OnlineApplicantVM
    {
        [Key]
        public int ApplicantID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string GFName { get; set; }
        [Required]
        public string NIDNumber { get; set; }
        [Required]
        public int? DOBYear { get; set; }
        [Required]
        public int? DOBMonth { get; set; }
        [Required (ErrorMessage ="DOB Day is requireds")]
        public int? DOBDay { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Mobile2 { get; set; }
    }
}