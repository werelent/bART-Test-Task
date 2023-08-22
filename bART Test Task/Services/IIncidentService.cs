using bART_Test_Task.Models;
using bART_Test_Task.Requests;

namespace bART_Test_Task.Services
{
    public interface IIncidentService
    {
        Task<List<Incident>> GetIncidents();
        Task<IncidentCreationResult> CreateIncident(CreateIncidentDTO incidentDTO);
    }
}

public enum IncidentCreationResult
{
    Success,
    AccountNotFound
}