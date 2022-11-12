namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;

    public class MoodRepository : GenericRepository<Mood>, IMoodRepository
    {
        private readonly DataContext context;

        public MoodRepository(DataContext context) : base(context) 
        {
            this.context = context;
        }

        public IQueryable GetMoodWithWomanDiaries()
        {
            return this.context.Moods
                .Include(c => c.WomanDiaries)
                .OrderBy(c => c.Description);
        }
    }
}
