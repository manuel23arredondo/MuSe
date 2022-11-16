namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class WomanDiaryRepository : GenericRepository<WomanDiary>, IWomanDiaryRepository
    {
        private readonly DataContext context;

        public WomanDiaryRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetWomanDiariesWithMoodsAndUsers(string name)
        {
            return context.WomanDiaries
                .Include(c => c.Mood)
                .Where(c => c.User.Email == name);
        }

        public async Task<WomanDiary> GetWomanDiariesWithMoodsAndUsersByIdAsync(int id)
        {
            return await context.WomanDiaries
                .Include(c => c.Mood)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Mood> GetMoodsByIdAsync(int id)
        {
            return await this.context.Moods
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
