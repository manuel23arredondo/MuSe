namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    public class HelpTypeRepository : GenericRepository<HelpType>, IHelpTypeRepository
    {
        private readonly DataContext context;

        public HelpTypeRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
    }
}
