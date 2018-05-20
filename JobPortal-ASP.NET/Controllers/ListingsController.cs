using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JobPortal_ASP.NET;

namespace JobPortal_ASP.NET.Controllers
{
    public class ListingsController : Controller
    {
        private JPDatabaseEntities db = new JPDatabaseEntities();

        // GET: Listings
        public ActionResult Index(LoggedInUser u)
        {
            if (u.UserName != null) {
                ViewBag.user = u.UserName;
            }

            var listings = db.Listings.Include(l => l.User);
            return View(listings.ToList());
        }

        // GET: Listings/Details/5
        public ActionResult Details(int? id, string username)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            ViewBag.user = username;
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // GET: Listings/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserType");
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ListingId,ListingDescription,ListedDate,GpaRequirement,ExperienceRequirement,OpenToAll,ListingTitle,AgeRequirement,UserId")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Listings.Add(listing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserType", listing.UserId);
            return View(listing);
        }

        // GET: Listings/Edit/5
        public ActionResult Edit(int? id, string username)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            ViewBag.user = username;
            if (listing == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserType", listing.UserId);
            return View(listing);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ListingId,ListingDescription,ListedDate,GpaRequirement,ExperienceRequirement,OpenToAll,ListingTitle,AgeRequirement,UserId")] Listing listing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserType", listing.UserId);
            return View(listing);
        }

        // GET: Listings/Delete/5
        public ActionResult Delete(int? id, string username)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Listing listing = db.Listings.Find(id);
            ViewBag.user = username;
            if (listing == null)
            {
                return HttpNotFound();
            }
            return View(listing);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Listing listing = db.Listings.Find(id);
            db.Listings.Remove(listing);
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
