using bART_Test_Task.Models;

namespace bART_Test_Task.Repositories
{
    public interface IIncidentRepository
    {
        Task<List<Incident>> GetIncidents();
        Task CreateIncident(Incident incident);
    }
}
    