namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IWomanDiaryRepository : IGenericRepository<WomanDiary>
    {
        IQueryable GetWomanDiariesWithMoodsAndUsers(string name);

        Task<Mood> GetMoodsByIdAsync(int id);
    }
}
