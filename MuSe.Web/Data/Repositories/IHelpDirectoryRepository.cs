namespace MuSe.Web.Data.Repositories
{
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IHelpDirectoryRepository : IGenericRepository<HelpDirectory>
    {
        IQueryable GetHelpDirectoriesWithHelpTypes();

        Task<HelpDirectory> GetHelpDirectoriesWithHelpTypesByIdAsync(int id);

        Task<HelpType> GetHelpTypesByIdAsync(int id);

        IQueryable<HelpDirectoryResponse> GetAllHelpDirectoriesResponse();

        Task<HelpDirectoryResponse> GetHelpDirectoriesResponseById(int id);
    }
}