using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("LaiqQuestionary")]
    public class LaiqQuestionary
    {
        [Key]
        public int LQID {get;set;}
        public int LApplicantID {get;set;}
        public string GovShare {get;set;}
        public string PhotoShare {get;set;}
        public string VideoShare {get;set;}
        public string DBCVSave {get;set;}
        public string Feedbk { get;set;}
        

    }
}