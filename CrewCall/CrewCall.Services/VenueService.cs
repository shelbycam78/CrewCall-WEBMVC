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

        private readonly Guid _userId;

        public VenueService(Guid userId)
        {
            _userId = userId;
        }

        public VenueDetail GetVenueDetailsById(int VenueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var venue = ctx.Venues.Single(v => v.VenueId == VenueId);
                return new VenueDetail
                {
                    VenueId = venue.VenueId,
                    VenueName = venue.VenueName,
                    VenueLocation = venue.VenueLocation
                };
            }
        }

        public bool CreateVenue(VenueCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newVenue = new Venue()
                {
                    VenueId = model.VenueId,
                    VenueName = model.VenueName,
                    VenueLocation = model.VenueLocation
                };

                ctx.Venues.Add(newVenue);
                return ctx.SaveChanges() == 1;
                           
            }
        
        }

        public IEnumerable<VenueListItem> GetVenueList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Venues.Select(v => new VenueListItem
                {
                    VenueId = v.VenueId,
                    VenueName = v.VenueName,
                    VenueLocation = v.VenueLocation
                });

                return query.ToArray();
            }
        }

        public bool UpdateVenue(VenueEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var venue = ctx.Venues.Single(v => v.VenueId == model.VenueId);
                    venue.VenueId = model.VenueId;
                    venue.VenueName = model.VenueName;
                    venue.VenueLocation = model.VenueLocation;

                    return ctx.SaveChanges() == 1;

                }
            }
        }
    }
