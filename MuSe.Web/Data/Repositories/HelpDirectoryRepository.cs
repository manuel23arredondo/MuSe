namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class HelpDirectoryRepository : GenericRepository<HelpDirectory>, IHelpDirectoryRepository
    {
        private readonly DataContext context;

        public HelpDirectoryRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetHelpDirectoriesWithHelpTypes()
        {
            return this.context.HelpDirectories
                .Include(c => c.HelpType)
                .OrderBy(c => c.OrganizationName);

        }

        public async Task<HelpDirectory> GetHelpDirectoriesWithHelpTypesByIdAsync(int id)
        {
            return await context.HelpDirectories
                .Include(c => c.HelpType)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<HelpType> GetHelpTypesByIdAsync(int id)
        {
            return await context.HelpTypes
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
