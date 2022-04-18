using CrewCall.Data;
using CrewCall.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Services
{
    public class VenueService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;

        public VenueService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateVenue(VenueCreate model)
        {

            var newVenue = new Venue()
            {
                VenueId = model.VenueId,
                VenueName = model.VenueName,
                VenueLocation = model.VenueLocation
            };

            _context.Venues.Add(newVenue);
            return _context.SaveChanges() == 1;

        }

        public IEnumerable<VenueListItem> GetVenueList()
        {

            var query = _context.Venues.Select(v => new VenueListItem
            {
                VenueId = v.VenueId,
                VenueName = v.VenueName,
                VenueLocation = v.VenueLocation
            });

            return query.ToArray();

        }
        public VenueDetail GetVenueDetailsById(int venueId)
        {
            var venue = _context.Venues.Find(venueId);
            if (venue == null)
                return null;

            var detail = new VenueDetail
            {
                VenueId = venue.VenueId,
                VenueName = venue.VenueName,
                VenueLocation = venue.VenueLocation
            };
            return detail;


        }
        public bool UpdateVenue(VenueEdit model)
        {
            var venue = _context.Venues.Single(v => v.VenueId == model.VenueId);
            venue.VenueId = model.VenueId;
            venue.VenueName = model.VenueName;
            venue.VenueLocation = model.VenueLocation;

            return _context.SaveChanges() == 1;

        }
    }
}
