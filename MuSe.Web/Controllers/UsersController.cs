//namespace MuSe.Web.Controllers
//{
//    using Microsoft.AspNetCore.Mvc;
//    using MuSe.Web.Data.Repositories;

//    [Route("api/[Controller]")]
//    public class UsersController : Controller
//    {
//        private readonly IUserRepository repository;

//        public UsersController(IUserRepository repository) 
//        {
//            this.repository = repository;
//        }

//        [HttpGet]
//        public IActionResult GetUsers() 
//        {
//            return Ok(this.repository.GetAll());
//        }
//    }
//}
