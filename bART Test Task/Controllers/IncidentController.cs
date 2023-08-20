using bART_Test_Task.Models;
using bART_Test_Task.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Controllers
{
    [ApiController]
    [Route("api/incidents")]
    public class IncidentController : ControllerBase
    {
        private readonly TaskDbContext _dbContext;

        public IncidentController(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetIncidents()
        {
            var incidents = await _dbContext.Incidents.ToListAsync();
            return Ok(incidents);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncident([FromBody] CreateIncidentRequest request)
        {
            var existingAccount = _dbContext.Accounts.FirstOrDefault(a => a.Name == request.AccountName);

            if (existingAccount == null)
            {
                return NotFound("Account not found!");
            }

            var newIncident = new Incident
            {
                IncidentName = Guid.NewGuid().ToString(),
                Description = request.IncidentDescription
            };

            existingAccount.Incident = newIncident;
            _dbContext.Incidents.Add(newIncident);

            await _dbContext.SaveChangesAsync();

            return Ok("Incident created");
        }
    }
}