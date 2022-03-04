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
    public class PhoneInterviewController : Controller
    {
        ApplicationDbContext db;
        Email EM = new Email();
        public PhoneInterviewController()
        {

            db = new ApplicationDbContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetMyApplicants()
        {
            int USERID = Convert.ToInt32(Session["USERID"]);
            if(User.IsInRole("SuperAdmin"))
            {
                var data = db.Database.SqlQuery<ApplicantVM>("exec GetMyApplicantsAll").ToList();
                var jsondata = Json(data, JsonRequestBehavior.AllowGet);
                jsondata.MaxJsonLength = int.MaxValue;
                return jsondata;
            }else
            {
                var data = db.Database.SqlQuery<ApplicantVM>("exec GetMyApplicants {0}", USERID).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            
        }
        public ActionResult SavePhoneInterview(PhoneInterview ph)
        {
            if (ModelState.IsValid)
            {
                int Counts = db.Database.SqlQuery<int>("SELECT COUNT(*) Counts FROM PhoneInterview WHERE LApplicantID = {0}", ph.LApplicantID).Single();
                if (Counts > 0)
                {
                    return Json("This Application Already Interviewed");
                }
                else
                {
                    PhoneInterview P = new PhoneInterview();
                    P.LApplicantID = ph.LApplicantID;
                    P.USERID = ph.USERID;
                    P.Rmarks = ph.Rmarks;
                    P.PersonalityType = ph.PersonalityType;
                    P.MgmtStyle = ph.MgmtStyle;
                    P.CreatedOn = ph.CreatedOn;
                    P.NextStep = ph.NextStep;
                    P.ExpectedPosition = ph.ExpectedPosition;
                    P.CreatedOn = DateTime.Now;
                    db.PhoneInterview.Add(P);
                    db.SaveChanges();
                    int NID = P.PIntID;
                    foreach(var d in ph.PhoneInterviewDetail)
                    {
                        PhoneInterviewDetail pd = new PhoneInterviewDetail();
                        pd.PIntID = NID;
                        pd.QuestionID = d.QuestionID;
                        pd.Marks = d.Marks;
                        db.PhoneInterviewDetail.Add(pd);
                  
                    }
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
        public ActionResult PhoneInterviewed()
        {
            return View();
        }
        public ActionResult GetMyApplicantsInterviewed()
        {
            int USERID = Convert.ToInt32(Session["USERID"]);
            if (!User.IsInRole("Admin"))
            {
                var data = db.Database.SqlQuery<ApplicantInterviewedVM>("exec GetMyApplicantsInterviewed {0}", USERID).ToList();
                var jsondata = Json(data, JsonRequestBehavior.AllowGet);
                jsondata.MaxJsonLength = int.MaxValue;
                return jsondata; 

            }
            else
            {
                var data = db.Database.SqlQuery<ApplicantInterviewedVM>("exec GetMyApplicantsInterviewedAdmin").ToList();
                var jsondata =Json(data, JsonRequestBehavior.AllowGet);
                jsondata.MaxJsonLength = int.MaxValue;
                return jsondata;
            }
           
        }
        public ActionResult GetApplicantAnswers(int Id)
        {
            var data = db.Database.SqlQuery<PhoneInterviewDetail>("EXEC GetPhoneInterviewDetail {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PhoneStatistics()
        {
            return View();
        }
        public ActionResult GetPhoneByTeam()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetPhoneByTeam").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPhoneByTeamToday()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetPhoneByTeamToday").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPhoneByNextStep()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetPhoneByNextStep").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetByExpectedPosition()
        {
            var data = db.Database.SqlQuery<ReportsVM>("exec GetByExpectedPosition").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}