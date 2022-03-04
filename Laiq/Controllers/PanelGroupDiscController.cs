using Laiq.Models;
using Laiq.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    //[Authorize]
    public class PanelGroupDiscController : Controller
    {
        // GET: PanelGroupDisc
        ApplicationDbContext db;
        Email EM = new Email();
        public PanelGroupDiscController()
        {

            db = new ApplicationDbContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            int USERID = Convert.ToInt32(Session["USERID"]);
            var dataApplicants = db.Database.SqlQuery<ApplicantShorVM>("exec GetUSERAssignApplicants {0}", USERID);
            ViewBag.dataApplicants = Json(dataApplicants);
            var data = db.Database.SqlQuery<GroupsVM>(@"GetPanelGroups {0}", USERID).ToList();
            ViewBag.Groups = Json(data);
            return View();
        }
        [HttpPost]
        public ActionResult SavePanelMarks(GroupDiscResult GDR)
        {
            int Counts = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupDiscResult WHERE USERID = {0} AND LApplicantID = {1}", GDR.USERID, GDR.LApplicantID).Single();
            if(Counts >0)
            {
                int GRID = db.Database.SqlQuery<int>(@"SELECT GRID FROM GroupDiscResult WHERE USERID = {0} AND LApplicantID = {1}", GDR.USERID, GDR.LApplicantID).Single();
                var data = db.GroupDiscResult.Find(GRID);
                data.Communication = GDR.Communication;
                data.Creativity = GDR.Creativity;
                data.Leadership = GDR.Leadership;
                data.English = GDR.English;
                data.Dari = GDR.Dari;
                data.Pashto = GDR.Pashto;
                data.Remarks = GDR.Remarks;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return Json("true");
            }
            if (ModelState.IsValid)
            {
                GDR.CreatedOn = DateTime.Now;
                db.GroupDiscResult.Add(GDR);
                db.SaveChanges();
                return Json("true");
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
        public ActionResult GetPanlMarksByGroupAndUSERID(int Id)
        {
            int USERID = Convert.ToInt32(Session["USERID"]);
            var jsondata = new
            {
                data = db.Database.SqlQuery<GroupDiscResultVM>("exec GetGroupDiscResultByUSERID {0},{1}", USERID, Id)
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);


        }
        //public ActionResult PrintMarkSheet(int GDID,int USERID, string format)
        //{
        //    var data = db.Database.SqlQuery<GroupDiscResultVM>(@"EXEC GetGroupDiscResultByUSERID {0},{1}", USERID, GDID).ToList();
        //    string PanelName = db.Database.SqlQuery<string>("SELECT Name FROM AspNetUsers WHERE USERID = {0}",USERID).Single();
        //    DateTime CDate = db.Database.SqlQuery<DateTime>("SELECT GETDate() CDate ").Single();
        //    ReportParameter[] paras = new ReportParameter[2];
        //    paras[0] = new ReportParameter("PanelName", PanelName);
        //    paras[1] = new ReportParameter("CDate",Convert.ToString(CDate));
        //    LocalReport lr = new LocalReport();
        //    string path = Path.Combine(Server.MapPath("/Reports"), "MarkSheet.rdlc");
        //    lr.ReportPath = path;
        //    ReportDataSource rd = new ReportDataSource("MarksDSET", data);
        //    lr.DataSources.Add(rd);
        //    lr.SetParameters(paras);
        //    lr.Refresh();

        //    string reportType = format;
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;
        //    string deviceInfo = "";
        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;
        //    renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);
        //    return File(renderedBytes, mimeType);
        //}
        public ActionResult GetPanlMarksByGroupAndUSERIDOffline(int GID,int USERID)
        {
            var jsondata = new
            {
                data = db.Database.SqlQuery<GroupDiscResultVM>("exec GetGroupDiscResultByUSERID {0},{1}", USERID, GID)
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SubmitPanelMarks(int GroupID,int USERID)
        {
            try
            {
                int GroupApplicants = db.Database.SqlQuery<int>(@"SELECT COUNT(*) Counts FROM GroupApplicants WHERE GDID = {0}", GroupID).Single();
                int MaredCounts = db.Database.SqlQuery<int>("exec GetUSERMarked {0},{1}",USERID,GroupID).Single();
                if(GroupApplicants >MaredCounts)
                {
                    return Json("Applicants marks is missing, Please Give Marks to All Applicants");
                }
                int GDPanID = db.Database.SqlQuery<int>("SELECT GDPanID FROM GroupPanel WHERE GDID = {0} AND USERID = {1}", GroupID,USERID).Single();
                var data = db.GroupPanel.Find(GDPanID);
                data.Status = 1;
                data.ApproveOn = DateTime.Now;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return Json("true");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public ActionResult OfflineInterview()
        {
            var dataUSERS = db.Database.SqlQuery<USERSVM>(@"exec getPanelUSERS").ToList();
            ViewBag.dataUSERS = Json(dataUSERS);
            var data = db.Database.SqlQuery<GroupsVM>(@"SELECT GDID,CONCAT(GDName,'-',CAST(GDDate AS date)) GDName FROM GroupDiscussion").ToList();
            ViewBag.Groups = Json(data);
            return View();
        }
       
        public ActionResult GetApplicantByUserID(int Id)
        {
            var dataApplicants = db.Database.SqlQuery<ApplicantShorVM>("exec GetUSERAssignApplicants {0}", Id);
            return Json(dataApplicants, JsonRequestBehavior.AllowGet);
        }
        public ActionResult OfflineInterViewNew()
        {
            //var dataUSERS = db.Database.SqlQuery<USERSVM>(@"exec getPanelUSERS").ToList();
            //ViewBag.dataUSERS = Json(dataUSERS);
            var data = db.Database.SqlQuery<GroupsVM>(@"SELECT GDID,CONCAT(GDName,'-',CAST(GDDate AS date)) GDName FROM GroupDiscussion").ToList();
            ViewBag.Groups = Json(data);
            return View();
        }
        public ActionResult GetGroupPanel(int Id)
        {
            var data = db.Database.SqlQuery<USERSVM>(@"
                    SELECT GP.USERID,CONCAT(Name,' ',AU.Position) Name FROM GroupPanel GP 
                    LEFT JOIN AspNetUsers AU ON AU.USERID = GP.USERID
                    WHERE GDID = {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult PrintCV(int Id)
        //{
        //    string format = "PDF";
        //    var data = db.Database.SqlQuery<AppCVVM>(@"EXEC spGetApp {0}", Id).ToList();

        //    var data1 = db.Database.SqlQuery<AppLangVM>(@"EXEC GetAppLang {0}", Id).ToList();
        //    var data2 = db.Database.SqlQuery<AppSoftVM>(@"EXEC GETAppSoftSkills {0}", Id).ToList();
        //    var data3 = db.Database.SqlQuery<AppCompSkillVM>(@"EXEC GETAppCompSkill {0}", Id).ToList();
        //    var data4 = db.Database.SqlQuery<AppCVMarksAVGVM>(@"EXEC AppCVMarksAVG {0}", Id).ToList();
        //    var data5 = db.Database.SqlQuery<GroupDisCategoryVM>(@"EXEC GetGroupDisCategory {0}", Id).ToList();
        //    string Photo = db.Database.SqlQuery<string>("SELECT ISNULL(MAX(Docs),0) Photo FROM LaiqApplicantUploads WHERE FileTypeID = 'Photo' AND LApplicantID = {0}",Id).Single();
        //    string FilePath;
        //    if (Photo == "0")
        //    {
        //        FilePath = new Uri(Server.MapPath("~/Uploads/Emp/DABS.png")).AbsoluteUri;
        //    }
        //    else
        //    {
        //        FilePath = new Uri(Server.MapPath("~/Uploads/Laiq/" + Photo)).AbsoluteUri;
        //    }
        //    //DateTime CDate = db.Database.SqlQuery<DateTime>("SELECT GETDate() CDate ").Single();
        //    ReportParameter[] paras = new ReportParameter[2];
        //    int MinQual = db.Database.SqlQuery<int>("SELECT MIN(QualificationID) FROM LaiqApplicantEdu WHERE LApplicantID = {0}",Id).Single();
        //    paras[0] = new ReportParameter("ImageParameter", FilePath);
        //    paras[1] = new ReportParameter("MinQual", Convert.ToString(MinQual));
        //    LocalReport lr = new LocalReport();
        //    string path = Path.Combine(Server.MapPath("/Reports"), "AppCV.rdlc");
        //    lr.ReportPath = path;
        //    ReportDataSource rd = new ReportDataSource("AppCVDSET", data);

        //    ReportDataSource rd1 = new ReportDataSource("Lang", data1);
        //    ReportDataSource rd2 = new ReportDataSource("Soft", data2);
        //    ReportDataSource rd3 = new ReportDataSource("Comp", data3);
        //    ReportDataSource rd4 = new ReportDataSource("Marks", data4);
        //    ReportDataSource rd5 = new ReportDataSource("GrCate", data5);

        //    lr.DataSources.Add(rd);
        //    lr.DataSources.Add(rd1);
        //    lr.DataSources.Add(rd2);
        //    lr.DataSources.Add(rd3);
        //    lr.DataSources.Add(rd4);
        //    lr.DataSources.Add(rd5);
        //    lr.EnableExternalImages = true;
        //    lr.SetParameters(paras);
        //    lr.Refresh();

        //    string reportType = format;
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;
        //    string deviceInfo = "";
        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;
        //    renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);
        //    return File(renderedBytes, mimeType);
        //}
        //public ActionResult PrintCVPending(int Id)
        //{
        //    string format = "PDF";
        //    var data = db.Database.SqlQuery<AppCVVM>(@"EXEC spGetApp {0}", Id).ToList();

        //    var data1 = db.Database.SqlQuery<AppLangVM>(@"EXEC GetAppLang {0}", Id).ToList();
        //    var data2 = db.Database.SqlQuery<AppSoftVM>(@"EXEC GETAppSoftSkills {0}", Id).ToList();
        //    var data3 = db.Database.SqlQuery<AppCompSkillVM>(@"EXEC GETAppCompSkill {0}", Id).ToList();
        //    var data4 = db.Database.SqlQuery<AppCVMarksAVGVM>(@"EXEC AppCVMarksAVG {0}", Id).ToList();
        //    var data5 = db.Database.SqlQuery<GroupDisCategoryVM>(@"EXEC GetGroupDisCategory {0}", Id).ToList();
        //    string Photo = db.Database.SqlQuery<string>("SELECT ISNULL(MAX(Docs),0) Photo FROM LaiqApplicantUploads WHERE FileTypeID = 'Photo' AND LApplicantID = {0}", Id).Single();
        //    string FilePath;
        //    if (Photo == "0")
        //    {
        //        FilePath = new Uri(Server.MapPath("~/Uploads/Emp/DABS.png")).AbsoluteUri;
        //    }
        //    else
        //    {
        //        FilePath = new Uri(Server.MapPath("~/Uploads/Laiq/" + Photo)).AbsoluteUri;
        //    }
        //    //DateTime CDate = db.Database.SqlQuery<DateTime>("SELECT GETDate() CDate ").Single();
        //    ReportParameter[] paras = new ReportParameter[2];
        //    int MinQual = db.Database.SqlQuery<int>("SELECT MIN(QualificationID) FROM LaiqApplicantEdu WHERE LApplicantID = {0}", Id).Single();
        //    paras[0] = new ReportParameter("ImageParameter", FilePath);
        //    paras[1] = new ReportParameter("MinQual", Convert.ToString(MinQual));
        //    LocalReport lr = new LocalReport();
        //    string path = Path.Combine(Server.MapPath("/Reports"), "AppCV1.rdlc");
        //    lr.ReportPath = path;
        //    ReportDataSource rd = new ReportDataSource("AppCVDSET", data);

        //    ReportDataSource rd1 = new ReportDataSource("Lang", data1);
        //    ReportDataSource rd2 = new ReportDataSource("Soft", data2);
        //    ReportDataSource rd3 = new ReportDataSource("Comp", data3);
        //    ReportDataSource rd4 = new ReportDataSource("Marks", data4);
        //    ReportDataSource rd5 = new ReportDataSource("GrCate", data5);

        //    lr.DataSources.Add(rd);
        //    lr.DataSources.Add(rd1);
        //    lr.DataSources.Add(rd2);
        //    lr.DataSources.Add(rd3);
        //    lr.DataSources.Add(rd4);
        //    lr.DataSources.Add(rd5);
        //    lr.EnableExternalImages = true;
        //    lr.SetParameters(paras);
        //    lr.Refresh();

        //    string reportType = format;
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;
        //    string deviceInfo = "";
        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;
        //    renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);
        //    return File(renderedBytes, mimeType);
        //}
        //public ActionResult PrintSample()
        //{
        //    string format = "PDF";
        //    var data = db.Database.SqlQuery<AppCVVM>(@"EXEC spGetApp {0}", 3).ToList();
        //    LocalReport lr = new LocalReport();
        //    string path = Path.Combine(Server.MapPath("/Reports"), "MainReport.rdlc");
        //    lr.ReportPath = path;
        //    ReportDataSource rd = new ReportDataSource("Applicant_DS", data);
        //    lr.DataSources.Add(rd);
        //    lr.EnableExternalImages = true;
        //    lr.Refresh();
        //    string reportType = format;
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;
        //    string deviceInfo = "";
        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;
        //    renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);
        //    return File(renderedBytes, mimeType);
        //}
    }
}