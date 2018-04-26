using SrNetDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SrNetDemo.App_Start
{
    public class CustomAuth : AuthorizeAttribute
    {
        private MyDbContext db = new MyDbContext();
        private bool LocalAllowed { get; set; }
        public string UserRole { get; set; }
        public CustomAuth(bool allowed)
        {

            LocalAllowed = allowed;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = db.Logins.Where(li => li.UserName == "" && li.Password == "").FirstOrDefault();
            var isAuthorize = base.AuthorizeCore(httpContext);
            if (!isAuthorize) return false;
            string currentUserRole = "Admin";
            return UserRole.Contains(currentUserRole);




            //if (httpContext.Request.IsLocal)
            //    return localAllowed;
            //else return true;
        }
    }
}