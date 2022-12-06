namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    public class KindOfPlaceRepository : GenericRepository<KindOfPlace>, IKindOfPlaceRepository
    {
        private readonly DataContext context;

        public KindOfPlaceRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetKindOfPlaceWithOwnWomanPlaces()
        {
            return this.context.KindOfPlaces
                .OrderBy(c => c.Description);
        }

        public KindOfPlace GetKindOfPlaceByName(string name)
        {
            return this.context.KindOfPlaces
                .FirstOrDefault(h => h.Description == name);
        }
    }
}
