using BAPapp.Models;
using BAPapp.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAPapp.WebMVC.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            var model = new EventListItem[0];
            return View(model);
        }
        //Get method
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}