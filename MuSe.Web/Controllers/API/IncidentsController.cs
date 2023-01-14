namespace MuSe.Web.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using MuSe.Common.Models;
    using MuSe.Web.Data.Entities;
    using MuSe.Web.Data.Repositories;
    using System.Threading.Tasks;

    [Route("api/[Controller]")]
    public class IncidentsController : Controller
    {
        private readonly IIncidentRepository incidentRepository;
        private readonly IViolentometerRepository violentometerRepository;
        private readonly IWomanRepository womanRepository;

        public IncidentsController(IIncidentRepository incidentRepository, IViolentometerRepository violentometerRepository, IWomanRepository womanRepository)
        {
            this.incidentRepository = incidentRepository;
            this.violentometerRepository = violentometerRepository;
            this.womanRepository = womanRepository;
        }

        [HttpGet]
        public IActionResult GetIncidents()
        {
            return Ok(this.incidentRepository.GetAllIncidentsResponse());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentResponse>> GetIncident(int id)
        {
            var incident = await this.incidentRepository.GetIncidentsResponseById(id);

            if (incident == null)
            {
                return BadRequest("Incident does not exist");
            }

            return incident;
        }

        [HttpPost]
        public async Task<IActionResult> PostIncident([FromBody] IncidentResponse incidentResponse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var woman = womanRepository.GetWomanUserById(incidentResponse.WomanUserId);
            if (woman == null)
                return BadRequest("Woman does not exist");

            var violentometer = violentometerRepository.GetViolentometerByName(incidentResponse.Violentometer);
            if (violentometer == null)
                return BadRequest("Violentometer does not exist");

            var incident = new Incident
            {
                IncidentDescription= incidentResponse.IncidentDescription,
                AgressorDescription=incidentResponse.AgressorDescription,
                Longitude=incidentResponse.Longitude,
                Latitude=incidentResponse.Latitude,
                IncidentDate=incidentResponse.IncidentDate,
                Woman = woman,
                Violentometer=violentometer
            };

            var newIncident = await incidentRepository.CreateAsync(incident);
            return Ok(newIncident);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident([FromRoute] int id, [FromBody] IncidentResponse incidentResponse)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != incidentResponse.Id)
                return BadRequest();

            var oldIncident = await this.incidentRepository.GetByIdAsync(id);
            if (oldIncident == null)
                return BadRequest("Incident does not exist.");

            var violentometer = violentometerRepository.GetViolentometerByName(incidentResponse.Violentometer);
            if (violentometer == null)
                return BadRequest("Violentometer does not exist");

            var woman = womanRepository.GetWomanUserById(incidentResponse.WomanUserId);
            if (woman == null)
                return BadRequest("Woman does not exist");

            oldIncident.IncidentDescription= incidentResponse.IncidentDescription;
            oldIncident.AgressorDescription= incidentResponse.AgressorDescription;
            oldIncident.Longitude=incidentResponse.Longitude;
            oldIncident.Latitude=incidentResponse.Latitude;
            oldIncident.IncidentDate=incidentResponse.IncidentDate;
            oldIncident.Woman = woman;
            oldIncident.Violentometer=violentometer;

            var updatedIncident = await this.incidentRepository.UpdateAsync(oldIncident);

            return Ok(updatedIncident);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var incident = await this.incidentRepository.GetIncidentsByIdAsync(id);
            if (incident == null)
                return BadRequest("Incident does not exist");

            await incidentRepository.DeleteAsync(incident);
            return Ok(incident);
        }
    }
}