namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class ReliabilitiesController : Controller
    {
        private readonly IReliabilityRepository reliabilityRepository;

        public ReliabilitiesController(IReliabilityRepository repository)
        {
            this.reliabilityRepository = repository;
        }

        [HttpGet]
        public IActionResult GetReliabilities()
        {
            return Ok(this.reliabilityRepository.GetReliabilityWithViolentometers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reliability>> GetReliability(int id)
        {
            var reliability = await this.reliabilityRepository.GetByIdAsync(id);

            if (reliability == null)
            {
                return NotFound();
            }

            return reliability;
        }

        [HttpPost]
        public async Task<IActionResult> PostReliability([FromBody] ReliabilityResponse reliabilityResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reliability = new Reliability
            {
                Description = reliabilityResponse.Description,
                Violentometers = (System.Collections.Generic.ICollection<Violentometer>)reliabilityResponse.Violentometers,
                Id = reliabilityResponse.Id
            };

            var newReliability = await reliabilityRepository.CreateAsync(reliability);
            return Ok(newReliability);
        }
    }
}
