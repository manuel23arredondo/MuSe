namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IHelpTypeRepository : IGenericRepository<HelpType>
    {
        //Task<HelpType> GetHelpTypeIdWithHelpDirectories(int id);

        IQueryable GetHelpTypeWithHelpDirectories();
    }
}
