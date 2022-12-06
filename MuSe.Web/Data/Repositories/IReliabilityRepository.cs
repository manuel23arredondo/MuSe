namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    public interface IReliabilityRepository : IGenericRepository<Reliability>
    {
        IQueryable GetReliabilityWithViolentometers();

        Reliability GetReliabilityByName(string name);
    }
}
