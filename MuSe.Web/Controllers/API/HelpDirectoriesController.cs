namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

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
            return Ok(this.repository.GetHelpDirectoriesWithHelpTypes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HelpDirectory>> GetHelpDirectory(int id)
        {
            var helpDirectory = await this.repository.GetHelpDirectoriesWithHelpTypesByIdAsync(id);

            if (helpDirectory == null)
            {
                return NotFound();
            }

            return helpDirectory;
        }
    }
}
