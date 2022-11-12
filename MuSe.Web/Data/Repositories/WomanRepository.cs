namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;

    public class WomanRepository : GenericRepository<Woman>, IWomanRepository
    {
        private readonly DataContext context;

        public WomanRepository(DataContext context) : base(context) 
        {
            this.context = context;
        }

        public IQueryable GetWomanWithUsers()
        {
            return this.context.Womans
                .Include(c => c.User)
                .OrderBy(c => c.User.FirstName);
        }
    }
}
