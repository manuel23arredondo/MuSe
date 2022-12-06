namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class ViolentometersController : Controller
    {
        private readonly IViolentometerRepository violentometerRepository;
        private readonly IReliabilityRepository reliabilityRepository;

        public ViolentometersController(IViolentometerRepository violentometerRepository, IReliabilityRepository reliabilityRepository)
        {
            this.violentometerRepository = violentometerRepository;
            this.reliabilityRepository = reliabilityRepository;
        }

        [HttpGet]
        public IActionResult GetViolentometers()
        {
            return Ok(this.violentometerRepository.GetAllViolentometersResponse());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ViolentometerResponse>> GetViolentometer(int id)
        {
            var violentometer = await this.violentometerRepository.GetViolentometersResponseById(id);

            if (violentometer == null)
            {
                return NotFound();
            }

            return violentometer;
        }

        [HttpPost]
        public async Task<IActionResult> PostHelpDirectory([FromBody] ViolentometerResponse violentometerResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reliability = reliabilityRepository.GetReliabilityByName(violentometerResponse.Reliability);
            if (reliability == null)
                return BadRequest("Reliability doesn´t exist");

            var violentometer = new Violentometer
            {
                Description = violentometerResponse.Description,
                Reliability = reliability
            };

            var newViolentometer = await violentometerRepository.CreateAsync(violentometer);
            return Ok(newViolentometer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutViolentometer([FromRoute] int id, [FromBody] ViolentometerResponse violentometerResponse)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != violentometerResponse.Id)
                return BadRequest();

            var oldViolentometer = await this.violentometerRepository.GetByIdAsync(id);
            if (oldViolentometer == null)
                return BadRequest("The violentometer does not exist.");

            var reliability = reliabilityRepository.GetReliabilityByName(violentometerResponse.Reliability);
            if (reliability == null)
                return BadRequest("Reliability doesn´t exist");

            oldViolentometer.Description = violentometerResponse.Description;
            oldViolentometer.Reliability = reliability;

            var updatedViolentometer = await this.violentometerRepository.UpdateAsync(oldViolentometer);

            return Ok(updatedViolentometer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHelpDirectory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var violentometer = await this.violentometerRepository.GetByIdAsync(id);
            if (violentometer == null)
                return BadRequest("Violentometer not exists");

            await violentometerRepository.DeleteAsync(violentometer);
            return Ok(violentometer);
        }
    }
}
