using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laiq.ViewModel
{
    public class GroupPanelVM
    {
        public int GDPanID {get;set;}
        public int GDID {get;set;}
        public int USERID {get;set;}
        public int CreatedBy {get;set;}
        public DateTime? CreatedOn {get;set;}
        public string Remarks {get;set;}
        public string GDName {get;set;}
        public DateTime? GDDate { get;set;}
        public string PanelName { get;set;}
        public string Position { get;set; }
    }
}