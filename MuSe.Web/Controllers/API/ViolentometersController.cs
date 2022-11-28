namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class ViolentometersController : Controller
    {
        private readonly IViolentometerRepository repository;

        public ViolentometersController(IViolentometerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetViolentometers()
        {
            return Ok(this.repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Violentometer>> GetViolentometer(int id)
        {
            var violentometer = await this.repository.GetByIdAsync(id);

            if (violentometer == null)
            {
                return NotFound();
            }

            return violentometer;
        }
    }
}
