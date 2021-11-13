using BAPapp.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BAPapp.WebMVC.Controllers
{
    public class VenueController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Venue
        public ActionResult Index()
        {
            ICollection<Venue> venuesList = _db.Venues.ToList();
            ICollection<Venue> orderedList = venuesList.OrderBy(ven => ven.VenueName).ToList();
            return View(orderedList);
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST: Venue
        [HttpPost]
        public ActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _db.Venues.Add(venue);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venue);
        }

        //GET: Delete
        //Venue/Delete/VenueId
        public ActionResult Delete(string venueId)
        {
            if (venueId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = _db.Venues.Find(venueId);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        //POST: Delete
        //Venue/Delete/VenueId
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string venueId)
        {
            Venue venue = _db.Venues.Find(venueId);
            _db.Venues.Remove(venue);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Edit
        //Venue/Edit/VenueId
        public ActionResult Edit(string venueId)
        {
            if (venueId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = _db.Venues.Find(venueId);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        //POST: Edit
        //Venue/Edit/VenueId
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(venue).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venue);
        }

        //GET: Details
        //Venue/Details/VenueId
        public ActionResult Details(string venueId)
        {
            if (venueId==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = _db.Venues.Find(venueId);
            if (venue==null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }
    }
} 