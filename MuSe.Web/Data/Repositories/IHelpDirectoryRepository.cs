namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IHelpDirectoryRepository : IGenericRepository<HelpDirectory>
    {
        IQueryable GetHelpDirectoriesWithHelpTypes();

        Task<HelpDirectory> GetHelpDirectoriesWithHelpTypesByIdAsync(int id);

        Task<HelpType> GetHelpTypesByIdAsync(int id);
    }
}