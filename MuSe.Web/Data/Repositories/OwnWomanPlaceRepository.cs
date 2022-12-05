namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;

    using System.Threading.Tasks;

    public class OwnWomanPlaceRepository : GenericRepository<OwnWomanPlace>, IOwnWomanPlaceRepository
    {
        private readonly DataContext context;

        public OwnWomanPlaceRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetOwnWomanPlacesWithKindOfPlacesAndUsers(string name)
        {
            return context.OwnWomanPlaces
                .Include(c => c.KindOfPlace)
                .Where(c => c.Woman.User.Email == name);
        }

        public IQueryable GetAllOwnWomanPlacesWithKindOfPlacesAndUsers()
        {
            return context.OwnWomanPlaces
                .Include(c => c.KindOfPlace)
                .Include(c => c.Woman.User)
                .OrderBy(c => c.Woman.User);
        }

        public async Task<OwnWomanPlace> GetOwnWomanPlacesWithKindOfPlacesAndUsersByIdAsync(int id)
        {
            return await context.OwnWomanPlaces
                .Include(c => c.KindOfPlace)
                .Include(c => c.Woman.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<KindOfPlace> GetKindOfPlacesByIdAsync(int id)
        {
            return await this.context.KindOfPlaces
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
