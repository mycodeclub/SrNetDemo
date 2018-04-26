using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SrNetDemo.Models;

namespace SrNetDemo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        private string validImageFormets = @"bmp, jpg, jpeg, gif, png";
        // GET: Home

        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Home/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View(new Employee());
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        [AllowAnonymous]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Email,Password,ConfirmPassword,gender,Dob,Mobile,ResumeUrl,ResumeUpload,IsPhysicallyChallenged,Country,city,Address")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(employee.ResumeUrl) || (employee.ResumeUpload != null && employee.ResumeUpload.ContentLength > 0))
                {
                    if ((employee.ResumeUpload != null || employee.ResumeUpload.ContentLength > 0) && validImageFormets.Contains(employee.ResumeUpload.FileName.Split('.').Last()))
                    {
                        SaveImage(employee);
                    }
                    else
                    {
                        ModelState.AddModelError("ResumeUpload", "Upload your resume in a valid image format, allowed formats are : " + validImageFormets);
                        return View(employee);
                    }
                }
                else
                {
                    ModelState.AddModelError("ResumeUpload", "This field is required");
                    return View(employee);
                }
                db.Employees.Add(employee);
                if (employee.EmployeeId > 0)
                    db.Entry(employee).State = EntityState.Modified;
                var x = db.SaveChanges();
                if (x > 0) ViewBag.Message = "Data Save Successfully";
                else ViewBag.Message = string.Empty;
            }
            return View(employee);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            employee.ConfirmPassword = employee.Password;
            return View("Create", employee);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Email,Password,gender,Dob,Mobile,ResumeUrl,IsPhysicallyChallenged,Country,city,Address")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void SaveImage(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.ResumeUrl) && employee.ResumeUpload == null || employee.ResumeUpload.ContentLength == 0)
                ModelState.AddModelError("ResumeUpload", "Please Upload your picture");
            else if (!validImageFormets.Contains(employee.ResumeUpload.FileName.Split('.').Last())) ModelState.AddModelError("ResumeUpload", "Upload a valid image, allowed formats are : " + validImageFormets);
            else
            {
                var fileName = DateTime.UtcNow.ToString().Replace(" ", string.Empty).Replace(":", string.Empty).Replace("/", string.Empty) + employee.ResumeUpload.FileName.Replace(" ", string.Empty);
                employee.ResumeUrl = @"\images\" + fileName;
                employee.ResumeUpload.SaveAs(Server.MapPath("~/images/" + fileName));
            }
        }
    }
}
