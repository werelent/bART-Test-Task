using bART_Test_Task.Models;
using bART_Test_Task.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly TaskDbContext _dbContext;

        public ContactController(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _dbContext.Contacts.ToListAsync();

            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactRequest request)
        {
            if (ModelState.IsValid)
            {
                var newContact = new Contact
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email
                };

                _dbContext.Contacts.Add(newContact);
                await _dbContext.SaveChangesAsync();

                return Ok("Contact created!");
            }
            else
            {
                return BadRequest("Invalid data!");
            }
        }
    }
}
