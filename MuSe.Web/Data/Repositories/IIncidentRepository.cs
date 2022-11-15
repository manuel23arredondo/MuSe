namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IIncidentRepository : IGenericRepository<Incident>
    {
        IQueryable GetIncidentsWithViolentometersAndUsers(string name);

        Task<Violentometer> GetViolentometersByIdAsync(int id);
    }
}
