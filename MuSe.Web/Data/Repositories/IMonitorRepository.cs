namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;

    public interface IMonitorRepository : IGenericRepository<Monitor>
    {
        IQueryable GetMonitorsWithUsers();
    }
}
