using bART_Test_Task.Requests;
using bART_Test_Task.Services;
using Microsoft.AspNetCore.Mvc;

namespace bART_Test_Task.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _contactService.GetContacts();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                await _contactService.CreateContact(contactDTO);
                return Ok("Contact created!");
            }
            else
            {
                return BadRequest("Invalid data!");
            }
        }
    }
}
