namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

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

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await this.context.Users
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Woman> GetWomanWithUserByIdAsync(string userId)
        {
            return await this.context.Womans
                .FirstOrDefaultAsync(w => w.User.Id == userId);
        }
    }
}
