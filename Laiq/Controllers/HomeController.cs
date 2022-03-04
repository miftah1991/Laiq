using Laiq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    public class HomeController : MYController
    {
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult ChangeLanguage(string lang)
        {
            new LanguageManager().SetLanguage(lang);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Laiq()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult CEOMessage()
        {
            return View();
        }
        
        public ActionResult HRMessage()
        {
            return View();
        }
    }
}