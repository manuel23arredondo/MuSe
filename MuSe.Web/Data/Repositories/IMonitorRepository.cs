namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMonitorRepository : IGenericRepository<Monitor>
    {
        IQueryable GetMonitorsWithUsers();

        Task<User> GetUsersByIdAsync(string id);

    }
}
