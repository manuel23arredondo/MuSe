namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;

    public class MonitorRepository : GenericRepository<Monitor>, IMonitorRepository
    {
        private readonly DataContext context;

        public MonitorRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetMonitorsWithUsers()
        {
            return this.context.Monitors
                .Include(c => c.User)
                .OrderBy(c => c.User.FirstName);
        }
    }
}
