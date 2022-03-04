using Laiq.Models;
using Laiq.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    [Authorize]
    public class ReportController : MYController
    {
        ApplicationDbContext db;
        Email EM = new Email();
        public ReportController()
        {

            db = new ApplicationDbContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult GetAll()
        {
            var dataUSERS = db.Database.SqlQuery<USERSVM>(@"SELECT Name,USERID from AspNetUsers WHERE GroupID is not null ORDER BY GroupID").ToList();
            ViewBag.dataUSERS = Json(dataUSERS);
            return View();
        }
        public ActionResult GetAllData()
        {
            var data = db.Database.SqlQuery<ApplicantVM>("EXEC GetLaiqAPP").ToList();
            var JsonResult = Json(data, JsonRequestBehavior.AllowGet);
            JsonResult.MaxJsonLength = int.MaxValue;
            return JsonResult;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetApplicantJobDetail(int Id)
        {
            var data = db.Database.SqlQuery<ApplicantsJobDetailVM>("exec getAppJobDetail {0}", Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewProfile(string Id)
        {
            var data = db.Database.SqlQuery<ApplicantProfileVM>("exec GetLaiqOne {0}", Id).Single();
            ViewBag.Certifications = db.Database.SqlQuery<string>(@"
SELECT dbo.GROUP_CONCAT(CerName) CerName FROM LaiqApplicantCertification LAC
LEFT JOIN zCertification C ON C.CerID = LAC.CerID
WHERE LApplicantID = {0}",data.LApplicantID).Single();
            string Photo = "DABS.png";
            try
            {
                Photo = db.Database.SqlQuery<string>(@"SELECT TOP 1 Docs FROM LaiqApplicantUploads
WHERE FileTypeID = 'Photo' AND LApplicantID = {0}", data.LApplicantID).Single();
            }
            catch
            {

            }
             ViewBag.Photo = Photo;
            string Assign;
            var dataAssign = db.Database.SqlQuery<ApplicantCategory>("select * from ApplicantCategory WHERE LApplicantID = {0}", data.LApplicantID).ToList();
            if(dataAssign.Count > 0)
            {
                Assign = "Already Assigned";
            }
            else
            {
                Assign = "Pending";
            }
            ViewBag.Assign = Assign;
            //var data = db.LaiqApplicants.Where(e => e.EncodeID.ToString() == Id).Single();

            return View(data);
        }
        public ActionResult GetApplicantEducation(int Id)
        {
            var data = db.Database.SqlQuery<AppEduVM>("exec getAPPEdu {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAppLang(int Id)
        {
            var data = db.Database.SqlQuery<AppLangVM>("exec GetAppLang {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAppSoftSkill(int Id)
        {
            var data = db.Database.SqlQuery<AppSoftVM>("exec GETAppSoftSkills {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAppCompSkill(int Id)
        {
            var data = db.Database.SqlQuery<AppCompSkillVM>("exec GETAppCompSkill {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AssignApplicant(ApplicantCategory ap)
        {
            if(ModelState.IsValid)
            {
                int Counts = db.Database.SqlQuery<int>("SELECT COUNT(*) Counts FROM ApplicantCategory WHERE LApplicantID = {0}", ap.LApplicantID).Single();
                if(Counts > 0)
                {
                    return Json("This Application Already Assigned");
                }
                else
                {
                    ap.CreatedOn = DateTime.Now;
                    db.ApplicantCategory.Add(ap);
                    db.SaveChanges();
                    return Json("true");
                }
               
            }
            else
            {
                string validationErrors = string.Join("<br /> ",
                       ModelState.Values.Where(E => E.Errors.Count > 0)
                                        .SelectMany(E => E.Errors)
                                        .Select(E => E.ErrorMessage)
                                      .ToArray());

                return Content(validationErrors, "text/html");
            }
        }
        public ActionResult MyApplicants()
        {
            return View();
        }
        public ActionResult LaiqStatistics()
        {
            ViewBag.Total = db.Database.SqlQuery<int>("SELECT COUNT(*) TotalApplicants FROM VWApplicants").Single();
            ViewBag.Male = db.Database.SqlQuery<int>("SELECT COUNT(*) Male FROM VWApplicants WHERE Gender = 'M'").Single();
            ViewBag.Female = db.Database.SqlQuery<int>("SELECT COUNT(*) Female FROM VWApplicants WHERE Gender = 'F'").Single();
            ViewBag.PhD = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Phd FROM VWApplicants WHERE QualificationID = 1").Single();
            ViewBag.PhdMale = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Phd FROM VWApplicants WHERE QualificationID = 1 AND Gender = 'M'").Single();
            ViewBag.PhdFemale = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Phd FROM VWApplicants WHERE QualificationID = 1 AND Gender = 'F'").Single();
            ViewBag.Masters = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Master FROM VWApplicants WHERE QualificationID = 2").Single();
            ViewBag.MastersMale = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Master FROM VWApplicants WHERE QualificationID = 2 AND Gender = 'M'").Single();
            ViewBag.MastersFemale = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Master FROM VWApplicants WHERE QualificationID = 2 AND Gender = 'F'").Single();
            ViewBag.Bachlor = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Bachelor FROM VWApplicants WHERE QualificationID = 3").Single();
            ViewBag.BachlorMale = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Bachelor FROM VWApplicants WHERE QualificationID = 3 AND Gender = 'M'").Single();
            ViewBag.BachlorFemale = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Bachelor FROM VWApplicants WHERE QualificationID = 3 AND Gender = 'F'").Single();

            ViewBag.MoreThan10 = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 9").Single();
            ViewBag.MoreThan10Male = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 9 AND Gender = 'M'").Single();
            ViewBag.MoreThan10Female = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 9 AND Gender = 'F'").Single();
            ViewBag.MoreThan10Phd = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 9 AND QualificationID = 1").Single();
            ViewBag.MoreThan10Master = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 9 AND QualificationID = 2").Single();
            ViewBag.MoreThan10Bachlor = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 9 AND QualificationID = 3").Single();

            ViewBag.MoreThan5 = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 8").Single();
            ViewBag.MoreThan5Male = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 8 AND Gender = 'M'").Single();
            ViewBag.MoreThan5Female = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 8 AND Gender = 'F'").Single();
            ViewBag.MoreThan5Phd = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 8 AND QualificationID = 1").Single();
            ViewBag.MoreThan5Master = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 8 AND QualificationID = 2").Single();
            ViewBag.MoreThan5Bachlor = db.Database.SqlQuery<int>(@"SELECT  COUNT(*) Counts  FROM VWApplicants WHERE ExpYearID = 8 AND QualificationID = 3").Single();
            //Phone Interview
            ViewBag.PhoneInterview = db.Database.SqlQuery<int>(@"SELECT Count(*) Counts FROM PhoneInterview").Single();
            ViewBag.PhoneNexGroup = db.Database.SqlQuery<int>(@"SELECT Count(*) Counts FROM PhoneInterview WHERE NextStep = 'GroupDiscussion'").Single();
            ViewBag.PhoneFail = db.Database.SqlQuery<int>(@"SELECT Count(*) Counts FROM PhoneInterview WHERE NextStep = 'Fail'").Single();
            ViewBag.PhoneFake = db.Database.SqlQuery<int>(@"SELECT Count(*) Counts FROM PhoneInterview WHERE NextStep = 'Fake'").Single();
            ViewBag.PhoneMale = db.Database.SqlQuery<int>(@"
            SELECT Count(*) Counts FROM PhoneInterview P
            INNER JOIN VWApplicants A ON A.LApplicantID = P.LApplicantID
            WHERE A.Gender = 'M'").Single();
            ViewBag.PhoneFemale = db.Database.SqlQuery<int>(@"
            SELECT Count(*) Counts FROM PhoneInterview P
            INNER JOIN VWApplicants A ON A.LApplicantID = P.LApplicantID
            WHERE A.Gender = 'F'").Single();
            ViewBag.PhonePhd = db.Database.SqlQuery<int>(@"
            SELECT Count(*) Counts FROM PhoneInterview P
            INNER JOIN VWApplicants A ON A.LApplicantID = P.LApplicantID
            WHERE A.QualificationID = 1").Single();
            ViewBag.PhoneMaster = db.Database.SqlQuery<int>(@"
            SELECT Count(*) Counts FROM PhoneInterview P
            INNER JOIN VWApplicants A ON A.LApplicantID = P.LApplicantID
            WHERE A.QualificationID = 2").Single();
            ViewBag.PhoneBachelor = db.Database.SqlQuery<int>(@"
            SELECT Count(*) Counts FROM PhoneInterview P
            INNER JOIN VWApplicants A ON A.LApplicantID = P.LApplicantID
            WHERE A.QualificationID = 3").Single();
            
            //Group
            ViewBag.Group = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupApplicants WHERE GDID NOT IN (4,7)").Single();
            ViewBag.Top = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupDisCategory WHERE CategoryID = 'Top'").Single();
            ViewBag.Deputy = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupDisCategory WHERE CategoryID = 'Deputy'").Single();
            ViewBag.GeneralStaff = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupDisCategory WHERE CategoryID = 'GeneralStaff'").Single();
            ViewBag.NotQualified = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupDisCategory WHERE CategoryID = 'NotQualified'").Single();
            ViewBag.Internal = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupDisCategory WHERE CategoryID = 'Internal'").Single();
            ViewBag.Absent = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupApplicants WHERE GDID =4").Single();
            //ViewBag.Absent = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupApplicants WHERE GDID =4");
            ViewBag.NotInterested = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupApplicants WHERE GDID =7").Single();

            ViewBag.GroupMale = db.Database.SqlQuery<int>(@"
SELECT COUNT(*) Counts FROM GroupApplicants GA
INNER JOIN VWApplicants A ON A.LApplicantID = GA.LApplicantID
WHERE A.Gender = 'M'").Single();
            ViewBag.GroupFemale = db.Database.SqlQuery<int>(@"
SELECT COUNT(*) Counts FROM GroupApplicants GA
INNER JOIN VWApplicants A ON A.LApplicantID = GA.LApplicantID
WHERE A.Gender = 'F'").Single();
            ViewBag.GroupPhd = db.Database.SqlQuery<int>(@"
SELECT COUNT(*) Counts FROM GroupApplicants GA
INNER JOIN VWApplicants A ON A.LApplicantID = GA.LApplicantID
WHERE A.QualificationID =1").Single();
            ViewBag.GropuMaster = db.Database.SqlQuery<int>(@"
SELECT COUNT(*) Counts FROM GroupApplicants GA
INNER JOIN VWApplicants A ON A.LApplicantID = GA.LApplicantID
WHERE A.QualificationID =2").Single();
            ViewBag.GroupBachelor = db.Database.SqlQuery<int>(@"
SELECT COUNT(*) Counts FROM GroupApplicants GA
INNER JOIN VWApplicants A ON A.LApplicantID = GA.LApplicantID
WHERE A.QualificationID =3").Single();

            return View();
        }
        
    }
}