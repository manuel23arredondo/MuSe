namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;

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
    }
}
