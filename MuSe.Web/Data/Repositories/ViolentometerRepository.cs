namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class ViolentometerRepository : GenericRepository<Violentometer>, IViolentometerRepository
    {
        private readonly DataContext context;

        public ViolentometerRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetViolentometersWithReliabilities()
        {
            return this.context.Violentometers
                .Include(c => c.Reliability)
                .OrderBy(c => c.Reliability.Description);
        }

        public async Task<Violentometer> GetViolentometersWithReliabilitiesByIdAsync(int id)
        {
            return await this.context.Violentometers
                .Include(c => c.Reliability)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Reliability> GetReliabitiesByIdAsync(int id)
        {
            return await this.context.Reliabilities
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
