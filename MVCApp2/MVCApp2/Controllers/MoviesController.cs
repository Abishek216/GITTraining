using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCApp2.Auth;
using MVCApp2.Models;

namespace MVCApp2.Controllers
{
    [SessionTimeout]
    [MyAuthentication][ClearCache]
    public class MoviesController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.Category).Include(m => m.Language).Include(m => m.Streaming);
            return View(movies.ToList());
        }

        // GET: Movies/Details/5
       // [MyAuthentication]
        [MyAuthorization(new string[] {"Admin","Premium" })]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movies = db.Movies.Include(m => m.Category).Include(m => m.Language).Include(m => m.Streaming).ToList();
            var movie = movies.Find(m => m.MovieId == id);
            // Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        //[MyAuthentication]
        [MyAuthorization("Admin")]
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.MoviesCategories, "CategoryId", "CategoryName");
            ViewBag.MoviesLanguageId = new SelectList(db.MoviesLanguages, "MoviesLanguageId", "MoviesLanguageName");
            ViewBag.StreamingPlatformId = new SelectList(db.StreamingPlatforms, "StreamingPlatformId", "StreamingPlatformName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[MyAuthentication]
        [MyAuthorization("Admin")]
        public ActionResult Create([Bind(Include = "MovieId,MovieName,MovieYearOfRelease,CategoryId,MoviesLanguageId,MovieDirectorName,StreamingPlatformId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.MoviesCategories, "CategoryId", "CategoryName", movie.CategoryId);
            ViewBag.MoviesLanguageId = new SelectList(db.MoviesLanguages, "MoviesLanguageId", "MoviesLanguageName", movie.MoviesLanguageId);
            ViewBag.StreamingPlatformId = new SelectList(db.StreamingPlatforms, "StreamingPlatformId", "StreamingPlatformName", movie.StreamingPlatformId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        //[MyAuthentication]
        [MyAuthorization("Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movies = db.Movies.Include(m => m.Category).Include(m => m.Language).Include(m => m.Streaming).ToList();
            var movie = movies.Find(m => m.MovieId == id);
        //    Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.MoviesCategories, "CategoryId", "CategoryName", movie.CategoryId);
            ViewBag.MoviesLanguageId = new SelectList(db.MoviesLanguages, "MoviesLanguageId", "MoviesLanguageName", movie.MoviesLanguageId);
            ViewBag.StreamingPlatformId = new SelectList(db.StreamingPlatforms, "StreamingPlatformId", "StreamingPlatformName", movie.StreamingPlatformId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[MyAuthentication]
        [MyAuthorization("Admin")]
        public ActionResult Edit([Bind(Include = "MovieId,MovieName,MovieYearOfRelease,CategoryId,MoviesLanguageId,MovieDirectorName,StreamingPlatformId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.MoviesCategories, "CategoryId", "CategoryName", movie.CategoryId);
            ViewBag.MoviesLanguageId = new SelectList(db.MoviesLanguages, "MoviesLanguageId", "MoviesLanguageName", movie.MoviesLanguageId);
            ViewBag.StreamingPlatformId = new SelectList(db.StreamingPlatforms, "StreamingPlatformId", "StreamingPlatformName", movie.StreamingPlatformId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        //[MyAuthentication]
        [MyAuthorization("Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var movies = db.Movies.Include(m => m.Category).Include(m => m.Language).Include(m => m.Streaming).ToList();
            var movie = movies.Find(m => m.MovieId == id);
            // Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
    }
}
