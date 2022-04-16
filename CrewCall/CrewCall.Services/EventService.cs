using CrewCall.Data;
using CrewCall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public EventDetail GetEventDetailsById(int EventId)
        {
            
        }

        public bool CreateEvent(EventCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newEvent = new Event()
                {
                    EventId = model.EventId,
                    EventDate = model.EventDate,
                    EventTitle = model.EventTitle,
                    VenueId = model.VenueId,
                    ClientId = model.ClientId,
                    IsPaid = model.IsPaid,
                    IsTaxed = model.IsTaxed,
                    IsDirectDeposit = model.IsDirectDeposit,
                    EventType = model.EventType
                };

                ctx.Events.Add(newEvent);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEventList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Events.Select(e => new EventListItem
                {
                    EventId = e.EventId,
                    EventDate = e.EventDate,
                    EventTitle = e.EventTitle,
                    VenueId =  e.VenueId,
                    ClientId = e.ClientId,
                    IsPaid = e.IsPaid,
                    IsTaxed = e.IsTaxed,
                    IsDirectDeposit = e.IsDirectDeposit,
                    EventType = e.EventType
                });
                return query.ToArray();

            }
        }

        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var event = ctx.Events.Single(e => e.EventId == model.EventId);
                event.EventId = model.EventId;
                event.EventDate = model.EventDate;
                event.EventTitle = model.EventTitle;
                event.VenueId = model.VenueId;
                event.ClientId = model.ClientId;
                event.IsPaid = model.IsPaid;
                event.IsDirectDeposit = model.IsDirectDeposit;
                event.EventType = model.EventType;

                return ctx.SaveChanges() == 1;
            }

        }
     }

    }
}

