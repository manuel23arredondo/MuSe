namespace MuSe.Web.Data.Repositories
{
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IWomanDiaryRepository : IGenericRepository<WomanDiary>
    {
        IQueryable GetWomanDiariesWithMoodsAndUsers(string name);

        IQueryable GetAllWomanDiariesWithMoodsAndUsers();

        Task<WomanDiary> GetWomanDiariesWithMoodsAndUsersByIdAsync(int id);

        Task<Mood> GetMoodsByIdAsync(int id);

        IQueryable<WomanDiaryResponse> GetAllWomanDiariesResponse();

        Task<WomanDiaryResponse> GetWomanDiaryResponseById(int id);
    }
}
