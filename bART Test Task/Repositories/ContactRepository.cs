using bART_Test_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly TaskDbContext _dbContext;

        public ContactRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Contact>> GetContacts()
        {
            return await _dbContext.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByEmail(string email)
        {
            return await _dbContext.Contacts.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task CreateContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
        }
    }
}
