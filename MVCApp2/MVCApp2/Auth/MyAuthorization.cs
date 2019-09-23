using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVCApp2.Auth
{
    public class MyAuthorization: AuthorizeAttribute
    {
        private string role;
        private string view;
        public List<string> roles = new List<string>();
        public MyAuthorization(string role)
        {
            this.role = role;
            roles.Add(role);
            view = "Authorisation_Failed";

        }
        public MyAuthorization(string[] role)
        {
            roles =role.ToList();
            
            view = "Authorisation_Failed";

        }
        public MyAuthorization()
        {
            role = "Admin";
            view = "Authorisation_Failed";

        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if(roles.Contains(filterContext.HttpContext.Session["role"].ToString()))
            {
                return;
            }
            else
            {
                var vr = new ViewResult();
                vr.ViewName = view;
                filterContext.Result = vr;
            }
        }
    }
}