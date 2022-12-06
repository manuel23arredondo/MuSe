namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    public interface IKindOfPlaceRepository : IGenericRepository<KindOfPlace>
    {
        IQueryable GetKindOfPlaceWithOwnWomanPlaces();

        KindOfPlace GetKindOfPlaceByName(string name);
    }
}
