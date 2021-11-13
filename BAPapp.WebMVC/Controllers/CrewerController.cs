using BAPapp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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

            return View();
        }
    }
}