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
    [Authorize]
    public class GroupDisController : Controller
    {
        ApplicationDbContext db;
        Email EM = new Email();
        public GroupDisController()
        {

            db = new ApplicationDbContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Groups()
        {
            return View();
        }
        public ActionResult GetGroups()
        {
            var data = db.GroupDiscussion.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create(GroupDiscussion gd)
        {
            if(ModelState.IsValid)
            {
                gd.CreatedBy = Convert.ToInt32(Session["USERID"]);
                gd.CreatedOn = DateTime.Now;
                db.GroupDiscussion.Add(gd);
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
        public ActionResult Edit(GroupDiscussion gd)
        {
            if (ModelState.IsValid)
            {
                gd.CreatedBy = Convert.ToInt32(Session["USERID"]);
                gd.CreatedOn = DateTime.Now;
                db.Entry(gd).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Updated");
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
        public ActionResult PendingForGroup()
        {
            var data = db.Database.SqlQuery<GroupsVM>(@"SELECT GDID,CONCAT(GDName,'-',CAST(GDDate AS date)) GDName FROM GroupDiscussion").ToList();
            ViewBag.Groups = Json(data);
            return View();
        }
        public ActionResult GetPendingForGroupData()
        {
            var data = db.Database.SqlQuery<ApplicantInterviewedVM>("exec GetPendingForGroupData").ToList();
            var jsonData = Json(data, JsonRequestBehavior.AllowGet);
            jsonData.MaxJsonLength = int.MaxValue;
            return jsonData;
        }
        [HttpPost]
        public ActionResult AssignApplicantToGroup(GroupApplicants ga)
        {
            if (ModelState.IsValid)
            {
                ga.CreatedBy = Convert.ToInt32(Session["USERID"]);
                ga.CreatedOn = DateTime.Now;
                db.GroupApplicants.Add(ga);
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
        [HttpPost]
        public ActionResult ChangeApplicantGroup(GroupApplicants ga)
        {
            if (ModelState.IsValid)
            {
                //var data = db.GroupApplicants.Where(e => e.LApplicantID == ga.LApplicantID);
                var data = db.Database.SqlQuery<GroupApplicants>(@"SELECT * FROM GroupApplicants WHERE LApplicantID = {0}", ga.LApplicantID).Single();
                data.GDID = ga.GDID;
                data.Remarks = ga.Remarks;
                db.Entry(data).State = EntityState.Modified;
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
        public ActionResult GroupPanel()
        {
            var data = db.Database.SqlQuery<GroupsVM>(@"SELECT GDID,CONCAT(GDName,'-',CAST(GDDate AS date)) GDName FROM GroupDiscussion").ToList();
            ViewBag.Groups = Json(data);
            var dataUSERS = db.Database.SqlQuery<USERSVM>(@"exec getPanelUSERS").ToList();
            ViewBag.dataUSERS = Json(dataUSERS);
            return View();
        }
        public ActionResult GetGroupPanelData(int Id)
        {
            var data = db.Database.SqlQuery<GroupPanelVM>(@"exec GetGroupDiscussion {0}", Id).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult DeleteGroupPanel(int Id)
        {
            try
            {
                var data = db.GroupPanel.Find(Id);
                db.GroupPanel.Remove(data);
                db.SaveChanges();
                return Json("true");
            }catch(Exception ex)
            {
                return Json(ex.Message);
            }
           
               
        }
        [HttpPost]
        public ActionResult SaveGroupPanel(GroupDiscussion gd)
        {
            if (ModelState.IsValid)
            {
                int GDID = gd.GDID;
                foreach(var d in gd.GroupPanel)
                {
                    GroupPanel gp = new GroupPanel();
                    gp.GDID = GDID;
                    gp.USERID = d.USERID;
                    gp.CreatedBy = Convert.ToInt32(Session["USERID"]);
                    gp.CreatedOn = DateTime.Now;
                    db.GroupPanel.Add(gp);
                }
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
        public ActionResult AssignedInGroups()
        {
            var data = db.Database.SqlQuery<GroupsVM>(@"SELECT GDID,CONCAT(GDName,'-',CAST(GDDate AS date)) GDName FROM GroupDiscussion").ToList();
            ViewBag.Groups = Json(data);
            return View();
        }
        public ActionResult GetAssignedInGroupsData( int Id)
        {
            if(Id==0)
            {
                var data = db.Database.SqlQuery<ApplicantInGroupVM>("exec GetAssignedInGroupsDataALL").ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.Database.SqlQuery<ApplicantInGroupVM>("exec GetAssignedInGroupsData {0}", Id).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
           
        }
        public ActionResult GroupDiscussionResult()
        {
            var data = db.Database.SqlQuery<GroupsVM>(@"SELECT GDID,CONCAT(GDName,'-',CAST(GDDate AS date)) GDName FROM GroupDiscussion").ToList();
            ViewBag.Groups = Json(data);
            return View();
        }
        public ActionResult GetGroupDiscussionResultData(int Id)
        {
            var data = db.Database.SqlQuery<GroupDiscussion>("exec CheckGroupCompleted {0}", Id).ToList();
            if (data.Count>0)
            {
                var jsondata = new
                {
                    data = db.Database.SqlQuery<GroupDiscAvgVM>("exec GetAppMarksAVG {0}", Id)
                };
                return Json(jsondata, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("There is Pending record for panel marking");
            }
            
        }
        public ActionResult GetApplicantAllPanelMarking(int Id)
        {
            var jsondata = new
            {
                data = db.Database.SqlQuery<GroupAllPanelMarks>("exec GetApplicantAllPanelMarking {0}", Id)
            };
            return Json(jsondata, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateGroupDisCategory(GroupDisCategory gc)
        {
            if (ModelState.IsValid)
            {
                int Counts = db.Database.SqlQuery<int>("SELECT COUNT(*) Counts FROM GroupDisCategory WHERE LApplicantID= {0}", gc.LApplicantID).Single();
                if(Counts >0)
                {
                    return Json("Already Assigned in Category");
                }

                gc.CreatedBy = Convert.ToInt32(Session["USERID"]);
                gc.CreatedOn = DateTime.Now;
                db.GroupDisCategory.Add(gc);
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
        public ActionResult GroupDiscussionCategory()
        {
            var data = db.Package.ToList();
            ViewBag.Packages = Json(data);
            return View();
        }
        [HttpPost]
        public ActionResult SaveHiredApp(ApplicantRecruited applicantRecruited)
        {
            if (ModelState.IsValid)
            {
                int Counts = db.Database.SqlQuery<int>("SELECT COUNT(*) Counts FROM ApplicantRecruited WHERE LApplicantID= {0}", applicantRecruited.LApplicantID).Single();
                if (Counts > 0)
                {
                    return Json("Already Hired");
                }

                applicantRecruited.CreatedBy = Convert.ToInt32(Session["USERID"]);
                applicantRecruited.CreatedOn = DateTime.Now;
                db.ApplicantRecruited.Add(applicantRecruited);
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
        public ActionResult SaveHiredAppEdit(ApplicantRecruited applicantRecruited)
        {
            if (ModelState.IsValid)
            {
                var data = db.ApplicantRecruited.Find(applicantRecruited.ARID);
                data.Organization = applicantRecruited.Organization;
                data.Division = applicantRecruited.Division;
                data.Department = applicantRecruited.Department;
                data.Position = applicantRecruited.Position;
                data.Salary = applicantRecruited.Salary;
                data.JoinDate = applicantRecruited.JoinDate;
                data.PositionLevel = applicantRecruited.PositionLevel;
                data.Remarks = applicantRecruited.Remarks;

                applicantRecruited.CreatedBy = Convert.ToInt32(Session["USERID"]);
                applicantRecruited.CreatedOn = DateTime.Now;
                db.Entry(data).State = EntityState.Modified;
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
        public ActionResult GroupResult()
        {
            var data = db.Database.SqlQuery<GroupDiscResultCategoryVM>("exec GroupResult").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetHired()
        {
            var data = db.Database.SqlQuery<GroupDiscResultCategoryVM>("exec GetHired").ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult HiredStaff()
        {
            return View();
        }
        public ActionResult GetSingleHired(int Id)
        {
            var data = db.ApplicantRecruited.Find(Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult PrintAttSheet(int Id, string format)
        //{
        //    var data = db.Database.SqlQuery<ApplicantInterviewedVM>(@"EXEC GetAssignedInGroupsData {0}", Id).ToList();
           
        //    //ReportParameter[] paras = new ReportParameter[3];
        //    //paras[0] = new ReportParameter("JobTitle", PositionTitle);
        //    //paras[1] = new ReportParameter("VacancyNumber", VacancyNumber);
        //    //paras[2] = new ReportParameter("PrepareBy", PrepareBy);
        //    LocalReport lr = new LocalReport();
        //    string path = Path.Combine(Server.MapPath("/Reports"), "AttSheet.rdlc");
        //    lr.ReportPath = path;
        //    ReportDataSource rd = new ReportDataSource("ApplicantLongListDSET", data);
        //    lr.DataSources.Add(rd);
        //    //lr.SetParameters(paras);
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