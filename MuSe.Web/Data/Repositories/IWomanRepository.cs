namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IWomanRepository : IGenericRepository<Woman>
    {
        IQueryable GetWomanWithUsers();

        Task<User> GetUserByIdAsync(string id);

        Task<Woman> GetWomanWithUserByIdAsync(string userId);

        Woman GetWomanUserById(int id);
    }
}
