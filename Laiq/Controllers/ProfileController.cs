using Laiq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    public class ProfileController : MYController
    {
        ApplicationDbContext db;
        Email EM = new Email();
        public ProfileController()
        {

            db = new ApplicationDbContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            var YearList = db.Database.SqlQuery<zYear>("select * from zYear where YID > 81 order by year desc");
            ViewBag.YearList = Json(YearList);
            var LangLevel = db.Database.SqlQuery<zLangLevel>("GetLangLevel {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.zLangLevel = new SelectList(LangLevel, "LLID", "LangLevel");
            var LanguageList = db.Database.SqlQuery<Language>("GetLang {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.zLang = Json(LanguageList);
            ViewBag.LangLevel = Json(LangLevel);
            var EduFieldlist = db.Database.SqlQuery<EduField>("exec GetEduField {0}", Request.Cookies["culture"].Value);
            //ViewBag.EduField = new SelectList(EduFieldlist, "EFID", "EFName");
            var QualificationList = db.Database.SqlQuery<Qualification>("exec GetQualification {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.Qualification = new SelectList(QualificationList, "QualificationID", "QualificationName");
            ViewBag.QualificationList = Json(QualificationList);
            ViewBag.EduFieldlist = Json(EduFieldlist);
            var CountryList = db.Database.SqlQuery<zCountry>("exec GetCountry {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.CountryList = Json(CountryList);
            var QAreaList = db.Database.SqlQuery<zQualificationArea>("exec GetQualificationArea {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.QAreaList = Json(QAreaList);

            var ExpYearList = db.Database.SqlQuery<zExpYear>("exec GetExpYear {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.ExpYear = new SelectList(ExpYearList, "ExpYearID", "ExpYear");
            var ExpLevelList = db.Database.SqlQuery<zExpLevel>("exec GetExpLevel {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.ExpLevel = new SelectList(ExpLevelList, "ExpLevID", "ExpLevel");
            var ExpStaffList = db.Database.SqlQuery<zExpStaff>("exec GetExpStaff {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.ExpStaff = new SelectList(ExpStaffList, "ExpStaffID", "ExpStaff");
            var SkillsList = db.Database.SqlQuery<zSkills>("exec GetSkill {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.Skills = new SelectList(SkillsList, "SkillID", "SkillName");
            var CompSkillsList = db.Database.SqlQuery<zComputerSkills>("exec GetCompSkill {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.CompSkills = Json(CompSkillsList);
            var Certifications = db.zCertification.ToList();
            ViewBag.Certifications = Json(Certifications); //new SelectList(Certifications, "CerID", "CerName");
            var DurationList = db.Database.SqlQuery<zDuration>("exec GetDuration {0}", Request.Cookies["culture"].Value).ToList();
            ViewBag.DurationList = Json(DurationList);

            return View();
        }
        public ActionResult GetProvince()
        {
            var data = db.Database.SqlQuery<Province>("exec GetProvince {0}", Request.Cookies["culture"].Value);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDistrict(int Id)
        {
            var data = db.Database.SqlQuery<District>(@"exec GetDistrict {0},{1}", Request.Cookies["culture"].Value, Id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LaiqPostData(LaiqApplicants LA)
        {
            if (ModelState.IsValid)
            {
                int Counts = db.Database.SqlQuery<int>(@"SELECT count(*) Counts FROM LaiqApplicants WHERE Email = {0}", LA.Email).Single();
                if(Counts>0)
                {
                    return Json("Email is Already Registered");
                }
                var transaction = db.Database.BeginTransaction();
                try
                {
                    LaiqApplicants l = new LaiqApplicants();
                    l.EncodeID = Guid.NewGuid();
                    l.Name = LA.Name;
                    l.LName = LA.LName;
                    l.NIDNumber = LA.NIDNumber;
                    l.Gender = LA.Gender;
                    l.Mobile = LA.Mobile;
                    l.Mobile2 = LA.Mobile2;
                    l.Email = LA.Email;
                    l.DOBYear = LA.DOBYear;
                    l.DOBMonth = LA.DOBMonth;
                    l.DOBDay = LA.DOBDay;
                    l.AddressCountryID = LA.AddressCountryID;
                    l.PPRID = LA.PPRID;
                    l.PDISID = LA.PDISID;
                    l.City = LA.City;
                    l.Street = LA.Street;
                    l.NAddressCountryID = LA.AddressCountryID;
                    l.NPRID = LA.NPRID;
                    l.NDISID = LA.NDISID;
                    l.NCity = LA.NCity;
                    l.WorkExp = LA.WorkExp;
                    l.ExpYearID = LA.ExpYearID;
                    l.ExpLevlID = LA.ExpLevlID;
                    l.ExpStaffID = LA.ExpStaffID;
                    l.HighSalary = LA.HighSalary;
                    l.ExpectedSalary = LA.ExpectedSalary;
                    l.CreatedOn = DateTime.Now;
                    l.IPAddress = Request.UserHostAddress;
                    db.LaiqApplicants.Add(l);
                    db.SaveChanges();
                    int NewID = l.LApplicantID;
                    foreach (var d in LA.LaiqApplicantEdu)
                    {
                        LaiqApplicantEdu LAE = new LaiqApplicantEdu();
                        LAE.LApplicantID = NewID;
                        LAE.QualificationID = d.QualificationID;
                        LAE.QAID = d.QAID;
                        LAE.EFID = d.EFID;
                        LAE.EducationField = d.EducationField;
                        LAE.University = d.University;
                        LAE.CountryID = d.CountryID;
                        LAE.GraduationYear = d.GraduationYear;
                        db.LaiqApplicantEdu.Add(LAE);
                        db.SaveChanges();
                    }
                    foreach (var d in LA.LaiqApplicantLang)
                    {

                        LaiqApplicantLang LAL = new LaiqApplicantLang();
                        LAL.LApplicantID = NewID;
                        LAL.LangID = d.LangID;
                        LAL.SpeakingID = d.SpeakingID;
                        LAL.ReadingID = d.ReadingID;
                        LAL.WritingID = d.WritingID;
                        if (ModelState.IsValid)
                        {
                            db.LaiqApplicantLang.Add(LAL);
                            db.SaveChanges();
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
                    foreach (var d in LA.LaiqApplicantSoftSkils)
                    {
                        LaiqApplicantSoftSkils LASS = new LaiqApplicantSoftSkils();
                        LASS.LApplicantID = NewID;
                        LASS.SkillsID = d.SkillsID;
                        LASS.RatingID = d.RatingID;
                        db.LaiqApplicantSoftSkils.Add(LASS);
                        db.SaveChanges();
                    }
                    foreach (var d in LA.LaiqApplicantCompSkills)
                    {
                        LaiqApplicantCompSkills LASS = new LaiqApplicantCompSkills();
                        LASS.LApplicantID = NewID;
                        LASS.CSID = d.CSID;
                        LASS.CSValue = d.CSValue;
                        db.LaiqApplicantCompSkills.Add(LASS);
                        db.SaveChanges();
                    }
                    if (LA.LaiqApplicantCertification !=null)
                    {
                        foreach (var d in LA.LaiqApplicantCertification)
                        {
                            if(d.CerID >0)
                            {
                                LaiqApplicantCertification LASS = new LaiqApplicantCertification();
                                LASS.LApplicantID = NewID;
                                LASS.CerID = d.CerID;
                                db.LaiqApplicantCertification.Add(LASS);
                                db.SaveChanges();
                            }
                           
                        }
                    }
                    if (LA.ApplicantJobDetail != null)
                    {
                        foreach (var d in LA.ApplicantJobDetail)
                        {
                            if (d.ZDID > 0)
                            {
                                ApplicantJobDetail LASS = new ApplicantJobDetail();
                                LASS.LApplicantID = NewID;
                                LASS.JobTitle = d.JobTitle;
                                LASS.Organization = d.Organization;
                                LASS.ZDID = d.ZDID;
                                db.ApplicantJobDetail.Add(LASS);
                                db.SaveChanges();
                            }

                        }
                    }
                    transaction.Commit();
                    SendEmail(LA.Email, l.EncodeID.ToString());
                    return Json(new { Type = "Success", EncodedID = l.EncodeID });
                }
                catch (Exception exp)
                {
                    transaction.Rollback();
                    if (exp.InnerException.InnerException == null)
                    {
                        return Content(exp.InnerException.Message.ToString(), "text/html");
                    }
                    else
                    {
                        return Content(exp.InnerException.InnerException.Message.ToString(), "text/html");
                    }
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
        public ActionResult LaiqApplicantUploadDocuments(string Id)
        {
            ViewBag.EncodeID = Id;
            return View();
        }
        public ActionResult LaiqAppUploadDoc(string Id)
        {
            int data = db.Database.SqlQuery<int>("SELECT count(*) Counts FROM LaiqApplicants WHERE EncodeID = {0}", Id).Single();
            if(data >0)
            {
                ViewBag.EncodeID = Id;
                return View();
            }
            else
            {
                ViewBag.EncodeID = 0;
                return View("AppNotFound");
            }
                
        }
        public ActionResult AppNotFound()
        {
            return View();
        }


        public ActionResult CompleteAppProfile()
        {
            return View();
        }
        public ActionResult GetUploads(string Id)
        {
            int LApplicantID = db.Database.SqlQuery<int>(@"SELECT LApplicantID FROM LaiqApplicants WHERE EncodeID ={0}", Id).Single();
            var data = db.Database.SqlQuery<LaiqApplicantUploadsVM>("SELECT * FROM LaiqApplicantUploads WHERE LApplicantID={0}", LApplicantID).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LaiqUpload(HttpPostedFileBase file)
        {
            string imagename = "";
            var fileName = "";
            if (file != null)
            {
                string EncodedID = Request.Form["EncodeID"];
                string FileTypeID = Request.Form["FileTypeID"];
                int LApplicantID = db.Database.SqlQuery<int>(@"SELECT LApplicantID FROM LaiqApplicants WHERE EncodeID ={0}", EncodedID).Single();
                var data = db.Database.SqlQuery<LaiqApplicantUploadsVM>(@"SELECT * FROM LaiqApplicantUploads WHERE LApplicantID = {0} AND FileTypeID ={1}", LApplicantID, FileTypeID).ToList();
                if (data.Count > 0)
                {
                    return Json("Already Uploaded");
                }
                int byteCount = file.ContentLength;
                imagename = System.IO.Path.GetFileName(file.FileName);
                string imageExtention = System.IO.Path.GetExtension(file.FileName);
                if(imageExtention ==".exe" || imageExtention == ".EXE" || imageExtention == ".bat" || imageExtention == ".BAT" || imageExtention == ".dll")
                {
                    return Json("wrongimageformat");
                }
                if(FileTypeID == "Photo" && imageExtention != ".jpg" && imageExtention != ".JPG" && imageExtention != ".png" && imageExtention != ".PNG" && imageExtention != ".jpeg" && imageExtention != ".JPEG" )
                {
                    return Json("wrongimageformat");
                }
                if (FileTypeID == "CV" && imageExtention != ".PDF" && imageExtention != ".pdf" && imageExtention != ".doc" && imageExtention != ".docx" && imageExtention != ".DOC")
                {
                    return Json("wrongimageformat");
                }
                    string TimeStamp = DateTime.Now.ToString("yyyMMddHmmss");
                    string CompletePath = TimeStamp + imagename;
                    fileName = CompletePath.Replace(" ", "_");
                    string physicalpath = Server.MapPath("/Uploads/Laiq/" + fileName);
                    //save image in folder
                    file.SaveAs(physicalpath);
                
                    if (ModelState.IsValid)
                    {
                        try
                        {
                            LaiqApplicantUploads LAU = new LaiqApplicantUploads();
                            LAU.LApplicantID = LApplicantID;
                            LAU.Docs = fileName;
                            LAU.CreatedOn = DateTime.Now;
                            LAU.FileTypeID = FileTypeID;
                            LAU.UploadEncodeID = Guid.NewGuid();
                            db.LaiqApplicantUploads.Add(LAU);
                            db.SaveChanges();
                            return Json("true");
                        }
                        catch (Exception exp)
                        {
                            if (exp.InnerException.InnerException == null)
                            {
                                return Content(exp.InnerException.Message.ToString(), "text/html");
                            }
                            else
                            {
                                return Content(exp.InnerException.InnerException.Message.ToString(), "text/html");
                            }
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
            else
            {
                return Json("nofile");
            }
        }
        [HttpPost]
        public ActionResult DeleteApplicantFile(string Id)
        {
            try
            {
                int LAppUploadID = db.Database.SqlQuery<int>(@"SELECT LAppUploadID FROM LaiqApplicantUploads WHERE UploadEncodeID = {0}", Id).Single();
                db.Database.ExecuteSqlCommand("DELETE FROM LaiqApplicantUploads WHERE LAppUploadID= {0}", LAppUploadID);
                //var data = db.LaiqApplicantUploads.Find(LAppUploadID);
                //db.LaiqApplicantUploads.Remove(data);
                //db.SaveChanges();
                return Json("true");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
        public ActionResult Succcess()
        {
            return View();
        }
        public ActionResult CompleteProfile(LaiqQuestionary LQ)
        {
            string EncodeID = Request.Form["EncodeID"];
            int LApplicantID = db.Database.SqlQuery<int>(@"SELECT LApplicantID FROM LaiqApplicants WHERE EncodeID = {0}", EncodeID).Single();
            LQ.LApplicantID = LApplicantID;
            if (ModelState.IsValid)
            {
                try
                {
                    db.LaiqQuestionary.Add(LQ);
                    db.SaveChanges();
                    return Json("true");
                }
                catch(Exception ex)
                {
                    return Json(ex.Message);
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

        public void SendEmail(string emailAddress,string EncodedID)
        {
            //string Title = db.Database.SqlQuery<string>(@"SELECT PositionTitle FROM REC.VWJobsPR WHERE JobID = {0}", AP.JobID).Single();
            string message = "<h3 align='left'>Dear Applicants</h3><br>";
            message += "<p dir ='ltr'>Thank you for participating in LAIQ program. Hereby, we confirm that we received your application. LAIQ team will review your application, and will further notify you as far as the screening process is completed.";
            message += "</p><br>";
            message += string.Format("<br><h4 align='left'>Your LAIQ registration number is: {0}</h4>", EncodedID);
            message += "<p>Sincerely yours</p><br>";
            message += "<br><h3 align='left'>";
            message += "<br>";
            message += "LaiQ Team";
            message += "<br>";
            message += "</h3><br>";
            try
            {
                EM.SendEmail("hr@dabs.af", emailAddress + ",miftah.a@dabs.af", "Laiq Confirmation Email", message, "hrd@dabs.af");
            }
            catch
            {
                
            }
        }


    }
}