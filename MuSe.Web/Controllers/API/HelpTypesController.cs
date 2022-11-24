namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class HelpTypesController : Controller
    {
        private readonly IHelpTypeRepository repository;

        public HelpTypesController(IHelpTypeRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetHelpTypes()
        {
            return Ok(this.repository.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<HelpType>> GetHelpType(int id)
        {
            var helpType = await this.repository.GetByIdAsync(id);

            if (helpType == null)
            {
                return NotFound();
            }

            return helpType;
        }
    }
}
