namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Repositories;

    [Route("api/[Controller]")]
    public class HelpDirectoriesController : Controller
    {
        private readonly IHelpDirectoryRepository repository;

        public HelpDirectoriesController(IHelpDirectoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetHelpDirectories()
        {
            return Ok(this.repository.GetAll());
        }
    }
}
