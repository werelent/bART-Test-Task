using bART_Test_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly TaskDbContext _dbContext;

        public AccountRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccountByName(string name)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task CreateAccount(Account account)
        {
            _dbContext.Accounts.Add(account);
            await _dbContext.SaveChangesAsync();
        }
    }
}
