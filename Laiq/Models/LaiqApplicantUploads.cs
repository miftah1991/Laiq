using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Laiq.Models
{
    [Table("LaiqApplicantUploads")]
    public class LaiqApplicantUploads
    {
        [Key]
        public int LAppUploadID {get;set;}
        public int LApplicantID {get;set;}
        public string Docs {get;set;}
        public DateTime? CreatedOn {get;set;}
        public string FileTypeID { get; set; }
        public Guid UploadEncodeID { get; set; }
    }
    public class LaiqApplicantUploadsVM
    {
        public int LAppUploadID { get; set; }
        public int LApplicantID { get; set; }
        public string Docs { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string FileTypeID { get; set; }
        public string UploadEncodeID { get; set; }
    }
}