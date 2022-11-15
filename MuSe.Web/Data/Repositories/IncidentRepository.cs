namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

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
                .Where(c => c.User.Email == name);
        }

        public async Task<Violentometer> GetViolentometersByIdAsync(int id)
        {
            return await this.context.Violentometers
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
