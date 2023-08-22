using bART_Test_Task.Models;
using Microsoft.AspNetCore.Mvc;

namespace bART_Test_Task.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContacts();
        Task<Contact> GetContactByEmail(string email);
        Task CreateContact(Contact contact);
    }
}
