using CrewCall.Data;
using CrewCall.Models;
using CrewCall.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CrewCall.WebMVC.Controllers
{
    public class ClientController : Controller
    {
        //GET: Client
        public ActionResult Index()
        {
            return View(CreateClientService().GetClientList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Client";
            return View();
        }

        //POST:  Client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateClientService().CreateClient(model))
            {
                TempData["SaveResult"] = "Client established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error creating a client");
            return View(model);
        }

        public ActionResult Details(int clientId)
        {
            var client = CreateClientService().GetClientDetailsById(clientId);
            return View(client);

        }

        public ActionResult Edit(int clientId)
        {
            var client = CreateClientService().GetClientDetailsById(clientId);
            return View(new ClientEdit
            {
                VenueId = client.ClientId,
                Company = client.Company,
                ContactId = client.ContactId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int clientId, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VenueId != clientId)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateClientService().UpdateClient(model))
            {
                TempData["SaveResult"] = "Client updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error editing client");
            return View(model);
        }

        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }


        //    // GET: Client
        //    public ActionResult Index()
        //    {
        //        ICollection<Client> clientsList = _db.Clients.ToList();
        //        ICollection<Client> orderedList = clientsList.OrderBy(client => client.Company).ToList();
        //        return View(orderedList);
        //    }

        //    public ActionResult Create()
        //    {
        //        return View();
        //    }

        //    //POST:  Client
        //    [HttpPost]
        //    public ActionResult Create(Client client)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _db.Clients.Add(client);
        //            _db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(client);
        //    }

        //    //GET:  Delete
        //    //Client/Delete/ClientId
        //    public ActionResult Delete(string clientId)
        //    {
        //        if (clientId == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Client client = _db.Clients.Find(clientId);
        //        if (client == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(client);
        //    }

        //    //POST: Delete
        //    //Client/Delete/ClientId
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult DeleteConfirm(string clientId)
        //    {
        //        Client client = _db.Clients.Find(clientId);
        //        _db.Clients.Remove(client);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    //GET:  Edit
        //    //Client/Edit/ClientId
        //    public ActionResult Edit(string clientId)
        //    {
        //        if (clientId == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Client client = _db.Clients.Find(clientId);
        //        if (client == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(client);
        //    }

        //    //POST: Edit
        //    //Client/Edit/ClientId
        //    [HttpPost, ActionName("Edit")]
        //    [ValidateAntiForgeryToken]
        //    public ActionResult Edit(Client client)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _db.Entry(client).State = EntityState.Modified;
        //            _db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        return View(client);

        //    }

        //    //GET:  Details
        //    //Client/Details/ClientId
        //    public ActionResult Details(string clientId)
        //    {
        //        if (clientId == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        Client client = _db.Clients.Find(clientId) ;
        //        if (client == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        return View(client);
        //    }
        //}
    }
}

