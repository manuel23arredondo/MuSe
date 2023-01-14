namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Http;

    public class IncidentRepository : GenericRepository<Incident>, IIncidentRepository
    {
        private readonly DataContext context;

        public IncidentRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetIncidentsWithViolentometersAndUsers(string name)
        {
            return context.Incidents
                .Include(c => c.Violentometer)
                .Where(c => c.Woman.User.Email == name);
        }

        public IQueryable GetAllIncidentsWithViolentometersAndUsers()
        {
            return context.Incidents
                .Include(c => c.Violentometer)
                .Include(c => c.Woman.User)
                .OrderBy(c => c.Woman.User);
        }

        public async Task<Incident> GetIncidentsByIdAsync(int id)
        {
            return await this.context.Incidents
                .Include(c => c.Violentometer)
                .Include(c => c.Woman)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Woman> GetWoman()
        {
            //var user = HttpContext.
            //return await context.Womans
             //   .Include(w => w.User)
            //    .FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name);
            return null;
        }

        public async Task<Incident> GetIncidentsWithViolentometersAndUsersByIdAsync(int id)
        {
            return await context.Incidents
                .Include(c => c.Violentometer)
                .Include(c => c.Violentometer.Reliability)
                .Include(c => c.Woman.User)
                .FirstOrDefaultAsync(c =>c.Id == id);
        }

        public async Task<Violentometer> GetViolentometersByIdAsync(int id)
        {
            return await this.context.Violentometers
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public IQueryable<IncidentResponse> GetAllIncidentsResponse()
        {
            return this.context.Incidents
                .Select(h => new IncidentResponse
                {
                    Id = h.Id,
                    IncidentDate= h.IncidentDate,
                    IncidentDescription= h.IncidentDescription,
                    AgressorDescription= h.AgressorDescription,
                    Longitude = h.Longitude,
                    WomanUserId = h.Woman.Id,
                    Latitude = h.Latitude,
                    Violentometer = h.Violentometer.Description
                });
        }

        public async Task<IncidentResponse> GetIncidentsResponseById(int id)
        {
            return await this.context.Incidents
                .Select(h => new IncidentResponse
                {
                    Id = h.Id,
                    IncidentDate = h.IncidentDate,
                    IncidentDescription = h.IncidentDescription,
                    AgressorDescription = h.AgressorDescription,
                    Longitude = h.Longitude,
                    Latitude = h.Latitude,
                    WomanUserId = h.Woman.Id,
                    Violentometer = h.Violentometer.Description
                }).FirstOrDefaultAsync(h => h.Id == id);
        }
    }
}
