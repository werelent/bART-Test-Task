using bART_Test_Task.Models;
using bART_Test_Task.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly TaskDbContext _dbContext;

        public AccountController(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _dbContext.Accounts.Include(a => a.Contacts).ToListAsync();
            return Ok(accounts);
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] CreateAccountRequest request)
        {
            var existingContact = _dbContext.Contacts.FirstOrDefault(c => c.Email == request.ContactEmail);

            if (existingContact != null)
            {
                if (existingContact.Account != null)
                {
                    return Conflict("Contact is already linked to an account!");
                }

                var existingAccount = _dbContext.Accounts.FirstOrDefault(a => a.Name == request.AccountName);

                if (existingAccount != null)
                {
                    return Conflict("Account with the provided name already exists!");
                }

                var newAccount = new Account { Name = request.AccountName };
                existingContact.Account = newAccount;

                _dbContext.Accounts.Add(newAccount);
                _dbContext.SaveChanges();

                return Ok("Account created and linked to the contact");
            }
            else
            {
                return NotFound("Contact not found!");
            }
        }
    }
}