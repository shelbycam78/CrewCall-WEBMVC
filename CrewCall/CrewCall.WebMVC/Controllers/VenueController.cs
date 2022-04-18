using CrewCall.Models;
using CrewCall.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrewCall.WebMVC.Controllers
{
    public class VenueController : Controller
    {


        private VenueService CreateVenueService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userId);
            return service;
        }
        //GET: Venue
        public ActionResult Index()
        {
            return View(CreateVenueService().GetVenueList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Venue";
            return View();
        }

        //POST:  Venue
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(VenueCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateVenueService().CreateVenue(model))
            {
                TempData["SaveResult"] = "Venue established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating a venue");
            return View(model);
        }

        public ActionResult Details(int venueId)
        {
            var venue = CreateVenueService().GetVenueDetailsById(venueId);
            return View(venue);
        }

        public ActionResult Edit(int venueId)
        {
            var venue = CreateVenueService().GetVenueDetailsById(venueId);
            return View(new VenueEdit
            {
                VenueId = venue.VenueId,
                VenueName = venue.VenueName,
                VenueLocation = venue.VenueLocation,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int venueId, VenueEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VenueId != venueId)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateVenueService().UpdateVenue(model))
            {
                TempData["SaveResult"] = "Venue updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error editing venue");
            return View(model);
        }


    }
    
}