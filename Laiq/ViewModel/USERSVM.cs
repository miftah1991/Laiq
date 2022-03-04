using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laiq.ViewModel
{
    public class USERSVM
    {

        public int USERID { get; set; }
        public string Name { get; set; }
    }
    public class ApplicantShorVM
    {
        public int LApplicantID { get; set; }
        public string Name { get; set; }
    }
    public class ApplicantsJobDetailVM
    {
        public int AJDID { get; set; }
        public string JobTitle    {get;set;}
        public string Organization{get;set;}
        public int ZDID        {get;set;}
        public string DurNameEn   {get;set;}
        public int LApplicantID {get;set;}
    }
}