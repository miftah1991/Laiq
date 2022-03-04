using Laiq.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    public class PackController : Controller
    {
        ApplicationDbContext db;
        Email EM = new Email();
        public PackController()
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
            var data = db.Package.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create(Package gd)
        {
            if (ModelState.IsValid)
            {
                gd.CreatedOn = DateTime.Now;
                db.Package.Add(gd);
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
        public ActionResult Edit(Package gd)
        {
            if (ModelState.IsValid)
            {
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
        [HttpPost]
        public ActionResult AssignApplicantToPack(PackageApplicants pa)
        {

            if (ModelState.IsValid)
            {
                int Count = db.Database.SqlQuery<int>("SELECT COUNT(*) FROM PackageApplicants WHERE LApplicantID={0}", pa.LApplicantID).Single();
                if (Count > 0)
                {
                    var data = db.PackageApplicants.Where(e => e.LApplicantID == pa.LApplicantID).Single();
                    data.PackID = pa.PackID;
                    data.Remarks = pa.Remarks;
                    pa.CreatedBy = Convert.ToInt32(Session["USERID"]);
                    pa.CreatedOn = DateTime.Now;
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json("true");
                }
                else
                {
                    pa.CreatedBy = Convert.ToInt32(Session["USERID"]);
                    pa.CreatedOn = DateTime.Now;
                    db.PackageApplicants.Add(pa);
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
    }
}