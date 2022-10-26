namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Threading.Tasks;

    public interface IHelpTypeRespository : IGenericRepository<HelpType>
    {
        Task<HelpType> GetHelpTypeIdWithHelpDirectories(int id);
    }
}
