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
    //public class EventController : Controller
    //{
    //    // GET: Event
    //    public ActionResult Index()
    //    {
    //        return View(CreateEventService().GetEventList());
    //    }

    //    public ActionResult Create()
    //    {
    //        ViewBag.Title = "New Event";
    //        return View();
    //    }

    //    // POST:  Event
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(EventCreate model)
    //    {
    //        if (!ModelState.IsValid) return View(model);

    //        if (CreateEventService().CreateEvent(model))
    //        {
    //            TempData["Save Result"] = "Event Established";
    //            return RedirectToAction("Index");
    //        }

    //        ModelState.AddModelError("", "Error creating an event");
    //        return View(model);
    //    }

    //    public ActionResult Details(int eventId)
    //    {
    //        var event = CreateEventService().GetEventDetailsById(eventId);
    //        return View(event);

    //    }

    //    public ActionResult Edit(int eventId)
    //    {
    //        var event = CreateEventService().GetEventDetailsById(eventId);
    //        return View(new EventEdit
    //        {
    //            EventId = event.EventId,
    //                EventDate = event.EventDate,
    //                EventTitle = event.EventTitle,
    //                VenueId = event.VenueId,
    //                ClientId = event.ClientId,
    //                IsPaid = event.IsPaid,
    //                IsTaxed = event.IsTaxed,
    //                IsDirectDeposit = event.IsDirectDeposit,
    //                EventType = event.EventType
    //    });
    //    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult Edit(int eventId, EventEdit model)
    //{
    //    if (!ModelState.IsValid) return View(model);

    //    if (model.EventId != eventId)
    //    {
    //        ModelState.AddModelError("", "Id mismatch");
    //        return View(model);
    //    }

    //    if (CreateEventService().UpdateEvent(model))
    //    {
    //        TempData["SaveResult"] = "Event updated";
    //        return RedirectToAction("Index");
    //    }

    //    ModelState.AddModelError("", "Error editing event");
    //    return View(model);
    //}

    //public EventService CreateEventService()
    //{
    //    var userId = Guid.Parse(User.Identity.GetUserId());
    //    var service = new EventService(userId);
    //    return service;
    //}
}