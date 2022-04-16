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

        private readonly Guid _userId;

        public ContactService(Guid userId)
        {
            _userId = userId;
        }

        public ContactDetail GetContactDetailsById(int ContactId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var contact = ctx.Contacts.Single(t => t.ContactId == ContactId);
                return new ContactDetail
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Company = contact.Company
                };
            }
        }

        public bool CreateContact(ContactCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newContact = new Contact()
                {
                    ContactId = model.ContactId,
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Company = model.Company

                };

                ctx.Contacts.Add(newContact);
                return ctx.SaveChanges() == 1;

            }

        }

        public IEnumerable<ContactListItem> GetContactList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Contacts.Select(t => new ContactListItem
                {
                    ContactId = t.ContactId,
                    Name = t.Name,
                    Email = t.Email,
                    Phone = t.Phone,
                    Company = t.Company
                    
                });

                return query.ToArray();
            }
        }

        public bool UpdateContact(ContactEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var contact = ctx.Contacts.Single(t => t.ContactId == model.ContactId);
                contact.ContactId = model.ContactId;
                contact.Name = model.Name;
                contact.Email = model.Email;
                contact.Phone = model.Phone;
                contact.Company = model.Company;

                return ctx.SaveChanges() == 1;

            }
        }
    }

}
