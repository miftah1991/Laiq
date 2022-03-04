using Laiq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    public class StudentController : MYController
    {
        public ApplicationDbContext context = new ApplicationDbContext();
        public Student stud = new Student();

        //[AttributeUsage(AttributeTargets.Class)]
        //public class ValidateAntiForgeryTokenOnAllPosts : AuthorizeAttribute
        //{
        //    public override void OnAuthorization(AuthorizationContext filterContext)
        //    {
        //        var request = filterContext.HttpContext.Request;

        //        //  Only validate POSTs
        //        if (request.HttpMethod == WebRequestMethods.Http.Post)
        //        {
        //            //  Ajax POSTs and normal form posts have to be treated differently when it comes
        //            //  to validating the AntiForgeryToken
        //            if (request.IsAjaxRequest())
        //            {
        //                var antiForgeryCookie = request.Cookies[AntiForgeryConfig.CookieName];

        //                var cookieValue = antiForgeryCookie != null
        //                    ? antiForgeryCookie.Value
        //                    : null;

        //                AntiForgery.Validate(cookieValue, request.Headers["__RequestVerificationToken"]);
        //            }
        //            else
        //            {
        //                new ValidateAntiForgeryTokenAttribute()
        //                    .OnAuthorization(filterContext);
        //            }
        //        }
        //    }
        //}

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //POST: Student
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterStudent(Student student)
        {
            return Json(student.Email);

            if (!ModelState.IsValid)
            {
                return View(new { result = "Error" });
            }
            stud.FirstName = student.FirstName;
            stud.LastName = student.LastName;
            stud.Phone = student.Phone;
            stud.Email = student.Email;
            context.Student.Add(student);
            if (context.SaveChanges() > 0)
            {
                return Json(new { result = "Success" });
            };

            return View();
        }
    }
}