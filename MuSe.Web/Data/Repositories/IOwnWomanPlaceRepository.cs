namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IOwnWomanPlaceRepository : IGenericRepository<OwnWomanPlace>
    {
        IQueryable GetOwnWomanPlacesWithKindOfPlacesAndUsers(string name);

        IQueryable GetAllOwnWomanPlacesWithKindOfPlacesAndUsers();

        Task<OwnWomanPlace> GetOwnWomanPlacesWithKindOfPlacesAndUsersByIdAsync(int id);

        Task<KindOfPlace> GetKindOfPlacesByIdAsync(int id);
    }
}
