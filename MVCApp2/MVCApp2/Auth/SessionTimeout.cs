using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp2.Auth
{
    public class SessionTimeout: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["sessionval"]==null)
            {
                filterContext.Result = new RedirectResult("~/Login/Login");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}