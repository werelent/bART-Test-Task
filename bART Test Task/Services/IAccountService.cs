using bART_Test_Task.Models;
using bART_Test_Task.Requests;

namespace bART_Test_Task.Services
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccounts();
        Task<AccountCreationResult> CreateAccount(CreateAccountDTO accountDTO);
    }
}

public enum AccountCreationResult
{
    Success,
    ContactNotFound,
    ContactAlreadyLinked,
    AccountNameExists
}
