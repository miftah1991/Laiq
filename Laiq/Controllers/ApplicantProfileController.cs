using Laiq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    public class ApplicantProfileController : Controller
    {
        ApplicationDbContext db;
        Email EM = new Email();
        public ApplicantProfileController()
        {

            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

    }
}