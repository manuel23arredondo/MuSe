namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class ReliabilitiesController : Controller
    {
        private readonly IReliabilityRepository repository;

        public ReliabilitiesController(IReliabilityRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult GetReliabilities()
        {
            return Ok(this.repository.GetReliabilityWithViolentometers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reliability>> GetReliability(int id)
        {
            var reliability = await this.repository.GetByIdAsync(id);

            if (reliability == null)
            {
                return NotFound();
            }

            return reliability;
        }
    }
}
