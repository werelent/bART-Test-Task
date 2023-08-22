using bART_Test_Task.Models;
using bART_Test_Task.Requests;
using bART_Test_Task.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _accountService.GetAccounts();
            return Ok(accounts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDTO accountDTO)
        {
            var result = await _accountService.CreateAccount(accountDTO);

            switch (result)
            {
                case AccountCreationResult.Success:
                    return Ok("Account created and linked to the contact");
                case AccountCreationResult.ContactNotFound:
                    return NotFound("Contact not found!");
                case AccountCreationResult.ContactAlreadyLinked:
                    return Conflict("Contact is already linked to an account!");
                case AccountCreationResult.AccountNameExists:
                    return Conflict("Account with the provided name already exists!");
                default:
                    return StatusCode(500, "An error occurred");
            }
        }
    }
}