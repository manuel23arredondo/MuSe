using System.Linq;

namespace MuSe.Web.Data.Repositories
{
    public interface IUserRepository
    {
        IQueryable GetUser();
    }
}
