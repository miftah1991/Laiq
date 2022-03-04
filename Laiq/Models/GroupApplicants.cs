using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("GroupApplicants")]
    public class GroupApplicants
    {
        [Key]
        public int GPAID  {get;set;}
        public int LApplicantID  {get;set;}
        public int GDID  {get;set;}
        public string Remarks  {get;set;}
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}