using BAPapp.Data;
using BAPapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Services
{
    public class VenueService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //create
        public bool CreateVenue(VenueCreate model)
        {
            Venue entity = new Venue
            {
                VenueId = model.VenueId,
                VenueName = model.VenueName,
                VenueLocation = model.VenueLocation,
                CrewerId = model.CrewerId,
                PointOfContact = model.PointOfContact
            };
            _context.Venues.Add(entity);
            return _context.SaveChanges() == 1;
        }

        //get all
        public List<VenueDetail> GetAllVenues()
        {
            var venueEntities = _context.Venues.ToList();
            var venueList = venueEntities.Select(v => new VenueDetail
            {
                VenueId = v.VenueId,
                VenueName = v.VenueName,
                VenueLocation = v.VenueLocation,
                CrewerId= v.CrewerId,
                PointOfContact = v.PointOfContact
            }).ToList();
            return venueList;
        }
        //get by name
        public VenueDetail GetVenueByName(string venueName)
        {
            var venueEntity = _context.Venues.Find(venueName);
            if (venueEntity == null)
                return null;
            var venueDetail = new VenueDetail
            {
                VenueId = venueEntity.VenueId,
                VenueName = venueEntity.VenueName,
                VenueLocation = venueEntity.VenueLocation,
                CrewerId = venueEntity.CrewerId,
                PointOfContact = venueEntity.PointOfContact
            };
            return venueDetail;
        }
    }
}
