using bART_Test_Task.Models;

namespace bART_Test_Task.Repositories
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAccounts();
        Task<Account> GetAccountByName(string name);
        Task CreateAccount(Account account);
    }
}
