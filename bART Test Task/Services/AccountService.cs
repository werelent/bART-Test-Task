using Azure.Core;
using bART_Test_Task.Models;
using bART_Test_Task.Repositories;
using bART_Test_Task.Requests;
using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IContactRepository _contactRepository;

        public AccountService(IAccountRepository accountRepository, IContactRepository contactRepository)
        {
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await _accountRepository.GetAccounts();
        }

        public async Task<AccountCreationResult> CreateAccount(CreateAccountDTO accountDTO)
        {
            var existingContact = await _contactRepository.GetContactByEmail(accountDTO.ContactEmail);

            if (existingContact == null)
            {
                return AccountCreationResult.ContactNotFound;
            }

            if (existingContact.Account != null)
            {
                return AccountCreationResult.ContactAlreadyLinked;
            }

            var existingAccount = await _accountRepository.GetAccountByName(accountDTO.AccountName);
            if (existingAccount != null)
            {
                return AccountCreationResult.AccountNameExists;
            }

            var newAccount = new Account { Name = accountDTO.AccountName };
            existingContact.Account = newAccount;

            existingContact.FirstName = accountDTO.ContactFirstName;
            existingContact.LastName = accountDTO.ContactLastName;

            await _accountRepository.CreateAccount(newAccount);

            return AccountCreationResult.Success;
        }
    }
}