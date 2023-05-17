using ContactData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactData.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContactsAsync(string searchTerm);
        Task<List<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task CreateContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int id);
        Task<bool> ContactExistsAsync(int id);
    }
}
