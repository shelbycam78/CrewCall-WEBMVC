using CrewCall.Data;
using CrewCall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrewCall.Services
{
    public class ContactService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;

        public ContactService(Guid userId)
        {
            _userId = userId;
        }
                
        public bool CreateContact(ContactCreate model)
        {
            var newContact = new Contact()
                {
                    ContactId = model.ContactId,
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Company = model.Company
                };

                _context.Contacts.Add(newContact);
                return _context.SaveChanges() == 1;
      
        }

        public IEnumerable<ContactListItem> GetContactList()
        {
            var query = _context.Contacts.Select(t => new ContactListItem
                {
                    ContactId = t.ContactId,
                    Name = t.Name,
                    Email = t.Email,
                    Phone = t.Phone,
                    Company = t.Company
                    
                });
                return query.ToArray();
        }
        public ContactDetail GetContactDetailsById(int contactId)
        {
            var contact = _context.Contacts.Find(contactId);
            if (contact == null)
            return null;
        
            var detail = new ContactDetail
            {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Company = contact.Company
            };
            return detail;

        }
    
        public bool UpdateContact(ContactEdit model)
        {
            var contact = _context.Contacts.Single(t => t.ContactId == model.ContactId);
                contact.ContactId = model.ContactId;
                contact.Name = model.Name;
                contact.Email = model.Email;
                contact.Phone = model.Phone;
                contact.Company = model.Company;

                return _context.SaveChanges() == 1;

        }
    }
}
