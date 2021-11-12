using BAPapp.Data;
using BAPapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAPapp.Services
{
    public class CrewerServices
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        //create
        public bool CreateCrewer(CrewerCreate model)
        {
            Crewer entity = new Crewer
            {
                CrewerId = model.CrewerId,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                
            };
            _context.Crewers.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //get all
        public List<CrewerDetail> GetAllCrewers()
        {
            var crewerEntities = _context.Crewers.ToList();
            var crewerList = crewerEntities.Select(c => new CrewerDetail
            { 
                CrewerId = c.CrewerId,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                
            }).ToList();
            return crewerList;
        }

        //get by event
        public CrewerDetail GetCrewerByEvent(string eventName)
        {
            var crewerEntity = _context.Crewers.Find(eventName);
            if (crewerEntity == null)
                return null;
            var crewerDetail = new CrewerDetail
            {
                CrewerId = crewerEntity.CrewerId,
                Name = crewerEntity.Name,
                Email = crewerEntity.Email,
                Phone = crewerEntity.Phone,
                
            };
            return crewerDetail;
        
        }
    }
}
