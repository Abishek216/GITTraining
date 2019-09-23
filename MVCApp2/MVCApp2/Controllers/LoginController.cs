using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCApp2.Auth;
using MVCApp2.Models;

namespace MVCApp2.Controllers
{
    [ClearCache]
    
    public class LoginController : Controller
    {
        private MovieContext db = new MovieContext();
        

        // GET: Login
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.mapping);
            return View(users.ToList());
            
        }

        // GET: Login/Details/5
        
       [MyAuthentication]
        public ActionResult Details(int? id)
        {
            var us = db.Users.Include(u => u.mapping).Include(u=>u.mapping.Role).ToList();
            var user = us.Find(u => u.mapping.UserId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //User user = db.Users.Find(id);
            
            if (us == null)
            {
                return HttpNotFound();
            }
            if (Session["id"].ToString() == id.ToString())
            {
                return View(user);
            }
            else
            {
                return View("Authorisation_Failed");
            }
        }

        // GET: Login/Create
        [MyAuthentication]
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserRoleMappings, "UserId", "UserId");
            return View();
        }

        // POST: Login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthentication]
        public ActionResult Create([Bind(Include = "UserId,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Create","Mappings");
            }

            ViewBag.UserId = new SelectList(db.UserRoleMappings, "UserId", "UserId", user.UserId);
            return View(user);
        }

        // GET: Login/Edit/5
        [MyAuthentication]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserRoleMappings, "UserId", "UserId", user.UserId);
            return View(user);
        }
        public ActionResult Login()
        {

            return View();


        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAuthentication]
        public ActionResult Edit([Bind(Include = "UserId,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Create","Mappings");
            }
            ViewBag.UserId = new SelectList(db.UserRoleMappings, "UserId", "UserId", user.UserId);
            return View(user);
        }

        // GET: Login/Delete/5
        [MyAuthentication]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [MyAuthentication]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ClearCache]
        public ActionResult Login(User user)
        {
          
            User find = db.Users.Include(m => m.mapping).Include(m=>m.mapping.Role).ToList().Find(u => u.UserName == user.UserName && u.Password == user.Password);
            if (find != null)
            {
                Session["sessionval"] = Guid.NewGuid();
                Session["role"] = find.mapping.Role.RoleName;
                Session["user"] = find.UserName;
                Session["id"] = find.UserId;
               
                
                FormsAuthentication.SetAuthCookie(find.UserName, true); 
 

                return RedirectToAction("Index", "Movies");
            }
            else
            {
                return Redirect("error");
            }
           // return View();


        }
        public ActionResult error()
        {
            return View();
        }
        [ClearCache]
        public ActionResult Logout()
        {
            Session["sessionval"] = null;
            return RedirectToAction("Login", "Login");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
