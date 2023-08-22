using bART_Test_Task.Models;
using bART_Test_Task.Requests;

namespace bART_Test_Task.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetContacts();
        Task CreateContact(CreateContactDTO contactDTO);
    }
}
