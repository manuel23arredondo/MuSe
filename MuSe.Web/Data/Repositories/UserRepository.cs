//namespace MuSe.Web.Data.Repositories
//{
//    using Microsoft.EntityFrameworkCore;
//    using System.Linq;

//    public class UserRepository : GenericRepository<UserRepository>, IUserRepository
//    {
//        private readonly DataContext context;

//        public UserRepository(DataContext context) : base(context)
//        {
//            this.context = context;
//        }

//        public IQueryable GetHelpTypeWithHelpDirectories()
//        {
//            return this.context.HelpTypes
//                .Include(c => c.HelpDirectories)
//                .OrderBy(c => c.Description);
//        }
//        public IQueryable GetUser()
//        {
//            throw new System.NotImplementedException();
//        }
//    }
//}
