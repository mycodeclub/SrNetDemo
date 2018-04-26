using SrNetDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SrNetDemo.Controllers
{
    public class LoginController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login/Create  
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Login([Bind(Include = "userName,Password")] LoginCredential login)
        {
            var user = db.Logins.Where(l => l.UserName == login.UserName && l.Password == login.Password).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(login.UserName, false);        // Session[""  db.Login.Any(l => l.userName == login.userName && l.Password == login.Password);
                return RedirectToAction("Index", "Home");
            }
            else { ModelState.AddModelError("Password", "Invalid User Name or Password"); }
            return View(login);
        }
    }
}