namespace MuSe.Web.Data.Repositories
{
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IViolentometerRepository : IGenericRepository<Violentometer>
    {
        IQueryable GetViolentometersWithReliabilities();

        Task<Violentometer> GetViolentometersWithReliabilitiesByIdAsync(int id);

        Task<Reliability> GetReliabitiesByIdAsync(int id);

        IQueryable<ViolentometerResponse> GetAllViolentometersResponse();

        Task<ViolentometerResponse> GetViolentometersResponseById(int id);

        Violentometer GetViolentometerByName(string name);
    }
}
