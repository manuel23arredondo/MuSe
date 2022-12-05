namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IMonitorRepository : IGenericRepository<Monitor>
    {
        IQueryable GetMonitorWithUsers();

        Task<User> GetUserByIdAsync(string id);

        Task<Monitor> GetMonitorWithUserByIdAsync(string userId);
    }
}
