using Azure.Core;
using bART_Test_Task.Models;
using bART_Test_Task.Repositories;
using bART_Test_Task.Requests;

namespace bART_Test_Task.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;
        private readonly IAccountRepository _accountRepository;

        public IncidentService(IIncidentRepository incidentRepository, IAccountRepository accountRepository)
        {
            _incidentRepository = incidentRepository;
            _accountRepository = accountRepository;
        }

        public async Task<List<Incident>> GetIncidents()
        {
            return await _incidentRepository.GetIncidents();
        }

        public async Task<IncidentCreationResult> CreateIncident(CreateIncidentDTO incidentDTO)
        {
            var existingAccount = await _accountRepository.GetAccountByName(incidentDTO.AccountName);

            if (existingAccount == null)
            {
                return IncidentCreationResult.AccountNotFound;
            }

            var newIncident = new Incident
            {
                IncidentName = Guid.NewGuid().ToString(),
                Description = incidentDTO.IncidentDescription
            };

            existingAccount.Incident = newIncident;
            await _incidentRepository.CreateIncident(newIncident);

            return IncidentCreationResult.Success;
        }
    }
}
