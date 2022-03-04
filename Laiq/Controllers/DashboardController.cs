using Laiq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    [Authorize]
    public class DashboardController :MYController
    {
        ApplicationDbContext db;
        Email EM = new Email();
        public DashboardController()
        {

            db = new ApplicationDbContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            int TotalApplicants = db.Database.SqlQuery<int>("SELECT COUNT(*) TotalApplicants FROM VWApplicants").Single();
            ViewBag.TotalApplicants = TotalApplicants;
            ViewBag.Percents = db.Database.SqlQuery<int>("SELECT ((COUNT(*))*100)/10000 Percents  FROM VWApplicants").Single();
            int Male = db.Database.SqlQuery<int>("SELECT COUNT(*) Male FROM VWApplicants WHERE Gender = 'M'").Single();
            ViewBag.Male = Male;
            int Female = db.Database.SqlQuery<int>("SELECT COUNT(*) Female FROM VWApplicants WHERE Gender = 'F'").Single();
            ViewBag.Female = Female;
            ViewBag.MalePercent = db.Database.SqlQuery<decimal>("SELECT CAST(100*CAST(sum(case when gender = 'M' then 1 else 0 end) AS decimal(18,2))/count(*) AS decimal(18,2)) FROM VWApplicants").Single();
            ViewBag.FemalePercent = db.Database.SqlQuery<decimal>("SELECT CAST(100*CAST(sum(case when gender = 'F' then 1 else 0 end) AS decimal(18,2))/count(*) AS decimal(18,2)) FROM VWApplicants").Single();
            ViewBag.PhdPercent = db.Database.SqlQuery<decimal>("SELECT CAST(100*CAST(sum(case when QualificationID = 1 then 1 else 0 end) AS decimal(18,2))/count(*) AS decimal(18,2)) FROM VWApplicants").Single();
            ViewBag.MasterPercent = db.Database.SqlQuery<decimal>("SELECT CAST(100*CAST(sum(case when QualificationID = 2 then 1 else 0 end) AS decimal(18,2))/count(*) AS decimal(18,2)) FROM VWApplicants").Single();
            ViewBag.BachelorPercent = db.Database.SqlQuery<decimal>("SELECT CAST(100*CAST(sum(case when QualificationID = 3 then 1 else 0 end) AS decimal(18,2))/count(*) AS decimal(18,2)) FROM VWApplicants").Single();
            ViewBag.Phd = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Phd FROM VWApplicants WHERE QualificationID = 1").Single();
            ViewBag.Master = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Master FROM VWApplicants WHERE QualificationID = 2").Single();
            ViewBag.Bachlor = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Bachelor FROM VWApplicants WHERE QualificationID = 3").Single();
            ViewBag.ToDay = db.Database.SqlQuery<int>("SELECT  COUNT(*) Counts FROM VWApplicants WHERE CAST(CreatedOn AS date) = CAST(GETDATE() AS date)").Single();
            ViewBag.ThisWeek = db.Database.SqlQuery<int>("SELECT  Count(*) Counts FROM VWApplicants WHERE DATEDIFF(DAY,CAST(CreatedOn AS date),CAST(GETDATE() AS date)) <=7").Single();
            ViewBag.ThisMonth = db.Database.SqlQuery<int>("SELECT  Count(*) Counts FROM VWApplicants WHERE DATEDIFF(DAY,CAST(CreatedOn AS date),CAST(GETDATE() AS date)) <=30").Single();

            return View();
        }
        public ActionResult GetChartForExpYear()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetByExpYear").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartForEFMasterEXPYear10()
        {
            var data = db.Database.SqlQuery<ReportsVM>(@"EXEC GetChartForEFMasterEXPYear10").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartForGenderMasterEXPYear10()
        {
            var data = db.Database.SqlQuery<ReportsVM>(@"EXEC GetChartForGenderMasterEXPYear10").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartForEduLocMasterEXPYear10()
        {
            var data = db.Database.SqlQuery<ReportsVM>(@"EXEC GetChartForEduLocMasterEXPYear10").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartForEduLocGenderMasterEXPYear10()
        {
            var data = db.Database.SqlQuery<ReportsGnderVM>(@"EXEC GetChartForEduLocGenderMasterEXPYear10").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartByExpLevel()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetByExpLevel").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByTeam()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetByTeam").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPhoneByTeam()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetPhoneByTeam").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PendingApplicantsForPhoneInterview()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec PendingApplicantsForPhoneInterview").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByTeamDataPhone(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantPhoneInterViewVM>(@"EXEC GetByTeamDataPhone {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByTeamCategory()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetByTeamCategory").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartByExpStaff()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetByExpStaff").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartByAgeGroup()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetByAgeGroup").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartByQArea()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetByQArea").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartByEFName()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetByEFName").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetChartByExcellentSoftSkill()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec ExcellentSoftSkill").ToList();
            return Json(data, JsonRequestBehavior.AllowGet); 
        }
        public ActionResult GetChartByLocation()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GETBYLocation").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAll()
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetAll").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByGender(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByGender {0}",Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByQualification(int Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByQualification {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByEFMoreThan10()
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByQualification").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByExpYearData(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByExpYearData {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByExpLevelData(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByExpLevelData {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByExpStaffData(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByExpStaffData {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByLocationData(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByLocationData {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByAgeData(string Age)
        {
            int m, y;
            if (Age == "Less than 18")
            {
                m = 0; y = 17;
            }
            else if (Age == "More than 65")
            {
                m = 66; y = 100;
            }
            else
            {
                string[] Agge = Age.Split('-');
                m = Convert.ToInt32(Agge[0]);
                y = Convert.ToInt32(Agge[1]);
            }
            var data = db.Database.SqlQuery<ApplicantsVM>(@"exec ReportAgeApplicants {0},{1}", m, y);
            var JSONDATA = Json(data, JsonRequestBehavior.AllowGet);
            JSONDATA.MaxJsonLength = int.MaxValue;
            return JSONDATA;
        }
        public ActionResult GetByQAreaData(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByQAreaData {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByEFData(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByEFData {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult GetByExcellentSoftSkillData(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByExcellentSoftSkillData {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByTeamData(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantsVM>(@"EXEC GetByTeamData {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}