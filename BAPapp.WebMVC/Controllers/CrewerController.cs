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
    public class CrewerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Crewer
        public ActionResult Index()
        {
            ICollection<Crewer> crewersList = _db.Crewers.ToList();
            ICollection<Crewer> orderedList = crewersList.OrderBy(crew=>crew.Name).ToList();
            return View(orderedList);
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST:  Crewer
        [HttpPost]
        public ActionResult Create(Crewer crewer)
        {
            if (ModelState.IsValid)
            {
                _db.Crewers.Add(crewer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crewer);
        }

        //GET:  Delete
        //Crewer/Delete/CrewerId
        public ActionResult Delete(string crewerId)
        {
            if (crewerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crewer crewer = _db.Crewers.Find(crewerId);
            if (crewer == null)
            {
                return HttpNotFound();
            }
            return View(crewer);
        }

        //POST: Delete
        //Crewer/Delete/CrewerId
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string crewerId)
        {
            Crewer crewer = _db.Crewers.Find(crewerId);
            _db.Crewers.Remove(crewer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET:  Edit
        //Crewer/Edit/CrewerId
        public ActionResult Edit(string crewerId)
        {
            if (crewerId==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crewer crewer = _db.Crewers.Find(crewerId);
            if (crewer==null)
            {
                return HttpNotFound();
            }
            return View(crewer);
        }

        //POST: Edit
        //Crewer/Edit/CrewerId
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Crewer crewer)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(crewer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crewer);
        
        }

        //GET:  Details
        //Crewer/Details/CrewerId
        public ActionResult Details(string crewerId)
        {
            if (crewerId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crewer crewer = _db.Crewers.Find(crewerId);
            if (crewer == null)
            {
                return HttpNotFound();
            }
            return View(crewer);
        }
    }
}