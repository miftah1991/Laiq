using Laiq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    public class AppRecruitedController : Controller
    {
        ApplicationDbContext db;
        Email EM = new Email();
        public AppRecruitedController()
        {

            db = new ApplicationDbContext();
            //db.ConfigureUsername(() => User.Identity.Name);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}