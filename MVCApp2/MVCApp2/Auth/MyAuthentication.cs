using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVCApp2.Auth
{
    public class MyAuthentication: ActionFilterAttribute, IAuthenticationFilter

    {
        public void OnAuthentication(AuthenticationContext filterContext)

        {
            //var test = filterContext.HttpContext.Session["sessionval"].ToString();

            if (filterContext.HttpContext.Session["sessionval"] == null)

            {

                filterContext.Result = new HttpUnauthorizedResult();

            }

        }



        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)

        {
            //var test = filterContext.HttpContext.Session["sessionval"].ToString();

            if (filterContext.HttpContext.Session["sessionval"] == null)

            {

                filterContext.Result = new HttpUnauthorizedResult();

            }
        }
    }
}