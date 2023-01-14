namespace MuSe.Web.Data.Repositories
{
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IOwnWomanPlaceRepository : IGenericRepository<OwnWomanPlace>
    {
        IQueryable GetOwnWomanPlacesWithKindOfPlacesAndUsers(string name);

        IQueryable GetAllOwnWomanPlacesWithKindOfPlacesAndUsers();

        Task<OwnWomanPlace> GetOwnWomanPlacesWithKindOfPlacesAndUsersByIdAsync(int id);

        Task<KindOfPlace> GetKindOfPlacesByIdAsync(int id);

        IQueryable<OwnWomanPlaceResponse> GetAllOwnWomanPlacesResponse();

        Task<OwnWomanPlace> GetOwnWomanPlacesByIdAsync(int id);

        Task<OwnWomanPlaceResponse> GetOwnWomanPlaceResponseById(int id);
    }
}
