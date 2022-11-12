//namespace MuSe.Web.Data.Repositories
//{
//    using Microsoft.EntityFrameworkCore;
//    using MuSe.Web.Data.Entities;
//    using System.Linq;

//    public class UserRepository : GenericRepository<User>, IUserRepository
//    {
//        private readonly DataContext context;

//        public UserRepository(DataContext context) : base(context)
//        {
//            this.context = context;
//        }

//        public IQueryable GetUsersWithWomansOrMonitors()
//        {
//            return this.context.Users
//                .Include(c => )
//                .OrderBy(c => c.Description);
//        }
//    }
//}
