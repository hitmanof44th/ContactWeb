using ContactData.Datacontext;
using ContactData.Interfaces;
using ContactData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData.Services
{
    public class ContactService : IContactService
    {
        private readonly ContactManagerDbContext _context;

        public ContactService(ContactManagerDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Contact>> GetContactsAsync(string searchTerm)
        {
            var contacts = _context.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                contacts = contacts.Where(c =>
                    c.FirstName.Contains(searchTerm) ||
                    c.LastName.Contains(searchTerm) ||
                    c.Address.Street.Contains(searchTerm) ||
                    c.Address.City.Contains(searchTerm) ||
                    c.Address.State.Contains(searchTerm) ||
                    c.Address.PostalCode.Contains(searchTerm)
                );
            }

            return await contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateContactAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await GetContactByIdAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ContactExistsAsync(int id)
        {
            return await _context.Contacts.AnyAsync(c => c.Id == id);
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts.Include(c => c.Address).ToListAsync();
        }


    }
}
