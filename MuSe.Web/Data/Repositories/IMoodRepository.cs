namespace MuSe.Web.Data.Repositories
{
    using MuSe.Web.Data.Entities;
    using System.Linq;

    public interface IMoodRepository : IGenericRepository<Mood>
    {
        IQueryable GetMoodWithWomanDiaries();

        Mood GetMoodByName(string name);
    }
}
