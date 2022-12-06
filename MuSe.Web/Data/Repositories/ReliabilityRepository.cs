namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;

    public class ReliabilityRepository : GenericRepository<Reliability>, IReliabilityRepository
    {
        private readonly DataContext context;

        public ReliabilityRepository(DataContext context) : base(context) 
        {
            this.context = context;
        }

        public IQueryable GetReliabilityWithViolentometers()
        {
            return this.context.Reliabilities
                .OrderBy(c => c.Description);
        }

        public Reliability GetReliabilityByName(string name)
        {
            return this.context.Reliabilities
                .FirstOrDefault(h => h.Description == name);
        }
    }
}
