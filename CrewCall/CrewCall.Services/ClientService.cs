using CrewCall.Data;
using CrewCall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CrewCall.Services
{
    public class ClientService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;

        public ClientService(Guid userId)
        {
            _userId = userId;
        }
                
        public bool CreateClient(ClientCreate model)
        {
           
                var newClient = new Client()
                {
                    ClientId = model.ClientId,
                    Company = model.Company,
                    
                };

                _context.Clients.Add(newClient);
                return _context.SaveChanges() == 1;       
        }
        public IEnumerable<ClientListItem> GetClientList()
        {
           
                var query = _context.Clients.Select(c => new ClientListItem
                {
                    ClientId = c.ClientId,
                    Company = c.Company,
                    
                });
                return query.ToArray();

        }

        public ClientDetail GetClientDetailsById(int clientId)
        {

            var client = _context.Clients.Find(clientId);
            if (client == null)
                return null;

            var detail = new ClientDetail
            {
                ClientId = client.ClientId,
                Company = client.Company,
            };
            return detail;
            
        }

        public bool UpdateClient(ClientEdit model)
        {

            var client = _context.Clients.Single(c => c.ClientId == model.ClientId);
            client.ClientId = model.ClientId;
            client.Company = model.Company;


            return _context.SaveChanges() == 1;

        }
    }
}
