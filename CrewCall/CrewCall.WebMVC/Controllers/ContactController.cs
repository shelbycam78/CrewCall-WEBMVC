using CrewCall.Data;
using CrewCall.Models;
using CrewCall.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CrewCall.WebMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View(CreateContactService().GetContactList());
        }
    
        public ActionResult Create()
        {
            ViewBag.Title = "New Contact";
            return View();
        }

        //POST:  Venue
        [HttpPost]
        [ValidateAntiForgeryToken]
    
         public ActionResult Create(ContactCreate model)
         {
            if (!ModelState.IsValid) return View(model);

            if (CreateContactService().CreateContact(model))
                {
                    TempData["SaveResult"] = "Contact established";
                    return RedirectToAction("Index");
                }

            ModelState.AddModelError("", "Error creating a contact");
            return View(model);
         }

         public ActionResult Details(int contactId)
         {
                var contact = CreateContactService().GetContactDetailsById(contactId);
                return View(contact);
         }

          public ActionResult Edit(int contactId)
          {
                var contact = CreateContactService().GetContactDetailsById(contactId);
                return View(new ContactEdit
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone
                });
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(int contactId, ContactEdit model)
          {
                if (!ModelState.IsValid) return View(model);

                if (model.ContactId != contactId)
                {
                    ModelState.AddModelError("", "Id mismatch");
                    return View(model);
                }

                if (CreateContactService().UpdateContact(model))
                {
                    TempData["SaveResult"] = "Contact updated";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Error editing contact");
                return View(model);
          }

        
        private ContactService CreateContactService()
          {
          var userId = Guid.Parse(User.Identity.GetUserId());
          var service = new ContactService(userId);
          return service;
          }

    }
}