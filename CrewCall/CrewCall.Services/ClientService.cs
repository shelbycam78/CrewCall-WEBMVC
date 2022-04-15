using CrewCall.Data;
using CrewCall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Services
{
    public class ClientService
    {
        private readonly Guid _userId;

        public ClientService(Guid userId)
        {
            _userId = userId;
        }

        public ClientDetail GetClientDetailsById(int ClientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var client = ctx.Clients.Single(c => c.ClientId == ClientId);
                return new ClientDetail
                {
                    ClientId = client.ClientId,
                    Company = client.Company,
                    ContactId = client.ContactId
                };
            }
        }

        public bool CreateClient(ClientCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newClient = new Client()
                {
                    ClientId = model.ClientId,
                    Company = model.Company,
                    ContactId = model.ContactId
                };

                ctx.Clients.Add(newClient);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClientListItem> GetClientList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Clients.Select(c => new ClientListItem
                {
                    ClientId = c.ClientId,
                    Company = c.Company,
                    ContactId = c.ContactId,
                });
                return query.ToArray();

            }
        }

        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var client = ctx.Clients.Single(c => c.ClientId == model.VenueId);
                client.ClientId = model.VenueId;
                client.Company = model.Company;
                client.ContactId = model.ContactId;

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
