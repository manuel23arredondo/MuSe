namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;

    public class HelpTypeRepository : GenericRepository<HelpType>, IHelpTypeRepository
    {
        private readonly DataContext context;

        public HelpTypeRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetHelpTypeWithHelpDirectories()
        {
            return this.context.HelpTypes
                .Include(c => c.HelpDirectories)
                .OrderBy(c => c.Description);
        }

        public HelpType GetHelpTypeByName(string name)
        {
            return this.context.HelpTypes
                .FirstOrDefault(h => h.Description == name);
        }
    }
}
