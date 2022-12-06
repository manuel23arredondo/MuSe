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
                .OrderBy(c => c.Description);
        }

        public Mood GetMoodByName(string name)
        {
            return this.context.Moods
                .FirstOrDefault(h => h.Description == name);
        }
    }
}
