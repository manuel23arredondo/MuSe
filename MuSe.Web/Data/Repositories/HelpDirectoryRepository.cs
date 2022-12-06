namespace MuSe.Web.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    public class HelpDirectoryRepository : GenericRepository<HelpDirectory>, IHelpDirectoryRepository
    {
        private readonly DataContext context;

        public HelpDirectoryRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetHelpDirectoriesWithHelpTypes()
        {
            return this.context.HelpDirectories
                .Include(c => c.HelpType)
                .OrderBy(c => c.OrganizationName);

        }

        public async Task<HelpDirectory> GetHelpDirectoriesWithHelpTypesByIdAsync(int id)
        {
            return await context.HelpDirectories
                .Include(c => c.HelpType)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<HelpDirectoryResponse> GetHelpDirectoriesResponseById(int id)
        {
            return await this.context.HelpDirectories
                .Select(h => new HelpDirectoryResponse
                {
                    Id = h.Id,
                    OrganizationName = h.OrganizationName,
                    PhoneNumber = h.PhoneNumber,
                    Street = h.Street,
                    InsideNumber = h.InsideNumber,
                    OutsideNumber = h.OutsideNumber,
                    Colony = h.Colony,
                    PostCode = h.PostCode,
                    Email = h.Email,
                    Longitude = h.Longitude,
                    Latitude = h.Latitude,
                    HelpType = h.HelpType.Description
                }).FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<HelpType> GetHelpTypesByIdAsync(int id)
        {
            return await context.HelpTypes
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public IQueryable<HelpDirectoryResponse> GetAllHelpDirectoriesResponse()
        {
            return this.context.HelpDirectories
                .Select(h => new HelpDirectoryResponse
                {
                    Id = h.Id,
                    OrganizationName = h.OrganizationName,
                    PhoneNumber = h.PhoneNumber,
                    Street = h.Street,
                    InsideNumber = h.InsideNumber,
                    OutsideNumber = h.OutsideNumber,
                    Colony = h.Colony,
                    PostCode = h.PostCode,
                    Email = h.Email,
                    Longitude = h.Longitude,
                    Latitude = h.Latitude,
                    HelpType = h.HelpType.Description
                });
        }
    }
}
