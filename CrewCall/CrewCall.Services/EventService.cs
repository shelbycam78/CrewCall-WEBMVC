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
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
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

            };

            _context.Events.Add(newEvent);
            return _context.SaveChanges() == 1;

        }

        public IEnumerable<EventListItem> GetEventList()
        {
            var query = _context.Events.Select(e => new EventListItem
            {
                EventId = e.EventId,
                EventDate = e.EventDate,
                EventTitle = e.EventTitle,
                VenueId = e.VenueId,
                ClientId = e.ClientId,
                IsPaid = e.IsPaid,
                IsTaxed = e.IsTaxed,
                IsDirectDeposit = e.IsDirectDeposit,

            });

            return query.ToArray();
        }

        //public EventDetail GetEventDetailsById(int eventId)
        //{
        //    var event = _context.Events.Find(eventId);
        //    if (event == null)
        //    return null;

        //var detail = new EventDetail
        //    {
        //        EventId = event.EventId,
        //        EventDate = event.EventDate,
        //        EventTitle = event.EventTitle,
        //        VenueId = event.VenueId,
        //        ClientId = event.ClientId,
        //        IsPaid = event.IsPaid,
        //        IsTaxed = event.IsTaxed,
        //        IsDirectDeposit = event.IsDirectDeposit,
        //    };
        //    return detail;
        //}
}
}

    //    public bool UpdateEvent(EventEdit model)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var event = ctx.Events.Single(e => e.EventId == model.EventId);
    //            event.EventId = model.EventId;
    //            event.EventDate = model.EventDate;
    //            event.EventTitle = model.EventTitle;
    //            event.VenueId = model.VenueId;
    //            event.ClientId = model.ClientId;
    //            event.IsPaid = model.IsPaid;
    //            event.IsDirectDeposit = model.IsDirectDeposit;
    //            event.EventType = model.EventType;

    //            return ctx.SaveChanges() == 1;
    //        }

    //    }
    // }

    //}

