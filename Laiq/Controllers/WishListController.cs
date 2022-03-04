using Laiq.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    [Authorize(Roles ="WishList")]
    public class WishListController : Controller
    {
        ApplicationDbContext db;
        Email EM = new Email();
        public WishListController()
        {

            db = new ApplicationDbContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(WishList WL)
        {
            int Check = db.Database.SqlQuery<int>("SELECT COUNT(*) Counts FROM WishList WHERE LApplicantID = {0}", WL.LApplicantID).Single();
            if(Check >0)
            {
                return Json("Already Assigned");
            }
            if (ModelState.IsValid)
            {
                WL.USERID = Convert.ToInt32(Session["USERID"]);
                WL.CreatedOn = DateTime.Now;
                db.WishList.Add(WL);
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

        public ActionResult GetWishListData()
        {
            int USERID = Convert.ToInt32(Session["USERID"]);
            var data = db.Database.SqlQuery<WishListVM>("exec GetMyWishList {0}", USERID);
            var jsondata= Json(data, JsonRequestBehavior.AllowGet);
            jsondata.MaxJsonLength = int.MaxValue;
            return jsondata;
        }
        public ActionResult Edit(WishList WL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(WL).State = EntityState.Modified;
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

    }
}