using BAPapp.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAPapp.Data;
using BAPapp.Models;

namespace BAPapp.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //Create
        public bool CreateEvent(EventCreate model)
        {
            Event entity = new Event
            {
                EventDate = model.EventDate,
                EventTitle = model.EventTitle,
                VenueId = model.VenueId,
                CrewerId = model.CrewerId,
                Position = model.Position,
                Director = model.Director,
                Producer = model.Producer,
                IsPaid = model.IsPaid,
                IsTaxed = model.IsTaxed,
                IsDirectDeposit = model.IsDirectDeposit
            };

            _context.Events.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //Get All

        public List<EventDetail> GetAllEvents()
        {
            var eventEntities = _context.Events.ToList();
            var eventList = eventEntities.Select(e => new EventDetail
            {
                EventId = e.EventId,
                EventDate = e.EventDate,
                EventTitle = e.EventTitle,
            }).ToList();
            return eventList;
        }

        //Get (Details by ID)
        public EventDetail GetEventByDate(DateTime eventDate)
        {
            var eventEntity = _context.Events.Find(eventDate);
            if (eventEntity == null)
                return null;
            
            var eventDetail = new EventDetail
            {
                EventId = eventEntity.EventId,
                EventDate = eventEntity.EventDate,
                EventTitle = eventEntity.EventTitle,
            };
            return eventDetail;
        }
    }
}