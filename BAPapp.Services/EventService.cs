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
        private readonly Guid _userId;
        
        public EventService(Guid userId)
        {
            _userId = userId;
        }
        
        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    EventId = _userId,
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
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }
        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                        ctx
                            .Events
                            .Where(e => e.EventId == _userId)
                            .Select(
                                e =>
                                    new EventListItem
                                    {
                                        EventId = e.EventId,
                                        EventDate = e.EventDate,
                                        EventTitle = e.EventTitle,
                                    }
                            );
                return query.ToArray();
            }
        }
    }
}