namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;

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
    }
}
