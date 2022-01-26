using Aasani.CRM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aasani.CRM.Logic
{
    public class ContactService
    {
        private readonly List<Contact> contacts;

        public ContactService()
        {
            contacts = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    FirstName = "Shadman",
                    LastName = "Kudchikar",
                    Mobiles = new List<string>
                    {
                        "+917977503536"
                    }
                }
            };
        }

        public Task<Contact> GetById(long id)
        {
            return Task.Run(()=> contacts.SingleOrDefault(c => c.Id == id));
        }

        public Task<IEnumerable<Contact>> Paginate(Func<Contact, bool> filter, int page = 1, int pageSize = 10, string orderBy = nameof(Contact.FirstName))
        {
            return Task.Run(()=>contacts.Where(filter)
                .OrderByName(orderBy)
                .Skip((page - 1) * pageSize)
                .Take(pageSize));
        }

        public Task<Contact> Add(Contact contact)
        {
            return Task.Run(() =>
            {
                contact.Id = contacts.Max(c => c.Id) + 1;
                contacts.Add(contact);
                return contact;
            });
        }

        public async Task Update(long id, Contact value)
        {
            Contact contact = await GetById(id);
            contact.FirstName = value.FirstName;
            contact.LastName = value.LastName;
            contact.Mobiles = value.Mobiles;
        }

    }
}
