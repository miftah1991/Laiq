using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Laiq.Controllers
{
    public class SessionTimeoutAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if (ctx.Request.Cookies["Email"].Value == null)
            {


                filterContext.Result = new RedirectResult("/Account/Login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}