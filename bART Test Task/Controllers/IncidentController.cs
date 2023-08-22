using bART_Test_Task.Models;
using bART_Test_Task.Requests;
using bART_Test_Task.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Controllers
{
    [ApiController]
    [Route("api/incidents")]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIncidents()
        {
            var incidents = await _incidentService.GetIncidents();
            return Ok(incidents);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncident([FromBody] CreateIncidentDTO incidentDTO)
        {
            var result = await _incidentService.CreateIncident(incidentDTO);

            switch (result)
            {
                case IncidentCreationResult.Success:
                    return Ok("Incident created");
                case IncidentCreationResult.AccountNotFound:
                    return NotFound("Account not found!");
                default:
                    return StatusCode(500, "An error occurred");
            }
        }
    }
}