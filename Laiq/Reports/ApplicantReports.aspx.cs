using Laiq.Models;
using Laiq.ViewModel;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laiq.Reports
{
    public partial class ApplicantReports : System.Web.UI.Page
    {
        private ApplicationDbContext  db = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ApplicantID = Convert.ToInt32(Request.QueryString["ApplicantID"]);
                var data = db.Database.SqlQuery<ApplicantVM>(@"SELECT * FROM LaiqApplicants WHERE LApplicantID = {0}", ApplicantID).ToList();
                ApplicantRV.SizeToReportContent = true;
                ApplicantRV.LocalReport.ReportPath = Server.MapPath("ApplicantReports.rdlc");
                ReportDataSource ds = new ReportDataSource("ApplicantD", data);
                ApplicantRV.LocalReport.DataSources.Add(ds);
                ApplicantRV.LocalReport.Refresh();

            }
        }
    }
}