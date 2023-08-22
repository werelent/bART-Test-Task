using Azure.Core;
using bART_Test_Task.Models;
using bART_Test_Task.Repositories;
using bART_Test_Task.Requests;

namespace bART_Test_Task.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Contact>> GetContacts()
        {
            return await _repository.GetContacts();
        }

        public async Task CreateContact(CreateContactDTO contactDTO)
        {
            var newContact = new Contact
            {
                FirstName = contactDTO.FirstName,
                LastName = contactDTO.LastName,
                Email = contactDTO.Email
            };

            await _repository.CreateContact(newContact);
        }
    }
}
