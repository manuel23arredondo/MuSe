namespace MuSe.Web.Data.Repositories
{
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IIncidentRepository : IGenericRepository<Incident>
    {
        IQueryable GetIncidentsWithViolentometersAndUsers(string name);

        IQueryable GetAllIncidentsWithViolentometersAndUsers();

        Task<Incident> GetIncidentsWithViolentometersAndUsersByIdAsync(int id);

        Task<Violentometer> GetViolentometersByIdAsync(int id);

        Task<Incident> GetIncidentsByIdAsync(int id);

        Task<Woman> GetWoman();
        IQueryable<IncidentResponse> GetAllIncidentsResponse();

        Task<IncidentResponse> GetIncidentsResponseById(int id);
    }
}
