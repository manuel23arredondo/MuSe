namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Common.Models;
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
                .Where(c => c.Woman.User.Email == name);
        }

        public IQueryable GetAllWomanDiariesWithMoodsAndUsers()
        {
            return context.WomanDiaries
                .Include(c => c.Mood)
                .Include(c => c.Woman.User)
                .OrderBy(c => c.Woman.User);
        }

        public async Task<WomanDiary> GetWomanDiariesWithMoodsAndUsersByIdAsync(int id)
        {
            return await context.WomanDiaries
                .Include(c => c.Mood)
                .Include(c => c.Woman.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Mood> GetMoodsByIdAsync(int id)
        {
            return await this.context.Moods
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public IQueryable<WomanDiaryResponse> GetAllWomanDiariesResponse()
        {
            return this.context.WomanDiaries
                .Select(h => new WomanDiaryResponse
                {
                    Id = h.Id,
                    Description = h.Description,
                    DiaryDate= h.DiaryDate,
                    WomanUserId = h.Woman.Id,
                    Mood = h.Mood.Description
                });
        }

        public async Task<WomanDiaryResponse> GetWomanDiaryResponseById(int id)
        {
            return await this.context.WomanDiaries
                .Select(h => new WomanDiaryResponse
                {
                    Id = h.Id,
                    Description = h.Description,
                    DiaryDate = h.DiaryDate,
                    WomanUserId = h.Woman.Id,
                    Mood = h.Mood.Description
                }).FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<WomanDiary> GetWomanDiariesByIdAsync(int id)
        {
            return await this.context.WomanDiaries
                .Include(c => c.Mood)
                .Include(c => c.Woman)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
