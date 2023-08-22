using bART_Test_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Repositories
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly TaskDbContext _dbContext;

        public IncidentRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Incident>> GetIncidents()
        {
            return await _dbContext.Incidents.ToListAsync();
        }

        public async Task CreateIncident(Incident incident)
        {
            _dbContext.Incidents.Add(incident);

            await _dbContext.SaveChangesAsync();
        }
    }
}
